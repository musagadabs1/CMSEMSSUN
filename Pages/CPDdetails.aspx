<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CPDdetails.aspx.cs" Inherits="Pages_CPDdetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlMainContent" runat="server" Visible="true">
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <div class="form_round_border">
                    <div class="form_round_heading_row">
                        <!--this is heading row-->
                        <h2 class="slide_top">
                            CPD Details</h2>
                    </div>
                    <div class="round_form_content">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_acadyear" runat="server" Text="Academic Year"></asp:Label>
                                    </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_acyear" runat="server" Width="380px" OnSelectedIndexChanged="ddl_acyearSelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rf_year" runat="server" ControlToValidate="ddl_acyear"
                                        ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_termname" runat="server" Text="Term Name"></asp:Label>
                                    </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_termname" runat="server" Width="380px" 
                                        AutoPostBack="True" onselectedindexchanged="ddl_termname_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rf_termname" runat="server" ControlToValidate="ddl_termname"
                                     ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label2" runat="server" Text="Semester Name"></asp:Label>
                                    </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_semester" runat="server" Width="380px" OnSelectedIndexChanged="ddl_semester_selectedindex_changed"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rf_sem" runat="server" ControlToValidate="ddl_semester"
                                        ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lblSchedCourse" runat="server" Text="Schedule Of Course"></asp:Label></b>
                                </td>
                                <td>
                                    <%--<asp:DropDownList ID="ddl_Sched" runat="server"></asp:DropDownList>--%>
                                    <%--<asp:TextBox ID="txt_sched" runat="server" ></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_shed_course" runat="server" Width="380px" OnSelectedIndexChanged="ddl_schedcourse_selectedindex_changed"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rf_shed_course" runat="server" ControlToValidate="ddl_shed_course"
                                     ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_Fac" runat="server" Text="Faculty Name"></asp:Label>
                                    </b>
                                </td>
                                <td>
                                    <%--<asp:DropDownList ID="ddl_Fac" runat="server"></asp:DropDownList>--%>
                                    <%-- <asp:TextBox ID="txt_fac" runat="server" ></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_Faculty" runat="server" Width="380px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rf_fac" runat="server" ControlToValidate="ddl_Faculty"
                                        ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_target" runat="server" Text="Target Number of Students"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Maxseat" runat="server" Width="380px" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rf_maxseat" runat="server" ControlToValidate="txt_Maxseat"
                                        ValidationGroup="vgadd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_ach" runat="server" Text="Number of Students Achieved"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Minseat" runat="server" Width="380px" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rf_minseat" runat="server" ControlToValidate="txt_Minseat"
                                        ValidationGroup="vgadd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label1" runat="server" Text="Types Of CPD"></asp:Label>
                                    </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_types" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_type_SelectedindexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rf_types" runat="server" ControlToValidate="ddl_types"
                                        ValidationGroup="vgadd" ErrorMessage="*" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <%--  <table>
                            <tr>
                                <td align="right">
                                    <div>
                                        <asp:Button ID="btn_plus" runat="server" Text="SAVE" OnClick="btn_plus_click" />                                      
                                        <asp:Label ID="lbl_acknow"  Font-Bold="true" ForeColor="Green"  runat="server" Visible="false" > </asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>--%>
                        <table border="1" runat="server" id="Table1">
                            <tr>
                                <td align="center" colspan='4'>
                                    <b>
                                        <asp:Label ID="lbl_types" runat="server"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <%-- <tr><td align="center" colspan='4' style="text-decoration:underline;"><b>2 Weeks Before</b></td></tr>--%>
                        </table>
                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" OnRowDataBound="gridview1_OnRowDataBound"
                            Style="margin-left: 5px; margin-bottom: 10px; top: 0px; left: 0px; width: 99%;">
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="RowNumber" HeaderText="SNo" />--%>
                                <asp:TemplateField HeaderText="Activities">
                                    <ItemTemplate>
                                        <asp:Label ID="txt_Activities" runat="server" Text='<%#Bind("Activities") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_status" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Responsibility">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_res" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div>
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btn_plus" runat="server" Text="SAVE" OnClick="btn_plus_click" ValidationGroup="vgadd" />
                                        <asp:Label ID="lbl_acknow" Font-Bold="true" ForeColor="Green" runat="server" Visible="false"> </asp:Label>
                                        <%-- <asp:Button ID="btn_clear" runat="server" OnClick="btn_clear_click" Text="Clear" />
                                        <asp:Button ID="btn_print" runat="server" Text="Print" OnClick="btn_print_statement" />
                                        <asp:Label ID="lbl_msg" runat="server"></asp:Label>--%>
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" Style="margin-left: 5px;
                                margin-bottom: 10px; top: 0px; left: 0px; width: 99%;">
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ACYear" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("AcadYearId")%>
                                              <asp:HiddenField ID="hid_acadid" runat="server"  Value='<%#Eval("AcadYearId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TermName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("TermName")%>
                                            <asp:HiddenField ID="hid_termid" runat="server"  Value='<%#Eval("Termid")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Semester" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("Semester_Desc")%>
                                             <asp:HiddenField ID="hid_Semid" runat="server"  Value='<%#Eval("SemesterId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <%--<asp:TemplateField HeaderText="Types" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("CPD_TYPES")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Degree" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("Degree_desc")%>
                                             <asp:HiddenField ID="hid_degreeid" runat="server"  Value='<%#Eval("courseId")%>'  />
                                             <asp:HiddenField ID="hid_Facid"    runat="server"  Value='<%#Eval("facultyId")%>' />
                                             <asp:HiddenField ID="hid_typeid"   runat="server"  Value='<%#Eval("MasterId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="FacultyName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                           
                                            <%#Eval("Faculty_Name")%>                                      
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Print" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lnk_print" runat="server" Text="Print" OnClick="btn_print_Click" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <%--   <asp:Panel ID="pnlScroll" runat="server" Width="660px" ScrollBars="Both">
                        <CR:CrystalReportViewer ID="rptviewer_DepSmmryRpt" runat="server" DisplayStatusbar="False"
                            GroupTreeStyle-ShowLines="False" HasCrystalLogo="False" HasDrilldownTabs="False"
                            HasDrillUpButton="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False"
                            Height="50px" ReuseParameterValuesOnRefresh="True" ToolPanelView="None" Width="350px">
                        </CR:CrystalReportViewer>
                    </asp:Panel> --%>
                </div>
            </div>
        </div>
    </asp:Panel>
    </div>
</asp:Content>
