<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FaresandEvents.aspx.cs" Inherits="Pages_FaresandEvents" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(

    function () {
      //  $('[id*=txt_title]').hide();
        $('input[type="radio"]').click(function () {
           
            if ($(this).val() == 'Radbut2') {
                $('[id*=ddl_Title]').hide();
                $('[id*=txt_title]').show();
            }
           

            if ($(this).val() == 'Radbut1') {
                $('[id*=ddl_Title]').show();
                $('[id*=txt_title]').hide();
            }

        });
    });

</script>


<style type="text/css">
        .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div2">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    CAREER FAIRS AND EVENTS</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <table width="500px" border="1">
                        <tr>
                            <td>
                                <%-- <asp:RadioButtonList ID="Rad_butlst1" runat="server"  Font-Bold="true"  RepeatDirection="Horizontal" Width="50%" >
        <asp:ListItem  Text="Pull from CMS" Value="1" ></asp:ListItem>
        <asp:ListItem Text ="Manual Entry" Value="2" ></asp:ListItem>
        </asp:RadioButtonList>--%>
                                <asp:RadioButton      ID="Radbut1" runat="server" Text="Pull from Emscms" GroupName="AA" />
                                <asp:RadioButton      ID="Radbut2" runat="server" Text="Manual Entry" GroupName="AA" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                AY
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_AcYear" runat="server" CssClass="textBox11" Width="90px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Month
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_month" runat="server" CssClass="textBox11" Width="90px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_month_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Title
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Title" runat="server" CssClass="textBox11" Width="300px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_Title_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txt_title" runat="server" CssClass="textBox11" Width="300px" Visible="false" ></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                S-Date
                            </td>
                            <td>
                                <asp:TextBox ID="txt_StartDate" runat="server" CssClass="textBox11"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="Req1" runat="server" ErrorMessage="*" ControlToValidate="txt_StartDate" >
                                </asp:RequiredFieldValidator>
                                 <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="ceFromDate" runat="server" CssClass="MyCalendar" TargetControlID="txt_StartDate"
                                        PopupButtonID="ImgBCalender"  Format="MM-dd-yyyy"   >
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txt_StartDate"    >
                                    </cc1:FilteredTextBoxExtender>
                            </td>
                            <td>
                                E-date
                            </td>
                            <td>
                                <asp:TextBox ID="txt_EndDate" runat="server" CssClass="textBox11"    ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txt_EndDate" >
                                </asp:RequiredFieldValidator>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" TargetControlID="txt_EndDate"
                                        PopupButtonID="ImageButton1" Format="MM-dd-yyyy" >
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                        ValidChars="/,-" TargetControlID="txt_EndDate">
                                    </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                From time
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Fromtime" runat="server" CssClass="textBox11"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="*" ControlToValidate="txt_Fromtime"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                To time
                            </td>
                            <td>
                                <asp:TextBox ID="txt_totime" runat="server" CssClass="textBox11"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="*" ControlToValidate="txt_totime"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                       <tr>
                            <td>
                                Type
                            </td>
                            <td>
                                <asp:TextBox ID="txt_type" runat="server" CssClass="textBox11"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="*" ControlToValidate="txt_type"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Remarks
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Remarks" runat="server" CssClass="textBox11" TextMode="MultiLine"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ErrorMessage="*" ControlToValidate="txt_Remarks"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Participation Fee
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Participationfee" runat="server" CssClass="textBox11"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ErrorMessage="*" ControlToValidate="txt_Participationfee"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Payment Status
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Paymentsts" runat="server" CssClass="textBox11"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ErrorMessage="*" ControlToValidate="txt_Paymentsts"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Location
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Location" runat="server" CssClass="textBox11"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  ErrorMessage="*" ControlToValidate="txt_Location"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Representative
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRepresentative" runat="server" CssClass="textBox11">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Forms Collector
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Formscollector" runat="server" CssClass="textBox11"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  ErrorMessage="*" ControlToValidate="txt_Formscollector"></asp:RequiredFieldValidator>
                            </td>

                             <td>
                                Report submission
                            </td>
                            <td>
                              
                                <asp:RadioButton ID="Rad_Submit" runat="server"  Text="Submitted" Checked="true" />
                                <asp:RadioButton ID="Rad_Pending" runat="server" Text ="Pending" />

                            </td>
                          
                        </tr>
                        <tr>
                           
                            <td >
                                Submission Remarks
                            </td>
                            <td colspan="4">
                                <asp:TextBox  ID="txt_FinalRemarks" runat="server" TextMode="MultiLine" Width="500px" CssClass="textBox11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="Save_form" />
                                <asp:HiddenField ID="Hid_Id" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
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
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    EVENTS DETAILS</h2>
            </div>
            <!--ended Div of Form fieldset wrapper top rounded part-->
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    
                     <asp:GridView ID="gvFaresandevents" OnRowCommand="GvFaresandEvents_RowCommand" AutoGenerateColumns="false" runat="server" Style="margin-left: 5px;
                                margin-bottom: 10px; top: 0px; left: 0px; width: 99%;"      >
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                     <asp:HiddenField ID="hid_sno" runat="server" Value='<%#Bind("ID") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="AY">
                                <ItemTemplate>
                                   <asp:Label ID="lblacdyr" runat="server" Text='<%#Eval("Acadyear").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MONTH">
                                <ItemTemplate>
                                   <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("MONTH").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="S-DATE">
                                <ItemTemplate>
                                   <asp:Label ID="lblSdate" runat="server" Text='<%#Eval("STARTDATE").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="E-DATE">
                                <ItemTemplate>
                                   <asp:Label ID="lblEnddate" runat="server" Text='<%#Eval("ENDDATE").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                             <asp:TemplateField HeaderText="EVENT TYPE">
                                <ItemTemplate>
                                   <asp:Label ID="lblEventtype" runat="server" Text='<%#Eval("EVENT_TYPE").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="PARTICIPATION FEE">
                                <ItemTemplate>
                                   <asp:Label ID="lblParticipationFee" runat="server" Text='<%#Eval("PARTICIPATION_FEE").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="PAYMENT TYPE">
                                <ItemTemplate>
                                   <asp:Label ID="lblPaymentType" runat="server" Text='<%#Eval("PAYMENT_STATUS").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            
                               <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                   <asp:Label ID="lbl" runat="server" Text='<%#Eval("LOCATION").ToString() %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" OnClientClick="javascript: return confirm('Are you sure you want to edit?')"
                         CausesValidation="false"    CommandArgument='<%#Eval("ID") + ";" + Eval("EVENT_TYPE") %>' Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>


                        </Columns>
                    </asp:GridView>
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
    </div>
</asp:Content>
