<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="SecurityClearance.aspx.cs" Inherits="Pages_SecurityClearance" MaintainScrollPositionOnPostback="true" %>

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
    </style>
    <script language="javascript" type="text/javascript">
     
   function isNumberKey(evt){  <!--Function to accept only numeric values-->
            evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
        }
       return true;
	    }

 function minmax(value, min, max) 
{
    if(parseInt(value) < min || isNaN(parseInt(value))) 
        return 0; 
    else if(parseInt(value) > max) 
        return 100; 
    else return value;
}


function lettersOnly(evt) {
       evt = (evt) ? evt : event;
       var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
          ((evt.which) ? evt.which : 0));
       if (charCode > 31 && (charCode < 65 || charCode > 90) &&
          (charCode < 97 || charCode > 122)) {
          alert("Enter letters only.");
          return false;
       }
       return true;
     }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <div class="form-fieldset-wrapper">
            <div class="form-fieldset-wrapper-top">
                <h2>
                    Personal Details
                </h2>
            </div>
            <div class="form-fieldset-wrapper-mid">
                <div class="form-fieldset-wrapper-mid-inner9">
                    <table class="style1" border="1">
                        <colgroup>
                            <col width="20%" />
                            <col width="35%" />
                            <col width="20%" />
                            <col width="25%" />
                        </colgroup>
                        <tr>
                            <td>
                                Full Name
                            </td>
                            <td>
                                <asp:TextBox ID="txt_name" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td>
                                Register No
                            </td>
                            <td>
                                <asp:TextBox ID="txt_RegisterId" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Religion
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="errordiv" ForeColor="Red"
                                    ErrorMessage="***" ControlToValidate="txt_religion" Display="Dynamic" />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_religion" runat="server"></asp:TextBox>
                                
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                    ValidChars=". " TargetControlID="txt_religion">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td>
                                Doctrine
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="errordiv" ForeColor="Red"
                                    ErrorMessage="***" ControlToValidate="txt_Doctrine" Display="Dynamic" />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Doctrine" runat="server"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" 
                                 FilterType="LowercaseLetters, UppercaseLetters,Custom"  ValidChars=". " TargetControlID="txt_Doctrine">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Place of birth
                            </td>
                            <td>
                             <%-- <asp:TextBox ID="txt_Placebirth" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                             ValidChars=". " TargetControlID="txt_Placebirth">
                            </cc1:FilteredTextBoxExtender>--%>
                                <asp:DropDownList ID="ddlPermanentCountry" runat="server" CssClass="textBox11" >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                     <cc1:calendarextender id="ceFromDate" runat="server" cssclass="MyCalendar" targetcontrolid="txt_Placebirth"
                                      popupbuttonid="ImgBCalender">
                                     </cc1:calendarextender>
                                     <cc1:filteredtextboxextender id="FilteredTextBoxExtender39" runat="server" filtertype="Custom,Numbers"
                                      validchars="/,-" targetcontrolid="txt_Placebirth">
                                     </cc1:filteredtextboxextender>--%>
                            </td>
                            <td>
                                Date of birth
                            </td>
                            <td>
                                <asp:TextBox ID="txt_dateofBirth" runat="server"  ></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="errordiv" ForeColor="Red"
                                    ErrorMessage="***" ControlToValidate="txt_dateofBirth" Display="Dynamic" />
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:CalendarExtender ID="Calendarextender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txt_dateofBirth" PopupButtonID="ImageButton1" Format="dd-MM-yyyy">
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txt_dateofBirth">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Current Nationality
                            </td>
                            <td>
                                <%-- <asp:TextBox ID="txt_CurrentNationality" runat="server" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddl_CurrentNationality" runat="server" CssClass="textBox11">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Previous Nationality
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txt_previousNationality" runat="server"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddl_previousNationality" runat="server" CssClass="textBox11">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="form-fieldset-wrapper-bottom">
            </div>
        </div>
    </div>
    <div id="Div1">
        <div class="form-fieldset-wrapper">
            <div class="form-fieldset-wrapper-top">
                <h2>
                    Educational Qualification
                </h2>
            </div>
            <div class="form-fieldset-wrapper-mid">
                <div class="form-fieldset-wrapper-mid-inner">
                    <table class="style1" border="1">
                        <colgroup>
                            <col width="20%" />
                            <col width="40%" />
                            <col width="20%" />
                            <col width="20%" />
                        </colgroup>
                        <tr>
                            <td>
                               Qualification
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Qualification" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="errordiv" ForeColor="Red"
                                    ErrorMessage="***" ControlToValidate="txt_Qualification" Display="Dynamic" />
                            </td>
                            <td>
                                Languages known (only in No's)
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Languages" runat="server" MaxLength="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="errordiv" ForeColor="Red"
                                    ErrorMessage="***" ControlToValidate="txt_Languages" Display="Dynamic" />
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txt_Languages">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="form-fieldset-wrapper-bottom">
        </div>
    </div>
    <div id="Div2">
        <div class="form-fieldset-wrapper">
            <div class="form-fieldset-wrapper-top">
                <h2>
                    Marital Status
                </h2>
            </div>
            <div class="form-fieldset-wrapper-mid">
                <div class="form-fieldset-wrapper-mid-inner9">
                    <table class="style1" border="1">
                        <colgroup>
                            <col width="20%" />
                            <col width="35%" />
                            <col width="20%" />
                            <col width="25%" />
                        </colgroup>
                        <tr>
                            <td>
                                Husband/Wife (Name)
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Spousename" runat="server" Width="100%"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                    ValidChars=". " TargetControlID="txt_Spousename">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td>
                                Nationality
                            </td>
                            <td>
                                <%--   <asp:TextBox ID="txt_spouseNationality" runat="server" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddl_spouseNationality" runat="server" CssClass="textBox11" >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Place of Birth
                            </td>
                            <td>
                                <%-- <asp:TextBox ID="txt_spousemartPob" runat="server" ></asp:TextBox>--%>
                                <asp:DropDownList ID="DDL_spousemartPob" runat="server" CssClass="textBox11" >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Date of Birth
                            </td>
                            <td>
                                <asp:TextBox ID="txt_SpouseDOB" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:CalendarExtender ID="Calendarextender4" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txt_SpouseDOB" PopupButtonID="ImageButton4" Format="dd-MM-yyyy" >
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txt_SpouseDOB">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="form-fieldset-wrapper-bottom">
        </div>
    </div>
    <div id="Div3">
        <div class="form-fieldset-wrapper">
            <div class="form-fieldset-wrapper-top">
                <h2>
                    Children Information
                </h2>
            </div>
            <div class="form-fieldset-wrapper-mid">
                <div class="form-fieldset-wrapper-mid-inner">
                    <table class="style1" border="1">
                        <colgroup>
                            <col width="20%" />
                            <col width="40%" />
                            <col width="20%" />
                            <col width="20%" />
                        </colgroup>
                        <tr>
                            <td>
                                Children (Only in No's)
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Childrens" runat="server" MaxLength="2"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txt_Childrens">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="form-fieldset-wrapper-bottom">
        </div>
        <div id="Div4">
            <div class="form-fieldset-wrapper">
                <div class="form-fieldset-wrapper-top">
                    <h2>
                        Parent's Information
                    </h2>
                </div>
                <div class="form-fieldset-wrapper-mid">
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <table class="style1" border="1">
                            <colgroup>
                                <col width="20%" />
                                <col width="35%" />
                                <col width="20%" />
                                <col width="25%" />
                            </colgroup>
                            <tr>
                                <td>
                                    Father’s Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_FathersName" runat="server" Width="100%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                        ValidChars=". " TargetControlID="txt_Spousename">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    Nationality
                                </td>
                                <td>
                                    <%--<asp:TextBox ID="txt_FatNationality" runat="server" ></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_FatNationality" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Place of birth
                                </td>
                                <td>
                                    <%-- <asp:TextBox ID="txt_FathersPob" runat="server" ></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_FathersPob" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Date of birth
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_FathersDateofbirth" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="Calendarextender2" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txt_FathersDateofbirth" PopupButtonID="ImageButton2" Format="dd-MM-yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txt_FathersDateofbirth">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mother’s Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_mothersname" runat="server" Width="100%"></asp:TextBox>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                    ValidChars=". " TargetControlID="txt_Spousename">
                                </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    Nationality
                                </td>
                                <td>
                                    <%--   <asp:TextBox ID="txt_mothersNationality" runat="server" ></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_mothersNationality" runat="server" CssClass="textBox11"
                                        >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Place of birth
                                </td>
                                <td>
                                    <%-- <asp:TextBox ID="txt_MothersPOB" runat="server" ></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_MothersPOB" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Date of birth
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_MothersDob" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="Calendarextender3" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txt_MothersDob" PopupButtonID="ImageButton3" Format="dd-MM-yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txt_MothersDob">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="form-fieldset-wrapper-bottom">
            </div>
        </div>
    </div>
    <div class="form-fieldset-wrapper">
        <div class="form-fieldset-wrapper-top">
            <h2>
                Contact Information
            </h2>
        </div>
        <div class="form-fieldset-wrapper-mid">
            <div class="form-fieldset-wrapper-mid-inner">
                <table class="style1" border="1">
                    <colgroup>
                        <col width="20%" />
                        <col width="40%" />
                        <col width="20%" />
                        <col width="20%" />
                    </colgroup>
                    <tr>
                        <td>
                            Mobile Number
                        </td>
                        <td>
                            <asp:TextBox ID="txt_ContactMobileno" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" FilterType="Custom,Numbers"
                                ValidChars="/,-" TargetControlID="txt_ContactMobileno">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            Residence Number
                        </td>
                        <td>
                            <asp:TextBox ID="txt_ResidenceNumber" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" FilterType="Custom,Numbers"
                                ValidChars="/,-" TargetControlID="txt_ResidenceNumber">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email Id
                        </td>
                        <td>
                            <asp:TextBox ID="txt_EmailId" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator   id="regEmail" ErrorMessage="Enter Valid emailId"
                             ControlToValidate="txt_EmailId"  ForeColor="Red" Font-Bold="true"  Text="(Invalid email)"
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ValidationGroup="section1" Runat="server" /> 
                        </td>
                        <td>
                            Website
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Website" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Twitter
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Twitter" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Facebook
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Facebook" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Have you ever worked in militry?
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_Militry" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnl_Show1" runat="server">
                    <table class="style1" border="1">
                        <colgroup>
                            <col width="20%" />
                            <col width="40%" />
                            <col width="20%" />
                            <col width="20%" />
                        </colgroup>
                        <tr>
                            <td>
                                Country Name
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txt_miltrycountryName" runat="server"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddl_miltrycountryName" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                            <td>
                                Type of Service
                            </td>
                            <td>
                                <asp:TextBox ID="txt_TypeOfService" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rank
                            </td>
                            <td>
                                <asp:TextBox ID="txt_militryRank" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Duration
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Duration" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                Person to be contacted in your abscence:
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Name
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ContactPerson" runat="server" Width="100%"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" 
                                 FilterType="LowercaseLetters, UppercaseLetters,Custom"  ValidChars=". " TargetControlID="txt_ContactPerson">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td>
                                Nationality
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txt_contactNationality" runat="server"></asp:TextBox>--%>
                                 <asp:DropDownList ID="ddl_contactNationality" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Work Place
                            </td>
                            <td>
                                <asp:TextBox ID="txt_WorkPlace" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Mobile No
                            </td>
                            <td>
                                <asp:TextBox ID="txt_mobileno" runat="server"></asp:TextBox>
                                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterType="Custom,Numbers"
                                ValidChars="/,-" TargetControlID="txt_mobileno">
                            </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                Countries visited before
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <%-- <asp:TextBox ID="txt_VisitedCountry" runat="server"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_VisitedCountry" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                               
                            </td>
                            <td>
                              <%--  <asp:TextBox ID="txt_VisitedCountry2" runat="server"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_VisitedCountry2" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                                
                            </td>
                            <td>
                               <%-- <asp:TextBox ID="txt_VisitedCountry3" runat="server"></asp:TextBox>--%>
                               
                                <asp:DropDownList ID="ddl_VisitedCountry3" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                            <td>
                             <%--   <asp:TextBox ID="txt_VisitedCountry4" runat="server"></asp:TextBox>--%>
                                 <asp:DropDownList ID="ddl_VisitedCountry4" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                               
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txt_VisitedCountry5" runat="server"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddl_VisitedCountry5" runat="server" CssClass="textBox11" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>
                                Upload Curriculum vitae
                            </td>
                            <td colspan="3">
                                <asp:FileUpload runat="server" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_saveClick" />
                                <asp:Label ID="lbl_showmsg" runat="server" Text="Saved Successfully" Visible="false"> </asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="form-fieldset-wrapper-bottom">
    </div>
    </div>
</asp:Content>
