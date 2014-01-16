<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.ascx.cs" Inherits="AOE.WebUI.EmployeeList" %>

<span>Job Title:</span>
<asp:DropDownList ID="ddlJobList" runat="server"></asp:DropDownList>
<p>Employees/Salary:</p>
<asp:GridView ID="gvEmployeeList" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowCustomPaging="true">
    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:LinkButton CommandName="SortByFullName" runat="server" Text="FullName"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("FullName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <%# Eval("FullName") %>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:LinkButton CommandName="SortBySalary" runat="server" Text="Salary"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Salary") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="tbSalary" runat="server" Text='<%# Eval("Salary") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="true" />
    </Columns>
</asp:GridView>