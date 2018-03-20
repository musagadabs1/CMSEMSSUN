<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Calldetails.aspx.cs" Inherits="Pages_Calldetails" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="all-form-wrap">
  <div class="form-fieldset-wrapper">
  </div>
   <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                       CAll DETAILS </h2>
                </div>
   <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="1" cellpadding="0" cellspacing="0">
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
   <div class="form-fieldset-wrapper-bottom">
   </div>
</div>
</asp:Content>
