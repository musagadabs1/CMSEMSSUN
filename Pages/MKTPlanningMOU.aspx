<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MKTPlanningMOU.aspx.cs" Inherits="Pages_MKTPlanningMOU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
        function ChkSelectallClick(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.GrvGrid.ClientID %>');
            var TargetChildControl = "chkRow";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
            CheckBoxCount();
        }


        function CheckBoxCount() {
            return;
        }

        function ChkSelectallClickDelete(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.GrvGrid.ClientID %>');
            var TargetChildControl = "chkDelete";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
            CheckBoxCount();
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
                        MKT MOU PLANNING</h2>
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
                        Academic year
                        </td>
                        <td>
                        <asp:DropDownList ID="DrpAcyear" runat="server" CssClass="textBox11"  AutoPostBack="true"
                                onselectedindexchanged="DrpAcyear_SelectedIndexChanged" ></asp:DropDownList>
                        </td>
                       
                        <td>
                        Category
                        </td>
                        <td>
                         <asp:DropDownList ID="DrpCategory" runat="server" CssClass="textBox11"  AutoPostBack="true"
                                onselectedindexchanged="DrpCategory_SelectedIndexChanged" ></asp:DropDownList>
                        </td>
                       
                        </tr>
                        <tr>
                        <td>
                        
                        </td>
                        <td>
                        <asp:Button ID="BtnSave" runat="server" Text="SAVE" onclick="BtnSave_Click" />
                    
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
                       Subcategory List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                  
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
                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sub Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubcategory" runat="server" Text='<%#Bind("Subcategory") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField >

                                    <HeaderTemplate>
                                           <asp:CheckBox  HeaderText="Add" ID="chkAllRow"  Text="select" runat="server" onclick="javascript:ChkSelectallClick(this);"  />
                                    </HeaderTemplate> 

                                <ItemTemplate>                                    
                                    <asp:CheckBox ID="chkRow" runat="server"  Checked='<%#Convert.ToBoolean(Eval("Value")) %>' />    
                                     <asp:HiddenField ID="HdnCategoryID" runat="server" Value='<%#Eval("CategoryID")%>' /> 
                                     <asp:HiddenField ID="HdnValue" runat="server" Value='<%#Eval("Value")%>' />  
                                      <asp:HiddenField ID="HdnPlanningID" runat="server" Value='<%#Eval("PlanningID")%>' />    
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField >

                                    <HeaderTemplate>
                                           <asp:CheckBox  HeaderText="Remove" ID="chkDeleteAllRow" Text="Remove" runat="server"   onclick="javascript:ChkSelectallClickDelete(this)" />
                                    </HeaderTemplate> 

                                <ItemTemplate>                                    
                                    <asp:CheckBox ID="chkDelete" runat="server"  />
                                  
                                </ItemTemplate>
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
            <!--Div started f-->
</asp:Content>

