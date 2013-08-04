<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="bayanihan_damayan.aspx.cs" Inherits="management_bayanihan_damayan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="bayanihan_damayan">
        <h2 class="listMember">Bayanihan Damayan</h2>
        <asp:GridView ID="gvbayanihan" runat="server" AutoGenerateColumns="False"
            AllowPaging="true"
            PageIndex="5"
            GridLines="None"
            CssClass="gridClass"
            HeaderStyle-CssClass="headClass"
            AlternatingRowStyle-CssClass="rowClass" 
            OnRowCommand="gvbayanihan_OnRowCommand"
            OnPageIndexChanging="gvbayanihan_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Reference No" HeaderStyle-Width="130" >
                    <ItemTemplate>
                        <asp:LinkButton ID="lbReferenceNo" runat="server" CausesValidation="false" CommandName="Bayanihan_Ref#" Text='<%# Eval("bayanihan_ref") %>' CommandArgument='<%# Eval("bayanihan_ref") %>'></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="played" HeaderText="Donators" SortExpression="played" />
                <asp:BoundField DataField="donations" HeaderText="Donations" SortExpression="donation" />
                <asp:BoundField DataField="combination_no_win" HeaderText="Winning Code" SortExpression="combination_no_win" />
                <asp:BoundField DataField="total_win" HeaderText="Total Win" SortExpression="total_win" />
                <asp:BoundField DataField="total_win_amount" HeaderText="Total Amount" SortExpression="total_win_amount" />
                <asp:BoundField DataField="open_started" HeaderText="Open Started" SortExpression="open_started" HeaderStyle-Width="200" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" HeaderStyle-Width="50" />
            </Columns>
        </asp:GridView>

        <div id="over-all-total">

            <table border="0">
                <tr>
                    <td style="text-align: right;">Total Donations:</td>
                    <td style="text-align: right; width: 120px;""><asp:Label ID="txtTotalDon" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right;">Total Winners:</td>
                    <td style="text-align: right;"><asp:Label ID="lblTotalWin" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; border-top: 1px solid #ccc;"><b>Total Remaining:</b></td>
                    <td style="text-align: right; border-top: 1px solid #ccc;"><asp:Label ID="lblTotalRem" runat="server"></asp:Label></td>
                </tr>
            </table>

        </div>

        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

</asp:Content>

