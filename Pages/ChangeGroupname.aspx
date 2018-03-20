<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangeGroupname.aspx.cs" Inherits="Pages_ChangeGroupname" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
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
                    <div class="form-fieldset-wrapper-mid-inner">                     
                    <table >
                   
                     <tr>
                     <td>
                     <asp:Label  ID="lbl_empname" runat="server" Text="Employee Name"></asp:Label>
                     </td>
                     <td> 
                     <asp:DropDownList ID="ddl_Empname" Width="250px" CssClass="textBox9" runat="server" AutoPostBack="true" 
                      OnSelectedIndexChanged="ddl_EmpName_Selectedindex_Changed" >
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rf_empname" runat="server" ControlToValidate="ddl_Empname"
                     ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                     
                     </td>                   
                     </tr>
                     <tr>
                     <td>
                     <asp:Label ID="lbl_Changegroup" runat="server" Text="Change Group" ></asp:Label>
                     </td>
                     <td>
                     <asp:DropDownList ID="ddl_Group" CssClass="textBox9" runat="server" Width="250px"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rf_group" runat="server" ControlToValidate="ddl_Group"
                      ValidationGroup="vgadd" ErrorMessage="*" InitialValue="---Select---" ForeColor="Red"></asp:RequiredFieldValidator>

                      <asp:Label  Font-Bold="true" ID="lbl_gname" runat="server" Text="Current Group:"></asp:Label>
                     <asp:Label Font-Bold="true"  ID="lbl_currentgroup" runat="server" ></asp:Label>
                     </td>
                     </tr>
                     <tr>

                     <td>
                       <asp:Label ID="lblState" runat="server" Text="Change State" ></asp:Label>
                     </td>
                     <td>
                     <asp:DropDownList ID="ddl_state" CssClass="textBox9" runat="server" Width="200px"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rf_State" runat="server" ControlToValidate="ddl_state"
                      ValidationGroup="vgadd" ErrorMessage="*" InitialValue="---Select---" ForeColor="Red"></asp:RequiredFieldValidator>
                         <asp:Label  Font-Bold="true" ID="lbl_State" runat="server" Text="Current State:"></asp:Label>
                         <asp:Label Font-Bold="true"  ID="lbl_states" runat="server" ></asp:Label>
                     </td>


                     </tr>

                     <tr>
                     <td>
                       <asp:Label ID="lbl_follow" runat="server" Text="Followup Mail" ></asp:Label>
                     </td>
                     <td>
                    <asp:RadioButtonList ID="Rad_but1" runat="server"  RepeatDirection="Horizontal" >
                    <asp:ListItem  Text="Yes" Value="1" Selected="True" ></asp:ListItem>
                    <asp:ListItem Text="No" Value="2" > </asp:ListItem>
                    </asp:RadioButtonList>
                     </td>
                     </tr>


                     <tr>
                     <td>
                       <asp:Label ID="lbl_reportAccess" runat="server" Text="Report Access" ></asp:Label>
                     </td>
                      <td>
                    <asp:RadioButtonList ID="Rad_but2" runat="server"  RepeatDirection="Horizontal" >
                    <asp:ListItem  Text="Yes" Value="1"  ></asp:ListItem>
                    <asp:ListItem Text="No" Value="2" Selected="True" > </asp:ListItem>
                    </asp:RadioButtonList>
                     </td>
                     </tr>

                     </table>                                     
                          <div align="center">                       
                            <asp:Button Font-Bold="true" ID="btn_tf_save" runat="server" Text="Update" OnClick="btn_update" ValidationGroup="vgadd" />  
                            <asp:Label ID="lblmsg" runat="server"  Font-Bold="true" ForeColor="Green"  Font-Size="8px" Visible="false" ></asp:Label>                      
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-fieldset-wrapper-bottom">
            </div>
            </div>
        </div>      
    </asp:Panel>
</asp:Content>
