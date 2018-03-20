<%@ Page Title="Skyline: Student Registration" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentRegistration.aspx.cs" Inherits="StudentRegistration"
    EnableEventValidation="false" %>
    
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    <%@ Register Assembly="obout_ComboBox" Namespace="Obout.ComboBox" TagPrefix="cc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
    <style type="text/css">
        .GridviewDiv
        {
            font-size: 11px;
            font-weight: normal;
            font-family: 'tahoma';
            color: #303933;
        }
        Table.Gridview
        {
            border: solid 1px #003964;
        }
        .Gridview th
        {
            color: white;
            border-right-color: #003964;
            border-bottom-color: #003964;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
        .Gridview td
        {
            border-bottom-color: #003964;
            border-right-color: #003964;
            padding: 0.5em 0.5em 0.5em 0.5em;
        }
        .Gridview tr
        {
            color: Black;
            background-color: #D3D3D3;
            text-align: left;
        }
        :link, :visited
        {
            color: #DF4F13;
            text-decoration: none;
        }
        .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }
        .buttonface
        {
            text-align: center;
        }
    </style>
   
   
    <script type="text/javascript">
        //function shopPopup() {
        //    var modalPopupExtender = $find('ModalPopupExtenderBehavior');
       //     modalPopupExtender.show();
       // }
       // function hidePopup() {
       //     var modalPopupExtender = $find('ModalPopupExtenderBehavior');
       //     modalPopupExtender.hide();
       // }	
    </script>
    <script type="text/javascript" language="JavaScript">
        var zxcZIndex = 0;         // the base Z-Index for the images
        var zxcDelay = 10;         // the global zoom speed may be specified in addition to the call
        var zxcAddCursor = true;   // true to add a 'hand'/'pointer' cursor to the Zoom Image, false for no cursor
        //-->
    </script>
    <script type="text/javascript" language="JavaScript">
        var zxcOOPCnt = 0;
        var zxcCursor = document.all ? 'hand' : 'pointer';
        zxcZIndex = zxcZIndex || 1;
        var zxcZIndx = zxcZIndex;
        zxcDelay = zxcDelay || 10;

        function zxcZoom(zxcobj, zxcph, zxcmw, zxcmh, zxcspd, zxcopt) {
            if (typeof (zxcobj) == 'string') { zxcobj = document.getElementById(zxcobj); }
            var zxcphoto;
            if (zxcobj.tagName.toUpperCase() == 'IMG') {
                zxcphoto = zxcph || zxcobj.src;
                if (zxcphoto.length < 5) { zxcphoto = zxcobj.src; }
            }
            var zxcspd = zxcspd || 1;
            var zxcopt = zxcopt || null;
            if (!zxcobj.zxcoop) { zxcobj.zxcoop = new zxcOOPZoom(zxcobj, zxcphoto, zxcmw, zxcmh, zxcspd, zxcopt, zxcopt); }
            clearTimeout(zxcobj.zxcoop.to);
            zxcobj.zxcoop.inc *= -1
            if (zxcobj.zxcoop.large.load) { zxcobj.src = zxcobj.zxcoop.large.src; }
            zxcZIndx++;
            zxcStyle(zxcobj, { zIndex: (zxcZIndx + '') });
            zxcobj.zxcoop.zoom();
        }
        function zxcOOPZoom(zxcobj, zxcph, zxcmw, zxcmh, zxcspd, zxcopt) {
            this.obj = zxcobj;
            this.objS = zxcobj.style;
            this.clone = zxcobj.cloneNode(true);
            this.zxcspd = zxcspd;
            this.zxct = zxcPos(zxcobj)[1];
            this.zxcl = zxcPos(zxcobj)[0];
            zxcStyle(this.obj, { position: 'absolute', zIndex: (zxcZIndex * 1 + 1 + ''), width: zxcobj.offsetWidth + 'px', height: zxcobj.offsetHeight + 'px', left: (this.zxcl - 250) + 'px', top: (this.zxct - 200) + 'px' });
            if (zxcAddCursor) { zxcStyle(this.obj, { cursor: zxcCursor }); }
            this.minw = zxcobj.offsetWidth;
            this.minh = zxcobj.offsetHeight;
            this.center = zxcopt;
            this.maxw = zxcmw;
            this.maxh = zxcmh || zxcmw * this.minh / this.minw;
            this.thumb = zxcobj.src;
            this.large = new Image();
            this.large.obj = this.obj;
            if (zxcph) { this.large.onload = function () { this.load = true; this.obj.src = this.src; }; this.large.src = zxcph; }
            zxcobj.parentNode.insertBefore(this.clone, zxcobj);
            this.inc = ((this.maxw - this.minw) / 100);
            this.inc = -this.inc * this.zxcspd;
            this.ratio = (this.maxh / this.maxw);
            this.ref = 'zxc' + zxcOOPCnt;
            window[this.ref] = this;
            this.to = null;
            zxcOOPCnt++;
        }

        zxcOOPZoom.prototype.setTimeOut = function (zxcf, zxcd) {
            this.to = setTimeout("window." + this.ref + "." + zxcf, zxcd);
        }

        zxcOOPZoom.prototype.zoom = function () {
            this.w = parseInt(this.objS.width) + this.inc; this.h = parseInt(this.objS.width) * this.ratio;
            zxcStyle(this.obj, { width: (this.w) + 'px', height: (this.h) + 'px' });
            this.w = parseInt(this.objS.width); this.h = parseInt(this.objS.height);
            if (this.center) { zxcStyle(this.obj, { top: ((this.zxct - 272) - (this.h - this.minh) / 2) + 'px', left: ((this.zxcl - 461) - (this.w - this.minw) / 2) + 'px' }); }
            if ((this.inc > 0 && this.w < this.maxw) || (this.inc < 0 && this.w > this.minw)) { this.setTimeOut('zoom();', zxcDelay); }
            else {
                if (this.inc > 0) { zxcStyle(this.obj, { width: this.maxw + 'px', height: this.maxh + 'px' }); }
                else {
                    zxcStyle(this.obj, { zIndex: zxcZIndex, width: this.minw + 'px', height: this.minh + 'px', top: ((this.zxct) - 272) + 'px', left: ((this.zxcl) - 461) + 'px' });
                    zxcZIndx--;
                    this.obj.src = this.thumb;
                }
            }
        }

        function zxcStyle(zxcele, zxcstyle) {
            for (key in zxcstyle) { zxcele.style[key] = zxcstyle[key]; }
        }

        function zxcPos(zxc) {
            zxcObjLeft = zxc.offsetLeft;
            zxcObjTop = zxc.offsetTop;
            while (zxc.offsetParent != null) {
                zxcObjParent = zxc.offsetParent;
                zxcObjLeft += zxcObjParent.offsetLeft;
                zxcObjTop += zxcObjParent.offsetTop;
                zxc = zxcObjParent;
            }
            return [zxcObjLeft, zxcObjTop];
        }
    </script>
    <script type="text/javascript">
        function changeColor(buttonid) {
            var id = document.getElementById(buttonid.id);
            id.style.color = "Red";
        }
    </script>

    <style type="text/css">
        .item
        {
            position: relative !important;
            display:-moz-inline-stack;
            display:inline-block;
            zoom:1;
            *display:inline;
            overflow: hidden;
            white-space: nowrap;
        }
        
        .header
        {
            margin-left: 2px;
        }
   
        .c1
        {
            width: 25px;
        }
        
        .c2
        {
            margin-left: 10px;
            width: 180px;
        }
        
        .c3
        {
            margin-left: 10px;
            width: 90px;
        }
          .c4
        {
            margin-left: 10px;
            width: 180px;
        }
    </style>


    <style type="text/css">
        
     
    
     
     
        
        .modalBackground
        {
            background-color: #E0ECED !important;
            filter: alpha(opacity=70);
            opacity: 1;
            Position:relative;
   
        }
        #main-frame1
        {
            width: 350px;
            padding: 10px;
            margin: 0px auto;
            background-color: #E0ECED !important;
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
        .modalBackground
        {
            background-color: #000000;
            filter: alpha(opacity=30);
            opacity: 0.7;
        }
       /*a:link { color: Red} /* unvisited links */
       /* a:visited { color: Green } /* visited links */
       /*  a:hover { color: Green } /* user hovers */
       /* a:active { color: Red } /* active links */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cleared">
        percentage</div>
    <table width="100%">
    <tr>
        <td style="width:64px;"><span style="font-weight:bold; color:Blue;">Regn No :</span> </td>
        <td style="width:122px;"><span style="font-weight:bold; color:Blue;">  <asp:Label ID="txtRegNo" runat="server" Text=""></asp:Label></span></td>
        <td style="width:43px;"><span style="font-weight:bold; color:Blue;">Name :</span></td>
        <td style="width:292px;"><span style="font-weight:bold; color:Blue;"> <asp:Label ID="txtName" runat="server" Text="" ></asp:Label></span></td>
    </tr>
    </table>   
    <asp:Panel ID="pnlTab" runat="server" Visible="true">
        <div id="all-form-wrap">
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <!--Start Div To Wrapping Form Fields Set-->
                <div class="form-tabMenu">
                    <!--For the Tab System Forms Tab menu-->
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnkContact" runat="server" Text="Contact" OnClick="lnkContact_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkPrograms" runat="server" Text="Programs" OnClick="lnkPrograms_Click"></asp:LinkButton></li>                      
                        <li>
                            <asp:LinkButton ID="lnkToc" runat="server" Text="TOC" OnClick="lnkToc_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkFinance" runat="server" Text="Finance" OnClick="lnkFinance_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkVisa" runat="server" Text="Document Info" OnClick="lnkVisa_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkTransport" runat="server" Text="Transport" OnClick="lnkTransport_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkMediaSource" runat="server" Text="Media Source" OnClick="lnkMediaSource_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkFitness" runat="server" Text="Fitness" OnClick="lnkFitness_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkParents" runat="server" Text="Parents" OnClick="lnkParents_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkExperience" runat="server" Text="Experience" OnClick="lnkExperience_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkAcademic" runat="server" Text="Qualification" OnClick="lnkAcademic_Click"></asp:LinkButton></li> 
                        <li>
                            <asp:LinkButton ID="lnkEntrance" runat="server" Text="Entrance" OnClick="lnkEntrance_Click"></asp:LinkButton></li> 
                        <li>
                            <asp:LinkButton ID="lnkSkylineVisa" runat="server" Text="SUN VISA" OnClick="lnkSkylineVisa_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkHostel" runat="server" Text="Hostel" OnClick="lnkHostel_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LnkRemarks" runat="server" Text="Remarks" OnClick="lnkRemarks_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkUndertaking" runat="server" Text="Undertaking" OnClick="lnkUnderTaking_Click"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkPrint" runat="server" Text="Print" OnClick="lnkPrint_Click"></asp:LinkButton></li>
                    </ul>
                </div>
                <!--Ended of Tab System Forms Tab Menu-->
                <asp:Panel ID="pnlContact" runat="server">
                    <div id="Contact" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Student Contact</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 22%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Label ID="Label29" runat="server" CssClass="" Text="Student Contact - Present"
                                                                    Font-Bold="true" Font-Underline="true"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPresentAddr1" runat="server" CssClass="" Text="House Number"></asp:Label>
                                                                <span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPresentAddr1" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPresentAddr1"
                                                                    CssClass="" ErrorMessage="Flat/Vila No Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="CSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPresentAddr2" runat="server" CssClass="" Text="Ward Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPresentAddr2" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPresentCity" runat="server" CssClass="" Text="Street Address"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPresentCity" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblNationalityDetails" runat="server" CssClass="" Text="Country"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlNationalityDetails" runat="server" 
                                                                    CssClass="textBox11" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlNationalityDetails_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPresentState" runat="server" CssClass="" Text="State/Province"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPresentState" runat="server" CssClass="textBox11">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="ddlPresentState"
                                                                    CssClass="" ErrorMessage="Present State/Province Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="CSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPostBoxNo" runat="server" CssClass="" Text="Post Box No"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPostBoxNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtPostBoxNo">
                                                                </cc1:FilteredTextBoxExtender>
                                                                
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="pnlEmirates" runat="server" Visible="true">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEmirateID" runat="server" CssClass="" Text="City"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlEmirateID" runat="server" CssClass="textBox11">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        </asp:Panel>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPlaceofBirth" runat="server" CssClass="" Text="Place of Birth"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPlaceofBirth" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPlaceofBirthNation" runat="server" CssClass="" Text="Nationality"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPlaceofBirthNation" runat="server" CssClass="textBox11">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">UAE</asp:ListItem>
                                                                </asp:DropDownList>
                                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlPlaceofBirthNation"
                                                                    CssClass="" ErrorMessage="Nationality Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="CSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblResPhoneNo" runat="server" CssClass="" Text="Phone Res"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtResPhoneNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtResPhoneNo">
                                                                </cc1:FilteredTextBoxExtender>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblOffPhoneNo" runat="server" CssClass="" Text="Phone Off"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtOffPhoneNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtOffPhoneNo">
                                                                </cc1:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" CssClass="" Text="Mobile"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMobile" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtMobile">
                                                                </cc1:FilteredTextBoxExtender>
                                                                
                                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtMobile"
                                                                    CssClass="" ErrorMessage="Mobile Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="CSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" CssClass="" Text="Email"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtEmail"
                                                                    CssClass="" ErrorMessage="Email Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="CSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblFaxNo" runat="server" CssClass="" Text="Fax No"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFaxNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtFaxNo">
                                                                </cc1:FilteredTextBoxExtender>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMaritalstatus" runat="server" CssClass="" Text="Marital Status"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="textBox11">
                                                                    <asp:ListItem Value="1">Single</asp:ListItem>
                                                                    <asp:ListItem Value="2">Married</asp:ListItem>
                                                                    <asp:ListItem Value="3">Divorce</asp:ListItem>
                                                                    <asp:ListItem Value="4">Widow</asp:ListItem>
                                                                    <asp:ListItem Value="5">Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                                <td colspan="4" align="center">
                                                                    <asp:Label ID="Label30" runat="server" CssClass="" Text="Student Contact - Permanent"
                                                                    Font-Bold="true" Font-Underline="true"></asp:Label>
                                                                    <div style="padding-left: 20px;">
                                                                        <asp:Label ID="Label37" runat="server" Text="Do You Want To Copy"></asp:Label>
                                                                        <asp:CheckBox ID="chkCopyParent" runat="server" AutoPostBack="true" OnCheckedChanged="lnkCopyParent_Click" />
                                                                    </div>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPermenentAddr1" runat="server" CssClass="" Text="House Number"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPermenentAddr1" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPermenentAddr2" runat="server" CssClass="" Text="Ward Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPermenentAddr2" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPermenentCity" runat="server" CssClass="" Text="Street No"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPermenentCity" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPermanentCountry" runat="server" CssClass="" Text="Country"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPermanentCountry" runat="server" CssClass="textBox11" 
                                                                    AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlPermanentCountry_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">U.A.E.</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPermenentState" runat="server" CssClass="" Text="State/Province"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                
                                                                <asp:DropDownList ID="ddlPermenentState" runat="server" CssClass="textBox11">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                                
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddlPermenentState"
                                                                    CssClass="" ErrorMessage="Permanent State/Province Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="CSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td rowspan="3" valign="middle">
                                                                Passport Size Photo
                                                            </td>
                                                            <td rowspan="3" valign="middle">
                                                                <asp:Image ID="Img_Student" runat="server" Width="80px" Height="90px" />
                                                                <%--onmouseover="zxcZoom(this,this,300,233,1,'C');" onmouseout="zxcZoom(this);" border="0" --%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStudentType" runat="server" CssClass="" Text="Student Type"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlStudentType" runat="server" CssClass="textBox11" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlStudentType_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="D">Dependent</asp:ListItem>
                                                                    <asp:ListItem Value="M">Matured</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="ddlStudentType"
                                                                    CssClass="" ErrorMessage="Student Type Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="CSubmit"></asp:RequiredFieldValidator>
                                                         
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Passport Size Photo
                                                            </td>
                                                            <td>
                                                                <asp:FileUpload ID="fuPhoto" runat="server" CssClass="FUpload" /><span style="color:Red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnUpdateDetails" runat="server" CssClass="" OnClick="btnInsertContact_Click"
                                                                    Text="Update" ValidationGroup="CSubmit" />
                                                                <%--      <asp:Button ID="btnPrint" runat="server" CssClass="" OnClick="btnPrint_Click" Text="Print"
                                                                    ValidationGroup="Back" />--%>
                                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" ConfirmText="Are you sure you want to Update?"
                                                                    TargetControlID="btnUpdateDetails" />
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                                                                    ShowMessageBox="True" ValidationGroup="CSubmit" Font-Size="Large" ForeColor="Red" />
                                                                <asp:Label ID="lblMesagContact" runat="server" Font-Bold="true" Font-Size="12px"
                                                                    Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </colgroup>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlFitness" runat="server">
                    <div id="Div1" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Fitness
                                </h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 31%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 13%;">
                                                    <colgroup span="1" style="width: 32%;">
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Label ID="lblIsDisability" runat="server" CssClass="" Text="Any Physical Disablity or Medical Condition Which Might Necessiate Special Arrangement or Facilities?"></asp:Label>
                                                                <asp:CheckBox ID="chkIsDisability" runat="server" CssClass="textBox1" AutoPostBack="True"
                                                                    OnCheckedChanged="chkIsDisability_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtHandiCapped" runat="server" CssClass="textBox11" Width="489px"
                                                                    TextMode="MultiLine" Height="40px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                               
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:CheckBox ID="chkVisual" runat="server" Text="Visual" />
                                                           
                                                                <asp:CheckBox ID="chkHearing" runat="server" Text="Hearing" />
                                                           
                                                                <asp:CheckBox ID="chkDifficulty" runat="server" Text="Special Learning Difficulty"/>
                                                            </td>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Label ID="lblChronicBool" runat="server" CssClass="" Text="Candidate Having Chronic Disease?"></asp:Label>
                                                                <asp:CheckBox ID="chkChronicBool" runat="server" CssClass="" AutoPostBack="True"
                                                                    OnCheckedChanged="chkChronicBool_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtChronicDisease" runat="server" CssClass="textBox11" Width="489px"
                                                                    TextMode="MultiLine" Height="40px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Label ID="lblPoliceClearnece" runat="server" CssClass="" Text="Candidate Required Police Clearnece?"></asp:Label>
                                                                <asp:CheckBox ID="chkPoliceClearnece" runat="server" CssClass="" AutoPostBack="True"
                                                                    OnCheckedChanged="chkPoliceClearnece_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtPoliceClearance" runat="server" CssClass="textBox11" ReadOnly="True"
                                                                    Width="489px" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Medical Certificate
                                                                <asp:CheckBox ID="chkMedicalCertificate" runat="server" CssClass="" />
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtsubject" runat="server" CssClass="textBox1" Width="220px"></asp:TextBox>
                                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender18" runat="server" Enabled="True"
                                                                    TargetControlID="txtsubject" WatermarkText="Subject">
                                                                </cc1:TextBoxWatermarkExtender>
                                                            </td>
                                                            <td colspan="1">
                                                                <asp:FileUpload ID="fuMedicalCertificate" runat="server" CssClass="FUpload" />
                                                                <asp:Button ID="btnAttach" runat="server" Text="Attach" OnClick="btnAttach_Click"
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnFitness" runat="server" CssClass="" OnClick="btnSaveFitness_Click"
                                                                    Text="Update" ValidationGroup="Update" />
                                                                <%-- <asp:Button ID="Button3" runat="server" CssClass="" OnClick="btnPrint_Click" Text="Print"
                                                                    ValidationGroup="Back" />--%>
                                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to Update?"
                                                                    TargetControlID="btnUpdateDetails" />
                                                                <asp:Label ID="lblFitnessMsg" runat="server" Font-Bold="true" Font-Size="12px" Text=""
                                                                    ForeColor="Blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </colgroup>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlParents" runat="server">
                    <div id="Parents" runat="server">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Guardian & Parents</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 22%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Label ID="Label31" runat="server" CssClass="" Text="Guardian Details" Font-Bold="true"
                                                                    Font-Underline="true"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblFatherName" runat="server" CssClass="" Text="Guardian Name"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFatherName" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFatherName"
                                                                    CssClass="" ErrorMessage="Gurdian Name Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="GSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblRelationShip" runat="server" CssClass="" Text="Relationship"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRelationShip" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtRelationShip"
                                                                    CssClass="" ErrorMessage="Relationship Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="GSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProfession" runat="server" CssClass="" Text="Profession"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtProfession" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtProfession"
                                                                    CssClass="" ErrorMessage="Profession Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="GSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblOrganization" runat="server" CssClass="" Text="Organization"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtOrganization" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblParentsEmail" runat="server" CssClass="" Text="Email"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmailGuardian" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMobile" runat="server" CssClass="" Text="Mobile"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMobileGuardian" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtMobileGuardian">
                                                                </cc1:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtMobileGuardian"
                                                                    CssClass="" ErrorMessage="Mobile Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="GSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblResPhone" runat="server" CssClass="" Text="Residence Phone"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtResPhone" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtResPhone">
                                                                </cc1:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtResPhone"
                                                                    CssClass="" ErrorMessage="Residence Phone Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="GSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblOffPhone" runat="server" CssClass="" Text="Office Phone"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtOffPhone" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="-" TargetControlID="txtOffPhone">
                                                                </cc1:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblWebsite" runat="server" CssClass="" Text="Website"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="textBox1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAddress" runat="server" CssClass="" Text="Address"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="Multiline" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtAddress"
                                                                    CssClass="" ErrorMessage="Address Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" ValidationGroup="GSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="PnlParrents" runat="server" Visible="false">
                                                            <tr>
                                                                <td colspan="4" align="center">
                                                                    <asp:Label ID="Label32" runat="server" CssClass="" Text="Parents Details" Font-Bold="true"
                                                                        Font-Underline="true"></asp:Label>
                                                                    <div style="padding-left: 20px;">
                                                                        <asp:Label ID="lblCopy" runat="server" Text="Do You Want To Copy"></asp:Label>
                                                                        <asp:CheckBox ID="chkCopy" runat="server" AutoPostBack="true" OnCheckedChanged="lnkCopy_Click" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label8" runat="server" CssClass="" Text="Parent Name"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPName" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label9" runat="server" CssClass="" Text="RelationShip"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPRelationShip" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label10" runat="server" CssClass="" Text="Profession"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPProfession" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label11" runat="server" CssClass="" Text="Organization"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPOrganization" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label12" runat="server" CssClass="" Text="Email"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPEmailParents" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label13" runat="server" CssClass="" Text="Mobile"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPMobileParents" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="-" TargetControlID="txtPMobileParents">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label14" runat="server" CssClass="" Text="Residence Phone"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPResPhone" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="-" TargetControlID="txtPResPhone">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label15" runat="server" CssClass="" Text="Office Phone"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPOfficePhone" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="-" TargetControlID="txtPOfficePhone">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label16" runat="server" CssClass="" Text="Website"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPWebsite" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" CssClass="" Text="Address"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAddressParents" runat="server" CssClass="Multiline" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnAddParents" runat="server" CssClass="" OnClick="btnAddParents_Click"
                                                                    Text="Update" ValidationGroup="GSubmit" />
                                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false"
                                                                    ShowMessageBox="True" ValidationGroup="GSubmit" Font-Size="Large" ForeColor="Red" />
                                                                <%-- <asp:Button ID="btnPrintParent" runat="server" CssClass="" OnClick="btnPrint_Click"
                                                                    Text="Print" ValidationGroup="Back" />--%>
                                                                <asp:Label ID="lblMesagGuardian" runat="server" Font-Bold="true" Font-Size="12px"
                                                                    Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </colgroup>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlProgram" runat="server">
                    <div id="Program" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Program</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 17%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                    

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDegreeID" runat="server" CssClass="" Text="Degree Program"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rdbProgramRegular" runat="server" Text="Week Day" CssClass="textBox1"
                                                                    GroupName="DegreeId" AutoPostBack="True" OnCheckedChanged="rdbProgramRegular_CheckedChanged" />
                                                                <asp:RadioButton ID="rdbProgramWeekend" runat="server" Text="Weekend" CssClass="textBox1" Visible="false"
                                                                    GroupName="DegreeId" AutoPostBack="True" OnCheckedChanged="rdbProgramWeekend_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                     <td>
                                                                <asp:Label ID="Label60" runat="server" CssClass="" Text="Schoolof"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                  
                                                    <td>
                                                      <asp:DropDownList ID="Drpschool" runat="server" CssClass="textBox9" TabIndex="8" Width="350"
                                                AutoPostBack="True" OnSelectedIndexChanged="Drpschool_SelectedIndexChanged">
                                                
                                            </asp:DropDownList>
                                                    
                                                    </td>
                                                    </tr>
                                                    <tr>
                                                      <td colspan="2">
                                                    
                                                    <asp:CheckBox ID="chkintegrated" runat="server" Text="Is BBA + MBA Integrated Program"  Checked="false" Visible="false"  OnCheckedChanged="chkintegrated_CheckedChanged"/>
                                                    
                                                    </td></tr>

                                                    
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDegreeTypeId" runat="server" CssClass="" Text="Degree Type"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDegreeType" runat="server" CssClass="textBox11" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlDegreeType_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDegreeType"
                                                                    CssClass="" ErrorMessage="Degree Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="PSubmit"></asp:RequiredFieldValidator>
                                                            </td></tr> 
                                                            <tr>
                                                            <td>
                                                                <asp:Label ID="lblCourseType" runat="server" CssClass="" Text="Course Type"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="textBox11" Width="250" 
                                                                    AutoPostBack="True" onselectedindexchanged="ddlCourseType_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCourseType"
                                                                    CssClass="" ErrorMessage="Course Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="PSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                         <asp:Panel ID="pnlfoundation" runat="server" Visible="false">
                                                        <tr>
                                                            <td colspan="4">
                                                                <b><asp:Label ID="Label50" runat="server" CssClass="" Text="Other Course"></asp:Label></b>
                                                            </td>
                                                       </tr>
                                                      
                                                       <tr>
                                                            <td></td>
                                                            <td colspan="3">
                                                                <asp:RadioButton Checked="true" ID="chkNone" runat="server" Text="None"  GroupName="AIPC" />
                                                                <asp:RadioButton ID="chkAIPCBASIC" runat="server" Text="AIPC BASIC" GroupName="AIPC" />
                                                                <asp:RadioButton ID="chkAIPCAdvance" runat="server" Text="AIPC ADVANCED"  GroupName="AIPC" />
                                                                <br /><asp:RadioButton ID="chkAIPCADVANCEWith1Course" runat="server" Text="AIPC ADVANCED With ONE COURSE"  GroupName="AIPC" />
                                                                <asp:RadioButton ID="chkAIPCADVANCEWith2Course" runat="server" Text="AIPC ADVANCED WITH TWO COURSE"  GroupName="AIPC" /><br />
                                                                <asp:CheckBox ID="chkMQPCourse" runat="server" Text="MQP" AutoPostBack="True" 
                                                                    oncheckedchanged="chkMQPCourse_CheckedChanged" Visible="false" />
                                                                <asp:CheckBox ID="chkIELTSCourse" runat="server" Text="IELP" 
                                                                    AutoPostBack="True" oncheckedchanged="chkIELTSCourse_CheckedChanged" Visible="false" />
                                                                      <asp:RadioButton ID="Chkket" runat="server" Text="PET" 
                                                                    AutoPostBack="True" GroupName="AIPC" />
                                                            </td>
                                                        </tr>
                                                        </asp:Panel>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTermID" runat="server" CssClass="" Text="Term"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlTerm" runat="server" CssClass="textBox11" AutoPostBack="True" onselectedindexchanged="ddlCourseType_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="lblShift" runat="server" CssClass="" Text="Shift"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlShift" runat="server" CssClass="textBox11" OnSelectedIndexChanged="ddlCourseType_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlShift"
                                                                    CssClass="" ErrorMessage="Shift Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="PSubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="pnshift" runat="server" Visible="true">
                                                        <tr>
                                                         <td>
                                                                <asp:Label ID="Label53" runat="server" CssClass="" Text="Next Batch Shift Selection"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlnextShift" runat="server" CssClass="textBox11">
                                                                
                                                                </asp:DropDownList>
                                                               
                                                            </td>
                                                        </tr>
                                                       </asp:Panel>

                                                        <asp:Panel ID="pnlSC" runat="server" Visible="false">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label34" runat="server" CssClass="" Text="From Date"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSCFromDay" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCFromMonth" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCFromYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender34" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCFromYear" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender35" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCFromMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender36" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCFromDay" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCFromMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender61" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCFromDay">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender62" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCFromYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label35" runat="server" CssClass="" Text="To Date"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSCToDay" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCToMonth" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtSCToYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender37" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCToYear" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender38" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCToMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender39" runat="server" Enabled="True"
                                                                        TargetControlID="txtSCToDay" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender63" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCToMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender64" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCToDay">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender65" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtSCToYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Reading
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlReading" runat="server" CssClass="textBox11" TabIndex="2">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    Writing
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlWriting" runat="server" CssClass="textBox11" TabIndex="2">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Listening
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlListening" runat="server" CssClass="textBox11" TabIndex="2">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    Speaking
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSpeaking" runat="server" CssClass="textBox11" TabIndex="2">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Excellent</asp:ListItem>
                                                                        <asp:ListItem Value="2">Average</asp:ListItem>
                                                                        <asp:ListItem Value="3">Good</asp:ListItem>
                                                                        <asp:ListItem Value="4">Poor</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlSubject" runat="server" Visible="false">
                                                        <tr>
                                                            <td colspan="4">
                                                               <b> Subjects </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td colspan="3">
                                                                <asp:CheckBox Checked="true" ID="chkSubject1" runat="server" Text="ACC5001-ACCOUNTING PRINCIPLES & PRACTICE" />
                                                                <br /><asp:CheckBox Checked="true" ID="chkSubject2" runat="server" Text="ECO5002-ECONOMICS PRINCIPLES & PRACTICE" />
                                                               <br /><asp:CheckBox Checked="true" ID="chkSubject3" runat="server" Text="MAT5003-FUNDAMENTALS OF QUANTITATIVE METHODS" />
                                                               <br /><asp:CheckBox  Checked="true" ID="chkSubject4" runat="server" Text="FIN5004-PRINCIPLES OF FINANCE" />
                                                               <br /><asp:CheckBox  Checked="true" ID="chkSubject5" runat="server" Text="MGM5005-PERSPECTIVE ON MANAGEMENT" />
                                                               <br /><asp:CheckBox  Checked="true" ID="chkSubject6" runat="server" Text="MKT5006-PRINCIPLES OF MARKETING" />
                                                               <br /><asp:CheckBox  Checked="true" ID="chkSubject7" runat="server" Text="MGM5007-OPERATIONS MANAGEMENT" />
                                                            </td>
                                                        </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel6" runat="server" Visible="false">
                                                        <tr>
                                                            <td>
                                                                Add Fee Group
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkAddProgramFeeGroup" runat="server"  onclick="shopPopup();" />
                                                            </td>
                                                        </tr>
                                                        </asp:Panel>
                                                        <tr>
                                                         <td colspan="4">
                                                        <asp:Label ID="lblprogrammess" Font-Bold="true" Text="" runat="server"></asp:Label>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnSaveProgram" runat="server" CssClass="" Text="Update" OnClick="btnSaveProgram_Click"
                                                                    ValidationGroup="PSubmit" />
                                                                <%--<asp:Button ID="Button11" runat="server" CssClass="" OnClick="btnPrint_Click" Text="Print"
                                                                    ValidationGroup="Back" />--%>
                                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="false"
                                                                    ShowMessageBox="True" ValidationGroup="PSubmit" Font-Size="Large" ForeColor="Red" />
                                                                <asp:Label ID="lblProgramMesag" runat="server" Font-Bold="true" Font-Size="12px"
                                                                    Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </colgroup>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlTocMain" runat="server">
                    <div id="Div6" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    TOC
                                </h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <colgroup span="1" style="width: 26%;">
                                                    <colgroup span="1" style="width: 26%;">
                                                        <colgroup span="1" style="width: 28%;">
                                                            <colgroup span="1" style="width: 26%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblTransferUniversity" runat="server" CssClass="" Text="TOC Case"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTransferUniversity" runat="server" CssClass="textBox11"
                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlTransferUniversity_SelectedIndexChanged"
                                                                            Width="142px">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlTransferUniversity"
                                                                            CssClass="" ErrorMessage="TOC Case Required!" Font-Size="Large" ForeColor="Red"
                                                                            InitialValue="0" SetFocusOnError="true" Display="None" ValidationGroup="TOCSubmit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <asp:Panel ID="pnlToc" runat="server" Visible="true">
                                                                     
                                                                    <td>
                                                                        <asp:Label ID="Label48" runat="server" CssClass="" Text="College / University Name"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlUniversityName" runat="server" CssClass="textBox11" Width="142px" AutoPostBack="True" OnSelectedIndexChanged="ddlUniversityName_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="999">Others</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="ddlUniversityName"
                                                                            CssClass="" ErrorMessage="College / University Name Required!" Font-Size="Large"
                                                                            ForeColor="Red" SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="TOCSubmit"></asp:RequiredFieldValidator>--%>
                                                                    </td>   
                                                                        
                                                                   


                                                                </tr>
                                                                <tr>
                                                                 <td>
                                                                        <asp:Label ID="Label49" runat="server" CssClass="" Text="CGPA"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCGPATOC" runat="server" CssClass="textBox1" AutoPostBack="True" OnTextChanged="txtCGPATOC_TextChanged"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender67" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtCGPATOC">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtCGPATOC"
                                                                            CssClass="" ErrorMessage="CGPA Required!" Font-Size="Large"
                                                                            ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="TOCSubmit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <asp:Panel ID="pnlOtherUniversity" runat="server" Visible="false">
                                                                    <td>
                                                                        <asp:Label ID="lblUniversityNameProgram" runat="server" CssClass="" Text="Others"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtUniversityNameProgram" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtUniversityNameProgram"
                                                                            CssClass="" ErrorMessage="College / University Name Required!" Font-Size="Large"
                                                                            ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="TOCSubmit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    </asp:Panel>
                                                                 </tr> 
                                                                 
                                                                <asp:Panel ID="pnlCgpAToc" runat="server" Visible="false">                                                                
                                                                <tr>                                                                    
                                                                    <td>
                                                                        Upload Document
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="fuTocDocument" runat="server" CssClass="FUpload" />
                                                                    </td>
                                                                    <td>
                                                                            <asp:Label ID="lblDocumentProcess" runat="server" CssClass="" Text="Document Process"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlDocumentProcess" runat="server" CssClass="textBox11" Width="142px">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    <asp:Panel ID="pnlHide1" runat="server" Visible="false">
                                                                    <td>
                                                                        Add Fee Group
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkTocAddGroup" runat="server"  onclick="shopPopup();" />
                                                                    </td>
                                                                    </asp:Panel>
                                                                </tr>
                                                                 <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label21" runat="server" CssClass="" Text="Total Nos. of Course Offered"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTotalNoOfCourse" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="-" TargetControlID="txtTotalNoOfCourse">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label24" runat="server" CssClass="" Text="Followup Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFollowDate" runat="server" CssClass="textBox1" Width="40px" MaxLength="2" ReadOnly="true"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFollowMonth" runat="server" CssClass="textBox1" Width="40px" MaxLength="2" ReadOnly="true"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFollowYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4" ReadOnly="true"></asp:TextBox>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender25" runat="server" Enabled="True"
                                                                            TargetControlID="txtFollowYear" WatermarkText="YYYY">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender26" runat="server" Enabled="True"
                                                                            TargetControlID="txtFollowMonth" WatermarkText="MM">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender27" runat="server" Enabled="True"
                                                                            TargetControlID="txtFollowDate" WatermarkText="DD">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtFollowMonth">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtFollowDate">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtFollowYear">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    
                                                                    <td>
                                                                        <asp:Label ID="Label25" runat="server" CssClass="" Text="Finance Details"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFinanceDetails" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label26" runat="server" CssClass="" Text="Fees Paid"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFeesPaid" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="-" TargetControlID="txtFeesPaid">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label27" runat="server" CssClass="" Text="Receipt No"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtReceiptNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label28" runat="server" CssClass="" Text="Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDate" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                        <asp:TextBox ID="txtMonth" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                                        <asp:TextBox ID="txtYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender19" runat="server" Enabled="True"
                                                                            TargetControlID="txtYear" WatermarkText="YYYY">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender20" runat="server" Enabled="True"
                                                                            TargetControlID="txtMonth" WatermarkText="MM">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender21" runat="server" Enabled="True"
                                                                            TargetControlID="txtDate" WatermarkText="DD">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtMonth">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtDate">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtYear">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Submission of CDD
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkCDD" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        Transcript
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkTranscript" runat="server" />
                                                                    </td>
                                                                </tr> 
                                                                <tr>
                                                                    <td>
                                                                        Letter from University
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkLetter" runat="server" />
                                                                    </td>
                                                                     <td>
                                                                      
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="Chkmqptoc"  Text="MQP TOC " runat="server"  />
                                                                    </td>
                                                                </tr>
                                                                <asp:Panel ID="pnlHIDE" runat="server" Visible="false">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label22" runat="server" CssClass="" Text="Undertaking for TOC Case"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtUnderTakingForToc" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label23" runat="server" CssClass="" Text="University Attended"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtUniversityAttended" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    </td>
                                                                </tr>                                                                
                                                                </asp:Panel>
                                                                </asp:Panel>                                                                
                                                                </asp:Panel>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:Button ID="btnSubmitToc" runat="server" CssClass="" Text="Add" OnClick="btnSaveTOC_Click"
                                                                            ValidationGroup="TOCSubmit" />
                                                                        <asp:Button ID="btnUpdateToc" runat="server" Text="Update" CssClass="" OnClick="btnUpdateTOC_Click"
                                                                            Visible="false" />
                                                                        <asp:Button ID="btnDeleteTOC" runat="server" Text="Delete" CssClass="" OnClick="btnDeleteTOC_Click"
                                                                            Visible="false" />
                                                                             <asp:Button ID="btnViewTOC" runat="server" CssClass="" Text="View" OnClick="btnViewTOC_Click"
                                                                            OnClientClick="document.getElementById('form1').target ='_blank';" />
                                                                        <%--<asp:Button ID="Button9" runat="server" CssClass="" OnClick="btnPrint_Click" Text="Print"
                                                                    ValidationGroup="Back" />--%>
                                                                        <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowSummary="false"
                                                                            ShowMessageBox="True" ValidationGroup="TOCSubmit" Font-Size="Large" ForeColor="Red" />
                                                                        <asp:Label ID="lblTOCMesag" runat="server" Font-Bold="true" Font-Size="12px" Text=""
                                                                            ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="gvTOC" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
                                                                            DataKeyNames="Id" EmptyDataText="There are no records to display." GridLines="Both"
                                                                            OnRowDataBound="gvgvTOC_RowDataBound" OnRowCommand="GvTOC_RowCommand">
                                                                            <FooterStyle CssClass="GridFooter" />
                                                                            <RowStyle CssClass="GridItem" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="University Name" Visible="true">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkId" runat="server" CommandArgument='<%#Bind("Id") %>' CommandName="Modify"
                                                                                            Text='<%#Bind("UniversityName") %>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total No of Course">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPassportNo" runat="server" Text='<%#Bind("TotalNoOfCourse") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Issue Date">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIssueDate" runat="server" Text='<%#Bind("UniversityAttended") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Fees Paid">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExpireDate" runat="server" Text='<%# Bind("FeesPaid") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Download" Visible="true">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkDownLoad" runat="server" CommandArgument='<%#Bind("FileName") %>' CommandName="DownLoad"
                                                                                            Text="Download" OnClientClick="document.getElementById('form1').target ='_blank';"></asp:LinkButton>
                                                                                        <asp:HiddenField ID="hdFNo" runat="server" Value='<%#Bind("FileName") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle CssClass="GridHeader" />
                                                                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                                            <SelectedRowStyle CssClass="GridRowOver" />
                                                                            <EditRowStyle />
                                                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </colgroup>
                                                        </colgroup>
                                                    </colgroup>
                                                </colgroup>
                                            </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlFinance" runat="server">
                    <div id="Div2" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Finance
                                </h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 22%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                        <tr> 
                                                            <td>
                                                                <asp:Label ID="lblType" runat="server" CssClass="" Text="Fee Waiver Category"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td colspan="1">
                                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="textBox11" Width="142px"
                                                                    OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="ddlType"
                                                                    CssClass="" ErrorMessage="Category Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="FINANCESubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDiscountType" runat="server" CssClass="" Text="Fee Waiver Type"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td colspan="1">
                                                                <asp:DropDownList ID="ddlDiscountType" runat="server" CssClass="textBox11" Width="143px"
                                                                    OnSelectedIndexChanged="ddlDiscountType_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDiscountType"
                                                                    CssClass="" ErrorMessage="Fee Waiver Type Required!" Font-Size="Large" ForeColor="Red"
                                                                    SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="FINANCESubmit"></asp:RequiredFieldValidator>
                                                            </td>
                                                          </tr>

                                                             <asp:Panel ID="pnl_Hrd" runat="server"  Visible="false">
                                                          <tr>
                                                          <td></td>
                                                          <td></td>
                                                          <td>
                                                                <asp:Label ID="Label56" runat="server" CssClass="" Text="Sharjah HRD"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td style="float:left; vertical-align: top;s" colspan="1">
                                                                <asp:DropDownList ID="ddlHrdDepartment" runat="server" CssClass="textBox11" Width="143px">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>                                                               
                                                            <asp:ImageButton ID="btnShowSharjahHRDPopup" runat="server" ImageUrl="~/Icons/new.png" CausesValidation="false" /></td>
                                                          </tr>
                                                         </asp:Panel> 

                                                         
                                                              <asp:Panel ID="pnl_show" runat="server"  Visible="false">
                                                           <tr>
                                                           <td>
                                                           <asp:RadioButton ID="rad_Self"  value="S" Text="Self" runat="server" AutoPostBack="true" OnCheckedChanged="rad_self_checked_changed"     GroupName="VgRad" />
                                                           <asp:RadioButton ID="rad_Family" value="F" Text="Family" runat="server"  GroupName="VgRad" AutoPostBack="True" OnCheckedChanged="rad_family_checked_changed" />
                                                           </td>
                                                           <asp:Panel ID="pnl_dropdown" runat="server" Visible="false">
                                                           <td>
                                                           <asp:DropDownList ID="ddl_Family" CssClass="textBox11" Width="143px" runat="server">
                                                           <asp:ListItem Value="Father" Text="Father" ></asp:ListItem>
                                                           <asp:ListItem Value="Mother" Text="Mother"></asp:ListItem>
                                                           <asp:ListItem Value="Brother" Text="Brother"></asp:ListItem>
                                                           <asp:ListItem Value="Sister" Text="Sister"></asp:ListItem>
                                                           <asp:ListItem Value="Husband" Text="Husband"></asp:ListItem>
                                                           <asp:ListItem Value="Wife" Text="Wife"></asp:ListItem>
                                                            <asp:ListItem Value="Son" Text="Son"></asp:ListItem>
                                                             <asp:ListItem Value="Daughter" Text="Daughter"></asp:ListItem>
                                                           </asp:DropDownList>
                                                           </td>
                                                           </asp:Panel>
                                                           </tr>
                                                           </asp:Panel>
                                                         

                                                        <tr>
                                                            <asp:Panel ID="hIDDEN" runat="server" Visible="true">
                                                            <td>
                                                                Percentage
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPercentage" runat="server" CssClass="textBox11" Width="143"
                                                                OnSelectedIndexChanged="ddlPercentage_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            </asp:Panel>
                                                            <td>
                                                                Letter Submitted
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkLetterSubmitted" runat="server" />
                                                            </td>
                                                       
                                                           </tr>
                                                        <tr> 
                                                        <td>  <asp:Label ID="lblTotalFees" runat="server" CssClass="" Text="Total Fees"  Visible="true"></asp:Label>
                                                      </td>    <td>    <asp:TextBox ID="txtTotalFees" runat="server" CssClass="textBox1" Text="0" ReadOnly="true" Visible="true"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="." TargetControlID="txtTotalFees">
                                                                </cc1:FilteredTextBoxExtender>
                                                          </td>    
                                                          <td>
                                                                <asp:Label ID="Label52" runat="server" CssClass="" Text="Net Payable"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNetFees" runat="server"  Text="0" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                            </td> 
                                                          
                                                          
                                                          
                                                       
                                                       
                                                           
                                                            </tr>
                                                        <tr>
                                                        <td>
                                                                <asp:Label ID="lblDiscount" runat="server" CssClass="" Text="Fee Waiver"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDiscount" Text="0"  runat="server" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="." TargetControlID="txtDiscount">
                                                                </cc1:FilteredTextBoxExtender>
                                                                
                                                              
                                                            </td> 
                                                            
                                                            
                                                                <td>
                                                                <asp:Label ID="lblFees" runat="server" CssClass="" Text="Alloted Fund"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFees" Text="0" runat="server" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" FilterType="Custom,Numbers"
                                                                    ValidChars="." TargetControlID="txtFees">
                                                                </cc1:FilteredTextBoxExtender>
                                                            </td> 
                                                            
                                                          </tr>
                                                        <tr>  
                                                        
                                                             
                                                            <td>
                                                                <asp:Label ID="Label36" runat="server" CssClass="" Text="Utilized Fund"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAvailableFund" Text="0" runat="server" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        
                                                        <td>
                                                                <asp:Label ID="Label51" runat="server" CssClass="" Text="Balance Fund"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBalanceFund" Text="0" runat="server" CssClass="textBox1" ReadOnly="true"></asp:TextBox>
                                                            </td> 
                                                             
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblRemarksPrograms" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarksPrograms" runat="server" CssClass="textBox11" TextMode="MultiLine"
                                                                    Height="50px" Width="143px"></asp:TextBox>
                                                            </td> 
                                                            <asp:Panel ID="pnlHidddddd" runat="server" Visible="false"><td>
                                                                NAU Fee Structure
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkNauFees" runat="server"/>
                                                            </td>
                                                             <td>
                                                                Add Fee Group
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="ckkFinance" runat="server"  onclick="shopPopup();" />
                                                            </td>
                                                            </asp:Panel>
                                                        </tr>
                                                        <tr>
                                                        
                                                        <td>
                                                        Special Talent
                                                        
                                                        
                                                        </td>
                                                         <td>
                                                                <asp:TextBox ID="Txtspecial" runat="server" CssClass="textBox11" TextMode="MultiLine"
                                                                    Height="50px" Width="143px"></asp:TextBox>
                                                            </td>
                                                            <asp:Panel ID="pnlsucalum" runat="server" Visible="false">
                                                        
                                                          <td>
                                                      Sibling /Sun Alumni Student ID
                                                         <asp:ImageButton ID="lnksearch" runat="server" ImageUrl="~/Icons/search.jpg" OnClick="lnksearch_click" Width="20%" Height="20%" AlternateText="Search Student" />
                                                        
                                                        </td>
                                                        <td>  <asp:TextBox ID="Txtstud" runat="server" CssClass="textBox11" ></asp:TextBox>
                                                        
                                                                                                </td>
                                                         </asp:Panel>
                                                        </tr>
                                                           <td colspan="2">
                                                        <asp:CheckBox ID="chkairticket" runat="server" Text= "Is Applicable for Airticket"  Enabled="false" />
                                                        </td>
                                                        <tr>
                                                        <td colspan="2">
                                                         <asp:Label ID="Lblairticket" runat="server" Text=""></asp:Label>
                                                        
                                                        </td>
                                                      
                                                        </tr>
                                                        

                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnSaveFinance" runat="server" CssClass="" Text="Update" OnClick="btnSaveFinace_Click"
                                                                    ValidationGroup="FINANCESubmit" />
                                                                <%--<asp:Button ID="btnPrintProgram" runat="server" CssClass="" OnClick="btnPrint_Click"
                                                        Text="Print" ValidationGroup="Back" />--%>
                                                                <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowSummary="false"
                                                                    ShowMessageBox="True" ValidationGroup="FINANCESubmit" Font-Size="Large" ForeColor="Red" />
                                                                <asp:Label ID="lblMesagProgram" runat="server" Font-Bold="true" Font-Size="12px"
                                                                    Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       
                                                    </colgroup>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlTransport" runat="server">
                    <div id="Transport" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Transport</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblIsTransportationRequired" runat="server" CssClass="" Text="Transportation Required"></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:RadioButton ID="rdbTransportationYes" runat="server" AutoPostBack="True" CssClass=""
                                                    GroupName="Transportation" OnCheckedChanged="rdbTransportationYes_CheckedChanged"
                                                    Text="Yes" />
                                                <asp:RadioButton ID="rdbTransportationNo" runat="server" AutoPostBack="True" CssClass=""
                                                    GroupName="Transportation" OnCheckedChanged="rdbTransportationNo_CheckedChanged"
                                                    Text="No" />
                                            </td>
                                            <td style="width: 20%">
                                            </td>
                                            <td style="width: 30%">
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlTransportation" runat="server" Visible="true">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTransportation" runat="server" CssClass="" Text="Transportation to be Picked up From"></asp:Label><span style="color:Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTransportation" runat="server" CssClass="textBox11">
                                                      <%--  <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="8">DEIRA / KARAMA / BURDUBAI / SATWA</asp:ListItem>
                                                        <asp:ListItem Value="9">UMM SEQUIM 2 / JUMEIRAH / AL SAFA / MIRDIFF</asp:ListItem>
                                                        <asp:ListItem Value="10">QUSAIS</asp:ListItem>
                                                        <asp:ListItem Value="11">AJMAN AREAS / AJMAN IND. AREAS</asp:ListItem>
                                                        <asp:ListItem Value="12">EMIRATES HILLS / EMIRATES GREENS / EMIRATES MEADOWS / EMIRATES GARDENS</asp:ListItem>
                                                        <asp:ListItem Value="13">SHARJAH AREAS</asp:ListItem>--%>
                                                        <%--<asp:ListItem Value="1">Abu Dhabi</asp:ListItem>
                                                        <asp:ListItem Value="2">Dubai </asp:ListItem>
                                                        <asp:ListItem Value="3">Sharjah</asp:ListItem>
                                                        <asp:ListItem Value="4">Ajman</asp:ListItem>
                                                        <asp:ListItem Value="5">Umm Al Qaiwain</asp:ListItem>
                                                        <asp:ListItem Value="6">Ras Al Khaimah</asp:ListItem>
                                                        <asp:ListItem Value="7">Fujairah</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlTransportation"
                                                        CssClass="" ErrorMessage="Transportation to be Picked up From Required!" Font-Size="Large"
                                                        ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="TransportSubmit"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblExaxtLocation" runat="server" CssClass="" Text="Exact Location"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExaxtLocation" runat="server" CssClass="Multiline" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <asp:Panel ID="Panel2" runat="server" Visible="false">
                                            <tr>
                                            
                                            <td>
                                                                Add Fee Group
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkTransportation" runat="server"  onclick="shopPopup();" />
                                                            </td>
                                            </tr>
                                            </asp:Panel>
                                        </asp:Panel>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="3">
                                                    <asp:Button ID="btnSubmitTransportation" runat="server" CssClass="" Text="Update"
                                                        OnClick="btnSubmitTransportation_Click" ValidationGroup="TransportSubmit" />
                                                    <asp:Button ID="btnDeleteTransportation" runat="server" CssClass="" Text="Delete"
                                                        OnClick="btnDeleteTransportation_Click"/>
                                                    <%--<asp:Button ID="Button5" runat="server" CssClass="" OnClick="btnPrint_Click" Text="Print"
                                            ValidationGroup="Back" />--%>
                                                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowSummary="false"
                                                        ShowMessageBox="True" ValidationGroup="TransportSubmit" Font-Size="Large" ForeColor="Red" />
                                                    <asp:Label ID="lblTransportaionMesag" runat="server" Font-Bold="true" Font-Size="12px"
                                                        Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                </td>
                                            </tr>
                                        </colgroup> </colgroup> </colgroup> </colgroup>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>


                            
                                                                            <asp:GridView ID="gvTransportRate" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
                                                                                 EmptyDataText="There are no records to display." GridLines="Both">
                                                                               
                                                                                <FooterStyle CssClass="GridFooter" />
                                                                                <RowStyle CssClass="GridItem" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                  <%--  <asp:TemplateField HeaderText="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkId" runat="server" CommandArgument='<%#Bind("Id") %>' CommandName="Modify"
                                                                                                Text='<%#Bind("Id") %>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>
                                                                                    <asp:TemplateField HeaderText="Area Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblAreaName" runat="server" Text='<%#Bind("areaname") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Rate">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblRate" runat="server" Text='<%#Bind("rate") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <HeaderStyle CssClass="GridHeader" />
                                                                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                                                <SelectedRowStyle CssClass="GridRowOver" />
                                                                                <EditRowStyle />
                                                                                <AlternatingRowStyle CssClass="GridAltItem" />
                                                                            </asp:GridView>





                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlMediaSourceMain" runat="server">
                    <div id="Div4" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Media Source
                                </h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 22%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                        <tr>
                                                            <td>
                                                                Media Source<span style="color:Red">*</span>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                (Select multiple items by hold down control key [CTRL])
                                                            </td>
                                                            <td>
                                                                <asp:ListBox ID="lbMediaSource" runat="server"  AutoPostBack="true" CssClass="listboxMedisSource" SelectionMode="Multiple"
                                                                    Width="200px" Height="300px" 
                                                                    onselectedindexchanged="lbMediaSource_SelectedIndexChanged"></asp:ListBox>
                                                            </td>
                                                            </tr>                                                             
                                <tr>
                                <td>Agent Name</td>
                                <td>
                                 <cc3:ComboBox runat="server" ID="drpagent" Width="200" MenuWidth="600" Height="150" EmptyText="Select a Agent ..."
	    
	    >
                                  
                                       
         <HeaderTemplate>
	           <div class="header c2">Agency</div>
             <div class="header c3">Name</div>
	        <div class="header c4">State</div>
	    </HeaderTemplate>
	    <ItemTemplate>
           <%-- <div title="<%# Eval("Agencyname").ToString() + " from " + Eval("Agentname").ToString() %>">--%>
           <div>
	             <div class="item c2"><%# Eval("AgencyName")%></div>
	            <div class="item c3"><%# Eval("AgentName")%></div>
                <div class="item c4"><%# Eval("State")%></div>
            </div>
	    </ItemTemplate>
	    <FooterTemplate>
	        Displaying <%# Container.ItemsCount %> items.
	    </FooterTemplate>
	</cc3:ComboBox>



                                     
                                
                                
                                
                                </td>
                                </tr>
                                <tr>
                                
                                                             <td> 
                                                            <asp:Label ID="lblMedia" runat="server" Text = "CMS Media source" Visible= "false" ></asp:Label>
                                                              </td> 
                                                              <td>
                                                             <asp:TextBox ID="txtCMSMedia" ReadOnly = "true" TextMode = "Multiline" 
                                                                    runat="server"  Width="200px" Height="69px" Visible= "false" ></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:Button ID="btnMediaSource" runat="server" CssClass="" Text="Update" OnClick="btnSubmitMediaSource_Click" />
                                                                <%-- <asp:Button ID="btnPrintMediaSource" runat="server" CssClass="" OnClick="btnPrint_Click"
                                                        Text="Print" ValidationGroup="Back" />--%>
                                                                <asp:Label ID="lblMesagMediaSource" runat="server" Font-Bold="true" Font-Size="12px"
                                                                    Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </colgroup>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlHostelMain" runat="server">
                    <div id="Div5" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Hostel
                                </h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 22%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblIsHostelRequired" runat="server" CssClass="" Text="Hostel Required"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%">
                                                                <asp:RadioButton ID="rdbHostelYes" runat="server" AutoPostBack="True" CssClass=""
                                                                    GroupName="Hostel" OnCheckedChanged="rdbHostelYes_CheckedChanged" Text="Yes" />
                                                                <asp:RadioButton ID="rdbHostelNo" runat="server" AutoPostBack="True" CssClass=""
                                                                    GroupName="Hostel" OnCheckedChanged="rdbHostelNo_CheckedChanged" Text="No" />
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="pnlHostel" runat="server" Visible="false">
                                                            <%--Hostel Content--%>
                                                            <tr>
                                                                <td align="center" colspan="4">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="" Font-Bold="true" Font-Underline="true"
                                                                        Text="Hostel Details"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Name of Hostel<span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlNameOfHostel" runat="server" CssClass="textBox11" Width="142px"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlNameOfHostel_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlNameOfHostel"
                                                                        CssClass="" ErrorMessage="Name of Hostel Required!" Font-Size="Large" ForeColor="Red"
                                                                        SetFocusOnError="true" Display="None" ValidationGroup="HostelSubmit"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    Phone No
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    From Date
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDateOfHostel" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtMonthOfHostel" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtYearOfHostel" runat="server" CssClass="textBox1" Width="50px"
                                                                        MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" runat="server" Enabled="True"
                                                                        TargetControlID="txtYearOfHostel" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender16" runat="server" Enabled="True"
                                                                        TargetControlID="txtMonthOfHostel" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender17" runat="server" Enabled="True"
                                                                        TargetControlID="txtDateOfHostel" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtMonthOfHostel">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtDateOfHostel">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtYearOfHostel">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                
                                                                <td>
                                                                    To Date
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDateOfHostelTo" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtMonthOfHostelTo" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtYearOfHostelTo" runat="server" CssClass="textBox1" Width="50px"
                                                                        MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender40" runat="server" Enabled="True"
                                                                        TargetControlID="txtYearOfHostelTo" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender41" runat="server" Enabled="True"
                                                                        TargetControlID="txtMonthOfHostelTo" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender42" runat="server" Enabled="True"
                                                                        TargetControlID="txtDateOfHostelTo" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender68" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtMonthOfHostelTo">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender69" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtDateOfHostelTo">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender70" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtYearOfHostelTo">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>

                                                                </tr>
                                                            <tr>
                                                                <td align="center" colspan="4">
                                                                    <asp:Label ID="Label3" runat="server" CssClass="" Font-Bold="true" Font-Underline="true"
                                                                        Text="Finance Details"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Fee Paid
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFeePaid" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                                                        TargetControlID="txtFeePaid" ValidChars=".">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    Receipt No
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtReceiptNo1" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                                <asp:Panel ID="Panel3" runat="server" Visible="false">
                                                                <tr>
                                                                <td>
                                                                    Add Fee Group
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkHostelAddGroup" runat="server"  onclick="shopPopup();" />
                                                                </td>
                                                                </tr>
                                                            </asp:panel>
                                                            <tr>
                                                                <td style="width: 23%">
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:Button ID="btnSubmitHostel" runat="server" CssClass="" OnClick="btnSubmitHostel_Click"
                                                                        Text="Update" ValidationGroup="HostelSubmit" />
                                                                    <asp:Button ID="btnDeleteHostel" runat="server" CssClass="" OnClick="btnDeleteHostel_Click"
                                                                        Text="Delete"/>
                                                                    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowSummary="false"
                                                                        ShowMessageBox="True" ValidationGroup="HostelSubmit" Font-Size="Large" ForeColor="Red" />
                                                                    <asp:Label ID="lblMesagHostel" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="Blue"
                                                                        Text="" CssClass="labelMesag"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4">
                                                                    <asp:Label ID="Label4" runat="server" CssClass="" Font-Bold="true" Font-Underline="true"
                                                                        Text="Medical History"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Medical History Date
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMedicalHistoryDate" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtMedicalHistoryMonth" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtMedicalHistoryYear" runat="server" CssClass="textBox1" Width="50px"
                                                                        MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="txtWM_UserID" runat="server" Enabled="True" TargetControlID="txtMedicalHistoryYear"
                                                                        WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                                                                        TargetControlID="txtMedicalHistoryMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                                                        TargetControlID="txtMedicalHistoryDate" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtMedicalHistoryMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtMedicalHistoryDate">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtMedicalHistoryYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtMedicalHistoryDate"
                                                                        CssClass="" ErrorMessage="History Date Required!" Font-Size="Large" ForeColor="Red"
                                                                        SetFocusOnError="true" Display="None" ValidationGroup="HostelMSubmit"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Medical History
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="txtMedicalHistory" runat="server" CssClass="Multiline" TextMode="MultiLine"
                                                                        Width="487px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Upload Document
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:FileUpload ID="fuUploadDocument" runat="server" CssClass="FUpload" />&nbsp;&nbsp;&nbsp;
                                                                    <asp:Button ID="btnAddMHistory" runat="server" Text="Add" Height="20px" Font-Size="8pt"
                                                                        Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                            <tr>
                                                                <td style="width: 23%">
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnAddHostelMHistory" runat="server" CssClass="" OnClick="btnAddHostelMHistory_Click"
                                                                        Text="Add" ValidationGroup="HostelMSubmit" />
                                                                    <asp:ValidationSummary ID="ValidationSummary13" runat="server" ShowSummary="false"
                                                                        ShowMessageBox="True" ValidationGroup="HostelMSubmit" Font-Size="Large" ForeColor="Red" />
                                                                    <asp:Label ID="lblMHistory" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="Blue"
                                                                        Text="" CssClass="labelMesag"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="gvMedicalHistory" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
                                                                                DataKeyNames="Id" EmptyDataText="There are no records to display." GridLines="Both"
                                                                                OnRowCommand="gvMedicalHistory_RowCommand" OnRowDataBound="gvMedicalHistory_RowDataBound">
                                                                                <FooterStyle CssClass="GridFooter" />
                                                                                <RowStyle CssClass="GridItem" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkId" runat="server" CommandArgument='<%#Bind("Id") %>' CommandName="Modify"
                                                                                                Text='<%#Bind("Id") %>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Medical History Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblMedicalHistoryDate" runat="server" Text='<%#Bind("HistoryDate") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Medical History">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblMedicalHistory" runat="server" Text='<%#Bind("MedicalHistory") %>'></asp:Label>
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
                                                                </td>
                                                            </tr>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlVisa" runat="server">
                    <div id="Visa" runat="server">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    VISA / Passport / National ID Card / Driving Licence Id</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <asp:Panel ID="pnlVisaD" runat="server" Visible="true">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblVisaType" runat="server" CssClass="" Text="Document Type"></asp:Label><span style="color:Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlVisaType" runat="server" AutoPostBack="True" CssClass="textBox11"
                                                        OnSelectedIndexChanged="ddlVisaType_SelectedIndexChanged" Width="142px">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem  Selected="True" Value="1">National ID Card</asp:ListItem>
                                                        <asp:ListItem Value="2">Visa</asp:ListItem>
                                                        <asp:ListItem Value="3">Passport</asp:ListItem>
                                                        <asp:ListItem Value="4">Driving Licence ID</asp:ListItem>
                                                          
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlVisaType"
                                                        CssClass="" ErrorMessage="Document Type Required!" Font-Size="Large" ForeColor="Red"
                                                        SetFocusOnError="true" Display="None" ValidationGroup="VisaInfoSubmit" InitialValue="0"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <asp:Panel ID="pnlVisaDetails" runat="server" Visible="true">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTypeOfVisa" runat="server" CssClass="" Text="Visa Type"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTypeofvisa" runat="server" CssClass="textBox1"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSponsor" runat="server" CssClass="" Text="Sponsor Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSponsor" runat="server" CssClass="textBox1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCardNo" runat="server" CssClass="" Text="Visa No"></asp:Label><span style="color:Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCardNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtCardNo"
                                                        CssClass="" ErrorMessage="Card No Required!" Font-Size="Large" ForeColor="Red"
                                                        SetFocusOnError="true" Display="None" ValidationGroup="VisaInfoSubmit"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPlaceOfIssue" runat="server" CssClass="" Text="Visa Place of Issue"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPlaceOfIssue" runat="server" CssClass="textBox1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%">
                                                    <asp:Label ID="lblIssueDate" runat="server" CssClass="" Text="Visa Date of Issue"></asp:Label><span style="color:Red">*</span>
                                                </td>
                                                <td width="30%">
                                                    <asp:TextBox ID="txtIssueDate" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                    <asp:TextBox ID="txtIssueMonth" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                    <asp:TextBox ID="txtIssueYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True"
                                                        TargetControlID="txtIssueYear" WatermarkText="YYYY">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" Enabled="True"
                                                        TargetControlID="txtIssueMonth" WatermarkText="MM">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True"
                                                        TargetControlID="txtIssueDate" WatermarkText="DD">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" FilterType="Custom,Numbers"
                                                        ValidChars="." TargetControlID="txtIssueMonth">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" FilterType="Custom,Numbers"
                                                        ValidChars="." TargetControlID="txtIssueDate">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" FilterType="Custom,Numbers"
                                                        ValidChars="." TargetControlID="txtIssueYear">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtIssueDate"
                                                        CssClass="" ErrorMessage="Date of Issue Required!" Font-Size="Large" ForeColor="Red"
                                                        SetFocusOnError="true" Display="None" ValidationGroup="VisaInfoSubmit"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="20%">
                                                    <asp:Label ID="lblExpireDate" runat="server" CssClass="" Text="Visa Date of Expiry"></asp:Label><span style="color:Red">*</span>
                                                </td>
                                                <td width="30%">
                                                    <asp:TextBox ID="txtExpireDate" runat="server" CssClass="textBox1" Width="40px" MaxLength="2"></asp:TextBox>
                                                    <asp:TextBox ID="txtExpireMonth" runat="server" CssClass="textBox1" Width="40px"
                                                        MaxLength="2"></asp:TextBox>
                                                    <asp:TextBox ID="txtExpireYear" runat="server" CssClass="textBox1" Width="50px" MaxLength="4"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" Enabled="True"
                                                        TargetControlID="txtExpireYear" WatermarkText="YYYY">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" Enabled="True"
                                                        TargetControlID="txtExpireMonth" WatermarkText="MM">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" Enabled="True"
                                                        TargetControlID="txtExpireDate" WatermarkText="DD">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" FilterType="Custom,Numbers"
                                                        ValidChars="." TargetControlID="txtExpireMonth">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" FilterType="Custom,Numbers"
                                                        ValidChars="." TargetControlID="txtExpireDate">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" FilterType="Custom,Numbers"
                                                        ValidChars="." TargetControlID="txtExpireYear">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtExpireDate"
                                                        CssClass="" ErrorMessage="Date of Expiry Required!" Font-Size="Large" ForeColor="Red"
                                                        SetFocusOnError="true" Display="None" ValidationGroup="VisaInfoSubmit"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" CssClass="" Text="Country Of Issue"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCountryOfIssue" runat="server" CssClass="textBox11" Width="145px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Upload Document
                                                </td>
                                                <td colspan="2">
                                                    <asp:FileUpload ID="fuVisaInfo" runat="server" CssClass="FUpload" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 23%">
                                                </td>
                                                <td colspan="3">
                                                    <asp:Button ID="btnSubmitVisaInfo" runat="server" CssClass="" OnClick="btnAddVisaInfo_Click"
                                                        Text="Add" ValidationGroup="VisaInfoSubmit" />
                                                    <asp:Button ID="btnUpdateVisa" runat="server" Text="Update" CssClass="" OnClick="btnUpdateVisa_Click"
                                                        Visible="false" />
                                                    <%-- <asp:Button ID="btnPrintVisaInfo" runat="server" CssClass="" OnClick="btnPrint_Click"
                                            Text="Print" ValidationGroup="Back" />--%>
                                                    <asp:ValidationSummary ID="ValidationSummary10" runat="server" ShowSummary="false"
                                                        ShowMessageBox="True" ValidationGroup="VisaInfoSubmit" Font-Size="Large" ForeColor="Red" />
                                                    <asp:Label ID="lblVisaInfoMesag" runat="server" Font-Bold="true" Font-Size="12px"
                                                        ForeColor="Blue" Text="" CssClass="labelMesag"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="gvVisa" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
                                                        DataKeyNames="Id" EmptyDataText="There are no records to display." GridLines="Both"
                                                        OnRowCommand="gvVisa_RowCommand" OnRowDataBound="gvVisa_RowDataBound">
                                                        <FooterStyle CssClass="GridFooter" />
                                                        <RowStyle CssClass="GridItem" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Document Type" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkId" runat="server" CommandArgument='<%#Bind("Id") %>' CommandName="Modify"
                                                                        Text='<%#Bind("DocumentType") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPassportNo" runat="server" Text='<%#Bind("CardNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Issue Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIssueDate" runat="server" Text='<%#Bind("DateofIssue") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Expire Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExpireDate" runat="server" Text='<%# Bind("DateOfExpiry") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Download" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkDownLoad" runat="server" CommandArgument='<%#Bind("FileName") %>' CommandName="DownLoad"
                                                                        Text="Download" OnClientClick="document.getElementById('form1').target ='_blank';"></asp:LinkButton>
                                                                    <asp:HiddenField ID="hdFNo" runat="server" Value='<%#Bind("FileName") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridHeader" />
                                                        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                        <SelectedRowStyle CssClass="GridRowOver" />
                                                        <EditRowStyle />
                                                        <AlternatingRowStyle CssClass="GridAltItem" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlSkylineVisaMain" runat="server">
                    <div id="Div7" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    SUN VISA</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <!--Start tab form wrap inner all forms wrapper-->
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 22%;">
                                            <colgroup span="1" style="width: 28%;">
                                                <colgroup span="1" style="width: 22%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                    
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblIsVisaRequired" runat="server" CssClass="" Text="SUN VISA Required?"></asp:Label>
                                                                <asp:RadioButton ID="rdbSkylineVisaYes" runat="server" AutoPostBack="True" CssClass=""
                                                                    GroupName="SkylineVisa1" OnCheckedChanged="rdbSkylineVisaYes_CheckedChanged" Text="Yes" />
                                                                <asp:RadioButton ID="rdbSkylineVisaNo" runat="server" AutoPostBack="True" CssClass=""
                                                                    GroupName="SkylineVisa1" OnCheckedChanged="rdbSkylineVisaNo_CheckedChanged" Text="No" />
                                                            </td>
                                                            <asp:Panel ID="pnlother" runat="server">
                                                            <td style="border: thin solid #C0C0C0; top: 2px;" colspan="2">
                                                                         <asp:RadioButton ID="RadioButton1" runat="server" CssClass=""
                                                                      GroupName="SkylineVisa" Text="Visa Letter"  AutoPostBack="True"  OnCheckedChanged="rdbSkylineVisaYes_CheckedChanged" />
                                                                <asp:RadioButton ID="RadioButton2" runat="server" CssClass=""
                                                                     GroupName="SkylineVisa" Text="Embassy Letter"  AutoPostBack="True" OnCheckedChanged="rdbSkylineVisaYes_CheckedChanged" />
                                                                       <asp:RadioButton ID="RadioButton3" runat="server" CssClass=""
                                                                      GroupName="SkylineVisa" Text="NA"  AutoPostBack="True"  OnCheckedChanged="rdbSkylineVisaYes_CheckedChanged" />
                                                                      <br />
                                                                       <asp:LinkButton Font-Bold ="true" ID="Link_Sec_Clearance" runat="server" 
                                                                 Text="Security Clearance"  ForeColor="Blue" Font-Underline="true" AutopostBack="True" OnClick="btn_Load_Security_Clearance" ></asp:LinkButton>
                                                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:Button ID="btnSaveVDType" runat="server" CssClass="" Text="Save" ToolTip="Click Save for VISA letter / Embassy Letter" 
                                                                    onclick="btnSaveVDType_Click"  />
                                                            </td>
                                                            </asp:Panel>
                                                        </tr>
                                                        <asp:Panel ID="pnlSkylineVisaYes" runat="server" Visible="false">
                                                            <tr>
                                                                <td colspan="2">
                                                                    Student Status at the time of seeking enrollment
                                                                </td>
                                                                <td align="left" colspan="3">
                                                                    <asp:RadioButton ID="rdbOutSide" runat="server" CssClass="" GroupName="SkylineVisaDetails1"
                                                                        Text="Out Side Nigeria." Checked="true" AutoPostBack="true" OnCheckedChanged="rdbOutSide_CheckedChanged" />
                                                                    <asp:RadioButton ID="rdbInside" runat="server" CssClass="" GroupName="SkylineVisaDetails1"
                                                                        Text="In Side Nigeria." AutoPostBack="true" OnCheckedChanged="rdbInside_CheckedChanged" />
                                                                </td>
                                                            </tr>
                                                            <asp:Panel ID="PnlInSideVisa" runat="server" Visible="false">
                                                                <tr>
                                                                    <td>
                                                                        Visa Type
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:RadioButton ID="rdbTransit" runat="server" CssClass="" GroupName="SkylineVisaDetails"
                                                                            Text="Transit Visa" />
                                                                        <asp:RadioButton ID="rdbVisit" runat="server" CssClass="" GroupName="SkylineVisaDetails"
                                                                            Text="Visit Visa" />
                                                                        <asp:RadioButton ID="rdbResidence" runat="server" CssClass="" GroupName="SkylineVisaDetails"
                                                                            Text="Residence Visa" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblVisaExpireOn" runat="server" CssClass="" Text="Visa Expire On"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtVisaExpireOnDate" runat="server" CssClass="textBox1" Width="40px"
                                                                            MaxLength="2"></asp:TextBox>
                                                                        <asp:TextBox ID="txtVisaExpireOnMonth" runat="server" CssClass="textBox1" Width="40px"
                                                                            MaxLength="2"></asp:TextBox>
                                                                        <asp:TextBox ID="txtVisaExpireOnYear" runat="server" CssClass="textBox1" Width="50px"
                                                                            MaxLength="4"></asp:TextBox>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender22" runat="server" Enabled="True"
                                                                            TargetControlID="txtVisaExpireOnYear" WatermarkText="YYYY">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender23" runat="server" Enabled="True"
                                                                            TargetControlID="txtVisaExpireOnMonth" WatermarkText="MM">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender24" runat="server" Enabled="True"
                                                                            TargetControlID="txtVisaExpireOnDate" WatermarkText="DD">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDateOfLastEntryDate"
                                                                            CssClass="" ErrorMessage="Visa Expire On Required!" Font-Size="Large" ForeColor="Red"
                                                                            SetFocusOnError="true" Display="None" ValidationGroup="SkySubmit"></asp:RequiredFieldValidator>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtVisaExpireOnMonth">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtVisaExpireOnDate">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtVisaExpireOnYear">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </asp:Panel>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlSkylineVisa" runat="server" Visible="false">
                                                            <tr>
                                                                <td>
                                                                    Urgent Visa Required
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="rdbUrgentVisaYes" runat="server" CssClass="" GroupName="UrgentVisa"
                                                                        Text="Yes" />
                                                                    <asp:RadioButton ID="rdbUrgentVisaNo" runat="server" Checked="true" CssClass="" GroupName="UrgentVisa"
                                                                        Text="No" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Father Name<span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFatherNameForVisa" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtFatherNameForVisa"
                                                                        CssClass="" ErrorMessage="Father Name Required!" Font-Size="Large" ForeColor="Red"
                                                                        SetFocusOnError="true" Display="None" ValidationGroup="SkySubmit"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    Abroad Mobile No<span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAbroadMobileNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAbroadMobileNo"
                                                                        CssClass="" ErrorMessage="*" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                                                        ValidationGroup="SkyVisa"></asp:RequiredFieldValidator>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender46" runat="server" FilterType="Custom,Numbers"
                                                                        TargetControlID="txtAbroadMobileNo">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Abroad Res. No
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAbroadResNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender47" runat="server" FilterType="Custom,Numbers"
                                                                        TargetControlID="txtAbroadResNo">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    Mother Name<span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMotherName" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMotherName"
                                                                        CssClass="" ErrorMessage="*" Font-Size="Large" ForeColor="Red" SetFocusOnError="true"
                                                                        ValidationGroup="SkyVisa"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Place of Birth (City)
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPlaceOfBirthUrgentVisa" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    Country / Region
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlReligionForUrgentVisa" runat="server" CssClass="textBox11"
                                                                        Width="142px">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    State / Province
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPlaceOfBirthPlace" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    Maritial Status
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlMaritialStatus" runat="server" CssClass="textBox11" Width="142px">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Single</asp:ListItem>
                                                                        <asp:ListItem Value="2">Married</asp:ListItem>
                                                                        <asp:ListItem Value="3">Divorce</asp:ListItem>
                                                                        <asp:ListItem Value="4">Widow</asp:ListItem>
                                                                        <asp:ListItem Value="5">Others</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPortOflastentry" runat="server" CssClass="" Text="Port of last Entry"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlPortOflastentry" runat="server" CssClass="textBox11" Width="142px" AutoPostBack="true" OnSelectedIndexChanged="ddlPortOflastentry_changed">
                                                                    
                                                                       
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    Previous Nationality
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlPreviousNationality" runat="server" CssClass="textBox11"
                                                                        Width="142px">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Date of Last Entry
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDateOfLastEntryDate" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtDateOfLastEntryMonth" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtDateOfLastEntryYear" runat="server" CssClass="textBox1" Width="50px"
                                                                        MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server" Enabled="True"
                                                                        TargetControlID="txtDateOfLastEntryYear" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender11" runat="server" Enabled="True"
                                                                        TargetControlID="txtDateOfLastEntryMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" Enabled="True"
                                                                        TargetControlID="txtDateOfLastEntryDate" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtDateOfLastEntryDate"
                                                                        CssClass="" ErrorMessage="Date of Last Entry Required!" Font-Size="Large" ForeColor="Red"
                                                                        SetFocusOnError="true" Display="None" ValidationGroup="SkySubmit"></asp:RequiredFieldValidator>--%>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender37" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtDateOfLastEntryYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender38" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtDateOfLastEntryMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtDateOfLastEntryDate">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    Religion
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtReligion" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Spoken Language
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSpokenLanguage" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    Native Language
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNativeLanguage" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4">
                                                                    <asp:Label ID="Label2" runat="server" CssClass="" Font-Bold="true" Font-Underline="true"
                                                                        Text="Local Guardian Details"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Address1<span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAddress1Local" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtAddress1Local"
                                                                        CssClass="" ErrorMessage="Address1 Required!" Font-Size="Large" ForeColor="Red"
                                                                        SetFocusOnError="true" Display="None" ValidationGroup="SkySubmit"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    Address2
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAddress2Local" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    PO Box
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGuardianPostalAddress" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                                                                        TargetControlID="txtGuardianPostalAddress">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    Office Adddress
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtOfficeAddress" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                          
                                                                <td>
                                                                    City
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCityLocal" runat="server" CssClass="textBox1" ></asp:TextBox>
                                                                </td>
                                                              
                                                                <td>
                                                                    State/Province
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtStateLocal" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                             <asp:Panel ID="pnlcitylocal" runat="server" Visible="false">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblEmirates" runat="server" CssClass="" Text="City"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEmirates" runat="server" CssClass="textBox11" Width="142px">
                                                                       <%-- <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Abu Dhabi</asp:ListItem>
                                                                        <asp:ListItem Value="2">Dubai</asp:ListItem>
                                                                        <asp:ListItem Value="3">Sharjah</asp:ListItem>
                                                                        <asp:ListItem Value="4">Ajman</asp:ListItem>
                                                                        <asp:ListItem Value="5">Ras Al Khaimah</asp:ListItem>
                                                                        <asp:ListItem Value="6">Umm Al Quwain</asp:ListItem>
                                                                        <asp:ListItem Value="7">Al Ain</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                              </asp:Panel>
                                                            <tr>
                                                                <td>
                                                                    Nationality
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlNationalityForLocalGuardian" runat="server" CssClass="textBox11"
                                                                        Width="142px">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblGuardianPassportNo" runat="server" CssClass="" Text="Guardian's PassportNo"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGuardianPassportNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblGuardianPassportValidity" runat="server" CssClass="" Text="Passport Validity"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGuardianPassportValidityDate" runat="server" CssClass="textBox1"
                                                                        Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtGuardianPassportValidityMonth" runat="server" CssClass="textBox1"
                                                                        Width="40px" MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtGuardianPassportValidityYear" runat="server" CssClass="textBox1"
                                                                        Width="50px" MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender28" runat="server" Enabled="True"
                                                                        TargetControlID="txtGuardianPassportValidityMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender29" runat="server" Enabled="True"
                                                                        TargetControlID="txtGuardianPassportValidityDate" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender30" runat="server" Enabled="True"
                                                                        TargetControlID="txtGuardianPassportValidityYear" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtGuardianPassportValidityDate"
                                                                        CssClass="" ErrorMessage="Passport Validity Required!" Font-Size="Large" ForeColor="Red"
                                                                        SetFocusOnError="true" Display="None" ValidationGroup="SkySubmit"></asp:RequiredFieldValidator>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtGuardianPassportValidityMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender44" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtGuardianPassportValidityDate">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender45" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtGuardianPassportValidityYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblGuardianVisaStatus" runat="server" CssClass="" Text="Visa Status"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGuardianVisaStatus" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    National Id No
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNationalIdLocal" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    Upload National Id
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="fuNationalId" runat="server" CssClass="FUpload" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    VISA Page
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtVisaPage" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    Upload VISA Page
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="fuVisaPage" runat="server" CssClass="FUpload" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Tenancy Contract
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtVisa" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    Upload Tenancy Contract
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="fuTenancyContract" runat="server" CssClass="FUpload" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblGuardianVisaNo" runat="server" CssClass="" Text="Visa No"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGuardianVisaNo" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblGuardianNameOfSponsor" runat="server" CssClass="" Text="Name of Sponsor"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGuardianNameOfSponsor" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <asp:CheckBox ID="chkVisaAddGroup" runat="server" Visible="false"  AutoPostBack="True" OnCheckedChanged="chkVisaAddGroup_CheckedChanged" />
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:Button ID="btnAddNewVisa" runat="server" CssClass="" OnClick="btnAddNewVisa_Click"
                                                                    ValidationGroup="SkySubmit" Text="Update" ToolTip="Click to Save SUN VISA"  />
                                                                <asp:Button ID="btnDeleteNewVisa" runat="server" CssClass="" OnClick="btnDeleteNewVisa_Click"
                                                                    Text="Delete" />
                                                                <%--<asp:Button ID="btnPrintVis" runat="server" CssClass="" OnClick="btnPrint_Click"
                                                        Text="Print" ValidationGroup="Back" />--%>
                                                                <asp:ValidationSummary ID="ValidationSummary11" runat="server" ShowSummary="false"
                                                                    ShowMessageBox="True" ValidationGroup="SkySubmit" Font-Size="Large" ForeColor="Red" />
                                                                <asp:Label ID="lblMesagVisa" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="Blue"
                                                                    Text="" CssClass="labelMesag"></asp:Label>
                                                            </td>
                                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlQualification" runat="server">
                    <div id="Experience" runat="server">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Academic and Professional Qualification</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <colgroup span="1" style="width: 32%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                        <colgroup span="1" style="width: 22%;">
                                                            <colgroup span="1" style="width: 28%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblQualification" runat="server" CssClass="" Text="Qualification"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlQualification" runat="server" CssClass="textBox11" 
                                                                            style="width:142px;" AutoPostBack="True" 
                                                                            onselectedindexchanged="ddlQualification_SelectedIndexChanged"></asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlQualification"
                                                                            CssClass="" ErrorMessage="Qualification Required!" Font-Size="Large" ForeColor="Red"
                                                                            SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="QualificationSubmit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        Bachelor Degree<span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlBachelorDegree" runat="server" CssClass="textBox11" 
                                                                            style="width:142px;" AutoPostBack="True" 
                                                                            onselectedindexchanged="ddlBachelorDegree_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            <asp:ListItem Value="BE">BUSINESS EMPHASIS</asp:ListItem>
                                                                            <asp:ListItem Value="NBE">NON BUSINESS EMPHASIS</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblYearofPassing" runat="server" CssClass="" Text="Year of Passing"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlYearOfPassing" runat="server" CssClass="textBox11" 
                                                                            Width="142px" AutoPostBack="True" 
                                                                            onselectedindexchanged="ddlYearOfPassing_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="ddlYearOfPassing"
                                                                            CssClass="" ErrorMessage="Year of Passing!" Font-Size="Large" ForeColor="Red"
                                                                            SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="QualificationSubmit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    
                                                                    <td>
                                                                        <asp:Label ID="Label41" runat="server" CssClass="" Text="CGPA / Percentage"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCGPA" runat="server" CssClass="textBox1" MaxLength="5" 
                                                                            AutoPostBack="True" ontextchanged="txtCGPA_TextChanged"></asp:TextBox>
                                                                            
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender66" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtCGPA">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>                                                                
                                                                    <td>
                                                                        <asp:Label ID="Label18" runat="server" CssClass="" Text="Specilization"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSpecilization" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtSpecilization"
                                                                            CssClass="" ErrorMessage="Specialization Required!" Font-Size="Large" ForeColor="Red"
                                                                            SetFocusOnError="true" Display="None" ValidationGroup="QualificationSubmit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        Criteria
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCourseFOrQualification" runat="server" 
                                                                            CssClass="textBox11" style="width:142px;" AutoPostBack="True" enabled="TRUE"
                                                                            onselectedindexchanged="ddlCourseFOrQualification_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">MQP</asp:ListItem>
                                                                            <asp:ListItem Value="2">PERSONAL INTERVIEW</asp:ListItem>
                                                                            <asp:ListItem Value="3">CHALLENGE EXAM</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <asp:Panel ID="pnlChalangeExam" runat="server" Visible="true">
                                                                <asp:Panel ID="pnlChalange1" runat="server" Visible="false">
                                                                <tr>
                                                                    <td colspan="2">
                                                                       <b> Subjects </b>
                                                                    </td>
                                                                    <td>
                                                                       <b> Date </b>
                                                                    </td>
                                                                    <td>
                                                                       <b> Time </b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="chkMqp11" runat="server" Text="ACC5001-ACCOUNTING PRINCIPLES & PRACTICE" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpDate11" runat="server" CssClass="textBox15" Width="121px" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpTime11" runat="server" CssClass="textBox15" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="chkMqp12" runat="server" Text="ECO5002-ECONOMICS PRINCIPLES & PRACTICE" />
                                                                    </td>
                                                                    <td>
                                                                         <asp:DropDownList ID="ddlMqpDate12" runat="server" CssClass="textBox15" Width="121px" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpTime12" runat="server" CssClass="textBox15" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td colspan="2">                                                                        
                                                                       <asp:CheckBox ID="chkMqp13" runat="server" Text="MAT5003-FUNDAMENTALS OF QUANTITATIVE METHODS" />
                                                                    </td>
                                                                    <td>
                                                                         <asp:DropDownList ID="ddlMqpDate13" runat="server" CssClass="textBox15" Width="121px" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpTime13" runat="server" CssClass="textBox15" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td colspan="2">     
                                                                       <asp:CheckBox ID="chkMqp14" runat="server" Text="FIN5004-PRINCIPLES OF FINANCE" />
                                                                    </td>
                                                                    <td>
                                                                         <asp:DropDownList ID="ddlMqpDate14" runat="server" CssClass="textBox15" Width="121px" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpTime14" runat="server" CssClass="textBox15" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td colspan="2"> 
                                                                       <asp:CheckBox ID="chkMqp15" runat="server" Text="MGM5005-PERSPECTIVE ON MANAGEMENT" />
                                                                    </td>
                                                                    <td>
                                                                         <asp:DropDownList ID="ddlMqpDate15" runat="server" CssClass="textBox15" Width="121px" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpTime15" runat="server" CssClass="textBox15" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td colspan="2"> 
                                                                       <asp:CheckBox ID="chkMqp16" runat="server" Text="MKT5006-PRINCIPLES OF MARKETING" />
                                                                    </td>
                                                                    <td>
                                                                         <asp:DropDownList ID="ddlMqpDate16" runat="server" CssClass="textBox15" Width="121px" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpTime16" runat="server" CssClass="textBox15" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td colspan="2">     
                                                                       <asp:CheckBox ID="chkMqp17" runat="server" Text="MGM5007-OPERATIONS MANAGEMENT" />
                                                                    </td>
                                                                    <td>
                                                                         <asp:DropDownList ID="ddlMqpDate17" runat="server" CssClass="textBox15" Width="121px" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMqpTime17" runat="server" CssClass="textBox15" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnlChalange2" runat="server" Visible="false">
                                                                <tr>
                                                                     <td>
                                                                            <asp:Label ID="Label46" runat="server" CssClass="" Text="Exam Date"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlChalangeExamDate" runat="server" CssClass="textBox15" Width="121px">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                          </td>
                                                                          <td>
                                                                            <asp:Label ID="Label47" runat="server" CssClass="" Text="Exam Time"></asp:Label>
                                                                        </td>
                                                                          <td>  <asp:DropDownList ID="ddlChalangeExamTime" runat="server" CssClass="textBox15">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                </tr>
                                                                </asp:Panel>
                                                                </asp:Panel>
                                                                <tr>
                                                                
                                                                    <td>
                                                                        <asp:Label ID="lblPercentage" runat="server" CssClass="" Text="Grade"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtPercentage" runat="server" CssClass="textBox1" MaxLength="10"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtPercentage"
                                                                            CssClass="" ErrorMessage="Pecentage Required!" Font-Size="Large" ForeColor="Red"
                                                                            SetFocusOnError="true" Display="None" ValidationGroup="QualificationSubmit"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label42" runat="server" CssClass="" Text="No.of Courses Completed"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSubjects" runat="server" CssClass="textBox1" MaxLength="2"></asp:TextBox>
                                                                            </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblUniversityName" runat="server" CssClass="" Text=" School / College / University"></asp:Label><span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtUniversityName" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtUniversityName"
                                                                            CssClass="" ErrorMessage="School / College / University Required!" Font-Size="Large"
                                                                            ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="QualificationSubmit"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                  
                                                                    <td>
                                                                        <asp:Label ID="lblBoardName" runat="server" CssClass="" Text="Board Name"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlBoardName" runat="server" CssClass="textBox11" Width="142px">                                                                           
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtBoardName" runat="server" Visible="false" CssClass="textBox1"></asp:TextBox>                                                                     
                                                                    </td>
                                                                    <td><asp:ImageButton ID="btnShowBoardNamePopup" runat="server" ImageUrl="~/Icons/new.png" CausesValidation="false" /></td>
                                                                </tr>

                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCity" runat="server" CssClass="" Text="City"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCity" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCountry" runat="server" CssClass="" Text="Country"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="textBox11" Width="142px">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                 
                                                                    <td>
                                                                        <asp:Label ID="Label38" runat="server" CssClass="" Text="Is Certificate Submitted"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkCertificateSubmitted" runat="server" CssClass="textBox1" />
                                                                    </td>
                                                                     <td>
                                                                        Upload Document
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="fuQualification" runat="server" CssClass="FUpload" />
                                                                    </td>
                                                                  </tr>
                                                                  <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label43" runat="server" CssClass="" Text="Special Approval / Recommendation Letter"></asp:Label>
                                                                    </td>

                                                                    <td>
                                                                        <asp:CheckBox ID="chkSpecialApproval" runat="server" CssClass="textBox1" 
                                                                            AutoPostBack="True" oncheckedchanged="chkSpecialApproval_CheckedChanged" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label45" runat="server" CssClass="" Text="Rejected"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkRejected" runat="server" CssClass="textBox1" AutoPostBack="True" oncheckedchanged="chkRejected_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                
                                                                                                                                     <td>
                                                                        <asp:Label ID="Label44" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRemarksQualification" runat="server" CssClass="textBox11" TextMode="MultiLine" Width="142px"
                                                                     ></asp:TextBox>
                                                                    </td>
                                                                    <asp:Panel ID="pnlmilitary" runat="server"  Visible="false">
                                                                     <td>
                                                                        <asp:Label ID="Label54" runat="server" CssClass="" Text="Clearance from Military"></asp:Label>
                                                                    </td>

                                                                    <td>
                                                                        <asp:CheckBox ID="Chkmilitary" runat="server" CssClass="textBox1" AutoPostBack="True" oncheckedchanged="Chkmilitary_CheckedChanged" Checked="false" 
                                                                             />
                                                                    </td>
                                                                    </asp:Panel>

                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:Button ID="btnAddQualification" runat="server" CssClass="" Text="Add" OnClick="btnAddQualification_Click"
                                                                            ValidationGroup="QualificationSubmit" />
                                                                        <asp:Button ID="btnUpdateQualification" runat="server" Text="Update" CssClass=""
                                                                            OnClick="btnUpdateQualification_Click" Visible="false" />
                                                                        <asp:ValidationSummary ID="ValidationSummary8" runat="server" ShowSummary="false"
                                                                            ShowMessageBox="True" ValidationGroup="QualificationSubmit" Font-Size="Large"
                                                                            ForeColor="Red" />
                                                                        <asp:Label ID="lblMesagQualification" runat="server" Font-Bold="true" Font-Size="12px"
                                                                            ForeColor="Blue" Text="" CssClass="labelMesag"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="GvQualification" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                                                            EmptyDataText="There are no records to display." OnRowDataBound="GvQualification_RowDataBound"
                                                                            GridLines="Both" CssClass="grid-view" OnRowCommand="GvQualification_RowCommand"
                                                                            Width="30%" >
                                                                            <FooterStyle CssClass="GridFooter" />
                                                                            <RowStyle CssClass="GridItem" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Qualification" Visible="true">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                                                            Text='<%#Bind("Qualification") %>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Specialization">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblYearOfPass" runat="server" Text='<%#Bind("Specilization") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="University Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblUniversityName" runat="server" Text='<%#Bind("UniversityName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="CGPA/Perc">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPercentage" runat="server" Text='<%# Bind("Percentage") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Download" Visible="true">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkDownLoad" runat="server" CommandArgument='<%#Bind("FileName") %>' CommandName="DownLoad"
                                                                                            Text="Download" OnClientClick="document.getElementById('form1').target ='_blank';"></asp:LinkButton>
                                                                                        <asp:HiddenField ID="hdFNo" runat="server" Value='<%#Bind("FileName") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle CssClass="GridHeader" />
                                                                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                                            <SelectedRowStyle CssClass="GridRowOver" />
                                                                            <EditRowStyle />
                                                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </colgroup>
                                                        </colgroup>
                                                    </colgroup>
                                                </colgroup>
                                            </table>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlExperience" runat="server">
                    <div id="Div3" runat="server" style="display: block">
                        <div class="tab-form-wrap">
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Work Experience
                                </h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <!--Start tab form wrap inner all forms wrapper-->
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <colgroup span="1" style="width: 28%;">
                                                    <colgroup span="1" style="width: 28%;">
                                                        <colgroup span="1" style="width: 15%;">
                                                            <colgroup span="1" style="width: 28%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblWorkExperience" runat="server" CssClass="" Text="Work Experience?"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RadioButton ID="rdbWorking" runat="server" Text="Working" Checked="true" CssClass=""
                                                                            GroupName="Working" AutoPostBack="True" OnCheckedChanged="rdbWorking_CheckedChanged" />
                                                                        <asp:RadioButton ID="rdbNotWorking" runat="server" Text="Not Working" CssClass=""
                                                                            GroupName="Working" AutoPostBack="True" OnCheckedChanged="rdbNotWorking_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <asp:Panel ID="pnlExperience1" runat="server" Visible="true">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblOrganizations" runat="server" CssClass="" Text="Organization/Company Name"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtOrganizations" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtOrganizations"
                                                                                CssClass="" ErrorMessage="Organization/Company Name Required!" Font-Size="Large"
                                                                                ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="ExpSubmit"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblDesignation" runat="server" CssClass="" Text="Designation"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtDesignation"
                                                                                CssClass="" ErrorMessage="Designation Required!" Font-Size="Large"
                                                                                ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="ExpSubmit"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label39" runat="server" CssClass="" Text="Location"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtLocationForExperience" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtLocationForExperience"
                                                                                CssClass="" ErrorMessage="Location Required!" Font-Size="Large"
                                                                                ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="ExpSubmit"></asp:RequiredFieldValidator>
                                                                       
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label19" runat="server" CssClass="" Text="City"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCityForExperience" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtCityForExperience"
                                                                                CssClass="" ErrorMessage="City Required!" Font-Size="Large"
                                                                                ForeColor="Red" SetFocusOnError="true" Display="None" ValidationGroup="ExpSubmit"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblJobSector" runat="server" CssClass="" Text="Job Sector"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlJobSector" runat="server" CssClass="textBox11">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlJobSector"
                                                                                CssClass="" ErrorMessage="Job Sector Required!" Font-Size="Large" ForeColor="Red"
                                                                                SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="ExpSubmit"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblTypeofJob" runat="server" CssClass="" Text="Job Type"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlTypeOfJob" runat="server" CssClass="textBox11">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="F">Full Time</asp:ListItem>
                                                                                <asp:ListItem Value="P">Part Time</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddlTypeOfJob"
                                                                                CssClass="" ErrorMessage="Job Type!" Font-Size="Large" ForeColor="Red"
                                                                                SetFocusOnError="true" Display="None" InitialValue="0" ValidationGroup="ExpSubmit"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label20" runat="server" CssClass="" Text="Job Profile"></asp:Label>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="txtJobProfile" runat="server" CssClass="textBox1" Width="440px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblFromMonth" runat="server" CssClass="" Text="From"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlFromMonth" runat="server" CssClass="textBox12">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ID="ddlFromYear" runat="server" CssClass="textBox12">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlFromMonth"
                                                                                CssClass="" ErrorMessage="Experience Date Required!" Font-Size="Large" ForeColor="Red"
                                                                                SetFocusOnError="true" InitialValue="0" Display="None" ValidationGroup="ExpSubmit"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblToMonth" runat="server" CssClass="" Text="To"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlToMonth" runat="server" CssClass="textBox12" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="ddlToMonth_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ID="ddlToYear" runat="server" CssClass="textBox12">
                                                                                <asp:ListItem Value="0">Till</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:Button ID="btnAddExperience" runat="server" CssClass="" Text="Add" OnClick="btnAddExperience_Click"
                                                                                ValidationGroup="ExpSubmit" />
                                                                            <asp:Button ID="btnUpdateExp" runat="server" Text="Update" CssClass="" OnClick="btnUpdateExp_Click"
                                                                                Visible="false" />
                                                                            <%--<asp:Button ID="btnPrintExperience" runat="server" CssClass="" OnClick="btnPrint_Click"
                                                            Text="Print" ValidationGroup="Back" />--%>
                                                                            <asp:ValidationSummary ID="ValidationSummary9" runat="server" ShowSummary="false"
                                                                                ShowMessageBox="True" ValidationGroup="ExpSubmit" Font-Size="Large" ForeColor="Red" />
                                                                            <asp:Label ID="lblMesagExperience" runat="server" Font-Bold="true" Font-Size="12px"
                                                                                Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:GridView ID="GvExperience" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                                                                EmptyDataText="There are no records to display." OnRowDataBound="GvExperience_RowDataBound"
                                                                                GridLines="Both" CssClass="grid-view" OnRowCommand="GvExperience_RowCommand">
                                                                                <FooterStyle CssClass="GridFooter" />
                                                                                <RowStyle CssClass="GridItem" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Organization" Visible="true">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                                                                Text='<%#Bind("Organization") %>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Designation">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("Designation") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Location">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLocation" runat="server" Text='<%#Bind("Location") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="City">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblJobType" runat="server" Text='<%#Bind("City") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <HeaderStyle CssClass="GridHeader" />
                                                                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                                                <SelectedRowStyle CssClass="GridRowOver" />
                                                                                <EditRowStyle />
                                                                                <AlternatingRowStyle CssClass="GridAltItem" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </asp:Panel>
                                                            </colgroup>
                                                        </colgroup>
                                                    </colgroup>
                                                </colgroup>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <!--ended of tab form wrap inner all forms wraper-->
                            </div>
                            <!--ended Div of Tab Form Wrapper inner-->
                        </div>
                        <!--ended of Tab System form Wrapper-->
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlEntrance" runat="server">
                    <div id="Entrance" runat="server">
                        <div class="tab-form-wrap">
                            <!--fot Tab System form Wrapper-->
                            <div class="tab-headline">
                                <!--Start Div for the Tab Headline-->
                                <h1>
                                    Entrance Requirement</h1>
                            </div>
                            <!--ended Div of Tab Headline-->
                            <div class="tab-form-wrap-inner">
                                <!--Start Div of Tab Form Wrapper inner-->
                                <div class="form-fieldset-wrapper-mid-inner1">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <colgroup span="1" style="width: 125px;">
                                            <colgroup span="1" style="width: 175px;">
                                                <colgroup span="1" style="width: 135px;">
                                                    <colgroup span="1" style="width: 225px;">
                                                    <tr>
                                                    <td align="center" colspan="4">
                                                    </td>
                                                    </tr>
                                                    <asp:Panel ID="PnlHideToefl" runat="server" Visible="true">
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Label ID="lblEnglish" runat="server" CssClass="" Text="English" Font-Bold="true"
                                                                    Font-Underline="true"></asp:Label>
                                                                <asp:Label ID="lblResultMessage" runat="server" Text="" ForeColor="Blue" Font-Size="14px" Font-Bold="true"></asp:Label>
                                                              
                                                                 <asp:LinkButton ID="lnlresult" runat="server" ForeColor=" Green" Font-Size="14px" Font-Bold="true" Text="View Results" OnClick ="showresult"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblNativeEnglishSpeaker" runat="server" CssClass="" Text="English Speaker"></asp:Label><span style="color:Red">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rdbNativeEnglishYes" runat="server" CssClass="" Text="Yes" GroupName="NativeEnglish" 
                                                                    AutoPostBack="True" OnCheckedChanged="rdbNativeEnglishYes_CheckedChanged" />
                                                                <asp:RadioButton ID="rdbNativeEnglishNo" runat="server" CssClass="" Text="No" GroupName="NativeEnglish" 
                                                                    OnCheckedChanged="rdbNativeEnglishNo_CheckedChanged" AutoPostBack="True" />
                                                                  
                                                            </td>
                                                           
                                                            <td>
                                                            
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="pnlNativeSpeaker" runat="server" Visible="true">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblHavingToefl" runat="server" CssClass="" Text="TOEFL/IELTS/IBT/PEARSON/CAMBRIDGE/CITY AND GUILDS"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="rdbHavingToeflYes" runat="server" CssClass="" Text="Yes" GroupName="HavingToefl"
                                                                        AutoPostBack="True" OnCheckedChanged="rdbHavingToeflYes_CheckedChanged" Checked="true" />
                                                                    <asp:RadioButton ID="rdbHavingToeflNo" runat="server" CssClass="" Text="No" GroupName="HavingToefl"
                                                                        AutoPostBack="True" OnCheckedChanged="rdbHavingToeflNo_CheckedChanged" />
                                                                </td>
                                                            </tr>
                                                      


                                                            <asp:Panel ID="pnlHavingToeflNo" runat="server" Visible="false">
                                                            <tr>
                                                            
                                                            
                                                            <asp:Panel ID="pnltoeflold" runat="server" Visible="false">

                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rdbTofel" runat="server" CssClass="" Text="TOEFL" GroupName="HavingToeflEXAM"
                                                                            AutoPostBack="True" OnCheckedChanged="rdbTofel_CheckedChanged" Checked="true" Visible="false" />
                                                                        <asp:RadioButton ID="rdbIelts" runat="server" CssClass="" Text="IELTS" GroupName="HavingToeflEXAM"
                                                                            AutoPostBack="True" OnCheckedChanged="rdbIelts_CheckedChanged" Visible="false" />
                                                                    </td>
                                                                </tr>
                                                                </asp:Panel>

                                                                <tr>



                                                                <td> Test Type</td>
                                                                
                                                              
                                                                    <td>
                                                                        
                     <asp:DropDownList ID="drpentrancetesttype" runat="server" CssClass="textBox14" OnSelectedIndexChanged="drpentrancetesttype_SelectedIndexChanged"
                                                                        AutoPostBack="true">
                                                                                                                                           
                                                                    </asp:DropDownList>

                                                                    </td>

                                                                </tr>


                                                                <tr>
                                                                    <asp:Panel ID="pnlToeflExamDate" runat="server">
                                                                        <td>
                                                                            <asp:Label ID="lblExamDateToefl" runat="server" CssClass="" Text="Exam"></asp:Label><span style="color:Red">*</span>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:DropDownList ID="ddlExamDateToefl" runat="server" CssClass="textBox15" Width="80px" onselectedindexchanged="ddlExamDateToefl_SelectedIndexChanged" AutoPostBack="true">
                                                                                <asp:ListItem Value="0">Date</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ID="ddlExamTimeToefl" runat="server" CssClass="textBox15" Width="80px">
                                                                                <asp:ListItem Value="0">Time</asp:ListItem>
                                                                            </asp:DropDownList>Orientation 
                                                                            <asp:DropDownList ID="ddlExamDateToeflOrt" runat="server" CssClass="textBox15" Width="80px">
                                                                                <asp:ListItem Value="0">Date</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ID="ddlExamTimeToeflOrt" runat="server" CssClass="textBox15" Width="80px">
                                                                                <asp:ListItem Value="0">Time</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                </tr>
                                                            </asp:Panel>
                                                                                                                      
                                                                <tr>
                                                                    <td>
                                                                        Books<span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkBooks" runat="server"  />
                                                                    </td>
                                                                </tr>
                                                            <asp:Panel ID="Panel4" runat="server" Visible="false">
                                                            <tr>
                                                                
                                                                <td>
                                                                Add Fee Group
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkToeflAddGroup" runat="server"  onclick="shopPopup();" />
                                                            </td>
                                                            </tr>
                                                            </asp:Panel>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlHavingToeflYes" runat="server" Visible="true">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <b>
                                                                        <asp:Label ID="Label40" runat="server" CssClass="" Text="Please Enter IELTS/TOEFL Score"></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                               <td>
                                                                    <asp:Label ID="lblTestType" runat="server" CssClass="" Text="Test Type"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTestType" runat="server" CssClass="textBox14" OnSelectedIndexChanged="ddlToefl_SelectedIndexChanged"
                                                                        AutoPostBack="true">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">TOEFL</asp:ListItem>
                                                                        <asp:ListItem Value="2">IELTS</asp:ListItem>
                                                                        <asp:ListItem Value="3">IBT</asp:ListItem>
                                                                        <asp:ListItem Value="4">Cambridge</asp:ListItem>
                                                                        <asp:ListItem Value="5">Pearson</asp:ListItem>
                                                                            <asp:ListItem Value="6">City & Guilds</asp:ListItem>
                                                                             <asp:ListItem Value="7">EMSAT</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>                                                                
                                                                    <td>
                                                                        Entry Type<span style="color:Red">*</span>
                                                                    </td>
                                                                    <td>
                                                                       <asp:DropDownList ID="ddlEntryType" runat="server" CssClass="textBox11" Width="142px">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    </tr>
                                                                  
                                              
                                                 <tr>
                                                                <td colspan="4">
                                                                   
                                                                         <asp:Label ID="Label55" runat="server" CssClass="" Text="EXAM APPEARING OUTSIDE SUN  "></asp:Label>
                                                                        
                                                                         <asp:RadioButtonList ID="rdosucoutside" Width="40%"  CssClass="" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdosucoutside_OnSelectedIndexChanged">
                                                                            <asp:ListItem  Value="1" Text="YES" />
                                                                             <asp:ListItem  Value="0" Text="NO"  Selected="false"/>
                                                                            </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                  


                                                    <asp:Panel ID="pnlemsat" runat="server">
                                                                    <tr>
                                                                   <td colspan="4">
                                                                     <asp:Label ID="Label59" runat="server" CssClass="" Text="Select EMSAT Score"></asp:Label>
                                                                    
                                                                                                                                     
                                                                      
                                 <cc3:ComboBox runat="server" ID="drpemsat" Width="200" MenuWidth="600" Height="150"  AutoPostBack="true"  OnSelectedIndexChanged="drpemsat_SelectedIndexChanged"   EmptyText="Select a EMSAT range ..."
	    
	    >
                                  
                                       
         <HeaderTemplate>
	           <div class="header c2">Id</div>
             <div class="header c3">Academic Track</div>
	        <div class="header c4">Range</div>
	    </HeaderTemplate>
	    <ItemTemplate>
                   <div>
	             <div class="item c2"><%# Eval("id")%></div>
	            <div class="item c3"><%# Eval("academic_track")%></div>
                <div class="item c4"><%# Eval("range")%></div>
            </div>
	    </ItemTemplate>
	    <FooterTemplate>
	        Displaying <%# Container.ItemsCount %> items.
	    </FooterTemplate>
	</cc3:ComboBox>
                                                                      
                                                                       </td>
                                                                    </tr>
                                                  </asp:Panel>


                                                                 <tr>
                                                                <td colspan="4">
                                                                 <span style ="font-family:Tahoma; color: Green;">  Please Enter  B1 = 1 , B2 = 2  in Marks field for City & Guilds TestType</span>
                                                                 </td>
                                                                 
                                                                 </tr>                                               
                                                     

                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblEnglishMark" runat="server" CssClass="" Text="English Marks"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtEnglishMark" runat="server" CssClass="textBox1" AutoPostBack="true"
                                                                        OnTextChanged="txtEnglish_TextChanged" MaxLength="5"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender49" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtEnglishMark">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblExamPassedOn" runat="server" CssClass="" Text="Exam Passed On"></asp:Label><span style="color:Red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtExamPassedOnDate" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtExamPassedOnMonth" runat="server" CssClass="textBox1" Width="40px"
                                                                        MaxLength="2"></asp:TextBox>
                                                                    <asp:TextBox ID="txtExamPassedOnYear" runat="server" CssClass="textBox1" Width="50px"
                                                                        MaxLength="4"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender12" runat="server" Enabled="True"
                                                                        TargetControlID="txtExamPassedOnYear" WatermarkText="YYYY">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender13" runat="server" Enabled="True"
                                                                        TargetControlID="txtExamPassedOnMonth" WatermarkText="MM">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" runat="server" Enabled="True"
                                                                        TargetControlID="txtExamPassedOnDate" WatermarkText="DD">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender54" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtExamPassedOnYear">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender55" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtExamPassedOnMonth">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender56" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtExamPassedOnDate">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                         

                                                         <tr>
                                                       
                                                        <td colspan="4">
                                                             <asp:CheckBox ID="chkstatus" text= "Completed During Bachelors" CssClass="" runat="server" />
                                                         
                                                         </td>
                                                         
                                                         </tr>
                                                         <tr>                                                                                                      
                                                                <td>
                                                                    <asp:Label ID="lblStatusOfExam" runat="server" CssClass="" Text="Status of Exam"></asp:Label>
                                                                </td>
                                                              
                                                                <td colspan="3">
                                                               
                                                                    <asp:TextBox ID="txtStatusOfExam" runat="server" CssClass="textBox1" Enabled="false"
                                                                        ReadOnly="true" Width="262px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblListening" runat="server" CssClass="" Text="Listening"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtListening" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender50" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtListening">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblReading" runat="server" CssClass="" Text="Reading"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtReading" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender51" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtReading">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblWriting" runat="server" CssClass="" Text="Writing"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtWriting" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender52" runat="server" FilterType="Custom,Numbers"
                                                                        ValidChars="." TargetControlID="txtWriting">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                                <asp:Panel ID="pnlSpeaking" runat="server">
                                                                    <td>
                                                                        <asp:Label ID="lblSpeaking" runat="server" CssClass="" Text="Speaking"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSpeaking" runat="server" CssClass="textBox1"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender53" runat="server" FilterType="Custom,Numbers"
                                                                            ValidChars="." TargetControlID="txtSpeaking">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </asp:Panel>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblResultSubmitted" runat="server" CssClass="" Text="Result Submitted"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="rdbResultSubmit" runat="server" CssClass="" Text="Yes" GroupName="ResultSubmit" />
                                                                    <asp:RadioButton ID="rdbResultSubmitNo" runat="server" CssClass="" Text="No" GroupName="ResultSubmit" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblSubmitResult" runat="server" CssClass="" Text="Result"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="fuResult" runat="server" CssClass="FUpload1" />
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                </asp:Panel>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnSubmitToefl" runat="server" CssClass="" Text="Add" OnClick="btnSubmitTOEFL_Click" />
                        
                        <asp:Button ID="btnUpdateToefl" runat="server" CssClass="" Text="Update" OnClick="btnUpdateToefl_Click" Visible="false" />
                        <asp:Button ID="btnDeleteToefl" runat="server" CssClass="" Text="Delete" OnClick="btnDeleteToefl_Click" Visible="false" />
                        <%--<asp:Button ID="btnPrintToefl" runat="server" CssClass="" OnClick="btnPrint_Click"
                Text="Print" ValidationGroup="Back" />--%>
                        <asp:Label ID="lblMesagToefl" runat="server" Font-Bold="true" Font-Size="12px" Text=""
                            ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                       <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>--%>
                                <asp:GridView ID="GvToefl" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                    EmptyDataText="There are no records to display." OnRowDataBound="GvToefl_RowDataBound"
                                    GridLines="Both" CssClass="grid-view" OnRowCommand="GvToefl_RowCommand" OnRowDeleting="GvToefl_RowDeleting">
                                    <FooterStyle CssClass="GridFooter" />
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.N." Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSN" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                            <asp:Label ID="lblOrganization1" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TOEFL YES/NO">
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                    Text='<%#Bind("ExamType") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TOEFL/IELTS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization" runat="server" Text='<%#Bind("TestType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("ExamDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Time">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobType" runat="server" Text='<%#Bind("ExamTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Passed On">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobSector1" runat="server" Text='<%# Bind("ExamPassedOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status Of Exam">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobSector2" runat="server" Text='<%# Bind("StatusOfExam") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lnkId1" runat="server" CommandName="Delete" CommandArgument='<%#Bind("Id") %>'
                                                    Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                    <SelectedRowStyle CssClass="GridRowOver" />
                                    <EditRowStyle />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                </asp:GridView>
                           <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                </asp:Panel>
                <asp:Panel ID="pnlHideEntrance" runat="server" Visible="true">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lblMath" runat="server" CssClass="" Text="Mathematics" Font-Bold="true"
                            Font-Underline="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHavingSATScore" runat="server" CssClass="" Text="Having SAT Score"></asp:Label><span style="color:Red">*</span>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdbSatScoreYes" runat="server" CssClass="" Text="Yes" GroupName="SatScore"
                            AutoPostBack="True" Checked="true" OnCheckedChanged="rdbSatScoreYes_CheckedChanged" />
                        <asp:RadioButton ID="rdbSatScoreNo" runat="server" CssClass="" Text="No" GroupName="SatScore"
                            AutoPostBack="True" OnCheckedChanged="rdbSatScoreNo_CheckedChanged" />
                        <asp:RadioButton ID="rdbDiploma" runat="server" CssClass="" Text="Diploma" GroupName="SatScore"
                            AutoPostBack="True" OnCheckedChanged="rdbDiploma_CheckedChanged" />
                    </td>
                </tr>
                <asp:Panel ID="pnlDiploma" runat="server" Visible="false">
                    <tr>
                        <td>
                            <asp:Label ID="Label33" runat="server" CssClass="" Text="Remarks"></asp:Label><span style="color:Red">*</span>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDiplomaRemarks" runat="server" CssClass="textBox11" Width="450px"
                                TextMode="MultiLine" Height="40px"></asp:TextBox>
                        </td>
                    </tr>
                </asp:Panel>
                <asp:Panel ID="pnlhavingSatNo" runat="server" Visible="false">
                    <tr>
                        <td>
                            <asp:Label ID="lblMathEntranceExam" runat="server" CssClass="" Text="Math Exam Date"></asp:Label><span style="color:Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMathEntranceExam" runat="server" CssClass="textBox15" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="ddlMathEntranceExam_changed">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList></td>
                          <td>  <asp:DropDownList ID="ddlMathEntranceExamTime" runat="server" CssClass="textBox15" Width="90%">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Panel ID="Panel5" runat="server" Visible="false">
                <tr>
                    <td>
                        Add Fee Group
                    </td>
                    <td>
                        <asp:CheckBox ID="chkMathMarkAddGroup" runat="server"  onclick="shopPopup();" />
                    </td>
                </tr>
                </asp:Panel>
                </asp:Panel>
                <asp:Panel ID="pnlHavingSatYes" runat="server" Visible="false">
                    <tr>
                        <td>
                            <asp:Label ID="lblMathMark" runat="server" CssClass="" Text="Math Mark"></asp:Label><span style="color:Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMath" runat="server" CssClass="textBox1" AutoPostBack="true"
                                OnTextChanged="txtMath_TextChanged" MaxLength="5"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender48" runat="server" FilterType="Custom,Numbers"
                                ValidChars="." TargetControlID="txtMath">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="lblMathPassedOn" runat="server" CssClass="" Text="Exam Passed On"></asp:Label><span style="color:Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMathPassedOnDate" runat="server" CssClass="textBox1" Width="40px"
                                MaxLength="2"></asp:TextBox>
                            <asp:TextBox ID="txtMathPassedOnMonth" runat="server" CssClass="textBox1" Width="50px"
                                MaxLength="2"></asp:TextBox>
                            <asp:TextBox ID="txtMathPassedOnYear" runat="server" CssClass="textBox1" Width="40px"
                                MaxLength="4"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender31" runat="server" Enabled="True"
                                TargetControlID="txtMathPassedOnYear" WatermarkText="YYYY">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender32" runat="server" Enabled="True"
                                TargetControlID="txtMathPassedOnMonth" WatermarkText="MM">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender33" runat="server" Enabled="True"
                                TargetControlID="txtMathPassedOnDate" WatermarkText="DD">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender57" runat="server" FilterType="Custom,Numbers"
                                ValidChars="." TargetControlID="txtMathPassedOnMonth">
                            </cc1:FilteredTextBoxExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender58" runat="server" FilterType="Custom,Numbers"
                                ValidChars="." TargetControlID="txtMathPassedOnDate">
                            </cc1:FilteredTextBoxExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender59" runat="server" FilterType="Custom,Numbers"
                                ValidChars="." TargetControlID="txtMathPassedOnYear">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMathStatus" runat="server" CssClass="" Text="Status of Exam"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtMathStatus" runat="server" CssClass="textBox1" ReadOnly="true"
                                Enabled="false" Width="462"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMathResultSubmited" runat="server" CssClass="" Text="Result Submitted"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="rdbMathResultYes" runat="server" CssClass="" Text="Yes" GroupName="ResultSubmitNo" />
                            <asp:RadioButton ID="rdbMathResultNo" runat="server" CssClass="" Text="No" GroupName="ResultSubmitNo" />
                        </td>
                        <td>
                            <asp:Label ID="Result" runat="server" CssClass="" Text="Result"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fuResult1" runat="server" CssClass="FUpload1" />
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnSubmitMath" runat="server" CssClass="" Text="Add" OnClick="btnSubmitMath_Click" />
                        <asp:Button ID="btnUpdateMath" runat="server" CssClass="" Text="Update" OnClick="btnUpdateMath_Click" Visible="false" />
                        <%--<asp:Button ID="btnPrintEntrance" runat="server" CssClass="" OnClick="btnPrint_Click"
                Text="Print" ValidationGroup="Back" />--%>
                        <asp:Label ID="lblMesagMath" runat="server" Font-Bold="true" Font-Size="12px" Text=""
                            ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                       <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                <asp:GridView ID="gvMath" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                    EmptyDataText="There are no records to display." OnRowDataBound="gvMath_RowDataBound"
                                    GridLines="Both" CssClass="grid-view" OnRowCommand="gvMath_RowCommand">
                                    <FooterStyle CssClass="GridFooter" />
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.N." Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSN" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>                                                
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Having SAT Score">
                                            <ItemTemplate>                                            
                                                <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                    Text='<%#Bind("ExamType") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization2" runat="server" Text='<%#Bind("ExamDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Time">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobType3" runat="server" Text='<%#Bind("ExamTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Math Mark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization" runat="server" Text='<%#Bind("MathMark") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status of Exam">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobType" runat="server" Text='<%#Bind("StatusOfExamMath") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Passed On">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobSector" runat="server" Text='<%# Bind("ExamPassedOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lnkId1" runat="server" CommandName="Delete001" CommandArgument='<%#Bind("Id") %>'
                                                    Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                    <SelectedRowStyle CssClass="GridRowOver" />
                                    <EditRowStyle />
                                    <AlternatingRowStyle CssClass="GridAltItem" />
                                </asp:GridView>
                           <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                </asp:Panel>
                </colgroup> </colgroup> </colgroup> </colgroup> </table>
            </div>
            <!--ended of tab form wrap inner all forms wraper-->
        </div>
        <!--ended Div of Tab Form Wrapper inner-->
        </div>
        <!--ended of Tab System form Wrapper-->
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlRemarks" runat="server">
        <div id="Remarks" runat="server">
            <div class="tab-form-wrap">
                <!--fot Tab System form Wrapper-->
                <div class="tab-headline">
                    <!--Start Div for the Tab Headline-->
                    <h1>
                        Remarks</h1>
                </div>
                <!--ended Div of Tab Headline-->
                <div class="tab-form-wrap-inner">
                    <!--Start Div of Tab Form Wrapper inner-->
                    <div class="form-fieldset-wrapper-mid-inner1">
                        <asp:UpdatePanel ID="updRemarks" runat="server">
                            <ContentTemplate>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <colgroup span="1" style="width: 22%;">
                                        <colgroup span="1" style="width: 32%;">
                                            <colgroup span="1" style="width: 22%;">
                                                <colgroup span="1" style="width: 28%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRemarksType" runat="server" CssClass="" Text="Remarks Type"></asp:Label><span style="color:Red">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRemarksType" runat="server" CssClass="textBox17">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Marketing & Registration</asp:ListItem>
                                                                <asp:ListItem Value="2">Dean</asp:ListItem>
                                                                <asp:ListItem Value="3">Verification & Approval</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlRemarksType"
                                                                CssClass="" ErrorMessage="Remarks Type Required!" Font-Size="Large" ForeColor="Red"
                                                                SetFocusOnError="true" Display="None" ValidationGroup="RemSubmit" InitialValue="0"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDetailsRemarks" runat="server" CssClass="" Text="Remarks"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDetailsRemarks" runat="server" CssClass="textBoxbig" TextMode="MultiLine" ></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:Button ID="btnAddRemarks" runat="server" Text="Add" CssClass="" OnClick="btnAddRemarks_Click"
                                                                ValidationGroup="RemSubmit" />
                                                            <asp:Button ID="btnUpdateRemarks" runat="server" Text="Update" CssClass="" OnClick="btnUpdateRemarks_Click"
                                                                Visible="false" />
                                                            <%--<asp:Button ID="btnPrintRemarks" runat="server" CssClass="" OnClick="btnPrint_Click"
                                                        Text="Print" ValidationGroup="Back" />--%>
                                                            <asp:ValidationSummary ID="ValidationSummary12" runat="server" ShowSummary="false"
                                                                ShowMessageBox="True" ValidationGroup="RemSubmit" Font-Size="Large" ForeColor="Red" />
                                                            <asp:Label ID="lblMesagRemarks" runat="server" Font-Bold="true" Font-Size="12px"
                                                                Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:GridView ID="GvRemarks" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                                                EmptyDataText="There are no records to display." OnRowDataBound="GvRemarks_RowDataBound"
                                                                GridLines="Both" CssClass="grid-view" OnRowCommand="GvRemarks_RowCommand" Width="280px">
                                                                <FooterStyle CssClass="GridFooter" />
                                                                <RowStyle CssClass="GridItem" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Id" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblRemarkType" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                                                Text='<%#Bind("RemarksType") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remark">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRemark" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="GridHeader" />
                                                                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                                <SelectedRowStyle CssClass="GridRowOver" />
                                                                <EditRowStyle />
                                                                <AlternatingRowStyle CssClass="GridAltItem" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </colgroup>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <!--ended of tab form wrap inner all forms wraper-->
                </div>
                <!--ended Div of Tab Form Wrapper inner-->
            </div>
            <!--ended of Tab System form Wrapper-->
        </div>
    </asp:Panel>
    <asp:Panel ID="PnlUndertaking" runat="server">
        <div id="Div8" runat="server">
            <div class="tab-form-wrap">
                <!--fot Tab System form Wrapper-->
                <div class="tab-headline">
                    <!--Start Div for the Tab Headline-->
                    <h1>
                        Non Submission of below documents as Undertaking</h1>
                </div>
                <!--ended Div of Tab Headline-->
                <div class="tab-form-wrap-inner">
                    <!--Start Div of Tab Form Wrapper inner-->
                    <div class="form-fieldset-wrapper-mid-inner1">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <colgroup span="1" style="width: 22%;">
                                <colgroup span="1" style="width: 32%;">
                                    <colgroup span="1" style="width: 22%;">
                                        <colgroup span="1" style="width: 28%;">
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:ListBox ID="lblAllUndertaking" runat="server" SelectionMode="Multiple" CssClass="textBox11"
                                                        Height="280px" Width="375px"></asp:ListBox>
                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="btnAdd" runat="server" Text="Add >>" OnClick="btnAdd_Click" Width="100px" />
                                                    <br />
                                                    <asp:Button ID="btnRemove" runat="server" Text="<< Remove" OnClick="btnRemove_Click"
                                                        Width="100px" />
                                                    <br />
                                                    <asp:Button ID="btnViewUnderTaking" runat="server" CssClass="textBox1" Text="View" OnClick="btnViewUnderTaking_Click"
                                    OnClientClick="document.getElementById('form1').target ='_blank';" Width="100px"/>
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lblUndertaking" runat="server" CssClass="textBox11" Height="280px"
                                                        Width="375px" SelectionMode="Multiple"></asp:ListBox>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td colspan="3" align="center">
                                                    <asp:Button ID="btnUnderTaking" runat="server" Text="Submit" CssClass="" OnClick="bbtnUnderTaking_Click" />
                                                    <asp:Label ID="lblMesagUnderTaking" runat="server" Font-Bold="true" Font-Size="12px"
                                                        Text="" ForeColor="Blue" CssClass="labelMesag"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <b>TRACKING OF UNDERTAKING DETAILS SUBMITTED BY STUDENT</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="gvUndertakin" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                                        EmptyDataText="There are no records to display." OnRowDataBound="gvUndertakin_RowDataBound"
                                                        GridLines="Both" CssClass="grid-view" OnRowCommand="gvUndertakin_RowCommand"
                                                        Width="280px">
                                                        <FooterStyle CssClass="GridFooter" />
                                                        <RowStyle CssClass="GridItem" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.N." Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSN" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Undertaking">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUname" runat="server" Text='<%#Bind("Uname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Submitted Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubmitedDate" runat="server" Text='<%#Bind("SubmitedDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Uplodedby">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblupload" runat="server" Text='<%#Bind("ReceivedBy") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Filename">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfile" runat="server" Text='<%#Bind("file1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField HeaderText="Received By">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReceivedBy" runat="server" Text='<%#Bind("ReceivedBy") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Browse">
                                                                <ItemTemplate>
                                                                    <asp:FileUpload ID="fuUnderTaking" runat="server" CssClass="FUpload" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Upload" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Uname") %>'
                                                                        Text="Upload"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>




                                                        </Columns>
                                                        <HeaderStyle CssClass="GridHeader" />
                                                        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                                        <SelectedRowStyle CssClass="GridRowOver" />
                                                        <EditRowStyle />
                                                        <AlternatingRowStyle CssClass="GridAltItem" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </colgroup>
                                    </colgroup>
                                </colgroup>
                            </colgroup>
                        </table>
                    </div>
                    <!--ended of tab form wrap inner all forms wraper-->
                </div>
                <!--ended Div of Tab Form Wrapper inner-->
            </div>
            <!--ended of Tab System form Wrapper-->
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlPrint" runat="server">
        <div id="Print" runat="server">
            <div class="tab-form-wrap">
                <!--fot Tab System form Wrapper-->
                <div class="tab-headline">
                    <!--Start Div for the Tab Headline-->
                    <h1>
                        Print</h1>
                </div>
                <!--ended Div of Tab Headline-->
                <div class="tab-form-wrap-inner">
                    <!--Start Div of Tab Form Wrapper inner-->
                    <div class="form-fieldset-wrapper-mid-inner1">
                        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>--%>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <colgroup span="1" style="width: 22%;">
                                        <colgroup span="1" style="width: 32%;">
                                            <colgroup span="1" style="width: 22%;">
                                                <colgroup span="1" style="width: 28%;">
                                                <tr>
                                                <td>File Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtFileNumber" runat="server" Text="" CssClass=""></asp:TextBox>
                                                </td>
                                                <td colspan="3">
                                                 <asp:Button ID="btnAddFileNumber" runat="server" CssClass="" OnClick="btnAddFileNumber_Click"
                                                Text="Add" Visible="true" />


                                            <asp:Button ID="btnFinalize" runat="server" CssClass="" OnClick="btnFinalize_Click"
                                                Text="Finalize" Visible="true" /></td>
                                                </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblMesag" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                       <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblairstatus" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
<tr>
<td colspan="4">
                                    
            <asp:Panel ID="pnlPrintGrid" runat="server" Visible="true">
               
                                    <asp:GridView ID="gvReportList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                        EmptyDataText="There are no records to display." OnRowDataBound="gvReportList_RowDataBound"
                                        GridLines="Both" CssClass="grid-view" OnRowCommand="gvReportList_RowCommand"
                                        OnSelectedIndexChanged="gvReportList_SelectedIndexChanged">
                                        <FooterStyle CssClass="GridFooter" />
                                        <RowStyle CssClass="GridItem" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Print Forms | Fees Structure | Refund Policy | Undertaking | Etc.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUName" runat="server" Text='<%#Bind("UName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Print">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnk1" runat="server" Text="Preview/Print" Target="_blank" NavigateUrl='<%#"~/Pages/PrintClient.aspx?UName="+ Eval("FileName") %>'  onclick="changeColor(this);" ForeColor="Blue"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Print" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkId" runat="server" CommandName="Print" CommandArgument='<%#Bind("FileName") %>'
                                                        Text="Print"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                        <SelectedRowStyle CssClass="GridRowOver" />
                                        <EditRowStyle />
                                        <AlternatingRowStyle CssClass="GridAltItem" />
                                    </asp:GridView>
                              
            </asp:Panel>
            
            <asp:Panel ID="pnlaa" runat="server" Visible="false">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </asp:Panel>
            </td>
            </tr>

                                                </colgroup>
                                            </colgroup>
                                        </colgroup>
                                    </colgroup>
                                </table>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                    <!--ended of tab form wrap inner all forms wraper-->
                </div>
                <!--ended Div of Tab Form Wrapper inner-->
            </div>
            <!--ended of Tab System form Wrapper-->
        </div>
    </asp:Panel>


    </div>
    <!--ended Div of Wrapping Form Fields Set-->
    </div> </asp:Panel> </div>






    
    <asp:Panel ID="pnlSearch" runat="server" Visible="true">
       
            <!--Div Started to Wrapping all Forms Fields-->
            <div class="form-fieldset-wrapper">
                <div class="form_left">
                    <!--this is form left part-->
                    <div class="form_round_border">
                        <!--This is rounded Div-->
                        <div class="form_round_heading_row">
                            <!--this is heading row-->
                            <h2 class="slide_top">
                                Add Fee Group</h2>
                        </div>
                        <!--ended heading row-->
                        <div class="round_form_content">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="4">
                                    
                                        <asp:GridView ID="gvAddGroup" runat="server" AutoGenerateColumns="false" DataKeyNames="Fees_Items_Id"
                                            EmptyDataText="There are no records to display."
                                            GridLines="Both" CssClass="grid-view" OnRowCommand="gvAddGroup_RowCommand" Width="100%">
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Fee Group" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFeeGroup" runat="server" Text='<%#Bind("Fees_Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Add Fee Group">
                                                    <ItemTemplate>
                                                      <a>  <asp:LinkButton ID="lnkAddFeeGroup" runat="server" CommandName="Modify" OnClientClick="hidePopup();" CommandArgument='<%#Bind("Fees_Items_Id") %>'
                                                            Text="Add Fee Group"></asp:LinkButton></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
                                            <SelectedRowStyle CssClass="GridRowOver" />
                                            <EditRowStyle />
                                            <AlternatingRowStyle CssClass="GridAltItem" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <div class="cleared">
                            </div>
                        </div>
                        <!--ended content Div-->
                    </div>
                    <!--ended rounded Div-->
                    <table width="100%">
                        <tr align="center">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Button ID="btncancel" runat="server" Text="Close" OnClientClick="hidePopup();"
                                    Font-Size="12px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </div>
       
    </asp:Panel>
    <cc1:AnimationExtender ID="aeRoles" runat="server" TargetControlID="pnlSearch">
        <Animations>
        <OnLoad>                               
            <FadeIn Duration="1.5" Fps="100" />
                </OnLoad>                               
        </Animations>
    </cc1:AnimationExtender>
    <asp:HiddenField ID="hdDummy" runat="server" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BehaviorID="ModalPopupExtenderBehavior"
        TargetControlID="hdDummy" PopupControlID="pnlSearch" RepositionMode="RepositionOnWindowResizeAndScroll"
        BackgroundCssClass="modalBackground" X="500" Y="220">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlAddedGroup" runat="server" Visible="false">
    <div style="width:241px; text-align:center; margin-left:144px; background-color:#436C74; border-width:0px; border-style:solid; position:fixed; bottom:0px; left:0; float:right;">
     <asp:GridView ID="gvAddedFeeGroup" runat="server" AutoGenerateColumns="false" DataKeyNames="Fees_Group_Id"
        EmptyDataText="There are no records to display."
        GridLines="Both" CssClass="grid-view" 
        OnRowCommand="gvAddedFeeGroup_RowCommand" Width="241px" ShowFooter="true" 
        onrowdatabound="gvAddedFeeGroup_RowDataBound">
        <FooterStyle CssClass="GridFooter" />
        <RowStyle CssClass="GridAltItem" />
        <Columns>
            <asp:TemplateField HeaderText="Added Fee Group" HeaderStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" Visible="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblFeeGroup" runat="server" Text='<%#Bind("Fees_Group_Code") %>'></asp:Label>
                    <asp:HiddenField ID="hdFeeGroupId" runat="server" Value='<%#Bind("Fees_Group_Id") %>' />
                    <asp:HiddenField ID="hdTypeId" runat="server" Value='<%#Bind("TypeId") %>' />
                       <asp:HiddenField ID="hddetailid" runat="server" Value='<%#Bind("detailsid") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterUName" runat="server" Text="Total"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>                                   
            <asp:TemplateField HeaderText="Amt" HeaderStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" Visible="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Amount") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterUNamea" runat="server" Text="40"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridHeader" />
        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
        <SelectedRowStyle CssClass="GridRowOver" />
        <EditRowStyle />
        <AlternatingRowStyle CssClass="GridAltItem" />
            <FooterStyle CssClass="GridAltItem" />
    </asp:GridView>
    <br />
    <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClick="btnProceed_Click" OnClientClick="document.getElementById('form1').target ='_blank';"/>
    </div>
    </asp:Panel>


        <asp:Button ID="btnShowPopup" runat="server" style="display:none" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="Button1"

BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="269px" Width="200px" style="left: 20% !important; top: 20% !important; display: none;" >
<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:Gray">
<td colspan="1" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Entrance Exam Results </td>
<td>
<asp:ImageButton ID="Button1" runat="server"  AlternateText="Close"  ImageUrl="~/Icons/download.jpg" Width="30" Height="30"/>
</td>
</tr>
<tr style="background-color: white; color: black; font-size: small; font-weight: bold">
<td align="center" style="width:45%">
<asp:GridView ID="grdentrance" runat="server" 

AutoGenerateColumns="false"                 EmptyDataText="There are no records to display."
                                            GridLines="Both" CssClass="grid-view" OnRowCommand="gvAddGroup_RowCommand" Width="100%">
                                            <FooterStyle CssClass="GridFooter" />
                                            <RowStyle CssClass="GridItem" />

  <Columns>
                                                                                                                                                                     
                                                                                    <asp:TemplateField HeaderText="TestType" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbltype" runat="server" Text='<%#Bind("TestType") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>


                                                                                       <asp:TemplateField HeaderText="Sec1 (Listening)" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls1" runat="server" Text='<%#Bind("Listening") %>'  ></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>


                                                                                       <asp:TemplateField HeaderText="Sec2 (Reading)" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls2" runat="server" Text='<%#Bind("Reading") %>'  ></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>


                                                                                       <asp:TemplateField HeaderText="Sec3 (Writing)" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls3" runat="server" Text='<%#Bind("Reading") %>'  ></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>


                                                                                      <asp:TemplateField HeaderText="Sec4 (Speaking)" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls4" runat="server" Text='<%#Bind("Speaking") %>'  ></asp:Label>                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>


                                                                                       <asp:TemplateField HeaderText="Marks" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls5" runat="server" Text='<%#Bind("Marks") %>'  ></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Status" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls5" runat="server" Text='<%#Bind("status") %>'  ></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                         <asp:TemplateField HeaderText="ADM ExamDate" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls6" runat="server" Text='<%#Bind("EntranceDate") %>'  ></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                         <asp:TemplateField HeaderText="ADM Remarks" Visible="TRUE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbls7" runat="server" Text='<%#Bind("Remarks") %>'  ></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    </Columns>




 <HeaderStyle CssClass="GridHeader" />
        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />
        <SelectedRowStyle CssClass="GridRowOver" />
        <EditRowStyle />
        <AlternatingRowStyle CssClass="GridAltItem" />
            <FooterStyle CssClass="GridAltItem" />
    </asp:GridView>


 </td>
</tr>

</table>
    </asp:Panel>
    
        <asp:Button ID="Btnstusearch" runat="server" style="display:none" />
        <cc1:ModalPopupExtender ID="Me4" runat="server" TargetControlID="Btnstusearch" PopupControlID="Pnlstudent" CancelControlID="Imgstud"

BackgroundCssClass="modalBackground" Drag="true">
</cc1:ModalPopupExtender>

<asp:Panel ID="Pnlstudent" runat="server" BackColor="#D3D3D3" Height="500px" Width="800px" ScrollBars="Auto" style="left: 20% !important; top: 20% !important; display: none;"  >
<%--<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:Gray">--%>
<table width="100%">
<tr>
<td  colspan="3" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Search Alumni Student </td>
<td  colspan="3" align="right">
<asp:ImageButton ID="Imgstud" runat="server"  AlternateText="Close"  ImageUrl="~/Icons/download.jpg" Width="30" Height="30" />
</td>
</tr>

</table>

 <div class="GridviewDiv">
 <table width="100%">
<tr><td>
        
        
            <b>Search :</b>
            <asp:TextBox ID="txtSearch" runat="server" Width="150" AutoPostBack="true" Font-Names="tahoma"
                OnTextChanged="txtSearch_TextChanged" />&nbsp;&nbsp;
            
            <asp:ImageButton ID="btnSearch" BackColor="ActiveCaption" runat="server" AlternateText="Search"
                Width="50" CssClass="buttonface" Style="top: 5px; position: relative" OnClick="btnSearch_Click" />&nbsp;&nbsp;
          
</td>
</tr>
</table>
<div></div>
<div style="height: 100">
<table>
<tr>
<td>
<asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsDetails" Width="800px" OnRowCommand="gvDetails_RowCommand" OnPageIndexChanging="gvDetails_OnPageIndexChanging"
                            CssClass="Gridview" ForeColor="#003964" PageSize="10">
                            <HeaderStyle BackColor="#003964" />
                            <Columns>
                          
                                <asp:TemplateField HeaderText="Name" ItemStyle-Width="75%">
                                    <ItemTemplate>
                                                               
                                   <asp:Label ID="lblname" Text='<%# HighlightText(Eval("student_name").ToString()) %>'
                                            runat="server" Width="75%" />
                                  
                                    </ItemTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="StudentId" ItemStyle-Width="90%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkstud" runat="server" CommandName="Modify" CommandArgument='<%#Eval("stud_Id") %>'
                                            ForeColor="Blue" Font-Underline="true" Width="90%" Text='<%# HighlightText(Eval("stud_id").ToString()) %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="YOG" ItemStyle-Width="90%">
                                    <ItemTemplate>
                                        <asp:Label ID="lbllastname" Text='<%# HighlightText(Eval("yog").ToString()) %>'
                                            runat="server" Width="90%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Program" ItemStyle-Width="90%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation1" Text='<%#HighlightText(Eval("DegreeCode").ToString()) %>'
                                            runat="server" Width="90%" CssClass="buttonface"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="90%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation2" Text='<%#HighlightText(Eval("Mobileno").ToString()) %>'
                                            runat="server" Width="100%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" ItemStyle-Width="100%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation6" Text='<%#HighlightText(Eval("Emailid").ToString()) %>'
                                            runat="server" Width="100%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </asp:GridView>
                  
                 
            
      
    
    <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ConnectionStrings:CDBConnectionString2 %>"
        SelectCommand="sp_displayrecordsalumni" UpdateCommand="sp_displayrecordsalumni" UpdateCommandType="StoredProcedure"
        SelectCommandType="StoredProcedure" FilterExpression="student_name LIKE '%{0}%'  or yog LIKE '%{0}%' or  Mobileno LIKE '%{0}%' or Degreecode LIKE '%{0}%' or  Emailid LIKE '%{0}%'  ">
        <FilterParameters>
            <asp:ControlParameter Name="student_name" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="Mobileno" ControlID="txtSearch" PropertyName="Text" />
                <asp:ControlParameter Name="yog" ControlID="txtSearch" PropertyName="Text" />
            <asp:ControlParameter Name="DegreeCode" ControlID="txtSearch" PropertyName="Text" />

            <asp:ControlParameter Name="emailid" ControlID="txtSearch" PropertyName="Text" />
           
           
        </FilterParameters>
        <SelectParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="empid" SessionField="EMPID1" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
   </td>
                </tr>
                </table>
                </div>
                </div>
               <%-- </td>
                </tr>
                </table>--%>
 </asp:Panel>
  <cc1:ModalPopupExtender ID="MSharjahHRDPopup" runat="server" TargetControlID="btnShowSharjahHRDPopup" PopupControlID="PnlSharjahHRD"
CancelControlID="imgSharjahHRDClose" BackgroundCssClass="modalBackground" RepositionMode="RepositionOnWindowResizeAndScroll" X="500" Y="150">
</cc1:ModalPopupExtender>

<asp:Panel ID="PnlSharjahHRD" runat="server" BackColor="White" Height="200px" Width="350px" style="left: 20% !important; top: 20% !important; display: none;">
<table width="100%" style="border:Solid 3px Gray;background-color: silver; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:Gray">
<td style="width:50%;color:White; font-weight:bold; font-size:medium;padding-left:2px; text-align:Left;height:5%" align="center">Sharjah HRD</td>
<td style="width:50%;text-align:right;padding-right:2px;">
<asp:ImageButton ID="imgSharjahHRDClose" runat="server"  AlternateText="Close"  ImageUrl="~/Icons/download.jpg" Width="15" Height="15"/>
</td>
</tr>
<tr>
<td colspan="2">
<table cellpadding="0" cellspacing ="0" width="100%">
<tr><td style="text-align:right;padding:5px"><asp:Label CssClass="PopUpLabel" ID="Label58" runat="server" Text="HRD Name :"></asp:Label></td>
<td style="text-align:left;padding:5px"><asp:TextBox ID="txtHRDName" CssClass="PopUptxt" runat="server" Width="180px"> </asp:TextBox></td>
</tr>
<tr><td style="text-align:right;"></td>
<td style="text-align:left;padding:5px"><asp:CheckBox ID="chkHRDNameActive" runat="server" Text="Is Active" CssClass="PopUpLabel" Checked="true"></asp:CheckBox></td></tr>
<tr>
<td></td>
<td style="text-align:left;padding:5px">
<asp:Button ID="BtnSharjahHRD" runat="server" Visible="true" OnClick="BtnSharjahHRD_Click" Text="Add" />
</td>
</tr>
</table>
</td>
</tr>
</table>
 </asp:Panel>
  <cc1:ModalPopupExtender ID="MBoardNamePopup" runat="server" TargetControlID="btnShowBoardNamePopup" PopupControlID="PnlBoardName"
CancelControlID="imgClose" BackgroundCssClass="modalBackground" RepositionMode="RepositionOnWindowResizeAndScroll" X="500" Y="150">
</cc1:ModalPopupExtender>

<asp:Panel ID="PnlBoardName" runat="server" BackColor="White" Height="200px" Width="350px" style="left: 20% !important; top: 20% !important; display: none;">
<table width="100%" style="border:Solid 3px Gray;background-color: silver; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:Gray">
<td style="width:50%;color:White; font-weight:bold; font-size:medium;padding-left:2px; text-align:Left;height:5%" align="center">Board Name</td>
<td style="width:50%;text-align:right;padding-right:2px;">
<asp:ImageButton ID="imgClose" runat="server"  AlternateText="Close"  ImageUrl="~/Icons/download.jpg" Width="15" Height="15"/>
</td>
</tr>
<tr>
<td colspan="2">
<table cellpadding="0" cellspacing ="0" width="100%">
<tr><td style="text-align:right;padding:5px"><asp:Label CssClass="PopUpLabel" ID="Label57" runat="server" Text="Name :"></asp:Label></td>
<td style="text-align:left;padding:5px"><asp:TextBox ID="txtddlBoardName" CssClass="PopUptxt" runat="server" Width="180px"> </asp:TextBox></td>
</tr>
<tr><td style="text-align:right;"></td>
<td style="text-align:left;padding:5px"><asp:CheckBox ID="chkBoardNameIsActive" runat="server" Text="Is Active" CssClass="PopUpLabel" Checked="true"></asp:CheckBox></td></tr>
<tr>
<td></td>
<td style="text-align:left;padding:5px">
<asp:Button ID="btnBoardName" runat="server" Visible="true" OnClick="BtnBoardName_Click" Text="Add" />
</td>
</tr>
</table>
</td>
</tr>
</table>
 </asp:Panel>  
             
</asp:Content>
