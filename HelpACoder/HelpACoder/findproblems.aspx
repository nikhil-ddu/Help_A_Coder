<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="findproblems.aspx.cs" Inherits="HelpACoder.findproblems" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   Enter Tag names(Separated by comma(,)) <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox><br />
    Enter platform names(Separated by comma(,)<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Find Problems" OnClick="Button1_Click"/>
    <asp:GridView runat="server" ID="GridView1" HeaderStyle-BackColor="Tomato"  AutoGenerateColumns="False" onrowcommand="gridMembersList_RowCommand" Visible="false">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Problem ID" />
                    <asp:BoundField DataField="title" HeaderText="Problem Title" />
                    <asp:BoundField DataField="platform" HeaderText="platform" />
                    <asp:HyperLinkField Text="Go to problem page" HeaderText="Problem page" DataNavigateUrlFields="problemUrl" Target="_blank" />
                    <asp:ImageField DataImageUrlField="imageUrl" HeaderText="Image"></asp:ImageField>     
                     
      <asp:TemplateField HeaderText="View More">
        <ItemTemplate>
            <asp:Button ID="btnViewmore" CommandArgument='<%# Eval("id") %>' CommandName="More" runat="server" Text="ViewProblemInfo" />
        </ItemTemplate>
        </asp:TemplateField>         
                    
                </Columns>

<HeaderStyle BackColor="Tomato"></HeaderStyle>
            </asp:GridView>
</asp:Content>
