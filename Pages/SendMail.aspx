<%@ Page Title="Skyline : Send Email" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="SendMail.aspx.cs" Inherits="Pages_SendMail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                    Send Email</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 695px">
                        <tr>
                            <td>
                                From
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrom" runat="server" Text="" CssClass="textBoxsendEmail"></asp:TextBox>
                            </td>
                            <td>
                                Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="textBoxsendEmail" TextMode="Password"
                                    Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Message
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="listbox2"
                                    Width="515px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Attachments
                            </td>
                            <td colspan="3">
                                <asp:FileUpload ID="fuAttachments" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSend" runat="server" CssClass="" Text="Send" OnClick="btnSend_Click" />
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
    </div>
</asp:Content>
