<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
 CodeFile="ChangeUser.aspx.cs" Inherits="Pages_ChangeUser" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[id*=chk_AppAll]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }   
            });
        });   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


 <asp:Panel ID="pnlMainContent" runat="server" Visible="true">

  <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <div class="form-fieldset-wrapper-top">
                    <h2>
                        Change Group Name
                    </h2>
                </div>
                <div class="form-fieldset-wrapper-mid">
                   <div class="form-fieldset-wrapper-mid-inner9">
                   <table style="width: 100%">
                        <tr>
                            <td style="width: 10%; font-weight: bold;">
                                From Employee
                            </td>
                            <td style="width:15%"  align="right" >
                                <asp:DropDownList ID="ddl_FromEmployee" runat="server" CssClass="textBox11" AutoPostBack="true"
                                 OnSelectedIndexChanged="ddl_FromEmployeeselectedindex_Changed" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rf_fromemp" runat="server" ControlToValidate="ddl_FromEmployee"
                                    ValidationGroup="vgadd" ErrorMessage=" * " InitialValue="0"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        
                            <td style="width: 10%; font-weight: bold;">
                                To Employee
                            </td>
                            <td style="width: 20%" align="right">
                                <asp:DropDownList ID="ddl_toEmployee" runat="server" CssClass="textBox11" AutoPostBack="true"
                                 OnSelectedIndexChanged="ddl_toEmployeeselectedindex_Changed"     Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rf_toemp" runat="server" ControlToValidate="ddl_toEmployee"
                                    ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            </tr>                         

                            <tr>
                            <td colspan="4" align="center" style="width:20%">
                                <asp:Button ID="Button1" runat="server" Font-Bold="true"  OnClick="btn_Transfer_Click"
                                    ValidationGroup="vgadd" Text="TRANSFER" />
                            </td>                          
                        </tr>
                    </table>
                    </div>
                </div>
            </div>
            <div class="form-fieldset-wrapper-bottom">
            </div>
            </div>
            <table cellpadding="10px" style="width: 100%">
                   <tr>
                                <td style="width: 50%" valign="top">                         
                      <asp:GridView ID="GridShow1" Width="93%" Height="50%" runat="server" AutoGenerateColumns="false"
                       Font-Size="X-Small" CssClass="grid-view" Style="overflow: auto; margin-left: 5px;
                       margin-bottom: 10px" EmptyDataText="There are no records to display">
                       <RowStyle CssClass="GridItem" />
                       <HeaderStyle CssClass="GridHeader" />
                       <PagerStyle />
                       <SelectedRowStyle CssClass="GridRowOver" />
                       <EditRowStyle />
                       <AlternatingRowStyle CssClass="GridAltItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Attender">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Attender" runat="server" Text='<%#Bind("Attender") %>'></asp:Label>
                                            <asp:HiddenField ID="hid_Empid1" runat="server" Value='<%#Bind("AttendedBy") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Caller">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCaller" runat="server" Text='<%#Bind("CallerCount") %>'></asp:Label>                                                
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>       
                                        
                                        <asp:TemplateField HeaderText="Visitor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVistor" runat="server" Text='<%#Bind("VisitorCount") %>'></asp:Label>                                                
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>                                      
                                                                              
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_AppAll" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_approval" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                             </td>
                              <td style="width: 50%" valign="top" align="right">
                                <asp:GridView ID="GridShow2" runat="server" AutoGenerateColumns="false" Width="93%"
                                    Style="margin-left: 5px; margin-bottom: 10px" Font-Size="X-Small" CssClass="grid-view"
                                    EmptyDataText="There are no records to display">
                                    <RowStyle CssClass="GridItem" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle />
                                    <SelectedRowStyle CssClass="GridRowOver" />
                                    <EditRowStyle />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Attender">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAttender" runat="server" Text='<%#Bind("Attender") %>'></asp:Label>
                                                <asp:HiddenField ID="hid_Empid2" runat="server" Value='<%#Bind("AttendedBy") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Caller">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCaller2" runat="server" Text='<%#Bind("CallerCount") %>'></asp:Label>                                               
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>   
                                        <asp:TemplateField HeaderText="Visitor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvisitor2" runat="server" Text='<%#Bind("VisitorCount") %>'></asp:Label>                                               
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>   
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chk_AppAll2" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_approval2" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                    </Columns>  
                                </asp:GridView>
                              </td>
                     </tr>
                       <div align ="center"> <asp:Label Visible="false"   Font-Bold="true" Font-Size="X-Small" ForeColor="Green" ID="lbl_ack" runat="server" Text="Transfered Successfully"></asp:Label> </div>
               </table>    
            
        </div>        
    
 </asp:Panel>
</asp:Content>