using System;
using System.ComponentModel;

namespace RentACarWPFProject.ViewModels
{
   public class ViewModelBase : INotifyPropertyChanged
    {

        #region ServiceAdresses

            public Uri VehicleUri = new Uri("http://localhost:8082/Design_Time_Addresses/RentACarService/VehicleService");
            public Uri ManufacturerUri = new Uri("http://localhost:8083/Design_Time_Addresses/RentACarService/VehicleService");
            public Uri ModelUri = new Uri(" http://localhost:8081/Design_Time_Addresses/RentACarService/ModelService/");
       

        #endregion ServiceAdresses

        #region PropertyChanged
        public delegate void ParameterChange(object parameter);
        public ParameterChange OnParameterChange { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion PropertyChanged



    }
    
}
