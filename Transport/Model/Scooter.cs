﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Model
{
    class Scooter: Vehicle
    {
        public Scooter(string vehicleBrand, string model, Fuel fuel, double fuelConsumption,
                   int fuelTankCapasity, double maxSpeed, double startSpead)
        {
            VehicleBrand = vehicleBrand;
            Model = model;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            FuelTankCapasity = fuelTankCapasity;
            MaxSpeed = maxSpeed;
            StartSpeed = startSpead;

            Type = "Scooter";
            QuantityOfWheels = 2;
            QuantityOfPassengers = 1;
            Payload = 60;
            Propeller = "Human";
            Purpose = "Personal";

            Refuel(fuelTankCapasity);
        }
    }
}
