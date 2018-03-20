<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EntranceResult.aspx.cs" Inherits="Pages_EntranceResult"  MaintainScrollPositionOnPostback="true"%>

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
                    Entrance Update</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding: 3px 5px;">
                                Registration No
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtRegistrationNo" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRegistrationNo"
                                    CssClass="" ErrorMessage="Registration No Required!" Font-Size="Large" ForeColor="Red"
                                    SetFocusOnError="true" Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </td>
                            <td style="padding: 3px 5px; width: 120px;">
                                Test Type
                            </td>
                            <td style="padding: 3px 5px; width: 260px;">
                                <asp:DropDownList ID="ddlTestType" runat="server" TabIndex="5" Width="142px" 
                                    CssClass="textBox9" AutoPostBack="True" 
                                    onselectedindexchanged="ddlTestType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTestType"
                                    CssClass="" ErrorMessage="Test Type Required!" Font-Size="Large" ForeColor="Red"
                                    SetFocusOnError="true" Display="None" ValidationGroup="Submit" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <asp:Panel ID="pnlHide" runat="server">
                        <tr>
                            <td style="padding: 3px 5px;">
                               Section1 (Listening)
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtListening" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="." TargetControlID="txtListening">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding: 3px 5px;">
                                Section2 (Reading)
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtReading" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="." TargetControlID="txtReading">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                Section3 (Writing)
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtWriting" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="." TargetControlID="txtWriting">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding: 3px 5px;">
                                Section4 (Speaking)
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtSpeaking" runat="server" TabIndex="5" CssClass="textBox1"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="." TargetControlID="txtSpeaking">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        </asp:Panel>
                        <tr>
                            <td style="padding: 3px 5px;">
                                Marks
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtMarks" runat="server" TabIndex="5" CssClass="textBox1" 
                                    AutoPostBack="True" ontextchanged="txtMarks_TextChanged"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="." TargetControlID="txtMarks">
                                </cc1:FilteredTextBoxExtender>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMarks"
                                    CssClass="" ErrorMessage="Marks Required!" Font-Size="Large" ForeColor="Red"
                                    SetFocusOnError="true" Display="None" ValidationGroup="Submit" ></asp:RequiredFieldValidator>
                            </td>
                            <td style="padding: 3px 5px;">
                                Status
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlStatus" runat="server" TabIndex="5" Width="142px" CssClass="textBox9">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStatus"
                                    CssClass="" ErrorMessage="Status Required!" Font-Size="Large" ForeColor="Red"
                                    SetFocusOnError="true" Display="None" ValidationGroup="Submit" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                Foundation
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlFoundation" runat="server" TabIndex="5" Width="142px" CssClass="textBox9">
                                </asp:DropDownList>
                            </td>
                            <td style="padding: 3px 5px;">
                                Remarks
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtRemarks" runat="server" TabIndex="5" CssClass="textBox1"  TextMode = "MultiLine" Height="148px" Width="316px"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="padding: 3px 5px;">
                                Re Test
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:CheckBox ID="chkRetest" runat="server" TabIndex="5" Checked="false" />
                            </td>
                            <td style="padding: 3px 5px;">
                                Exam Date
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlExamDate" runat="server" CssClass="textBox15" Width="78px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlExamTime" runat="server" CssClass="textBox15" Width="62px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="3" style="padding: 3px 5px;">
                                <asp:Button ID="btnSave" runat="server" CssClass="" OnClick="btnSave_Click" Text="Save"
                                    ValidationGroup="Submit" />
                                <asp:Button ID="btnUpdate" runat="server" CssClass="" OnClick="btnUpdate_Click" Text="Update"
                                    ValidationGroup="Submit" Visible="false" />
                                <asp:Button ID="btnSend" runat="server" CssClass="" OnClick="btnSendSMS_Click" Text="Send SMS/Email"
                                     />
                                <asp:Button ID="btnMailToMkt" runat="server" CssClass="" OnClick="btnMailToMkt_Click" Text="Send Email to MKT"
                                     />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                    ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                                <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"
                                    CssClass="labelMesag"></asp:Label>
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
                    Exam Result Details</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
    <div id="list-member-block" style="width: 693px">
        <asp:GridView ID="gvEntranceResult" runat="server" AutoGenerateColumns="false" DataKeyNames="Testid"
            EmptyDataText="There are no records to display." GridLines="Both" CssClass="grid-view"
            OnRowCommand="gvEntranceResult_RowCommand" OnRowDataBound="gvEntranceResult_RowDataBound">
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField HeaderText="Test Type">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkTestType" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Testid") %>'
                            Text='<%#Bind("TestType") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Listening">
                    <ItemTemplate>
                        <asp:Label ID="lblListening" runat="server" Text='<%#Bind("Listening") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reading">
                    <ItemTemplate>
                        <asp:Label ID="lblReading" runat="server" Text='<%# Bind("Reading") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Speaking">
                    <ItemTemplate>
                        <asp:Label ID="lblSpeaking" runat="server" Text='<%# Bind("Speaking") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Writing">
                    <ItemTemplate>
                        <asp:Label ID="lblWriting" runat="server" Text='<%# Bind("Writing") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marks">
                    <ItemTemplate>
                        <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblExamStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
                         <asp:Panel ID="pnlToefl" runat="server" Visible="false">
                      <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    English Exam Details</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                                <asp:GridView ID="GvToefl" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                    EmptyDataText="There are no records to display." 
                                    GridLines="Both" CssClass="grid-view" onrowcommand="GvToefl_RowCommand" 
                                    onrowdatabound="GvToefl_RowDataBound" >
                                    <FooterStyle CssClass="GridFooter" />
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                            <asp:Label ID="lblOrganization1" runat="server" Text='<%#Bind("Id") %>'></asp:Label>                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TOEFL YES/NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExamType" runat="server" Text='<%#Bind("ExamType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TOEFL/IELTS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization" runat="server" Text='<%#Bind("TestType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("ExamDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Time">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobType" runat="server" Text='<%#Bind("ExamTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Passed On">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobSector1" runat="server" Text='<%# Bind("ExamPassedOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status Of Exam">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobSector2" runat="server" Text='<%# Bind("StatusOfExam") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                <asp:TemplateField HeaderText="Download" Visible="true">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownLoad" runat="server" CommandArgument='<%#Bind("FileName") %>' CommandName="DownLoad"
                            Text="Download" OnClientClick="document.getElementById('form1').target ='_blank';"></asp:LinkButton>
                        <asp:HiddenField ID="hdFNo" runat="server" Value='<%#Bind("FileName") %>' />
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
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
        <!--ended Div of Wrapping Form Fields Set-->
    </div>
                         </asp:Panel>
                         
                         <asp:Panel ID="pnlMath" runat="server" Visible="false">
                         
                          <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Math Exam Details</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">      
                 <asp:GridView ID="gvMath" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                    EmptyDataText="There are no records to display." 
                                    GridLines="Both" CssClass="grid-view" 
                        onrowcommand="gvMath_RowCommand" onrowdatabound="gvMath_RowDataBound" >
                                    <FooterStyle CssClass="GridFooter" />
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>                                                
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Having SAT Score">
                                            <ItemTemplate>                                         
                                                <asp:Label ID="lblOrganization2as" runat="server" Text='<%#Bind("ExamType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization2" runat="server" Text='<%#Bind("ExamDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Time">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobType3" runat="server" Text='<%#Bind("ExamTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Math Mark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization" runat="server" Text='<%#Bind("MathMark") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status of Exam">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobType" runat="server" Text='<%#Bind("StatusOfExamMath") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Passed On">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobSector" runat="server" Text='<%# Bind("ExamPassedOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                <asp:TemplateField HeaderText="Download" Visible="true">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownLoad" runat="server" CommandArgument='<%#Bind("FileName") %>' CommandName="DownLoad"
                            Text="Download" OnClientClick="document.getElementById('form1').target ='_blank';"></asp:LinkButton>
                        <asp:HiddenField ID="hdFNo" runat="server" Value='<%#Bind("FileName") %>' />
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
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
        <!--ended Div of Wrapping Form Fields Set-->
    </div>
    </asp:Panel>
             <asp:Panel ID="pnlChallengeExam" runat="server" Visible="false">
                      <div id="Div1">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Challenge Exam Details</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                                <asp:GridView ID="gdvChallengeExam" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                    EmptyDataText="There are no records to display." 
                                    GridLines="Both" CssClass="grid-view" >
                                    <FooterStyle CssClass="GridFooter" />
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                     
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LinkID"  Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLinkID" runat="server" Text='<%#Eval("LinkID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                              <asp:TemplateField HeaderText="Present">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkPresent" runat="server"  Checked='<%# Eval("Present").ToString().Equals("true",StringComparison.CurrentCultureIgnoreCase) %>' OnCheckedChanged = "chkPresent_CheckedChanged" AutoPostBack = "true" /> 
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="Marks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMarks" runat="server" Text='<%#Eval("Marks") %>'></asp:TextBox>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtMarks" runat="server" ErrorMessage="Only Numbers allowed"  ForeColor="Red" ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="Grade">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtGrade" runat="server" Text='<%#Eval("Grade") %>'></asp:TextBox>
                                                &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
                                                &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                         <asp:TemplateField HeaderText="ExamDate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtExamDate" runat="server" Text='<%#Eval("ExamDate") %>'></asp:TextBox>
                                                 &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
                                           &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
                                         <cc1:CalendarExtender ID="CalenderExtender1" runat="server"   TargetControlID="txtExamDate" Format="MM/dd/yyyy">
                                         
                                </cc1:CalendarExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                         <asp:TemplateField HeaderText="ChallengeId" Visible="false">
                                            <ItemTemplate>
                                            <asp:Label ID="lblChallengeId" runat="server" Text='<%#Eval("ChallengeId") %>'></asp:Label>                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
    
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                    <SelectedRowStyle CssClass="GridRowOver" />
                                    <EditRowStyle />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                </asp:GridView>
                                  <asp:Label ID="lbl2" runat="server" CssClass="labelMesag" Font-Bold="true" 
                                    Font-Size="12px" Text="Remarks"></asp:Label>  
                                   <asp:TextBox ID="txtRemarksCh" runat="server" Height="123px" 
                                    TextMode="Multiline" Width="680px"></asp:TextBox>
                                 <asp:Button ID="btnSaveChallenge" runat="server" CssClass="" OnClick="btnSaveChallenge_Click" Text="Save Challenge Exam Results"
                                    />
                                       <asp:Label ID="Label1" runat="server" CssClass="labelMesag" Font-Bold="true" 
                                    Font-Size="12px" Text=""></asp:Label>
                                </div> 
                               
            </div> 
            <div class="form-fieldset-wrapper-bottom">
            </div> 
        </div> 
    </div>
                         </asp:Panel>
    </div>
</asp:Content>
