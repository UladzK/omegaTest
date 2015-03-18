<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestTask_Vladimir._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>           
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="Content/custom/Default.css" rel="stylesheet" />    
    <script src="Scripts/Custom/Default.js"></script>    

    <h3>Enter text:</h3>        
    <div id="words" class="wordsContainer" runat="server">
        <textarea id="wordsArea" rows="5" cols="3" class="langBox"></textarea>  
    </div>     
    
    <asp:Label ID="Label1" runat="server" Text="" Visible="False"></asp:Label>
</asp:Content>
