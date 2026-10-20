
using System;
using HomeApplianceRepairCenter.Models;

namespace HomeApplianceRepairCenter.Services
{
    public static class Validation_Helper
    {
        public static void ValidateSerialNumber(string? serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                throw new ArgumentException(
                    "Serial number cannot be empty.",
                    nameof(serialNumber));
        }

        public static void ValidateCustomerName(string? customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException(
                    "Customer name cannot be empty.",
                    nameof(customerName));
        }

        public static void ValidateCost(decimal cost, string parameterName)
        {
            if (cost < 0)
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    "Cost cannot be negative.");
        }

        public static void ValidateReceivedDate(DateTime receivedDate)
        {
            if (receivedDate > DateTime.Now)
                throw new ArgumentException(
                    "Received date cannot be in the future.",
                    nameof(receivedDate));
        }

        public static void ValidateStatus(Repair_Status status)
        {
            if (!Enum.IsDefined(typeof(Repair_Status), status))
                throw new ArgumentException("Invalid repair status.");
        }
    }
}
