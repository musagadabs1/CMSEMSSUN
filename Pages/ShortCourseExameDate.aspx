<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ShortCourseExameDate.aspx.cs" Inherits="Pages_ShortCourseExameDate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnAdd">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Entrance Date Setup</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 180px; padding: 3px 5px;">
                                    Exam Type
                                </td>
                                <td style="width: 180px" colspan="3">
                                  <%--  <asp:RadioButton Text="ILETS" runat="server" ID="rbtIlets" GroupName="chk1" 
                                        Font-Bold="True" AutoPostBack="True" 
                                        oncheckedchanged="rbtIlets_CheckedChanged" />
                                    <asp:RadioButton Text="TOFEL" runat="server" ID="rbtTofel" GroupName="chk1" 
                                        Font-Bold="True" AutoPostBack="True" 
                                        oncheckedchanged="rbtTofel_CheckedChanged" />
                                    <asp:RadioButton Text="Chalange Exam" runat="server" ID="rdbChalange" 
                                        GroupName="chk1" Font-Bold="True" AutoPostBack="True" 
                                        oncheckedchanged="rdbChalange_CheckedChanged" />
                                    <asp:RadioButton Text="Personal InterView" runat="server" ID="rdbPersonal" 
                                        GroupName="chk1" Font-Bold="True" AutoPostBack="True" 
                                        oncheckedchanged="rdbPersonal_CheckedChanged" />                                        
                                    <asp:RadioButton Text="TOEFL ORIENTATION" runat="server" ID="rdbToeflOrt" 
                                        GroupName="chk1" Font-Bold="True"/>                                        
                                    <asp:RadioButton Text="IELTS ORIENTATION" runat="server" ID="rdbIELTSOrt" 
                                        GroupName="chk1" Font-Bold="True" />--%>

                                       <asp:DropDownList ID="drpentrancetesttype" runat="server" CssClass="textBox14" OnSelectedIndexChanged="drpentrancetesttype_SelectedIndexChanged"
                                                                        AutoPostBack="true">
                                        
                                        </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txthdn_Field" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Date
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtExamDate" runat="server" Text="" CssClass="Exam Date"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txt_JoinDateCalendarExtender" Format="dd/MM/yyyy" CssClass="MyCalendar" TargetControlID="txtExamDate"
                                        runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:CheckBox Text="Active" runat="server" ID="chk" OnCheckedChanged="changStatus" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Exam Time From:
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtEngExFrom" runat="server" CssClass="Exam Date" Text="" MaxLength="4" Width="60px"></asp:TextBox>
                                </td>
                                <td style="padding: 3px 5px;">
                                    To
                                    <asp:TextBox ID="txtEngExTo0" runat="server" CssClass="Exam Date" Text="" MaxLength="4" Width="60px"></asp:TextBox>
                                </td>
                                <td style="padding: 3px 5px;">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Maths Exam Time From:
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtMathExFrom" runat="server" CssClass="Exam Date" Text="" MaxLength="4" Width="60px"></asp:TextBox>
                                </td>
                                <td style="padding: 3px 5px;">
                                    To
                                     <asp:TextBox ID="txtMathExTo" runat="server" CssClass="Exam Date" Text="" MaxLength="4" Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                    <td colspan="3">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn" OnClick="btnAdd_Click1" Text="Add"
                                            ValidationGroup="Add" />
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn" OnClick="btnUpdate_Click1"
                                            Text="Update" ValidationGroup="Update" />
                                   
                                    <asp:Label ID="lblMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!--form fieldset wrapper mid inner ended-->
                </div>
                <!--Ended Div of form fieldset wrapper middle part of left and right border-->
                <div class="form-fieldset-wrapper-bottom">
                </div>
                <!--Div started for the form fieldset wrapper bottom founded-->
            </div>
            <!--ended Div of Wrapping Form Fields Set-->
        </div>
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Entrance Date List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--start list member blocks-->
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="list-member-block" style="width: 693px">
                                <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" EmptyDataText="There are no records to display."
                                    OnRowDataBound="gvStudentList_RowDataBound" OnRowCommand="gvStudentList_RowCommand">
                                    <%-- DataKeyNames="Id" 
                                            GridLines="Both" CssClass="grid-view" OnRowCommand="gvStudentList_RowCommand">--%>
                                    <FooterStyle CssClass="GridFooter" />
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.N.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSN" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblName" runat="server" Text='<%#Bind("EntranceDate") %>' CommandArgument='<%#Bind("EntranceID") %>'
                                                    CommandName="Details"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Time">
                                            <ItemTemplate>
                                                <asp:Label Text='<%#Bind("EngTime") %>' ID="lnkEngTime" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Maths Exam Time">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMathsTime" runat="server" Text='<%#Bind("MathsTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%#Bind("Type") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIsActive" runat="server" Text='<%#Bind("IsActive") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                    <SelectedRowStyle CssClass="GridRowOver" />
                                    <EditRowStyle />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
        </div>
        <!--Ended Div of form fieldset wrapper middle part of left and right border-->
        <div class="form-fieldset-wrapper-bottom">
        </div>
        <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
    </asp:Panel>
</asp:Content>
