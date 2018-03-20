<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MouCategory.aspx.cs" Inherits="Pages_SeatAllocations" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }
    </style>
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

        function validate() {
            var radio1 = $('#<%= rad_but1.ClientID%>');
            var radio2 = $('#<%= rad_but2.ClientID%>');
            if (!radio1.is(':checked') || !radio2.is(':checked')) {
                alert("Please Choose any scholarship or Feewaiver button");
            };
        } 

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlMainContent" runat="server" Visible="true">
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <div class="form-fieldset-wrapper-top">
                    <h2>
                        Category Types
                    </h2>
                </div>
                <div class="form-fieldset-wrapper-mid">
                    <div class="form-fieldset-wrapper-mid-inner">
                        <table class="style1" border="1">
                            <tr>
                                <td style="width: 15%">
                                </td>
                                <td colspan="6">
                                    <asp:RadioButton ID="rad_but1" runat="server" Text="Scholarship" OnCheckedChanged="radbt1_click"
                                        GroupName="AA" AutoPostBack="true" />
                                    <asp:RadioButton ID="rad_but2" runat="server" Text="Feewaiver"   OnCheckedChanged="radbut2_click"
                                        GroupName="AA" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                                </td>
                                <td colspan="6">
                                    <asp:DropDownList ID="ddlcategory" runat="server" OnSelectedIndexChanged="ddlcategory_selectedindexchanged"
                                        CssClass="textBox9" Width="280px" AutoPostBack="true">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:LinkButton ID="link_add" runat="server" OnClick="btn_click_show" Text="To Add new category"></asp:LinkButton>
                                    <asp:TextBox ID="txt_newcat" runat="server" Visible="false" Width="280px" CssClass="textBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Sub Category"></asp:Label>
                                </td>
                                <td colspan="6">
                                    <asp:DropDownList ID="DDL_Subcat" runat="server" Width="280px" OnSelectedIndexChanged="ddl_Subcategoryindexchanged"
                                        AutoPostBack="true" CssClass="textBox9">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:LinkButton ID="link_subcat" runat="server" OnClick="btn_click_show_subcat" Text="To Add new Subcat">
                                    </asp:LinkButton>
                                    <asp:TextBox ID="txtsub" runat="server" Visible="false" Width="280px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="AC-Year"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_Fyr" runat="server" Width="87px" CssClass="textBox9">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Req_Fyr" Display="Dynamic" runat="server" ControlToValidate="ddl_Fyr"
                                        ValidationGroup="vgadd" ErrorMessage=" * Required" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="To-Year"></asp:Label>
                                </td>
                                <td colspan="6">
                                    <asp:DropDownList ID="ddl_Tyr" runat="server" Enabled="false" CssClass="textBox9" Width="87px">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                   <%-- <asp:RequiredFieldValidator ID="Req_Tyr" Display="Dynamic" runat="server" ControlToValidate="ddl_Tyr"
                                        ValidationGroup="vgadd" ErrorMessage=" * Required" InitialValue="0" ForeColor="Red">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="DegreeType"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_degtype" runat="server" OnSelectedIndexChanged="ddldegree_selectedindex_changed"
                                        AutoPostBack="true" Width="87px" CssClass="textBox9">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="BBA" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="MBA" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="req_deg" Display="Dynamic" runat="server" ControlToValidate="ddl_degtype"
                                        ValidationGroup="vgadd" ErrorMessage=" * Required" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_tfnd" runat="server" Text="Total Fund"></asp:Label>
                                </td>
                                <td colspan="6">
                                    <asp:TextBox ID="txt_totalFund" runat="server" Width="87px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>                            
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="No Of Students Allocated"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_std_allocated" runat="server" Text="1" Width="87px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req3" runat="server" ControlToValidate="txt_std_allocated"
                                        ErrorMessage="* Required" ForeColor="Red" ValidationGroup="vgadd">
                                    </asp:RequiredFieldValidator>
                                </td>                            
                                <%--    <asp:Label ID="lbl_balshow"  runat ="server" ></asp:Label>--%>
                                  <td>
                                 <asp:Label ID="Label6" runat="server" Text="Percentage"></asp:Label>
                              </td>
                              <td>
                                    <asp:DropDownList ID="ddl_percentage" runat="server" CssClass="textBox9" Width="87px"
                                        OnSelectedIndexChanged="ddlpercen_selectedindex_changed" AutoPostBack="true">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="req_" runat="server" Display="Dynamic" ControlToValidate="ddl_percentage"
                                        ValidationGroup="vgadd" ErrorMessage=" * Required" InitialValue="0" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                       <asp:Label ID="lbl_peramount" runat="server" text="Percentage Amount:" ></asp:Label>
                                       <asp:Label ID="percen_Amt" runat="server"  ></asp:Label>
                                    <div align="left">
                                        <b>
                                            <asp:Label ID="lblbal" runat="server" Visible="false" Text="Balance:"></asp:Label>
                                            <asp:Label ID="lbl_balance" runat="server"> </asp:Label>
                                        </b>
                                    </div>
                                </td>
                              
                            </tr>
                            <tr>
                                 <td>
                                    <asp:Label ID="Label3" runat="server" Text="Alloted Fund"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="txt_af" runat="server" Width="87px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req2" runat="server" Display="Dynamic" ControlToValidate="txt_af"
                                         ErrorMessage="* Required" ForeColor="Red" ValidationGroup="vgadd">
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <label for="Password">
                                        File To Upload
                                    </label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="fileUpload1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td  >
                                    <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active" CssClass="CheckboxLists">
                                    </asp:CheckBox>
                                    <asp:CheckBox ID="chkisMou" runat="server" Text="Is MOU" CssClass="CheckboxLists">
                                    </asp:CheckBox>                                  
                                </td>

                                <td>
                                <asp:CheckBox ID="chk_IsSharjah" runat="server" Text="Is Sharjah Govt" />
                                </td>
                               <asp:Panel ID="pnl_Renewal" runat="server" Visible="false">
                                  <td>
                                  <asp:CheckBox ID="chk_renewal" runat="server" Text="Renewal" CssClass="CheckboxLists"  AutoPostBack="true"
                                   OnCheckedChanged="chk_renewal_Checked_Changed" />
                                  </td>
                              </asp:Panel>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Button ID="btnupdatedetails" runat="server" Visible="false" Text="Update" CommandArgument='<%#Eval("Id")%>'
                                        OnClick="Button2_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                    &nbsp;
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="HiddenField3" runat="server" /> 
                                </td>
                                <td colspan="6">
                                    <asp:Button ID="Button1" runat="server" ValidationGroup="vgadd" Text="Add" OnClick="Button1_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnupdate" runat="server" Text="Update" CommandArgument='<%#Eval("Id")%>'
                                    OnClick="Button2_Click" />
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
    </asp:Panel>
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
            <td>
                <asp:Button ID="btn_save_approval" runat="server" Visible="false" Text="Save Approval"
                    OnClick="btn_save_approval_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lbl_app" runat="server" ForeColor="Green" Visible="false" Font-Bold="true"
                    Font-Size="X-Small"></asp:Label>
            </td>
        </tr>
    </table>
    <div  id="divGridView" runat="server" style="overflow: auto">

        <asp:GridView ID="gvTOC" runat="server" AutoGenerateColumns="false" CssClass="grid-view" OnSorting="gvTOC_OnSorting"
            GridLines="Both" OnRowCommand="GvTOC_RowCommand" OnRowDeleted="gvTOC_RowDeleted"  OnRowDataBound="gvgvTOC_RowDataBound"
            DataKeyNames="Category" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="5"
            DataSourceID="dsTOC">
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="GridItem" />
            <EmptyDataTemplate>
                <label style="color: black; font-weight: bold; font-family: Verdana; font-size: 11px;">
                    There are no records to display.</label>
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="SNo">
                    <ItemTemplate>
                        <%# ((GridViewRow)Container).RowIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Approve All">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chk_AppAll" runat="server" />
                        Approve All
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_approval" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Approval Status">
                    <ItemTemplate>
                        <asp:Label ID="lbl_app" runat="server" Text='<%#Eval("Approval_Status").ToString()%>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" OnClientClick="javascript: return confirm('Are you sure you want to edit?')"
                            CommandArgument='<%#Eval("SNO") + ";" + Eval("isMOU") %>' Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                                  

                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <asp:Label ID="lblSN" runat="server" Text='<%#HighlightText(Eval("Category").ToString()) %>'></asp:Label>
                        <asp:HiddenField ID="hid_sno" runat="server" Value='<%#Bind("SNO") %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                
                <asp:TemplateField HeaderText="Sub-Cat">
                    <ItemTemplate>
                        <asp:Label ID="lblsub" runat="server" Text='<%#HighlightText(Eval("SubCategory").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AY">
                    <ItemTemplate>
                        <asp:Label ID="lblacdyr" runat="server" Text='<%#HighlightText(Eval("FromYear").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Degree">
                    <ItemTemplate>
                        <asp:Label ID="lbldegtype" runat="server" Text='<%#HighlightText(Eval("DegreeType").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="%age">
                    <ItemTemplate>
                        <asp:Label ID="lblperc" runat="server" Text='<%#HighlightText(Eval("Percentage").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Fund">
                    <ItemTemplate>
                        <asp:Label ID="lbltotalfund" runat="server" Text='<%#HighlightText(Eval("TotalFund").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Alloted Fund">
                    <ItemTemplate>
                        <asp:Label ID="lblappfund" runat="server" Text='<%#HighlightText(Eval("ApproveFund").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Students">
                    <ItemTemplate>
                        <asp:Label ID="lblstdalloted" runat="server" Text='<%#HighlightText(Eval("StdAlloted").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="FileName">
                    <ItemTemplate>
                        <asp:Label ID="lblfName" runat="server" Text='<%#HighlightText(Eval("uploadfilename").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
             
               
                <asp:TemplateField HeaderText="Change Status">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkdelete" runat="server" CommandName="DeleteRow" OnClientClick="javascript: return confirm('Are you sure you want to inactive?')"
                            CommandArgument='<%#Bind("SNO")%>' Text="InActive"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <HeaderStyle CssClass="GridHeader" />
            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
            <SelectedRowStyle CssClass="GridRowOver" />
            <EditRowStyle />
            <AlternatingRowStyle CssClass="GridAltItem" />
        </asp:GridView>
    </div>
    </div>
    <asp:SqlDataSource ID="dsTOC" runat="server" ConnectionString="<%$ConnectionStrings:SkyLineConnection %>"
        SelectCommand="GetCategoryDetails_New" SelectCommandType="StoredProcedure"
        FilterExpression="Category LIKE '%{0}%' or subcategory LIKE '%{0}%'
        or AccAdyear_Desc LIKE '%{0}%'  or DegreeType LIKE '%{0}%' or TotalFund LIKE '%{0}%' or Percentage LIKE '%{0}%'
        or ApproveFund LIKE '%{0}%' or StdAlloted LIKE '%{0}%' or uploadfilename LIKE '%{0}%' ">
        <FilterParameters>
            <asp:ControlParameter Name="Category"       ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="subcategory"    ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="AccAdyear_Desc" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="DegreeType"     ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="TotalFund"      ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Percentage"     ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="ApproveFund"    ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="StdAlloted"     ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="uploadfilename" ControlID="txtSearch" PropertyName="Text" />
        </FilterParameters>
        <%-- <SelectParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
        </UpdateParameters>--%>
    </asp:SqlDataSource>
    <asp:Panel ID="pnlSearch" Width="50%" runat="server" Style="display: none;" Visible="true">
   
        <div align="center">
            <table width="80%" border="1" cellpadding="5px" cellspacing="5px" style="background-color: silver;">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="user_ack" runat="server"></asp:Label>
                    </td>
                      <td align="center">
                    <div align="center">
                        <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cross.png" CausesValidation="false"
                            Style="float: none; margin-right: 2px;" />--%>
                            <asp:Button ID="btn_close"  Text="Close" runat="server" CausesValidation="false" />
                    </div>
                </td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label runat="server" Text="New Total Fund :"></asp:Label>
                    </td>
                    <td width="35%">
                        <asp:TextBox Visible="false" ID="txt_newtotalfnd" runat="server" Height="21px" Width="270px"> </asp:TextBox>
                    </td>
                    <td width="20%">
                        <asp:Button ID="btn_tf_save" Visible="false" runat="server" Text="Update TotalFund"  CausesValidation="true"
                            OnClick="btn_savenewtotalfund" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <cc1:ModalPopupExtender ID="M1" runat="server" BehaviorID="ModalPopupExtenderBehavior1"
        TargetControlID="HiddenField1" PopupControlID="pnlSearch" RepositionMode="RepositionOnWindowResizeAndScroll"
        BackgroundCssClass="modalBackground" X="350" Y="120">
    </cc1:ModalPopupExtender>
</asp:Content>
