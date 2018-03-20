<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForCallManagement.master" AutoEventWireup="true" CodeFile="ForwardCall.aspx.cs" Inherits="Pages_ForwardCall" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 0px;
            background-color: White;
            margin-left: 0px;
            z-index: 10;
            position: absolute;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }
        #divwidth
        {
            width: 150px !important;
        }
        #divwidth div
        {
            width: 150px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnSearch">
    <table>
                                    <tr>
                                        <td style="width: 40%">
                                            <asp:Label ID="Label3" runat="server" CssClass="" Text="School"></asp:Label>
                                        </td>
                                        <td style="width: 60%">
                                            <asp:DropDownList ID="Drpschool" runat="server" CssClass="textBox9" TabIndex="8"
                                                AutoPostBack="True" OnSelectedIndexChanged="Drpschool_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Drpschool"
                                                CssClass="" ErrorMessage="Please Select School!" Font-Size="Large" ForeColor="Red"
                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                  </table> 

        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Search</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3" style="padding: 3px 5px;">
                                    <asp:RadioButton ID="rdbNumber" runat="server" Text="Mobile No" GroupName="FilterBy" />
                                    <asp:RadioButton ID="rdbEmail" runat="server" Text="Email" GroupName="FilterBy" />
                                    <asp:RadioButton ID="rdbName" runat="server" Text="Name" GroupName="FilterBy" />
                                    &nbsp;
                                    <asp:TextBox ID="txtFilterValue" runat="server" Text="" CssClass="textBox1"></asp:TextBox>
                                    <cc1:AutoCompleteExtender runat="server" ID="acFilterVAlue" BehaviorID="autoComplete"
                                        TargetControlID="txtFilterValue" ServicePath="~/AutoComlete.asmx" ServiceMethod="GetCompletionList"
                                        MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth">
                                    </cc1:AutoCompleteExtender>
                                    From Date
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox1" Width="60px"></asp:TextBox>
                                    <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="ceFromDate" runat="server" CssClass="MyCalendar" TargetControlID="txtFromDate"
                                        PopupButtonID="ImgBCalender">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txtFromDate">
                                    </cc1:FilteredTextBoxExtender>
                                    To Date
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox1" Width="60px"></asp:TextBox>
                                                 
                                <asp:ImageButton ID="ImgToDate" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txtToDate">
                                </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr align="center" style="padding: 3px 5px;">
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnSearch" runat="server" CssClass="" OnClick="btnSearch_Click" Text="Search"
                                        ValidationGroup="Search" />
                                    &nbsp;
                                    <asp:Button ID="btnNew" runat="server" CssClass="" OnClick="btnNew_Click" Text="New" />
                                    <asp:CheckBox ID="chkAllUSer" runat="server" Text="All" AutoPostBack="True" OnCheckedChanged="chkAllUSer_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
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
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Caller List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--start list member blocks-->
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="list-member-block" style="width: 693px">
                                        <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                            EmptyDataText="There are no records to display." OnRowDataBound="gvStudentList_RowDataBound"
                                            GridLines="Both" CssClass="grid-view" OnRowCommand="gvStudentList_RowCommand">
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.N.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                            Text='<%#Bind("Name") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%#Bind("DegreeCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentStatus" runat="server" Text='<%# Bind("CallerStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Form Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFormStatus" runat="server" Text='<%# Bind("FormStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Entry Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEntryDate" runat="server" Text='<%# Bind("CallDate1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Registered By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegisteredBy" runat="server" Text='<%# Bind("AttendedBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total FollowUp" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalFollow" runat="server" Text='<%# Bind("TotalFollowUp") %>'></asp:Label>
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
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                
                        <table >
                        <tr class="button">
                        <td class="button1">
                       <asp:Button ID="btnFirst" runat="server" Text="<<" OnClick="btnFirst_Click"   />
                        <asp:Button ID="btnPrev" runat="server" Text="<" OnClick="btnPrev_Click" />
                        Page
                        <asp:TextBox ID="txtPageNo" runat="server" Text="1" Width="45px"></asp:TextBox>
                        of
                        <asp:Label ID="lblPages" runat="server" Text="1"></asp:Label>
                        <asp:Button ID="btnNext" runat="server" Text=">"  OnClick="btnNext_Click"   />
                        <asp:Button ID="btnLast" runat="server" Text=">>" OnClick="btnLast_Click"  />
                        <asp:RequiredFieldValidator ID="rfvPageNo" runat="server" ControlToValidate="txtPageNo"
                        ErrorMessage="*" ValidationGroup="grpGo">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvPageNo" runat="server" ControlToValidate="txtPageNo" Type="Integer"
                        MinimumValue="1" MaximumValue="1" ValidationGroup="grpGo"></asp:RangeValidator>                        
                        </td>
                        <td align="right">
                        <asp:Label ID="lblStatus" runat="server"> Displaying 1 of 1</asp:Label>
                        </td>
                        </tr>
                        </table>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
    </asp:Panel>
    </div>
</asp:Content>