<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CourseandWrkshpdet.aspx.cs" Inherits="Pages_CourseandWrkshpdet" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlMainContent" runat="server" Visible="true">
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <div class="form_round_border">
                    <div class="form_round_heading_row">
                        <!--this is heading row-->
                        <h2 class="slide_top">
                            Course and WorkshopDetails Details</h2>
                    </div>
                    <div class="round_form_content">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lblSchedCourse" runat="server" Text="Schedule Of Course"></asp:Label></b>
                                </td>
                                <td>
                                    <%--<asp:DropDownList ID="ddl_Sched" runat="server"></asp:DropDownList>--%>
                                    <asp:TextBox ID="txt_sched" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txt_fac" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_month" runat="server" Text="Month"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpmonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpmonth_selectedindex_changed">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="Label1" runat="server" Text="Year"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DrpYear" runat="server">
                                        <asp:ListItem Text="----Select---" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="right">
                                    <div>
                                        <asp:Button ID="btn_plus" runat="server" Text="+" OnClick="btn_plus_Click" />
                                        <%-- <asp:Button ID="btn_minus" runat="server" Text="-" onclick="btn_minus_Click" />--%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table border="1" runat="server" id="Table1">
                            <tr>
                                <td align="center" colspan='4' style="text-decoration: underline;">
                                    <b>CENTER FOR PROFESSIONAL DEVELOPMENT</b>
                                </td>
                            </tr>
                            <%--<tr><td align="center"><b>S.No</b></td><td align="center"><b>Activities</b></td><td align="center"><b>Status</b></td><td align="center"><b>Responsibility</b></td></tr>--%>
                        </table>
                        <%-- <asp:PlaceHolder ID="resultHolder" runat="server"></asp:PlaceHolder>--%>
                        <asp:Panel ID="pnlsetup" runat="server" Width="665px" Height="200px" ScrollBars="Both">
                            <asp:GridView ID="grid_tab" AutoGenerateColumns="false" runat="server" Style="margin-left: 5px;
                                margin-bottom: 10px; top: 0px; left: 0px; width: 100%;">
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                                <Columns>
                                    <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                                    <asp:TemplateField HeaderText="Coursename">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtcrsenme" runat="server" Width="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CourseSchedule">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtexmshedle" runat="server" Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ExamShedule">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtexmsch" runat="server" Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Batch">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtbatch" Width="50px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NoofSessions">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtsessions" Width="100px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Days">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtdays" Width="100px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CourseFee">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtcourse" Width="100px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClassTimings">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txttimngs" Width="100px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Target">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txttargt" Width="50px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SMS">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtsms" Width="100px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtemail" Width="100px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TargetAudience">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtaud" Width="100px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
                                    <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click" />
                                    <asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click" />
                                    <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel1" runat="server" Width="665px" Height="200px" ScrollBars="Both">
                            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Style="margin-left: 5px;
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
                                    <asp:TemplateField HeaderText="Course" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("course")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ExamDetails" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("exmdetails")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Responsibility" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("responsibilty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Batch" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("batch")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Session" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("noofsessions")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Days" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("days")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Coursefee" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("coursefee")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClassTimings" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("classtimngs")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Target" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("target")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SMS" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("sms")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("email")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Audit" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("aud")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlReportViwer" runat="server" ScrollBars="Both" Width="710px" Visible="true">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None"
            PrintMode="ActiveX" />
    </asp:Panel>
    </div>
</asp:Content>
