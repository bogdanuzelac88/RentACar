﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACarWPFProject.RentACarServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RentACarServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        int Login(Common.Models.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<int> LoginAsync(Common.Models.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetManufacturers", ReplyAction="http://tempuri.org/IService1/GetManufacturersResponse")]
        System.Collections.Generic.List<Common.Models.Manufacturer> GetManufacturers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetManufacturers", ReplyAction="http://tempuri.org/IService1/GetManufacturersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Common.Models.Manufacturer>> GetManufacturersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCarModels", ReplyAction="http://tempuri.org/IService1/GetCarModelsResponse")]
        System.Collections.Generic.List<Common.Models.CarModel> GetCarModels(int manufacturerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCarModels", ReplyAction="http://tempuri.org/IService1/GetCarModelsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Common.Models.CarModel>> GetCarModelsAsync(int manufacturerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewManufacturer", ReplyAction="http://tempuri.org/IService1/AddNewManufacturerResponse")]
        void AddNewManufacturer(Common.Models.Manufacturer manufacturer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewManufacturer", ReplyAction="http://tempuri.org/IService1/AddNewManufacturerResponse")]
        System.Threading.Tasks.Task AddNewManufacturerAsync(Common.Models.Manufacturer manufacturer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewModel", ReplyAction="http://tempuri.org/IService1/AddNewModelResponse")]
        void AddNewModel(Common.Models.CarModel carModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewModel", ReplyAction="http://tempuri.org/IService1/AddNewModelResponse")]
        System.Threading.Tasks.Task AddNewModelAsync(Common.Models.CarModel carModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewCar", ReplyAction="http://tempuri.org/IService1/AddNewCarResponse")]
        void AddNewCar(Common.Models.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewCar", ReplyAction="http://tempuri.org/IService1/AddNewCarResponse")]
        System.Threading.Tasks.Task AddNewCarAsync(Common.Models.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCar", ReplyAction="http://tempuri.org/IService1/GetCarResponse")]
        System.Collections.Generic.List<Common.Models.Car> GetCar(int carModel_id, int manufacturer_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCar", ReplyAction="http://tempuri.org/IService1/GetCarResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Common.Models.Car>> GetCarAsync(int carModel_id, int manufacturer_id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : RentACarWPFProject.RentACarServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<RentACarWPFProject.RentACarServiceReference.IService1>, RentACarWPFProject.RentACarServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Login(Common.Models.Person person) {
            return base.Channel.Login(person);
        }
        
        public System.Threading.Tasks.Task<int> LoginAsync(Common.Models.Person person) {
            return base.Channel.LoginAsync(person);
        }
        
        public System.Collections.Generic.List<Common.Models.Manufacturer> GetManufacturers() {
            return base.Channel.GetManufacturers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Common.Models.Manufacturer>> GetManufacturersAsync() {
            return base.Channel.GetManufacturersAsync();
        }
        
        public System.Collections.Generic.List<Common.Models.CarModel> GetCarModels(int manufacturerId) {
            return base.Channel.GetCarModels(manufacturerId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Common.Models.CarModel>> GetCarModelsAsync(int manufacturerId) {
            return base.Channel.GetCarModelsAsync(manufacturerId);
        }
        
        public void AddNewManufacturer(Common.Models.Manufacturer manufacturer) {
            base.Channel.AddNewManufacturer(manufacturer);
        }
        
        public System.Threading.Tasks.Task AddNewManufacturerAsync(Common.Models.Manufacturer manufacturer) {
            return base.Channel.AddNewManufacturerAsync(manufacturer);
        }
        
        public void AddNewModel(Common.Models.CarModel carModel) {
            base.Channel.AddNewModel(carModel);
        }
        
        public System.Threading.Tasks.Task AddNewModelAsync(Common.Models.CarModel carModel) {
            return base.Channel.AddNewModelAsync(carModel);
        }
        
        public void AddNewCar(Common.Models.Car car) {
            base.Channel.AddNewCar(car);
        }
        
        public System.Threading.Tasks.Task AddNewCarAsync(Common.Models.Car car) {
            return base.Channel.AddNewCarAsync(car);
        }
        
        public System.Collections.Generic.List<Common.Models.Car> GetCar(int carModel_id, int manufacturer_id) {
            return base.Channel.GetCar(carModel_id, manufacturer_id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Common.Models.Car>> GetCarAsync(int carModel_id, int manufacturer_id) {
            return base.Channel.GetCarAsync(carModel_id, manufacturer_id);
        }
    }
}