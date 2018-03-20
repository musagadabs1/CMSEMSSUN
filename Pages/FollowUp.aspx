<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForCallManagement.master"
    AutoEventWireup="true" CodeFile="FollowUp.aspx.cs" Inherits="Pages_FollowUp" %>
     <%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function shopPopup() {
            var modalPopupExtender = $find('ModalPopupExtenderBehavior');
            modalPopupExtender.show();
        }
        function hidePopup() {
            var modalPopupExtender = $find('ModalPopupExtenderBehavior');
            modalPopupExtender.hide();
        }
    </script>

      <script type = "text/javascript">
          function ConfirmP() {
              var confirm_value = document.createElement("INPUT");
              confirm_value.type = "hidden";
              confirm_value.name = "confirm_value";
              if (confirm("Dou you want to send SMS & Email ? Click Ok to send and Cancel to update the records")) {
                  confirm_value.value = "Yes";
              } else {
                  confirm_value.value = "No";
              }
              document.forms[0].appendChild(confirm_value);
          }
    </script>



    <style type="text/css">
        #main-frame
        {
            width: 500px;
            padding: 10px;
            margin: 0px auto;
            background-color: #E0ECED;
            border: 1PX solid #9BAEAF;
            z-index: 50000;
        }
        
        #main-frame h1
        {
            color: #374E51;
            margin: 0px 0px 10px 0px;
            font-family: Tahoma;
            font-size: 14px;
            letter-spacing: 1px;
        }        
        
        #main-frame p
        {
            margin: 0px 0px 10px 0px;
            padding: 0px;
            font-family: Tahoma;
            font-size: 12px;
            font-weight: normal;
            color: #374E51;
        }
        
        #main-frame label
        {
            float: left;
            margin: 0px 5px 0px 0px;
            width: 60px;
            padding: 3px 0px 2px 0px;
        }
        
        #main-frame input[type=text]
        {
            width: 170px;
            height: 14px;
            font-family: Tahoma;
            font-size: 11px;
            color: #374E51;
        }
        
        .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        
        #main-frame1
        {
            width: 300px;
            padding: 10px;
            margin: 0px auto;
            background-color: #E0ECED;
            border: 1PX solid #9BAEAF;
            z-index: 50000;
        }
        #main-frame1 h1
        {
            color: #374E51;
            margin: 0px 0px 10px 0px;
            font-family: Tahoma;
            font-size: 14px;
            letter-spacing: 1px;
        }
        
        
        #main-frame1 p
        {
            margin: 0px 0px 10px 0px;
            padding: 0px;
            font-family: Tahoma;
            font-size: 11px;
            font-weight: normal;
            color: #374E51;
        }
        
        #main-frame1 label
        {
            float: left;
            margin: 0px 5px 0px 0px;
            width: 80px;
            padding: 3px 0px 2px 0px;
        }
        
        #main-frame1 input[type=text]
        {
            width: 170px;
            height: 14px;
            font-family: Tahoma;
            font-size: 11px;
            color: #374E51;
        }
        .btnclose
        {
            background-image: url(../Icons/lightbox-btn-close.gif);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnUpdate">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Follow Up</h2>
                </div>
                <div> <button onclick="javascript:window.history.back();return false;" > Go Back </button></div>
               
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 100px">
                                    Date
                                </td>
                                <td style="width: 287px">
                                    <asp:TextBox ID="txtCallDate" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCallDate"
                                        CssClass="" ErrorMessage="Date Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                        Display="None" ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                
                                <asp:Label ID="lblregno" runat="server" Text=""></asp:Label>
                                </td>
                                <asp:Panel ID="pnlNigeria1" runat="server" Visible="false">
                                <td style="width: 180px">
                                    Provisional Admission Letter Issued
                                </td>
                                <td>
                                     <asp:CheckBox ID="chkProvCerticate" runat="server"/>
                                </td>                                
                                </asp:Panel>   
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                </td>  
                                <asp:Panel ID="pnlNigeria2" runat="server" Visible="false">
                                <td>
                                    Initial Admission Fee Paid
                                </td>
                                <td>
                                   <asp:CheckBox ID="chkPaymentMode" runat="server"/>
                                </td>
                                </asp:Panel>                              
                            </tr>
                            <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="" Text="Forwarded To"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlForwardedTo1" runat="server" CssClass="textBox9" Width="143px" TabIndex="7" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStudentStatus" runat="server" CssClass="" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStudentStatus" runat="server" TabIndex="5" 
                                        CssClass="textBox9" AutoPostBack="True"  AppendDataBoundItems="true"
                                        onselectedindexchanged="ddlStudentStatus_SelectedIndexChanged" Width="143px">
                                          <asp:ListItem Value="2">Caller</asp:ListItem>
                                     <%--   <asp:ListItem Value="V">Visitor</asp:ListItem>
                                        <asp:ListItem Value="C">Caller</asp:ListItem>
                                        <asp:ListItem Value="F">Follow Up</asp:ListItem>
                                        <asp:ListItem Value="R">Enrolled</asp:ListItem>
                                        <asp:ListItem Value="NQ">Not Qualified</asp:ListItem>
                                        <asp:ListItem Value="Cl">Not Interested (Closed)</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlStudentStatus"
                                        CssClass="" ErrorMessage="Status Required!" Font-Size="Large" ForeColor="Red"
                                        SetFocusOnError="true" Display="None" ValidationGroup="Submit1" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlnq" runat="server" Visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="LblNQ" runat="server" CssClass="" Text="Not Interested -  Reason"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DrpNQ" runat="server" TabIndex="5" 
                                        CssClass="textBox9" ></asp:DropDownList>


</td>
</tr>
</asp:Panel>
                            <tr>
                                <td>
                                    Send SMS
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSms" runat="server" Enabled="true" Checked="true" AutoPostBack="true"  OnCheckedChanged="chksms_changed" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Send Email
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkEmail" runat="server" Enabled="true" Checked="true"  AutoPostBack="true" OnCheckedChanged="chkEmail_changed"/>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    Send SMS (Follow up No reply)
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSms1" runat="server" Enabled="true" Checked="false" AutoPostBack="true" OnCheckedChanged="chksms1_changed" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Send Email (Follow up No reply))
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkEmail1" runat="server" Enabled="true" Checked="false" AutoPostBack="true" OnCheckedChanged="chkEmail1_changed" />
                                </td>
                            </tr>



                             <asp:Panel ID="pnlfollowup" Visible="false" runat="server">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label5" runat="server" CssClass="" Text="Next Followupdate"></asp:Label>
                                </td>
                               <td colspan="3" style="width: 273px; height: 3px; text-align: left">
                    <asp:TextBox ID="txtFromDate" runat="server" ReadOnly="True" CssClass="NewWebcontentswos"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="From Date Required" Text="*" ValidationGroup="ContactUs" ControlToValidate="txtFromDate"></asp:RequiredFieldValidator>
     <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtFromDate" AutoPostBack="True"  Format="d m yyyy"   />
                </td>
                            </tr>
                            
                            </asp:Panel>
                            
                             <asp:Panel ID="pnlvisit" Visible="false" runat="server">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label7" runat="server" CssClass="" Text="Next Visitingdate"></asp:Label>
                                </td>
                               <td colspan="3" style="width: 273px; height: 3px; text-align: left">
                    <asp:TextBox ID="txtVisitDate" runat="server" ReadOnly="True" CssClass="NewWebcontentswos"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Visitng Date Required" Text="*" ValidationGroup="ContactUs" ControlToValidate="txtVisitDate"></asp:RequiredFieldValidator>
     <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txtVisitDate" AutoPostBack="True"  Format="d m yyyy"   />
                </td>
                            </tr>
                            
                            </asp:Panel>


                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblRemarks" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBoxbigA" Height="120px"
                                        TabIndex="7" TextMode="MultiLine" Width="512">                                               
                                    </asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass=""   OnClick="btnUpdate_Click" Text="Update FollowUps"   OnClientClick = "ConfirmP()"  
                                        ValidationGroup="Submit1" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                        ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red"  />
                                    <input id="Button1" type="button" value="View Details Only"  onclick="shopPopup();"  />
                                    <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"
                                        CssClass="labelMesag"></asp:Label>
                                         <asp:Button ID="btneditdetails" runat="server" CssClass=""   OnClick="btneditdetails_Click" Text="Update Register Call"  
                                        ValidationGroup="Submit1" />
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
    </asp:Panel>
    <div id="all-form-wrap">
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Follow Up List</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner">
                    <!--start list member blocks-->
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server">
                                <div id="list-member-block" style="width: 693px">
                                    <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                        EmptyDataText="There are no records to display." OnRowDataBound="gvStudentList_RowDataBound"
                                        GridLines="Both" CssClass="grid-view" OnRowCommand="gvStudentList_RowCommand">
                                        <FooterStyle CssClass="GridFooter" />
                                        <RowStyle CssClass="GridItem" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.N.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblType" runat="server" Text='<%#Bind("DegreeCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Form Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentFormStatus" runat="server" Text='<%# Bind("FormStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentStatus" runat="server" Text='<%# Bind("CallerStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Form Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFormStatus" runat="server" Text='<%# Bind("FormStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Entry Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEntryDate" runat="server" Text='<%# Bind("CallDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Followup By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRegisteredBy" runat="server" Text='<%# Bind("AttendedBy") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Total FollowUp">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalFollow" runat="server" Text='<%# Bind("TotalFollowUp") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <!--form fieldset wrapper mid inner ended-->
        </div>
        <!--Ended Div of form fieldset wrapper middle part of left and right border-->
        <div class="form-fieldset-wrapper-bottom">
        </div>
        <!--Div started for the form fieldset wrapper bottom founded-->
    </div>
    <asp:Panel ID="pnlSearch" runat="server" Visible="true">
        <div id="Div1" style="background-color: #E3E2E3 !important; padding-left: 7px;
            padding-top: 7px;">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <div class="form_left">
                    <!--this is form left part-->
                    <div class="form_round_border">
                        <!--This is rounded Div-->
                        <div class="form_round_heading_row">
                            <!--this is heading row-->
                            <h2 class="slide_top">
                                New Caller's Info</h2>
                        </div>
                        <!--ended heading row-->
                        <div class="round_form_content">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <asp:Panel ID="pnlStudentReg" runat="server" Visible="true">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRegisterId" runat="server" CssClass="" Text="Caller ID"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLinkId" runat="server" CssClass="textBox1" OnTextChanged="txtLinkId_TextChanged"
                                                ReadOnly="true" TabIndex="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAttendedBy" runat="server" CssClass="" Text="Call Attended By"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAttendedBy" runat="server" CssClass="textBox1" TabIndex="7" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCallDate" runat="server" CssClass="" Text="Call Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCallPrevDate" runat="server" TabIndex="5" CssClass="textBox1"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 35%">
                                        <asp:Label ID="lblCallerCategory" runat="server" CssClass="" Text="Caller Category"></asp:Label>
                                    </td>
                                    <td style="width: 65%">
                                        <asp:DropDownList ID="ddlCallerCategory" runat="server" TabIndex="5" CssClass="textBox9" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%">
                                        <asp:Label ID="Label1" runat="server" CssClass="" Text="Caller Status"></asp:Label>
                                    </td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlPrevStudentStatus" runat="server" TabIndex="5" 
                                            CssClass="textBox9" Enabled="true" >
                                           <%--  AutoPostBack="True" OnSelectedIndexChanged="ddlPrevStudentStatus_SelectedIndexChanged"--%>
                                           
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblProspectStatus" runat="server" CssClass="" Text="Prospect Status"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlProspectSstatus" runat="server" TabIndex="6" CssClass="textBox9" Enabled="true">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Serious</asp:ListItem>
                                                <asp:ListItem Value="2">Non Serious</asp:ListItem>
                                                <asp:ListItem Value="3">Not Sure</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                              

                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="" Text="Forwarded Type"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:RadioButtonList ID="rdotype" runat="server" RepeatDirection="Horizontal" 
                                            AutoPostBack="true" Enabled="false" 
                                            onselectedindexchanged="rdotype_SelectedIndexChanged">
                                         
                                      <asp:ListItem Text="MKT" Value="MKT" Selected="True">
                                      </asp:ListItem>
                                         <asp:ListItem Text="FAC" Value="FAC">
                                      </asp:ListItem>
                                        <asp:ListItem Text="STF" Value="STF">
                                      </asp:ListItem>
                                       
                                       </asp:RadioButtonList>
                                    </td>
                                </tr>



                                <tr>
                                    <td>
                                        <asp:Label ID="lblForwardedTo" runat="server" CssClass="" Text="Forwarded To"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="textBox9" TabIndex="7">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblReferredBy" runat="server" CssClass="" Text="Referred By/Enquiry For"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlReferredBy" runat="server" CssClass="textBox9" TabIndex="7">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Self</asp:ListItem>
                                            <asp:ListItem Value="2">Friend</asp:ListItem>
                                            <asp:ListItem Value="3">Relatives</asp:ListItem>
                                            <asp:ListItem Value="4">Cousin</asp:ListItem>
                                            <asp:ListItem Value="5">Others</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 35px;">
                                        <asp:Label ID="lblCaption" runat="server" CssClass="" Text="Title"></asp:Label>
                                    </td>
                                    <td style="width: 65px;">
                                        <asp:DropDownList ID="ddlTitle" runat="server" CssClass="textBox9" TabIndex="7">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Mr</asp:ListItem>
                                            <asp:ListItem Value="2">Mrs</asp:ListItem>
                                            <asp:ListItem Value="3">Miss</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFirstName" runat="server" CssClass="" Text="First Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Middle Name
                                        </td>
                                    <td>
                                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Last Name
                                        </td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%">
                                        <asp:Label ID="lblMobileNo" runat="server" CssClass="" Text="Mobile"></asp:Label>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                            ValidChars="-" TargetControlID="txtMobileNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%">
                                        <asp:Label ID="Label2" runat="server" CssClass="" Text="Phone"></asp:Label>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                            ValidChars="-" TargetControlID="txtTelephone">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmailID" runat="server" CssClass="" Text="Email ID"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmailID" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
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
                                <asp:Panel ID="pnlForVendor2" runat="server" Visible="false">
                                    <tr>
                                        <td style="width: 40%">
                                            Company Name
                                        </td>
                                        <td style="width: 60%">
                                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Designation
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Religion
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlReligion" runat="server" CssClass="textBox9" TabIndex="8">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfReligion" runat="server" ControlToValidate="ddlReligion"
                                                CssClass="" ErrorMessage="Please Select Religion!" Font-Size="Large" ForeColor="Red"
                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNationality" runat="server" CssClass="" Text="Nationality / Country"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlNationality" runat="server" CssClass="textBox9" TabIndex="8">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlForVendor4" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            Industry
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIndustry" runat="server" CssClass="textBox9" TabIndex="8">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Advertising</asp:ListItem>
                                                <asp:ListItem Value="2">Airlines</asp:ListItem>
                                                <asp:ListItem Value="3">Appliance and Tools</asp:ListItem>
                                                <asp:ListItem Value="4">Audio and Video Equipment</asp:ListItem>
                                                <asp:ListItem Value="5">Auto and Truck Manufacturers</asp:ListItem>
                                                <asp:ListItem Value="6">Beverages</asp:ListItem>
                                                <asp:ListItem Value="7">Biotechnology and Drugs</asp:ListItem>
                                                <asp:ListItem Value="8">Buisness Services</asp:ListItem>
                                                <asp:ListItem Value="9">Commercial Banks</asp:ListItem>
                                                <asp:ListItem Value="10">Communications Equipment</asp:ListItem>
                                                <asp:ListItem Value="11">Computer Peripherals</asp:ListItem>
                                                <asp:ListItem Value="12">Electric Utilities</asp:ListItem>
                                                <asp:ListItem Value="13">Manufacturing</asp:ListItem>
                                                <asp:ListItem Value="14">Software</asp:ListItem>
                                                <asp:ListItem Value="15">Personal Services</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Website
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fax
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFax" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            PO Box / Zip
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPoBox" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            City
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="textBox1" TabIndex="8"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlForVendor1" runat="server">
                                    <tr>
                                        <td style="width: 40%">
                                            <asp:Label ID="lblDegreeTypeId" runat="server" CssClass="" Text="Degree Type"></asp:Label>
                                        </td>
                                        <td style="width: 60%">
                                            <asp:DropDownList ID="ddlDegreeType" runat="server" CssClass="textBox9" TabIndex="8"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlDegreeType_SelectedIndexChanged">
                                                                                           </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCourseType" runat="server" CssClass="" Text="Course Type"></asp:Label>
                                        </td>
                                        <td>
                                             <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="textBox9" TabIndex="8">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblArabNonArab" runat="server" CssClass="" Text="Arab/Non Arab"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlArabNonArab" runat="server" CssClass="textBox9" TabIndex="8">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Arab</asp:ListItem>
                                                <asp:ListItem Value="2">Non Arab</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCurrentlyEmployee" runat="server" CssClass="" Text="Currently Employee"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCurrentlyEmployee" runat="server" CssClass="textBox9" TabIndex="8">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            School / University
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSchool" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                    
                                            <asp:Label ID="lblMediaSource" runat="server" CssClass="" Text="Media Source"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lbMediaSource" runat="server" CssClass="listboxMedisSource" TabIndex="8"
                                                SelectionMode="Multiple" Height="64px"></asp:ListBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:Label ID="lblEvents" runat="server" CssClass="" Text="Events"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlExhibition" runat="server" CssClass="textBox9" TabIndex="8">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            TOC
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkTOC" runat="server" TabIndex="8" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Admission Applicable To
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="textBox9" TabIndex="2">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Grade
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGrade" runat="server" CssClass="textBox1" TabIndex="2"></asp:TextBox>
                                        </td>
                                        </tr>


                                </asp:Panel>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPrevRemarks" runat="server" CssClass="textBoxbigA" Height="82px"
                                            TabIndex="8" TextMode="MultiLine">                                               
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <div class="cleared">
                            </div>
                        </div>
                        <!--ended content Div-->
                    </div>
                    <!--ended rounded Div-->
                    <table width="100%">
                        <tr align="center">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2"><asp:Button ID="Button2" runat="server" ValidationGroup="Submit" CssClass="" OnClick="btnSave_Click" Visible="false"
                                            Text="Update" />
                               <asp:Button ID="btncancel" runat="server" CssClass="" OnClientClick="hidePopup();"
                                            Text="Close" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </div>
        </div>
    </asp:Panel>
    <cc1:AnimationExtender ID="aeRoles" runat="server" TargetControlID="pnlSearch">
        <Animations>
        <OnLoad>                               
            <FadeIn Duration="1.5" Fps="100" />
                </OnLoad>                               
        </Animations>
    </cc1:AnimationExtender>
    <asp:HiddenField ID="hdDummy" runat="server" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BehaviorID="ModalPopupExtenderBehavior"
        TargetControlID="hdDummy" PopupControlID="pnlSearch" RepositionMode="RepositionOnWindowResizeAndScroll"
        BackgroundCssClass="modalBackground" X="320" Y="120">
    </cc1:ModalPopupExtender>
    </div>
</asp:Content>
