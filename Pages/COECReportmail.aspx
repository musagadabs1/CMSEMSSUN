<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ReportMaster.master"  CodeFile="COECReportmail.aspx.cs" Inherits="Pages_COECReportmail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"

    TagPrefix="HTMLEditor" %>
    

   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script>
    function fnCheckOne(me) {
        me.checked = true;
        var chkary = document.getElementsByTagName('input');
        for (i = 0; i < chkary.length; i++) {
            if (chkary[i].type == 'checkbox') {
                if (chkary[i].id != me.id)
                    chkary[i].checked = false;
            }
        }
    }

    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });


</script>

<style type="text/css">
    
.FooterStyle
{
    background-color:Gray;
    color: White;
    text-align: right;
}

.modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: Transparent ;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }

 .loading
    {
        font-family: Arial;
        font-size: 10pt;
        width: 100px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: Transparent;
        z-index: 999;
    }

.fontstyle
{
 text-transform: inherit !important;	
}
  
        .modalBackground
        {
            background-color:  silver; !important;
            filter: alpha(opacity=70);
            opacity: 1;
            Position:relative;
   
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <!--Div Started to Wrapping all Forms Fields-->
        <div class="form-fieldset-wrapper">
            <!--Start Div To Wrapping Form Fields Set-->
            <div class="form-fieldset-wrapper-top">
                <!--Div for the form fieldset wrapper top rounded part-->
                <h2>
                    COEC Enrollment Report </h2>
            </div>
            <div class="form-fieldset-wrapper-mid">
                <!--Div for the form fieldset wrapper middle part for the left and right border-->
                <div class="form-fieldset-wrapper-mid-inner9">
                    <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->

                    <table>
<tr>
<td>

<asp:Label ID="lblmaildate" runat="server" Text="" ForeColor ="Green"/>

</td>
</tr>

<tr>


<td>Select Previous Term (for enrollment statistics)</td>
<td>
<asp:DropDownList ID="ddlprevious" runat="server" AppendDataBoundItems="true">
<asp:ListItem Text="Select" Value="0"></asp:ListItem>

</asp:DropDownList></td>

<td>Select Current Term</td>
<td>
<asp:DropDownList ID="ddlTerm" runat="server" AppendDataBoundItems="true">
<asp:ListItem Text="Select" Value="0"></asp:ListItem>

</asp:DropDownList></td>


</tr>
<tr>
   <td style="padding: 3px 5px;">
                               Date 
                            </td>
 <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox1" ></asp:TextBox>
                                <asp:ImageButton ID="ImgBCalender" runat="server" ImageUrl="~/Icons/calendar_view_month.png" />
                                <cc1:calendarextender id="ceFromDate" runat="server" cssclass="MyCalendar" targetcontrolid="txtFromDate"
                                    popupbuttonid="ImgBCalender">
                                </cc1:calendarextender>
                                <cc1:filteredtextboxextender id="FilteredTextBoxExtender39" runat="server" filtertype="Custom,Numbers"
                                    validchars="/,-" targetcontrolid="txtFromDate">
                                </cc1:filteredtextboxextender>
                            </td>

</tr>

<tr>
<td><br /></td>
</tr>

<tr>
<td>
<asp:Button ID="btnview_Generated" runat="server" onclick="btnviewgenerated_Click" Text="Previously Generated Reports" />



</td>

<td>
<asp:Button ID="btnMailLogs" runat="server" onclick="btnMailLogs_Click" Text="View Send Mail Logs" />

</td>
<td>
<asp:Button ID="btnview" runat="server" onclick="btnview_Click" Text="Generate" />
</td>
</tr>



<tr>
<td colspan="4">

<asp:Button ID="btnviewfile" runat="server" onclick="btnviewfile_Click" Text="View" Visible="false" />

</td>
</tr>
<tr>
<td colspan="4">
<asp:Label ID="lblmess" runat="server" Visible="true" Text=""></asp:Label>
</td>
</tr>
</table>
<asp:Panel ID="pnlview" runat="server" Visible="false">
<table style="text-align:center;">


<tr>
<td>
<asp:HyperLink ID="hypbbaweek" runat="server" Text="1. BBA Weekdays"  Target="_blank"></asp:HyperLink></td>

</tr>
<tr>
<td>
<asp:HyperLink ID="hypbbaweekend" runat="server" Text="2. BBA Weekend"  Target="_blank"></asp:HyperLink></td>

</tr>
<tr>
<td>
<asp:HyperLink ID="hypmbaweek" runat="server" Text="3. MBA Weekdays"  Target="_blank"></asp:HyperLink>
</td>

</tr>
<tr>
<td>
<asp:HyperLink ID="hypmbaweekend" runat="server" Text="4. MBA Weekend"  Target="_blank"></asp:HyperLink>
</td>

</tr>


<tr>
<td>
<asp:HyperLink ID="hyperstat" runat="server" Text="5. Consolidated Comparatitive Enrollment Statistics"  Target="_blank"></asp:HyperLink>
</td>

</tr>


</table>


<table>
  <tr>
            <td>
                       <asp:CheckBox ID="chkcoec" runat="server" Text="Send COEC Report( Only to COEC)" Checked="false" OnCheckedChanged="chkcoec_checked" AutoPostBack="true" /></td>
                        
<td>
</tr>
<tr>

<td>
<asp:HyperLink ID="hyperall" runat="server" Text=" COEC Report-Consolidated All"  Target="_blank"></asp:HyperLink>
</td>

</tr>

</table>

                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                     <tr>
                            <td style="padding: 3px 5px;">
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:Label runat="server" ForeColor='Blue' Font-Bold="true" Text="To add multiple email, 'semicolen(;)' symbol is required between the email IDs." ID="Label1" />
                            </td>
                        </tr>
                      
                      
                       
                        <tr>
                            <td style="padding: 3px 5px; width: 10%">
                                To:
                            </td>
                            <td style="padding: 3px 5px; width: 90%">
                                <asp:TextBox ID="txtTo" runat="server" Width="625px"  Text="rakesh@skylineuniversity.ac.ae" CssClass="fontstyle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvTo" ForeColor="Red" runat="server" Display="Dynamic"
                                    ValidationGroup="SendMail" ControlToValidate="txtTo" Width="625px" ErrorMessage="To Address Required !" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px; width: 10%">
                                CC:
                            </td>
                            <td style="padding: 3px 5px; width: 90%">
                                <asp:TextBox ID="txtCC" runat="server" Width="625px" CssClass="fontstyle"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                                Subject:
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:TextBox ID="txtSubject" runat="server" Width="625px" Text="ENROLLMENT STATISTICS REPORTS"></asp:TextBox>
                                <asp:RequiredFieldValidator Width="625px" ID="rvSubject" runat="server" Display="Dynamic"
                                    ValidationGroup="SendMail" ControlToValidate="txtSubject" ForeColor="Red" ErrorMessage="Subject Required !" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;" valign="top">
                                Body:
                            </td>
                            <td style="padding: 3px 5px;">
                                <%--            <asp:TextBox ID="txtBody" runat="server" TextMode = "MultiLine" Height = "150" Width = "200"></asp:TextBox>
                                --%>
                                <HTMLEditor:Editor runat="server" ID="editor" Height="250px" AutoFocus="true" Width="100%" />
                                <div style="height: 7px;">
                                
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 3px 5px;">
                            </td>
                            <td style="padding: 3px 5px;">
                                <asp:Button ID="Button1" Text="Send" OnClick="btnsend_Click" ValidationGroup="SendMail"
                                    runat="server" />
                                &nbsp;<asp:Label runat="server" ID="lblMesag" />
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>

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

   
   <div class="loading" align="center">
  <span style="font-family:Verdana; font-size:small;"></span> <br />
    <img  src="../Icons/loading1.gif" alt="" width="80px" height="80px" />
</div>

<asp:Panel ID="pnlpopup" runat="server" ScrollBars="Auto" Height="369px" Width="100%" Visible="false"  >
                 <table width="100%" >    
                  <tr>   
                  <td align="left">
                  <asp:ImageButton ID="brnCloseInvoice" runat="server" onclick="brnCloseInvoice_Click"  ImageUrl="~/Icons/Cancel.png"
                        Text="Close" Width="30px" AlternateText="CLOSE" />
                               
                </td>

                </tr>
                <tr>
                <td>Mail Send Logs</td>
                </tr>
                <tr>
                <td>
                <asp:GridView ID="gridmail" runat="server" Font-Names="verdana" Font-Size="Small"
                    AutoGenerateColumns="False"  Width="100%">
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                <SelectedRowStyle CssClass="GridRowOver" />
                                <EditRowStyle />
                                <AlternatingRowStyle CssClass="GridAltItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                
                                    <asp:TemplateField HeaderText="Send_Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsenddate" runat="server" Text='<%#Eval("Send_Date")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                      <asp:TemplateField HeaderText="Send_By">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsendby" runat="server" Text='<%#Eval("Send_by")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Send_To">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsendto"  CssClass="fontstyle"  runat="server" Text='<%#Eval("Send_To")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Send_Message">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsendmess" runat="server" Text='<%#Eval("Send_Message")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Send_CC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsendcc" runat="server" CssClass="fontstyle"  Text='<%#Eval("Send_CC")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                
                
               </Columns>
                                <RowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                
                </td>
                
                
                                  </tr>
                  </table>
                 
                  </asp:Panel>



</asp:Content>
