<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForCallManagement.master" AutoEventWireup="true" CodeFile="PolicyMaster.aspx.cs" Inherits="Pages_PolicyMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                                    Form Name
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFormName" runat="server" CssClass="textBox11" 
                                        Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Program
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProgram" runat="server" CssClass="textBox11" 
                                        Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Form Type
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFormType" runat="server" CssClass="textBox11" Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Academic Year
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="textBox11" Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        <tr>
                                <td>
                                    Min Value
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMinValue" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                                <td>
                                    Max Value
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaxValue" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Is Finance
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsFinance" runat="server" CssClass="CheckboxLists" 
                                        AutoPostBack="True" oncheckedchanged="chkIsFinance_CheckedChanged"></asp:CheckBox>
                                </td>
                                <asp:Panel ID="pnlFeeGroup" runat="server" Visible="false">
                                <td>
                                    Fee Group
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFeeGroup" runat="server" CssClass="textBox11" Width="140px"></asp:DropDownList>
                                </td>
                                </asp:Panel>
                            </tr>
                            <tr>
                                <td>
                                    Remarks
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBox11" Text="" 
                                        TextMode="MultiLine" Height="60px" Width="143px"></asp:TextBox>
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
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="" OnClick="btnUpdate_Click" Text="Update"/>
                                    <asp:Button ID="btnDelete" runat="server" CssClass="" OnClick="btnDelete_Click" Text="Delete"/>
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
    <div id="list-member-block" style="width: 693px">
    <asp:HiddenField ID="hdId" runat="server" Value="0" />
        <asp:GridView ID="gvPolicyList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
            EmptyDataText="There are no records to display." GridLines="Both" 
            CssClass="grid-view" onrowcommand="gvPolicyList_RowCommand" 
            onrowdatabound="gvPolicyList_RowDataBound" 
            onrowupdating="gvPolicyList_RowUpdating">
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField HeaderText="Form Name">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkFormName" runat="server" CommandName="Update" CommandArgument='<%#Bind("Id") %>'
                            Text='<%#Bind("FormName") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Program">
                    <ItemTemplate>
                        <asp:Label ID="lblProgram" runat="server" Text='<%#Bind("Program") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Form Type">
                    <ItemTemplate>
                        <asp:Label ID="lblFormType" runat="server" Text='<%#Bind("FormType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Min Value">
                    <ItemTemplate>
                        <asp:Label ID="lblMinvalue" runat="server" Text='<%# Bind("MinValue") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MaxValue">
                    <ItemTemplate>
                        <asp:Label ID="lblMaxValue" runat="server" Text='<%# Bind("MaxValue") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Activate">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkActivate" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                            Text="Activate"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
            <SelectedRowStyle CssClass="GridRowOver" />
            <EditRowStyle />
            <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
    </div>
        </div>
</asp:Content>

