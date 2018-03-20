<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="IndexSetup.aspx.cs" Inherits="Pages_IndexSetup" %>

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
                        Index Setup</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding: 3px 5px; width: 120px;">
                                    Index
                                </td>
                                <td style="padding: 3px 5px; width: 260px;">
                                    <asp:DropDownList ID="ddlIndex" runat="server" TabIndex="5" Width="142px" CssClass="textBox9">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlIndex"
                                        CssClass="" ErrorMessage="Index Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                                <td style="padding: 3px 5px; width: 120px">
                                    Degree
                                </td>
                                <td style="padding: 3px 5px; width: 260px;">
                                    <asp:DropDownList ID="ddlDegree" runat="server" TabIndex="5" Width="142px" CssClass="textBox9">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDegree"
                                        CssClass="" ErrorMessage="Degree Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Term
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:DropDownList ID="ddlTerm" runat="server" TabIndex="5" Width="142px" CssClass="textBox9"
                                        AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTerm"
                                        CssClass="" ErrorMessage="Term Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                        Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                                <td style="padding: 3px 5px;">
                                    Reminder Type
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:RadioButton GroupName="ScheduleType" ID="rdbScheduleTypeYear" runat="server"
                                        Text="Year" TabIndex="5" Visible="false" />
                                    <asp:RadioButton GroupName="ScheduleType" ID="rdbScheduleTypeMonth" runat="server"
                                        Text="Month" TabIndex="5" Visible="false" />
                                    <asp:RadioButton ID="rdbScheduleTypeDay" runat="server" Checked="true" Text="Days"
                                        TabIndex="5" GroupName="ScheduleType" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Reminder Interval
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtSchedule" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="." TargetControlID="txtSchedule">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSchedule"
                                        CssClass="" ErrorMessage="Reminder Interval Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                                <td style="padding: 3px 5px;">
                                    Next Verification Date
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtNextVerificationDate" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtNextVerificationDate" PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txtNextVerificationDate">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNextVerificationDate"
                                        CssClass="" ErrorMessage=" Next Verification Date Required!" Font-Size="Large"
                                        ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Approved By
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:DropDownList ID="ddlApprovedBy" runat="server" TabIndex="5" Width="142px" CssClass="textBox9">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 3px 5px;">
                                    Approved Date
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtApprovedDate" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                    <asp:ImageButton ID="ImgBCalender1" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="ceFromDate" runat="server" CssClass="MyCalendar" TargetControlID="txtApprovedDate"
                                        PopupButtonID="ImgBCalender1" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txtApprovedDate">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Previous Revised By
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:DropDownList ID="ddlRevisedBy" runat="server" TabIndex="5" Width="142px" CssClass="textBox9">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 3px 5px;">
                                    Previous Updated Date
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtRevisedDate" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                    <asp:ImageButton ID="ImgRevisedCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtRevisedDate" PopupButtonID="ImgRevisedCalender" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="fttxtRevisedDate" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txtRevisedDate">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Remarks
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtRemarks" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                </td>
                                <td style="padding: 3px 5px;">
                                    Is Closed
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:CheckBox ID="chkIsActive" runat="server" TabIndex="5" Width="142px" Checked="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3" style="padding: 3px 5px;">
                                    <asp:Button ID="btnSave" runat="server" CssClass="" OnClick="btnSave_Click" Text="Save"
                                        ValidationGroup="Submit" />                                        
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="" OnClick="btnUpdate_Click" Text="Update"
                                        ValidationGroup="Update" />
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
        <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="IndexId"
            EmptyDataText="There are no records to display." GridLines="Both" 
            CssClass="grid-view" onrowcommand="gvStudentList_RowCommand">
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Term Name">
                    <ItemTemplate>
                        <asp:Label ID="lblTermName" runat="server" Text='<%#Bind("TermName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DegreeType">
                    <ItemTemplate>
                        <asp:Label ID="lblDegreeType_Desc" runat="server" Text='<%# Bind("DegreeType_Desc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Next Verification Date">
                    <ItemTemplate>
                        <asp:Label ID="lblVArificationDate" runat="server" Text='<%# Bind("NextVerified") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Interval">
                    <ItemTemplate>
                        <asp:Label ID="lblScheduleDate" runat="server" Text='<%# Bind("ScheduleDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDeactivate" runat="server" CommandName="Modify" CommandArgument='<%#Bind("IndexId") %>'
                            Text="Edit"></asp:LinkButton>
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
