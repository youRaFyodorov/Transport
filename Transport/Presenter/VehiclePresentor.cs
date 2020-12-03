﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Model;
using Transport.View;

namespace Transport.Presenter
{
    class VehiclePresentor
    {
        private IVehicleView _view;

        public VehiclePresentor(IVehicleView view)
        {
            _view = view;
            _view.SetFuel(ApplicationContext.Fuels);
        }

        public void Submit()
        {
            ApplicationContext.Vehicles.Add(FactoryVehicles.CreateVehicle(
                _view.GetTypeVehicle(),
                _view.GetBrandVehicle(),
                _view.GetModelVehicle(),
                ApplicationContext.Fuels.Where(f => f.Name == _view.GetFuelNameVehicle()).FirstOrDefault(),
                _view.GetFuelConsumptionVehicle(),
                _view.GetFuelTankCapasityVehicle(),
                _view.GetMaxSpeedVehicle() / 3.6,
                _view.GetStartSpeedVehicle() / 3.6
            ));

            Console.WriteLine(_view.GetTypeVehicle().Contains("Car"));
            Console.WriteLine(_view.GetTypeVehicle());

            if (ApplicationContext.Vehicles.Count == 5)
            {
                _view.CloseForm();
                return;
            }

            _view.NextPage(ApplicationContext.Vehicles.Count);
        }
    }
}
