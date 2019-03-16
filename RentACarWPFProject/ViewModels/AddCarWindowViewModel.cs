using Common.Models;
using Microsoft.Win32;
using RentACarService;
using RentACarWPFProject.Commands;
using RentACarWPFProject.Enums;
using RentACarWPFProject.Views;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows;
using System.Windows.Input;
using static RentACarWPFProject.Enums.CarTypeEnumumeration;

namespace RentACarWPFProject.ViewModels
{
    public class AddCarWindowViewModel : ViewModelBase
    {
        private ICommand loadData;
        private List<Manufacturer> manufactuterList;
        private CarModel selectedCarModel;
        private ICommand manufacturerSelected;
        private Manufacturer selectedManufacturer;
        private byte[] carImage;
        private ICommand addNewManufacturer;
        private string manufacturerName;
        private byte[] manufacturerLogoImage;
        private ICommand addNewImage;
        private int cubicCapacity;
        private string modelName;
        private int year;
        private ICommand addNewModel;
        private string fuel;
        private float fuelConsuption;
        private int power;
        private ICommand addNewCar;
        private int kilometers;
        private readonly List<CarTypeEnum> cartypeEnumList;
        private string cartype;
        private string town;
        private int id;
        //Determines if the window is editing or adding a car do the database
        public bool Editing { get; set; }
        //Car that is about to be edited
        public Car Car { get; set; }

        public AddCarWindowViewModel()
        {
            CarTypeEnumumeration cte = new CarTypeEnumumeration();
            cartypeEnumList = cte.CarTypeEnumList;
        }

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public byte[] CarImage
        {
            get
            {
                return carImage;
            }
            set
            {
                carImage = value;
                OnPropertyChanged("CarImage");
            }
        }

        public string ManufacturerName
        {
            get
            {
                return manufacturerName;
            }
            set
            {
                manufacturerName = value;
                OnPropertyChanged("ManufacturerName");
            }
        }
        public byte[] ManufacturerLogoImage
        {
            get
            {
                return manufacturerLogoImage;
            }
            set
            {
                manufacturerLogoImage = value;
                OnPropertyChanged("ManufacturerLogoImage");
            }
        }

        public int CubicCapacity
        {
            get
            {
                return cubicCapacity;
            }
            set
            {
                cubicCapacity = value;
                OnPropertyChanged("CubicCapacity");
            }
        }

        public string ModelName
        {
            get { return modelName; }
            set
            {
                modelName = value;
                OnPropertyChanged("ModelName");
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public string Fuel
        {
            get
            {
                return fuel;
            }
            set
            {
                fuel = value;
                OnPropertyChanged("Fuel");
            }
        }

        public float FuelConsuption
        {
            get
            {
                return fuelConsuption;
            }
            set
            {
                fuelConsuption = value;
                OnPropertyChanged("FuelConsuption");
            }
        }

        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
                OnPropertyChanged("Power");
            }
        }

        public int Kilometers
        {
            get
            {
                return kilometers;
            }
            set
            {
                kilometers = value;
                OnPropertyChanged("Kilometers");
            }
        }

        public List<CarTypeEnum> CartypeEnumList
        {
            get
            {
                return cartypeEnumList;
            }
        }
        public string Cartype
        {
            get
            {
                return cartype;
            }
            set
            {
                cartype = value;
                OnPropertyChanged("Cartype");
            }
        }

        public string Town
        {
            get
            {
                return town;
            }
            set
            {
                town = value;
                OnParameterChange("Town");
            }
        }
        #endregion

        #region ICommand 

        public ICommand ManufacturerSelected
        {
            get
            {
                return manufacturerSelected = new RelayCommand(param => ManufacturerSelectedExecute());
            }
        }

        public ICommand LoadData
        {
            get
            {
                return loadData = new RelayCommand(param => LoadDataExecute());
            }
        }

        private void LoadDataExecute()
        {
            GetManufacturers();
            if (Editing)
            {
                CarImage = Car.Image;
                Cartype = Car.Type;
                CubicCapacity = Car.CubicCapacity;
                Fuel = Car.Fuel;
                FuelConsuption = (float)Car.FuelConsuption;
                Kilometers = Car.Kilometers;
                Power = Car.Power;
                Id = Car.Id;
                SelectedCarModel = (from manufacturer in ManufactrerList
                                    from model in manufacturer.Models
                                    where model.Id == Car.IdModel
                                    select model).First();
                SelectedManufacturer = (from manufacturer in ManufactrerList
                                        from model in manufacturer.Models
                                        where model.Id == Car.IdModel
                                        select manufacturer).First();
            }
        }

        public ICommand AddNewManufacturer
        {
            get
            {
                return addNewManufacturer = new RelayCommand(param => AddNewManufacturerExecute());
            }
        }

        public ICommand AddNewImage
        {
            get
            {
                return addNewImage = new RelayCommand(param => AddNewImageExecute(param));
            }

        }

        public ICommand AddNewModel
        {
            get
            {
                return addNewModel = new RelayCommand(param => AddNewModelExecute());
            }
        }

        public ICommand AddNewCar
        {
            get
            {
                return addNewCar = new RelayCommand(param => AddNewCarExecute());
            }
        }

        public AddCarWindow AddCarWindow
        {
            get { return default(AddCarWindow); }

        }

        #endregion

        #region Methods

        private void ManufacturerSelectedExecute()
        {
        }

        private void GetManufacturers()
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
            };
        }

        ///<summary>method <c>AddNewManufacturerExecute</c> inserts a new manufacturer entry via the wcf service into the database.</summary>
        private void AddNewManufacturerExecute()
        {
            using (ServiceHost service = new ServiceHost(typeof(ManufacturerService), ManufacturerUri))
            {
                Manufacturer manufactrer = new Manufacturer()
                {
                    Name = ManufacturerName,
                    Logo = ManufacturerLogoImage
                };

                IManufacturerService manufacturer = new ManufacturerService();
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                service.Description.Behaviors.Add(smb);
                service.Open();
                manufacturer.AddNewManufacturer(manufactrer);
                service.Close();
                GetManufacturers();
                //AddCarWindow acw = new AddCarWindow();
                //acw.grpAddManufacturer.Visibility = Visibility.Collapsed;
            }
        }

        private void AddNewImageExecute(object param)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == true)
            {
                using (Stream fs = openFD.OpenFile())
                {
                    if (fs != null)
                    {
                        var bt = new byte[fs.Length];
                        fs.Read(bt, 0, bt.Length);
                        string option = param as string;
                        if (option == "carImage")
                        {
                            CarImage = bt;
                        }
                        else
                        {
                            ManufacturerLogoImage = bt;
                        }
                    }

                }
            }
        }

        private void AddNewModelExecute()
        {
            using (ServiceHost service = new ServiceHost(typeof(ModelService), ModelUri))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                service.Description.Behaviors.Add(smb);
                IModelService model = new ModelService();
                service.Open();
                CarModel carModel = new CarModel();
                carModel.Name = ModelName;
                carModel.Year = Year;
                carModel.ManufacturerId = SelectedManufacturer.Id;
                model.AddNewModel(carModel);
                service.Close();
                GetManufacturers();
                AddCarWindow acw = new AddCarWindow();
                acw.grpModel.Visibility = Visibility.Collapsed;
            }
        }

        private void AddNewCarExecute()
        {
            Car car = new Car();
            car.Available = true;
            car.Image = CarImage;
            car.TotalRentals = 0;
            car.CubicCapacity = CubicCapacity;
            car.Fuel = Fuel;
            car.FuelConsuption = FuelConsuption;
            car.Power = Power;
            car.IdModel = SelectedCarModel.Id;
            car.Type = Cartype;
            car.Kilometers = Kilometers;
            IVehicleService vehicle = new VehicleService();
            car.Town = Town;
            if (Editing)
            {
                car.Id = Id;
                using (ServiceHost service = new ServiceHost(typeof(VehicleService), VehicleUri))
                {
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    service.Description.Behaviors.Add(smb);
                    service.Open();
                    vehicle.UpdateCar(car);
                    service.Close();
                }
            }
            else
            {
                using (ServiceHost service = new ServiceHost(typeof(VehicleService), VehicleUri))
                {
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    service.Description.Behaviors.Add(smb);
                    service.Open();
                    vehicle.UpdateCar(car);
                    service.Close();
                }
            }
        }
        #endregion
    }
}
