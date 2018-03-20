<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForCallManagement.master"
    AutoEventWireup="true" CodeFile="SendBulkMail.aspx.cs" Inherits="Pages_SendBulkMail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function selectAll(Checkbox) {
            var gvStudentList = document.getElementById("<%=gvStudentList.ClientID %>");
            for (i = 1; i < gvStudentList.rows.length; i++) {
                gvStudentList.rows[i].cells[5].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    Send Bulk Email</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 695px">
                      
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
                                Category
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="textBoxsendEmail" 
                                    Width="225px" AutoPostBack="True" 
                                    onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Degree
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDegree" runat="server" CssClass="textBoxsendEmail" 
                                    Width="225px" AutoPostBack="True" 
                                    onselectedindexchanged="ddlDegree_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                From Email
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromEmail" runat="server" Text="admissions@skylineuniversity.ac.ae" CssClass="textBox1" Width="225px"></asp:TextBox>
                            </td>
                            <td>
                                Subject
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server" Text="Registration Details" CssClass="textBox1" Width="225px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Send Email
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEmail" runat="server"  />
                            </td>
                            <td>
                                Send SMS
                            </td>
                            <td>
                                <asp:CheckBox ID="chkSendSMS" runat="server" />
                            </td>
                        </tr>
                        <asp:Panel ID="pnlSms" runat="server" Visible="true">
                        <tr>
                        
                            <td>
                                Sms Text
                            </td>
                            <td>
                                <asp:TextBox ID="txtSmsContent" runat="server" Text="" TextMode="MultiLine" Height="40px"  Width="225px"></asp:TextBox>
                            </td>
                        </tr>
                        </asp:Panel>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSend" runat="server" CssClass="" Text="Send" OnClick="btnSend_Click" />
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
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
    <asp:Panel ID="pnlEmailContent" runat="server" Visible="true">
    <div id="all-form-wrap">
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <htmleditor:editor runat="server" id="editor" height="250px" autofocus="true" width="100%" />
                <div style="height: 7px;">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </asp:Panel>
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Student List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--start list member blocks-->
                       <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="list-member-block" style="width: 693px">
                                        <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                            EmptyDataText="There are no records to display." OnRowDataBound="gvStudentList_RowDataBound"
                                            GridLines="Both" CssClass="grid-view" >
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.N.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student Name" SortExpression="Name">
                                                    <ItemTemplate>                                                    
                                                        <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("LinkId") %>'
                                                            Text='<%#Bind("Name") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Degree" SortExpression="DegreeType">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDegree" runat="server" Text='<%# Bind("DegreeType_Desc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Bind("EmailId") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdMobile" runat="server" Value='<%#Bind("MobileNo") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Mobile" SortExpression="MobileNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Bind("MobileNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                 
                                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="selectAll(this);" Text="All" />
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" ></asp:CheckBox> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                            <SelectedRowStyle CssClass="GridRowOver" />
                                            <EditRowStyle />
                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
    </div>
</asp:Content>
