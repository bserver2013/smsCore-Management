<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="add_users.aspx.cs" Inherits="management_add_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="add" >

        <h2 class="listMember">Add User</h2> <br />
        <div class="column1">
            <dt>Username:</dt>
            <dd> <asp:TextBox ID="txtUsername" placeholder="Enter username" runat="server"></asp:TextBox> </dd>

            <dt>Passwor.:</dt>
            <dd> <asp:TextBox ID="txtPassword" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox> </dd>

            <dt>Re-type password:</dt>
            <dd> <asp:TextBox ID="txtRePassword" placeholder="Re-type Password" runat="server" TextMode="Password"></asp:TextBox> </dd>

            <dt>Email:</dt>
            <dd> <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email"></asp:TextBox> </dd>

            <dt>Role:</dt>
            <dd> 
                <asp:DropDownList ID="ddlRole" runat="server">
                    <asp:ListItem Value="Select Role" Selected="True">Select Role</asp:ListItem>
                    <asp:ListItem Value="admin">Admin</asp:ListItem>
                    <asp:ListItem Value="developer">Developer</asp:ListItem>
                    <asp:ListItem Value="user">User</asp:ListItem>
                 </asp:DropDownList> 
            </dd>
            <dd class="dd"> <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /> </dd>
            <dd> <br /> <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label></dd>
        </div>

    </div>

</asp:Content>

