<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NoBarriersWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>NO BARRIERS</h1>
        <p class="lead">This is a website to link people who need tasks to be done and donate to charity.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>List of Users</h2>
            <asp:GridView ID="gvUsers" runat="server"></asp:GridView>
        </div>
    </div>

</asp:Content>
