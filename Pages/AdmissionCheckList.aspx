<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AdmissionCheckList.aspx.cs" Inherits="Pages_AdmissionCheckList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    ADMISSION CHECKLIST</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding: 3px 5px;">
                                NAME OF STUDENT
                            </td>
                            <td style="padding: 3px 5px;" colspan="3">
                                <asp:TextBox ID="txtName" runat="server" TabIndex="5" CssClass="textBox11" Width="493px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                DATE
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:CalendarExtender ID="Calendarextender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtDate" PopupButtonID="ImgBCalender">
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txtDate">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding: 3px 5px;">
                                NATIONALITY
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtNationality" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                STUDENT ID
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtStudentId" runat="server" TabIndex="5" CssClass="textBox11" Width="142px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td style="padding: 3px 5px;">
                                PROGRAM
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtProgram" runat="server" TabIndex="5" CssClass="textBox11" Width="142px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                LEVEL
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtLevel" runat="server" TabIndex="5" CssClass="textBox11" Width="142px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td style="padding: 3px 5px;">
                                INTAKE
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtIntake" runat="server" TabIndex="5" CssClass="textBox11" Width="142px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>                            
                            <td style="padding: 3px 5px;">
                                SESSION
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtSession" runat="server" TabIndex="5" CssClass="textBox11" Width="142px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                            <asp:Button ID="btnPrint" runat="server" Text="Print" onclick="btnPrint_Click"   OnClientClick="document.getElementById('form1').target ='_blank';" />
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
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    ADMINISTRATION DEPARTMENT - CHECKLIST</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="1" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding: 3px 5px;" rowspan="2">
                                PLACEMENT TEST RESULT
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:Label ID="lblExamType" runat="server" Text="TOEFL"></asp:Label>
                            </td>
                            <td style="padding: 3px 5px;">
                                SCORE
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtToeflScore" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px" ReadOnly="true" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                MATHS
                            </td>
                            <td style="padding: 3px 5px;">
                                SCORE
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtMathScore" runat="server" TabIndex="5" CssClass="textBox11" Width="142px" ReadOnly="true" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                MATHS CRASH COURSE
                            </td>
                            <td>
                                <asp:RadioButton ID="chkYesMath" runat="server" Text="Yes"  GroupName="I"/>
                                <asp:RadioButton ID="chkNoMath" runat="server" Text="No"  GroupName="I"/>
                                <asp:RadioButton ID="chkNAMath" runat="server" Text="NA"  GroupName="I"  Checked="true" />
                            </td>
                            <td style="padding: 3px 5px;">
                                SCORE
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtScoreMaths" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                AIPC
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:RadioButton ID="rdbAIPC190" runat="server" Text="190 HRS"  GroupName="A"/>
                                <asp:RadioButton ID="rdbAIPC120" runat="server" Text="120 HRS"  GroupName="A"/>
                                <asp:RadioButton ID="rdbAIPCNA" runat="server" Text="NA"  GroupName="A" Checked="true"/>
                            </td>
                            <td style="padding: 3px 5px;">
                                RESULT
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtResultAIPC" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                IELP
                            </td>
                            <td>
                                <asp:RadioButton ID="chkYesIELP" runat="server" Text="Yes"  GroupName="H"/>
                                <asp:RadioButton ID="chkNoIELP" runat="server" Text="No"  GroupName="H" Checked="true"/>
                            </td>
                            <td style="padding: 3px 5px;">
                                RESULT
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtResultIELP" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                FEE WAIVER
                            </td>
                            <td>
                               <asp:Label ID="lblFeewaiver" runat="server" Text=""></asp:Label></td>
                            <td style="padding: 3px 5px;">
                                TYPE
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtFwType" runat="server" TabIndex="5" TextMode="MultiLine" CssClass="textBox11" Width="142px" Height="50px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                FEE WAIVER [PROOF] SUBMISSION
                            </td>
                            <td>
                                <asp:RadioButton ID="chkYesProof" runat="server" Text="Yes"  GroupName="F"/>
                                <asp:RadioButton ID="chkNoProof" runat="server" Text="No"  GroupName="F"/>
                            </td>
                            <td style="padding: 3px 5px;">
                                TYPE
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtProof" runat="server" TabIndex="5" CssClass="textBox11" 
                                    Width="142px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                FEE WAIVER AMOUNT(AED)
                            </td>
                            <td style="padding: 3px 5px;" colspan="3">
                                <asp:TextBox ID="txtFWAmount" runat="server" TabIndex="5" Text="-" 
                                    CssClass="textBox11" Width="431px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                TRANSFER OF CREDIT
                            </td>
                            <td>
                               <asp:Label ID="lblToc" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="padding: 3px 5px;">
                                NO. OF COURSES
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtNoOfCourses" runat="server" TabIndex="5" CssClass="textBox11" AutoPostBack="true"
                                    Width="142px" Text="0" ontextchanged="txtNoOfCourses_TextChanged"></asp:TextBox>
                            
                          
                             <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtNoOfCourses" MinimumValue="1" MaximumValue="30"
                              Type="Integer" EnableClientScript="false" Text="Only Numberic allowed,  value must be from 1 to 30!" runat="server"></asp:RangeValidator>
                            
                            
                            </td>



                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                TRANSFER OF CREDIT [AMOUNT]
                            </td>
                            <td style="padding: 3px 5px;" colspan="3">
                                <asp:TextBox ID="txtTOCAmount" runat="server" TabIndex="5" CssClass="textBox11" 
                                    Width="431px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;" rowspan="1">
                                VISA STATUS
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:Label ID="lblVisaType" runat="server" Text=""></asp:Label>
                            </td>
                        </tr> 
                        <tr>
                            <td style="padding: 3px 5px;">
                                HOSTEL STATUS
                            </td>
                            <td>
                            <asp:Label ID="lblHostelStatus" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="padding: 3px 5px;">
                            </td>
                            <td style="padding: 3px 5px;">
                            </td>
                        </tr>
                         <tr>
                            <td style="padding: 3px 5px;">
                                Admin Remarks
                            </td>
                            <td style="padding: 3px 5px;" colspan="3">
                                <asp:TextBox ID="txtAdminRemarks" runat="server" TabIndex="5" TextMode="MultiLine" Height="45px" CssClass="textBox11" Width="431px"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td style="padding: 3px 5px;">
                                Finance Remarks
                            </td>
                            <td style="padding: 3px 5px;" colspan="3">
                                <asp:TextBox ID="txtFinanceRemarks" runat="server" TabIndex="5" TextMode="MultiLine" Height="45px" CssClass="textBox11" Width="431px"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td style="padding: 3px 5px;">
                                General Remarks
                            </td>
                            <td style="padding: 3px 5px;" colspan="3">
                                <asp:TextBox ID="txtGeneralRemarks" runat="server" TabIndex="5" TextMode="MultiLine" Height="45px" CssClass="textBox11" Width="431px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="padding: 3px 5px;" align="left" colspan="3">
                                <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />
                                <asp:Label ID="lblMesag" runat="server" Text=""></asp:Label>
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
    </div>
</asp:Content>
