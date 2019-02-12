<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="allproblems.aspx.cs" Inherits="HelpACoder.allproblems" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="GridView1" HeaderStyle-BackColor="Tomato" AutoGenerateColumns="False" OnRowCommand="gridMembersList_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Problem ID" />
            <asp:BoundField DataField="title" HeaderText="Problem Title" />
            <asp:BoundField DataField="platform" HeaderText="platform" />
            <asp:HyperLinkField Text="Go to problem page" HeaderText="Problem page" DataNavigateUrlFields="problemUrl" Target="_blank" />
            <asp:ImageField DataImageUrlField="imageUrl" HeaderText="Image"></asp:ImageField>

            <asp:TemplateField HeaderText="View More">
                <ItemTemplate>
                    <asp:Button ID="btnViewmore" CommandArgument='<%# Eval("id") %>' CommandName="More" runat="server" Text="DisplayProblemInfo" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

        <HeaderStyle BackColor="Tomato"></HeaderStyle>
    </asp:GridView>
</asp:Content>
