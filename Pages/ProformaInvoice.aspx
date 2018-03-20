<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="ProformaInvoice.aspx.cs" Inherits="Pages_ProformaInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .kkTable100
        {
            margin: 1% 0 1% 0;
            box-shadow: 0px 2px 4px 0px rgba(0,0,0,0.10);
            border-radius: 10px;
            padding: 1px;
            height: 0px;
            font-size: xx-small;
            font-family: verdana;
            width: 100%;
            vertical-align: top;
        }
        .kkvalign-top
        {
            vertical-align: top;
            text-align: left;
        }
        
        .style1
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="kkTable100">
        <tr class="kkvalign-top">
            <td class="style1">
                <asp:LinkButton ID="lbGoBack" runat="server" Font-Size="Small" OnClick="lbGoBack_Click">Go Back</asp:LinkButton>
            </td>
        </tr>
        <tr class="kkvalign-top">
            <td>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="9px" ForeColor="Red"></asp:Label>
                <asp:GridView ID="GridFee_Group_Acedamic_Details" runat="server" AutoGenerateColumns="False"
                    Caption="Proforma Details" CellPadding="2" Font-Size="X-Small" ForeColor="#333333"
                    GridLines="Vertical" Height="32px" OnRowCommand="GridFee_Group_Acedamic_Details_RowCommand"
                    OnRowDataBound="GridFee_Group_Acedamic_Details_RowDataBound" PageSize="15" Style="margin-left: 5px;
                    margin-bottom: 10px" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <ItemTemplate>
                                <asp:Label ID="lblSN" runat="server" Text='<%# Bind("slno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProformaID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Proformaid" runat="server" Text='<%# Bind("Proforma_inv_id") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stu.ID">
                            <ItemTemplate>
                                <asp:Label ID="lblStudid" runat="server" Text='<%# Bind("Stu_Id") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="inv_id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblinv_id" runat="server" Text='<%# Bind("inv_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FGDID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblfgdid" runat="server" Text='<%# Bind("Fee_Group_Det_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fees Items">
                            <ItemTemplate>
                                <asp:Label ID="lblFees_Items_Id" runat="server" Text='<%#Bind("Fees_Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fees Group">
                            <ItemTemplate>
                                <asp:Label ID="lblFees_Pay_Typea" runat="server" Text='<%#Bind("Fees_Group_Desc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fees Pay Type">
                            <ItemTemplate>
                                <asp:Label ID="lblFees_Pay_Typeas" runat="server" Text='<%#Bind("Fees_Pay_Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Period Start">
                            <ItemTemplate>
                                <asp:Label ID="lblPeriod_id_start" runat="server" Text='<%#Bind("Start") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Period End">
                            <ItemTemplate>
                                <asp:Label ID="lblPeriod_id_end" runat="server" Text='<%#Bind("End") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Period">
                            <ItemTemplate>
                                <asp:Label ID="lblFees_Amountss" runat="server" Text='<%#Bind("Period") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fees Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblFees_Amount" runat="server" Text='<%#Bind("Fees_Amount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Level">
                            <ItemTemplate>
                                <asp:Label ID="lbllevel" runat="server" Text='<%# Bind("Level_Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Installment">
                            <ItemTemplate>
                                <asp:Label ID="lblinstallment" runat="server" Text='<%# Bind("installment_status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" CssClass="GridHeader" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" CssClass="grid-pagination" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" CssClass="GridRowOver" Font-Bold="True" ForeColor="#333333" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
