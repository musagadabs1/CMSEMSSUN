<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Exhibition.aspx.cs" Inherits="Pages_Exhibition" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 124px;
        }
        .style2
        {
            width: 124px;
            height: 33px;
        }
        .style3
        {
            height: 33px;
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
                        <table border="1" cellpadding="5" cellspacing="0">
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="LblAyear" Text="Ayear" runat="server"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="DDLAyear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLAyear_SelectedIndexChanged"
                                        Height="18px" Width="195px">
                                    </asp:DropDownList>
                                </td>
                            
                                <td class="style1">
                                    <asp:Label ID="LblMonth" Text="Month" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDlMonth_SelectedIndexChanged"
                                        Height="18px" Width="193px">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="LblExhibitionName" Text="Exhibition Name" runat="server"></asp:Label>
                                </td>
                                <td colspan ="3">
                                    <asp:DropDownList ID="DDLExp" runat="server" OnSelectedIndexChanged="DDLExp_SelectedIndexChanged"
                                        AutoPostBack="True" Height="18px" Width="580px">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="LblDate" Text="Date" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtDate" runat="server" Height="16px" Width="191px" />
                                    <br />
                                     <asp:TextBox ID="TxtID" runat="server" Visible="false"  />
                                </td>
                            
                                <td class="style1">
                                    <asp:Label ID="LblVenue" Text="Venue" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtVenue" runat="server" Height="16px" Width="191px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="LblRequiredStaff" Text="Requied Staff" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtReqStaff" runat="server" Height="16px" Width="191px" />
                                </td>
                           
                                <td class="style1">
                                    <asp:Label ID="LblStand" Text="Stand" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtStand" runat="server" Height="16px" Width="191px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" Visible ="false"
                                        onclick="BtnUpdate_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div id="Div1">
                <div class="form-fieldset-wrapper">
                    <div class="form_round_border">
                        <div class="form_round_heading_row">
                            <!--this is heading row-->
                            <h2 class="slide_top">
                                Exhibition
                            </h2>
                        </div>
                        <div class="form-fieldset-wrapper-mid-inner9">
                            <asp:GridView ID="GrdExhibition" AutoGenerateColumns="false" runat="server" Style="margin-left: 5px;
                                margin-bottom: 10px; top: 0px; left: 0px; width: 99%;">
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("RN")%>
                                            <asp:HiddenField ID="hid_ID" runat="server" Value='<%#Eval("ID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AYear" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("AYear")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Month" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("Month")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EventTitle" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("EventTitle")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("Date")%>
                                            <asp:HiddenField ID="hid_Date" runat="server" Value='<%#Eval("Date")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Venue" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("Venue")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stand" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("Stand")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="EDIT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                      <ItemTemplate>
                                         <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("ID")%>'
                                            OnClientClick="return confirm('Do you want to Edit?')" Text="Edit" OnClick="EditExhibition">
                                        </asp:LinkButton>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                     <ItemTemplate>
                                        <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("ID")%>'
                                            OnClientClick="return confirm('Do you want to delete?')" Text="Delete" OnClick="DeleteExhibition">
                                        </asp:LinkButton>
                                        </ItemTemplate>
                                         </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
