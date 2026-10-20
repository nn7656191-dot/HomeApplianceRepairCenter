
using HomeApplianceRepairCenter.Models;
using HomeApplianceRepairCenter.Services;

var center = new Repair_Center();


var refrigerator = new Refrigerator(
    "Ref100", "Moaaz", DateTime.Now, 1500m);

var washingMachine = new Washing_Machine(
    "WAS100", "Raneem", DateTime.Now, 2500m);

var airConditioner = new Air_Conditioner(
    "AC100", "Zainab", DateTime.Now, 1000m);

  var airConditioner1 = new Air_Conditioner(
    "AC200", "Asmaa", DateTime.Now, 1500m);
      
    var washingMachine1 = new Washing_Machine(
    "WAS200", "Aya", DateTime.Now, 1800m);

    
washingMachine.StatusChanged += (sender, oldStatus, newStatus) =>
{
    Console.WriteLine(
        $"EVENT: Status changed from {oldStatus} to {newStatus}");
};

washingMachine.MaintenanceRequired += (sender, reason) =>
{
    Console.WriteLine(
        $"MAINTENANCE ALERT: {reason}");
};



center.AddDevice(refrigerator);
center.AddDevice(washingMachine);
center.AddDevice(airConditioner);
center.AddDevice(washingMachine1);
center.AddDevice(airConditioner1);

Console.WriteLine("=== Registered Devices ===");

foreach (Device device in center.Devices)
{
    Console.WriteLine(
        $"Type: {device.GetType().Name}");

    Console.WriteLine(
        $"Serial: {device.SerialNumber}");

    Console.WriteLine(
        $"Customer: {device.CustomerName}");

    Console.WriteLine(
        $"Status: {device.Status}");

    Console.WriteLine(
        $"Repair Cost: {device.CalculateRepairCost()}");

    Console.WriteLine("----------------------------");
}


center.UpdateStatus("WAS100", Repair_Status.UnderRepair);
center.UpdateStatus("AC200", Repair_Status.Repaired);
center.UpdateStatus("WAS200", Repair_Status.Delivered);

Console.WriteLine(
    "Washing machine status after update: " +
    center.FindBySerialNumber("WAS100")?.Status);

    Console.WriteLine(
    "AirConditioner machine status after update: " +
    center.FindBySerialNumber("AC200")?.Status);

    Console.WriteLine(
    "Washing machine status after update: " +
    center.FindBySerialNumber("WAS200")?.Status);

Console.WriteLine();
Console.WriteLine("=== Repair Center Statistics ===");

Console.WriteLine(
    $"Total devices: {Repair_Statistics.TotalDevices}");

Console.WriteLine(
    $"Received: {Repair_Statistics.ReceivedCount}");

Console.WriteLine(
    $"Under repair: {Repair_Statistics.UnderRepairCount}");

Console.WriteLine(
    $"Repaired: {Repair_Statistics.RepairedCount}");

Console.WriteLine(
    $"Delivered: {Repair_Statistics.DeliveredCount}");