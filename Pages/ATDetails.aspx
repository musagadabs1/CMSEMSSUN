<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ATDetails.aspx.cs" Inherits="Pages_ATDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
           .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        
        .form-heading{
	width:715px;
	height:25px;
	float:left;
	position:relative;
	margin:0px;
	padding:0px;
	font-family:Verdana;
	font-size:medium;
	font-weight:bold;
	}
        
        
          .form-button{
	float:right;
	position:relative;
	margin:0px;
	padding:0px;
	font-family:Verdana;
	font-size:small;
	font-weight:bold;
	}
	
	
	
        </style>
        </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="form-heading">
                <!--Div for the form fieldset wrapper top rounded part-->
              
                    Aptitude Test
              
<asp:linkButton ID="BTNSEARCH"  runat="server" Text="Search Student" OnClick="BTNSEARCH_CLICKED" CssClass="form-button" />  
   <br />

</div>
 <div id="Div1" style="width: 693px">         
    
                 
                                <asp:ImageButton ID="imgapp" runat="server" src="..\Icons\button.png" width="10%" Height="10%" 
                                        Visible="false"/>
                                </div>
                                <div>
                                   <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>                              
                                </div>
      <asp:Panel ID="Panel1" runat="server">
   <div id="list-member-block" style="width: 693px">
                                        <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                            EmptyDataText="There are no records to display."
                                            GridLines="Both" CssClass="grid-view"  
                                            OnRowDataBound="gvStudentList_RowDataBound" onselectedindexchanged="gvStudentList_SelectedIndexChanged"
                                          
                                            >                                          
                                             
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.N." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSN" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="S.Name" SortExpression="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                   <%--  <asp:HiddenField  ID="hklinkid" runat="server" Value='<%#Bind("LinkId") %>'/>--%>
                                                                                        
                                                <asp:Label ID="lnkId" runat="server"   Text='<%#Bind("Name") %>'/>
                                             
                                                 </ItemTemplate>
                                                       <HeaderStyle HorizontalAlign="Center" />
                                                       <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField> 
                                                 <asp:TemplateField HeaderText="Id" SortExpression="Username" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>                                                    
                                                        <asp:Label ID="lbluserName" ForeColor="BlueViolet" runat="server" Text='<%#Bind("Username") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                     <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Pwd" SortExpression="apassword" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>                                                    
                                                        <asp:Label ID="lblpassword" ForeColor="BlueViolet"  runat="server" Text='<%#Bind("apassword") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                     <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Status" SortExpression="astatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>   
                                                    <asp:HiddenField  ID="hklinkid" runat="server" Value='<%#Bind("LinkId") %>'/>
                                                    <asp:HiddenField  ID="hktc" runat="server"/>
                                                                                                                  
                                                     <asp:Label ID="lblastatus" ForeColor="green"  runat="server" Text='<%#Bind("astatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                       <HeaderStyle HorizontalAlign="Center" />
                                                       <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="TestCode" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate> 
                                                     <asp:HyperLink ID="drptestcode" runat="server" Text='<%#Bind("test_code")  %>' Target="_blank" NavigateUrl='<%#"~/Pages/PrintOtherReport.aspx?E=15&A="+ Eval("test_code") %>'></asp:HyperLink>                                                                
                                                      <%--<asp:Label ID="lblastatus" ForeColor="green"  runat="server" Text='<%#Bind("astatus") %>'></asp:Label>--%>
                                                                                                       
                                                    <asp:HiddenField ID="hdntc" runat="server" Value='<%#Eval("test_code")  %>' />
                                                    </ItemTemplate>
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Counseled" SortExpression="astatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>   
                                                    <asp:Radiobuttonlist id="rdocounsel" runat="server" repeatdirection="Horizontal" autopostback="true"  OnSelectedIndexChanged="rdocounsel_SelectedIndexChanged"   selectedvalue= '<%#Bind("counsel") %>'                      >
                                                 <asp:ListItem  Text="YES" Value="YES">
                                                 </asp:ListItem>
                                                 <asp:ListItem  Text="NO" Value="NO">
                                                 </asp:ListItem>
                                                 </asp:Radiobuttonlist>                          
                                                 </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="View Counsel" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate> 
                                                 <asp:LinkButton ID="lnkview" runat="server" Text="View" OnClick="lnkview_clicked"  ></asp:LinkButton>                                                              
                                                      <%--<asp:Label ID="lblastatus" ForeColor="green"  runat="server" Text='<%#Bind("astatus") %>'></asp:Label>--%>
                                                                                                     
                                                                                                     </ItemTemplate>
                                                     <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Act." ItemStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                         
                                                <ItemTemplate>
                                                <asp:radiobutton ID="chkactiveaptitude" runat="server"  AutoPostBack="true"
                                                        Checked='<%#Bind("active") %>' GroupName="rdogroup" 
                                                        oncheckedchanged="chkactiveaptitude_CheckedChanged"  />
                                                </ItemTemplate>
                                            <HeaderStyle ForeColor="White" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>                                                                                                                                
                                                 
                                                    <asp:TemplateField HeaderText="DeAct." SortExpression="activate" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>                                                    
                                                    <asp:radiobutton ID="chkdeactiveapp" runat="server" Checked='<%#Bind("deactive") %>' GroupName="rdogroup"  AutoPostBack="true"  oncheckedchanged="chkdeactiveap_CheckedChanged"  />
                                                    </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
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
                                 <asp:Button ID="btnShowPopup" runat="server" style="display:none" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"

BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="269px" Width="400px" style="display:none">
<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#D55500">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Couseling Informations</td>
</tr>
<tr style="background-color: #008080; color: #FFFFFF; font-size: large; font-weight: bold">
<td align="right" style="width:45%">
Test Code: </td>
<td>
<asp:Label ID="Lbltestcode2" runat="server"></asp:Label>
</td>
<asp:HiddenField ID="HiddenField1" runat="server" />
</tr>
<tr style="background-color: #008080; color: #FFFFFF; font-size: large; font-weight: bold">
<td align="right" style="width:45%">
Counseled date : </td>
<td>
  <asp:TextBox ID="txtSCFromDay" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
    <asp:TextBox ID="txtSCFromMonth" runat="server" CssClass="textBox1" Width="40px"
        MaxLength="2"></asp:TextBox>
   <asp:TextBox ID="txtSCFromYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
   <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender34" runat="server" Enabled="True"
      TargetControlID="txtSCFromYear" WatermarkText="YYYY">
   </cc1:TextBoxWatermarkExtender>
   <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender35" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCFromMonth" WatermarkText="MM">
   </cc1:TextBoxWatermarkExtender>
  <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender36" runat="server" Enabled="True"
    TargetControlID="txtSCFromDay" WatermarkText="DD">   
    </cc1:TextBoxWatermarkExtender>
</td>
<asp:HiddenField ID="hdntestcode" runat="server" />
</tr>
<tr style="background-color: #008080; color: #FFFFFF; font-size: large; font-weight: bold">
<td align="right" style="width:45%">
Remarks :
</td>
<td>
<asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine"></asp:TextBox>
</td>
</tr>

<tr>

<td>
</td>
<td><asp:Label ID="lblmess" runat="server" Text="11" Font-Bold="true" Font-Size="Large"></asp:Label></td>
</tr>
<tr>
<td></td>
<td>
<asp:Button ID="btnUpdate" CommandName="Save" runat="server" Text="Update" OnClick="btnupdate_click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btncancel_click" />

</td>
</tr></table>
</asp:Panel>
</asp:Content>
