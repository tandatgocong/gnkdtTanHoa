<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pUngVien.aspx.cs" Inherits="WebHMI.pUngVien" %>
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
  <div  style="margin-top:45px;"
  <div class="title_page"><asp:Label ID="title" runat="server" Text="THÔNG TIN ỨNG VIÊN"></asp:Label></div>
  
  </div>
</asp:Content>
