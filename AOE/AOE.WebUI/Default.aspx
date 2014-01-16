<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AOE.WebUI.Default" %>
<%@ Register Src="~/EmployeeList.ascx" TagName="EmployeeList" TagPrefix="uwc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uwc:EmployeeList runat="server" XmlConfigFile="EmployeeListConfig.xml" />
    </div>
    </form>
</body>
</html>
