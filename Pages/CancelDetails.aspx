<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CancelDetails.aspx.cs" Inherits="Pages_CancelDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnUpdate">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Cancel/Postponed</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 100px">
                                    Date
                                </td>
                                <td style="width: 160px">
                                    <asp:TextBox ID="txtCallDate" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCallDate"
                                        CssClass="" ErrorMessage="Date Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                        Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 400px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStudentStatus" runat="server" CssClass="" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStudentStatus" runat="server" TabIndex="5" CssClass="textBox9"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlStudentStatus_SelectedIndexChanged">
                                        <asp:ListItem Value="C">Cancel</asp:ListItem>
                                        <asp:ListItem Value="P">Postponed</asp:ListItem>
                                        <asp:ListItem Value="A">Active</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlStudentStatus"
                                        CssClass="" ErrorMessage="Status Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTermID" runat="server" CssClass="" Text="Term"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTerm" runat="server" CssClass="textBox9">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblRemarks" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBoxbigA" Height="120px"
                                        TabIndex="7" TextMode="MultiLine">                                               
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="" OnClick="btnUpdate_Click" Text="Update"
                                        ValidationGroup="Submit" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                        ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                                    <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"
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
