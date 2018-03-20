<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterForCallManagement.master" CodeFile="InsertForwardcallexisting.aspx.cs" Inherits="Pages_InsertForwardcallexisting" %>


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
        
        

  

        
        .rblist
{
	margin: 1em 0;
padding: 0;

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
                        Forward Call  Existing Student </h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                                <div class="form-fieldset-wrapper-mid-inner9">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0" width="80%">
                            <tr>
                                <td style="width: 100px">
                                    Date
                                </td>
                                <td style="width: 160px">
                                    <asp:TextBox ID="txtCallDate" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCallDate"
                                        CssClass="" ErrorMessage="Date Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                        Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 200px">
                                    <asp:Label ID="lblForwardedMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                </td>
                                  <td></td>
                            </tr>
                          
                          <tr>
                          <td>Forward Type</td>
                           <td style="width: 90px">
                           <asp:RadioButtonList ID="rdotype" runat="server" RepeatDirection="Horizontal"  
                                            AutoPostBack="true" CssClass="rblist"
                                            onselectedindexchanged="rdotype_SelectedIndexChanged">
                                         
                                      <asp:ListItem Text="MKT" Value="MKT" Selected="True" >
                                      </asp:ListItem>
                                         <asp:ListItem Text="FAC" Value="FAC">
                                      </asp:ListItem>
                                        <asp:ListItem Text="STF" Value="STF">
                                      </asp:ListItem>
                                       
                                       </asp:RadioButtonList>
                          
                          
                        </td>
                          <td></td>
                          
                          </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Forwarded To"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlForwardedTo1" CssClass="textBox9"  runat="server">
                                    </asp:DropDownList>
                                    
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlForwardedTo1"
                                            CssClass="" ErrorMessage="Forwarded To Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" Display="None" ValidationGroup="Submit1" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <asp:Panel ID="pnlStatus" runat="server" Visible="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStudentStatus" runat="server" CssClass="" Text="Status"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlStudentStatus" runat="server" TabIndex="5" CssClass="textBox9">
                                            <asp:ListItem Value="V">Visitor</asp:ListItem>
                                            <asp:ListItem Value="C">Caller</asp:ListItem>
                                            <asp:ListItem Value="F">Follow Up</asp:ListItem>
                                            <asp:ListItem Value="R">Enrolled</asp:ListItem>
                                            <asp:ListItem Value="NQ">Not Qualified</asp:ListItem>
                                            <asp:ListItem Value="Cl">Not Interested (Closed)</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlStudentStatus"
                                            CssClass="" ErrorMessage="Status Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" Display="None" ValidationGroup="Submit" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                    <td></td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblRemarks" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBoxbigA" Height="120px"
                                        TabIndex="7" TextMode="MultiLine">                                               
                                    </asp:TextBox>
                                </td>
                    
                         
                            </tr>
                            <tr>
                               
                                <td colspan="3">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="" OnClick="btnUpdate_Click" Text="Update"
                                        ValidationGroup="Submit1" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                        ShowMessageBox="True" ValidationGroup="Submit1" Font-Size="Large" ForeColor="Red" />
                                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                                        <input id="Button1" type="button" value="View Details" onclick="shopPopup();" />
                                    </asp:Panel>
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
    </asp:Panel>
    <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Forwarded History</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--start list member blocks-->
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel4" runat="server">
                                    <div id="Div2" style="width: 693px">
                                        <asp:GridView ID="gvForwardedTo" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                            EmptyDataText="There are no records to display." OnRowDataBound="gvForwardedTo_RowDataBound"
                                            GridLines="Both" CssClass="grid-view">
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.N.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Course">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%#Bind("DegreeCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entry Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEntryDate" runat="server" Text='<%# Bind("CallDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attended By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegisteredBy" runat="server" Text='<%# Bind("AttendedBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Forwarded To">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblForwardedTo" runat="server" Text='<%# Bind("ForwardedTo") %>'></asp:Label>
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
    <asp:Panel ID="Panel3" runat="server" Visible="false">
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
                                                <asp:TemplateField HeaderText="Registered By">
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
            <div id="all-form-wrap" style="background-color: #E3E2E3 !important; padding-left: 7px;
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
                                            <asp:DropDownList ID="ddlCallerCategory" runat="server" TabIndex="5" CssClass="textBox9"
                                                Enabled="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 40%">
                                            <asp:Label ID="Label1" runat="server" CssClass="" Text="Caller Status"></asp:Label>
                                        </td>
                                        <td style="width: 60%">
                                            <asp:DropDownList ID="ddlPrevStudentStatus" runat="server" TabIndex="5" CssClass="textBox9"
                                                Enabled="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlForStudent" runat="server" Visible="true">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblProspectStatus" runat="server" CssClass="" Text="Prospect Status"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlProspectSstatus" runat="server" TabIndex="6" CssClass="textBox9"
                                                    Enabled="false">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Serious</asp:ListItem>
                                                    <asp:ListItem Value="2">Non Serious</asp:ListItem>
                                                    <asp:ListItem Value="3">Not Sure</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblForwardedTo" runat="server" CssClass="" Text="Forwarded To"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="textBox9" TabIndex="7"
                                                Enabled="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblReferredBy" runat="server" CssClass="" Text="Referred By/Enquiry For"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlReferredBy" runat="server" CssClass="textBox9" TabIndex="7"
                                                Enabled="false">
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
                                            <asp:DropDownList ID="ddlTitle" runat="server" CssClass="textBox9" TabIndex="7" Enabled="false">
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
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox1" TabIndex="7" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Middle Name
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textBox1" TabIndex="7" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Last Name
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox1" TabIndex="7" ReadOnly="true"></asp:TextBox>
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
                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="textBox1" TabIndex="7" ReadOnly="true"></asp:TextBox>
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
                                            <asp:TextBox ID="txtTelephone" runat="server" CssClass="textBox1" TabIndex="7" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblEmailID" runat="server" CssClass="" Text="Email ID"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmailID" runat="server" CssClass="textBox1" TabIndex="7" ReadOnly="true"></asp:TextBox>
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
                                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textBox1" TabIndex="8"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Designation
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDesignation" runat="server" CssClass="textBox1" TabIndex="8"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Religion
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlReligion" runat="server" CssClass="textBox9" TabIndex="8"
                                                    Enabled="false">
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
                                            <asp:DropDownList ID="ddlNationality" runat="server" CssClass="textBox9" TabIndex="8"
                                                Enabled="false">
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
                                                <asp:DropDownList ID="ddlIndustry" runat="server" CssClass="textBox9" TabIndex="8"
                                                    Enabled="false">
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
                                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="textBox1" TabIndex="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Fax
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFax" runat="server" CssClass="textBox1" TabIndex="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                PO Box / Zip
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPoBox" runat="server" CssClass="textBox1" TabIndex="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Address
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="textBox1" TabIndex="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                City
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCity" runat="server" CssClass="textBox1" TabIndex="8" ReadOnly="true"></asp:TextBox>
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
                                                    Enabled="false">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="BBA">BBA</asp:ListItem>
                                                    <asp:ListItem Value="MBA">MBA</asp:ListItem>
                                                    <asp:ListItem Value="WEEKEND BBA">WEEKEND BBA</asp:ListItem>
                                                    <asp:ListItem Value="WEEKEND MBA">WEEKEND MBA</asp:ListItem>
                                                    <asp:ListItem Value="SHORT COURSE">SHORT COURSE</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCourseType" runat="server" CssClass="" Text="Course Type"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="textBox9" TabIndex="8"
                                                    Enabled="false">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">BBI</asp:ListItem>
                                                    <asp:ListItem Value="2">BIB</asp:ListItem>
                                                    <asp:ListItem Value="3">BBT</asp:ListItem>
                                                    <asp:ListItem Value="4">BBM</asp:ListItem>
                                                    <asp:ListItem Value="5">BBF</asp:ListItem>
                                                    <asp:ListItem Value="6">MBF</asp:ListItem>
                                                    <asp:ListItem Value="7">MBM</asp:ListItem>
                                                    <asp:ListItem Value="8">MBH</asp:ListItem>
                                                    <asp:ListItem Value="9">WBIB</asp:ListItem>
                                                    <asp:ListItem Value="10">WBBT</asp:ListItem>
                                                    <asp:ListItem Value="11">WBBM</asp:ListItem>
                                                    <asp:ListItem Value="12">WBBF</asp:ListItem>
                                                    <asp:ListItem Value="13">WMBF</asp:ListItem>
                                                    <asp:ListItem Value="14">WMBM</asp:ListItem>
                                                    <asp:ListItem Value="15">WMBH</asp:ListItem>
                                                    <asp:ListItem Value="16">All Short Courses</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblArabNonArab" runat="server" CssClass="" Text="Arab/Non Arab"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlArabNonArab" runat="server" CssClass="textBox9" TabIndex="8"
                                                    Enabled="false">
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
                                                <asp:DropDownList ID="ddlCurrentlyEmployee" runat="server" CssClass="textBox9" TabIndex="8"
                                                    Enabled="false">
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
                                                <asp:TextBox ID="txtSchool" runat="server" CssClass="textBox1" TabIndex="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMediaSource" runat="server" CssClass="" Text="Media Source"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ListBox ID="lbMediaSource" runat="server" CssClass="listboxMedisSource" Enabled="false"
                                                    TabIndex="8" SelectionMode="Multiple">
                                                    <asp:ListItem Value="0">News Paper</asp:ListItem>
                                                    <asp:ListItem Value="1">Word of Mouth</asp:ListItem>
                                                    <asp:ListItem Value="2">Television</asp:ListItem>
                                                    <asp:ListItem Value="3">Exhibition</asp:ListItem>
                                                    <asp:ListItem Value="4">Friends/Relatives</asp:ListItem>
                                                    <asp:ListItem Value="5">Billboards</asp:ListItem>
                                                    <asp:ListItem Value="6">School</asp:ListItem>
                                                    <asp:ListItem Value="7">Radio</asp:ListItem>
                                                    <asp:ListItem Value="8">Internet</asp:ListItem>
                                                    <asp:ListItem Value="9">Any Other</asp:ListItem>
                                                    <asp:ListItem Value="10">Face book</asp:ListItem>
                                                    <asp:ListItem Value="11">Google</asp:ListItem>
                                                    <asp:ListItem Value="12">Yahoo</asp:ListItem>
                                                    <asp:ListItem Value="13">Bing</asp:ListItem>
                                                    <asp:ListItem Value="14">Referral</asp:ListItem>
                                                    <asp:ListItem Value="15">International Agent</asp:ListItem>
                                                    <asp:ListItem Value="16">Existing Student</asp:ListItem>
                                                    <asp:ListItem Value="17">Online Inquiry - SUC</asp:ListItem>
                                                    <asp:ListItem Value="18">Alumini</asp:ListItem>
                                                </asp:ListBox>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrevRemarks" runat="server" ReadOnly="true" CssClass="textBoxbigA"
                                                Height="82px" TabIndex="8" TextMode="MultiLine">                                               
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
                                <td colspan="2">
                                    <asp:ImageButton ID="btncancel" runat="server" OnClientClick="hidePopup();" ImageUrl="~/Icons/lightbox-btn-close.gif"
                                        Font-Size="12px" />
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
    </asp:Panel>
    </div>
</asp:Content>
