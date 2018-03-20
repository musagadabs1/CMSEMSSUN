<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForCallManagement.master" AutoEventWireup="true" CodeFile="PrintMissedCall.aspx.cs" Inherits="Pages_PrintMissedCall" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.min.js"> </script>
     <style type="text/css">
    @media print {
  body * {
    visibility:hidden;
  }
  #section_to_print, #section_to_print * {
    visibility:visible;
  }
  #section_to_print {
    position:absolute;
    left:0;
    top:0;
  }
}
    </style>
    <script type="text/javascript">
        function printdiv(id) {
            window.print()
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<input name="b_print" type="button" onclick="printdiv('#printReady')" value=" Print " />--%>
   <%-- <div id="section_to_print">
    </div>--%>
    <div id="all-form-wrap" >
        <asp:Panel ID="pnlReportViwer" runat="server" ScrollBars="Both" Width="710px" Visible="true">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                   
                          PrintMode="ActiveX" EnableDrillDown="False" 
           HasCrystalLogo="False" HasDrilldownTabs="False" HasDrillUpButton="False" 
           HasSearchButton="False" HasToggleGroupTreeButton="False" 
           HasToggleParameterPanelButton="False" ToolPanelView="None" 
        DisplayToolbar="False" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" EnableTheming="False" EnableToolTips="False" 
        HasExportButton="False" HasGotoPageButton="False" HasZoomFactorList="False" />
          </asp:Panel>
    </div>



</asp:Content>
