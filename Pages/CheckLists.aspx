<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckLists.aspx.cs" Inherits="Pages_CheckLists" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Skyline Project</title>
    <script src="../js/JScript.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/DD_roundies_0.0.2a-min.js"></script>
    <script type="text/javascript">
        DD_roundies.addRule('.form_round_border', '10px', true);
	
    </script>
    <link rel="shortcut icon" href="../Icons/favicon.ico" />
    <link rel="stylesheet" href="../style/main-design.css" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="smCDB" runat="server">
        </asp:ScriptManager>
        <div id="main-Div">
            <!--Started main First Div-->
            <div id="main-Div-inner">
                <!--Started Main Div Second-->
                <div id="main-cont-Div">
                    <!--Started Div for the main contents wrappter-->
                    <div id="top-header">
                        <img src="../Icons/logo.png" />
                    </div>
                    <div class="cleared">
                    </div>
                    <div class="menus navStuff">
                        <div id="top-menu">
                            <div id="menu-wrap">
                                <div class="icon">
                                    <a href="Default.aspx">
                                        <img src="../Icons/home.png" /><span>Home</span></a>
                                </div>
                                <div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="NewCaller.aspx">
                                        <img src="../Icons/telephone.png" /><span>Call Management</span></a>
                                </div>
                                <!--ended Div of menu icon-->
                                <div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="StudentList.aspx">
                                        <img src="../Icons/loan-icon.png" /><span>Registration</span></a>
                                </div>
                                <%--  <div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="#">
                                        <img src="../Icons/drive.png" /><span>Store Management</span></a>
                                </div>
                                <div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="#">
                                        <img src="../Icons/loan-icon.png" /><span>Request Approval</span></a>
                                </div>
                                <div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="#">
                                        <img src="../Icons/transaction-icon.png" /><span>HOD Management</span></a>
                                </div>--%>
                                <%--<div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="#">
                                        <img src="../Icons/reports.png" alt="Report" /><span>Report</span></a>
                                </div>
                                <div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="#">
                                        <img src="../Icons/settings.png" alt="Setting" /><span>Setting</span></a>
                                </div>--%>
                                <div class="icon">
                                    <a href="MissedCall.aspx">
                                        <asp:UpdatePanel ID="upApprovalRequest" runat="server">
                                            <ContentTemplate>
                                                <%--<asp:LinkButton ID="lnkRequest" runat="server" Text="Approval Requests" ForeColor="Red" Font-Size="Small" PostBackUrl="~/ApprovalStatus.aspx" ></asp:LinkButton><br />--%>
                                                <asp:ImageButton ID="imgRequest" runat="server" ImageUrl="../Icons/notification-on.png" />
                                                <div id="div1" runat="server" class="count-mes-block">
                                                    <asp:Label ID="lblCount" runat="server" Visible="false"></asp:Label></div>
                                                <span>Missed Call</span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick"/>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Timer runat="server" ID="UpdateTimer" Interval="99999999" OnTick="UpdateTimer_Tick"  />
                                    </a>
                                </div>
                                <div class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="Login.aspx">
                                        <img src="../Icons/logout.png" alt="Log Out" /><span>Log Out</span></a>
                                </div>
                            </div>
                            <!--ended Div of menu Item Wrapping-->
                        </div>
                        <!--ended Top Menu-->
                    </div>
                    <div class="cleared">
                    </div>
                    <div id="mid-main-cont-wrap">
                        <!--Start Div for the middle main contents wrapper-->
                        <div id="date-field">
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblUserName" runat="server" Text="" ForeColor="Green"></asp:Label>
                                    </td>
                                    <td>
                                      <asp:Label ID="lblMesag" runat="server" Text=""></asp:Label>
                                    
                                    </td>

                                   
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblDate" runat="server" Text="" ForeColor="Green"></asp:Label>
                                    </td>


                                </tr>
                                <tr>
                                 <td style="text-align: left;" colspan="1">
                                        <asp:Label ID="Lbl1" runat="server" Text="Student Category :  " ForeColor="DarkMagenta"></asp:Label>
                                  
                                      <asp:Label ID="Lblcategory" runat="server"  ForeColor="DarkMagenta" Text=""></asp:Label>
                                    
                                    </td>
                                    
                                   <td style="text-align: right;" colspan="2">
                               <asp:Button ID="btnPrint" runat="server" Text="Print Checklist" onclick="btnPrint_Click"   OnClientClick="document.getElementById('form1').target ='_blank';" />
                            </td>

                                    <td style="text-align: left; color: Blue; text-transform: uppercase; font-style: italic;"
                                        colspan="2">
                                        <asp:Label ID="lblThougt" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                         <div id="list-member-block" style="width: 1000px">


                         <div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" OnTick="TimerTick" Interval="2000">
        </asp:Timer>
                         
                                                        <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="ChkDetailId"
                                                            EmptyDataText="There are no records to display." OnRowDataBound="gvStudentList_RowDataBound"
                                                            GridLines="Both" CssClass="grid-view" OnRowCommand="gvStudentList_RowCommand">
                                                            <FooterStyle CssClass="GridFooter" />
                                                            <RowStyle CssClass="GridItem" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.N." ItemStyle-Width="30px" HeaderStyle-Width="30"
                                                                    Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblId" runat="server" Text='<%#Bind("ChkDetailId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DepId" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDepId" runat="server" Text='<%#Bind("DepartmentId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Caption" ItemStyle-Width="100px" HeaderStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCaption" runat="server" Text='<%#Bind("Caption") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Check List" ItemStyle-Width="250px" HeaderStyle-Width="250">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
                                                                             <asp:HiddenField ID="txtMArkettingDate" runat="server" />
                                                                        <asp:HiddenField ID="txtAdminDate" runat="server" />
                                                                        <asp:HiddenField ID="txtFinanceDate" runat="server" />
                                                                        <asp:HiddenField ID="txtIRODate" runat="server" />
                                                                         <asp:HiddenField ID="txtcoecDate" runat="server" />                                                            
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Applicable" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkIsApplicable" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Value" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px"
                                                                    HeaderStyle-Width="30" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblValue" runat="server" Text='<%#Bind("Value") %>' Width="30px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>         
                                                                <asp:TemplateField HeaderText="MKT" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px"
                                                                    HeaderStyle-Width="60" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkMarketting" runat="server" />
                                                                        <asp:TextBox ID="txtMarketting" runat="server" Text="" Width="60px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ADM" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px"
                                                                    HeaderStyle-Width="40" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkAdmin" runat="server" />
                                                                        <asp:TextBox ID="txtAdmin" runat="server" Text="" Width="60px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FIN" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px"
                                                                    HeaderStyle-Width="40" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkFinance" runat="server" />
                                                                        <asp:TextBox ID="txtFinance" runat="server" Text="" Width="60px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IRO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px"
                                                                    HeaderStyle-Width="40" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkIro" runat="server" />
                                                                        <asp:TextBox ID="txtIRO" runat="server" Text="" Width="60px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>     
                                                                 <asp:TemplateField HeaderText="COEC" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px"
                                                                    HeaderStyle-Width="40" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkcoec" runat="server" />
                                                                        <asp:TextBox ID="txtcoec" runat="server" Text="" Width="60px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                
                                                                                                                           
                                                                <asp:TemplateField HeaderText="MrktCreatedBy" ItemStyle-Width="250px" HeaderStyle-Width="250" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMrktCreatedBy" runat="server" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                
                                                                <asp:TemplateField HeaderText="AdmCreatedBy" ItemStyle-Width="250px" HeaderStyle-Width="250" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAdmCreatedBy" runat="server" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                
                                                                <asp:TemplateField HeaderText="FinCreatedBy" ItemStyle-Width="250px" HeaderStyle-Width="250" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFinCreatedBy" runat="server" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                
                                                                <asp:TemplateField HeaderText="IroCreatedBy" ItemStyle-Width="250px" HeaderStyle-Width="250" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIroCreatedBy" runat="server" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                
                                                                 <asp:TemplateField HeaderText="COECCreatedBy" ItemStyle-Width="250px" HeaderStyle-Width="250" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCOECCreatedBy" runat="server" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                                                                                  
                                                                      
                                                                   
                                                            </Columns>
                                                            <HeaderStyle CssClass="GridHeader" />
                                                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                            <SelectedRowStyle CssClass="GridRowOver" />
                                                            <EditRowStyle />
                                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                                        </asp:GridView>
                                                                                                           
    </ContentTemplate>
</asp:UpdatePanel>
</div>
                                                    </div>
                                               <br />
                                               <div>
                                               Marketing Remarks:
                                                 <asp:TextBox ID="txtRemarks" runat="server" Text="" CssClass="textBox1" Width="95%"  TextMode="MultiLine"  Enabled="false"></asp:TextBox>
                                                     </div>
                                                      <div>
                                               Administration Remarks:
                                                       <asp:TextBox ID="txtremarksadm" runat="server" Text="" CssClass="textBox1" Width="95%"  TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                                     </div>
                                                      <div>
                                               Finance Remarks:
                                                       <asp:TextBox ID="txtremarksfin" runat="server" Text="" CssClass="textBox1" Width="95%"  TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                                 </div>
                                                  <div>
                                            IRO Remarks:
                                                  <asp:TextBox ID="txtremarksiro" runat="server" Text="" CssClass="textBox1" Width="95%"  TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                              </div>
                                                <div>
                                              Verification Remarks:
                                               <asp:TextBox ID="txtremarkscoec" runat="server" Text="" CssClass="textBox1" Width="95%"  TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                               </div>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                  
                   </div>
                    <div id="footer-wrap">
                        <!--Start Footer Div-->
                        <div id="copyright1">
                            <!--Div for Copyright Text-->
                            &nbsp; © 2015 Skyline University College. All Rights Reserved.<br />
                            Designed and Developed By Al Asas Information Technology
                        </div>
                        <!--ended Div of Copyright Text-->
                    </div>
                    <!--ended footer Div-->
                </div>
                <!--ended main content div wrapper-->
                <div class="cleared">
                </div>
            </div>
            <!--Ended main Div Second-->
        </div>
        <!--Ended main First Div-->
    </form>
</body>
</html>
