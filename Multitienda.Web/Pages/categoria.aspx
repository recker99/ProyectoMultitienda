<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="categoria.aspx.cs" Inherits="Multitienda.Web.Pages.categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="~/css/estilos.css" />
    <!-- Bootstrap CSS si no está en el MasterPage -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="my-4 text-center">Administrador de Categorías</h2>
        
        <form>
            <div class="form-group row">
                <label for="txtIdCat" class="col-sm-2 col-form-label">ID Categoría</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtIdCat" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group row">
                <label for="txtNom" class="col-sm-2 col-form-label">Nombre</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNom" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-10 offset-sm-2">
                    <asp:Button ID="btnGuardarCat" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarCat_Click" />
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-12">
                    <asp:Label ID="LblError" runat="server" CssClass="text-danger" />
                </div>
            </div>
        </form>

        <div class="table-responsive table-striped">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="IdCategoria"
                OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="IdCategoria" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lblNom" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNom" runat="server" Text='<%# Bind("Nombre") %>' CssClass="form-control" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
