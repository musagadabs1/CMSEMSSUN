<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LicenceRenewal.aspx.cs" Inherits="Pages_LicenceRenewal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
 <script type="text/javascript">
     function Search_Gridview(strKey, strGV) {
         var strData = strKey.value.toLowerCase().split(" ");
         var tblData = document.getElementById(strGV);
         var rowData;
         for (var i = 1; i < tblData.rows.length; i++) {
             rowData = tblData.rows[i].innerHTML;
             var styleDisplay = 'none';
             for (var j = 0; j < strData.length; j++) {
                 if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                     styleDisplay = '';
                 else {
                     styleDisplay = 'none';
                     break;
                 }
             }
             tblData.rows[i].style.display = styleDisplay;
         }
     }    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        LICENCE RENEWAL</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table>
                        <tr style="display:none">
                        <td>
                        <asp:TextBox ID="TxtID" runat="server" ></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Course Type
                        </td>
                        <td>
                        <asp:DropDownList ID="DrpCourseType" runat="server" CssClass="textBox11" ></asp:DropDownList>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Valid From
                        </td>
                        <td>
                        <asp:TextBox ID="txtValidFrom" runat="server"  CssClass="textBox1"></asp:TextBox>
                         <asp:ImageButton ID="ImgValidFrom" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:calendarextender id="ceValidFrom" runat="server" cssclass="MyCalendar" targetcontrolid="txtValidFrom"
                                    popupbuttonid="ImgValidFrom"  Format="dd/MM/yyyy" >
                                </cc1:calendarextender>
                                <cc1:filteredtextboxextender id="FilteredTextBoxExtenderValidFrom" runat="server" filtertype="Custom,Numbers"
                                    validchars="/,-" targetcontrolid="txtValidFrom">
                                </cc1:filteredtextboxextender>
                        </td>
                         <td>
                        Valid To
                        </td>
                        <td>
                        <asp:TextBox ID="txtValidTo" runat="server" ></asp:TextBox>
                        <asp:ImageButton ID="ImgValidTo" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:calendarextender id="CeValidTo" runat="server" cssclass="MyCalendar" targetcontrolid="txtValidTo"
                                    popupbuttonid="ImgValidTo"  Format="dd/MM/yyyy" >
                                </cc1:calendarextender>
                                <cc1:filteredtextboxextender id="FilteredTextBoxExtenderValidTo" runat="server" filtertype="Custom,Numbers"
                                    validchars="/,-" targetcontrolid="txtValidTo">
                                </cc1:filteredtextboxextender>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Description/Blog Link
                        </td>
                        <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                         <td>
                        Remarks
                        </td>
                        <td>
                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Soft Copy
                        </td>
                        <td>
                        <cc1:AsyncFileUpload ID="DOC_AsyncDocUPload" runat="server" FailedValidation="False"
                                                                    BackColor="#E3E2E3" />
                        </td>
                        <td>
                        <asp:Button ID="BtnSave" runat="server" Text="SAVE" onclick="BtnSave_Click" />
                       <%-- </td>
                         <td>--%>
                       <%-- <asp:Button ID="BtnUpdate" runat="server" Text="UPDATE" />--%>
                        </td>
                        <td>
                        
                        </td>
                        </tr>
                        <tr>
                        <td colspan="2">
                        <asp:label ID="LblDisplayMessage" runat="server" ForeColor="Red"></asp:label>
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
          <div id="Div1">
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                       Course List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <div>
                        
                          Search:  <asp:TextBox runat="server" ID="txtSearch" placeholder="Search Here" style="background-color:White "
                                onkeyup="Search_Gridview(this, 'GrvGrid')" Height="20px" Width="627px"></asp:TextBox>
                        </div>

                    <asp:GridView ID="GrvGrid" ClientIDMode="Static" OnRowDataBound="GrvGrid_RowDataBound" OnRowCommand="GrvGrid_RowCommand" 
                             AutoGenerateColumns="false" runat="server" Style="margin-left: 5px;  
                             margin-bottom: 10px; top: 0px; left: 0px; width: 100%;  "  >
                              
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />                             
                              <%--  <AlternatingRowStyle CssClass="GridAltItem" />--%>
                                <Columns> 
                                            
                              <asp:TemplateField HeaderText="S.N.">
                                <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Course Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourseType" runat="server" Text='<%#Bind("CourseType") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Valid From">
                                        <ItemTemplate>
                                            <asp:Label ID="lblValidFrom" runat="server" Text='<%#Bind("ValidFrom") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Valid To">
                                        <ItemTemplate>
                                            <asp:Label ID="lblValidTo" runat="server" Text='<%#Bind("ValidTo") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="File Details" Visible ="false" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Bind("FileDetails") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Description" Visible ="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDescription" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Bind("CreatedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" OnClientClick="javascript: return confirm('Are you sure you want to edit?')"
                                                CommandArgument='<%#Eval("LicenseID")%>' Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDownload" runat="server" CommandName="Download"
                                                CommandArgument='<%#Eval("LicenseID")%>' Text="Download"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                        </Columns>
                                  <emptydatarowstyle  HorizontalAlign="Center" Font-Bold="true"  backcolor="LightBlue"  forecolor="Red"/>
                                    <emptydatatemplate>
                                    No Data Found
                                    </emptydatatemplate>
                            </asp:GridView>
                     </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
              
        </div>
</asp:Content>

