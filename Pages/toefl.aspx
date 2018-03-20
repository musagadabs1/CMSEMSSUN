<%@ Page Title=""  MasterPageFile="~/MasterPage.master" EnableEventValidation="false" 
    AutoEventWireup="true" Language="C#"  CodeFile="toefl.aspx.cs" Inherits="Pages_toefl" %>        
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                       TOEFL DETAILS</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="1" cellpadding="0" cellspacing="0">
                       <%-- <tr>
                        <td><b><asp:Label ID="lbl_type" runat="server"  Text="Select Type of Persons"></asp:Label></b></td>
                        <td align="left"  >
                        <asp:DropDownList ID="ddl_list" runat="server"  Width="50%" >
                        <asp:ListItem Text="---Select---" Value =""></asp:ListItem>
                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="F" ></asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        </tr>--%>
                         
                          <tr>
                          <td align = "center" class="style2" colspan="2" >
                          <asp:Button ID="btnShow" CssClass="textBox11" Text = "Show" runat="server"  OnClick="btnShow_Click"  Width="81px" >
                                </asp:Button>
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
<%--    </asp:Panel>--%>
</asp:Content>
