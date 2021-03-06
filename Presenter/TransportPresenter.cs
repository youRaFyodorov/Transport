﻿using System;
using System.Collections.Generic;
using View;
using Model;

namespace Presenter
{
    public class TransportPresenter
    {
        private ITransportView _view;

        public TransportPresenter(ITransportView view)
        {
            _view = view;
        }
        
        public void ShowVehicles(object sender, EventArgs e)
        {   
            List<VehicleInForm> vehicleInForms = new List<VehicleInForm>();
            var vehicles = ApplicationContext.Vehicles;
            var pictureBoxes = _view.GetPictureBoxWithVehicle();
            var informationOnForms = CreateListInformationOnForms();
            for (int i = 0; i < vehicles.Count; i++)
            {
                vehicleInForms.Add(new VehicleInForm(vehicles[i], pictureBoxes[i], informationOnForms[i]));
            }
            
            ApplicationContext.VehicleInForms = vehicleInForms;
        }

        private List<InformationOnForm> CreateListInformationOnForms()
        {
            var labels = _view.GetLabels();
            var progresBars = _view.GetProgressBars();

            List<InformationOnForm> informationOnForms = new List<InformationOnForm>();
            for (int i = 0; i < 5; i++)
            {
                informationOnForms.Add(new InformationOnForm
                {
                    BrandAndModel = labels[i * 4],
                    Time = labels[i * 4 + 1],
                    PassedWay = labels[i * 4 + 2],
                    Speed = labels[i * 4 + 3],
                    FuelLevel = progresBars[i],
                });
            }

            return informationOnForms;
        }

        public void Start()
        {
            ApplicationContext.VehicleInForms.ForEach(v => v.Launch());
        }

        public void Stop()
        {
            ApplicationContext.VehicleInForms.ForEach(v => v.Stop());
        }
    }
}
