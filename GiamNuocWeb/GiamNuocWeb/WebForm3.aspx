<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="GiamNuocWeb.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="STT" HeaderText="STT">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="TenNhom" HeaderText="Tên Nhóm">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="DMA" HeaderText="DMA Đang Dò">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="NgayBatDau" HeaderText="Ngày Nhận ">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Height="35px" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    
        <br />
&nbsp;
    
    </div>
    </form>
</body>
</html>
