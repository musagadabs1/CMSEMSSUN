<%@ Page Title="" Language="C#" MasterPageFile="~/ReportMaster.master"
    AutoEventWireup="true" CodeFile="PrintReport.aspx.cs" Inherits="Pages_PrintReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
        <%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc3" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Consolidated Report</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                         <td style="padding:3px 5px;">
                                MKT Officer
                            </td>
                            <td style="padding:3px 5px;">
                                <asp:DropDownList ID="ddlemp" runat="server" CssClass="textBox11" Width="142px">
                                </asp:DropDownList>


                                <%--   <cc3:ComboBox runat="server" ID="ddlemp" Width="200" MenuWidth="600" Height="150" EmptyText="Select MKT Officer ...">

                                     <HeaderTemplate>
	      
             <div class="header c3">Name</div>
	        <div class="header c4">Group Name</div>
	    </HeaderTemplate>
	    <ItemTemplate>
           <%-- <div title="<%# Eval("Agencyname").ToString() + " from " + Eval("Agentname").ToString() %>">
           <div>
	           
	            <div class="item c3"><%# Eval("Name")%></div>
                <div class="item c4"><%# Eval("GroupName")%></div>
            </div>
	    </ItemTemplate>
	    <FooterTemplate>
	        Displaying <%# Container.ItemsCount %> items.
	    </FooterTemplate>
	</cc3:ComboBox>--%>


                            </td>
                            <td>
                            </td>
                            <td></td>
                            </tr>
                            <td style="padding:3px 5px;">
                                Degree Type
                            </td>
                            <td style="padding:3px 5px;">
                                <asp:DropDownList ID="ddlDegreeType" runat="server" CssClass="textBox11" Width="142px">
                                </asp:DropDownList>
                            </td>
                            <td style="padding:3px 5px;">
                                <asp:Label ID="lblCallerCategory" runat="server" CssClass="" Text="Caller Category"></asp:Label>
                                 <span style="color:Red">*</span>
                            </td>
                            <td style="padding:3px 5px;">
                                <asp:DropDownList ID="ddlCallerCategory" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding:3px 5px;">
                                <asp:Label ID="lblStudentStatus" runat="server" CssClass="" Text="Caller Status"></asp:Label>
                                 <span style="color:Red">*</span>
                            </td>
                            <td style="padding:3px 5px;">
                                <asp:DropDownList ID="ddlStudentStatus" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px">
                                    <asp:ListItem Value="V">Visitor</asp:ListItem>
                                    <asp:ListItem Value="C">Caller</asp:ListItem>
                                    <asp:ListItem Value="F">Follow Up</asp:ListItem>
                                    <asp:ListItem Value="R">Enrolled</asp:ListItem>
                                    <asp:ListItem Value="NQ">Not Qualified</asp:ListItem>
                                    <asp:ListItem Value="Cl">Not Interested (Closed)</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="padding:3px 5px;">
                                <asp:Label ID="Label1" runat="server" CssClass="" Text="Country"></asp:Label>
                                 <span style="color:Red">*</span>
                            </td>
                            <td style="padding:3px 5px;">
                                <asp:DropDownList ID="ddlCountry" runat="server" TabIndex="5" CssClass="textBox11"
                                    Width="142px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="UAE">U.A.E.</asp:ListItem>
                                    <asp:ListItem Value="NG">NIGERIA</asp:ListItem>
                                    <asp:ListItem Value="PK">PAKISTAN</asp:ListItem>
   <asp:ListItem Value="MA">MOROCCO</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding:3px 5px;">
                                From Date
                            </td>
                            <td style="padding:3px 5px;">
                             <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox1"></asp:TextBox>  
                              <span style="color:Red">*</span>                              
                                <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:CalendarExtender ID="ceFromDate" runat="server" CssClass="MyCalendar" TargetControlID="txtFromDate" PopupButtonID="ImgBCalender" >
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txtFromDate">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding:3px 5px;">
                                To Date
                            </td>
                            <td style="padding:3px 5px;">
                                

                             <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox1"></asp:TextBox>   
                              <span style="color:Red">*</span>                             
                                <asp:ImageButton ID="ImgToDate" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" TargetControlID="txtToDate" PopupButtonID="ImgToDate" >
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                    ValidChars="/,-" TargetControlID="txtToDate">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding:3px 5px;" align="center" colspan="4">
                              <%--  <asp:Button ID="btnSubmit" runat="server" CssClass="textBox1" Text="Preview" Visible="false"
                                    OnClick="btnSubmit_Click" />--%>
                                <asp:Button ID="btnPrint" runat="server" CssClass="textBox1" Text="Print"
                                    OnClick="btnPrint_Click"  OnClientClick="document.getElementById('form1').target ='_blank';" />
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
        <asp:Panel ID="pnlReportViwer" runat="server" ScrollBars="Both" Width="710px" Visible="true">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                HasCrystalLogo="False" HasToggleGroupTreeButton="False" 
                ToolPanelView="None" PrintMode="ActiveX" />
        </asp:Panel>
    </div>
    </div>
</asp:Content>
