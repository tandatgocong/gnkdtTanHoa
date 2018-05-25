<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageApLuc.aspx.cs" Inherits="GiamNuocWeb.pageApLuc" %>
<%@ Register TagPrefix="ff" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("SANLUONG").className = "";
     window.document.getElementById("LUULUONG").className = "";
     window.document.getElementById("DHT").className = "";
     window.document.getElementById("APLUC").className = "active";
     window.document.getElementById("THATTHOAT").className = ""; window.document.getElementById("DOBE").className = "";
  </script>
   <style>
    
        .style1
        {
            height: 25px;
            text-align:center;
        }
    
  </style>
                <div class="dhnLoi">
                 <marquee ><asp:Label ID="Label1" runat="server" Text="Tổi"></asp:Label></marquee>
              </div> 

<div class="title_page"><a href="Home.aspx" class="active">&nbsp;<img src="Image/Home2.png" />&nbsp;</a>
<asp:Label ID="title" runat="server" Text="Áp Lực đồng hồ tổng">
</asp:Label></div>
<table border="1" style="margin-top:10px;">
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
    <tr><td class="style1" colspan="2"><asp:Button ID="Button1" CssClass="button" runat="server" Text="&nbsp;Xem&nbsp;" OnClick="bt_Click" /></td></tr>
</table>
<table border="1" style="margin-top:5px;">
    <tr>
    <td>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="500px">
        </rsweb:ReportViewer>

         <br />
    </td>
    </tr>
  </table>

</asp:Content>
