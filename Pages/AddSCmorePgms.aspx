<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"  CodeFile="AddSCmorePgms.aspx.cs" Inherits="Pages_AddSCmorePgms" %>
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
                                    Add More Program</h1>
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
                                                    <td colspan="4"> <asp:Label ID="lblreg" runat="server" Text=""></asp:Label></td>
                                                    
                                                    </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDegreeID" runat="server" CssClass="" Text="Degree Program" Visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rdbProgramRegular" runat="server" Text="Week Day" CssClass="textBox1" Checked="true"
                                                                    GroupName="DegreeId" AutoPostBack="True" OnCheckedChanged="rdbProgramRegular_CheckedChanged" />
                                                                <asp:RadioButton ID="rdbProgramWeekend" runat="server" Text="Weekend" CssClass="textBox1"
                                                                    GroupName="DegreeId" AutoPostBack="True" OnCheckedChanged="rdbProgramWeekend_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDegreeTypeId" runat="server" CssClass="" Text="Degree Type">
                                                                </asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDegreeType" runat="server" CssClass="textBox11" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlDegreeType_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDegreeType"
                                                                    CssClass="" ErrorMessage="Degree Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="PSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCourseType" runat="server" CssClass="" Text="Course Type"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="textBox11" 
                                                                    AutoPostBack="True" onselectedindexchanged="ddlCourseType_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCourseType"
                                                                    CssClass="" ErrorMessage="Course Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="PSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                                                                              
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTermID" runat="server" CssClass="" Text="Term"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlTerm" runat="server" CssClass="textBox11" AutoPostBack="True" onselectedindexchanged="ddlCourseType_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblShift" runat="server" CssClass="" Text="Shift"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlShift" runat="server" CssClass="textBox11" OnSelectedIndexChanged="ddlCourseType_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlShift"
                                                                    CssClass="" ErrorMessage="Shift Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="PSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                     

                                                        <asp:Panel ID="pnlSC" runat="server" Visible="true">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label34" runat="server" CssClass="" Text="From Date"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSCFromDay" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCFromMonth" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCFromYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender34" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCFromYear" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender35" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCFromMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender36" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCFromDay" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCFromMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender61" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCFromDay">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender62" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCFromYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label35" runat="server" CssClass="" Text="To Date"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSCToDay" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCToMonth" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCToYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender37" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCToYear" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender38" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCToMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender39" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCToDay" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender63" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCToMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender64" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCToDay">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender65" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCToYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                                                                        <td>
                                                                <asp:Label ID="lblType" runat="server" CssClass="" Text="Fee Waiver Category"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="textBox11" Width="142px"
                                                                    OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="ddlType"
                                                                    CssClass="" ErrorMessage="Category Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="FINANCESubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDiscountType" runat="server" CssClass="" Text="Fee Waiver Type"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td colspan="1">
                                                                <asp:DropDownList ID="ddlDiscountType" runat="server" CssClass="textBox11" Width="143px"
                                                                    OnSelectedIndexChanged="ddlDiscountType_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDiscountType"
                                                                    CssClass="" ErrorMessage="Fee Waiver Type Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="FINANCESubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            </tr>
                                                            <tr>
                                                              <td>
                                                                <asp:Label ID="Label1" runat="server" CssClass="" Text="Percentage"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                                         <td>
                                                                <asp:DropDownList ID="ddlPercentage" runat="server" CssClass="textBox11" Width="143"
                                                                OnSelectedIndexChanged="ddlPercentage_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                                                                                       
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblDiscount" runat="server" CssClass="" Text="Fee Waiver"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDiscount" Text="0"  runat="server" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="." TargetControlID="txtDiscount">
                                                                </cc1:FilteredTextBoxExtender>
                                                                
                                                              
                                                            </td>

                                                            </tr>

                                                               <tr> 
                                                        <td>  <asp:Label ID="lblTotalFees" runat="server" CssClass="" Text="Total Fees"  Visible="true"></asp:Label>
                                                      </td>    <td>    <asp:TextBox ID="txtTotalFees" runat="server" CssClass="textBox1" Text="0" ReadOnly="true" Visible="true"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="." TargetControlID="txtTotalFees">
                                                                </cc1:FilteredTextBoxExtender>
                                                          </td>    
                                                          <td>
                                                                <asp:Label ID="Label52" runat="server" CssClass="" Text="Net Payable"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNetFees" runat="server"  Text="0" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                            </td> 
                                                          <td>
                                                          
                                                                <asp:TextBox ID="txtFees"  Visible="false" Text="0" runat="server" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="." TargetControlID="txtFees">
                                                                </cc1:FilteredTextBoxExtender>
                                                            </td> 
                                                          
                                                       
                                                       
                                                           
                                                            </tr>
                                                       
                                                       <asp:Panel ID="pnlno" Visible="false" runat="server">

                                                            <tr>
                                                                <td>
                                                                    Reading
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlReading" runat="server" CssClass="textBox11" TabIndex="2" >
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    Writing
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlWriting" runat="server" CssClass="textBox11" TabIndex="2">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Listening
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlListening" runat="server" CssClass="textBox11" TabIndex="2">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    Speaking
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSpeaking" runat="server" CssClass="textBox11" TabIndex="2">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            </asp:Panel>
                                                        </asp:Panel>
                                                       
                                                      
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnSaveProgrammore" runat="server" CssClass="" Text="Update" OnClick="btnSaveProgrammore_Click"
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
                                    <asp:TemplateField HeaderText="S.N.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSN" runat="server"></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign ="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign ="Center" Width="5%" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblEdit" runat="server" Text='Edit' CommandArgument='<%#Bind("id") %>'
                                                CommandName="EditDetails"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblDelete" runat="server" Text='Delete' CommandArgument='<%#Bind("id") %>'
                                              OnClientClick="return confirm('Are You sure to Delete');"   CommandName="DeleteDetails"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>


                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Program">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("program") %>' ID="lblprogram" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="25%" />
                                    </asp:TemplateField>

                                  


                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Percentage">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("percentage") %>' ID="lblpercentage1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="25%" />
                                    </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Fees">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("fees") %>' ID="lblfees1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="25%" />
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="NetFees">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("netfees") %>' ID="lblnetfees2" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="25%" />
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
                </td>
  </tr>
  <tr>
  <td>
  <asp:Label ID="lblMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""></asp:Label>
  
  </td>
  
  </tr>
              
                <tr>
                <td>
                               <div>
                <asp:GridView ID="gvAddedFeeGroup" runat="server" AutoGenerateColumns="false" DataKeyNames="Fees_Group_Id"
        EmptyDataText="There are no records to display."
        GridLines="Both" CssClass="grid-view" 
       Width="241px" ShowFooter="true" 
        onrowdatabound="gvAddedFeeGroup_RowDataBound">
        <FooterStyle CssClass="GridFooter" />
        <RowStyle CssClass="GridAltItem" />
        <Columns>
            <asp:TemplateField HeaderText="Added Fee Group" HeaderStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" Visible="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblFeeGroup" runat="server" Text='<%#Bind("Fees_Group_Code") %>'></asp:Label>
                    <asp:HiddenField ID="hdFeeGroupId" runat="server" Value='<%#Bind("Fees_Group_Id") %>' />
                    <asp:HiddenField ID="hdTypeId" runat="server" Value='<%#Bind("TypeId") %>' />
                       <asp:HiddenField ID="hddetailid" runat="server" Value='<%#Bind("detailsid") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterUName" runat="server" Text="Total"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>                                   
            <asp:TemplateField HeaderText="Amt" HeaderStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" Visible="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Amount") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterUNamea" runat="server" Text="40"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
        <SelectedRowStyle CssClass="GridRowOver" />
        <EditRowStyle />
        <AlternatingRowStyle CssClass="GridAltItem" />
            <FooterStyle CssClass="GridAltItem" />
    </asp:GridView>
 </div>
  </td>
  </tr>
  <tr>
  <td><asp:Button ID="btnfinalise" runat="server"  Text="Finalise Debits" 
          onclick="btnfinalise_Click" /> </td>
  </tr>

  </table>




</div>
</div>
</div>
 </asp:Content>