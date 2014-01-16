using AOE.Repository;
using AOE.Service;
using StructureMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AOE.WebUI
{
    public partial class EmployeeList : System.Web.UI.UserControl, IEmployeeListView
    {
        [Category("Behavior")]
        [Browsable(true)]
        [UrlProperty("*.xml")]
        public string XmlConfigFile { get; set; }

        private EmployeeListPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            EmployeeListConfig config = (EmployeeListConfig)ViewState["EmployeeListConfig"];
            if (config == null)
            {
                config = EmployeeListConfig.GetConfig(XmlConfigFile);
                ViewState["EmployeeListConfig"] = config;
            }
            _presenter = new EmployeeListPresenter(this, DataSourceResolver.GetConfiguredContainer(config).GetInstance<EmployeeService>());
            ddlJobList.DataBound += ddlJobList_DataBound;
            ddlJobList.SelectedIndexChanged += ddlJobList_SelectedIndexChanged;
            gvEmployeeList.RowCommand += gvEmployeeList_RowCommand;
            gvEmployeeList.PageIndexChanging += gvEmployeeList_PageIndexChanging;
            gvEmployeeList.RowEditing += gvEmployeeList_RowEditing;
            gvEmployeeList.RowCancelingEdit += gvEmployeeList_RowCancelingEdit;
            gvEmployeeList.RowUpdating += gvEmployeeList_RowUpdating;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeListConfig config = (EmployeeListConfig)ViewState["EmployeeListConfig"];
                gvEmployeeList.PageSize = config.PageSize;
                gvEmployeeList.Columns[2].Visible = config.IsEditable;
                ddlJobList.DataValueField = "Id";
                ddlJobList.DataTextField = "Name";
                ViewState["SortColumn"] = SortColumn.None;
                ViewState["SortOrder"] = SortOrder.None;
                _presenter.DisplayJobList();
            }
        }

        protected void ddlJobList_DataBound(object sender, EventArgs e)
        {
            _presenter.DisplayEmployeeList();
        }

        protected void ddlJobList_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvEmployeeList.EditIndex = -1;
            gvEmployeeList.PageIndex = 0;
            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SortByFullName" || e.CommandName == "SortBySalary")
            {
                SortColumn currentSortColumn = (SortColumn)ViewState["SortColumn"];
                SortOrder currentSortOrder = (SortOrder)ViewState["SortOrder"];
                SortColumn nextSortColumn = SortColumn.None;
                switch (e.CommandName) 
                {
                    case "SortByFullName":
                        nextSortColumn = SortColumn.FullName;
                        break;
                    case "SortBySalary":
                        nextSortColumn = SortColumn.Salary;
                        break;
                }
                if (currentSortColumn == nextSortColumn)
                {
                    if (currentSortOrder == SortOrder.Ascending)
                        ViewState["SortOrder"] = SortOrder.Descending;
                    else
                        ViewState["SortOrder"] = SortOrder.Ascending;
                }
                else
                {
                    ViewState["SortColumn"] = nextSortColumn;
                    ViewState["SortOrder"] = SortOrder.Ascending;
                }
                gvEmployeeList.EditIndex = -1;
                gvEmployeeList.PageIndex = 0;
                _presenter.DisplayEmployeeList();
            }
        }

        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.EditIndex = -1;
            gvEmployeeList.PageIndex = e.NewPageIndex;
            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployeeList.EditIndex = e.NewEditIndex;
            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployeeList.EditIndex = -1;
            _presenter.DisplayEmployeeList();
        }

        protected void gvEmployeeList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            gvEmployeeList.EditIndex = -1;
            _presenter.DisplayEmployeeList();
        }

        public void DisplayJobList(IList<Job> jobs)
        {
            ddlJobList.DataSource = jobs;
            ddlJobList.DataBind();
        }

        public void DisplayEmployeeList(IList<Employee> employees, int employeeVirtualCount)
        {
            gvEmployeeList.VirtualItemCount = employeeVirtualCount;
            gvEmployeeList.DataSource = employees;
            gvEmployeeList.DataBind();
        }

        public int JobId
        {
            get { return int.Parse(ddlJobList.SelectedValue); }
        }

        public SortColumn SortColumn
        {
            get { return (SortColumn)ViewState["SortColumn"]; }
        }

        public SortOrder SortOrder
        {
            get { return (SortOrder)ViewState["SortOrder"]; }
        }

        public int PageIndex
        {
            get { return gvEmployeeList.PageIndex; }
        }

        public int PageSize
        {
            get { return gvEmployeeList.PageSize; }
        }
    }
}