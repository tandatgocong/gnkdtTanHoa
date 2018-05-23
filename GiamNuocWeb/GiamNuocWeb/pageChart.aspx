<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageChart.aspx.cs" Inherits="GiamNuocWeb.pageChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript" src="https://www.google.com/jsapi"></script><!-- linechart "corechart",-->
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["linechart" ] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {        
            var data = google.visualization.arrayToDataTable([
         <%=Session["sanluong"] %>
        ]);

            var options = {
                title: null,          
                 height: 400,
                 width: 1500,
                legend : 'top' 
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
            chart.title.remove();
        }
    </script>
<table><tr><td colspan=2 ><div class="title_page2"> DMA : 
                        <asp:DropDownList ID="listDMA" runat="server" Height="24px" 
           Width="67px" onselectedindexchanged="listDMA_SelectedIndexChanged" 
           AutoPostBack="True">
                        </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" CssClass="button" 
        OnClick="bt_Click" Text="&nbsp;Xem&nbsp;" />
                    </div></td></tr>
<tr><td>Ngày</td><td><asp:TextBox ID="tTuNgay" runat="server" TextMode="Date"></asp:TextBox></td></tr>
<tr><td colspan=2 >
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" 
        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
        AutoPostBack="True">
        <asp:ListItem Selected="True" Value="1">Lưu lượng</asp:ListItem>
        <asp:ListItem Value="2">Inlet</asp:ListItem>
        <asp:ListItem Value="3">Outlet</asp:ListItem>
        <asp:ListItem Value="4">CMP</asp:ListItem>
    </asp:RadioButtonList>

    </td></tr>

</table>
<div id="chart_div" style="height:400px; width"></div>
</asp:Content>
