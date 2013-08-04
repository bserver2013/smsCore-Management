<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="management_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="users">
        <h2 class="listMember">List of Users</h2>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False"
            AllowPaging="true"
            PageIndex="5"
            GridLines="None"
            CssClass="gridClass"
            HeaderStyle-CssClass="headClass"
            AlternatingRowStyle-CssClass="rowClass"
             OnRowCommand="gvUsers_OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Admin" HeaderStyle-Width="80" >
                    <ItemTemplate>
                        <asp:LinkButton ID="lbId" runat="server" CausesValidation="false" CommandName="viewAccount" Text='<%# Eval("admin") %>' CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="role" HeaderText="Role" SortExpression="role" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                <asp:BoundField DataField="added_by" HeaderText="Added By" SortExpression="added_by" />
                <asp:BoundField DataField="date_added" HeaderText="Date" SortExpression="date_added" HeaderStyle-Width="200" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

</asp:Content>

