﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACarWPFProject.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IManufacturerService")]
    public interface IManufacturerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/GetManufacturers", ReplyAction="http://tempuri.org/IManufacturerService/GetManufacturersResponse")]
        Common.Models.Manufacturer[] GetManufacturers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/GetManufacturers", ReplyAction="http://tempuri.org/IManufacturerService/GetManufacturersResponse")]
        System.Threading.Tasks.Task<Common.Models.Manufacturer[]> GetManufacturersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/AddNewManufacturer", ReplyAction="http://tempuri.org/IManufacturerService/AddNewManufacturerResponse")]
        void AddNewManufacturer(Common.Models.Manufacturer manufacturer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/AddNewManufacturer", ReplyAction="http://tempuri.org/IManufacturerService/AddNewManufacturerResponse")]
        System.Threading.Tasks.Task AddNewManufacturerAsync(Common.Models.Manufacturer manufacturer);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManufacturerServiceChannel : RentACarWPFProject.ServiceReference1.IManufacturerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManufacturerServiceClient : System.ServiceModel.ClientBase<RentACarWPFProject.ServiceReference1.IManufacturerService>, RentACarWPFProject.ServiceReference1.IManufacturerService {
        
        public ManufacturerServiceClient() {
        }
        
        public ManufacturerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManufacturerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManufacturerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManufacturerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Common.Models.Manufacturer[] GetManufacturers() {
            return base.Channel.GetManufacturers();
        }
        
        public System.Threading.Tasks.Task<Common.Models.Manufacturer[]> GetManufacturersAsync() {
            return base.Channel.GetManufacturersAsync();
        }
        
        public void AddNewManufacturer(Common.Models.Manufacturer manufacturer) {
            base.Channel.AddNewManufacturer(manufacturer);
        }
        
        public System.Threading.Tasks.Task AddNewManufacturerAsync(Common.Models.Manufacturer manufacturer) {
            return base.Channel.AddNewManufacturerAsync(manufacturer);
        }
    }
}
