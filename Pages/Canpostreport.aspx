<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" 
    AutoEventWireup="true" CodeFile="Canpostreport.aspx.cs" Inherits="Pages_Canpostreport" %>    
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"      
        PrintMode="ActiveX" HasSearchButton="true" HasToggleGroupTreeButton="true" 
        HasToggleParameterPanelButton="true" ToolPanelView="None"
        DisplayToolbar="true" EnableDatabaseLogonPrompt="true" 
        EnableParameterPrompt="true" EnableTheming="true" EnableToolTips="true" 
        HasExportButton="False" HasGotoPageButton="true" HasZoomFactorList="true" />   
</CR:CrystalReportSource>
</asp:Content>

