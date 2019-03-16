using Common.Models;
using RentACarWPFProject.Commands;
using RentACarWPFProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RentACarWPFProject.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string name;
        private string surname;
        private string password;
        private string email;
        private ICommand login;
        private ICommand register;

        public LoginViewModel()
        {

        }

        #region Properties

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                LoginWindow window = new LoginWindow();
                if (window.txtRegisterPassword.Text == window.txtRepeatPassword.Text)
                {
                    password = value;
                }
                else
                {
                    MessageBox.Show("Wrong password!");
                }
               
                OnPropertyChanged("Password");
            }
        }
        
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        #endregion Properties
        #region Commands

        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(param), param => CanLoginExecute(param));
                }
                return login;
            }
        }

        public LoginWindow LoginWindow
        {
            get { return default(LoginWindow); }
        }

        private bool CanLoginExecute(object param)
        {
            if (Name == null || Surname == null || Password == null)
            {
                return false;
            }
            return true;
        }

        private void LoginExecute(object param)
        {
            try
            {
                //Window loginWindow = (Window)param;
                //using (ServiceHost service = new ServiceHost(typeof(IVehicleService), VehicleUri))
                //{
                //    IVehicleService vehicle = new VehicleService();
                //    service.Open();
                //    int result = vehicle.DeleteCar(car);
                //    if (result > 0)
                //        MessageBox.Show("Car successfully deleted.");
                //    else
                //        MessageBox.Show("Something went wrong.");
                //}
                //using (RentACarServiceReference.Service1Client service = new RentACarServiceReference.Service1Client())
                //{
                //    Person customer = new Person();
                //    customer.Name = Name;
                //    customer.Surname = Surname;
                //    customer.Password = Password;
                //    int res = service.Login(customer);
                //    if (res == 0)
                //    {
                //        MessageBox.Show("There is no user with data entered!");
                //    }

                //    else
                //    {
                //        AdministrationWindow mainWindow = new AdministrationWindow();
                //        mainWindow.Show();
                //        loginWindow.Close();

                //    }
                //} 
            }

            catch (Exception)
            {

                throw;
            }
        }
        public ICommand Register
        {
            get
            {
                return register = new RelayCommand(param => RegisterExecute());
            }
        }


        private void RegisterExecute()
        {
            try
            {
            //    using (RentACarServiceReference.Service1Client service = new RentACarServiceReference.Service1Client())
            //    {
            //        Person person = new Person();
            //        person.Name = Name;
            //        person.Surname = Surname;
            //        person.Password = Password;
            //    }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
