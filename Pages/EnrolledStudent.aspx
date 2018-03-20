﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ReportMaster.master" AutoEventWireup="true" CodeFile="EnrolledStudent.aspx.cs" Inherits="Pages_EnrolledStudent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    STUDENT DETAILS REPORT</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">
                       
                        <tr>
                            <td style="padding: 3px 5px;">
                               Degree
                            </td>
                            <td style="padding: 3px 5px;">
                            <asp:DropDownList ID="ddlDegree" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px">
                                    <asp:ListItem Value="0">BBA & MBA</asp:ListItem>
                                    <asp:ListItem Value="1">BBA</asp:ListItem>
                                    <asp:ListItem Value="6">MBA</asp:ListItem>
                                    <asp:ListItem Value="9">SHORT COURSE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="padding: 3px 5px;">
                               Term
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlTerm" runat="server" TabIndex="5" CssClass="textBox11" AppendDataBoundItems="true"
                                        Width="142px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr> 
                        <tr>
                            <td style="padding: 3px 5px;">
                           Country
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlCountry" runat="server" TabIndex="5" CssClass="textBox11" 
                                    Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="UAE">U.A.E.</asp:ListItem>
                                    <asp:ListItem Value="NG">NIGERIA</asp:ListItem>
                                    <asp:ListItem Value="PK">PAKISTAN</asp:ListItem>
                                    <asp:ListItem Value="MA">MOROCCO</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;" align="center" colspan="4">
                                <asp:Button ID="btnPrint" runat="server" CssClass="textBox1" Text="Print" OnClick="btnPrint_Click"
                                    OnClientClick="document.getElementById('form1').target ='_blank';" />
                            </td>

                            <td style="padding: 3px 5px;" align="center" colspan="4">
                                <asp:Button ID="btnexport" runat="server" CssClass="textBox1" Text="Export to Excel" OnClick="btnexport_Click"
                                     />
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
           

              <cr:crystalreportviewer id="CrystalReportViewer2" runat="server" autodatabind="true"
                hascrystallogo="False" hastogglegrouptreebutton="False" toolpanelview="None"
                printmode="ActiveX" />


        </asp:Panel>
    </div>
    </div>
</asp:Content>