
namespace HomeApplianceRepairCenter.Models
{
    public delegate void ApplianceStatusChangedHandler(
        object? sender,
        Repair_Status oldStatus,
        Repair_Status newStatus);

    public delegate void MaintenanceRequiredHandler(
        object? sender,
        string reason);
}
