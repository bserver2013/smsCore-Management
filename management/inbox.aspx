<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="inbox.aspx.cs" Inherits="view_inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div id="inbox">
        <h2 class="listMember">List of Inbox</h2>
        <asp:GridView ID="gvInbox" runat="server" AutoGenerateColumns="False"
            AllowPaging="true"
            PageIndex="5"
            GridLines="None"
            CssClass="gridClass"
            HeaderStyle-CssClass="headClass"
            AlternatingRowStyle-CssClass="rowClass"
            OnRowCommand="gvInbox_OnRowCommand" OnPageIndexChanging="gvInbox_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Sender" HeaderStyle-Width="80" >
                    <ItemTemplate>
                        <asp:LinkButton ID="lbId" runat="server" CausesValidation="false" CommandName="viewAccount" Text='<%# Eval("Sender") %>' CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Message" HeaderText="Message" SortExpression="Message" />
                <asp:BoundField DataField="DateReceived" HeaderText="Date" SortExpression="DateReceived" HeaderStyle-Width="200" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

