<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GiamNuocWeb.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="800px" ScrollBars="Both" 
            Width="800px">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">Thêm Mới</asp:ListItem>
                <asp:ListItem Value="1">Chuyển ĐB</asp:ListItem>
                <asp:ListItem Value="2">Theo dõi</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="checkDDS" runat="server" 
                AutoPostBack="True" oncheckedchanged="checkDDS_CheckedChanged" 
                Text="Đã Đánh Sơn" />
&nbsp;

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" Font-Size="Small" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px"  Width="100%"
                CellPadding="3" 
                style="text-align: center" onrowdatabound="GridView1_RowDataBound"  onrowcommand="GridView1_RowCommand"  >
                <Columns>
                    <asp:BoundField DataField="STT" HeaderText="STT">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TenNhom" HeaderText="Nhóm ">
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Địa Chỉ">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DiaChi") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Bind("DiaChi") %>'></asp:LinkButton>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
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
                    <asp:TemplateField HeaderText="Tình Trạng">
                        <ItemTemplate>
                            <asp:Button ID="btChuyenTT" runat="server" CommandArgument='<%# Bind("ID") %>' 
                                CommandName="chuyenTT" CssClass="buttonGir" 
                                onclientclick="if(confirm('Bạn có muốn chuyển Tình Trạng ?') == false)return false;" 
                                Text='<%# Bind("TinhTrang") %>' Width="100%" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                     <asp:BoundField DataField="KetCauLe" HeaderText="Kết Cấu Lề">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="KetCauDuong" HeaderText="Kết Cấu Đường">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NgayBao" HeaderText="Ngày Báo" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Chuyển Thông Báo">                      
                        <ItemTemplate>
                               <asp:Button ID="btChuyenTB" CssClass=buttonGir runat="server" Width="100%" Text='<%# Bind("Chuyen") %>' Visible=false  CommandArgument='<%# Bind("ID") %>' CommandName="chuyenTB"   onclientclick="if(confirm('Bạn có muốn chuyển Thông Báo?') == false)return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>


        </asp:Panel>
    
            
        
    
    </div>
    </form>
</body>
</html>



