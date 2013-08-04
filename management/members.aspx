<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="members.aspx.cs" Inherits="view_members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div id="members">
        <h2 class="listMember">List of Member</h2>
        <asp:Button ID="btnSearchAccount" runat="server" Text="Search" OnClick="btnSearchAccount_Click" />
        <asp:TextBox ID="txtSeachAccount" runat="server" Width="200">Enter Act#, Ref# or Num</asp:TextBox>
                
        <br /><br />
        <asp:GridView ID="tblmanage" runat="server" AutoGenerateColumns="False"
            AllowPaging="true"
            PageIndex="6"
            GridLines="None"
            CssClass="gridClass"
            HeaderStyle-CssClass="headClass"
            AlternatingRowStyle-CssClass="rowClass"
            OnRowCommand="GridView1_OnRowCommand" OnPageIndexChanging="tblmanage_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Reference #" HeaderStyle-Width="130">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbId" runat="server" CausesValidation="false" CommandName="viewAccount" Text='<%# Eval("ReferenceNo") %>' CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-Width="130" DataField="Account_Number" HeaderText="Account #" SortExpression="Account_Number" />
                <asp:BoundField DataField="Group_Name" HeaderText="Group" SortExpression="Group_Name" />
                <asp:BoundField DataField="Family_Name" HeaderText="Lastname" SortExpression="Family_Name" />
                <asp:BoundField DataField="First_Name" HeaderText="Firstname" SortExpression="First_Name" />
                <asp:BoundField DataField="Town" HeaderText="Town" SortExpression="Town" />
                <asp:BoundField DataField="Sponsor_ID" HeaderText="Sponsor" SortExpression="Sponsor_ID" HeaderStyle-Width="100" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Ammount" HeaderStyle-Width="100" />
                <asp:CheckBoxField DataField="Status" HeaderText="Status" SortExpression="Status" HeaderStyle-Width="70" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>

