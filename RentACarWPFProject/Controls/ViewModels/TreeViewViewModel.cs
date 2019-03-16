using Common.Models;
using RentACarService;
using RentACarWPFProject.Commands;
using RentACarWPFProject.Controls.Views;
using RentACarWPFProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows;
using System.Windows.Input;

namespace RentACarWPFProject.Controls.ViewModels
{
    public class TreeViewViewModel : ViewModelBase
    {
        private Manufacturer selectedManufacturer;
        private CarModel selectedCarModel;
        private List<Manufacturer> manufactuterList;
        private ICommand loadData, itemClicked;
        public EventHandler SelectionChanged;


        public TreeViewViewModel()
        {
        }
        #region Fields
        public Manufacturer SelectedManufacturer
        {
            get
            {
                return selectedManufacturer;
            }
            set
            {
                selectedManufacturer = value;

                OnPropertyChanged("SelectedManufacturer");
            }
        }

        public CarModel SelectedCarModel
        {
            get
            {
                return selectedCarModel;
            }
            set
            {

                selectedCarModel = value;
                OnPropertyChanged("SelectedCarModel");
            }
        }
        public List<Manufacturer> ManufactrerList
        {
            get
            {
                return manufactuterList;
            }
            set
            {
                manufactuterList = value;
                OnPropertyChanged("ManufactrerList");
            }
        }
        #endregion
        public ICommand LoadData
        {
            get
            {
                return loadData = new RelayCommand(param => OnLoadedExecute());
            }
        }

        private void OnLoadedExecute()
        {
            using (ServiceHost service = new ServiceHost(typeof(ManufacturerService), ManufacturerUri))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                service.Description.Behaviors.Add(smb);
                IManufacturerService manufacturer = new ManufacturerService();
                service.Open();
                ManufactrerList = manufacturer.GetManufacturers();
                service.Close();
            }
        }

        public ICommand ItemClicked
        {
            get
            {
                if (itemClicked == null)
                {
                    itemClicked = new RelayCommand(param => ItemClickedExecute(param));
                }
                return itemClicked;
            }
        }

        private bool CanItemClickedExecute()
        {
            return true;
        }

        private void ItemClickedExecute(Object param)
        {
            try
            {
                if (param is Manufacturer)
                {
                    var manufacturer = (Manufacturer)param;
                    SelectedCarModel = null;
                    SelectedManufacturer = manufacturer;

                    TreeViewItemSelectedEventArgs args = new TreeViewItemSelectedEventArgs();
                    args.Manufacturer = manufacturer;
                    args.Model = null;
                    OnItemSelected(args);
                }
                else if (param is CarModel)
                {
                    var model = (CarModel)param;
                    SelectedManufacturer = null;
                    SelectedCarModel = model;

                    TreeViewItemSelectedEventArgs args = new TreeViewItemSelectedEventArgs();
                    args.Manufacturer = null;
                    args.Model = model;
                    OnItemSelected(args);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Invalid treeview item object: {ex.Message}");
            }
           
        }

        protected virtual void OnItemSelected(TreeViewItemSelectedEventArgs e)
        {
           OnItemSelectedEventHandler handler = ItemSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event OnItemSelectedEventHandler ItemSelected;

        public TreeViewCars TreeViewCars
        {
            get {return default(TreeViewCars); }
    
        }
    }

    public delegate void OnItemSelectedEventHandler(Object sender, TreeViewItemSelectedEventArgs e);
}
