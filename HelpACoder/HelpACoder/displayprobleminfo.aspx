<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="displayprobleminfo.aspx.cs" Async="true" Inherits="HelpACoder.displayprobleminfo" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label12" runat="server" Text="Enter problem ID"/>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" /><br />
    <asp:Button ID="Button1" runat="server" Text="FindProblem"  OnClick="Button1_Click" /><br />
    

    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" Visible="false"/><br /><br />
   <div  style="text-align:center;">
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label><br />

    <asp:HyperLink ID="HyperLink1" runat="server" Text=" Go to problem Page" Target="_blank" Visible="false"></asp:HyperLink><br />
    <asp:Label ID="Label3" runat="server" Text="Label" Visible="false"></asp:Label><br />
    <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label><br />
    <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label><br />
    <asp:Label ID="Label6" runat="server" Text="Label" Visible="false"></asp:Label><br />
    <asp:Label ID="Label7" runat="server" Text="Label" Visible="false"></asp:Label><br />
    <asp:Label ID="Label8" runat="server" Text="Sample Input Output" Visible="false"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" Visible="false" HorizontalAlign="Center"/><br />
    <asp:Label ID="Label9" runat="server" Text="Label" Visible="false"></asp:Label><br />
    <asp:Label ID="Label10" runat="server" Text="Tags" Visible="false"></asp:Label><br />
    <asp:GridView ID="GridView2" runat="server" Visible="false" HorizontalAlign="Center"/><br />
    <asp:Label ID="Label11" runat="server" Text="Label" Visible="false"></asp:Label><br />
      
    </div>
</asp:Content>
