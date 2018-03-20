<%@ Page Title="Skyline : Student List" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentList.aspx.cs" Inherits="Pages_StudentList" %>

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
   
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Search Student</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">

                      <table>
 <tr>
                                        <td align="left">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="Small" Text="School Of" Font-Names="tahoma"></asp:Label>
                                       
                                       
                                            <asp:DropDownList ID="Drpschool" runat="server" CssClass="textBox9" TabIndex="8" Width="350"
                                                AutoPostBack="True" OnSelectedIndexChanged="Drpschool_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Drpschool"
                                                CssClass="" ErrorMessage="Please Select School!" Font-Size="Large" ForeColor="Red"
                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    </table>





                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    NON REGISTERED
                                    <asp:CheckBox ID="chkNonRegister" runat="server" />&nbsp;
                                    <asp:RadioButton ID="rdbNumber" runat="server" Text="Mobile No" GroupName="FilterBy"  />
                                    <asp:RadioButton ID="rdbEmail" runat="server" Text="Reg No" GroupName="FilterBy" />
                                    <asp:RadioButton ID="rdbName" runat="server" Text="Name" GroupName="FilterBy" />
                                    &nbsp;<%--<asp:DropDownList ID="ddlCallerCategory" runat="server" AppendDataBoundItems="true"
                                        Width="100px" CssClass="textBox9">
                                        <asp:ListItem Value="0">All Category</asp:ListItem>
                                    </asp:DropDownList>--%><asp:TextBox ID="txtFilterValue" runat="server" Text="" CssClass="textBox1"></asp:TextBox>
                                    <cc1:AutoCompleteExtender runat="server" ID="acFilterVAlue" BehaviorID="autoComplete"
                                        TargetControlID="txtFilterValue" ServicePath="~/AutoComlete.asmx" ServiceMethod="GetCompletionList"
                                        MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth">
                                    </cc1:AutoCompleteExtender>
                                    &nbsp;
                                    <asp:Button ID="btnSearch" runat="server" CssClass="" OnClick="btnSearch_Click" Text="Search"
                                        ValidationGroup="Search" />
                                    &nbsp;
                                    <asp:Button ID="btnNew" runat="server" CssClass="" OnClick="btnNew_Click" Text="New" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
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
                        Student List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                     
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="list-member-block" style="width: 693px">
                                        <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                            EmptyDataText="There are no records to display." OnRowDataBound="gvStudentList_RowDataBound"
                                            GridLines="Both" CssClass="grid-view" 
                                            OnRowCommand="gvStudentList_RowCommand" OnSorted="gvStudentList_Sorted"
                                            OnSorting="gvStudentList_Sorting" AllowSorting="true" AllowPaging="true" onpageindexchanged="gvStudentList_PageIndexChanged" 
                                            onpageindexchanging="gvStudentList_PageIndexChanging" PageSize="10" >
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.N.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSN" Text='<%# Container.DataItemIndex + 1 %>'  runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RegnNo" SortExpression="RegistrationNo">
                                                    <ItemTemplate>                                                    
                                                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("RegistrationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student Name" SortExpression="Name">
                                                    <ItemTemplate>                                                    
                                                        <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("LinkId") %>'
                                                            Text='<%#Bind("Name") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Regn Date" SortExpression="CallDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDate" runat="server" Text='<%#Bind("CallDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderText="Form Status" SortExpression="FormStatus">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFormStatus" runat="server" Text='<%# Bind("CallerStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmobile" runat="server" Text='<%# Bind("mobileno") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Degree" SortExpression="DegreeType">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDegree" runat="server" Text='<%# Bind("DegreeType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                

                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                            <SelectedRowStyle CssClass="GridRowOver" />
                                            <EditRowStyle />
                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            
                    </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
        
    </asp:Panel>
   
</asp:Content>
