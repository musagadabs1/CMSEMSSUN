<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="StudentReversal.aspx.cs" Inherits="Pages_StudentReversal" %>

   <%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function shopPopup() {
            var modalPopupExtender = $find('ModalPopupExtenderBehavior');
            modalPopupExtender.show();
        }
        function hidePopup() {
            var modalPopupExtender = $find('ModalPopupExtenderBehavior');
            modalPopupExtender.hide();
        }
    </script>

      <script type = "text/javascript">
          function ConfirmP() {
              var confirm_value = document.createElement("INPUT");
              confirm_value.type = "hidden";
              confirm_value.name = "confirm_value";
              if (confirm("Do you want to update the records")) {
                  confirm_value.value = "Yes";
              } else {
                  confirm_value.value = "No";
              }
              document.forms[0].appendChild(confirm_value);
          }
    </script>



    <style type="text/css">
        #main-frame
        {
            width: 500px;
            padding: 10px;
            margin: 0px auto;
            background-color: #E0ECED;
            border: 1PX solid #9BAEAF;
            z-index: 50000;
        }
        
        #main-frame h1
        {
            color: #374E51;
            margin: 0px 0px 10px 0px;
            font-family: Tahoma;
            font-size: 14px;
            letter-spacing: 1px;
        }
        
        
        #main-frame p
        {
            margin: 0px 0px 10px 0px;
            padding: 0px;
            font-family: Tahoma;
            font-size: 12px;
            font-weight: normal;
            color: #374E51;
        }
        
        #main-frame label
        {
            float: left;
            margin: 0px 5px 0px 0px;
            width: 60px;
            padding: 3px 0px 2px 0px;
        }
        
        #main-frame input[type=text]
        {
            width: 170px;
            height: 14px;
            font-family: Tahoma;
            font-size: 11px;
            color: #374E51;
        }
        
        .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        
        #main-frame1
        {
            width: 300px;
            padding: 10px;
            margin: 0px auto;
            background-color: #E0ECED;
            border: 1PX solid #9BAEAF;
            z-index: 50000;
        }
        #main-frame1 h1
        {
            color: #374E51;
            margin: 0px 0px 10px 0px;
            font-family: Tahoma;
            font-size: 14px;
            letter-spacing: 1px;
        }
        
        
        #main-frame1 p
        {
            margin: 0px 0px 10px 0px;
            padding: 0px;
            font-family: Tahoma;
            font-size: 11px;
            font-weight: normal;
            color: #374E51;
        }
        
        #main-frame1 label
        {
            float: left;
            margin: 0px 5px 0px 0px;
            width: 80px;
            padding: 3px 0px 2px 0px;
        }
        
        #main-frame1 input[type=text]
        {
            width: 170px;
            height: 14px;
            font-family: Tahoma;
            font-size: 11px;
            color: #374E51;
        }
        .btnclose
        {
            background-image: url(../Icons/lightbox-btn-close.gif);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnUpdate">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Student Reversal</h2>
                </div>
                <div> <button onclick="javascript:window.history.back();return false;" > Go Back </button></div>
               
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 100px">
                                    Date
                                </td>
                                <td style="width: 287px">
                                    <asp:TextBox ID="txtCallDate" runat="server" TabIndex="5" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCallDate"
                                        CssClass="" ErrorMessage="Date Required!" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                        Display="None" ValidationGroup="Submit1"></asp:RequiredFieldValidator>
                                
                                <asp:Label ID="lblregno" runat="server" Text=""></asp:Label>
                                </td>
                                
                            </tr>
                                   <asp:Panel ID="pnl1" Visible="false" runat="server">                
                               <tr>
                                <td valign="top">
                                    <asp:Label ID="lblRemarks" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBoxbigA" Height="120px" ValidationGroup="Submit"
                                        TabIndex="7" TextMode="MultiLine" Width="512">                                               
                                    </asp:TextBox>
                                </td>
                            </tr>
                         

                            <tr>
                                                         
                                <td colspan="3">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="" OnClick="btnUpdate_Click" Text="Update"   OnClientClick = "ConfirmP()"  
                                        ValidationGroup="Submit1" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                        ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                                      
                                             </td>
                            </tr>
                            </asp:Panel> 
                            <tr>
                                <td colspan="3">
                                     <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"
                                        CssClass="labelMesag"></asp:Label>
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
    </asp:Panel>
    
    
    
   
</asp:Content>
