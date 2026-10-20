
namespace HomeApplianceRepairCenter.Models
{
    public class Refrigerator : Device
    {
        public Refrigerator(
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
            decimal laborCost = 250m;

            return PartsCost + laborCost;
        }
    }
}
