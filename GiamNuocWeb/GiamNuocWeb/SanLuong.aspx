<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SanLuong.aspx.cs" Inherits="GiamNuocWeb.SanLuong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("SANLUONG").className = "active";
     window.document.getElementById("LUULUONG").className = "";
     window.document.getElementById("APLUC").className = "";

  </script>
<!--<section>
	<header>
		<h2>Sản Lượng</h2>
	</header>
 
    fdsafd

</section>-->
<div class="title_page"><asp:Label ID="title" runat="server" Text="Sản Lượng "></asp:Label></div>


</asp:Content>
