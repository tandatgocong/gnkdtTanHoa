<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageDoBeUD.aspx.cs" Inherits="GiamNuocWeb.pageDoBeUD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..: Cập Nhật Điểm Bể :..</title>
   
    <style type="text/css">
        .style1
        {
            width: 96px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
 


<table border="1" style="margin-top:10px;">
            <tr ><td class="style1">Ngày Sửa Bể  </td><td><asp:TextBox ID="tTuNgay" runat="server" TextMode="Date" Width="130px"></asp:TextBox></td><td>
                <asp:Button ID="Button3" runat="server" CssClass="button1" 
                    Text="Đã Sửa Điểm bể" Width="149px" onclick="Button3_Click" /></td>
                    <td><asp:Button ID="Button1" runat="server" CssClass="button1" 
                    Text="Điểm Không bể" Width="149px" onclick="Button1_Click" /></td>
                    </tr>
                    <tr><td colspan=4></td>
                    </tr> 
                     <tr><td colspan=4>
                         <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" 
                             BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                             CellPadding="4">
                             <Columns>
                                 <asp:TemplateField>
                                     <ItemTemplate>
                                         <asp:CheckBox ID="CheckBox1" runat="server" />
                                     </ItemTemplate>
                                     <EditItemTemplate>
                                         <asp:CheckBox ID="CheckBox1" runat="server" />
                                     </EditItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="ID">
                                     <ItemTemplate>
                                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                     </ItemTemplate>
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="TenNHom" HeaderText="Nhóm Dò Bể" />
                                 <asp:BoundField DataField="NgayDo" HeaderText="Ngày Báo" />
                                 <asp:BoundField DataField="SoNha" HeaderText="Số Nhà" />
                                 <asp:BoundField DataField="Duong" HeaderText="Đường" />
                                 <asp:BoundField DataField="DMA" HeaderText="DMA" />
                             </Columns>
                             <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                             <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                             <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                             <RowStyle BackColor="White" ForeColor="#003399" />
                             <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                             <SortedAscendingCellStyle BackColor="#EDF6F6" />
                             <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                             <SortedDescendingCellStyle BackColor="#D6DFDF" />
                             <SortedDescendingHeaderStyle BackColor="#002876" />
                         </asp:GridView>
                     </td>
                    </tr>     
    </table>
</form>
</body>
</html>