<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pUngVienDetail.aspx.cs" Inherits="WebHMI.pUngVienDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("UNGVIEN").className = "active";
     window.document.getElementById("PHONGVAN").className = "";
     window.document.getElementById("HOSOJS").className = "";
     window.document.getElementById("TRACUU").className = "";
     //       window.document.getElementById("THATTHOAT").className = "";
     //       
     //        window.document.getElementById("DOBE").className = "";
  </script>
   
  <div class="title_page"><asp:Label ID="title" runat="server" Text="THÔNG TIN ỨNG VIÊN"></asp:Label></div>
 <div class="Pages_content">
  <div class="formsearch">
		<table border="1" cellspacing="0" cellpadding="0" class="table_list" width="380px" style="text-align:left">
			
                  <tr class="head">
					<td colspan=2> THÔNG TIN ỨNG VIÊN</td>
			      </tr>
                  <tr><td colspan=2>
                  
                             <table width="100%" style="text-align:left"><tr>
                             <td rowspan="4"  style=" text-align:center;width:140px; margin-right:10px;">
                                 <span style="width:130px; text-align:center; margin-right:10px;"> <asp:Image ID="Image1" runat="server" Height="114px" Width="129px"  /></span>
                             </td>
                            <td> <table style="width:100%;"  >
                        <tr>
                            <td class="row" style="height:30px;">
                              <span style="color:Red; font-weight:bold" >                              
                                 <asp:Label ID="HoTen" runat="server" Text="Nguyễn Văn A"></asp:Label>
                              </span>
                            </td>                            
                        </tr>
                        <tr>
                            <td class="row">
                                Giới tính: <asp:Label ID="GioiTinh" runat="server" Text=""></asp:Label>
                                </td>
                            
                        </tr>
                        <tr>
                            <td class="row">
                                Ngày sinh: <asp:Label ID="NgaySinh" runat="server" Text=""></asp:Label>
                                </td>
                            
                        </tr>
                        <tr>
                            <td class="row">
                                Nơi sinh: <asp:Label ID="NoiSinh" runat="server" Text=""></asp:Label>
                                </td>
                            
                        </tr>
                        
                        <tr>
                            <td class="row">
                                Tình trạng: <span style="color:Blue; font-weight:bold" ><asp:Label ID="TinhTrang" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        
                    </table>
                                      </td>
                            </tr>
                            
                            </table>
                  
                  </td>
              </tr>
              <tr >
              <td style="width:100px">&nbsp;Nguyên Quán</td><td><asp:Label ID="NguyenQuan" runat="server" Text="fdsads"></asp:Label></td>
              </tr>
               <tr><td>&nbsp;Đ/C hiện tại</td><td>&nbsp;<asp:Label ID="ChoOht" runat="server" Text="fdsads"></asp:Label></td></tr>
               <tr><td>&nbsp;Điện Thoại</td><td>&nbsp;<asp:Label ID="DienThoai" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Di Động </td><td>&nbsp;<asp:Label ID="DiDong" runat="server" Text=""></asp:Label></td></tr>
                <tr class="head1"><td colspan="2">Chứng minh nhân dân</td></tr>
               <tr><td>&nbsp;Số CMND</td><td>&nbsp;<asp:Label ID="CMND" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Ngày Cấp </td><td>&nbsp;<asp:Label ID="cmndNgayCap" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Nơi Cấp </td><td>&nbsp;<asp:Label ID="cmndNoiCap" runat="server" Text=""></asp:Label></td></tr>
               <tr class="head1"><td colspan="2"> Hộ chiếu</td></tr>
               <tr><td>&nbsp;Số Hộ Chiếu </td><td>&nbsp;<asp:Label ID="hcSo" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Ngày Cấp HC </td><td>&nbsp;<asp:Label ID="hcNgayCap" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Nơi Cấp HC </td><td>&nbsp;<asp:Label ID="hcNoiCap" runat="server" Text=""></asp:Label></td></tr>
               <tr class="head1"><td colspan="2"> Thông tin Cá Nhân</td></tr>
               <tr><td>&nbsp;HK thường trú </td><td><asp:Label ID="hkThuongTru" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;HK tạm trú </td><td><asp:Label ID="hkTamTru" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;ĐT người thân </td><td><asp:Label ID="dtNguoiThan" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Hôn nhân </td><td><asp:Label ID="honnhan" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Sở thích </td><td><asp:Label ID="sothich" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Kỹ năng </td><td><asp:Label ID="kynang" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Ngành nghề</td><td><asp:Label ID="nganhnghe" runat="server" Text=""></asp:Label></td></tr>
              
              <tr><td colspan="2">
                  <table width="100%" style="text-align:left">
                        <tr><td class="row">Chiều Cao </td> <td class="row"><asp:Label ID="chieucao" runat="server" Text=""></asp:Label></td><td class="row">Cân Nặng</td> <td class="row"><asp:Label ID="cannang" runat="server" Text=""></asp:Label></td></tr>
                        <tr><td class="row">Nhóm Máu </td> <td class="row"><asp:Label ID="nhommau" runat="server" Text=""></asp:Label></td><td class="row">Mù Màu</td> <td class="row"><asp:Label ID="mumau" runat="server" Text=""></asp:Label></td></tr>
                        <tr><td class="row">Mắt phải</td> <td class="row"><asp:Label ID="matphai" runat="server" Text=""></asp:Label></td><td class="row">Mắt trái</td> <td class="row"><asp:Label ID="matrai" runat="server" Text=""></asp:Label></td></tr>
               </table>
              </td>
              </tr>
               <tr><td>&nbsp;Tay Thuận </td><td><asp:Label ID="taythuan" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Sức khỏe </td><td><asp:Label ID="suckhoe" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Tiền sử bệnh </td><td><asp:Label ID="tiensubenh" runat="server" Text=""></asp:Label></td></tr>
               <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckNguoiThan" runat="server" />&nbsp;Có người thân sinh sống, làm việc ở Nhật</td></tr>
               <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckDaTung" runat="server" />&nbsp;Đã từng đi Nhật làm việc, học tập, du lịch hay thăm người thân</td></tr>
               <tr><td>&nbsp;Mục đích & thời gian </td><td><asp:Label ID="MucDichThoiGian" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Cơ quan làm Hồ sơ </td><td><asp:Label ID="coquanhs" runat="server" Text=""></asp:Label></td></tr>
               <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckNhapCanh" runat="server" />&nbsp;Đã từng làm hồ sơ nhập cảnh nước ngoài</td></tr>
               <tr><td>&nbsp;Mục đích & thời gian </td><td><asp:Label ID="lamHSMucDich" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Cơ quan làm Hồ sơ </td><td><asp:Label ID="lamHSCoQuan" runat="server" Text=""></asp:Label></td></tr>
                <tr class="head2"><td colspan="2">&nbsp;<asp:CheckBox ID="ckThamGia" runat="server" />&nbsp;Đã tham dự chương trình Tu Nghiệp Sinh - Nhật ở công ty khác</td></tr>
               <tr><td>&nbsp;Cơ quan đăng ký</td><td><asp:Label ID="tNCoQuan" runat="server" Text=""></asp:Label></td></tr>
               <tr><td>&nbsp;Lý Do không tiếp tục tham gia</td><td><asp:Label ID="tNlyDo" runat="server" Text=""></asp:Label></td></tr>

               
            </table>

           
</div>
 </div>  

</asp:Content>
