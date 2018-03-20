<%@ Page Title="" Language="C#"  AutoEventWireup="true"  MasterPageFile="~/MasterPage.master"
 CodeFile="MOUFundEdit.aspx.cs" Inherits="Pages_MOUFundEdit" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:Panel ID="Panel1" runat="server">
        <div id="Div1">
            <div class="form-fieldset-wrapper">
                <div class="form-fieldset-wrapper-top">
                    <h2>
                        Details
                    </h2>
                </div>
                <div class="form-fieldset-wrapper-mid">
                    <div class="form-fieldset-wrapper-mid-inner">
                        <table class="style1">
                            <tr>
                                <td>
                                   <asp:Label ID="Label3" runat="server" Text="Mou Category"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="ddl_moucat" runat="server" OnSelectedIndexChanged="ddlSubcatLoad_selectedindexchanged" AutoPostBack="true"   ></asp:DropDownList>
                                </td>
                            </tr>
                           <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Mou SubCategory"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_subcat" runat="server">                                       
                                    </asp:DropDownList>
                                </td>
                            </tr>                   
                     
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                    &nbsp;
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_search" runat="server" Text="Search" onclick = "btn_search_moufund" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="form-fieldset-wrapper-bottom">
            </div>
        </div>
        <div>
         <asp:GridView ID="gvTOC" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
        EmptyDataText="There are no records to display." GridLines="Both"   onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating"  DataKeyNames="SNO" 
        OnRowDeleting="GridView1_RowDeleting"
        onrowdatabound="GridView1_RowDataBound"     >
        <FooterStyle CssClass="GridFooter" />
        <RowStyle CssClass="GridItem" />
        <Columns>

              <asp:TemplateField HeaderText="Subcategory">
                <ItemTemplate>
                    <asp:Label ID="lblSubcat" runat="server" Text='<%# Eval("SubCategory") %>' />
                </ItemTemplate>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="Degree Name">
             
              
                <ItemTemplate>
                    <asp:Label ID="lbldegid" runat="server"  Text='<%# Eval("degreename") %>'></asp:Label>
                    <asp:HiddenField ID="hid_no" runat="server" Value='<%# Eval("SNO") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                <asp:HiddenField ID="hid_sno" runat="server" Value= '<%# Eval("SNO") %>' />
                    <asp:DropDownList ID="ddl_1" runat="server" >
                      <asp:ListItem Text="BBA" Value="1"></asp:ListItem>
                       <asp:ListItem Text="MBA" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Term Name">
                <ItemTemplate>
                    <asp:Label ID="lblterm" runat="server"  Text='<%# Eval("Termname") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                       <asp:DropDownList ID="ddl_2" runat="server" >                   
                       </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Percentage">
                <ItemTemplate>
                    <asp:Label ID="lblpercen" runat="server" Text='<%# Eval("Percentage") %>' />
                </ItemTemplate>
                 <EditItemTemplate>
                     <asp:DropDownList ID="ddl_3" runat="server" >                       
                          <asp:ListItem Text="15"  Value="15"></asp:ListItem>
                          <asp:ListItem Text="25"  Value="25"></asp:ListItem>
                          <asp:ListItem Text="50"  Value="50"></asp:ListItem>
                          <asp:ListItem Text="100" Value="100"></asp:ListItem>                                   
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Approved Fund">
                <ItemTemplate>
                    <asp:Label ID="lblapprovefund" runat="server" Text='<%# Eval("Approvefund") %>' />
                </ItemTemplate>
                 <EditItemTemplate>
                    <asp:TextBox id="txt_Approvefund" runat="server" Text='<%# Eval("Approvefund") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="Edit" ShowHeader="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnedit" runat="server"   CommandName="Edit" Text="Edit"  
                        OnClientClick="javascript: return confirm('Are you sure you want to edit?')" ></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" ></asp:LinkButton>
                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel" ></asp:LinkButton>
                       
                    </EditItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                <asp:LinkButton ID="btndelete" runat="server" CommandName="Delete" Text="Delete" ></asp:LinkButton>               
                </ItemTemplate>
            </asp:TemplateField>       

        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <PagerStyle  CssClass="grid-pagination" HorizontalAlign="Right" />
        <SelectedRowStyle CssClass="GridRowOver" />
        <EditRowStyle BackColor="#CCCCCC"  />
        <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
        </div>

    </asp:Panel>
</asp:Content>