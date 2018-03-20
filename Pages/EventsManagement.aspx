<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EventsManagement.aspx.cs" Inherits="Pages_EventsManagement" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script language="javascript" type="text/javascript">
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

       <script type="text/javascript">
           function Search_Gridview(strKey, strGV) {
               var strData = strKey.value.toLowerCase().split(" ");
               var tblData = document.getElementById(strGV);
               var rowData;
               for (var i = 1; i < tblData.rows.length; i++) {
                   rowData = tblData.rows[i].innerHTML;
                   var styleDisplay = 'none';
                   for (var j = 0; j < strData.length; j++) {
                       if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                           styleDisplay = '';
                       else {
                           styleDisplay = 'none';
                           break;
                       }
                   }
                   tblData.rows[i].style.display = styleDisplay;
               }
           }    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlMainContent" runat="server" Visible="true">
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <div class="form_round_border">
                    <div class="form_round_heading_row">
                        <!--this is heading row-->
                        <h2 class="slide_top">
                            CERTIFICATE IN EVENTS MANAGEMENT
                        </h2>
                    </div>
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <table border="1" cellpadding="5" cellspacing="0">
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label3" runat="server" Text="Academic Year"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddl_Fyr" runat="server" Height="24px" Width="280px"  
                                     AutoPostBack="true" OnSelectedIndexChanged="Acyear_selectedindex_changed" >
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Req_Fyr" runat="server" ControlToValidate="ddl_Fyr"
                                    ValidationGroup="vgadd" ErrorMessage=" * Please Choose From-Year" InitialValue="0"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lblSchedCourse" runat="server" Text="Title Of Course"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddl_Sched" runat="server" Width="500px" AutoPostBack="true" Height="30px">
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Req_sched" runat="server" ControlToValidate="ddl_Sched"
                                        ValidationGroup="vgadd" ErrorMessage="***" InitialValue="0"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label1" runat="server" Text="About"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_about" runat="server" TextMode="MultiLine" Width="500px" Height="30px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_about"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>                            

                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_course_intro" runat="server" Text="Course Introduction"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_crse_intro" runat="server" TextMode="MultiLine" Width="500px"
                                        Height="30px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_crse_intro"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_mq" runat="server" Text="Audience/Minimum Qualification"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_amqli" runat="server" TextMode="MultiLine" Width="500px" Height="30px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_amqli"
                                         ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_co" runat="server" Text="Carrer Opportunities"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_co" runat="server" TextMode="MultiLine" Width="500px" Height="30px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_co"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label2" runat="server" Text="Course Contents"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_con" runat="server" TextMode="MultiLine" Width="500px" Height="30px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_con"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label4" runat="server" Text="Course Schedule"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_course_schedule" runat="server" TextMode="MultiLine" Width="500px" Height="30px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req_cshed" runat="server" ControlToValidate="txt_course_schedule"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                           
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_exam" runat="server" Text="Examination"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_exam" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_exam"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_crse_fee" runat="server" Text="Course Fee"></asp:Label>
                                    </b>
                                </td>
                                <td >
                                  <asp:DropDownList ID="ddl_Course_fee" runat="server" Width="100px" Height="30px" AutoPostBack="true" OnSelectedIndexChanged = "CourseFee_Selectedindex_changed" >
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                  </asp:DropDownList>
                                  </td>
                                   <td colspan="2">
                                    <asp:TextBox ID="txt_course_fee" runat="server" TextMode="MultiLine" Width="381px" Height="20px"></asp:TextBox>                                  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_course_fee"
                                       ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_regDate" runat="server" Text="Last Date To Register"></asp:Label>
                                    </b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_regdate" runat="server" TextMode="MultiLine" Width="100px" Height="20px"  ></asp:TextBox>
                                    
                                    <cc1:CalendarExtender ID="txt_Tdate" Format="dd/MM/yyyy" CssClass="MyCalendar" TargetControlID="txt_regdate"
                                        runat="server">
                                    </cc1:CalendarExtender>
                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_regdate"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td colspan="2">
                                 <asp:TextBox ID="txt_datedetails" runat="server" TextMode="MultiLine" Width="381px" Height="20px"></asp:TextBox>
                                </td>
                               
                                
                                
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_adreq" runat="server" Text="Admission Requirements"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_ad_req" runat="server" TextMode="MultiLine" Width="500px" Height="30px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_ad_req"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_refund_policy" runat="server" Text="Refund Policy"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_refund_policy" runat="server" TextMode="MultiLine" Width="500px"
                                        Height="30px">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_refund_policy"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_gt_con" runat="server" Text="General Terms and Conditions"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_gt_con" runat="server" TextMode="MultiLine" Width="500px" Height="30px">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_gt_con"
                                        ValidationGroup="vgadd" ErrorMessage="***"  ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="right">
                                    <div>
                                        <asp:Button ID="btn_plus" Font-Bold="true" runat="server" Text="Add" ValidationGroup="vgadd" OnClick="btn_Add" />
                                        <asp:Button ID="btn_summary" Font-Bold="true" runat="server" Text="PrintSummary"  OnClick="btn_print_Summary" />
                                       <%-- <asp:Button ID="Edit" runat="server" Text="Edit" />--%>
                                        <asp:Button ID="btn_update" Font-Bold="true" runat="server" Text="Update" Visible="false"  OnClick="btn_Update" />
                                      <%--  <asp:Button ID="btn_remove" runat="server" Text="Remove" />--%>
                                      <%--  <asp:Label ID="lbl_ack" runat="server" Visible="false"></asp:Label>--%>
                                        <%-- <asp:Button ID="btn_minus" runat="server" Text="-" onclick="btn_minus_Click" />--%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table border="1" runat="server" id="Table1">
                            <tr>
                                <td align="center" colspan='4' style="text-decoration: underline;">
                                    <b>CENTER FOR PROFESSIONAL DEVELOPMENT COURSE CALENDAR</b>
                                </td>
                            </tr>
                            <%--<tr><td align="center"><b>S.No</b></td><td align="center"><b>Activities</b></td><td align="center"><b>Status</b></td><td align="center"><b>Responsibility</b></td></tr>--%>
                        </table>

                         <div>
                        
                          Search:  <asp:TextBox runat="server" ID="txtSearch" onkeyup="Search_Gridview(this, 'grid_tab')"></asp:TextBox>
                        </div>

                        <asp:Panel ID="pnlsetup" runat="server" Width="700px" Height="300px" ScrollBars="Both">
                            <asp:GridView ID="grid_tab" ClientIDMode="Static" OnRowDataBound="grid_tab_RowDataBound" OnRowCommand="GvTOC_RowCommand" 
                             AutoGenerateColumns="false" runat="server" Style="margin-left: 5px;  
                             margin-bottom: 10px; top: 0px; left: 0px; width: 100%;  "  >
                              
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />                             
                              <%--  <AlternatingRowStyle CssClass="GridAltItem" />--%>
                                <Columns> 
                                    <asp:TemplateField HeaderText="Approve All">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chk_AppAll" runat="server" />
                                            All
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_approval" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="SNo">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                              <asp:HiddenField runat="server" ID="hid_finalize"  Value='<%#Bind("Finalize") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="AY">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sc" runat="server" Text='<%#Bind("Academicyear") %>'></asp:Label>
                                            <asp:HiddenField ID="hid_cId" runat="server" Value='<%#Bind("CPDid") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_shedcourse" runat="server" Text='<%#Bind("course_schedule") %>'></asp:Label>
                                            <asp:HiddenField ID="shedcourse_id" runat="server" Value='<%#Bind("courseshedId") %>' />
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Course Intro">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Fd" runat="server" Text='<%#Bind("Course_Intro") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Course Fee">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_coursefee" runat="server" Text='<%#Bind("course_fee") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Audience/Minimum Qualification">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Ftime" runat="server" Text='<%#Bind("aud_min_qualify") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>


                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" OnClientClick="javascript: return confirm('Are you sure you want to edit?')"
                                                CommandArgument='<%#Eval("CPDid")%>' Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Remove">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkdelete" runat="server" CommandName="DeleteRow" OnClientClick="javascript: return confirm('Are you sure you want to Remove?')"
                                                CommandArgument='<%#Eval("CPDid")%>' Text="Remove"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                </Columns>
                                  <emptydatarowstyle  HorizontalAlign="Center" Font-Bold="true"  backcolor="LightBlue"  forecolor="Red"/>
                                    <emptydatatemplate>
                                    No Data Found
                                    </emptydatatemplate>
                            </asp:GridView>
                        </asp:Panel>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Button ID="btn_save"  runat="server"  Text="Finalize"   OnClick="btn_finalize_click" />
                                    <asp:Button ID="btn_clear" runat="server"  Text="Clear"      OnClick="clear" />
                                    <asp:Button ID="btnprint"  runat="server"  Text="Print"      OnClick="btn_print_Click" />
                                    <asp:Label  ID="lbl_msg"  Font-Bold="true" ForeColor="Red"  runat="server" ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    </div>
</asp:Content>
