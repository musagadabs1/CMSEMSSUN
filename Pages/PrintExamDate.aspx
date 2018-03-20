<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="PrintExamDate.aspx.cs" Inherits="Pages_PrintExamDate" %>


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
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                   
                          PrintMode="ActiveX" 
                       
           HasSearchButton="true" HasToggleGroupTreeButton="true" 
           HasToggleParameterPanelButton="true" ToolPanelView="None"
        DisplayToolbar="true" EnableDatabaseLogonPrompt="true" 
        EnableParameterPrompt="true" EnableTheming="true" EnableToolTips="true" 
        HasExportButton="False" HasGotoPageButton="true" HasZoomFactorList="true" />



       
                   
                     

</CR:CrystalReportSource>




</asp:Content>