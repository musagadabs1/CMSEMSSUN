<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Toctrack.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Pages_Toctrack" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    <%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-tabMenu">
     <asp:Panel ID="pnlProgram" runat="server">
                    <div id="Program" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    TOC TRACK</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 17%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                   
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
                                                            <td>
                                                                <asp:Label ID="lblDegreeTypeId" runat="server" CssClass="" Text="Degree Type">
                                                                </asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDegreeType" runat="server" CssClass="textBox11" >
                                                                </asp:DropDownList>
                                                                
                                                            </td>
                                                           
                                                     
                                                            <td>
                                                                <asp:Label ID="lblTermID" runat="server" CssClass="" Text="Term"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlTerm" runat="server" CssClass="textBox11" AppendDataBoundItems="true" >
                                                                <asp:ListItem  Text="Select" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                           
                                                        </tr>
                                                     
                                                               <tr>
                                                               <td>
                                                               <asp:CheckBox ID="chkstud" runat="server" Text="By Student" Checked="false" />
                                                               </td>
                                                               <td>
                                                               <asp:TextBox ID="txtstud" Text="" runat="server"></asp:TextBox>
                                                               
                                                               </td>
                                                               </tr>                                      
                                                       
                                                       
                                                      
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnSaveProgrammore" runat="server" CssClass="" Text="Search" OnClick="btnSaveProgrammore_Click"
                                                                    ValidationGroup="PSubmit" />
                                                                <%--<asp:Button ID="Button11" runat="server" CssClass="" OnClick="btnPrint_Click" Text="Print"
                                                                    ValidationGroup="Back" />--%>
                                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="false"
                                                                    ShowMessageBox="True" ValidationGroup="PSubmit" Font-Size="Large" ForeColor="Red" />
                                                                <asp:Label ID="lblProgramMesag" runat="server" Font-Bold="true" Font-Size="12px"
                                                                    Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </colgroup>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                  <table>
                <tr>
                <td>
                <div>
               
                <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" EmptyDataText="There are no records to display."
                                OnRowDataBound="gvStudentList_RowDataBound" OnRowCommand="gvStudentList_RowCommand" Font-Size="Small"
                                AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" Width="100%">
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                                <FooterStyle CssClass="GridFooter" />
                                <RowStyle CssClass="GridItem" />
                                <Columns>

                                <asp:TemplateField HeaderText="View">
                                              <%--  <ItemTemplate>
                                                    <asp:HyperLink ID="lnk1" runat="server" Text="Preview" Target="_blank" NavigateUrl='<%#"~/Pages/PrintClient.aspx?studid="+ Eval("stud_id") %>'  onclick="changeColor(this);" ForeColor="Blue"></asp:HyperLink>
                                                </ItemTemplate>--%>
                                                  <ItemTemplate>
                                                 <asp:Button ID="btnViewTOC" runat="server" CssClass="" Text="View" OnClick="btnViewTOC_Click" CommandArgument='<%#Bind("stud_id") %>' CommandName="View"
                                                                            OnClientClick="document.getElementById('form1').target ='_blank';" />

 </ItemTemplate> <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="5%" />
                                            </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Stud_Id">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("stud_Id") %>' ID="lblstud" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="7%" />
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("student_name") %>' ID="lblname" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="25%" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Term">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("termname") %>' ID="lblterm" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="5%" />
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Program">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("Degreecode") %>' ID="lblprogram" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="5%" />
                                    </asp:TemplateField>
                                                             


                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Shift">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("Shift") %>' ID="lblshift" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="5%" />
                                    </asp:TemplateField>

                                    
                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Level">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("S_level") %>' ID="lbllevel" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="5%" />
                                    </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Course">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("Totalcourse") %>' ID="lblcourse" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="3%" />
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Tot.Cr">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("totalcredits") %>' ID="lblcredits" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="5%" />
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("status") %>' ID="lblstatus" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="5%" />
                                    </asp:TemplateField>

                                      </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                            </asp:GridView>
                        </div>

</td>
</tr>
</table>
                </div>
               
              


</div>
</div>

 </asp:Content>