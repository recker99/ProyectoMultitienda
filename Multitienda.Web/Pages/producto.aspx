<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="Multitienda.Web.Pages.producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--  Bootstrap CSS si no está en el MasterPage -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
     <link rel="stylesheet" href="~/css/estilos.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="my-4 text-center">Administrador de Productos</h2>
        
        <form>
            <div class="form-group row">
                <label for="txtIdProd" class="col-sm-2 col-form-label">ID Producto</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtIdProd" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group row">
                <label for="txtNomProd" class="col-sm-2 col-form-label">Nombre</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNomProd" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group row">
                <label for="txtDesc" class="col-sm-2 col-form-label">Descripción</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group row">
                <label for="ddlIdCat" class="col-sm-2 col-form-label">Categoría</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlIdCat" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-12 text-center">
                    <asp:Label ID="LblError" runat="server" CssClass="text-danger" />
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-12 text-center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="Button1_Click" />
                </div>
            </div>
        </form>

        <div class="table-responsive table-striped mt-4">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="idProducto"
                OnRowEditing="GridView1_RowEditing" 
                OnRowDeleting="GridView1_RowDeleting" 
                OnRowUpdating="GridView1_RowUpdating" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="idProducto" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="idCategoria" HeaderText="Categoría" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:MultitiendaConnectionString %>"
        ProviderName="<%$ ConnectionStrings:MultitiendaConnectionString.ProviderName %>"
        SelectCommand="SELECT [idProducto], [Nombre], [Descripcion], [idCategoria] FROM [Producto]">
    </asp:SqlDataSource>
</asp:Content>
