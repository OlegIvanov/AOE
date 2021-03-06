﻿using AOE.Presentation;
using AOE.Service;
using AOE.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
            EmployeeListControlConfig employeeListConfig = (EmployeeListControlConfig)ViewState["EmployeeListConfig"];
            if (employeeListConfig == null)
            {
                employeeListConfig = EmployeeListControlConfig.GetConfig(XmlConfigFile);
                ViewState["EmployeeListConfig"] = employeeListConfig;
            }

            _presenter = new EmployeeListPresenter(this, EmployeeListControlDataSourceInjector.GetConfiguredContainer(employeeListConfig).GetInstance<EmployeeService>());

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
                EmployeeListControlConfig employeeListConfig = (EmployeeListControlConfig)ViewState["EmployeeListConfig"];

                gvEmployeeList.PageSize = employeeListConfig.PageSize;
                gvEmployeeList.Columns[2].Visible = employeeListConfig.IsEditable;

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
                        {
                            nextSortColumn = SortColumn.FullName;
                            break;
                        }
                    case "SortBySalary":
                        {
                            nextSortColumn = SortColumn.Salary;
                            break;
                        }
                }
                if (currentSortColumn == nextSortColumn)
                {
                    if (currentSortOrder == SortOrder.Ascending)
                    {
                        ViewState["SortOrder"] = SortOrder.Descending;
                    }
                    else
                    {
                        ViewState["SortOrder"] = SortOrder.Ascending;
                    }
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
            _presenter.UpdateEmployeeSalary();

            gvEmployeeList.EditIndex = -1;

            _presenter.DisplayEmployeeList();
        }

        public void DisplayJobList(List<JobViewModel> jobs)
        {
            ddlJobList.DataSource = jobs;
            ddlJobList.DataBind();
        }

        public void DisplayEmployeeList(List<EmployeeViewModel> employees, int employeeTotalCount)
        {
            gvEmployeeList.VirtualItemCount = employeeTotalCount;

            gvEmployeeList.DataSource = employees;
            gvEmployeeList.DataBind();
        }

        public int JobId
        {
            get { return int.Parse(ddlJobList.SelectedValue); }
        }

        public string SortExpression
        {
            get 
            {
                SortColumn sortColumn = (SortColumn)ViewState["SortColumn"];
                SortOrder sortOrder = (SortOrder)ViewState["SortOrder"];
                StringBuilder sortExpression = new StringBuilder();

                switch (sortColumn)
                {
                    case SortColumn.FullName:
                        {
                            sortExpression.Append("FullName");
                            break;
                        }
                    case SortColumn.Salary:
                        {
                            sortExpression.Append("Salary");
                            break;
                        }
                }
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        {
                            sortExpression.Append("Ascending");
                            break;
                        }
                    case SortOrder.Descending:
                        {
                            sortExpression.Append("Descending");
                            break;
                        }
                }
                return sortExpression.ToString();
            }
        }

        public int PageIndex
        {
            get { return gvEmployeeList.PageIndex; }
        }

        public int PageSize
        {
            get { return gvEmployeeList.PageSize; }
        }

        public int EmployeeId
        {
            get 
            {
                HiddenField hfEmployeeId = (HiddenField)gvEmployeeList.Rows[gvEmployeeList.EditIndex].FindControl("hfEmployeeId");
                return int.Parse(hfEmployeeId.Value);
            }
        }

        public double Salary
        {
            get 
            {
                TextBox tbSalary = (TextBox)gvEmployeeList.Rows[gvEmployeeList.EditIndex].FindControl("tbSalary");
                return double.Parse(tbSalary.Text);
            }
        }
    }
}