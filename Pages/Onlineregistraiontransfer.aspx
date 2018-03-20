<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterForCallManagement.master" CodeFile="Onlineregistraiontransfer.aspx.cs" Inherits="Pages_Onlineregistraiontransfer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
     
    
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
        
        #mask
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>
  
     <script type="text/javascript" language="javascript">
        function CheckAllEmp(Checkbox) {
            var GridVwHeaderChckbox = document.getElementById("<%=gvDetails.ClientID %>");
            for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
                GridVwHeaderChckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
       </script>

    <style type="text/css">
        
      .tableBackground
{
	background-color:silver;
	opacity:0.7;
}
    </style>
    

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="GridviewDiv">
               <b>Admission Enquiry & Contactus Import</b>
               <br />
               <span style="color:Green; font-weight:bold;" >(Import Option is applicable from Records registered 26-2-2017 onwards ) </span>
               <p>
            <b>Search :  </b>
            <asp:TextBox ID="txtSearch" runat="server" Width="150" AutoPostBack="true" Font-Names="tahoma"
                OnTextChanged="txtSearch_TextChanged" />&nbsp;&nbsp;
                <asp:CheckBox ID="chkall" runat="server" Text="ALL" Checked="false" AutoPostBack="true"
                OnCheckedChanged="chkall_checkedchanged" />
                <asp:ImageButton ID="btnSearch" BackColor="ActiveCaption" runat="server" AlternateText="Search"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnSearch_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="btnClear" BackColor="ActiveCaption" runat="server" AlternateText="Clear"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnClear_Click" />
                    <asp:ImageButton ID="btnimport" BackColor="ActiveCaption" runat="server" AlternateText="Import to CMS"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnimport_Click" /> 
                 <asp:ImageButton ID="btnview" BackColor="ActiveCaption" runat="server" AlternateText="View Imported"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnview_Click" /> 
                
                   
          
                 <br />
                   <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true"  Font-Size="12px" Visible="true"></asp:Label>
                 </p>
               
            <br />
               
        <asp:Panel ID="pnlgeneral" runat="server" Visible="true">
        <div style="height: 100;overflow:scroll ">
            <table width="90%">
                <tr>
                    <td>
                        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsDetails" Width="500px" OnRowCommand="gvDetails_RowCommand"
                            CssClass="Gridview" ForeColor="#003964" PageSize="10"  DataKeyNames="id">
                            <HeaderStyle BackColor="#003964" />
                            <Columns>
                             <asp:TemplateField HeaderText="Import" ItemStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White"  SortExpression="kitstatus">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkApproveAll" runat="server" Text="Import" OnClick="CheckAllEmp(this);" Visible="true" />
                                            </HeaderTemplate>
                                              <ItemTemplate>
                                                <asp:CheckBox ID="chkApprove" runat="server" Visible="true" Checked="false"/>
                                              </ItemTemplate>
                                            <HeaderStyle ForeColor="White" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                    <asp:Label ID="lblLocation9" Text='<%# HighlightText(Eval("Name").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                     <asp:HiddenField ID="hdnid"  runat="server" Value='<%#Eval("Id").ToString() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                               <asp:TemplateField HeaderText="Nationality" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation1" Text='<%#HighlightText(Eval("nationality").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="CallDate" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCallDate" Text='<%#HighlightText(Eval("callDate1").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
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
                                        <asp:Label ID="lblLocation3" Text='<%#HighlightText(Eval("Emailid").ToString()) %>'
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Program" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation4" Text='<%#HighlightText(Eval("program").ToString()) %>'
                                            runat="server" Width="100%" CssClass="buttonface"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                            
                                  <asp:TemplateField HeaderText="Media Source" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation6" Text='<%#HighlightText(Eval("mediasource").ToString()) %>' 
                                            runat="server" Width="90%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="View Details" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                       <asp:LinkButton ID="popup" runat="server" Text="View" OnClick="popup_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="Type" ItemStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation16" Text='<%#HighlightText(Eval("Regtype").ToString()) %>' 
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
  
    <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ConnectionStrings:CDBConnectionString2 %>"
        SelectCommand="sp_displayrecordsonline" 
        UpdateCommand="sp_displayrecordsonline" UpdateCommandType="StoredProcedure"
        SelectCommandType="StoredProcedure" 
        FilterExpression="Regtype like '%{0}%'  or  nationality LIKE '%{0}%'  or Name LIKE '%{0}%'  or Mediasource  LIKE '%{0}%'  or  Mobileno LIKE '%{0}%' or program LIKE '%{0}%' 
        or Emailid LIKE '%{0}%' or calldate1 like '%{0}%' ">
        <FilterParameters>
            <asp:ControlParameter Name="Name" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Mobileno" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="program" ControlID="txtSearch" PropertyName="Text" />
          
            <asp:ControlParameter Name="Emailid" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Nationality" ControlID="txtSearch" PropertyName="Text" />
             <asp:ControlParameter Name="Mediasource" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="CallDate1" ControlID="txtSearch" PropertyName="Text" />
          <asp:ControlParameter Name="Regtype" ControlID="txtSearch" PropertyName="Text" />
            </FilterParameters>

         <SelectParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
        </UpdateParameters>
           
       
       
        
       
    </asp:SqlDataSource>
    <asp:Label ID="lblmsg" runat="server"/>
<asp:Button ID="modelPopup" runat="server" style="display:none" />
   <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="modelPopup" PopupControlID="updatePanel"
CancelControlID="btnCancel" BackgroundCssClass="tableBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="updatePanel" runat="server" BackColor="White" Height="230px" Width="700px" ScrollBars="Auto" style="display:none" >
<table width="100%" cellspacing="4">
	<tr style="background-color:#33CC66">
	<td colspan="2"  align="Left">Details</td>
	</tr>
	
    <tr>
    <td>
<asp:GridView ID="grdids" runat="server" AutoGenerateColumns="true" Width="70%"
                           ForeColor="#003964"  Font-Size="Small"></asp:GridView></td></tr>
      
        <tr>
		
		<td>
		<asp:Button ID="btnCancel" runat="server" Text="Close" />
		</td>
	</tr>                    
</table>
</asp:Panel>
 

</asp:Content>


