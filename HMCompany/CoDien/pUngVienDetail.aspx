<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pUngVienDetail.aspx.cs" Inherits="WebHMI.pUngVienDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
 <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("UNGVIEN").className = "active";
     window.document.getElementById("PHONGVAN").className = "";
     window.document.getElementById("HOSOJS").className = "";
     window.document.getElementById("TRACUU").className = "";
     //       window.document.getElementById("THATTHOAT").className = "";
     //       
     //        window.document.getElementById("DOBE").className = "";

     function get1() {
        
     }
     function get2() {
        
     }
     function get3() {
         
     }
 
</script>

  <div class="title_page"><asp:Label ID="title" runat="server" Text="THÔNG TIN ỨNG VIÊN"></asp:Label></div>
 <div class="Pages_content">
  <div class="formsearch">
   <div class="block_tab">
                        <ul  id='menu' class="tablink tablink_left">
         	                 <li id="1" >
                                  <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" ><b>Thông tin cá nhân</b></asp:LinkButton></li>         	           
                             <li id="2"><asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" ><b>Thông tin khác</b></asp:LinkButton></li>
                             <li id="3"><asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" ><b>Xuất quốc</b></asp:LinkButton></li>
                        </ul>
 <asp:Panel ID="pThongTinCaNhan" runat="server">
    <script language="javascript" type="text/javascript">
        window.document.getElementById("1").className = "current";
        window.document.getElementById("2").className = "";
        window.document.getElementById("3").className = "";
    </script>
    
	<table border="1" cellspacing="0" cellpadding="0" class="table_list" width="380px" style="text-align:left">
			
                 
                  <tr style="border-top:0px;"><td colspan="2">
                  
                             <table width="100%" style="text-align:left"><tr>
                             <td   style=" text-align:center;width:140px; margin-right:10px;">
                                 <span style="width:130px; text-align:center; margin-right:10px;"> <asp:Image ID="Image1" runat="server" Height="144px" Width="129px"  /></span>
                             </td>
                            <td> 
                                    <table style="width:100%;">
                                    <tr>
                                        <td class="row" style="height:30px;" colspan="2">
                                          <span style="color:Red; font-weight:bold" >                              
                                             <asp:TextBox ID="HoTen" runat="server" Width="100%" ></asp:TextBox>
                                          </span>
                                        </td>                            
                                    </tr>
                                    <tr>
                                        <td class="row" style="width:100px">
                                            Giới tính: </td><td class="row"> <asp:DropDownList ID="gioitinhh" runat="server" Width="70px" ></asp:DropDownList>
                                            </td>
                            
                                    </tr>
                                    <tr>
                                        <td class="row">
                                            Ngày sinh: </td><td class="row"><asp:TextBox ID="NgaySinh" runat="server" TextMode="Date" Height="25px" ></asp:TextBox>
                                            </td>
                            
                                    </tr>
                                    <tr>
                                        <td class="row">
                                            Nơi sinh:  </td><td class="row">
                                                <asp:DropDownList ID="drNoiSinh" runat="server" Width="100%" >
                                                </asp:DropDownList>
                                            </td>
                            
                                    </tr>
                        
                                    <tr>
                                        <td class="row">
                                            Tình trạng: </td><td class="row"><asp:DropDownList ID="drTinhTrang" runat="server" Width="100%" >
                                                 <asp:ListItem Value="Chưa phỏng vấn">Chưa phỏng vấn</asp:ListItem>
                                                 <asp:ListItem Value="Đã xếp phỏng vấn">Đã xếp phỏng vấn</asp:ListItem>
                                                 <asp:ListItem Value="Đã phỏng vấn">Đã phỏng vấn</asp:ListItem>
                                                 <asp:ListItem Value="Đậu phỏng vấn">Đậu phỏng vấn</asp:ListItem>
                                                 <asp:ListItem Value="Hủy">Hủy</asp:ListItem>
                                                </asp:DropDownList></td>
                                    </tr>
                        
                                         </table>
                             </td>
                            </tr>
                            
                            </table>
                  
                  </td>
              </tr>
              <tr >
              <td style="width:100px">&nbsp;Nguyên Quán</td><td><asp:DropDownList ID="drNguyenQuan" runat="server" Width="168px" ></asp:DropDownList></td>
              </tr>
               <tr><td>&nbsp;Đ/C hiện tại</td><td><asp:TextBox ID="ChoOht" runat="server" Text="" Width="100%"></asp:TextBox></td></tr>
               <tr><td>&nbsp;Điện Thoại</td><td><asp:TextBox ID="DienThoai" runat="server" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Di Động </td><td><asp:TextBox ID="DiDong" runat="server" ></asp:TextBox></td></tr>
                <tr class="head1"><td colspan="2">Chứng minh nhân dân</td></tr>
               <tr><td>&nbsp;Số CMND</td><td><asp:TextBox ID="CMND" runat="server" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Ngày Cấp </td><td><asp:TextBox ID="cmndNgayCap" runat="server" TextMode="Date" Width="168px" Height="25px" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Nơi Cấp </td><td><asp:DropDownList ID="cmndNoiCap" runat="server" Width="168px" ></asp:DropDownList></td></tr>
               <tr class="head1"><td colspan="2"> Hộ chiếu</td></tr>
               <tr><td>&nbsp;Số Hộ Chiếu </td><td><asp:TextBox ID="hcSo" runat="server" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Ngày Cấp HC </td><td><asp:TextBox ID="hcNgayCap" runat="server" TextMode="Date" Width="168px" Height="25px"></asp:TextBox></td></tr>
               <tr><td>&nbsp;Nơi Cấp HC </td><td><asp:DropDownList ID="hcNoiCapp" runat="server" Width="168px" ></asp:DropDownList></td></tr>
               <tr class="head1"><td colspan="2"> Thông tin Cá Nhân</td></tr>
               <tr><td>&nbsp;HK thường trú </td><td><asp:TextBox ID="hkThuongTru" runat="server" Width="100%"></asp:TextBox></td></tr>
               <tr><td>&nbsp;HK tạm trú </td><td><asp:TextBox ID="hkTamTru" runat="server" Width="100%"></asp:TextBox></td></tr>
               <tr><td>&nbsp;ĐT người thân </td><td><asp:TextBox ID="dtNguoiThan" runat="server" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Hôn nhân </td><td><asp:DropDownList ID="honnhann" runat="server" Width="90px" ></asp:DropDownList></td></tr>
               <tr><td>&nbsp;Sở thích </td><td><asp:TextBox ID="sothich" runat="server" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Kỹ năng </td><td><asp:TextBox ID="kynang" runat="server" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Ngành nghề</td><td><asp:TextBox ID="nganhnghe" runat="server" ></asp:TextBox></td></tr>
              
              <tr><td colspan="2">
                  <table width="100%" style="text-align:left">
                        <tr><td class="row" style="width:100px;">&nbsp;Chiều Cao </td> <td class="row"><asp:TextBox ID="chieucao" runat="server" Width="65px" TextMode="Number" ></asp:TextBox></td><td class="row" style="width:65px;">&nbsp;Cân Nặng</td> <td class="row"><asp:TextBox ID="cannang" TextMode="Number" runat="server" Width="70px"></asp:TextBox></td></tr>
                        <tr><td class="row">&nbsp;Nhóm Máu </td> <td class="row"> <asp:DropDownList ID="drNhomMau" runat="server" Width="65px" > 
                             <asp:ListItem Value="O">O</asp:ListItem>
                             <asp:ListItem Value="A">A</asp:ListItem>
                             <asp:ListItem Value="B">B</asp:ListItem>
                             <asp:ListItem Value="B">AB</asp:ListItem>
                            </asp:DropDownList></td><td class="row">&nbsp;Mù Màu</td> <td class="row"><asp:TextBox ID="mumau" runat="server" Width="70px"></asp:TextBox></td></tr>
                        <tr><td class="row">&nbsp;Mắt phải</td> <td class="row"><asp:TextBox ID="matphai" runat="server" Width="65px"></asp:TextBox></td><td class="row">&nbsp;Mắt trái</td> <td class="row"><asp:TextBox ID="matrai" runat="server" Width="70px"></asp:TextBox></td></tr>
               </table>
              </td>
              </tr>
               <tr><td>&nbsp;Tay Thuận </td><td><asp:DropDownList ID="taythuan" runat="server" Width="90px" ></asp:DropDownList></td></tr>
               <tr><td>&nbsp;Sức khỏe </td><td><asp:TextBox ID="suckhoe" runat="server" ></asp:TextBox></td></tr>
               <tr><td>&nbsp;Tiền sử bệnh </td><td><asp:TextBox ID="tiensubenh" runat="server" ></asp:TextBox></td></tr>
               <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckNguoiThan" runat="server" />&nbsp;Có người thân sinh sống, làm việc ở Nhật</td></tr>
               <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckDaTung" runat="server" />&nbsp;Đã từng đi Nhật làm việc, học tập, du lịch hay thăm người thân</td></tr>
               <tr><td>&nbsp;Mục đích & thời gian </td><td><asp:TextBox ID="MucDichThoiGian" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:TextBox></td></tr>
               <tr><td>&nbsp;Cơ quan làm Hồ sơ </td><td><asp:TextBox ID="coquanhs" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:TextBox></td></tr>
               <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckNhapCanh" runat="server" />&nbsp;Đã từng làm hồ sơ nhập cảnh nước ngoài</td></tr>
               <tr><td>&nbsp;Mục đích & thời gian </td><td><asp:TextBox ID="lamHSMucDich" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:TextBox></td></tr>
               <tr><td>&nbsp;Cơ quan làm Hồ sơ </td><td><asp:TextBox ID="lamHSCoQuan" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:TextBox></td></tr>
                <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckThamGia" runat="server" />&nbsp;Đã tham dự chương trình Tu Nghiệp Sinh - Nhật ở công ty khác</td></tr>
               <tr><td>&nbsp;Cơ quan đăng ký</td><td><asp:TextBox ID="tNCoQuan" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:TextBox></td></tr>
               <tr><td>&nbsp;Lý Do không tiếp tục tham gia</td><td><asp:TextBox ID="tNlyDo" runat="server" Width="100%" TextMode="MultiLine" Height="60px"></asp:TextBox></td></tr>
               <tr class="head3"><td colspan="2"><b><u>1.</u> Thành phần gia đình</b></td></tr>
               <tr class="head2">
               <td colspan="2">
                  <div style='overflow-x:scroll;overflow-y:hidden;width:440px'>
                    <div style='width:600px;'>
                <asp:GridView ID="grvGiaDinh" runat="server" AutoGenerateColumns="False" Font-Size="13px" Width="100%"
                     BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                     CellPadding="4" ForeColor="Black" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                         <asp:BoundField DataField="TenDM" HeaderText="Quan Hệ">
                         <ItemStyle Width="60px" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                 </div>
                 </div>
               </td>
               </tr>
               <tr class="head3"><td colspan="2"><b><u>2.</u> Quá trình học vấn</b></td></tr>
               <tr class="head2">
               <td colspan="2">
                  <div style='overflow-x:scroll;overflow-y:hidden;width:440px'>
                    <div style='width:600px;'>
                   <asp:GridView ID="grvHocVan" runat="server" AutoGenerateColumns="False" Font-Size="13px"
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
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="TT" HeaderText="Tốt Nghiệp">
                         <ItemStyle Width="60px" HorizontalAlign="Center" VerticalAlign="Middle" />
                         </asp:BoundField>
                         <asp:BoundField DataField="KhoaID" HeaderText="Khoa">
                         <ItemStyle Width="140px" />
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
                     </div>
                     </div>
               </td>
               </tr>
               <tr class="head3"><td colspan="2"><b><u>3.</u> Bằng cấp, chứng chỉ</b></td></tr>
               <tr class="head2">
               <td colspan="2">
                  <div style='overflow-x:scroll;overflow-y:hidden;width:440px'>
                    <div style='width:800px;'>
                 <asp:GridView ID="grvCHUNGCHI" runat="server" AutoGenerateColumns="False" Font-Size="13px"
                         BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                         CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:BoundField DataField="ThangNam" HeaderText="Tháng Năm">
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
                     </div>
                     </div>
               </td>
               </tr>
               <tr class="head3"><td colspan="2"><b><u>4.</u> Kinh nghiệm làm việc</b></td></tr>
               <tr class="head2">
               <td colspan="2">
                <div style='overflow-x:scroll;overflow-y:hidden;width:440px'>
                    <div style='width:800px;'>
                <asp:GridView ID="grvKinhNghiem" runat="server" AutoGenerateColumns="False" Font-Size="13px"
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
                         <asp:BoundField DataField="PhongBan" HeaderText="Phòng Ban">
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="ViTri" HeaderText="Vị Trí">
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="SanPham" HeaderText="Sản Phẩm">
                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="CongCu" HeaderText="Công Cụ">
                         <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                         </asp:BoundField>
                         <asp:BoundField HeaderText="Mô Tả" DataField="MoTa" >
                         <ItemStyle Width="250px" />
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
              </div>
                  </div>
               </td>
               </tr>
               <tr class="head3"><td colspan="2"><b><u>5.</u> Quá trình phỏng vấn</b></td></tr>
               <tr class="head2">
               <td colspan="2">
                 <div style='overflow-x:scroll;overflow-y:hidden;width:440px'>
                    <div style='width:800px;'>
                          <asp:GridView ID="grvPhongVan" runat="server" AutoGenerateColumns="False" Font-Size="13px"
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
                    </div>
                    </div>
               </td>
               </tr>
            </table>

</asp:Panel>   
 <asp:Panel ID="pThongTinKhac" runat="server" Visible="false">
    <script language="javascript" type="text/javascript">
        window.document.getElementById("1").className = "";
        window.document.getElementById("2").className = "current";
        window.document.getElementById("3").className = "";
    </script>
</asp:Panel>

 <asp:Panel ID="pXuatQuoc" runat="server" Visible="false">
    <script language="javascript" type="text/javascript">        window.document.getElementById("1").className = "";
        window.document.getElementById("2").className = "";
        window.document.getElementById("3").className = "current";
    </script>
</asp:Panel>
</div>
 </div>  

</asp:Content>
