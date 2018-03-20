﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/ReportMaster.master" 
CodeFile="FollowupCancelandPost.aspx.cs" Inherits="Pages_FollowupCancelandPost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc3" %>

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
                    Follow up Summary - Cancellation and Postponement</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">         
                       <tr>
                            <td style="padding:3px 5px;">
                                From Date
                            </td>
                            <td style="padding:3px 5px;">
                             <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox1"></asp:TextBox>  
                              <span style="color:Red">*</span>                              
                                <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:CalendarExtender ID="ceFromDate" runat="server" CssClass="MyCalendar" TargetControlID="txtFromDate" PopupButtonID="ImgBCalender">
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txtFromDate">
                                </cc1:FilteredTextBoxExtender>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate"
                                    CssClass="" ErrorMessage="Select FromDate!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                    Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </td>
                            <td style="padding:3px 5px;">
                                To Date
                            </td>
                            <td style="padding:3px 5px;">
                                

                             <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox1"></asp:TextBox>   
                              <span style="color:Red">*</span>                             
                                <asp:ImageButton ID="ImgToDate" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txtToDate">
                                </cc1:FilteredTextBoxExtender>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtToDate"
                                    CssClass="" ErrorMessage="Select ToDate!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                    Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </td>
                        </tr>              
                    
                       <%-- <tr>
                           <td style="padding: 3px 5px;">
                               AcademicYear
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="drpayyear" runat="server" TabIndex="5" Width="142px" CssClass="textBox9" AutoPostBack="true"
                                    AppendDataBoundItems="true" 
                                    onselectedindexchanged="drpayyear_SelectedIndexChanged">
                                   
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpayyear"
                                    CssClass="" ErrorMessage="Academicyear Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                    Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </td>


                             <td style="padding: 3px 5px;">
                                Term
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlTerm" runat="server" TabIndex="5" Width="142px" CssClass="textBox9"
                                    AppendDataBoundItems="true">
                                   
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTerm"
                                    CssClass="" ErrorMessage="Term Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                    Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="padding:3px 5px;" align="center" colspan="4">
                             
                                <asp:Button ID="btnPrint" runat="server" CssClass="textBox1" Text="Print"
                                    OnClick="btnPrint_Click"  ValidationGroup="Submit"  OnClientClick="document.getElementById('form1').target ='_blank';" />
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
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" 
                ToolPanelView="None" PrintMode="ActiveX" />
        </asp:Panel>
    </div>
</asp:Content>
