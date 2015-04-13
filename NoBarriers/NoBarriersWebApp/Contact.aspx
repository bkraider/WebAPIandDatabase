<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="NoBarriersWebApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        No Barriers<br />
        West Columbia, SC 29169<br />
        <abbr title="Phone">P:</abbr>
        412.901.5659
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@NoBarriers.com">Support@example.com</a><br />
    </address>
</asp:Content>
