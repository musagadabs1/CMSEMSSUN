<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Skyline : Login</title>
    <script src="js/JScript.js" type="text/javascript"></script>
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
                        </div>
                        <div class="Login">
                            <div id="all-form-wrap">
                                <!--Div Started to Wrapping all Forms Fields-->
                                <div class="form-fieldset-wrapper">
                                    <div class="form_left">
                                        <!--this is form left part-->
                                        <div class="form_round_border">
                                            <!--This is rounded Div-->
                                            <div class="form_round_heading_row">
                                                <!--this is heading row-->
                                                <h2 class="slide_top">
                                                    Log In</h2>
                                            </div>
                                            <!--ended heading row-->
                                            <div class="round_form_content">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 30%">
                                                            User Name
                                                        </td>
                                                        <td style="width: 30px">
                                                            <asp:TextBox ID="txtUserName" runat="server" Text="" CssClass="textBoxlogin"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Password
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPassword" runat="server" Text="" TextMode="Password" CssClass="textBoxlogin"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnLogIn" runat="server" Text="Log In" CssClass="" OnClick="btnLogIn_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMesag" runat="server" Text="" CssClass="" ForeColor="Red" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--ended Div of Middle main contents wrapper-->
                    <div id="footer-wrap">
                        <!--Start Footer Div-->
                        <div id="copyright1">
                            <!--Div for Copyright Text-->
                            &nbsp; © 2018 Skyline University Nigeria. All Rights Reserved.<br />
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
    </div>
    </form>
</body>
</html>
