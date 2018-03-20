<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterForMasters.master" CodeFile="Airticket.aspx.cs" Inherits="Pages_Airticket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnAdd">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Air ticket </h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding: 5px 5px; width: 18%">
                               Country <span style="color:Red">*</span>
                                </td>
                                <td style="width: 37%; padding: 5px 5px;">
                                   <asp:DropDownList ID="ddlNationality" runat="server" CssClass="textBox9" 
                                        AutoPostBack="true" 
                                        onselectedindexchanged="ddlNationality_SelectedIndexChanged">
                                                                                    
                                        </asp:DropDownList><asp:TextBox runat="server" ID="txthdn_Id" Visible="false" />
                                    </td>
                                <td style="padding: 5px 5px; width: 13%">
                                   Amount (AED) <span style="color:Red">*</span>
                                </td>
                                <td style="width: 37%; padding: 5px 5px;">
                                    <asp:TextBox ID="txtamount" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtamount"
                                        CssClass="" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"  
                                        Display="Dynamic" ValidationGroup="CSubmit" />
                                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender64" runat="server" FilterType="Numbers,Custom"
                                                                        ValidChars="." TargetControlID="txtamount">
                                                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="padding: 3px 5px;">
                                   From Date (dd/mm/yyyy)<span style="color:Red">*</span>
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="Txtfromdate" runat="server" Width="100px" CssClass="textBox1"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" CssClass="MyCalendar" 
                                        TargetControlID="Txtfromdate" runat="server">
                                    </cc1:CalendarExtender>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,Custom"
                                                                        ValidChars="/" TargetControlID="Txtfromdate">
                                                                    </cc1:FilteredTextBoxExtender>
                                </td> 
                                <td style="padding: 3px 5px;">
                                   To Date (dd/mm/yyyy) <span style="color:Red">*</span>
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="TxtTodate" runat="server" Width="100px" CssClass="textBox1"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" CssClass="MyCalendar"
                                        TargetControlID="TxtTodate" runat="server">
                                    </cc1:CalendarExtender>
                                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers,Custom"
                                                                        ValidChars="/" TargetControlID="TxtTodate">
                                                                    </cc1:FilteredTextBoxExtender>
                                </td> 
                            </tr>
                             <tr>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    Minimum No <span style="color:Red">*</span>
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="Txtmin" runat="server" Width="20px" CssClass="textBox1" MaxLength="2"></asp:TextBox>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                                                        TargetControlID="Txtmin">
                                                                    </cc1:FilteredTextBoxExtender>
                                </td>          
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    Maximum No <span style="color:Red">*</span>
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="Txtmax" runat="server" Width="20px" CssClass="textBox1" MaxLength="2"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                                                        TargetControlID="Txtmax">
                                                                    </cc1:FilteredTextBoxExtender>
                                </td>                             
                            </tr>
                           
                            <tr>
                             <td style="vertical-align:top;padding: 3px 5px;">
                                    Remarks
                                </td>
                                <td style="padding: 3px 5px;" colspan="4">
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="50px" Width="195px" CssClass="textBox1"></asp:TextBox>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers,Custom,UppercaseLetters, LowercaseLetters"
                                                                     ValidChars=".,@-"   TargetControlID="txtRemarks">
                                                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn" OnClick="btnAdd_Click1" Text="Add"
                                        ValidationGroup="CSubmit" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn" OnClick="btnUpdate_Click1"
                                        Text="Update" ValidationGroup="CSubmit" />
                                   <asp:HyperLink ID="hdnviewreport"  Font-Size="Medium" runat="server" CssClass="btn" Target="_blank" Text="View Report" ></asp:HyperLink>
                                       <%--  <asp:Button ID="BtnViewReport" runat="server" CssClass="btn" OnClick="BtnViewReport_Click1"
                                        Text="View Report"  Visible="true" />--%>
                                    <asp:Label ID="lblMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""></asp:Label>
                                </td> </tr>
                                <tr><td colspan="4">Note: For View Report select country for Individial orchose Select option from country dropdown for all</td></tr>
                           
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
                       Airticket Entered details</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--start list member blocks-->
                    </div>
                    <div style="width: 693px; margin: 0px 10px 0px 10px; padding-top: 5px; overflow: auto">
                        <div>
                         <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" EmptyDataText="There are no records to display."
                                OnRowDataBound="gvStudentList_RowDataBound" OnRowCommand="gvStudentList_RowCommand" Font-Size="Small"
                                AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" Width="100%">
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                                <FooterStyle CssClass="GridFooter" />
                                <RowStyle CssClass="GridItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.N.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSN" runat="server"></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Center" Width="5%" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblEdit" runat="server" Text='Edit' CommandArgument='<%#Bind("airid") %>'
                                                CommandName="EditDetails"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblDelete" runat="server" Text='Delete' CommandArgument='<%#Bind("airid") %>'
                                              OnClientClick="return confirm('Are You sure to Delete');"   CommandName="DeleteDetails"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Nationality">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("nationalityname") %>' ID="lblnationName" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="25%" />
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Amount(AED)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Bind("amount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Left" Width="15%"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Fromdate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfromdate" runat="server" Text='<%#Bind("fromdate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Left" Width="15%"  />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Todate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTOdate" runat="server" Text='<%#Bind("Todate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Left" Width="15%"  />
                                    </asp:TemplateField>


                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="false" HeaderText="MinNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmin" runat="server" Text='<%#Bind("minno") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Center" Width="15%"  />
                                    </asp:TemplateField>
                                     <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="false" HeaderText="MaxNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmax" runat="server" Text='<%#Bind("maxno") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Center" Width="15%"  />
                                    </asp:TemplateField>

                                     <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="false" HeaderText="Createdby">
                                        <ItemTemplate>
                                            <asp:Label ID="lblempname" runat="server" Text='<%#Bind("name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Center" Width="15%"  />
                                    </asp:TemplateField>

                                     <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="false" HeaderText="Createddate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcreateddate" runat="server" Text='<%#Bind("createddate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Center" Width="15%"  />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="false" HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblremarks" runat="server" Text='<%#Bind("remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Center" Width="15%"  />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
                <div class="form-fieldset-wrapper-bottom">
                </div>
            </div>
        </div>
        <!--Ended Div of form fieldset wrapper middle part of left and right border-->
        <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
    </asp:Panel>
</asp:Content>