<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForCallManagement.master"
    AutoEventWireup="true" CodeFile="FollowUpReport.aspx.cs" Inherits="Pages_FollowUpReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .GridviewDiv
        {
            font-size: 11px;
            font-weight: normal;
            font-family: 'tahoma';
            color: #303933;
        }
        Table.Gridview
        {
            border: solid 1px #003964;
        }
        .Gridview th
        {
            color: white;
            border-right-color: #003964;
            border-bottom-color: #003964;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
        .Gridview td
        {
            border-bottom-color: #003964;
            border-right-color: #003964;
            padding: 0.5em 0.5em 0.5em 0.5em;
        }
        .Gridview tr
        {
            color: Black;
            background-color: #D3D3D3;
            text-align: left;
        }
        :link, :visited
        {
            color: #DF4F13;
            text-decoration: none;
        }
        .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }
        .buttonface
        {
            text-align: center;
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
<table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
       <%--<div class="GridviewDiv">--%>
        <p>
            <b>Search :</b>
            <asp:TextBox ID="txtSearch" runat="server" Width="150" AutoPostBack="true" Font-Names="tahoma"
                OnTextChanged="txtSearch_TextChanged" />&nbsp;&nbsp;
            <asp:CheckBox ID="chkall" runat="server" Text="ALL" Checked="false" AutoPostBack="true"
                OnCheckedChanged="chkall_checkedchanged" />
            <asp:ImageButton ID="btnSearch"  runat="server" AlternateText="Search" BorderStyle="Outset"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnSearch_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="btnClear"  runat="server" AlternateText="Clear" BorderStyle="Outset"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnClear_Click" />
            &nbsp;&nbsp;
            <asp:ImageButton ID="btnNew"  AlternateText="New" runat="server" CssClass="buttonface" BorderStyle="Outset"
                Width="50"  Style="top: 5px; position: relative" OnClick="btnNew_Click" />
             
                <asp:ImageButton ID="Imgcancel"  AlternateText="Cancel" runat="server" BorderStyle="Outset"
                Width="100" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="Imgcancel_Click" />

                <asp:ImageButton ID="Imgpost"  AlternateText="Postpone" runat="server" BorderStyle="Outset"
                Width="100" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="Imgpost_Click" />
                <asp:ImageButton ID="ImageButton1" BackColor="ActiveCaption"  BorderStyle="Outset"
                AlternateText="Export" runat="server" Visible ="false" 
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" 
                onclick="ImageButton1_Click" />
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
         <div id="all-form-wrap1">
                    
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
        <asp:Panel ID="pnlgeneral" runat="server" Visible="true">
        <div style="height: 100">
            <table width="90%">
                <tr>
                    <td>
                        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsDetails" Width="400px" OnRowCommand="gvDetails_RowCommand"
                            CssClass="Gridview" ForeColor="#003964" PageSize="10">
                            <HeaderStyle BackColor="#003964" />
                            <Columns>
                                <asp:TemplateField HeaderText="FirstName" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Id") %>'
                                            ForeColor="Blue" Font-Underline="true" Width="90%" Text='<%# HighlightText(Eval("FirstName").ToString()) %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LastName" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbllastname" Text='<%# HighlightText(Eval("LastName").ToString()) %>'
                                            runat="server" Width="90%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastname2" Text='<%# HighlightText(Eval("CallDate1").ToString()) %>'
                                            runat="server" Width="90%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Program" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation1" Text='<%#HighlightText(Eval("DegreeCode").ToString()) %>'
                                            runat="server" Width="100%" CssClass="buttonface"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation2" Text='<%#HighlightText(Eval("Mobileno").ToString()) %>'
                                            runat="server" Width="100%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Email" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation6" Text='<%#HighlightText(Eval("Emailid").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Attended" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation3" Text='<%#HighlightText(Eval("AttendedBy").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation4" Text='<%#HighlightText(Eval("CallerStatus").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Followups" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblLocation5" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Id") %>'
                                            ForeColor="Blue" Font-Underline="true" Width="90%" CssClass="buttonface" Text='<%#HighlightText(Eval("TotalFollowUp").ToString()) %>'></asp:LinkButton>
                                        <%--
<asp:Label ID="lblLocation5" Text='<%#HighlightText(Eval("TotalFollowUp").ToString()) %>' runat="server" Width="90%"></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        </asp:Panel>


    <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ConnectionStrings:CDBConnectionString2 %>"
        SelectCommand="sp_displayrecords" UpdateCommand="sp_displayrecords" UpdateCommandType="StoredProcedure"
        SelectCommandType="StoredProcedure" 
        FilterExpression="TotalFollowUp LIKE '%{0}%' or firstName LIKE '%{0}%'  or LastName LIKE '%{0}%' or  Mobileno LIKE '%{0}%' or CallerStatus LIKE '%{0}%' or Degreecode LIKE '%{0}%' or AttendedBy LIKE '%{0}%'  or Emailid LIKE '%{0}%' or calldate1 LIKE '%{0}%' " 
        onselecting="dsDetails_Selecting">
        <FilterParameters>
            <asp:ControlParameter Name="firstName" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Mobileno" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="TotalFollowUp" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="CallerStatus" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="DegreeCode" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="AttendedBy" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Emailid" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="LastName" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="CallDate1" ControlID="txtSearch" PropertyName="Text" />
        </FilterParameters>
        <SelectParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
            <asp:SessionParameter Name="schoolcode" SessionField="schoolcode1" Type="string" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
            <asp:SessionParameter Name="schoolcode" SessionField="schoolcode1" Type="string" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <div class="GridviewDiv">
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div style="height: 100">
            <table width="90%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="SqlDataSource1" Width="500px" OnRowCommand="GridView1_RowCommand"
                            CssClass="Gridview" ForeColor="#003964">
                            <HeaderStyle BackColor="#003964" />
                            <Columns>
                                <asp:TemplateField HeaderText="FirstName" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkId1" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Id") %>'
                                            ForeColor="Blue" Font-Underline="true" Width="90%" Text='<%# HighlightText(Eval("FirstName").ToString()) %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LastName" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbllastname1" Text='<%# HighlightText(Eval("LastName").ToString()) %>'
                                            runat="server" Width="90%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastname21" Text='<%# HighlightText(Eval("CallDate1").ToString()) %>'
                                            runat="server" Width="90%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Program" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation11" Text='<%#HighlightText(Eval("DegreeCode").ToString()) %>'
                                            runat="server" Width="100%" CssClass="buttonface"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation21" Text='<%#HighlightText(Eval("Mobileno").ToString()) %>'
                                            runat="server" Width="100%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation61" Text='<%#HighlightText(Eval("Emailid").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attended" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation31" Text='<%#HighlightText(Eval("AttendedBy").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ayyear" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation41" Text='<%#HighlightText(Eval("Ayyear").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Followups" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblLocation51" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Id") %>'
                                            ForeColor="Blue" Font-Underline="true" Width="90%" CssClass="buttonface" Text='<%#HighlightText(Eval("TotalFollowUp").ToString()) %>'></asp:LinkButton>
                                        <%--
<asp:Label ID="lblLocation5" Text='<%#HighlightText(Eval("TotalFollowUp").ToString()) %>' runat="server" Width="90%"></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        </asp:Panel>

         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CDBConnectionString2 %>"
        SelectCommand="sp_displayrecordscancelpost" 
            UpdateCommand="sp_displayrecordscancelpost" UpdateCommandType="StoredProcedure"
        SelectCommandType="StoredProcedure" 
            
            FilterExpression="TotalFollowUp LIKE '%{0}%' or firstName LIKE '%{0}%'  or LastName LIKE '%{0}%' or  Mobileno LIKE '%{0}%' or Ayyear LIKE '%{0}%' or Degreecode LIKE '%{0}%' or AttendedBy LIKE '%{0}%'  or Emailid LIKE '%{0}%' or calldate1 LIKE '%{0}%' " 
            onselecting="SqlDataSource1_Selecting">
        <FilterParameters>
            <asp:ControlParameter Name="firstName" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Mobileno" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="TotalFollowUp" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Ayyear" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="DegreeCode" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="AttendedBy" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Emailid" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="LastName" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="CallDate1" ControlID="txtSearch" PropertyName="Text" />
        </FilterParameters>
        <SelectParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" 
                DefaultValue="0" />
            <asp:SessionParameter Name="option"  SessionField="option1" Type="string" 
                DefaultValue="1" />
                  <asp:SessionParameter Name="schoolcode" SessionField="schoolcode1" Type="string" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
                  <asp:SessionParameter Name="option"  SessionField="option1" Type="string" />
                    <asp:SessionParameter Name="schoolcode" SessionField="schoolcode1" Type="string" />
        </UpdateParameters>
    </asp:SqlDataSource>
      </div>
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
