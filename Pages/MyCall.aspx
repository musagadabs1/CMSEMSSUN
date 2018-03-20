<%@ Page Title="Skyline : My Call List" Language="C#" MasterPageFile="~/MasterForCallManagement.master"
    AutoEventWireup="true" CodeFile="MyCall.aspx.cs" Inherits="Pages_MyCall" %>

<%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc3" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        .item
        {
            position: relative !important;
            display:-moz-inline-stack;
            display:inline-block;
            zoom:1;
            *display:inline;
            overflow: hidden;
            white-space: nowrap;
        }
        
        .header
        {
            margin-left: 2px;
        }
   
        .c1
        {
            width: 25px;
        }
        
        .c2
        {
            margin-left: 10px;
            width: 180px;
        }
        
        .c3
        {
            margin-left: 10px;
            width: 90px;
        }
          .c4
        {
            margin-left: 10px;
            width: 180px;
        }
    </style>


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
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div id="all-form-wrap">
                <!--Div Started to Wrapping all Forms Fields-->
                <div class="form-fieldset-wrapper">
                    <!--Start Div To Wrapping Form Fields Set-->
                    <div class="form-fieldset-wrapper-top">
                    <table>
                                    <tr>
                                        <td style="width: 40%">
                                            <asp:Label ID="Label4" runat="server" CssClass="" Text="School"></asp:Label>
                                        </td>
                                        <td style="width: 60%">
                                            <asp:DropDownList ID="Drpschool" runat="server" CssClass="textBox9" TabIndex="8"
                                                AutoPostBack="True" OnSelectedIndexChanged="Drpschool_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Drpschool"
                                                CssClass="" ErrorMessage="Please Select School!" Font-Size="Large" ForeColor="Red"
                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                  </table> 
                        <!--Div for the form fieldset wrapper top rounded part-->
                        <h2>
                            Filter Caller</h2>
                    </div>
                    <!--ended Div of Form fieldset wrapper top rounded part-->
                    <div class="form-fieldset-wrapper-mid">
                        <!--Div for the form fieldset wrapper middle part for the left and right border-->
                        <div class="form-fieldset-wrapper-mid-inner">
                            <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Call Type &nbsp;<asp:DropDownList ID="ddlCallType" runat="server" CssClass="textBoxSearch">
                                            <asp:ListItem Value="All">Select</asp:ListItem>
                                            <asp:ListItem Value="A">Attended</asp:ListItem>
                                            <asp:ListItem Value="R">Registered</asp:ListItem>
                                            <asp:ListItem Value="P">Prospect</asp:ListItem>
                                            <asp:ListItem Value="S">Suspended</asp:ListItem>
                                            <asp:ListItem Value="D">Drop Out</asp:ListItem>
                                            <asp:ListItem Value="V">Visitor</asp:ListItem>
                                            <asp:ListItem Value="C">Caller</asp:ListItem>
                                            <asp:ListItem Value="F">Follow Up</asp:ListItem>
                                            <asp:ListItem Value="CT">Converted</asp:ListItem>
                                            <asp:ListItem Value="F">Forwarded To Me</asp:ListItem>
                                            <asp:ListItem Value="FM">Forwarded By Me</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:RadioButton ID="rdbNumber" runat="server" Text="Mobile No" GroupName="FilterBy" />
                                        <asp:RadioButton ID="rdbEmail" runat="server" Text="Email" GroupName="FilterBy" />
                                        <asp:RadioButton ID="rdbName" runat="server" Text="Name" GroupName="FilterBy" />
                                        &nbsp;
                                        <asp:TextBox ID="txtFilterValue" runat="server" Text="" CssClass="textBox1"></asp:TextBox>
                                        <cc1:AutoCompleteExtender runat="server" ID="acFilterVAlue" BehaviorID="autoComplete"
                                            TargetControlID="txtFilterValue" ServicePath="~/AutoComlete.asmx" ServiceMethod="GetCompletionList"
                                            MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth">
                                        </cc1:AutoCompleteExtender>
                                        &nbsp;
                                        <asp:Button ID="btnSearch" runat="server" CssClass="" OnClick="btnSearch_Click" Text="Search"
                                            ValidationGroup="Search" />
                                        &nbsp;
                                        <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
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
                            My Call List</h2>
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
                                                GridLines="Both" CssClass="grid-view" 
                                                OnRowCommand="gvStudentList_RowCommand">
                                                <FooterStyle CssClass="GridFooter" />
                                                <RowStyle CssClass="GridItem" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.N.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Caller No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Bind("LinkId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Name">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("LinkId") %>'
                                                                Text='<%#Bind("Name") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Call Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%#Bind("CallDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Form Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFormStatus" runat="server" Text='<%# Bind("FormStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Caller Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStudentStatus" runat="server" Text='<%# Bind("StudentStatus") %>'></asp:Label>
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

                        <table >
                        <tr class="button">
                        <td class="button1">
                        <asp:Button ID="btnFirst" runat="server" Text="<<" OnClick="btnFirst_Click" />
                        <asp:Button ID="btnPrev" runat="server" Text="<"  OnClick="btnPrev_Click" />
                        Page
                        <asp:TextBox ID="txtPageNo" runat="server" Text="1" Width="45px"></asp:TextBox>
                        of
                        <asp:Label ID="lblPages" runat="server" Text="1"></asp:Label>
                        <asp:Button ID="btnNext" runat="server" Text=">"  OnClick="btnNext_Click" />
                        <asp:Button ID="btnLast" runat="server" Text=">>" OnClick="btnLast_Click" />
                        <asp:RequiredFieldValidator ID="rfvPageNo" runat="server" ControlToValidate="txtPageNo"
                        ErrorMessage="*" ValidationGroup="grpGo">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvPageNo" runat="server" ControlToValidate="txtPageNo" Type="Integer"
                        MinimumValue="1" MaximumValue="1" ValidationGroup="grpGo"></asp:RangeValidator>                        
                        </td>
                        <td align="right">
                        <asp:Label ID="lblStatus" runat="server"> Displaying 1 of 1</asp:Label>
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
                                                <asp:TextBox ID="txtAttendedBy" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
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
                                            <td style="width: 40%">
                                                <asp:Label ID="Label1" runat="server" CssClass="" Text="Caller Status"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlPrevStudentStatus" runat="server" TabIndex="5" CssClass="textBox9">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblCallerCategory" runat="server" CssClass="" Text="Caller Category"></asp:Label>
                                            </td>
                                            <td style="width: 65%">
                                                <asp:DropDownList ID="ddlCallerCategory" runat="server" TabIndex="5" CssClass="textBox9"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlCallerCategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlForStudent" runat="server" Visible="true">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblProspectStatus" runat="server" CssClass="" Text="Prospect Status"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProspectSstatus" runat="server" TabIndex="6" CssClass="textBox9">
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
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                                                    CssClass="" ErrorMessage="First Name Required!" Font-Size="Large" ForeColor="Red"
                                                    SetFocusOnError="true" ValidationGroup="Submit" Display="None">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="No special Character For First Name!"
                                                    ValidationGroup="Submit" ControlToValidate="txtFirstName" Font-Size="Large" ForeColor="Red"
                                                    ValidationExpression="^[A-Za-z .]+$" Display="None"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
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
                                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Last Name
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLastName"
                                                    CssClass="" ErrorMessage="Last Name Required!" Font-Size="Large" ForeColor="Red"
                                                    SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="No special Character For Last Name!"
                                                    ValidationGroup="Submit" ControlToValidate="txtLastName" Font-Size="Large" ForeColor="Red"
                                                    ValidationExpression="^[A-Za-z .]+$" Display="None"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox1" TabIndex="7"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40%">
                                                <asp:Label ID="lblMobileNo" runat="server" CssClass="" Text="Mobile"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMobileNo"
                                                    CssClass="" ErrorMessage="Mobile No Required!" Font-Size="Large" ForeColor="Red"
                                                    SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
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
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlNationality"
                                                    CssClass="" ErrorMessage="Please Select Nationality!" Font-Size="Large" ForeColor="Red"
                                                    InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
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
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                                                        TargetControlID="txtPoBox">
                                                    </cc1:FilteredTextBoxExtender>
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
                                                    <asp:TextBox ID="txtCity" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
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
                                                    <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="textBox9" TabIndex="8">
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
                                                        SelectionMode="Multiple">
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
                                                <asp:TextBox ID="txtPrevRemarks" runat="server" CssClass="textBoxbigA" Height="82px"
                                                    TabIndex="8" TextMode="MultiLine">                                               
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfCourseType" runat="server" ControlToValidate="ddlCourseType"
                                                    CssClass="" ErrorMessage="Please Select Course Type!" Font-Size="Large" ForeColor="Red"
                                                    InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
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
                                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Submit" CssClass="" OnClick="btnSave_Click"
                                            Text="Update" />
                                        <asp:Button ID="btncancel" runat="server" CssClass="" OnClientClick="hidePopup();"
                                            Text="Close" />
                                        <asp:Button ID="btnPrint" runat="server" ValidationGroup="Submit" CssClass="" OnClick="btnPrint_Click"
                                            Text="Print" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                            ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td colspan="4">
                                        <asp:Label ID="lblMesages" runat="server" Font-Bold="true" Font-Size="12px" Text=""
                                            CssClass="labelMesag"></asp:Label>
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
            <FadeIn Duration="0" Fps="100" />
                </OnLoad>                               
                </Animations>
            </cc1:AnimationExtender>
            <asp:HiddenField ID="hdDummy" runat="server" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BehaviorID="ModalPopupExtenderBehavior"
                TargetControlID="hdDummy" PopupControlID="pnlSearch" RepositionMode="RepositionOnWindowResizeAndScroll"
                BackgroundCssClass="modalBackground" X="320" Y="120">
            </cc1:ModalPopupExtender>
      
  

        
        </ContentTemplate>
    </asp:UpdatePanel>
 
</asp:Content>
