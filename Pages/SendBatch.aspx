<%@ Page Title="Skyline : Select Email" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="SendBatch.aspx.cs" Inherits="Pages_SendBatch" %>

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
                    Select Batch</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-innerc">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Level
                            </td>
                            <td>
                                <asp:ListBox ID="lbLevel" runat="server" CssClass="listbox12" AutoPostBack="True"
                                    OnSelectedIndexChanged="lbLevel_SelectedIndexChanged" SelectionMode="Multiple">
                                </asp:ListBox>
                            </td>
                            <td>
                                Timming
                            </td>
                            <td>
                                <asp:ListBox ID="lbTiming" runat="server" CssClass="listbox12" SelectionMode="Multiple"
                                    AutoPostBack="true" OnSelectedIndexChanged="lbTiming_SelectedIndexChanged">
                                    <asp:ListItem Value="M">Morning</asp:ListItem>
                                    <asp:ListItem Value="A">Afternoon</asp:ListItem>
                                    <asp:ListItem Value="E">Evening</asp:ListItem>
                                    <asp:ListItem Value="W">Weekend</asp:ListItem>
                                </asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Batch
                            </td>
                            <td>
                                <asp:Panel ID="pnlSelectList" runat="server" CssClass="PanelCheckboxList" ScrollBars="Vertical">
                                    <asp:CheckBoxList ID="chkSelectList" DataTextField="BatchCode" DataValueField="BatchCode"
                                        runat="server" CssClass="" BackColor="#E3E2E3">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Button ID="btnMoveRight" runat="server" Text="&gt;" OnClick="btnMoveRight_Click"
                                    Width="100px" />
                                <br />
                                <asp:Button ID="btnMoveLeft" runat="server" Text="&lt;" Width="100px" OnClick="btnMoveLeft_Click" />
                            </td>
                            <td>
                                <asp:Panel ID="pnlSelectedList" runat="server" CssClass="PanelCheckboxList" ScrollBars="Vertical">
                                    <asp:CheckBoxList ID="chkSelectedList" runat="server" CssClass="" BackColor="#E3E2E3">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnNext" runat="server" CssClass="" Text="Next" OnClick="btnNext_Click" />
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
