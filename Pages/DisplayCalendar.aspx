<%@ Page Title="" Language="C#" MasterPageFile="~/ReportMaster.master" AutoEventWireup="true" CodeFile="DisplayCalendar.aspx.cs" Inherits="Page_DisplayCalendar" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                Calendar Reports
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
                                onselectedindexchanged="DrpCalendar_SelectedIndexChanged" AutoPostBack="true" Width="170px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Category1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpCat1" runat="server" CssClass="textBox11" 
                                onselectedindexchanged="DrpCat1_SelectedIndexChanged"  AutoPostBack="true" Width="170px">
                            </asp:DropDownList>
                        </td>
                        </tr>
                        <tr>
                         <td>
                            <asp:Label ID="Label7" runat="server" Text="Category2"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpCat2" runat="server" CssClass="textBox11"  Width="170px">
                            </asp:DropDownList>
                        </td>
                  
                   
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Event Title"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpEvent" runat="server" CssClass="textBox11"  Width="170px">
                            </asp:DropDownList>
                        </td>
                          </tr>
                           <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Type" ></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpType" runat="server" CssClass="textBox11"  Width="170px">
                            </asp:DropDownList>
                             </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Academic Year"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpYear" runat="server" CssClass="textBox11"  Width="170px">
                            </asp:DropDownList>
                       
                       
                        </td>                       
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Semester"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpSem" runat="server" CssClass="textBox11"  Width="170px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Event Start Date"></asp:Label>
                        </td>
                        <td>
                             
                             <asp:TextBox ID="txtStrtDate" Width="87%" runat="server" CssClass="textBox1" ></asp:TextBox>
                           
                             <cc1:CalendarExtender ID="CAL1"  runat="server" Format="dd/MM/yyyy" TargetControlID="txtStrtDate"
                                CssClass="MyCalendar">
                            </cc1:CalendarExtender>
                        </td>
                        </tr>
                        <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Event End Date"></asp:Label>
                        </td>
                        <td>
                             
                             <asp:TextBox ID="txtEndDate" Width="87%" runat="server" CssClass="textBox1" ></asp:TextBox>
                           
                             <cc1:CalendarExtender ID="cal2"  runat="server" Format="dd/MM/yyyy" TargetControlID="txtEndDate"
                                CssClass="MyCalendar">
                            </cc1:CalendarExtender>
                        </td>                      
                    </tr>
                   
                    <tr>
                          <td>
                            <asp:Button ID="BtnStatitics" runat="server" Text="Statistics Report" onclick="BtnStatitics_Click" 
                                />
                        </td>
                        <td>
                            <asp:Button ID="btnShow" runat="server" Text="Dept Wise Report" 
                                onclick="btnShow_Click" />
                        </td>
                         <td>
                            <asp:Button ID="btnDate" runat="server" Text="Date Wise Report" 
                                onclick="btnDate_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnAcademic" runat="server" Text="Academic Calendar" 
                            onclick="btnAcademic_Click" />
                        </td>
                        <td>
                        <asp:CheckBox ID="ChkExportExcel" runat="server" Text="EXPORT EXCEL" />
                        </td>
                         <td>
                            <asp:Label ID="Label4" runat="server" Text="Term" Visible="false"></asp:Label>
                            <asp:Panel ID="PnlConsolidate" runat="server" Visible="false">
                            <table>
                            <tr>
                            <td> 
                                <asp:Button ID="BtnConsolidateRpt" runat="server" 
                                    Text="Consolidated AAC Calendar" onclick="BtnConsolidateRpt_Click"  />
                                    </td>
                            </tr>
                            <tr>
                            <td>
                            <asp:Label ID="Label6" runat="server" Text="Note:Please select only StartDate&EnDate for consolidated Report" ></asp:Label>
                            </td>
                            </tr>
                            </table>
                                  </asp:Panel>                     
                        
                        </td>
                    </tr>
               
                </table>
                  <asp:GridView ID="GrvGrid" runat="server" BackColor="White" BorderColor="#999999"   
          BorderStyle="None" font-Size="X-Small" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  Visible="false" >
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle   Width="10px"   />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />  
                               <Columns>
                               <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                <HeaderStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>  
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
     <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
        PrintMode="ActiveX" />
    </div>
</div>
</asp:Content>

