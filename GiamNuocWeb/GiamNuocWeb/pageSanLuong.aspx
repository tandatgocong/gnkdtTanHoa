﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageSanLuong.aspx.cs" Inherits="GiamNuocWeb.pageSanLuong" %>
<%@ Register TagPrefix="ff" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
                   window.document.getElementById("HOME").className = "";
                   window.document.getElementById("SANLUONG").className = "active";
                   window.document.getElementById("LUULUONG").className = "";
                   window.document.getElementById("APLUC").className = "";
                   window.document.getElementById("DHT").className = ""; 
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
<asp:Label ID="title" runat="server" Text="Sản Lượng đồng hồ tổng">
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
    <tr><td class="style1"><asp:CheckBox ID="check" runat="server" Text="NRW" /></td><td><asp:Button ID="Button1" CssClass="button" runat="server" Text="&nbsp;Xem&nbsp;" OnClick="bt_Click" />
        </td></tr>
</table>

<table border="1" style="margin-top:5px;">
    <tr>
    <td>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="600px">
            <LocalReport ReportPath="rpSanLuong.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="dsDma" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </td>
    </tr>
  </table>
</asp:Content>
