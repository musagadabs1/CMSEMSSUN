<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ReportMaster.master" CodeFile="COECEnrollment_ManualEntry.aspx.cs" Inherits="Pages_COECEnrollment_ManualEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                   ENROLLMENT STATISTCS  BBA & MBA - WEEKDAY & WEEKEND BATCH – MANUAL ENTRY</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding: 3px 5px;">
                                Term
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:DropDownList ID="ddlTerm" runat="server" TabIndex="5" Width="142px" 
                                    CssClass="textBox9" AutoPostBack="true" 
                                    AppendDataBoundItems="true" 
                                    onselectedindexchanged="ddlTerm_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                             <asp:ListItem Value="0">Select</asp:ListItem>
                                                      <asp:ListItem Value="May">May</asp:ListItem>
                                                               <asp:ListItem Value="Sep">Sep</asp:ListItem>
                                                                <asp:ListItem Value="Jan">Jan</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTerm"
                                    CssClass="" ErrorMessage="Term Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                    Display="None" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </td>

                                      <td style="padding: 3px 5px;">
                               AS of Date
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox1" AutoPostBack="true"  OnTextChanged="txtFromDate_changed"></asp:TextBox>
                                <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:calendarextender id="ceFromDate" runat="server" cssclass="MyCalendar" targetcontrolid="txtFromDate"
                                    popupbuttonid="ImgBCalender">
                                </cc1:calendarextender>
                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender39" runat="server" filtertype="Custom,Numbers"
                                    validchars="/,-" targetcontrolid="txtFromDate">
                                </cc1:filteredtextboxextender>
                            </td>
                            <td>
                            <asp:Button ID="btnload" runat="server" Text="Load" onclick="btnload_Click" />
                            
                            </td>
                            </tr>
                            
                                               </table>
                                               <table>
                                               <tr>
                                               <td>
                                                <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false"
                                                        EmptyDataText="There are no records to display."
                                                        GridLines="Both" CssClass="grid-view"                                                  >
                                                        <FooterStyle CssClass="GridFooter" />
                                                        <RowStyle CssClass="GridItem" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.N.">
                                                                <ItemTemplate>
                                                                   <asp:Label ID="lblSN1" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Year">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblyear" runat="server" Text='<%# Eval("Eyear") %>' ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="BBA WEEKDAY">
                                                                <ItemTemplate>
                                                                  <asp:TextBox ID="txtbbaweekday" runat="server" MaxLength="3" Text='<%# Eval("BBaweekday_Total") %>' ></asp:TextBox>
                                                                   <cc1:filteredtextboxextender id="FilteredTextBoxExtender391" runat="server" filtertype="Numbers" targetcontrolid="txtbbaweekday"></cc1:filteredtextboxextender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                              <asp:TemplateField HeaderText="BBA WEEKEND">
                                                                <ItemTemplate>
                                                                  <asp:TextBox ID="txtbbaweekend" runat="server" MaxLength="3" Text='<%# Eval("BBaweekend_Total") %>' ></asp:TextBox>
                                                                   <cc1:filteredtextboxextender id="FilteredTextBoxExtender392" runat="server" filtertype="Numbers" targetcontrolid="txtbbaweekend"></cc1:filteredtextboxextender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="MBA WEEKDAY">
                                                                <ItemTemplate>
                                                                  <asp:TextBox ID="txtMbaweekday" runat="server" MaxLength="3" Text='<%# Eval("MBaweekday_Total") %>' ></asp:TextBox>
                                                                   <cc1:filteredtextboxextender id="FilteredTextBoxExtender393" runat="server" filtertype="Numbers" targetcontrolid="txtMbaweekday"></cc1:filteredtextboxextender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                                <asp:TemplateField HeaderText="MBA WEEKEND">
                                                                <ItemTemplate>
                                                                  <asp:TextBox ID="txtMbaweekend" runat="server" MaxLength="3" Text='<%# Eval("MBaweekend_Total") %>' ></asp:TextBox>
                                                                   <cc1:filteredtextboxextender id="FilteredTextBoxExtender394" runat="server" filtertype="Numbers" targetcontrolid="txtMbaweekend"></cc1:filteredtextboxextender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                                                                     
                                                         </Columns>
                                                        <HeaderStyle CssClass="GridHeader" />
                                                        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                        <SelectedRowStyle CssClass="GridRowOver" />
                                                        <EditRowStyle />
                                                        <AlternatingRowStyle CssClass="GridAltItem" />
                                                    </asp:GridView>

</td>
                                               </tr>


                                        <tr>
                                       <td>
                                        <asp:Button ID="btnsave" Text="Save" runat="server" onclick="btnsave_Click" />
                                                                                
                                        <asp:Label ID="lblmess" Text="" runat="server" /></td>
                                                                               
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
   
    </div>
</asp:Content>