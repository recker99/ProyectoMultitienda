<%@ Page Title="Iniocio - Multitienda" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Multitienda.Web.Pages.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenido principal -->
            <main class="main-content my-5">
                <div class="jumbotron">
                    <h1 class="text-center h1">Bienvenido a Multitienda</h1>
                    <p class=" text-center lead">Tu destino para productos de alta calidad y categorías diversas.</p>
                    <hr class="my-4">
                    <p class="text-center">Explora nuestra tienda y descubre lo que tenemos para ofrecerte.</p>
                </div>

                <!-- Sección de "Quiénes Somos" -->
                <section class="quienes-somos">
                    <h2 class="text-center">Quiénes Somos</h2>
                    <p class="text-justify">
                        En Multitienda, nos dedicamos a ofrecer una amplia gama de productos de alta calidad para satisfacer todas tus necesidades. 
                        Desde electrónica hasta moda, tenemos todo lo que buscas y más. Nos enorgullecemos de nuestra atención al cliente y 
                        nos esforzamos por brindarte la mejor experiencia de compra posible.
                    </p>
                </section>
            </main>
</asp:Content>
