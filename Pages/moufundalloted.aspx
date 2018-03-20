﻿<%@ Page Language="C#" MasterPageFile="~/ReportMaster.master" AutoEventWireup="true" CodeFile="moufundalloted.aspx.cs" Inherits="Pages_moufundalloted" %>

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
                    MOU FUND Report</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">

                   <tr>
                            <td style="padding: 3px 5px;">
                               AcademicYear
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="drpayyear" runat="server" TabIndex="5" Width="142px" CssClass="textBox9" 
                                    AppendDataBoundItems="true" 
                                >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpayyear"
                                    CssClass="" ErrorMessage="Academicyear Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                    Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </td>
                        
                            <td style="padding: 3px 5px;">
                                Program
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlprogram" runat="server" TabIndex="5" Width="142px" CssClass="textBox9"
                                    AppendDataBoundItems="true">
                                     <asp:ListItem Value="0">BBA & MBA</asp:ListItem>
                                          <asp:ListItem Value="BBA">BBA</asp:ListItem>
                                          <asp:ListItem Value="MBA">MBA</asp:ListItem>
                                </asp:DropDownList>
                              
                            </td>
                            </tr>
                         <tr>
                         
                         <td>
                                <asp:Button ID="btnPrint" runat="server" CssClass="textBox1" Text="Print" OnClick="btnPrint_Click"
                                    OnClientClick="document.getElementById('form1').target ='_blank';" />
                            </td>
                            <td style="padding: 3px 5px;">
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
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None"
                PrintMode="ActiveX" />
        </asp:Panel>
    </div>
    </div>
</asp:Content>
