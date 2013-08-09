<%@ Page Title="" Language="C#" MasterPageFile="~/smsCore.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div id="dashboard">
        <h2>Welcome <asp:Label ID="lblWelUser" runat="server"></asp:Label>, to the SMSLauncher Management System! </h2>
        <script src="js/highchart/highcharts.js"></script>
        <script src="js/highchart/exporting.js"></script>
        <link rel="stylesheet" href="js/highchart/jquery-ui.css" />
        <script src="js/highchart/jquery-ui.js"></script>
        <script>
            $(function () {
                $('#container').highcharts({
                    chart: {
                        type: 'line',
                        marginRight: 130,
                        marginBottom: 25
                    },
                    title: {
                        text: 'Monthly Average Report',
                        x: -20 //center
                    },
                    subtitle: {
                        text: 'kingpauloaquino@mail.com',
                        x: -20
                    },
                    xAxis: {
                        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                            'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                    },
                    yAxis: {
                        title: {
                            text: 'SMS Transactions'
                        },
                        plotLines: [{
                            value: 0,
                            width: 1,
                            color: '#808080'
                        }]
                    },
                    tooltip: {
                        valueSuffix: 'Totals'//'°C'
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'top',
                        x: -10,
                        y: 100,
                        borderWidth: 0
                    },
                    series: [{
                        name: 'Outbound',
                        data:  <% Response.Write(highChartController.execute("sentItem")); %>
                        }, {
                            name: 'Inbound',
                            data:  <% Response.Write(highChartController.execute("inbox")); %>
                            }, {
                                name: 'Registering',
                                data: <% Response.Write(highChartController.execute("registered")); %>
                                }
                    ]
                });
            });
    
            $(function() {
                $("#accordion").show();
                $('#nav_hideShow').hide();
            });
            function showMe()
            {
                $("#accordion").fadeIn(1000);
                $("#dev").hide();
                $('#nav_hideShow').hide();
            }
            function hideMe()
            {
                $("#accordion").fadeOut(1000);
                $("#dev").show();
                $('#nav_hideShow').show();
            }
        </script>
        <h2><asp:Label ID="lblAdmin" runat="server"></asp:Label></h2> <br />
        <div id="container" style="min-width: 700px; height: 280px; margin: 0 auto"></div>
        <br />

        <div id="accordion">
	        <h3>Server Information [<asp:Label ID="lblCpuName" runat="server"></asp:Label>] <img class="img_hide" onclick="hideMe()" src="images/delete-icon.png" alt="Hide" title="Hide"></a></h3> <br />
	        <div class="c1">
                <h4>CPU</h4>
                <table style="padding: 0px;" border="0">
                    <tr>
                        <td>CPU Usaged:</td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                    <asp:Label ID="lblCpuUsaged" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>Processors:</td>
                        <td><% Response.Write(hardwareController.NumberOfProcessors + "-" + hardwareController.NumberOfLogicalProcessors + " / " + hardwareController.NumberOfCores); %></td>
                    </tr>
                    <tr>
                        <td>Max Clock Speed:</td>
                        <td><% Response.Write(hardwareController.MaxClockSpeed); %></td>
                    </tr>
                    <tr>
                        <td>L2 / L3 Cache:</td>
                        <td><% Response.Write(hardwareController.L2CacheSize + " / " + hardwareController.L3CacheSize); %></td>
                    </tr>
                </table>
	        </div>
            <div class="c2">
                <h4>Memory</h4>
                <table style="padding: 0px;" border="0">
                    <tr>
                        <td>Free Memory:</td>
                        <td>
                           Memory <%--<% Response.Write(hardwareController.MemoryUsaged()); %>--%>
                        </td>
                    </tr>
                </table>
	        </div>
            <div class="c3">
                <h4>Local Drive</h4>
                <p> <asp:Label ID="lblLocal" runat="server">asdjasldjasl</asp:Label> </p>
	        </div>
        </div>

        <div id="nav_hideShow">
	        <h3 onclick="showMe()">Server Information [<asp:Label ID="lblCpuName2" runat="server"></asp:Label>]  </h3> 
	        <img onclick="showMe()" src="images/arrow-down-icon.png" alt="Show" title="Show" />
        </div>

    </div>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
</asp:Content>

