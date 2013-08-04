<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="transfer_funds_reports.aspx.cs" Inherits="management_transfer_funds_reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="transfer-funds-report">
        <h2 class="listMember">Transfer Funds Report List</h2>
        <asp:GridView ID="gvtransferfundsreport" runat="server" AutoGenerateColumns="False"
            AllowPaging="true"
            PageIndex="5"
            GridLines="None"
            CssClass="gridClass"
            HeaderStyle-CssClass="headClass"
            AlternatingRowStyle-CssClass="rowClass"
            OnRowCommand="gvtransferfundsreport_OnRowCommand"
            OnPageIndexChanging="gvtransferfundsreport_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Reference No" HeaderStyle-Width="130" >
                    <ItemTemplate>
                        <asp:LinkButton ID="lbReferenceNo" runat="server" CausesValidation="false" CommandName="ReferenceNo" Text='<%# Eval("ReferenceNo") %>' CommandArgument='<%# Eval("ReferenceNo") %>'></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="Sender" />
                <asp:BoundField DataField="Receiver" HeaderText="Receiver" SortExpression="Receiver" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="DateTransfered" HeaderText="Date Transfered" SortExpression="DateTransfered" HeaderStyle-Width="200" />
                 <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" HeaderStyle-Width="50" />
            </Columns>
        </asp:GridView>

        <div id="over-all-total">
            <p>Total:</p>
            <asp:TextBox ID="txtTotal" runat="server" Width="190" ReadOnly="true"></asp:TextBox>
        </div>

        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

</asp:Content>

