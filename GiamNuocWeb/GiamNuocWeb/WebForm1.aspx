<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GiamNuocWeb.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style type="text/css">
        .style1
        {
            width: 70px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="800px" ScrollBars="Both" 
            Width="800px">
            <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" Height="581px" Width="138px">
            </asp:GridView>
        </asp:Panel>
    
            
        
    
    </div>
    </form>
</body>
</html>






<form id="form2" runat="server">
  <!-- Preloader -->
  <div id="preloader">
    <div id="load"></div>
  </div>

  <nav class="navbar navbar-custom navbar-fixed-top top-nav-collapse" role="navigation">
    <div class="container">
      <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-main-collapse">
                    <i class="fa fa-bars"></i>
                </button>
        <a class="navbar-brand" href="#">
          <h1>DMA - TÂN HÒA</h1>
        </a>
      </div>

      <!-- Collect the nav links, forms, and other content for toggling -->
      <div class="collapse navbar-collapse navbar-right  ">
      <ul  class="nav navbar-nav">
						<li id="HOME" class="active" ><a href="Home.aspx" class="active">Home</a></li>
                      <!--  <li id="Li2"   ><a href="Home2.aspx" class="active">Add</a></li>-->
                        <li id="DHT" class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown">Quản Lý DMA <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                              <li><a href="pageDongHoTong.aspx" >Thông tin Đồng hồ DMA</a></li>
                              <li><a href="pageSanLuong.aspx">Sản Lượng</a></li>
                              <li><a href="pageLuuLuong.aspx">Lưu lượng</a></li>
                              <li><a href="pageApLuc.aspx">Áp Lực</a></li>
                              <li><a href="pageDoBeDMA.aspx">Tình Hình Dò Bể DMA</a></li>
                            </ul>
                        </li>	
                        		
                        <li id="SANLUONG" class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown">Van Bước DMA <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                              <li><a href="#">Menu 1</a></li>
                              <li><a href="#">Menu 2</a></li>
                              <li><a href="#">Menu 3</a></li>                              
                            </ul>
                        </li>			
                        <li id="THATTHOAT" class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown">Tỉ Lệ Thất Thoát <b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                  <li><a href="pageThatThoatBieuDo.aspx">Biểu đồ tỉ lệ thất thoát</a></li>
                                  <li><a href="pageThatThoatMangLuoi.aspx">Thất Thoát Mạng Lưới</a></li>
                                  <li><a href="pageThatThoatTuan.aspx">Thất Thoát DMA Theo Tuần</a></li>                                  
                                </ul>
                        </li>		                        
                        

                         <li id="DOBE" class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown">Quản lý Dò Bể<b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                  <li><a href="#">Tiếp nhận điểm bể</a></li>
                                  <li><a href="#">Thông báo & Xin phép sửa bể</a></li>
                                  <li><a href="#">Tình Hình Sửa Bể</a></li>
                                  <li><a href="#">Theo Dõi Điểm Bể</a></li>
                                  <li><a href="#">Tổng Kết Điểm Bể</a></li>                                  
                                </ul>
                        </li>		   
                        <li ><a href="pageDoBe.aspx">Dò Bể</a></li>
                      <!--     <li id="Li1" ><a href="pageLogin.aspx">Đăng nhập</a></li> -->
					</ul>

      <!--  <ul class="nav navbar-nav">
          <li id="HOME" ><a href="Home.aspx">Home</a></li>
          <li id="UNGVIEN"><a href="pUngVien.aspx">Ứng Viên</a></li>
           <li id="UNGVIENJS"><a href="#service">Ứng Viên JS</a></li>
          <li id="PHONGVAN" class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Phỏng Vấn <b class="caret"></b></a>
                    <ul class="dropdown-menu">
                      <li><a href="#">Lên Lịch</a></li>
                      <li><a href="#"> menu</a></li>
                      <li><a href="#"> menu</a></li>
                    </ul>
          </li>
           <li id="KHACHHANG"><a href="#contact">KHÁCH HÀNG</a></li>
          <li id="TRACUU"><a href="#contact">Tra Cứu</a></li>
          <li><a href="#contact">Đăng Nhập</a></li>
     
        </ul>-->
      </div>
      <!-- /.navbar-collapse -->
    </div>
    <!-- /.container -->
  </nav>

    <!-- Section: contact -->
 
    <div style="margin-top:55px;margin-left:5px; margin-right:5px;">
      <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">
       
      </asp:ContentPlaceHolder>
    </div> 


  <footer>
    <div class="container">
      <div class="row">
        <div class="col-md-12 col-lg-12">
          <div class="wow shake" data-wow-delay="0.4s">
          </div>
          <p>© Copyright 2018 - Tan Hoa Water Supply JSC. Developed by Tan Hoa's GNKDT</p>
        </div>
      </div>
    </div>
  </footer>

  </form>