<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FeeGroupAllocation.aspx.cs" Inherits="Pages_FeeGroupAllocation" %>

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
                        Fund Allocation</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 120px">
                                    Fee Waiver
                                </td>
                                <td style="width: 260px">
                                    <asp:DropDownList ID="ddlFeeWaiverType" runat="server" TabIndex="5" Width="142px"
                                        CssClass="textBox9">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFeeWaiverType"
                                        CssClass="" ErrorMessage="Fee Waiver Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 120px">
                                    Fee Waiver Group
                                </td>
                                <td style="width: 220px">                                
                                    <asp:DropDownList ID="ddlFeeWaiverGroup" runat="server" TabIndex="5" Width="142px"
                                        CssClass="textBox9" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlFeeWaiverGroup"
                                        CssClass="" ErrorMessage="Fee Group Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Is Active
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" TabIndex="5" Width="142px" />
                                </td>
                                </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnSave" runat="server" CssClass="" OnClick="btnSave_Click" Text="Save"
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
    <div id="list-member-block" style="width: 693px">
        <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
            EmptyDataText="There are no records to display." GridLines="Both" CssClass="grid-view">
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField HeaderText="FeeWaiver Type">
                    <ItemTemplate>
                       <%-- <asp:LinkButton ID="lnkFeeWaiverType" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                            Text='<%#Bind("FeeWaiverType") %>'></asp:LinkButton>--%>
                            <asp:Label ID="lblFeeWaiverType" runat="server" Text='<%#Bind("FeeWaiverType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fees Group">
                    <ItemTemplate>
                        <asp:Label ID="lblFundAllocated" runat="server" Text='<%#Bind("Fees_Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblFundExceed" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
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