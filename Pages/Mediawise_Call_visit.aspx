<%@ Page Title="" Language="C#" MasterPageFile="~/ReportMaster.master" AutoEventWireup="true" 
CodeFile="Mediawise_Call_visit.aspx.cs" Inherits="Pages_Mediawise_Call_visit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
 Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Daily CMS Report</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">      
                    <tr>
                    <td style="padding: 3px 5px;">
                             <b>   Type </b>
                    </td>
                    <td>
                    <asp:RadioButtonList ID="rad_but" runat="server"  RepeatDirection="Horizontal" >
                    <asp:ListItem  Text="Mediawise Caller and Visitor List" Value="C"></asp:ListItem>
                    <asp:ListItem  Text="MediaWise Enrollment List" Value="E" ></asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                    </tr>                
                      
                        <tr>
                            <td style="padding: 3px 5px;">
                               <b> From Date </b>
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox1"></asp:TextBox>
                                <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:calendarextender id="ceFromDate" Format="yyyy/MM/dd" runat="server" cssclass="MyCalendar" targetcontrolid="txtFromDate"
                                    popupbuttonid="ImgBCalender">
                                </cc1:calendarextender>
                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender39" runat="server" filtertype="Custom,Numbers"
                                    validchars="/,-" targetcontrolid="txtFromDate">
                                </cc1:filteredtextboxextender>
                            </td>
                            <td style="padding: 3px 5px;">
                               <b> To Date </b>
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtToDate" runat="server"  CssClass="textBox1"></asp:TextBox>
                                <asp:ImageButton ID="ImgToDate" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:calendarextender id="CalendarExtender1"  runat="server"  Format="yyyy/MM/dd"  cssclass="MyCalendar"
                                    targetcontrolid="txtToDate" popupbuttonid="ImgToDate">
                                </cc1:calendarextender>
                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" filtertype="Custom,Numbers"
                                    validchars="/,-" targetcontrolid="txtToDate">
                                </cc1:filteredtextboxextender>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;" align="center" colspan="4">
                                <asp:Button ID="btnPrint" runat="server" CssClass="textBox1" Text="Print" OnClick="btnPrint_Click"
                                    OnClientClick="document.getElementById('form1').target ='_blank';" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
        <!--ended Div of Wrapping Form Fields Set-->
    </div>
    <div id="all-form-wrap">
        <asp:Panel ID="pnlReportViwer" runat="server" ScrollBars="Both" Width="710px" Visible="true">
            <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                hascrystallogo="False" hastogglegrouptreebutton="False" toolpanelview="None"
                printmode="ActiveX" />
        </asp:Panel>
    </div>
</asp:Content>

