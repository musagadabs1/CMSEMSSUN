<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterForCallManagement.master" CodeFile="DeletePermanently.aspx.cs" Inherits="Pages_DeletePermanently" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
     function shopPopup() {
         var modalPopupExtender = $find('ModalPopupExtenderBehavior');
         modalPopupExtender.show();
     }
     function hidePopup() {
         var modalPopupExtender = $find('ModalPopupExtenderBehavior');
         modalPopupExtender.hide();
     }	
    </script>
     <style type="text/css">
           .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        </style>
         <script type = "text/javascript">
             function Confirm() {
                 var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 if (confirm("Are you want to Delete?")) {
                     confirm_value.value = "Yes";
                 } else {
                     confirm_value.value = "No";
                 }
                 document.forms[0].appendChild(confirm_value);
             }
    </script>

    <style type="text/css">
.GridviewDiv {font-size: 11px;  font-weight: normal; font-family: 'tahoma'; color: #303933;}
Table.Gridview{border:solid 1px #003964;}
.Gridview th{color:white;border-right-color:#003964;border-bottom-color:#003964;padding:0.5em 0.5em 0.5em 0.5em;text-align:center}  
.Gridview td{border-bottom-color:#003964;border-right-color:#003964;padding:0.5em 0.5em 0.5em 0.5em;}
.Gridview tr{color: Black; background-color:#D3D3D3; text-align:left}
:link,:visited { color: #DF4F13; text-decoration:none }
.highlight {text-decoration: none;color:black;background:yellow;}
.buttonface{ text-align:center;}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="GridviewDiv">
<p>
<b>Search :</b>
<asp:TextBox ID="txtSearch" runat="server" Width="450" AutoPostBack="true" 
        ontextchanged="txtSearch_TextChanged"   />&nbsp;&nbsp;
          <asp:CheckBox ID="chkall" runat="server" Text="ALL" Checked="false" AutoPostBack="true" OnCheckedChanged="chkall_checkedchanged" />


<asp:ImageButton ID="btnSearch"  BackColor="ActiveCaption" runat="server" AlternateText="Search" Width="50" CssClass="buttonface" 
Style="top: 5px; position: relative" onclick="btnSearch_Click" />&nbsp;&nbsp;
<asp:ImageButton ID="btnClear" BackColor="ActiveCaption"  runat="server" AlternateText="Clear" Width="50"  CssClass="buttonface"  Style="top: 5px;
position: relative" onclick="btnClear_Click" /> &nbsp;&nbsp;
<asp:ImageButton ID="btnNew" BackColor="ActiveCaption"  AlternateText="New"   runat="server" Width="50" CssClass="buttonface"  Style="top: 5px;
position: relative" onclick="btnNew_Click" /><br />
<br />
</p>
  <div  style ="height:100">
<table  width="90%">
<tr>
<td>
<asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
AllowSorting="True" DataSourceID="dsDetails" Width="500px"   OnRowCommand="gvDetails_RowCommand"
        CssClass="Gridview" ForeColor="#003964" PageSize="10" >
<HeaderStyle BackColor="#003964" />
<Columns>
<asp:TemplateField HeaderText="FirstName" ItemStyle-Width="40%">
<ItemTemplate>
<asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Id") %>' ForeColor="Blue"  Font-Underline="true" Width="90%"
           Text='<%# HighlightText(Eval("FirstName").ToString()) %>'></asp:LinkButton>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LastName" ItemStyle-Width="40%">
<ItemTemplate>
<asp:Label ID="lbllastname" Text='<%# HighlightText(Eval("LastName").ToString()) %>' runat="server" Width="90%"/>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Date" ItemStyle-Width="20%">
<ItemTemplate>
<asp:Label ID="lblLastname2" Text='<%# HighlightText(Eval("CallDate1").ToString()) %>' runat="server" Width="90%"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Program" ItemStyle-Width="10%">
<ItemTemplate>
<asp:Label ID="lblLocation1" Text='<%#HighlightText(Eval("DegreeCode").ToString()) %>' runat="server" Width="40%"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Mobile" ItemStyle-Width="30%">
<ItemTemplate>
<asp:Label ID="lblLocation2" Text='<%#HighlightText(Eval("Mobileno").ToString()) %>' runat="server" Width="100%"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Email" ItemStyle-Width="40%">
<ItemTemplate>
<asp:Label ID="lblLocation6" Text='<%#HighlightText(Eval("Emailid").ToString()) %>' runat="server" Width="90%"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Attended" ItemStyle-Width="10%">
<ItemTemplate>
<asp:Label ID="lblLocation3" Text='<%#HighlightText(Eval("AttendedBy").ToString()) %>' runat="server" Width="90%"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" ItemStyle-Width="20%"> 
<ItemTemplate>
<asp:Label ID="lblLocation4" Text='<%#HighlightText(Eval("CallerStatus").ToString()) %>' runat="server" Width="90%"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Followups" ItemStyle-Width="20%" >
<ItemTemplate>
<asp:LinkButton ID="lblLocation5" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Id") %>' ForeColor="Blue"  Font-Underline="true" Width="90%" CssClass="buttonface"
           Text='<%#HighlightText(Eval("TotalFollowUp").ToString()) %>'></asp:LinkButton>

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
</div>

   <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CDBConnectionString2 %>" 
        SelectCommand="sp_displayrecords" SelectCommandType="StoredProcedure" FilterExpression="Name LIKE '%{0}%'">>
        <FilterParameters>
<asp:ControlParameter Name="Name" ControlID="txtSearch" PropertyName="Text" />
</FilterParameters
    </asp:SqlDataSource>--%>

<asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ConnectionStrings:CDBConnectionString2 %>" 
SelectCommand="sp_displayrecords" 
SelectCommandType="StoredProcedure" UpdateCommand="sp_displayrecords" UpdateCommandType="StoredProcedure"
FilterExpression="TotalFollowUp LIKE '%{0}%' or firstName LIKE '%{0}%'  or LastName LIKE '%{0}%' or  Mobileno LIKE '%{0}%' or CallerStatus LIKE '%{0}%' or Degreecode LIKE '%{0}%' or AttendedBy LIKE '%{0}%'  or Emailid LIKE '%{0}%' ">
<FilterParameters>
<asp:ControlParameter Name="firstName" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="Mobileno" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="TotalFollowUp" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="CallerStatus" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="DegreeCode" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="AttendedBy" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="Emailid" ControlID="txtSearch" PropertyName="Text" />
<asp:ControlParameter Name="LastName" ControlID="txtSearch" PropertyName="Text" />
</FilterParameters>
 <SelectParameters>
   <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />  
     
    </SelectParameters>

     <UpdateParameters>
<asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />   
     
    </UpdateParameters>

</asp:SqlDataSource>
                 <asp:Panel ID="pnldelete" runat="server" Style="display: none;" >
                <div id="Div1" style="background-color: #E3E2E3 !important;">
                    <table class="GridviewDiv">
                   
                    <tr>
                    
                    <td colspan="2" align="right">
                   <asp:ImageButton ID="Button1"  ImageAlign ="right" runat="server"    AlternateText="Close"  ImageUrl="~/Icons/download.jpg" Width="20" Height="20"/>
                 </td>
                    </tr>
                     <tr>
                     <td colspan="2" align="center">
                    <b> Deletetion </b>
                        </td>
                    
                    
                    </tr>
                    <tr>
                    <td>
                    Remarks For Deletetion 
                    
                    </td>
                    <td>
                    <asp:HiddenField ID="hdnplink" runat="server" />
                    <asp:TextBox ID="txtpremarks" runat="server" TextMode="MultiLine" Width="200"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="2" align="center">
                    <asp:Button ID="btndelete" runat="Server"  Text="Delete"  OnClick="btnpsave_Click" OnClientClick = "Confirm()"/>
                    </td>
                    <td> <asp:Label ID="lblMesagesp" runat="Server" Text=""></asp:Label></td>
                    </tr>
                    </table>
                    </div>
                    </asp:Panel>
                 
         
             <asp:HiddenField ID="hdDummy1" runat="server" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BehaviorID="ModalPopupExtenderBehavior"
                TargetControlID="hdDummy1" PopupControlID="pnldelete" RepositionMode="RepositionOnWindowResizeAndScroll"
                BackgroundCssClass="modalBackground" X="500" Y="120">
            </cc1:ModalPopupExtender>
  
</asp:Content>
