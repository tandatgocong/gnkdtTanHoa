<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageThatThoatTuan.aspx.cs" Inherits="GiamNuocWeb.pageThatThoatTuan" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.document.getElementById("THATTHOAT").className = "dropdown active";        
  </script>
  

<style>
     
      #title {
        color: #fff;
        background-color: #4d90fe;
        font-size: 25px;
        font-weight: 500;
        padding: 6px 12px;
      }
      #target {
        width: 345px;
      }
     .box {
            position:absolute;
            left:20px;
            top:100px;
            z-index:999;
   
     }
    </style>
     
    <asp:Panel ID="pTiLeThatThoat" runat="server" Width="100%" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager> 
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"
            Height="800px" ZoomMode="PageWidth">
        </rsweb:ReportViewer>
    </asp:Panel>
    
</asp:Content>
