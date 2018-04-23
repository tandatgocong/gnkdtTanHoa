<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SanLuong.aspx.cs" Inherits="GiamNuocWeb.SanLuong" %>
<%@ Register TagPrefix="asp" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>
<%--
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("SANLUONG").className = "active";
     window.document.getElementById("LUULUONG").className = "";
     window.document.getElementById("APLUC").className = "";

  </script>
  <style>
    
        .style1
        {
            height: 25px;
            text-align:center;
        }
    
  </style>
<div class="title_page"><asp:Label ID="title" runat="server" Text="Sản Lượng đồng hồ tổng"></asp:Label></div>
<div style="font-size:13px;" >
<table border="1" style="margin-top:10px;">
    <tr><td class=style1>Mã DMA : </td><td>
        <asp:DropDownCheckBoxes ID="DropDownDMA" runat="server" Font-Size="13"> 
         <Style SelectBoxWidth="145" DropDownBoxBoxWidth="150" DropDownBoxBoxHeight="150"/>
        </asp:DropDownCheckBoxes> 
     </td></tr>
    <tr ><td class=style1>Từ Ngày  </td><td><asp:TextBox ID="TextBox1" runat="server" TextMode=Date></asp:TextBox></td></tr>
    <tr><td class=style1>Đến Ngày </td><td><asp:TextBox ID="TextBox2" runat="server" TextMode=Date></asp:TextBox></td></tr>
    <tr><td class=style1 colspan=2><asp:Button ID="Button1" CssClass=button runat="server" Text="Xem" /></td></tr>
</table>

<table border="1" style="margin-top:10px;">
    <tr>
    <td>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="669px">
            <LocalReport ReportPath="rpSanLuong.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="dsDma" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </td>
    </tr>
  </table>

    
 </div>    
</asp:Content>