<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="OfferLetter.aspx.cs" Inherits="Pages_OfferLetter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript">
        function openPopup(productid, productname, price, Name) {
            $('#lblId').text(productid);
            $('#lblName').text(productname);
            $('#lblPrice').text(price);
            $("#popupdiv").dialog({
                title: Name,
                width: 300,
                height: 250,
                modal: true,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                }
            });
        }
    </script>
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).on("click", "[id*=lnkView]", function () {
            $("#id").html($(".Id", $(this).closest("tr")).html());
            $("#name").html($(".Name", $(this).closest("tr")).html());
            $("#lblFormStatus").html($(".CallerStatus", $(this).closest("tr")).html());
            $("#dialog").dialog({
                title: "View Details",
                buttons: {
                    Ok: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
            return false;
        });
    </script>
    <script type="text/javascript">

 


function CheckOnOff(ChkSave) { // var row = ChkSave.parentNode.parentNode; //
    var rowIndex = row.rowIndex - 1; // var grid = document.getElementById("<%=gvStudentList.ClientID%>");
    var CellValue = grid.rows[parseInt(rowIndex) + 1].cells[0]; // var hidID = CellValue.childNodes[0];
  alert(hidID); // // } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlDefaultControl" runat="server" DefaultButton="btnSearch">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-fieldset-wrapper-top">
                    <!--Div for the form fieldset wrapper top rounded part-->
                    <h2>
                        Search Student</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <!--Form fieldset wrapper mid inner inside this Div all form fields inserted here-->
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    NON REGISTERED
                                    <asp:CheckBox ID="chkNonRegister" runat="server" Checked="true" />&nbsp;
                                    <asp:RadioButton ID="rdbNumber" runat="server" Text="Mobile No" GroupName="FilterBy" />
                                    <asp:RadioButton ID="rdbEmail" runat="server" Text="Reg No" GroupName="FilterBy" />
                                    <asp:RadioButton ID="rdbName" runat="server" Text="Name" GroupName="FilterBy" />
                                    &nbsp;<%--<asp:DropDownList ID="ddlCallerCategory" runat="server" AppendDataBoundItems="true"
                                        Width="100px" CssClass="textBox9">
                                        <asp:ListItem Value="0">All Category</asp:ListItem>
                                    </asp:DropDownList>--%><asp:TextBox ID="txtFilterValue" runat="server" Text="" CssClass="textBox1"></asp:TextBox>
                                    <cc1:AutoCompleteExtender runat="server" ID="acFilterVAlue" BehaviorID="autoComplete"
                                        TargetControlID="txtFilterValue" ServicePath="~/AutoComlete.asmx" ServiceMethod="GetCompletionList"
                                        MinimumPrefixLength="3" CompletionInterval="1" EnableCaching="true" CompletionSetCount="1"
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth">
                                    </cc1:AutoCompleteExtender>
                                    &nbsp;
                                    <asp:Button ID="btnSearch" runat="server" CssClass="" OnClick="btnSearch_Click" Text="Search"
                                        ValidationGroup="Search" />
                                    &nbsp;
                                    <asp:Button ID="btnNew" runat="server" CssClass="" OnClick="btnNew_Click" Visible="false"
                                        Text="New" />
                                    <asp:Button ID="BtnSave" runat="server" CssClass="" Text="Save" OnClick="BtnSave_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
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
                        Student List Offer Letter (A - Approved, C - Cancelled, P - Processing)</h2>
                </div>
                <!--ended Div of Form fieldset wrapper top rounded part-->
                <div class="form-fieldset-wrapper-mid">
                    <!--Div for the form fieldset wrapper middle part for the left and right border-->
                    <div class="form-fieldset-wrapper-mid-inner">
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="list-member-block" style="width: 693px">
                                <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                    EmptyDataText="There are no records to display." OnRowDataBound="gvStudentList_RowDataBound"
                                    GridLines="Both" CssClass="grid-view" OnRowCommand="gvStudentList_RowCommand"
                                    OnSorted="gvStudentList_Sorted" OnSorting="gvStudentList_Sorting" AllowSorting="true"
                                    AllowPaging="true" OnPageIndexChanged="gvStudentList_PageIndexChanged" OnPageIndexChanging="gvStudentList_PageIndexChanging"
                                    PageSize="10" >
                                    <FooterStyle CssClass="GridFooter" Font-Size="Small" />
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.N.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSN" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name" SortExpression="Name">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%#Bind("LinkId") %>'
                                                    Text='<%#Bind("Name") %>'></asp:LinkButton>
                                                <asp:Label ID="LblLinkID" runat="server" Text='<%#Bind("LinkId") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="LblID" runat="server" Text='<%#Bind("ID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a href="#" class="gridViewToolTip" onclick='openPopup("<%# Eval("NationalityName")%>","<%# Eval("FormStatus")%>","<%# Eval("CallerStatus")%>","<%#Eval("Name") %>")'>
                                                    Details</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="App Rece">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkApplicationReceived" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Mail">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkMail" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="App Status">
                                            <ItemTemplate>
                                                <asp:RadioButton ID="RadApproved" runat="server" Text="A" GroupName="Opt" />
                                                <asp:RadioButton ID="RadCancelled" runat="server" Text="C" GroupName="Opt" />
                                                <asp:RadioButton ID="RadProcessing" runat="server" Text="P" GroupName="Opt"
                                                    Checked="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Term">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DDLTerm" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Save">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkSave" runat="server" OnClick="onGridViewRowSelected(this);" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                    <SelectedRowStyle CssClass="GridRowOver" />
                                    <EditRowStyle />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <!--form fieldset wrapper mid inner ended-->
            </div>
            <!--Ended Div of form fieldset wrapper middle part of left and right border-->
            <div class="form-fieldset-wrapper-bottom">
            </div>
        </div>
        <!--Div started for the form fieldset wrapper bottom founded-->
        </div>
        <div id="popupdiv" title="Basic modal dialog" style="display: none">
            Country:
            <label id="lblId">
            </label>
            <br />
            Caller Status:
            <label id="lblName">
            </label>
            <br />
            Student Status:
            <label id="lblPrice">
            </label>
        </div>
    </asp:Panel>
</asp:Content>
