<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCallSearchPage.aspx.cs" MasterPageFile="~/MasterForCallManagement.master" Inherits="Pages_EditCallSearchPage" %>
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
   <table>
 <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="Small" Text="School" Font-Names="tahoma" Width="150"></asp:Label>
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
   
   
   
    <div class="GridviewDiv">
        <p>
            <b>Search :</b>
            <asp:TextBox ID="txtSearch" runat="server" Width="150" AutoPostBack="true" Font-Names="tahoma"
                OnTextChanged="txtSearch_TextChanged" />&nbsp;&nbsp;
            <asp:CheckBox ID="chkall" runat="server" Text="ALL" Checked="false" AutoPostBack="true"
                OnCheckedChanged="chkall_checkedchanged" />
            <asp:ImageButton ID="btnSearch" BackColor="ActiveCaption" runat="server" AlternateText="Search"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnSearch_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="btnClear" BackColor="ActiveCaption" runat="server" AlternateText="Clear"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnClear_Click" />
            &nbsp;&nbsp;
         
                            <br />
            <br />
        </p>
        <asp:Panel ID="pnlgeneral" runat="server" Visible="true">
        <div style="height: 100">
            <table width="90%">
                <tr>
                    <td>
                        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsDetails" Width="500px" OnRowCommand="gvDetails_RowCommand"
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
                                <asp:TemplateField HeaderText="Email" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation6" Text='<%#HighlightText(Eval("Emailid").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                               
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        </asp:Panel>



    </div>
    <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CDBConnectionString2 %>" 
        SelectCommand="sp_displayrecords" SelectCommandType="StoredProcedure" FilterExpression="Name LIKE '%{0}%'">>
        <FilterParameters>
<asp:ControlParameter Name="Name" ControlID="txtSearch" PropertyName="Text" />
</FilterParameters
    </asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ConnectionStrings:CDBConnectionString2 %>"
        SelectCommand="sp_displayrecords_Update" UpdateCommand="sp_displayrecords_Update" UpdateCommandType="StoredProcedure"
        SelectCommandType="StoredProcedure" 
        FilterExpression="firstName LIKE '%{0}%'  or LastName LIKE '%{0}%' or  Mobileno LIKE '%{0}%' or CallerStatus LIKE '%{0}%' or Degreecode LIKE '%{0}%' or AttendedBy LIKE '%{0}%'  or Emailid LIKE '%{0}%' or calldate1 LIKE '%{0}%' " 
        onselecting="dsDetails_Selecting">
        <FilterParameters>
            <asp:ControlParameter Name="firstName" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Mobileno" ControlID="txtSearch" PropertyName="Text" />
            
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
    
</asp:Content>