<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true"
 CodeFile="CourseFilePlanner.aspx.cs" Inherits="Pages_CourseFilePlanner" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:Panel ID="pnlMainContent" runat="server" Visible="true">
<div id="all-form-wrap">
 <div class="form-fieldset-wrapper">
  <div class="form_round_border">
   <div class="form_round_heading_row">
      <!--this is heading row-->
      <h2 class="slide_top">
           Course File Planner
      </h2>
   </div>

   <div class="round_form_content">
     <table border="0" cellpadding="0" cellspacing="0">
     <tr>
     <td>
      <b>  <asp:Label ID="lblSchedCourse" runat="server"  Text="Schedule Of Course"></asp:Label></b>
     </td>
     <td>
           <asp:TextBox ID="txt_sched" runat="server" ></asp:TextBox>
     </td>
     </tr>

     <tr>
     <td><b> <asp:Label ID="lbl_fac" runat="server" Text ="Faculty Name"></asp:Label></b> </td>
     <td><asp:TextBox ID="txt_fac" runat="server"></asp:TextBox></td>
     </tr>

     <tr>
     <td>
     <b><asp:Label ID="lbl_course_date" runat="server"></asp:Label> </b>
     </td>      
     </tr>

     
     <tr>
     <td>
      <b><asp:Label ID="lbl_FromDate" runat="server" Text="From Date" ></asp:Label></b>
     </td>
     
     <td style="padding: 3px 5px;">
        <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox1"></asp:TextBox>
        <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
        <cc1:calendarextender id="ceFromDate" runat="server" cssclass="MyCalendar" targetcontrolid="txtFromDate"
            popupbuttonid="ImgBCalender">
        </cc1:calendarextender>
       <%-- <cc1:filteredtextboxextender id="FilteredTextBoxExtender39" runat="server" filtertype="Custom,Numbers"
            validchars="/,-" targetcontrolid="txtFromDate">
            </cc1:filteredtextboxextender> --%>
    </td>

     <td>
      <b><asp:Label ID="lbl_ToDate" runat="server" Text="To Date" ></asp:Label></b>
     </td>
     <td>
      <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox1"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
        <cc1:calendarextender id="Calendarextender1" runat="server" cssclass="MyCalendar" targetcontrolid="txtToDate"
            popupbuttonid="ImageButton1">
        </cc1:calendarextender>
     </td>
     </tr>
     </table>

      <table>
        <tr>
        <td align="right">                        
        <div>
        <asp:Button ID="btn_plus" runat="server" Text="+" OnClick="btn_plus_click"  />
        
        </div>
        </td>
        </tr>
     </table>

     <table border=1  runat="server" id="Table1" >
          <tr><td align="center" colspan='4'><b><asp:Label ID="lbl_types" runat="server"></asp:Label></b></td></tr>
     </table>

  <asp:GridView ID="grid_tab" AutoGenerateColumns="false" runat="server" 
                           Style="margin-left: 5px; margin-bottom: 10px; top: 0px; left: 0px; width: 99%;"   >                                  
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <Columns>
                            <asp:BoundField  DataField="RowNumber" HeaderText="Plan" />                         
                                                      
                             
                                 <asp:TemplateField HeaderText="Content"   >
                                    <ItemTemplate>
                                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>                                      
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Operational"   >
                                    <ItemTemplate>
                                       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Academic"   >
                                    <ItemTemplate>
                                       <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transportation"   >
                                    <ItemTemplate>
                                       <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="For Week"   >
                                    <ItemTemplate>
                                       <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
       </asp:GridView> 

                      <table>
                      <tr>
                      <td align="center">
                      <asp:Button ID="btn_save" runat="server" OnClick="btn_save_click"  Text="Save" />
                      <asp:Button ID="btn_clear" runat="server"  Text="Clear" OnClick="btn_clear_click" />
                      <asp:Button ID="btn_report" runat="server" Text="Print Report" OnClick="btn_print_Click" Visible="false" />
                      <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                      </td></tr>
                      </table> 

   <asp:GridView ID="GridView1" AutoGenerateColumns="false" 
                       runat="server" Style="margin-left: 5px;
                            margin-bottom: 10px; top: 0px; left: 0px; width: 99%;"  >                            
                             <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                            <SelectedRowStyle CssClass="GridRowOver" />
                            <EditRowStyle />
                            <AlternatingRowStyle CssClass="GridAltItem" />
                            <Columns>
                              <asp:TemplateField HeaderText="SNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                    <asp:Label ID="lbl_SNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>                                      
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Week plan" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <%#Eval("WeekPlan")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                          
                                 <asp:TemplateField HeaderText="Content" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <%#Eval("content")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Operational" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <%#Eval("Operational")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Academic" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <%#Eval("Academic")%>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="Transportation" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <%#Eval("transportation")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            </asp:GridView>


   </div>
  
  </div>
 </div>
</div>
</asp:Panel>
 <asp:Panel ID="pnlReportViwer" runat="server" ScrollBars="Both" Width="710px" Visible="true">
            <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                hascrystallogo="False" hastogglegrouptreebutton="False" toolpanelview="None"
                printmode="ActiveX" />
        </asp:Panel>
</asp:Content>


