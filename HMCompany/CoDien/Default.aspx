<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebHMI.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">

 &nbsp;&nbsp;&nbsp;<asp:DropDownList 
     ID="dropSearch" runat="server" AutoPostBack="True" 
     onselectedindexchanged="dropSearch_SelectedIndexChanged">
     <asp:ListItem Value="0">Tên Ứng Viên</asp:ListItem>
     <asp:ListItem Value="1">Địa Chỉ</asp:ListItem>
     <asp:ListItem Value="2">Ngày Ứng Tuyển</asp:ListItem>
     <asp:ListItem Value="3">Chưa phỏng vấn</asp:ListItem>
     <asp:ListItem Value="4">Đã xếp phỏng vấn</asp:ListItem>
     <asp:ListItem Value="5">Đã phỏng vấn</asp:ListItem>
     <asp:ListItem Value="6">Đậu phỏng vấn</asp:ListItem>
     <asp:ListItem Value="7">Đậu phỏng vấn</asp:ListItem>
     <asp:ListItem Value="8">Hủy</asp:ListItem>
 </asp:DropDownList>
 <asp:TextBox ID="txtSearch" runat="server" Width="150px" 
     ontextchanged="txtSearch_TextChanged"></asp:TextBox>
&nbsp;<div class="tongket">
  <asp:Label ID="lbTong" runat="server" Text="Tổng"></asp:Label>
              </div> 
 <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns = "False" 
     BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
     CellPadding="4" ForeColor="Black" GridLines="Vertical" 
     onrowdatabound="GridView1_RowDataBound" Font-Size="12px" 
     AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
     PageSize="6">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Ảnh">
                
                <ItemTemplate>                    
                    <asp:Image ID="Image1" runat="server" Height="114px" Width="129px" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Họ Tên">
                
                <FooterTemplate>
                    <asp:Label ID="lbTongSo" runat="server" 
                        style="font-size: medium; font-weight: 700; color: #0000FF" Text="Label"></asp:Label>
                </FooterTemplate>
                
                <ItemTemplate>
                    
                    <table style="width:100%;"  >
                        <tr>
                            <td class="row">
                              <span style="color:Red; font-weight:bold" ><asp:Label ID="Label2" runat="server" Text='<%# Bind("HoTen") %>'></asp:Label></span>
                            </td>                            
                        </tr>
                        <tr>
                            <td class="row">
                                Giới tính: <asp:Label ID="Label6" runat="server" Text='<%# Bind("GioiTinh") %>'></asp:Label>
                                </td>
                            
                        </tr>
                        <tr>
                            <td class="row">
                                Ngày sinh: <asp:Label ID="Label1" runat="server" Text='<%# Bind("NgaySinh") %>'></asp:Label>
                                </td>
                            
                        </tr>
                        <tr>
                            <td class="row">
                                Nơi sinh: <asp:Label ID="Label5" runat="server" Text='<%# Bind("NoiSinh") %>'></asp:Label>
                                </td>
                            
                        </tr>
                        
                        <tr>
                            <td class="row">
                                Tình trạng: <span style="color:Blue; font-weight:bold" ><asp:Label ID="Label16" runat="server" Text='<%# Bind("TinhTrang") %>'></asp:Label></span></td>
                        </tr>
                        
                    </table>

                </ItemTemplate>
                <ItemStyle Width="30%" VerticalAlign="Top" />
            </asp:TemplateField>

            
            <asp:TemplateField HeaderText="Số CMND">
                
                <ItemTemplate>
                     <table style="width:100%;">
                        <tr>
                            <td class="row">
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("SoCMND") %>'></asp:Label>
                            </td>                            
                        </tr>
                        <tr>
                            <td>
                               Nơi cấp:  <asp:Label ID="Label8" runat="server" Text='<%# Bind("NoiCap") %>'></asp:Label>
                                </td>
                            
                        </tr>
                        
                    </table>

                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hộ Chiếu">
               
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td class="row">
                               <asp:Label ID="Label3" runat="server" Text='<%# Bind("HoChieu") %>'></asp:Label>
                            </td>                            
                        </tr>
                        <tr>
                            <td class="row"> 
                               Ngày Cấp:  <asp:Label ID="Label9" runat="server" Text='<%# Bind("HCNgay") %>'></asp:Label>
                                </td>
                            
                        </tr>
                         <tr>
                            <td>
                               Nơi Cấp:  <asp:Label ID="Label10" runat="server" Text='<%# Bind("HCNoiCap") %>'></asp:Label>
                                </td>
                            
                        </tr>
                        
                    </table>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Địa Chỉ">
                
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td class="row">
                             Địa chỉ:   <asp:Label ID="Label11" runat="server" Text='<%# Bind("DiaChi") %>'></asp:Label>
                            </td>                            
                        </tr>
                        <tr>
                            <td class="row">
                                Nguyên quán : <asp:Label ID="Label13" runat="server" Text='<%# Bind("NguyenQuan") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               HKTT:  <asp:Label ID="Label12" runat="server" Text='<%# Bind("HKTT") %>'></asp:Label>
                                </td>
                            
                        </tr>
                        
                    </table>
                    
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" Width="30%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Điện Thoại">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DTDD") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                 <table style="width:100%;">
                        <tr>
                            <td class="row">
                             DĐ:   <asp:Label ID="Label4" runat="server" Text='<%# Bind("DTDD") %>'></asp:Label>
                            </td>                            
                        </tr>
                        <tr>
                            <td class="row">
                                SĐT : <asp:Label ID="Label14" runat="server" Text='<%# Bind("SDT") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Người thân:  <asp:Label ID="Label15" runat="server" Text='<%# Bind("SDTNT") %>'></asp:Label>
                                </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <ItemStyle Width="10%" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:BoundField DataField="MTUVID" HeaderText="ID" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
        <PagerTemplate>

          <table>
          <tr>
             <td>
                 <asp:LinkButton ID="lb1" Text="Previous" 

                 CommandName="Page" CommandArgument="Prev" runat="server" />
              </td>
              <td>
                <asp:label id="CurrentPageLabel"
                  forecolor="Blue"
                  runat="server"/>
              </td>
              <td>
                 <asp:LinkButton ID="lb2" Text="Next" CommandName="Page" 

                 CommandArgument="Next" runat="server" />
               </td>    
          </tr>
       </table>   
        </PagerTemplate>
        <RowStyle BackColor="#F7F7DE" Height="35px" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>

            
<%--<script type = "text/javascript">

    var GridId = "<%=GridView1.ClientID %>";
    var ScrollHeight = 300;

    window.onload = function () {
        var grid = document.getElementById(GridId);
        var gridWidth = grid.offsetWidth;
        var gridHeight = grid.offsetHeight;
        var headerCellWidths = new Array();
        for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
            headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
        }
        grid.parentNode.appendChild(document.createElement("div"));
        var parentDiv = grid.parentNode;

        var table = document.createElement("table");
        for (i = 0; i < grid.attributes.length; i++) {
            if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
            }
        }
        table.style.cssText = grid.style.cssText;
        table.style.width = gridWidth + "px";
        table.appendChild(document.createElement("tbody"));
        table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
        var cells = table.getElementsByTagName("TH");

        var gridRow = grid.getElementsByTagName("TR")[0];
        for (var i = 0; i < cells.length; i++) {
            var width;
            if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                width = headerCellWidths[i];
            }
            else {
                width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
            }
            cells[i].style.width = parseInt(width - 3) + "px";
            gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
        }
        parentDiv.removeChild(grid);

        var dummyHeader = document.createElement("div");
        dummyHeader.appendChild(table);
        parentDiv.appendChild(dummyHeader);

        var scrollableDiv = document.createElement("div");
        if (parseInt(gridHeight) > ScrollHeight) {
            gridWidth = parseInt(gridWidth) + 17;
        }
        scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
        scrollableDiv.appendChild(grid);
        parentDiv.appendChild(scrollableDiv);
    }
 
 </script>--%>

    <p>
&nbsp;&nbsp;&nbsp;
    </p>
 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
     BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
     CellPadding="4" ForeColor="Black" GridLines="Vertical">
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField DataField="TenDM" HeaderText="Quan Hệ">
         <ItemStyle Width="60px" />
         </asp:BoundField>
         <asp:BoundField DataField="HoTen" HeaderText="Họ Tên">
         <ItemStyle Width="150px" />
         </asp:BoundField>
         <asp:BoundField DataField="NamSinh" HeaderText="Năm Sinh">
         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
         </asp:BoundField>
         <asp:BoundField DataField="CVHienTai" HeaderText="Công việc đang làm">
         <ItemStyle Width="90px" />
         </asp:BoundField>
         <asp:BoundField DataField="DiaChi" HeaderText="Chổ ở hiện nay">
         <ItemStyle Width="110px" />
         </asp:BoundField>
     </Columns>
     <FooterStyle BackColor="#CCCC99" />
     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
     <RowStyle BackColor="#F7F7DE" />
     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
     <SortedAscendingCellStyle BackColor="#FBFBF2" />
     <SortedAscendingHeaderStyle BackColor="#848384" />
     <SortedDescendingCellStyle BackColor="#EAEAD3" />
     <SortedDescendingHeaderStyle BackColor="#575357" />
 </asp:GridView>
 <asp:GridView ID="grvHocVan" runat="server" AutoGenerateColumns="False" 
     BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
     CellPadding="4" ForeColor="Black" GridLines="Vertical">
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField DataField="TuThang" HeaderText="Từ Ngày">
         <ItemStyle Width="60px" />
         </asp:BoundField>
         <asp:BoundField DataField="DenThang" HeaderText="Đến Ngày">
         <ItemStyle Width="60px" />
         </asp:BoundField>
         <asp:BoundField DataField="TruongHoc" HeaderText="Trường Học">
         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
         </asp:BoundField>
         <asp:BoundField DataField="TT" HeaderText="Tốt Nghiệp">
         <ItemStyle Width="60px" HorizontalAlign="Center" VerticalAlign="Middle" />
         </asp:BoundField>
         <asp:BoundField DataField="KhoaID" HeaderText="Khoa">
         <ItemStyle Width="110px" />
         </asp:BoundField>
         <asp:BoundField HeaderText="Ghi Chú" DataField="Ghichu" >
         <ItemStyle Width="120px" />
         </asp:BoundField>
     </Columns>
     <FooterStyle BackColor="#CCCC99" />
     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
     <RowStyle BackColor="#F7F7DE" />
     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
     <SortedAscendingCellStyle BackColor="#FBFBF2" />
     <SortedAscendingHeaderStyle BackColor="#848384" />
     <SortedDescendingCellStyle BackColor="#EAEAD3" />
     <SortedDescendingHeaderStyle BackColor="#575357" />
 </asp:GridView>

 <asp:GridView ID="grvCHUNGCHI" runat="server" AutoGenerateColumns="False" 
     BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
     CellPadding="4" ForeColor="Black" GridLines="Vertical">
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField DataField="TuThang" HeaderText="Tháng Năm">
         <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
         </asp:BoundField>
         <asp:BoundField DataField="BangCap" HeaderText="Bằng Cấp">
         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
         </asp:BoundField>
         <asp:BoundField DataField="ChuyenNganh" HeaderText="Chuyên Ngành">
         <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Middle" />
         </asp:BoundField>
     </Columns>
     <FooterStyle BackColor="#CCCC99" />
     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
     <RowStyle BackColor="#F7F7DE" />
     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
     <SortedAscendingCellStyle BackColor="#FBFBF2" />
     <SortedAscendingHeaderStyle BackColor="#848384" />
     <SortedDescendingCellStyle BackColor="#EAEAD3" />
     <SortedDescendingHeaderStyle BackColor="#575357" />
 </asp:GridView>
 <br />  <asp:Panel ID="Panel1" runat="server" Width="600px" 
     ScrollBars="Vertical" >
                   
 <asp:GridView ID="grvKinhNghiem" runat="server" AutoGenerateColumns="False" 
     BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
     CellPadding="4" ForeColor="Black" GridLines="Vertical" Font-Size="13px" 
         Width="950px">
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField DataField="TuThang" HeaderText="Từ Ngày">
         <ItemStyle Width="60px" />
         </asp:BoundField>
         <asp:BoundField DataField="DenThang" HeaderText="Đến Ngày">
         <ItemStyle Width="60px" />
         </asp:BoundField>
         <asp:BoundField DataField="PhongBan" HeaderText="Phòng Ban">
         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
         </asp:BoundField>
         <asp:BoundField DataField="ViTri" HeaderText="Vị Trí">
         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
         </asp:BoundField>
         <asp:BoundField DataField="SanPham" HeaderText="Sản Phẩm">
         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
         </asp:BoundField>
         <asp:BoundField DataField="CongCu" HeaderText="Công Cụ">
         <ItemStyle Width="60px" HorizontalAlign="Center" VerticalAlign="Middle" />
         </asp:BoundField>
         <asp:BoundField HeaderText="Mô Tả" DataField="MoTa" >
         <ItemStyle Width="150px" />
         </asp:BoundField>
         <asp:BoundField DataField="Congty" HeaderText="Công Ty">
         <ItemStyle Width="150px" />
         </asp:BoundField>
     </Columns>
     <FooterStyle BackColor="#CCCC99" />
     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
     <RowStyle BackColor="#F7F7DE" />
     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
     <SortedAscendingCellStyle BackColor="#FBFBF2" />
     <SortedAscendingHeaderStyle BackColor="#848384" />
     <SortedDescendingCellStyle BackColor="#EAEAD3" />
     <SortedDescendingHeaderStyle BackColor="#575357" />
 </asp:GridView>
 </asp:Panel>
 <asp:GridView ID="grvPhongVan" runat="server" AutoGenerateColumns="False" 
     BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
     CellPadding="4" ForeColor="Black" GridLines="Vertical">
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField DataField="TT" HeaderText="STT">
         <ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Middle" />
         </asp:BoundField>
         <asp:BoundField DataField="MaKH" HeaderText="Khách Hàng">
         <ItemStyle Width="200px" />
         </asp:BoundField>
         <asp:BoundField DataField="NganhNghe" HeaderText="Ngành Nghề">
         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
         </asp:BoundField>
         <asp:BoundField DataField="Remark" HeaderText="Remark">
         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
         </asp:BoundField>
         <asp:BoundField DataField="KetQua" HeaderText="Kết Quả">
         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
         </asp:BoundField>
     </Columns>
     <FooterStyle BackColor="#CCCC99" />
     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
     <RowStyle BackColor="#F7F7DE" />
     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
     <SortedAscendingCellStyle BackColor="#FBFBF2" />
     <SortedAscendingHeaderStyle BackColor="#848384" />
     <SortedDescendingCellStyle BackColor="#EAEAD3" />
     <SortedDescendingHeaderStyle BackColor="#575357" />
 </asp:GridView>
 </form>
    </body>
</html>
