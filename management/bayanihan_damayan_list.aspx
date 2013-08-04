<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="bayanihan_damayan_list.aspx.cs" Inherits="management_bayanihan_damayan_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/bootstrap-combined.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="bayanihan_damayan_list">
        <h2 class="bayanihan_damayan_h3">Bayanihan Damayan List</h2>
        
        <div class="bayanihan_damayan_link" id="links_id" runat="server" visible="false">
            <a href="#" id="_all" runat="server">All</a> |
            <a href="#" id="_winners" runat="server">Show Winners</a>
        </div>

        <asp:GridView ID="gvbayanihan_list" runat="server" AutoGenerateColumns="False"
            GridLines="None"
            CssClass="gridClass"
            HeaderStyle-CssClass="headClass"
            AlternatingRowStyle-CssClass="rowClass" >
            <Columns>
                <asp:BoundField DataField="refNo" HeaderText="Ref No" SortExpression="refNo" />
                <asp:BoundField DataField="donator" HeaderText="Donator" SortExpression="donator" />
                <asp:BoundField DataField="combination" HeaderText="Combination" SortExpression="combination" />
                <asp:BoundField DataField="donation" HeaderText="Donation" SortExpression="donation" />
                <asp:BoundField DataField="date_danated" HeaderText="Date Danated" SortExpression="date_danated" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" HeaderStyle-Width="200" />
            </Columns>
        </asp:GridView>

        <a href="#" id="lbUpdate" runat="server" class="shower" data-source="#showme" visible="false"> Enter Winning Code </a>
        <div id="over-all-total">

            <table border="0" id="tbl_total" runat="server" visible="false">
                <tr>
                    <td style="text-align: right;">Total Donations:</td>
                    <td style="text-align: right; width: 120px;"><asp:Label ID="txtTotalDon" runat="server"></asp:Label></td>
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

        <div id="showme" class="modal hide fade">
	      <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                <img src="images/delete-icon.png" />
            </button>
		    <h3>Bayanihan Damayan</h3>
	      </div>
	      <div class="modal-body">
		    <p>Enter Winning Code</p>
            <asp:TextBox ID="txtWinCode" runat="server" placeholder="Winning Code" ></asp:TextBox>
	      </div>
	      <div class="modal-footer">
               <asp:LinkButton class="btn" ID="lbSend" runat="server" OnClick="btnProceed_Click">Proceed</asp:LinkButton>
		       <a href="#" class="btn" data-dismiss="modal">No</a>
	      </div>
	    </div>
	
	    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
	    <script src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/js/bootstrap.min.js"></script>
	    <script type="text/javascript">
	        $(document).ready(function () {
	            $('.shower').click(function (event) {
	                var id = $(this).attr('data-source');
	                $(id).modal('toggle');
	            });
	        });
	    </script>
    </div>

</asp:Content>

