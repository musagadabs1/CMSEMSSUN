<%@ Page Language="C#" MasterPageFile="~/ReportMaster.master" AutoEventWireup="true"
    CodeFile="MisCOECReport.aspx.cs" Inherits="Pages_MisCOECReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 79px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <div class="form_round_border">
                    <div class="form_round_heading_row">
                        <!--this is heading row-->
                        <h2 class="slide_top">
                            Exhibition
                        </h2>
                    </div>
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <table>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="Label1" runat="server" Text="Report Type"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="DDLReport" runat="server" AutoPostBack="True" Height="18px"
                                        Width="195px"  CssClass="textBox11">
                                        <asp:ListItem Text="Exhibition" Value="Exhibition"></asp:ListItem>
                                        <asp:ListItem Text="Farirs & Events" Value="Farirs&Events"></asp:ListItem>
                                        <asp:ListItem Text="MKT Visits" Value="MKTVisits"></asp:ListItem>
                                        <asp:ListItem Text="Events & Workshop" Value="Events&Workshop"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                          
                                <td class="style1">
                                    <asp:Label ID="LblAyear" runat="server" Text="Ayear"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="DDLAyear" runat="server" AutoPostBack="True" Height="18px"
                                        Width="195px" OnSelectedIndexChanged="DDLAyear_SelectedIndexChanged"  CssClass="textBox11">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="LblFromYear" runat="server" Text="From Year"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="DrpFromYear" runat="server" AutoPostBack="True" Height="18px"
                                        Width="193px"  CssClass="textBox11">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                           <%-- </tr>
                            <tr>--%>
                                <td class="style1">
                                    <asp:Label ID="LblToyear" runat="server" Text="To Year"></asp:Label>
                                </td>
                                <td>
                                  <%--  <asp:TextBox ID="TxtTyear" runat="server"></asp:TextBox>--%>
                                   <asp:DropDownList ID="DrpToYear" runat="server" AutoPostBack="True" Height="18px"
                                        Width="193px"  CssClass="textBox11">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="LblFromMonth" runat="server" Text="From Month"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDFMonth" runat="server" AutoPostBack="True" Height="18px"
                                        Width="193px"  CssClass="textBox11">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                          <%--  </tr>
                            <tr>--%>
                                <td class="style1">
                                    <asp:Label ID="LblTMonth" runat="server" Text="To Month"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLTMonth" runat="server" AutoPostBack="True" Height="18px"
                                        Width="193px"  CssClass="textBox11">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                            <td colspan="3" align="center">
                             <asp:Button ID="BtnReport" runat="server" Text="REPORT" 
                                    onclick="BtnReport_Click" />
                             </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--    </div> --%>
</asp:Content>
