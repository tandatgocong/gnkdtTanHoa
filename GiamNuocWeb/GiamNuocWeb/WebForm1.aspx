<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GiamNuocWeb.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    </head>
<body>
    <form id="form1" runat="server">
    <div>
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                BackColor="White" Font-Size="Small" BorderColor="#CC9966" 
                BorderStyle="None" BorderWidth="1px"  Width="100%"
                CellPadding="4" 
                style="text-align: center" onrowdatabound="GridView2_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="Chọn" Visible="False">
                        <ItemTemplate>
                            <asp:CheckBox ID="checkChon" runat="server" />
                        </ItemTemplate>                        
                        <ItemStyle Width="40px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="STT" HeaderText="STT">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TenNhom" HeaderText="Nhóm ">
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Địa Chỉ">
                         <ItemTemplate>
                            <b> <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("ID") %>' Text='<%# Bind("DiaChi") %>'></asp:LinkButton> </b>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                      <asp:BoundField DataField="TenPhuong" HeaderText="Phường">
                    </asp:BoundField>
                      <asp:BoundField DataField="TenQuan" HeaderText="Quận">
                    </asp:BoundField>
                    <asp:BoundField DataField="MaDMA" HeaderText="DMA">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="" Visible="False">
                        <ItemTemplate>
                            <div ID="popup">
                                <a href="#">Image<span>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# BIND("HinhAnh") %>' />
                                </span></a>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="LoaiBe" HeaderText="Loại Bể">
                    </asp:BoundField>
                     <asp:BoundField DataField="PhuiLe" HeaderText="Kết Cấu Lề">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PhuiDuong" HeaderText="Kết Cấu Đường">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NgayBao" HeaderText="Ngày Báo" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GhiChuu" HeaderText="Ghi Chú" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="ID" Visible="False">
                         <ItemTemplate>
                            <b> <asp:Label ID="lbID" runat="server"  Text='<%# Bind("DiaChi") %>'></asp:Label> </b>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle ForeColor="#330099" Height="25px" BackColor="White" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
    
    </div>
    </form>
</body>
</html>



