
using Common.Models;
using RentACarService;
using RentACarWPFProject.Commands;
using RentACarWPFProject.Controls.ViewModels;
using RentACarWPFProject.Views;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows;
using System.Windows.Input;

namespace RentACarWPFProject.ViewModels
{
    public class AdministrationWindowViewModel : ViewModelBase
    {
        public TreeViewViewModel TreeViewViewModel { get; set; }
        public CarDataGridViewModel CarDataGridViewModel { get; set; }
        ICommand loadData;
        ICommand addNewCarCommand, deleteCarCommand, editCarCommand;

        public AdministrationWindowViewModel()
        {
            TreeViewViewModel = new TreeViewViewModel();
            CarDataGridViewModel = new CarDataGridViewModel();
            TreeViewViewModel.ItemSelected += CarDataGridViewModel.c_ItemSelected;
        }

        public ICommand EditCarCommand
        {
            get { return editCarCommand = new RelayCommand(param => EditCar()); }
        }

        private void EditCar()
        {
            if (CarDataGridViewModel.SelectedCar != null)
            {
                AddCarWindow window = new AddCarWindow(CarDataGridViewModel.SelectedCar);
                window.ShowDialog();
                CarDataGridViewModel.LoadData.Execute(null);
            }
        }

        public ICommand DeleteCarCommand
        {
            get { return deleteCarCommand = new RelayCommand(param => DeleteCar()); }
        }

        private void DeleteCar()
        {

            Car car = CarDataGridViewModel.SelectedCar;
            if (car != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you wish to delete the selected car ?", "Deletion Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (ServiceHost service = new ServiceHost(typeof(VehicleService), VehicleUri))
                    {
                        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                        smb.HttpGetEnabled = true;
                        smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                        service.Description.Behaviors.Add(smb);
                        IVehicleService vehicle = new VehicleService();
                        service.Open();
                        int result = vehicle.DeleteCar(car);
                        if (result > 0)
                            MessageBox.Show("Car successfully deleted.");
                        else
                            MessageBox.Show("Something went wrong.");
                        service.Close();
                    }

                    CarDataGridViewModel.LoadData.Execute(null);
                }
            }

        }

        public ICommand AddNewCarCommand
        {
            get
            {
                return addNewCarCommand = new RelayCommand(param => AddNewCar());
            }
        }

        private void AddNewCar()
        {
            AddCarWindow window = new AddCarWindow();
            window.ShowDialog();
            CarDataGridViewModel.LoadData.Execute(null);
            TreeViewViewModel.LoadData.Execute(null);
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
        }

        public AdministrationWindow AdministrationWindow
        {
            get { return default(AdministrationWindow); }
        }
    }
}
