<%@ Page Language="C#" MasterPageFile="~/MasterForCallManagement.master"  AutoEventWireup="true" CodeFile="Followupschedulelist.aspx.cs" Inherits="Pages_Followupschedulelist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <style type="text/css">
        .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 0px;
            background-color: White;
            margin-left: 0px;
            z-index: 10;
            position: absolute;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }
        #divwidth
        {
            width: 150px !important;
        }
        #divwidth div
        {
            width: 150px !important;
        }
    </style>


    <script>
     
//        function ShowProgress() {
//            setTimeout(function () {
//                var modal = $('<div />');
//                modal.addClass("modal");
//                $('body').append(modal);
//                var loading = $(".loading");
//                loading.show();
//                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
//                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
//                loading.css({ top: top, left: left });
//            }, 200);
//        }
//        $('form').live("submit", function () {
//            ShowProgress();
//        });


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

</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server">
        <div id="all-form-wrap">
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Follow Up List</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">

                      <table>
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
                                   
                    
                    
                    </table>


                        <!--start list member blocks-->
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="list-member-block" style="width: 693px">
                                        <asp:GridView ID="gvStudentList" runat="server"  AutoGenerateColumns="false" DataKeyNames="Id"
                                            EmptyDataText="There are no records to display." OnRowDataBound="gvStudentList_RowDataBound"
                                            
                                            GridLines="Both" CssClass="grid-view" OnRowCommand="gvStudentList_RowCommand">
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />
                                            <Columns>
                                               <%-- <asp:TemplateField HeaderText="S.N.">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblSN" runat="server" Text='<%#Bind("orderno") %>'></asp:Label>--%>
                                                       <%-- <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                        <asp:Hiddenfield ID="lblSN" runat="server" Value='<%#Bind("orderno") %>'></asp:Hiddenfield >
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                             <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                            Text='<%#Bind("Name") %>'></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("Id") %>'  />
                                                              <asp:HiddenField ID="hdnstud" runat="server"  Value='<%#Eval("studentstatus") %>'  />

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%#Bind("DegreeCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentStatus" runat="server" Text='<%# Bind("CallerStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Follow Up Schedule Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEntryDate" runat="server" Text='<%# Bind("CallDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Registered By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegisteredBy" runat="server" Text='<%# Bind("AttendedBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                            <SelectedRowStyle CssClass="GridRowOver" />
                                            <EditRowStyle />
                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                        </asp:GridView>
                                        <br />
<asp:Repeater ID="rptPager" runat="server">
<ItemTemplate>
    <asp:LinkButton ID="lnkPage" OnClientClick="return ShowProgress();" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed"></asp:LinkButton>
</ItemTemplate>
</asp:Repeater>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
            <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
    </asp:Panel>
    </div>
    <%--<div class="loading" align="center">
  <span style="font-family:Verdana; font-size:small;">Please Wait...</span> <br />
    <img  src="../Icons/loading.gif" alt="" width="80px" height="80px" />
</div>--%>
</asp:Content>