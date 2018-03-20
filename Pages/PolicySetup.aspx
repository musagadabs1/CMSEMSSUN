<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PolicySetup.aspx.cs" Inherits="Pages_PolicySetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnSave">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Policy Setup</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                                <td>
                                    Policy Code
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPolicyCode" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                                <td>
                                    Policy Description
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPolicyDescription" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Academic Semester
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAcademicSemester" runat="server" CssClass="textBox11" Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Is Mandatory
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsMand" runat="server" CssClass="CheckboxLists" Text=""></asp:CheckBox>
                                </td>
                                <td>
                                    Is Active
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" CssClass="CheckboxLists"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnSave" runat="server" CssClass="" OnClick="btnSave_Click" Text="Save"
                                        ValidationGroup="Submit" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                        ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""
                                        CssClass="labelMesag"></asp:Label>
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
    </asp:Panel>
    </div>
</asp:Content>
