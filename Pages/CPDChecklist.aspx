<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CPDChecklist.aspx.cs" Inherits="Pages_CPDChecklist" %>
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
                            CPD COURSE CALENDAR
                        </h2>
                    </div>
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <table border="1" cellpadding="5" cellspacing="0">
                        <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label2" runat="server" Text="Academic Year"></asp:Label>
                                    </b>
                                </td>
                                 <td colspan="3">
                                    <asp:DropDownList ID="ddl_acadyear" runat="server" Width="390px" OnSelectedIndexChanged="ddl_acyearSelectedIndexChanged"   
                                      AutoPostBack="true"  >
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Rf_acadyear" runat="server" ControlToValidate="ddl_acadyear"
                                        ValidationGroup="vgadd" ErrorMessage="***" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                 </td>
                         </tr>

                          <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_termname" runat="server" Text="Term Name"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddl_termname" runat="server" Width="390px" 
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rf_termname" runat="server" ControlToValidate="ddl_termname"
                                     ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                         <tr>
                          <td>
                                    <b>
                                        <asp:Label ID="Label3" runat="server" Text="Semester Name"></asp:Label>
                                    </b>
                           </td>
                            <td colspan="3">
                                        <asp:DropDownList ID="ddl_Semester" runat="server" Width="390px"   >
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Rf_semester" runat="server" ControlToValidate="ddl_Semester"
                                        ValidationGroup="vgadd" ErrorMessage="***" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                         </tr>


                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lblSchedCourse" runat="server" Text="Schedule Of Course"></asp:Label>
                                    </b>
                                </td>
                                <td colspan="3">
                                        <asp:DropDownList ID="ddl_Sched" runat="server" Width="390px"   >
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Req_sched" runat="server" ControlToValidate="ddl_Sched"
                                        ValidationGroup="vgadd" ErrorMessage="***" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_month" runat="server" Text="From Date"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_fromdate" runat="server" Width="160px"  ></asp:TextBox>
                                    <%-- <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" /> --%>
                                    <cc1:CalendarExtender ID="txt_Fdate"  CssClass="MyCalendar" TargetControlID="txt_fromdate"  Format="dd/MM/yyyy"
                                     runat="server" PopupButtonID="ImgBCalender">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="Req_Fdate" runat="server" ControlToValidate="txt_fromdate"
                                        ErrorMessage="***" ValidationGroup="vgadd" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ToDate" runat="server" Width="160px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txt_Tdate"  CssClass="MyCalendar" TargetControlID="txt_ToDate"  Format="dd/MM/yyyy"
                                         runat="server">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="req_td" runat="server" ControlToValidate="txt_Todate"
                                        ErrorMessage="***" ValidationGroup="vgadd" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_ftime" runat="server" Text="From Time"></asp:Label></b>
                                </td>
                                <td align="left">
                                    (HH)
                                    <asp:DropDownList ID="cbo_hh" runat="server" Width="50">
                                    </asp:DropDownList>
                                    (MM)
                                    <asp:DropDownList runat="server" ID="cbo_mm" Width="50">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_Ttime" runat="server" Text="To Time"></asp:Label></b>
                                </td>
                                <td align="left">
                                    (HH)
                                    <asp:DropDownList ID="cbo_th" runat="server" Width="50">
                                    </asp:DropDownList>
                                    (MM)
                                    <asp:DropDownList runat="server" ID="cbo_tm" Width="50">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_davail" runat="server" Text="Days Available"></asp:Label></b>
                                </td>
                                <td colspan="3">
                                    <asp:CheckBox ID="chk_Sun" runat="server" Text="Sunday" />
                                    <asp:CheckBox ID="chk_Mon" runat="server" Text="Monday" />
                                    <asp:CheckBox ID="chk_Tue" runat="server" Text="Tuesday" />
                                    <asp:CheckBox ID="chk_Wed" runat="server" Text="Wednesday" />
                                    <asp:CheckBox ID="chk_Thu" runat="server" Text="Thursday" />
                                    <asp:CheckBox ID="chk_fri" runat="server" Text="Friday" />
                                    <asp:CheckBox ID="chk_Sat" runat="server" Text="Saturday" />
                                </td>
                            </tr>
                            <tr>
                            <td>
                            <b>
                            <asp:Label ID="lbl_remarks" runat="server" Text="Remarks"></asp:Label>
                            </b>
                            </td>
                            <td colspan="3" >
                            <asp:TextBox ID="txt_remarks" runat="server" Width="470px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="right">
                                    <div>
                                        <asp:Button ID="btn_plus" Font-Bold="true" runat="server" Text="Add" OnClick="btn_Add" ValidationGroup="vgadd" />
                                      <%--  <asp:Button ID="btn_Editmode" Font-Bold="true" runat="server" Text="Edit"   OnClientClick="javascript: return confirm('Are you sure you want to edit?')" OnClick="btn_edit" />--%>
                                        <asp:Button ID="btn_update" Font-Bold="true" runat = "server" Text="Update"  Visible="false"  OnClientClick="javascript: return confirm('Are you sure you want to update?')" OnClick="btn_Update" />
                                      <%--  <asp:Button ID="btn_remove" Font-Bold="true"  runat="server" Text="Remove"    OnClientClick="javascript: return confirm('Are you sure you want to remove?')"  OnClick="btn_removecoursesched"   />--%>
                                        <asp:Label ID="lbl_ack" runat="server" Visible="false"></asp:Label>
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

                        <asp:Panel ID="pnlsetup"  ClientIDMode="Static" runat="server" Width="700px" Height="300px" ScrollBars="Both">
                        <asp:GridView ID="grid_tab" ClientIDMode="Static" OnRowCommand="GvTOC_RowCommand"  OnRowDataBound="grid_tab_RowDataBound" AutoGenerateColumns="false" runat="server" 
                             Style="margin-left: 5px;    margin-bottom: 10px; top: 0px; left: 0px; width: 100%;"  >
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                               <%-- <AlternatingRowStyle CssClass="GridAltItem" />--%>
                                <Columns>
                                    <asp:TemplateField HeaderText="Approve All">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chk_AppAll" runat="server" />
                                            Select All
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
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Schedule Course">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sc" runat="server" Text='<%#Bind("Course_Schedule") %>'></asp:Label>
                                           <asp:HiddenField ID="hid_cId" runat="server" Value='<%#Bind("calendarId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="From Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Fd" runat="server" Text='<%#Bind("cs_Fromdate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="To Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Td" runat="server" Text='<%#Bind("cs_Todate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="From Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Ftime" runat="server" Text='<%#Bind("fromtime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="To Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Ttime" runat="server" Text='<%#Bind("Totime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Days Available">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Davail" runat="server" Text='<%#Bind("Daysavailble") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fees">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TotalFees" runat="server" Text='<%#Bind("totalFees") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks">
                                     <ItemTemplate>
                                     <asp:Label ID="lbl_gridrem" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label>
                                     </ItemTemplate>
                                     </asp:TemplateField>

                                     
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow"  
                         OnClientClick="javascript: return confirm('Are you sure you want to edit?')"
                        CommandArgument='<%#Eval("CalendarId")%>' Text="Edit"></asp:LinkButton>
                </ItemTemplate>
                 <ItemStyle Width="10px" HorizontalAlign="Center" />
                  <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Remove">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkdelete" runat="server" CommandName="DeleteRow" 
                    OnClientClick="javascript: return confirm('Are you sure you want to Remove?')"
                    CommandArgument='<%#Eval("CalendarId")%>' Text="Remove"></asp:LinkButton>
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
                   <asp:HiddenField ID="HiddenField1" runat="server" 
                       onvaluechanged="HiddenField1_ValueChanged" />
                   <asp:Button ID="btn_finalize" Font-Bold="true"  runat="server"  Text="Finalize"   ValidationGroup="finalized" Visible="True " OnClick="btn_finalize_click" />
                   <asp:Button ID="btn_clear"    Font-Bold="true"  runat="server"  Text="Clear"      OnClick="btn_clear_Click" />                                    
                   <asp:Button ID="btnprint"     Font-Bold="true"  runat="server"  Text="Print"      OnClick="btn_print_Click"    OnClientClick="document.getElementById('form1').target ='_blank';" />
                   <asp:Label  ID="lbl_msg" runat="server"  Visible ="false" Text="Please choose the row to be finalized" > </asp:Label>
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
