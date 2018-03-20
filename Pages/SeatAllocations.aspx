<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SeatAllocations.aspx.cs" Inherits="Pages_SeatAllocations" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="all-form-wrap">
        <div class="user-sum-report" style="padding-left:0px">
            <asp:UpdatePanel ID="upSummary" runat="server">
                <ContentTemplate>
                    <cc1:Accordion ID="MyAccordion" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader"
                        ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40"
                        TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                        <Panes>
                            <cc1:AccordionPane ID="AccordionPane1" runat="server">
                                <Header>
                                    <a href="">BBA</a></Header>
                                <Content>
                                    <asp:GridView ID="gvBba" runat="server" AutoGenerateColumns="false" OnRowCommand="gvBBA_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Course">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                        Text='<%#Bind("Degree_desc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Term" DataField="Term_Name" />
                                            <asp:BoundField HeaderText="Shift" DataField="Shift" />
                                            <asp:BoundField HeaderText="Max Seat" DataField="MaxSeat" />
                                            <asp:BoundField HeaderText="Avail. Seat" DataField="AvailableSeat" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Data not available!!
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </Content>
                            </cc1:AccordionPane>
                            <cc1:AccordionPane ID="AccordionPane2" runat="server">
                                <Header>
                                    <a href="">MBA</a></Header>
                                <Content>
                                    <asp:GridView ID="gvMba" runat="server" AutoGenerateColumns="false" OnRowCommand="gvMBA_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Course">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                        Text='<%#Bind("Degree_desc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Term" DataField="Term_Name" />
                                            <asp:BoundField HeaderText="Shift" DataField="Shift" />
                                            <asp:BoundField HeaderText="Max Seat" DataField="MaxSeat" />
                                            <asp:BoundField HeaderText="Avail Seat" DataField="AvailableSeat" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Data not available!
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </Content>
                            </cc1:AccordionPane>
                            <cc1:AccordionPane ID="AccordionPane3" runat="server">
                                <Header>
                                    <a href="">BBA WEEKEND</a></Header>
                                <Content>
                                    <asp:GridView ID="gvBbaWeakend" runat="server" AutoGenerateColumns="false" OnRowCommand="gvBBAWeekend_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Course">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                        Text='<%#Bind("Degree_desc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Term" DataField="Term_Name" />
                                            <asp:BoundField HeaderText="Shift" DataField="Shift" />
                                            <asp:BoundField HeaderText="Max Seat" DataField="MaxSeat" />
                                            <asp:BoundField HeaderText="Avail Seat" DataField="AvailableSeat" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Data not available!
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </Content>
                            </cc1:AccordionPane>
                            <cc1:AccordionPane ID="AccordionPane4" runat="server">
                                <Header>
                                    <a href="">MBA WEEKEND</a></Header>
                                <Content>
                                    <asp:GridView ID="gvMbaWeakend" runat="server" AutoGenerateColumns="false" OnRowCommand="gvMBAWeakend_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Course">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                        Text='<%#Bind("Degree_desc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Term" DataField="Term_Name" />
                                            <asp:BoundField HeaderText="Shift" DataField="Shift" />
                                            <asp:BoundField HeaderText="Max Seat" DataField="MaxSeat" />
                                            <asp:BoundField HeaderText="Avail Seat" DataField="AvailableSeat" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Data not available!
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </Content>
                            </cc1:AccordionPane>
                            <cc1:AccordionPane ID="AccordionPane5" runat="server">
                                <Header>
                                    <a href="">SHORT COURSE</a></Header>
                                <Content>
                                    <asp:GridView ID="gvShortCourse" runat="server" AutoGenerateColumns="false" OnRowCommand="gvShortCourse_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Course">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkId" runat="server" CommandName="Modify" CommandArgument='<%#Bind("Id") %>'
                                                        Text='<%#Bind("Degree_desc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Term" DataField="Term_Name" />
                                            <asp:BoundField HeaderText="Shift" DataField="Shift" />
                                            <asp:BoundField HeaderText="Max Seat" DataField="MaxSeat" />
                                            <asp:BoundField HeaderText="Avail Seat" DataField="AvailableSeat" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Data not available!
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </Content>
                            </cc1:AccordionPane>
                        </Panes>
                    </cc1:Accordion>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
        </div>
    </div>
    </div>
</asp:Content>
