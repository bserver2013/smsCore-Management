<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="sms_broadcast.aspx.cs" Inherits="management_sms_broadcast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/bootstrap-combined.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="broadcast">
        <br />
        <h2>SMS Broadcast</h2>
        <table id="tblBroadcast">
            <tr>
                <td>
                    Body of Message 1 <br /> 
                    <asp:TextBox ID="txtMsg1" runat="server" TextMode="MultiLine" Width="400" Height="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Body of Message 2 <br /> 
                    <asp:TextBox ID="txtMsg2" runat="server" TextMode="MultiLine" Width="400" Height="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 50px;" valign="top">
                    Encoded by: <asp:Label ID="lblEncoder" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Upload Text file <br />
                   <asp:FileUpload ID="fuUpload" runat="server" />
                    <asp:Button ID="btnUpload" runat="server" Text="upload" OnClick="btnUpload_Click"  />
                </td>
            </tr>
            <tr>
                <td>
                    <!-- trigger -->
	                <a href="#" id="linkProceed" runat="server" visible="false" class="shower" data-source="#showme">Continue...</a>
                    <br /><br />
                    <asp:Label ID="lblError" runat="server"></asp:Label>
	                <!-- required -->
                </td>
            </tr>
        </table>

        <div id="showme" class="modal hide fade">
	      <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                <img src="images/delete-icon.png" />
            </button>
		    <h3>SMS Broadcast</h3>
	      </div>
	      <div class="modal-body">
		    <p>Would you like to proceed to sms broadcast?</p>
	      </div>
	      <div class="modal-footer">
               <a href="sms_broadcast.aspx?procced=true" class="btn">Yes, Send it now!</a>
		       <a href="sms_broadcast.aspx?procced=false" class="btn">No</a>
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

