<%@ Page Language="C#"   MasterPageFile="~/ReportMaster.master"  AutoEventWireup="true" CodeFile="Mom_Agenda.aspx.cs" Inherits="Page_Mom_Agenda" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div id="all-form-wrap">
    <!--Div Started to Wrapping all Forms Fields-->
    <div class="form-fieldset-wrapper">
        <!--Start Div To Wrapping Form Fields Set-->
        <div class="form-fieldset-wrapper-top-left">
        </div>
        <div class="form-fieldset-wrapper-top-page">
            <!--Div for the form fieldset wrapper top rounded part-->
            <h2>
                Agenda & MOM Reports
            </h2>
        </div>
        <div class="form-fieldset-wrapper-top-right">
        </div>
        <!--ended Div of Form fieldset wrapper top rounded part-->
        <div class="form-fieldset-wrapper-mid">
            <!--Div for the form fieldset wrapper middle part for the left and right border-->
            <div class="form-fieldset-wrapper-mid-inner9">
                <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                
                <table id="Table1" runat="server" width="100%" cellspacing="5" cellpadding="5">
                
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Calendar Name"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpCalendar" CssClass="textBox11" runat="server" 
                                onselectedindexchanged="DrpCalendar_SelectedIndexChanged" AutoPostBack="true" Width="200px" >
                            </asp:DropDownList>
                        </td>
                            <%--<td>--%>
                       <%-- <table>
                        <tr>--%>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="AY"></asp:Label>
                        </td>
                        
                        <td>
                         <asp:DropDownList ID="DrpAcademicYear" AutoPostBack="true" runat="server"  CssClass="textBox11" 
                                    OnSelectedIndexChanged="DrpAcademicYear_SelectedIndexChanged1" 
                                Height="21px" Width="108px">
                                </asp:DropDownList>
                        </td>
                        <%--</tr>
                        
                        </table>--%>
                     
                            
                       <%--
                            </td>--%>
                            </tr>
                        <tr>
                      
                         <td>
                            <asp:Label ID="Label12" runat="server" Text="Event Start Date"></asp:Label>
                        </td>
                        <td>
                             
                             <asp:TextBox ID="txtStrtDate" Width="87%" runat="server" CssClass="textBox1" 
                                 AutoPostBack="True" ontextchanged="txtStrtDate_TextChanged" ></asp:TextBox>
                           
                             <cc1:CalendarExtender ID="CAL1"  runat="server" Format="dd/MM/yyyy" TargetControlID="txtStrtDate"
                                CssClass="MyCalendar">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Event Title"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpEvent" runat="server" AutoPostBack="true"  CssClass="textBox11" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
          
                    
                   
                    <tr>
                     
                          <td>
                            
                       
                             <asp:RadioButton runat ="server"  ID="RadMom" Text ="MOM" AutoPostBack ="true" 
                                  GroupName ="RPT" />
                              <asp:RadioButton runat ="server"  ID="RadAgenda" Text ="Agenada" AutoPostBack ="true" GroupName ="RPT" />
                           
                               
                        </td>
                         <td>
                             <asp:Button ID="btnLOad" runat="server" Text="LoadReport" onclick="btnLOad_Click" /></td>
                             <td>  <asp:Label ID="Label3" runat="server" Text="Decision Status"></asp:Label> </td>
                                 <td> <asp:DropDownList ID="DDLDecisionStatus" runat ="server" >
                                  <asp:ListItem Text ="All" Value ="All"></asp:ListItem>
                                 <asp:ListItem Text ="Completed" Value ="Completed"></asp:ListItem>
                                 <asp:ListItem Text ="Pending" Value ="Pending"></asp:ListItem>
                                  <asp:ListItem Text ="In Progress" Value ="In Progress"></asp:ListItem>
                                   <asp:ListItem Text ="In Progress & Pending" Value ="In Progress & Pending"></asp:ListItem>
                                 </asp:DropDownList> </td>
                             </tr>

                             <tr>
                        <td>
                            
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
                            </td>
                        <td>
                            &nbsp;</td>
                         <td>
                            <asp:Panel ID="PnlConsolidate" runat="server" Visible="false">
                            <table>
                            <tr>
                            <td> 
                                &nbsp;</td>
                            </tr>
                            <tr>
                            <td>
                                &nbsp;</td>
                            </tr>
                            </table>
                                  </asp:Panel>                     
                        
                        </td>
                    </tr>
               
                </table>
                  </div>
            <!--form fieldset wrapper mid inner ended-->
        </div>
        <!--Ended Div of form fieldset wrapper middle part of left and right border-->
        <div class="form-fieldset-wrapper-bottom-left">
        </div>
        <div class="form-fieldset-wrapper-bottom-page">
        </div>
        <div class="form-fieldset-wrapper-bottom-right">
        </div>
        <!--Div started for the form fieldset wrapper bottom founded-->
    </div>
    <!--ended Div of Wrapping Form Fields Set-->
    <%-- <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
        PrintMode="ActiveX" />--%>
    </div>
<%--</div>--%>
</asp:Content>