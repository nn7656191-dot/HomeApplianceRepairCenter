
using System;
using HomeApplianceRepairCenter.Interfaces;
using HomeApplianceRepairCenter.Services;

namespace HomeApplianceRepairCenter.Models
{
    public abstract class Device : Home_Repiar
    {
        private readonly string _serialNumber;
        private readonly DateTime _receivedDate;
        private string _customerName;
        private decimal _partsCost;
        private Repair_Status _status;

        public string SerialNumber => _serialNumber;
        public DateTime ReceivedDate => _receivedDate;

        public string CustomerName
        {
            get => _customerName;
            set
            {
                 Validation_Helper.ValidateCustomerName(value);
                 _customerName = value;
            }
        }

        public decimal PartsCost
        {
            get => _partsCost;
            set
            {
                 Validation_Helper.ValidateCost(value, nameof(value));
                   _partsCost = value;
            }
        }

        public Repair_Status Status => _status;

        // Event: fires when the status changes.
        public event ApplianceStatusChangedHandler? StatusChanged;

        // Event: fires when a maintenance issue is reported.
        public event MaintenanceRequiredHandler? MaintenanceRequired;

        protected Device(
            string serialNumber,
            string customerName,
            DateTime receivedDate,
            decimal partsCost = 0)
        {
           Validation_Helper.ValidateSerialNumber(serialNumber);
           Validation_Helper.ValidateCustomerName(customerName);
           Validation_Helper.ValidateReceivedDate(receivedDate);
           Validation_Helper.ValidateCost(partsCost, nameof(partsCost));

            _serialNumber = serialNumber;
            _customerName = customerName;
            _receivedDate = receivedDate;
            _partsCost = partsCost;
            _status = Repair_Status.Received;
        }

        public void UpdateStatus(Repair_Status newStatus)
        {
             Validation_Helper.ValidateStatus(newStatus);

            Repair_Status oldStatus = _status;

            if (oldStatus == newStatus)
                return;

            _status = newStatus;

            StatusChanged?.Invoke(
                this, oldStatus, newStatus);
        }

        public void ReportMaintenanceCondition(string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException(
                    "A maintenance reason is required.",
                    nameof(reason));

            MaintenanceRequired?.Invoke(this, reason);
        }

        public abstract decimal CalculateRepairCost();
    }
}
