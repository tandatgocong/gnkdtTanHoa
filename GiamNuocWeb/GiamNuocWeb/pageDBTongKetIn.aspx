<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDBTongKetIn.aspx.cs" Inherits="GiamNuocWeb.pageDBTongKetIn" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="css/style22.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.document.getElementById("DOBE").className = "dropdown active ";
</script>
<style>
 .title_mobile
          {
        border-bottom: 2px solid #663300;
        color: #006600;
        font-family: Tahoma,Arial,Helvetica,sans-serif;
        font-size: 13px;
        font-weight: bold;
        margin: 0 10px;
        padding: 5px 0;
        text-transform: uppercase;
    }      
 div.title_page 
    {
        margin-top:10px;
        margin-left:10px;
        border-bottom: 2px solid #663300;
        color: #006600;
        font-family: Tahoma,Arial,Helvetica,sans-serif;
        font-size: 14px;
        font-weight: bold;
        text-transform: uppercase;
    }
</style>
<asp:Panel ID="pThemMoi" runat="server" >   
  <div class='title_page'>TỔNG KẾT ĐIỂM BỂ</div>
  <div style="margin-left:10px; font-size: 13px;margin-top:10px;">          
     <table>
        <tr style="height:20px;">
          <td class="style33">
          Chọn Báo Cáo:                 
                </td>
                <td class="style3" colspan=3 >
                    <asp:DropDownList ID="cbChonBC" runat="server"> 
                        <asp:ListItem Value="1">Theo Dõi Định Mức Dò Bể</asp:ListItem>
                        <asp:ListItem Value="2">Báo Cáo Định Mức Dò Bể</asp:ListItem>
                        <asp:ListItem Value="3">KTB</asp:ListItem>
                        <asp:ListItem Value="ĐĐS">Bể ĐĐS</asp:ListItem>                     
                    </asp:DropDownList>                   
                </td>
            </tr>
     </table>
            <table style="margin-top:10px;">
              <tr><td>
              Từ Ngày: <asp:TextBox ID="tNgay" runat="server" Width="122px" Height="20px" TextMode="Date"/></td><td>đến&nbsp;</td><td><asp:TextBox ID="dNgay" runat="server" Width="122px" Height="20px" TextMode="Date"/></td>
              </tr>
       </table>
     <div style="margin:10px; ">
      <asp:Button ID="btThen" runat="server" CssClass="button" Height="25px" 
                          onclick="btThen_Click" Text="Tra Cứu" Width="103px" />
     </div>     
   </div>
   <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ConsumeContainerWhiteSpace = true ShowPrintButton="true"  Width="795px" Height="590px"
        Visible="false" ZoomMode="PageWidth" >
    </rsweb:ReportViewer>



  </asp:Panel>
</asp:Content>
