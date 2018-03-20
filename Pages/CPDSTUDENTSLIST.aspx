<%@ Page Language="C#" MasterPageFile="~/ReportMaster.master" AutoEventWireup="true"
    CodeFile="CPDSTUDENTSLIST.aspx.cs" Inherits="Pages_CPDSTUDENTSLIST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
        
         .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }       
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    CPD Student List</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner">
                    <!--start list member blocks-->
                    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                    <asp:Panel ID="Panel1" runat="server">
                      <%--  <div id="list-member-block" style="width: 500px">--%>
                        <div  id="divGridView" runat="server"  style="overflow-y: auto; overflow-x: auto; height: 450px; width: 700px">

                        <table>
                                <tr>
            <td style="padding: 3px 5px;">
                <b>
                    <asp:Label ID="Label9" Font-Size="12px" runat="server" Text="Search : "></asp:Label>
                </b>
            </td>
            <td style="padding: 3px 5px;">
                <asp:TextBox ID="txtSearch" Width="280px" runat="server" AutoPostBack="true" 
                 OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
            </td>
            <td style="padding: 3px 5px;">
                <asp:Button ID="but_search" runat="server" Text="search" OnClick="button_search" />
            </td>

             <td style="padding: 3px 5px;">
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            </td>
        </tr>
                        </table>


                            <asp:GridView ID="gvStudDetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                GridLines="Both" CssClass="grid-view" EmptyDataText="There are no records to display"
                                CellPadding="5"   AllowSorting="true" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                                OnSorting="gvTOC_OnSorting"  PageSize="15"   DataSourceID="dsTOC" >
                                 <FooterStyle CssClass="GridFooter" />
                                 <HeaderStyle  Font-Underline="false" />
                                 <RowStyle CssClass="GridItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="REGNNO" SortExpression="CallDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("RegistrationNo").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="STUDENT NAME" SortExpression="CallDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("Name").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MOBILE NO" SortExpression="CallDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("Mobileno").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EMAIL ID" SortExpression="Email Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("EmailId").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DEGREE CODE" SortExpression="Degree ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("Degreecode").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BATCHCODE" SortExpression="Batchcode ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("Batchcode").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="COMPANY" SortExpression="Company ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("organization").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DESIGNATION" SortExpression="Designation ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("Designation").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CITY" SortExpression="City ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#HighlightText(Eval("City").ToString()) %>'></asp:Label>
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
                             <asp:SqlDataSource ID="dsTOC" runat="server" ConnectionString="<%$ConnectionStrings:SkyLineConnection %>"
        SelectCommand="SP_CPDSTUDENTSLIST" SelectCommandType="StoredProcedure"
        FilterExpression=" RegistrationNo LIKE '%{0}%' or  Name LIKE '%{0}%'  or  MobileNo LIKE '%{0}%'  or  EmailId LIKE '%{0}%' or Degreecode LIKE '%{0}%'  or  BatchCode LIKE '%{0}%'  or  Organization LIKE '%{0}%' "  >
        <FilterParameters>    
            <asp:ControlParameter Name="RegistrationNo"  ControlID="txtSearch" PropertyName="Text" />    
            <asp:ControlParameter Name="Name"  ControlID="txtSearch" PropertyName="Text" />                               
            <asp:ControlParameter Name="EmailId"  ControlID="txtSearch" PropertyName="Text" />         
            <asp:ControlParameter Name="Degreecode"  ControlID="txtSearch" PropertyName="Text" />   
            <asp:ControlParameter Name="BatchCode"  ControlID="txtSearch" PropertyName="Text" />   
            <asp:ControlParameter Name="Organization"  ControlID="txtSearch" PropertyName="Text" />     
        </FilterParameters>        
    </asp:SqlDataSource>
                        </div>
                    </asp:Panel>
                    <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                </div>
            </div>
            <!--form fieldset wrapper mid inner ended-->
        </div>
        <!--Ended Div of form fieldset wrapper middle part of left and right border-->
        <div class="form-fieldset-wrapper-bottom">
        </div>
        <!--Div started for the form fieldset wrapper bottom founded-->
    </div>
</asp:Content>
