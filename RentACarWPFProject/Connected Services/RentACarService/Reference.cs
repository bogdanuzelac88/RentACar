﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACarWPFProject.RentACarService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RentACarService.IManufacturerService")]
    public interface IManufacturerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/GetManufacturers", ReplyAction="http://tempuri.org/IManufacturerService/GetManufacturersResponse")]
        RentACarWPFProject.RentACarService.GetManufacturersResponse GetManufacturers(RentACarWPFProject.RentACarService.GetManufacturersRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/GetManufacturers", ReplyAction="http://tempuri.org/IManufacturerService/GetManufacturersResponse")]
        System.Threading.Tasks.Task<RentACarWPFProject.RentACarService.GetManufacturersResponse> GetManufacturersAsync(RentACarWPFProject.RentACarService.GetManufacturersRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/AddNewManufacturer", ReplyAction="http://tempuri.org/IManufacturerService/AddNewManufacturerResponse")]
        RentACarWPFProject.RentACarService.AddNewManufacturerResponse AddNewManufacturer(RentACarWPFProject.RentACarService.AddNewManufacturerRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManufacturerService/AddNewManufacturer", ReplyAction="http://tempuri.org/IManufacturerService/AddNewManufacturerResponse")]
        System.Threading.Tasks.Task<RentACarWPFProject.RentACarService.AddNewManufacturerResponse> AddNewManufacturerAsync(RentACarWPFProject.RentACarService.AddNewManufacturerRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetManufacturers", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetManufacturersRequest {
        
        public GetManufacturersRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetManufacturersResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetManufacturersResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.Generic.List<Common.Models.Manufacturer> GetManufacturersResult;
        
        public GetManufacturersResponse() {
        }
        
        public GetManufacturersResponse(System.Collections.Generic.List<Common.Models.Manufacturer> GetManufacturersResult) {
            this.GetManufacturersResult = GetManufacturersResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddNewManufacturer", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AddNewManufacturerRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Common.Models.Manufacturer manufacturer;
        
        public AddNewManufacturerRequest() {
        }
        
        public AddNewManufacturerRequest(Common.Models.Manufacturer manufacturer) {
            this.manufacturer = manufacturer;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddNewManufacturerResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AddNewManufacturerResponse {
        
        public AddNewManufacturerResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManufacturerServiceChannel : RentACarWPFProject.RentACarService.IManufacturerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManufacturerServiceClient : System.ServiceModel.ClientBase<RentACarWPFProject.RentACarService.IManufacturerService>, RentACarWPFProject.RentACarService.IManufacturerService {
        
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
        
        public RentACarWPFProject.RentACarService.GetManufacturersResponse GetManufacturers(RentACarWPFProject.RentACarService.GetManufacturersRequest request) {
            return base.Channel.GetManufacturers(request);
        }
        
        public System.Threading.Tasks.Task<RentACarWPFProject.RentACarService.GetManufacturersResponse> GetManufacturersAsync(RentACarWPFProject.RentACarService.GetManufacturersRequest request) {
            return base.Channel.GetManufacturersAsync(request);
        }
        
        public RentACarWPFProject.RentACarService.AddNewManufacturerResponse AddNewManufacturer(RentACarWPFProject.RentACarService.AddNewManufacturerRequest request) {
            return base.Channel.AddNewManufacturer(request);
        }
        
        public System.Threading.Tasks.Task<RentACarWPFProject.RentACarService.AddNewManufacturerResponse> AddNewManufacturerAsync(RentACarWPFProject.RentACarService.AddNewManufacturerRequest request) {
            return base.Channel.AddNewManufacturerAsync(request);
        }
    }
}
