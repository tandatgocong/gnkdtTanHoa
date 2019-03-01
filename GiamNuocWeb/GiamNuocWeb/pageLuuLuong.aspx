<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageLuuLuong.aspx.cs" Inherits="GiamNuocWeb.pageLuuLuong" %>
<%@ Register TagPrefix="ff" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("DHT").className = "dropdown active";        
  </script>
    <style>
    
        .style1
        {
            height: 25px;
            text-align:center;
        }
    
  </style>
                <div class="dhnLoi">
                 <marquee ><asp:Label  ID="Label1" runat="server" Text="Tổi" ForeColor="Red"></asp:Label></marquee>
              </div> 

<div class="title_page"><a href="Home.aspx" class="active">&nbsp;<img src="Image/Home2.png" />&nbsp;</a>
<asp:Label ID="title" runat="server" Text="Lưu lượng đồng hồ tổng">
</asp:Label></div>
<table border="0" style="margin-top:10px;">
    <tr><td class="style1">Mã DMA : </td>
    <td><div>

        <ff:DropDownCheckBoxes ID="DropDownDMA" runat="server" Font-Size="13">
            <Style DropDownBoxBoxHeight="150" DropDownBoxBoxWidth="150" 
                SelectBoxWidth="145" />
        </ff:DropDownCheckBoxes>

        </div>
    </td>
     </tr>
    <tr ><td class="style1">Từ Ngày  </td><td><asp:TextBox ID="tTuNgay" runat="server" TextMode="Date"></asp:TextBox></td></tr>
    <tr><td class="style1">Đến Ngày </td><td><asp:TextBox ID="tDenNgay" runat="server" TextMode="Date"></asp:TextBox></td></tr>
    <tr><td class="style1" ><asp:CheckBox ID="check" runat="server" Text="NRW" /></td><td><asp:Button ID="Button1" CssClass="button" runat="server" Text="&nbsp;Xem&nbsp;" OnClick="bt_Click" /></td><td><asp:CheckBox ID="checkSX" runat="server" Text="SX" /></td></tr>
</table>

<table border="1" style="margin-top:5px;">
    <tr>
    <td>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="590px"  ZoomMode="PageWidth">
        </rsweb:ReportViewer>

         <br />
    </td>
    </tr>
  </table>
</asp:Content>
