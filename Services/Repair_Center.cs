using System;
using System.Collections.Generic;
using HomeApplianceRepairCenter.Models;

namespace HomeApplianceRepairCenter.Services
{
    public class Repair_Center
    {
        private readonly List<Device> _devices = new();

        public IReadOnlyList<Device> Devices =>
            _devices.AsReadOnly();

        public void AddDevice(Device device)
        {
            if (device is null)
                throw new ArgumentNullException(nameof(device));

            foreach (Device existing in _devices)
            {
                if (string.Equals(
                    existing.SerialNumber,
                    device.SerialNumber,
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "An device with this serial number already exists.");
                }
            }

            _devices.Add(device);

            Repair_Statistics.RegisterDevice(device.Status);

            device.StatusChanged += OnStatusChanged;
        }

        private void OnStatusChanged(
            object? sender,
            Repair_Status oldStatus,
            Repair_Status newStatus)
        {
            Repair_Statistics.ChangeStatus(oldStatus, newStatus);
        }

        public Device? FindBySerialNumber(string serialNumber)
        {
            foreach (Device device in _devices)
            {
                if (string.Equals(
                    device.SerialNumber,
                    serialNumber,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return device;
                }
            }

            return null;
        }

        public bool UpdateStatus(
            string serialNumber,
            Repair_Status newStatus)
        {
            Device? device = FindBySerialNumber(serialNumber);

            if (device is null)
                return false;

            device.UpdateStatus(newStatus);
            return true;
        }
    }
}