
namespace HomeApplianceRepairCenter.Models
{
    public class Washing_Machine : Device
    {
        public Washing_Machine(
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
            decimal laborCost = 180m;

            return PartsCost + laborCost;
        }
    }
}
