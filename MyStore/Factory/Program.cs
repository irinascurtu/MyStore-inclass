// See https://aka.ms/new-console-template for more information
using Factory;
using static Factory.Enums;

Console.WriteLine("Hello, World!");

VehicleFactory factory = new ConcreteVehicleFactory();

Scooter? scooter = factory.GetVehicle(VehicleType.Scooter) as Scooter;

//var x =(int) VehicleType.Scooter;

scooter.Drive(50);

IDrivable bike = factory.GetVehicle(VehicleType.Bike);
bike.Drive(20);


Console.ReadKey();