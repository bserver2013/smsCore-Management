<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="user_edit.aspx.cs" Inherits="management_user_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="edit" >

        <h2 class="listMember">Edit User</h2> <br />
        <div class="column1">
            <dt>Username:</dt>
            <dd> <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox> </dd>

            <dt>Email:</dt>
            <dd> <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> </dd>

            <dt>Role:</dt>
            <dd> 
                <asp:DropDownList ID="ddlRole" runat="server">
                    <asp:ListItem Selected="True"> Select Role </asp:ListItem>
                    <asp:ListItem Value="admin"> Admin </asp:ListItem>
                    <asp:ListItem Value="developer"> Developer </asp:ListItem>
                    <asp:ListItem Value="user"> User </asp:ListItem>
                 </asp:DropDownList> 
            </dd>
        </div>

        <div class="column1-bottom">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" />
            <br /> <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </div>

    </div>

</asp:Content>

