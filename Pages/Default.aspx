<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                                <div id="MasterTab" runat="server" visible="false" class="icon">
                                    <!--Div for the menu icon-->
                                    <a href="AgentList.aspx">
                                        <img src="../Icons/group.png" alt="Masters" /><span>Masters</span></a>
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
                            <div class="icon">
                                <!--Div for the menu icon-->
                                <a href="DailyCms.aspx">
                                    <img src="../Icons/loan-icon.png" /><span>Reports</span></a>
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
                                                <asp:ImageButton ID="imgRequest" runat="server" ImageUrl="Icons/notification-on.png" />
                                                <div id="div1" runat="server" class="count-mes-block">
                                                    <asp:Label ID="lblCount" runat="server" Visible="false"></asp:Label></div>
                                                <span>Missed Call</span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Timer runat="server" ID="UpdateTimer" Interval="99999999" OnTick="UpdateTimer_Tick" />
                                    </a>
                                </div>

                                <div class="icon">
                                <a href="Followupschedulelist.aspx">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:LinkButton ID="lnkRequest" runat="server" Text="Approval Requests" ForeColor="Red" Font-Size="Small" PostBackUrl="~/ApprovalStatus.aspx" ></asp:LinkButton><br />--%>
                                            <asp:ImageButton ID="imgRequest1" runat="server" ImageUrl="Icons/notification-on.png" />
                                            <div id="div2" runat="server" class="count-mes-block">
                                                <asp:Label ID="lblCount1" runat="server" Visible="false"></asp:Label></div>
                                            <span>Follow Up</span>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:Timer runat="server" ID="Timer1" Interval="99999999" OnTick="UpdateTimer_Tick" />
                                </a>
                            </div>
                              <div class="icon">
                               <a href="VisitScheduleList.aspx">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                           
                                            <asp:Image ID="Image1" runat="server" ImageUrl="Icons/notification-on.png" />
                                            <div id="div3" runat="server" class="count-mes-block">
                                                <asp:Label ID="Lblvisit" runat="server" Visible="false"></asp:Label></div>
                                            <span>Visit</span>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:Timer runat="server" ID="Timer2" Interval="99999999" OnTick="UpdateTimer_Tick" />
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
                                <td style="text-align: right;">
                                    <asp:Label ID="lblDate" runat="server" Text="" ForeColor="Green"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; color:Blue; text-transform:uppercase; font-style:italic;" colspan="2">
                                 <asp:Label ID="lblThougt" runat="server" Text=""></asp:Label> </td>
                            </tr>
                        </table>
                    </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <table id="tblMain" runat="server" width="100%">
                            <tr>
                                <td align="right" colspan="2">
                                    <%--  <div>
                                        <table class="sampleTable" width="50%">
                                            <tr>
                                                <td>
                                                    <asp:Chart ID="Chart2" runat="server" Palette="BrightPastel" BackColor="#D3DFF0"
                                                        Height="296px" Width="412px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom"
                                                        BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                                                        <Legends>
                                                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                                                IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False"
                                                                Name="Default">
                                                            </asp:Legend>
                                                        </Legends>
                                                        <Series>
                                                            <asp:Series ChartArea="Area2" XValueType="Double" Name="Series2" ChartType="Pie"
                                                                Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                                                MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                                                Label="#PERCENT{P1}">
                                                            </asp:Series>
                                                        </Series>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="Area2" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                                                                BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                    </asp:Chart>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td align="left" colspan="2">
                                    <div>
                                        <table class="sampleTable" width="50%">
                                            <tr>
                                                <td>
                                                    <asp:Chart ID="Chart1" runat="server" Palette="BrightPastel" BackColor="#D3DFF0"
                                                        Height="296px" Width="412px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom"
                                                        BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                                                        <Legends>
                                                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                                                IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False"
                                                                Name="Default">
                                                            </asp:Legend>
                                                        </Legends>
                                                        <Series>
                                                            <asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie"
                                                                Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                                                MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                                                Label="#PERCENT{P1}">
                                                            </asp:Series>
                                                        </Series>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                                                                BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                    </asp:Chart>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>--%>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td align="center">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblStudentStatus" runat="server" Text="Call Status" Font-Bold="true"
                                        Font-Size="Large"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblFormStatus" runat="server" Text="Form Status" Font-Bold="true"
                                        Font-Size="Large"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>--%>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label ID="Label2" runat="server" Text="Welcome to" Font-Bold="true" Font-Size="XX-Large"
                                        Visible="true"></asp:Label>
                                    <asp:Label ID="lblwelcome" runat="server" Text="Skyline University Nigeria" Font-Bold="true"
                                        Visible="true" Font-Size="XX-Large"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!--ended Div of Middle main contents wrapper-->
                    <div id="footer-wrap">
                        <!--Start Footer Div-->
                        <div id="copyright1" style="color: #000080">
                            <!--Div for Copyright Text-->
                            &nbsp; © 2017 Skyline University Nigeria. All Rights Reserved.<br />
                            Designed & Developed By IT Dept., Skyline University Nigeria
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
