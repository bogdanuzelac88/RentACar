using Common.Models;
using RentACarWPFProject.Commands;
using RentACarWPFProject.Controls.Views;
using RentACarWPFProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using RentACarService;
using System.ServiceModel.Description;

namespace RentACarWPFProject.Controls.ViewModels
{
    public class CarDataGridViewModel : ViewModelBase
    {

        private Manufacturer SelectedManufacturer;
        private Car selectedCar;
        private ICommand loadData;
        private CarModel selectedModel;
        
        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged("SelectedCar"); }
        }

        public Manufacturer MyProperty
        {
            get { return SelectedManufacturer; }
            set { SelectedManufacturer = value; }
        }

        public CarModel SelectedModel
        {
            get { return selectedModel; }
            set { selectedModel = value; }
        }

        public CarDataGridViewModel()
        {
        }

        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged("Cars"); }
        }


        public void c_ItemSelected(object sender, TreeViewItemSelectedEventArgs e)
        {
            SelectedModel = e.Model;
            SelectedManufacturer = e.Manufacturer;
            using (ServiceHost service = new ServiceHost(typeof(VehicleService), VehicleUri))
            {
                IVehicleService vehicle = new VehicleService();
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                service.Description.Behaviors.Add(smb);
                service.Open();
                if (SelectedModel != null)
                {

                    Cars = vehicle.GetCarByModel(SelectedModel);
                }
                else if (SelectedManufacturer != null)
                {
                    Cars = vehicle.GetCarByManufacturer(SelectedManufacturer);
                }
                service.Close();
            }
        }
        public ICommand LoadData
        {
            get
            {
                return loadData = new RelayCommand(param => OnLoadedExecute());
            }
        }

        private void OnLoadedExecute()
        {
            using (ServiceHost service = new ServiceHost(typeof(VehicleService), VehicleUri))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                service.Description.Behaviors.Add(smb);
                IVehicleService vehicle = new VehicleService();
                service.Open();
                Cars = vehicle.GetCars();
                service.Close();
            }
        }

 

        public CarDataGrid CarDataGrid
        {
            get { return default(CarDataGrid); }
           
        }

        protected virtual void OnCarSelected(DataGridItemSelectedEventArgs e)
        {
            OnCarSelectedEventHandler handler = CarSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event OnCarSelectedEventHandler CarSelected;
    }

    public delegate void OnCarSelectedEventHandler(Object sender, DataGridItemSelectedEventArgs e);
}
