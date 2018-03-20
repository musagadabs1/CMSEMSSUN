<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PolicyPrerequisite.aspx.cs" Inherits="Pages_PolicyPrerequisite" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnSave">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Policy Pre-Requisite</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    Policy Code
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPolicyCode" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                                <td>
                                    Pre-Requisite Code
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrereqCode" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Minimum Value
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMinVal" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                                <td>
                                    Maximum Value
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaxVal" runat="server" CssClass="textBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Or Policy Id
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrpID" runat="server" CssClass="textBox11" Width="142px">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Skill 1
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMinSkillVal1" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="txtWM_UserID" runat="server" Enabled="True" TargetControlID="txtMinSkillVal1"
                                        WatermarkText="Minimum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaxSkillVal1" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                        TargetControlID="txtMaxSkillVal1" WatermarkText="Maximum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSkill1Lbl" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                        TargetControlID="txtSkill1Lbl" WatermarkText="Label">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Skill 2
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMinSkillVal2" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                        TargetControlID="txtMinSkillVal2" WatermarkText="Minimum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaxSkillVal2" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" Enabled="True"
                                        TargetControlID="txtMaxSkillVal2" WatermarkText="Maximum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSkill2Lbl" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                                        TargetControlID="txtSkill2Lbl" WatermarkText="Label">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Skill 3
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMinSkillVal3" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" Enabled="True"
                                        TargetControlID="txtMinSkillVal3" WatermarkText="Minimum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaxSkillVal3" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" Enabled="True"
                                        TargetControlID="txtMaxSkillVal3" WatermarkText="Maximum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSkill3Lbl" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" Enabled="True"
                                        TargetControlID="txtSkill3Lbl" WatermarkText="Label">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Skill 4
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMinSkillVal4" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                                        TargetControlID="txtMinSkillVal4" WatermarkText="Minimum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaxSkillVal4" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server" Enabled="True"
                                        TargetControlID="txtMaxSkillVal4" WatermarkText="Maximum Value">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSkill4Lbl" runat="server" CssClass="textBox1"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender11" runat="server" Enabled="True"
                                        TargetControlID="txtSkill4Lbl" WatermarkText="Label">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Undertaking Desired
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkUndertakingDesired" runat="server" CssClass=""></asp:CheckBox>
                                </td>
                                <td>
                                    Undertaking Documents
                                </td>
                                <td>
                                    <asp:FileUpload ID="fuUnderTakingDocument" runat="server" CssClass="FUpload" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnSave" runat="server" CssClass="" OnClick="btnSave_Click" Text="Save"
                                        ValidationGroup="Submit" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                        ShowMessageBox="True" ValidationGroup="Submit" Font-Size="Large" ForeColor="Red" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""
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
    </div>
</asp:Content>
