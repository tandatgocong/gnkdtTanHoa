<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDBTongKet.aspx.cs" Inherits="GiamNuocWeb.pageDBTongKet" %>
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
          Nhóm Dò Bể:                 
                </td>
                <td class="style3" colspan=3 >
                    <asp:DropDownList ID="cbNhomDB" runat="server">                      
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
        <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" 
            onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="STT" HeaderText="STT">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="DiaChi" HeaderText="Địa Chỉ" />
                <asp:BoundField DataField="NgayBao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày Báo">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="LoaiBe" HeaderText="Loại Bể">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="TinhTrang" HeaderText="Điểm bể">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                </asp:BoundField>
                <asp:BoundField DataField="AutoDel" HeaderText="Xóa">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="Chuyen" HeaderText="Chuyển Sửa Bể">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="InThongBao" HeaderText="In Thông Báo">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="TinhTrangSuaBe" HeaderText="Tình Trạng">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="GhiChuSuaBe" HeaderText="Ghi Chú Sửa Bể">
                <ItemStyle VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" Height="35px" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>

    <table cellpadding="0" cellspacing="0" class="table_list" 
            style="font-family:Times New Roman; font-size:15px; margin-left:20px; margin-top:10px;">
                                <tr class="head1">
                                    <td class="style26" 
                                        style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                        TỔNG ĐIỂM BỂ</td>
                                    <td   
                                        style="border-right: 1px #FF0000 solid; border-bottom: 1px solid; background-color: #FFFF99; text-align: right; width:30px;">
                                        <asp:Label ID="tc_tongdiem" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                    <td class="style6" 
                                        
                                        style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                        ĐIỂM BỂ NỔI</td>
                                    <td class="style4" 
                                        style="border-right: 1px #FF0000 solid; border-bottom: 1px solid; background-color: #FFFF99; text-align: right; width:30px;">
                                        <asp:Label ID="tc_benoi" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                </tr>
                                <tr class="head1">
                                    <td class="style26" 
                                        style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                        ĐIỂM BỂ NGẦM</td>
                                    <td class="style4" 
                                        style="border-right: 1px #FF0000 solid; border-bottom: 1px solid; background-color: #FFFF99; text-align: right; ">
                                        <asp:Label ID="tc_bengam" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                    <td class="style6" 
                                        style="border-right: 2px #FF0000 solid; border-bottom-style: solid; border-bottom-color: inherit; border-bottom-width: 1px;">
                                        TỒNG ĐIỂM SỬA</td>
                                    <td class="style4" 
                                        style="border-right: 1px #FF0000 solid; border-bottom: 1px solid; background-color: #FFFF99; text-align: right;">
                                        <asp:Label ID="tc_diemsua" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                </tr>
                                 <tr class="head1">
                                    <td class="style26" 
                                        style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                        ĐIỂM CHƯA SỬA</td>
                                    <td class="style4" 
                                        style="border-right: 1px #FF0000 solid; border-bottom: 1px solid; background-color: #FFFF99; text-align: right;">
                                        <asp:Label ID="tc_chuasua" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
                                    </td>
                                    <td class="style6" 
                                        
                                        style="border-right: 2px #FF0000 solid; border-bottom: 1px solid;  text-align: right;">
                                        ĐIỂM KHÔNG BỂ</td>
                                    <td class="style4" 
                                        style="border-right: 1px #FF0000 solid; border-bottom: 1px solid; background-color: #FFFF99; text-align: right;">
                                        <asp:Label ID="tc_khongbe" runat="server" Font-Size="X-Large" ForeColor="Red">0</asp:Label>
          </td>
      </tr>
       </table>


  </asp:Panel>
</asp:Content>
