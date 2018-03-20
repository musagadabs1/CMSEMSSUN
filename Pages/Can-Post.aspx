<%@ Page Title="" Language="C#" MasterPageFile="~/ReportMaster.master" AutoEventWireup="true"
    CodeFile="Can-Post.aspx.cs" Inherits="Pages_Can_Post" %>

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
                    Student Cancellation and Postponement details
                </h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <%--<td style="padding: 3px 5px;">
                                   Student Name
                              </td>
                            <td style="padding: 3px 5px;">
                            <asp:TextBox ID="txtRegNo" runat="server" CssClass="textBox1"></asp:TextBox>
                               <asp:Button ID="btnRegNo" runat="server" Text="::" Font-Size="11px" 
                                    Height="18px" onclick="btnRegNo_Click" />
                               </td>--%>
                            <td style="padding: 3px 5px;">
                              <b>  Term </b>
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlTerm" runat="server" TabIndex="5" CssClass="textBox11" AppendDataBoundItems="true"
                                    Width="200px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                <b> Degree </b>
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlDegreeType" runat="server" CssClass="textBox9" TabIndex="8" AppendDataBoundItems="true"
                                      Width="200px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                         <%--<td style="padding: 3px 5px;">
                               Course
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="textBox9" TabIndex="8" Width="143px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            </td>--%>
                        </tr>
                         <tr>
                            <td style="padding: 3px 5px;">
                             <b> Selection Type </b>
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddltype" runat="server" TabIndex="5" CssClass="textBox11"
                                      Width="200px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="C">CANCELLATION</asp:ListItem>
                                    <asp:ListItem Value="P">POSTPONEMENT</asp:ListItem>                                    
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;" align="center"  colspan="4">
                                <asp:Button ID="btnPrint" runat="server" CssClass="textBox1" Text="Print" OnClick="btnPrint_Click"
                                    OnClientClick="document.getElementById('form1').target ='_blank';"  />
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
   <%-- <div id="all-form-wrap">
        <asp:Panel ID="pnlReportViwer" runat="server" ScrollBars="Both" Width="710px" Visible="true">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                PrintMode="ActiveX" HasSearchButton="true" HasToggleGroupTreeButton="true" HasToggleParameterPanelButton="true"
                ToolPanelView="None" DisplayToolbar="true" EnableDatabaseLogonPrompt="true" EnableParameterPrompt="true"
                EnableTheming="true" EnableToolTips="true" HasExportButton="False" HasGotoPageButton="true"
                HasZoomFactorList="true" />
            </CR:CrystalReportSource>
        </asp:Panel>
    </div>--%>
    </div>
</asp:Content>
