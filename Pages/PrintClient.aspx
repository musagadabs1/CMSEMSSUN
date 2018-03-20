<%@ Page Title="Skyline : Print Offline" Language="C#" MasterPageFile="~/MasterPage2.master"
    AutoEventWireup="true" CodeFile="PrintClient.aspx.cs" Inherits="Pages_PrintClient" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.min.js"> </script> 
   
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div>
       <%-- <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            DisplayStatusbar="False" DisplayToolbar="false" EnableDrillDown="False" EnableParameterPrompt="False"
            EnableTheming="False" EnableToolTips="False" HasDrilldownTabs="False" HasToggleGroupTreeButton="False"
            HasToggleParameterPanelButton="False" Height="50px" SeparatePages="False" ToolPanelView="None"
            Width="350px" PrintMode="ActiveX" />
    </div>--%>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                       PrintMode="ActiveX" EnableDrillDown="False" 
           HasCrystalLogo="False" HasDrilldownTabs="False" HasDrillUpButton="False" 
           HasSearchButton="False" HasToggleGroupTreeButton="False" 
           HasToggleParameterPanelButton="False" ToolPanelView="None" />
    </div>
</asp:Content>
