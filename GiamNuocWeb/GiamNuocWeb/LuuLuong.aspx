<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LuuLuong.aspx.cs" Inherits="GiamNuocWeb.LuuLuong" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("SANLUONG").className = "";
     window.document.getElementById("LUULUONG").className = "active";
     window.document.getElementById("APLUC").className = "";
  </script>
<section>
	<header>
		<h2>Lưu Lượng</h2>
	</header>
    <p>
<cc1:DropDownCheckBoxes ID="DropDownCheckBoxes1" runat="server"></cc1:DropDownCheckBoxes>
    </p>
</section>
</asp:Content>
