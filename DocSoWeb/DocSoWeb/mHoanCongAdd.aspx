<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="mHoanCongAdd.aspx.cs" Inherits="WebMobile.mHoanCongAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <style>

        div.title_page {
            border-bottom: 2px solid #663300;
            color: #006600;
            font-family: Tahoma,Arial,Helvetica,sans-serif;
            font-size: 14px;
            font-weight: bold;
            text-transform: uppercase;
    }

     .style2
     {
         width: 111px;
     }
     .style3
     {
         width: 85%;
     }
     .style4
     {
         width: 2%;
         height: 20px;
     }
     .style5
     {
         width: 111px;
         height: 240px;
     }
     .style6
     {
         height: 240px;
     }
     .style7
     {
         width: 2%;
         height: 240px;
     }

 </style>
<script language="javascript" type="text/javascript">
    window.document.getElementById("HOME").className = "";
    window.document.getElementById("BAOBE").className = "";
    window.document.getElementById("HOANCONG").className = "active";
    window.document.getElementById("BAOCAO").className = "";
  </script>

<div id="map" style="width: 100%; height: 900px;">
     <script type="text/javascript">
         function removeElement(divNum) {
             var d = document.getElementById('attach_file');
             var olddiv = document.getElementById(divNum);
             d.removeChild(olddiv);
         }

         var fileFieldCount = 0;
         function addFileField() {
             if (fileFieldCount >= 9) return false
             fileFieldCount++;
             var f = document.createElement("input");
             f.id = "theFile" + fileFieldCount;
             f.type = "file";
             f.size = 120;
             f.name = "theFile" + fileFieldCount;
             p = document.getElementById("attachments_fields");
             p.appendChild(document.createElement("br"));
             p.appendChild(f);
         }
      </script>
           
      
    <table class='table_list' style="width:100%;">           

            <tr  >
                <td class="style3" colspan="3">
                    <div class="title_page">
                        THÔNG TIN ĐỂM BỂ (<asp:Label ID="lbID" runat="server"></asp:Label>)
                    </div>
                </td>
            </tr>

            <tr   >
                <td class="style12" style="width: 2%">
                    </td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; "  >
                   <asp:Label ID="Label1" runat="server" Text=" Địa Chỉ:"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="lbDiaChi" runat="server" Font-Bold="True" Font-Italic="False"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                   <asp:Label ID="Label2" runat="server" Text=" Ngày Báo Bể :"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="lbNgayBaoBe" runat="server" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lbLat" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lbLng" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 2%">
                    &nbsp;</td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="Label3" runat="server" Text="Ghi Chú :"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="lbGhiChuBB" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 2%">
                    &nbsp;</td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    Giao Sửa Bể</td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="lbNgayGiao" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="3">
                    <div class="title_page">
                        THÔNG TIN HOÀN CÔNG ĐIỂM BỂ
                    
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style41" style="width: 2%">
                    </td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="Label5" runat="server" 
                        Text="Ngày Thực Hiện :"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="dataThucHienTN" runat="server" TextMode="DateTimeLocal" /> 
                   
                </td>
            </tr>
            <tr>
                <td class="style41" style="width: 2%">
                    &nbsp;</td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    Đến Ngày</td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="dateTNden" runat="server" TextMode="DateTimeLocal" />
                </td>
            </tr>
            <tr>
                <td class="style45" style="width: 2%">
                    </td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="Label7" runat="server" 
                        Text="Ghi Chú Thực Hiện"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtGhiChuSuaBe" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 2%">
                    &nbsp;</td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="Label8" runat="server" 
                        Text="NV Sửa Bể :"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">                    <asp:TextBox ID="txtNVSua" runat="server" 
                        Height="27px" Width="343px"></asp:TextBox>
                
                 <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" Height="80px">
                    <asp:CheckBoxList ID="checkNVSua" runat="server" 
                         Font-Overline="False" Font-Strikeout="False" 
                        Height="75px" Width="283px" AutoPostBack="True" 
                         onselectedindexchanged="checkNVSua_SelectedIndexChanged">
                    </asp:CheckBoxList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 2%">
                    &nbsp;</td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="Label9" runat="server" 
                        Text="NV Giám Sát"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                                    <asp:TextBox ID="txtNVGS" runat="server" Height="27px" Width="343px"></asp:TextBox>
                
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Height="77px">
                        <asp:CheckBoxList ID="checkNVGS" runat="server" 
                         Font-Overline="False" Font-Strikeout="False" 
                        Height="74px" Width="282px" 
                            onselectedindexchanged="checkNVGS_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style50" style="width: 2%">
                    </td>
                <td class="style2" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="Label11" runat="server" 
                        Text="File Hoàn Công :"></asp:Label>
                </td>
                <td class="style3" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Button ID="Button3" runat="server" 
                        Text="Upload" onclick="btUploag" ValidationGroup="adsfdsafd" />
                    <br />
                    <asp:HiddenField ID="FilePath" runat="server" />
                    <asp:Label ID="uploadfile" runat="server" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
                <td class="style5">
                    <asp:Label ID="Label10" runat="server" 
                        Text="Hình Sửa Bể :"></asp:Label>
                    </td>
                <td class="style6">
                    <asp:Image ID="imgFile" runat="server" Height="208px" 
                        Width="349px" Visible="False" />
                    <div class="criteria_scroll">
                        <%
                    string filelis = Session["imgfile"].ToString();
                    string[] words = Regex.Split(filelis, ",");
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!words[i].Equals("")) {
                            Response.Write("<img  src=" + words[i] + " Height='100px' Width='200px' /> ");
                        }
                         
                    }
                  %>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 2%">
                    &nbsp;</td>
                <td class="style2">
                    Chọn Hình</td>
                <td class="style3">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="Button1" runat="server" 
                        Text="Upload" onclick="Button1_Click" ValidationGroup="adsfdsafd" />
                    <asp:Button ID="Button2" runat="server" 
                        Text="Clear" onclick="Button2_Click1" ValidationGroup="adsfdsafd" />
                    <asp:HiddenField ID="imagePath" runat="server" />
                    <asp:Label ID="upload" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style54" style="width: 2%">
                    </td>
                <td class="style2">
                    </td>
                <td class="style3">
                    <asp:Button ID="btSearch" runat="server" Height="30px"  Text="CẬP NHẬT" 
                        Width="115px" Font-Bold="True" Font-Names="Times New Roman" 
                        Font-Size="12pt" onclick="btSearch_Click" CssClass="button"  />
                    &nbsp;<asp:Button ID="btSearch0" runat="server" Height="30px"  Text="TRỞ LẠI" 
                        Width="115px" Font-Bold="True" Font-Names="Times New Roman" 
                        Font-Size="12pt" onclick="btTrolai" CssClass="button"  />
                    </td>
            </tr>
            <tr>
                <td class="style3" style="width: 2%">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style27">
                    <asp:Label ID="lbThanhCong" runat="server" ForeColor="Blue" Font-Bold="True" 
                        Font-Size="13pt"></asp:Label>
                    </td>
            </tr>
        </table>
</div>
</asp:Content>
