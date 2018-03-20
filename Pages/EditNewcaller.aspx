<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterForCallManagement.master" CodeFile="EditNewcaller.aspx.cs" Inherits="Pages_EditNewcaller" %>
 <%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            font-size:12;
            font-family:Verdana;
            
        }
        
        .header
        {
            margin-left: 2px;
        }
   
        .c1
        {
            width: 90px;
            
        }
        
        .c2
        {
            margin-left: 12px;
            width: 280px;
           
        }
        
        
        
        
        .c3
        {
            margin-left: 10px;
            width: 110px;
           
        }
          .c4
        {
            margin-left: 10px;
            width: 80px;
            
        }
        
        
          .c5
        {
            margin-left: 13px;
            width:60px;
            
        }
        
           .c5
        {
            margin-left: 13px;
            width:70px;
            
        }
        
    </style>
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
                                 Edit Caller's Info</h2>
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
                                        <asp:TextBox ID="txtCallDate" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCallDate"
                                            CssClass="" ErrorMessage="*" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCallerCategory"
                                            CssClass="" ErrorMessage="Caller Category Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%">
                                        <asp:Label ID="lblStudentStatus" runat="server" CssClass="" Text="Caller Status"></asp:Label>
                                    </td>
                                    <td style="width: 60%">
                                        <asp:DropDownList ID="ddlStudentStatus" runat="server" TabIndex="5" CssClass="textBox9"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlStudentStatus_SelectedIndexChanged">
                                            <asp:ListItem Value="V">Visitor</asp:ListItem>
                                            <asp:ListItem Value="C">Caller</asp:ListItem>
                                            <asp:ListItem Value="F">Follow Up</asp:ListItem>
                                            <asp:ListItem Value="R">Enrolled</asp:ListItem>
                                            <asp:ListItem Value="NQ">Not Qualified</asp:ListItem>
                                            <asp:ListItem Value="Cl">Not Interested (Closed)</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlStudentStatus"
                                            CssClass="" ErrorMessage="Caller Status Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlForStudent" runat="server" Visible="true">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="LblFormStatus" runat="server" CssClass="" Text="Form Status"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFormStatus" runat="server" TabIndex="5" CssClass="textBox9"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlFormStatus_SelectedIndexChanged">
                                                <asp:ListItem Value="P">Prospect</asp:ListItem>
                                                <asp:ListItem Value="R">Registrant</asp:ListItem>
                                                <asp:ListItem Value="D">Drop Out</asp:ListItem>
                                                <asp:ListItem Value="S">Suspended</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>--%>
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProspectSstatus"
                                                CssClass="" ErrorMessage="Prospect Status Required!" Font-Size="Large" ForeColor="Red"
                                                SetFocusOnError="true" ValidationGroup="Submit" Display="None" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                 <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="" Text="Forwarded Type"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:RadioButtonList ID="rdotype" runat="server" RepeatDirection="Horizontal" 
                                             Enabled="false" 
                                          >
                                         
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
                                        <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="textBox9" TabIndex="7" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblReferredBy" runat="server" CssClass="" Text="Enquiry For"></asp:Label>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlReferredBy"
                                            CssClass="" ErrorMessage="Enquiry For Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None" InitialValue="0"></asp:RequiredFieldValidator>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlTitle"
                                            CssClass="" ErrorMessage="Title Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None" InitialValue="0"></asp:RequiredFieldValidator>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName"
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
                                        <asp:Label ID="lblMobileNo" runat="server" CssClass="" Text="Mobile(2349099999706)"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
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
                                        <asp:Label ID="Label1" runat="server" CssClass="" Text="Phone"></asp:Label>
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
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Email Format is Wrong!"
                                            ValidationGroup="Submit" ControlToValidate="txtEmailID" Font-Size="Large" Display="None"
                                            ForeColor="Red" ValidationExpression="\w+([_+.']\w+)*@\w+([_.]\w+)*\.\w+([_.]\w+)*">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmailID"
                                            CssClass="" ErrorMessage="Email Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>--%>
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
                                        <asp:Label ID="lblNationality" runat="server" CssClass="" Text="Nationality"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlNationality"
                                            CssClass="" ErrorMessage="Please Select Nationality!" Font-Size="Large" ForeColor="Red"
                                            InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlNationality" runat="server" CssClass="textBox9" TabIndex="8"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlNationality_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Lblcor" runat="server" CssClass="" Text="Country of Residence"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DrpCOR"
                                            CssClass="" ErrorMessage="Please Select Country of Residence!" Font-Size="Large" ForeColor="Red"
                                            InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DrpCOR" runat="server" CssClass="textBox9" TabIndex="8"
                                            AutoPostBack="True" OnSelectedIndexChanged="DrpCOR_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                
                                <asp:Panel ID="pnltxtcity"  runat="server" Visible="true">
                                <tr>
                                        <td>
                                            City Name
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcityname" runat="server" CssClass="textBox1" TabIndex="8"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtcityname"
                                            CssClass="" ErrorMessage="City Name Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnldrpcity"  runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            City Name
                                        </td>
                                        <td>
                                           <asp:DropDownList ID="drpcityname" runat="server" CssClass="textBox9"  TabIndex="8" OnSelectedIndexChanged="drpcityname_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    </asp:Panel>


                                <asp:Panel ID="pnlForVendor4" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            Industry
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIndustry" runat="server" CssClass="textBox9" TabIndex="8">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
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
                                            <asp:Label ID="Label3" runat="server" CssClass="" Text="School"></asp:Label>
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
                                   
                                   
                                    <tr>
                                        <td style="width: 40%">
                                            <asp:Label ID="lblDegreeTypeId" runat="server" CssClass="" Text="Degree Type"></asp:Label>
                                        </td>
                                        <td style="width: 60%">
                                            <asp:DropDownList ID="ddlDegreeType" runat="server" CssClass="textBox9" TabIndex="8"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlDegreeType_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfDegreeType" runat="server" ControlToValidate="ddlDegreeType"
                                                CssClass="" ErrorMessage="Please Select Degree Type!" Font-Size="Large" ForeColor="Red"
                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <tr>
                                        <td>
                                            <asp:Label ID="lblCourseType" runat="server" CssClass="" Text="Course Type"></asp:Label>
                                        </td>
                                        <td>
                  <cc3:ComboBox runat="server" ID="ddlCourseType" Width="120" MenuWidth="460" Height="250" CssClass="textBox9" EmptyText="Select Course ..."
	    
	    >
                                  
                                       
         <HeaderTemplate>
	                                     <div class="header c2">Degree code</div>
                            <div class="header c5">Degree Desription</div>
	        
	    </HeaderTemplate>
	    <ItemTemplate>
           <%-- <div title="<%# Eval("Agencyname").ToString() + " from " + Eval("Agentname").ToString() %>">--%>
           <div>
	             <div class="item c1"><%# Eval("Description")%></div>
	            <div class="item c2"><%# Eval("degreedesc")%></div>
                
            </div>
	    </ItemTemplate>
	    <FooterTemplate>
	        Displaying <%# Container.ItemsCount %> items.
	    </FooterTemplate>
	</cc3:ComboBox>
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
                                        <asp:Label ID="lblRemarks" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBoxbigA" Height="34px"
                                            TabIndex="8" TextMode="MultiLine">                                               
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfCourseType" runat="server" ControlToValidate="txtRemarks"
                                            CssClass="" ErrorMessage="Remarks Required!" Font-Size="Large" ForeColor="Red"
                                            SetFocusOnError="true" ValidationGroup="Submit" Display="None"></asp:RequiredFieldValidator>
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
                <br />
                <table width="50%">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="4">
                           
                           
                            <asp:Button ID="btnUpdate" runat="server" CssClass="" TabIndex="9" OnClick="btnUpdate_Click"
                                Text="Update" Visible="false" />
                           
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to Update?"
                                TargetControlID="btnUpdate" />
                         
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="4">
                            <asp:Label ID="lblMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""
                                CssClass="labelMesag"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        
    </asp:Panel>
</asp:Content>