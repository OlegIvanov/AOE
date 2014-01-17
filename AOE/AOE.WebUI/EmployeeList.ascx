<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.ascx.cs" Inherits="AOE.WebUI.EmployeeList" %>

<span>Job Title:</span>
<asp:DropDownList ID="ddlJobList" runat="server" AutoPostBack="true"></asp:DropDownList>
<p>Employees/Salary:</p>
<asp:GridView ID="gvEmployeeList" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowCustomPaging="true">
    <Columns>
        <asp:TemplateField ItemStyle-Width="300" HeaderStyle-HorizontalAlign="Left">
            <HeaderTemplate>
                <asp:LinkButton CommandName="SortByFullName" runat="server" Text="FullName" Font-Bold="false"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("FullName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:HiddenField ID="hfEmployeeId" runat="server" Value='<%# Eval("Id") %>' />
                <%# Eval("FullName") %>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="220" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
            <HeaderTemplate>
                <asp:LinkButton CommandName="SortBySalary" runat="server" Text="Salary" Font-Bold="false"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Salary") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="tbSalary" runat="server" Text='<%# Eval("Salary") %>' Width="200"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ControlToValidate="tbSalary" Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="true" />
    </Columns>
</asp:GridView>