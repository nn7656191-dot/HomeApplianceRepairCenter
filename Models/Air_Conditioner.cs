
namespace HomeApplianceRepairCenter.Models
{
    public class Air_Conditioner : Device
    {
        public Air_Conditioner(
            string serialNumber,
            string customerName,
            DateTime receivedDate,
            decimal partsCost = 0)
            : base(
                serialNumber,
                customerName,
                receivedDate,
                partsCost)
        {
        }

        public override decimal CalculateRepairCost()
        {
            decimal laborCost = 300m;

            return PartsCost + laborCost;
        }
    }
}
