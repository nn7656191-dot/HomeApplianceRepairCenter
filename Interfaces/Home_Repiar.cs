using HomeApplianceRepairCenter.Models;

namespace HomeApplianceRepairCenter.Interfaces
{
    public interface Home_Repiar
    {
        decimal CalculateRepairCost();

        void UpdateStatus(Repair_Status newStatus);
    }
}