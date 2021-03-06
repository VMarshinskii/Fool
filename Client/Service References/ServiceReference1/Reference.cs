﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18444
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] cardsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int statusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] cards {
            get {
                return this.cardsField;
            }
            set {
                if ((object.ReferenceEquals(this.cardsField, value) != true)) {
                    this.cardsField = value;
                    this.RaisePropertyChanged("cards");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int status {
            get {
                return this.statusField;
            }
            set {
                if ((this.statusField.Equals(value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IFoolService")]
    public interface IFoolService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFoolService/Registration", ReplyAction="http://tempuri.org/IFoolService/RegistrationResponse")]
        Client.ServiceReference1.User Registration(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFoolService/Registration", ReplyAction="http://tempuri.org/IFoolService/RegistrationResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.User> RegistrationAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFoolService/GetCardsOnTable", ReplyAction="http://tempuri.org/IFoolService/GetCardsOnTableResponse")]
        System.Collections.Generic.Dictionary<int, int> GetCardsOnTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFoolService/GetCardsOnTable", ReplyAction="http://tempuri.org/IFoolService/GetCardsOnTableResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, int>> GetCardsOnTableAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFoolService/GetAllUsersOnTable", ReplyAction="http://tempuri.org/IFoolService/GetAllUsersOnTableResponse")]
        Client.ServiceReference1.User[] GetAllUsersOnTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFoolService/GetAllUsersOnTable", ReplyAction="http://tempuri.org/IFoolService/GetAllUsersOnTableResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.User[]> GetAllUsersOnTableAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFoolServiceChannel : Client.ServiceReference1.IFoolService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FoolServiceClient : System.ServiceModel.ClientBase<Client.ServiceReference1.IFoolService>, Client.ServiceReference1.IFoolService {
        
        public FoolServiceClient() {
        }
        
        public FoolServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FoolServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FoolServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FoolServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.ServiceReference1.User Registration(string name) {
            return base.Channel.Registration(name);
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.User> RegistrationAsync(string name) {
            return base.Channel.RegistrationAsync(name);
        }
        
        public System.Collections.Generic.Dictionary<int, int> GetCardsOnTable() {
            return base.Channel.GetCardsOnTable();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, int>> GetCardsOnTableAsync() {
            return base.Channel.GetCardsOnTableAsync();
        }
        
        public Client.ServiceReference1.User[] GetAllUsersOnTable() {
            return base.Channel.GetAllUsersOnTable();
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.User[]> GetAllUsersOnTableAsync() {
            return base.Channel.GetAllUsersOnTableAsync();
        }
    }
}
