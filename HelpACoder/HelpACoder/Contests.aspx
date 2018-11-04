<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Contests.aspx.cs" Inherits="HelpACoder.Contests" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:GridView runat="server" ID="GridView1" HeaderStyle-BackColor="Tomato"  AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Contest Name" />
                    <asp:BoundField DataField="platform" HeaderText="platform" />
                    <asp:BoundField DataField="startDate" HeaderText="Start Date" />
                    <asp:HyperLinkField Target="_blank" Text="Go to contest page" DataNavigateUrlFields="contestUrl" HeaderText="Contest Page" />
                    <asp:ImageField DataImageUrlField="imageUrl" HeaderText="Image"></asp:ImageField>                   
                    
                </Columns>

<HeaderStyle BackColor="Tomato"></HeaderStyle>
            </asp:GridView>
</asp:Content>
