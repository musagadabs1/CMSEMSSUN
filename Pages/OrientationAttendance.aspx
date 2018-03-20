<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="OrientationAttendance.aspx.cs" Inherits="Pages_OrientationAttendance" %>

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
        .list-member-block
        {
            width: 713px;
            float: left;
            margin: 2px 0px 4px 0px;
            padding: 0px;
            position: relative;
            border: 1px solid #354A4F;
        }
        .list-member-block table
        {
            width: 100%;
            margin: 0px;
            padding: 0px;
            float: left;
            border-collapse: collapse;
        }
        
        .list-member-block table th
        {
            font-family: verdana;
            font-size: 12px;
            font-weight: normal;
            color: #FFFFFF;
            padding: 3px 0px;
            background-image: url(../Icons/seperator.gif);
            background-repeat: no-repeat;
            background-position: 100% 50%;
            background-color: #43747E;
        }
        
        .list-member-block table td
        {
            font-family: verdana;
            font-size: 12px;
            font-weight: normal;
            color: #333333;
            padding: 5px 0px;
            border-right: 1px solid #CED9EA;
        }
        
        .list-member-block table tr.odd-row
        {
            background-color: #E3E2E3;
        }
        
        .list-member-block table tr.even-row
        {
            background-color: #dde8f4;
        }
        
        .list-member-block table tr.odd-row a
        {
            font-family: verdana;
            font-size: 12px;
            font-weight: normal;
            color: #333333;
        }
        
        .list-member-block table tr.odd-row a:hover
        {
            font-family: verdana;
            font-size: 12px;
            font-weight: normal;
            color: #333333;
            background-color: #a3bdd9;
        }
    </style>
    <script type="text/javascript">
        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlMainContent" runat="server" Visible="true">
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <div class="form-fieldset-wrapper-top">
                    <h2>
                        Filter Student Details
                    </h2>
                </div>
                <div class="form-fieldset-wrapper-mid">
                    <div class="form-fieldset-wrapper-mid-inner">
                        <table class="style1" border="1">
                            <tr>
                                <td style="padding: 3px 5px; width: 150px">
                                    Term
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:DropDownList ID="ddlTerm" runat="server" TabIndex="5" Width="142px" CssClass="textBox9"
                                        AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTerm"
                                        CssClass="" ErrorMessage="Term Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                        Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px; width: 150px">
                                    Degree
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:DropDownList ID="ddlDegree" AutoPostBack="true" runat="server" TabIndex="5"
                                        Width="142px" CssClass="textBox9" OnSelectedIndexChanged="ddlDegree_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDegree"
                                        CssClass="" ErrorMessage="Degree Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px; width: 150px">
                                    Intake
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:CheckBox ID="chkNew" runat="server" Text="New" AutoPostBack="true" OnCheckedChanged="chkNew_CheckedChanged" />
                                    <asp:CheckBox ID="chkPrevious" runat="server" Text="Previous" AutoPostBack="true"
                                        OnCheckedChanged="chkPrevious_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px; width: 150px">
                                    Commencement Calender
                                </td>
                                <td style="padding: 3px 5px; width: 260px;">
                                    <asp:DropDownList ID="ddlCommencementCalender" runat="server" TabIndex="5" Width="142px"
                                        CssClass="textBox9" OnSelectedIndexChanged="ddlDegree_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px; width: 150px">
                                    Attendance Date
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtAttendenceDate" runat="server" TabIndex="5" Width="120px" CssClass="textBox1"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtAttendenceDate" PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txtAttendenceDate">
                                    </cc1:FilteredTextBoxExtender>
                                    <br />
                                    <asp:CheckBox ID="chkIsNeedtoPopulate" runat="server" Text="Copy this date to all students.?" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnLoadStudentsDetails" runat="server" Text="Load" OnClick="btnLoadStudentsDetails_Click" />
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
    <div id="Div1">
        <div class="form-fieldset-wrapper">
            <div class="form-fieldset-wrapper-top">
                <h2>
                    Student Details
                </h2>
            </div>
            <div class="form-fieldset-wrapper-mid">
                <div id="dvStudentDetails" class="list-member-block" style="width: 690px; margin-left: 10px">
                    <asp:GridView ID="gvStudentDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                        DataKeyNames="LinkId" EmptyDataText="There are no records to display." GridLines="Both"
                        CssClass="grid-view" OnRowDeleting="gvStudentDetails_RowDeleting" OnRowCommand="gvStudentDetails_RowCommand">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNO" HeaderStyle-Width="5%">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Code" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:Label ID="LblId" Style="text-align: right;" Visible="false" Text='<%#Eval("Id") %>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="LblDegree" Style="text-align: right;" Text='<%#Eval("DegreeCode") %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LinkID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LblLinkID" runat="server" Text='<%#Eval("LinkID") %>' Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="LblStudID" Text='<%#Eval("Stud_ID") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="LblName" runat="server" Text='<%#Eval("student_name") %>' Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shift" HeaderStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="LblShift" Style="text-align: right;" Text='<%#Eval("shift_desc") %>'
                                        runat="server"></asp:Label>
                                    <asp:Label ID="LblShiftID" Style="text-align: right;" Text='<%#Eval("Shift_ID") %>'
                                        Visible="false" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ATT Date" HeaderStyle-Width="30%">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtAttendenceDate" Text='<%#Eval("AttendenceDate") %>' runat="server"
                                        Width="75%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender6" TargetControlID="TxtAttendenceDate"
                                        Format="dd/MM/yyyy" runat="server">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="TxtAttendenceDate">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="5%">
                                <HeaderTemplate>
                                    Is Attended<br />
                                    <asp:CheckBox ID="checkAll" runat="server" Text="" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkAttendented" Checked='<%#Convert.ToBoolean(Eval("IsAttendented")) %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="Action" HeaderStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="javascript: return confirm('Are you sure you want to delete?')"
                                        CommandArgument='<%#Eval("Input_TermId")+ ";" +Eval("Input_DegreeType")+ ";" +Eval("Id") +";" +Eval("Shift_ID")%>'
                                        CausesValidation="false" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:HiddenField ID="hdnOperation" runat="server" />
                                <asp:Button ID="BtnSave" runat="server" Visible="false" Text="Save" OnClick="BtnSave_Click" />&nbsp;
                                <asp:Button ID="BtnCancel" runat="server" Visible="false" Text="Cancel" OnClick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="form-fieldset-wrapper-bottom">
        </div>
    </div>
    <div style="margin-top: 50px">
        &nbsp;
    </div>
    <div id="Div2">
        <div class="form-fieldset-wrapper">
            <div class="form-fieldset-wrapper-top">
                <h2>
                    Orientation Attendance List
                </h2>
            </div>
            <div class="form-fieldset-wrapper-mid">
                <div id="Div3" class="list-member-block" style="width: 690px; margin-left: 10px">
                    <asp:GridView ID="gvOrientationAttendanceList" runat="server" AutoGenerateColumns="false"
                        Width="100%" DataKeyNames="Input_TermId,Input_DegreeType" EmptyDataText="There are no records to display."
                        GridLines="Both" CssClass="grid-view" OnRowCommand="gvOrientationAttendanceList_RowCommand"
                        OnRowEditing="gvOrientationAttendanceList_RowEditing">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNO" HeaderStyle-Width="5%">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Term" HeaderStyle-Width="25%">
                                <ItemTemplate>
                                    <asp:Label ID="LblTerm" Style="text-align: right;" Text='<%#Eval("Term") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Degree Type" HeaderStyle-Width="25%">
                                <ItemTemplate>
                                    <asp:Label ID="LblDegreeType" Text='<%#Eval("DegreeType_Desc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" OnClientClick="javascript: return confirm('Are you sure you want to edit?')"
                                        CommandArgument='<%#Eval("Input_TermId")+ ";" +Eval("Input_DegreeType")+ ";" +Eval("Input_Intake")%>'
                                        CausesValidation="false" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="form-fieldset-wrapper-bottom">
        </div>
    </div>
</asp:Content>
