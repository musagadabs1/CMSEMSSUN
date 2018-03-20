<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage2.master" CodeFile="Canpostreportviewer.aspx.cs" Inherits="Pages_Canpostreportviewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"                   
       PrintMode="ActiveX" EnableDrillDown="False" 
           HasCrystalLogo="False" HasDrilldownTabs="False" HasDrillUpButton="False" 
           HasSearchButton="False" HasToggleGroupTreeButton="False" 
           HasToggleParameterPanelButton="False" ToolPanelView="None" 
        DisplayToolbar="False" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" EnableTheming="False" EnableToolTips="False" 
        HasExportButton="False" HasGotoPageButton="False" HasZoomFactorList="False" />
    </asp:Content>