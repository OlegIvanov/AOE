﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=4.0.30319.17929.
// 
namespace EmployeeWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="EmployeeWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class EmployeeWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetJobListOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetEmployeeListOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateEmployeeOperationCompleted;
        
        /// <remarks/>
        public EmployeeWebService() {
            this.Url = "http://localhost:3006/EmployeeWebService.asmx";
        }
        
        /// <remarks/>
        public event GetJobListCompletedEventHandler GetJobListCompleted;
        
        /// <remarks/>
        public event GetEmployeeListCompletedEventHandler GetEmployeeListCompleted;
        
        /// <remarks/>
        public event UpdateEmployeeCompletedEventHandler UpdateEmployeeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetJobList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public JobListResponse GetJobList() {
            object[] results = this.Invoke("GetJobList", new object[0]);
            return ((JobListResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetJobList(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetJobList", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public JobListResponse EndGetJobList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((JobListResponse)(results[0]));
        }
        
        /// <remarks/>
        public void GetJobListAsync() {
            this.GetJobListAsync(null);
        }
        
        /// <remarks/>
        public void GetJobListAsync(object userState) {
            if ((this.GetJobListOperationCompleted == null)) {
                this.GetJobListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetJobListOperationCompleted);
            }
            this.InvokeAsync("GetJobList", new object[0], this.GetJobListOperationCompleted, userState);
        }
        
        private void OnGetJobListOperationCompleted(object arg) {
            if ((this.GetJobListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetJobListCompleted(this, new GetJobListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetEmployeeList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest) {
            object[] results = this.Invoke("GetEmployeeList", new object[] {
                        employeeListRequest});
            return ((EmployeeListResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetEmployeeList(EmployeeListRequest employeeListRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetEmployeeList", new object[] {
                        employeeListRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public EmployeeListResponse EndGetEmployeeList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((EmployeeListResponse)(results[0]));
        }
        
        /// <remarks/>
        public void GetEmployeeListAsync(EmployeeListRequest employeeListRequest) {
            this.GetEmployeeListAsync(employeeListRequest, null);
        }
        
        /// <remarks/>
        public void GetEmployeeListAsync(EmployeeListRequest employeeListRequest, object userState) {
            if ((this.GetEmployeeListOperationCompleted == null)) {
                this.GetEmployeeListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetEmployeeListOperationCompleted);
            }
            this.InvokeAsync("GetEmployeeList", new object[] {
                        employeeListRequest}, this.GetEmployeeListOperationCompleted, userState);
        }
        
        private void OnGetEmployeeListOperationCompleted(object arg) {
            if ((this.GetEmployeeListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetEmployeeListCompleted(this, new GetEmployeeListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateEmployee", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest) {
            this.Invoke("UpdateEmployee", new object[] {
                        employeeUpdateRequest});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateEmployee", new object[] {
                        employeeUpdateRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndUpdateEmployee(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        public void UpdateEmployeeAsync(EmployeeUpdateRequest employeeUpdateRequest) {
            this.UpdateEmployeeAsync(employeeUpdateRequest, null);
        }
        
        /// <remarks/>
        public void UpdateEmployeeAsync(EmployeeUpdateRequest employeeUpdateRequest, object userState) {
            if ((this.UpdateEmployeeOperationCompleted == null)) {
                this.UpdateEmployeeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateEmployeeOperationCompleted);
            }
            this.InvokeAsync("UpdateEmployee", new object[] {
                        employeeUpdateRequest}, this.UpdateEmployeeOperationCompleted, userState);
        }
        
        private void OnUpdateEmployeeOperationCompleted(object arg) {
            if ((this.UpdateEmployeeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateEmployeeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class JobListResponse {
        
        private Job[] jobsField;
        
        /// <remarks/>
        public Job[] Jobs {
            get {
                return this.jobsField;
            }
            set {
                this.jobsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Job {
        
        private int idField;
        
        private string nameField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EmployeeUpdateRequest {
        
        private int employeeIdField;
        
        private double salaryField;
        
        /// <remarks/>
        public int EmployeeId {
            get {
                return this.employeeIdField;
            }
            set {
                this.employeeIdField = value;
            }
        }
        
        /// <remarks/>
        public double Salary {
            get {
                return this.salaryField;
            }
            set {
                this.salaryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Employee {
        
        private int idField;
        
        private string fullNameField;
        
        private double salaryField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string FullName {
            get {
                return this.fullNameField;
            }
            set {
                this.fullNameField = value;
            }
        }
        
        /// <remarks/>
        public double Salary {
            get {
                return this.salaryField;
            }
            set {
                this.salaryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EmployeeListResponse {
        
        private Employee[] employeesField;
        
        private int employeeVirtualCountField;
        
        /// <remarks/>
        public Employee[] Employees {
            get {
                return this.employeesField;
            }
            set {
                this.employeesField = value;
            }
        }
        
        /// <remarks/>
        public int EmployeeVirtualCount {
            get {
                return this.employeeVirtualCountField;
            }
            set {
                this.employeeVirtualCountField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EmployeeListRequest {
        
        private int jobIdField;
        
        private SortColumn sortColumnField;
        
        private SortOrder sortOrderField;
        
        private int pageSizeField;
        
        private int pageIndexField;
        
        /// <remarks/>
        public int JobId {
            get {
                return this.jobIdField;
            }
            set {
                this.jobIdField = value;
            }
        }
        
        /// <remarks/>
        public SortColumn SortColumn {
            get {
                return this.sortColumnField;
            }
            set {
                this.sortColumnField = value;
            }
        }
        
        /// <remarks/>
        public SortOrder SortOrder {
            get {
                return this.sortOrderField;
            }
            set {
                this.sortOrderField = value;
            }
        }
        
        /// <remarks/>
        public int PageSize {
            get {
                return this.pageSizeField;
            }
            set {
                this.pageSizeField = value;
            }
        }
        
        /// <remarks/>
        public int PageIndex {
            get {
                return this.pageIndexField;
            }
            set {
                this.pageIndexField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum SortColumn {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        FullName,
        
        /// <remarks/>
        Salary,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum SortOrder {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        Ascending,
        
        /// <remarks/>
        Descending,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    public delegate void GetJobListCompletedEventHandler(object sender, GetJobListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetJobListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetJobListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public JobListResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((JobListResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    public delegate void GetEmployeeListCompletedEventHandler(object sender, GetEmployeeListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetEmployeeListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetEmployeeListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public EmployeeListResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((EmployeeListResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
    public delegate void UpdateEmployeeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}