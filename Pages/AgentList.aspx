<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForMasters.master" AutoEventWireup="true"
    CodeFile="AgentList.aspx.cs" Inherits="Pages_AgentList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnAdd">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Agent Details</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding: 5px 5px; width: 18%">
                                    Agency Name
                                </td>
                                <td style="width: 37%; padding: 5px 5px;">
                                    <asp:TextBox ID="txtAgencyName" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAgencyName"
                                        CssClass="" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                        Display="Dynamic" ValidationGroup="CSubmit" />
                                    <asp:TextBox runat="server" ID="txthdn_Id" Visible="false" />
                                </td>
                                <td style="padding: 5px 5px; width: 13%">
                                    Agent Name
                                </td>
                                <td style="width: 37%; padding: 5px 5px;">
                                    <asp:TextBox ID="txtAgentName" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAgentName"
                                        CssClass="" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                        Display="Dynamic" ValidationGroup="CSubmit" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Agent Type
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:DropDownList ID="ddlNationality" runat="server" CssClass="textBox11" Width="202px">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 3px 5px;">
                                    State
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:DropDownList ID="ddlState" Visible="false" runat="server" CssClass="textBox11">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtState" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtState"
                                        CssClass="" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                        Display="Dynamic" ValidationGroup="CSubmit" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 3px 5px;">
                                    Phone
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtPhone" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                    <asp:CompareValidator ID="CvtxtPhone" runat="server" Operator="DataTypeCheck" Type="Integer"
                                        ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Value must be a number" />
                                </td>
                                <td style="padding: 3px 5px;">
                                    Email
                                </td>
                                <td style="padding: 3px 5px;">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                                        CssClass="" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                        Display="Dynamic" ValidationGroup="CSubmit" />
                                    <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
                                        runat="server" Display="Dynamic" ErrorMessage="Invalid" ValidationGroup="CSubmit" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                             <tr>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    Date Of Agreement
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="txtDateOfAgreement" runat="server" Width="100px" CssClass="textBox1"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txt_JoinDateCalendarExtender" Format="dd/MM/yyyy" CssClass="MyCalendar"
                                        TargetControlID="txtDateOfAgreement" runat="server">
                                    </cc1:CalendarExtender>
                                </td>                           
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    Validity
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="txtValidity" runat="server" Width="100px" CssClass="textBox1"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" CssClass="MyCalendar"
                                        TargetControlID="txtValidity" runat="server">
                                    </cc1:CalendarExtender>
                                </td>                              
                            </tr>
                            <tr>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    Target
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="txtTarget" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                </td>                           
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    Website
                                </td>
                                <td style="vertical-align:top; padding: 3px 5px;">
                                    <asp:TextBox ID="txtWebsite" runat="server" Width="200px" CssClass="textBox1"></asp:TextBox>
                                </td>                              
                            </tr>
                            <tr>
                             <td style="vertical-align:top;padding: 3px 5px;">
                                    Remarks
                                </td>
                                <td style="padding: 3px 5px;" colspan="4">
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="50px" Width="195px" CssClass="textBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn" OnClick="btnAdd_Click1" Text="Add"
                                        ValidationGroup="CSubmit" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn" OnClick="btnUpdate_Click1"
                                        Text="Update" ValidationGroup="CSubmit" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" OnClick="btnCancel_Click1"
                                        Text="Cancel" />
                                         <asp:Button ID="BtnViewReport" runat="server" CssClass="btn" OnClick="BtnViewReport_Click1"
                                        Text="View Report"  Visible="true" OnClientClick="document.getElementById('form1').target ='_blank';" />
                                    <asp:Label ID="lblMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""></asp:Label>
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
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Agent List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner9">
                        <!--start list member blocks-->
                    </div>
                    <div style="width: 693px; margin: 0px 10px 0px 10px; padding-top: 5px; overflow: auto">
                        <div>
                            <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" EmptyDataText="There are no records to display."
                                OnRowDataBound="gvStudentList_RowDataBound" OnRowCommand="gvStudentList_RowCommand"
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
                                     <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblEdit" runat="server" Text='Edit' CommandArgument='<%#Bind("Agentid") %>'
                                                CommandName="EditDetails"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Agency Name">
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Bind("AgencyName") %>' ID="lblAgencyName" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="25%" />
                                        <ItemStyle HorizontalAlign ="Left" Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Agent Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgentName" runat="server" Text='<%#Bind("AgentName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Left" Width="15%"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Agent Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNationality" runat="server" Text='<%#Bind("MediaSource") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Left" Width="15%"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="State">
                                        <ItemTemplate>
                                            <asp:Label ID="lblState" runat="server" Text='<%#Bind("State") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Left" Width="15%"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="false" HeaderText="Phone">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%#Bind("Phone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" Width="15%"  />
                                         <ItemStyle HorizontalAlign ="Center" Width="15%"  />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%#Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" />
                                         <ItemStyle HorizontalAlign ="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="Website">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWebsite" runat="server" Text='<%#Bind("Website") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign ="Center" />
                                         <ItemStyle HorizontalAlign ="Left" />
                                    </asp:TemplateField>--%>
                                   
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
                <div class="form-fieldset-wrapper-bottom">
                </div>
            </div>
        </div>
        <!--Ended Div of form fieldset wrapper middle part of left and right border-->
        <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
    </asp:Panel>
</asp:Content>
