<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageThatThoatTiLe.aspx.cs" Inherits="GiamNuocWeb.pageThatThoatTiLe" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script language="javascript" type="text/javascript">
       window.document.getElementById("THATTHOAT").className = "dropdown active";        
  </script>
  
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

<table style="width: 200px"><tr><td style="width: 80px"   ><div class="title_page2"> DMA   
                    </div></td><td style="width: 67px"><asp:DropDownList ID="listDMA" runat="server" Height="24px" 
           Width="67px" onselectedindexchanged="listDMA_SelectedIndexChanged" 
           AutoPostBack="True">
                        </asp:DropDownList></td><td style="width: 49px"><asp:Button ID="Button1" runat="server" CssClass="button" 
        OnClick="bt_Click" Text="&nbsp;Xem&nbsp;" /></td></tr>
<tr><td style="width: 50px">Tuần</td><td style="width: 67px">
    <asp:TextBox ID="tTuNgay" runat="server" 
        TextMode="Number" Width="67px">8</asp:TextBox></td><td> </td></tr>
</table>
    <br />
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <rsweb:ReportViewer Width="100%" ID="ReportViewer1" runat="server" ZoomMode="PageWidth" 
        Height="300px">
         </rsweb:ReportViewer>
         <br />
         <div id="chart_div" style="height:400px; width"></div>
</asp:Content>
