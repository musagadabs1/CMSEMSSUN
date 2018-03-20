<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExistingRegistration.aspx.cs" Inherits="Pages_ExistingRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlMainContent" runat="server" Visible="true">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <div class="form_left">
                    <!--this is form left part-->
                    <div class="form_round_border">
                        <!--This is rounded Div-->
                        <div class="form_round_heading_row">
                            <!--this is heading row-->
                            <h2 class="slide_top">
                                Existing Student Registration Info</h2>
                        </div>
                        <!--ended heading row-->
                        <div class="round_form_content">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <asp:Panel ID="pnlStudentReg" runat="server" Visible="true">
                                    <tr>
                                        <td style="text-transform: uppercase;">
                                            <span style="color: Blue">
                                                <asp:Label ID="lblRegisterId" runat="server" ForeColor="Blue" Text="Caller ID"></asp:Label></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLinkId" runat="server" CssClass="textBox1" ForeColor="Blue" OnTextChanged="txtLinkId_TextChanged"
                                                ReadOnly="true" TabIndex="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAttendedBy" runat="server" Text="Registered By" Font-Bold="true"
                                            ForeColor="Blue"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAttendedBy" runat="server" ForeColor="Blue" Font-Bold="true"
                                            ReadOnly="true" Enabled="false" CssClass="textBox1" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" CssClass="" Text="Registration No"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegNo" runat="server" TabIndex="1" CssClass="textBox1" ReadOnly="true"
                                            Width="92px"></asp:TextBox>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCallDate" runat="server" CssClass="" Text="Registration Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCallDate" runat="server" TabIndex="1" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCallDate"
                                            CssClass="" ErrorMessage="*" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 35px;">
                                        <asp:Label ID="lblGender" runat="server" CssClass="" Text="Gender"></asp:Label>
                                    </td>
                                    <td style="width: 65px;">
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="textBox9" TabIndex="1">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                            <asp:ListItem Value="3">Other</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlGender"
                                            CssClass="" ErrorMessage="Gender Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" InitialValue="0" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 35px;">
                                        <asp:Label ID="lblCaption" runat="server" CssClass="" Text="Title"></asp:Label>
                                    </td>
                                    <td style="width: 65px;">
                                        <asp:DropDownList ID="ddlTitle" runat="server" CssClass="textBox9" TabIndex="1">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Mr</asp:ListItem>
                                            <asp:ListItem Value="2">Mrs</asp:ListItem>
                                            <asp:ListItem Value="3">Miss</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlTitle"
                                            CssClass="" ErrorMessage="Title Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFirstName" runat="server" CssClass="" Text="First Name"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName"
                                            CssClass="" ErrorMessage="First Name Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="No special Character For First Name!"
                                            ValidationGroup="Submit" ControlToValidate="txtFirstName" Font-Size="Large" ForeColor="Red"
                                            ValidationExpression="^[A-Za-z .]+$" Display="None"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox1" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Middle Name
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="No special Character For Middle Name!"
                                            ValidationGroup="Submit" ControlToValidate="txtMiddleName" Font-Size="Large"
                                            ForeColor="Red" ValidationExpression="^[A-Za-z .]+$" Display="None"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textBox1" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Last Name
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName"
                                            CssClass="" ErrorMessage="Last Name Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="No special Character For Last Name!"
                                            ValidationGroup="Submit" ControlToValidate="txtLastName" Font-Size="Large" ForeColor="Red"
                                            ValidationExpression="^[A-Za-z .]+$" Display="None"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox1" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%">
                                        <asp:Label ID="lblMobileNo" runat="server" CssClass="" Text="Mobile (971501234567)"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                                            CssClass="" ErrorMessage="Mobile No Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                            ValidChars="-" TargetControlID="txtMobileNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="textBox1" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%">
                                        <asp:Label ID="Label2" runat="server" CssClass="" Text="Phone"></asp:Label>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                            ValidChars="-" TargetControlID="txtPhoneNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="textBox1" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmailID" runat="server" CssClass="" Text="Email ID"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmailID" runat="server" CssClass="textBox1" TabIndex="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmailID"
                                            CssClass="" ErrorMessage="Email Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTypeofStudent" runat="server" CssClass="" Text="International Student"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlInternationalStudent" runat="server" CssClass="textBox9"
                                            TabIndex="1">
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" CssClass="" TabIndex="9" OnClick="btnSave_Click"
                                            Text="Save" ValidationGroup="Submit" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                            ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMesag" runat="server" CssClass="labelMesag" Font-Bold="true" Font-Size="12px"
                                            Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="form_right">
                    <!--this is form right part-->
                    <div class="form_round_border  margin_0px">
                        <!--This is rounded Div-->
                        <div class="form_round_heading_row">
                            <!--this is heading row-->
                            <h2 class="slide_top">
                                Additional Info</h2>
                        </div>
                        <!--ended heading row-->
                        <div class="round_form_content">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 40%">
                                        <asp:Label ID="lblArabicFirstName" runat="server" CssClass="" Text="Arabic First Name"></asp:Label>
                                    </td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtArabicFirstName" runat="server" CssClass="textBox1" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Arabic Middle Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtArabicMiddleName" runat="server" CssClass="textBox1" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Arabic Last Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtArabicLastName" runat="server" CssClass="textBox1" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Date of Birth
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDobDate" runat="server" CssClass="textBox1" Width="46px" MaxLength="2"></asp:TextBox>
                                        <asp:TextBox ID="txtDobMonth" runat="server" CssClass="textBox1" Width="47px" MaxLength="2"></asp:TextBox>
                                        <asp:TextBox ID="txtDobYear" runat="server" CssClass="textBox1" Width="60px" MaxLength="4"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender25" runat="server" Enabled="True"
                                            TargetControlID="txtDobYear" WatermarkText="YYYY">
                                        </cc1:TextBoxWatermarkExtender>
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender26" runat="server" Enabled="True"
                                            TargetControlID="txtDobMonth" WatermarkText="MM">
                                        </cc1:TextBoxWatermarkExtender>
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender27" runat="server" Enabled="True"
                                            TargetControlID="txtDobDate" WatermarkText="DD">
                                        </cc1:TextBoxWatermarkExtender>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtDobMonth">
                                        </cc1:FilteredTextBoxExtender>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtDobDate">
                                        </cc1:FilteredTextBoxExtender>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtDobYear">
                                        </cc1:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDobDate"
                                            CssClass="" ErrorMessage="DOB Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                            ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mother Tongue
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMotherTongue" runat="server" CssClass="textBox1" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNationality" runat="server" CssClass="" Text="Nationality / Country"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlNationality"
                                            CssClass="" ErrorMessage="Please Select Nationality!" Font-Size="Large" ForeColor="Red"
                                            InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlNationality" runat="server" CssClass="textBox9" TabIndex="2">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Proficiency in English
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProficiencyInEnglish" runat="server" CssClass="textBox9"
                                            TabIndex="2">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Excellent</asp:ListItem>
                                            <asp:ListItem Value="2">Average</asp:ListItem>
                                            <asp:ListItem Value="3">Good</asp:ListItem>
                                            <asp:ListItem Value="4">Poor</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Blood Group
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="textBox9" TabIndex="2">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>O-</asp:ListItem>
                                            <asp:ListItem>O+</asp:ListItem>
                                            <asp:ListItem>A-</asp:ListItem>
                                            <asp:ListItem>A+</asp:ListItem>
                                            <asp:ListItem>B-</asp:ListItem>
                                            <asp:ListItem>B+</asp:ListItem>
                                            <asp:ListItem>AB-</asp:ListItem>
                                            <asp:ListItem>AB+</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <div class="cleared">
                            </div>
                        </div>
                        <!--ended content Div-->
                    </div>
                    <!--ended rounded Div-->
                </div>
            </div>
        </div>
    </asp:Panel>
    </div>
</asp:Content>
