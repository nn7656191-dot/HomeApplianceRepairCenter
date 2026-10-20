using System.Collections.Generic;
using HomeApplianceRepairCenter.Models;

namespace HomeApplianceRepairCenter.Services
{
    public static class Repair_Statistics
    {
        private static int _totalDevices;

        private static readonly Dictionary<Repair_Status, int>
            _countsByStatus = new()
            {
                { Repair_Status.Received, 0 },
                { Repair_Status.UnderRepair, 0 },
                { Repair_Status.Repaired, 0 },
                { Repair_Status.Delivered, 0 }
            };

        public static int TotalDevices => _totalDevices;

        public static int ReceivedCount =>
            GetCountByStatus(Repair_Status.Received);

        public static int UnderRepairCount =>
            GetCountByStatus(Repair_Status.UnderRepair);

        public static int RepairedCount =>
            GetCountByStatus(Repair_Status.Repaired);

        public static int DeliveredCount =>
            GetCountByStatus(Repair_Status.Delivered);

        public static int GetCountByStatus(Repair_Status status)
        {
            return _countsByStatus.TryGetValue(
                status, out int count) ? count : 0;
        }

        internal static void RegisterDevice(Repair_Status status)
        {
            _totalDevices++;
            _countsByStatus[status]++;
        }

        internal static void ChangeStatus(
            Repair_Status oldStatus,
            Repair_Status newStatus)
        {
            if (oldStatus == newStatus)
                return;

            if (_countsByStatus.ContainsKey(oldStatus)
                && _countsByStatus[oldStatus] > 0)
            {
                _countsByStatus[oldStatus]--;
            }

            if (_countsByStatus.ContainsKey(newStatus))
            {
                _countsByStatus[newStatus]++;
            }
        }
    }
}