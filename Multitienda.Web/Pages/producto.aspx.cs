using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Multitienda.Web.Pages
{
    public partial class producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarGrillaProductos();
                llenarCategorias();
            }
        }

        private void llenarGrillaProductos()
        {
            MultitiendaBF.productoBF negocio = new MultitiendaBF.productoBF();
            GridView1.DataSource = negocio.ReadAllBF();
            GridView1.DataBind();
        }

        private void llenarCategorias()
        {
            MultitiendaBF.categoriaBF negocio = new MultitiendaBF.categoriaBF();
            ddlIdCat.DataSource = negocio.ReadAllCategoriasBF();
            ddlIdCat.DataValueField = "idCategoria";
            ddlIdCat.DataTextField = "Nombre";
            ddlIdCat.DataBind();
            ddlIdCat.Items.Insert(0, new ListItem("-- Seleccion --", "0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdProd.Text))
            {
                LimpiarLabelError();

                if (!string.IsNullOrEmpty(txtNomProd.Text))
                {
                    LimpiarLabelError();

                    if (!string.IsNullOrEmpty(txtDesc.Text))
                    {
                        LimpiarLabelError();

                        if (ddlIdCat.SelectedValue != "0")
                        {
                            MultitiendaBF.productoBF negocio = new MultitiendaBF.productoBF();
                            if (negocio.CrearBF(Convert.ToInt32(txtIdProd.Text), txtNomProd.Text, txtDesc.Text, Convert.ToInt32(ddlIdCat.SelectedValue)))
                            {
                                llenarGrillaProductos();
                                LimpiarLabelError();
                                LimpiarFields();
                                LblError.Text = "Se grabó el producto con éxito.";
                            }
                            else
                            {
                                LblError.Text = "No se grabó el producto.";
                            }
                        }
                        else
                        {
                            LblError.Text = "Debe seleccionar una categoría.";
                        }
                    }
                    else
                    {
                        LblError.Text = "La descripción del producto no puede estar vacía.";
                    }
                }
                else
                {
                    LblError.Text = "El nombre del producto no puede estar vacío.";
                }
            }
            else
            {
                LblError.Text = "El ID del producto no puede estar vacío.";
            }
        }

        private void LimpiarLabelError()
        {
            LblError.Text = "";
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            llenarGrillaProductos();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int idProducto = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string nombre = (row.FindControl("txtNombre") as TextBox).Text;
            string descripcion = (row.FindControl("txtDescripcion") as TextBox).Text;
            int idCategoria = Convert.ToInt32((row.FindControl("ddlCategoria") as DropDownList).SelectedValue);

            MultitiendaBF.productoBF negocio = new MultitiendaBF.productoBF();
            negocio.EditarBF(idProducto, nombre, descripcion, idCategoria);

            GridView1.EditIndex = -1;
            llenarGrillaProductos();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idProducto = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            MultitiendaBF.productoBF negocio = new MultitiendaBF.productoBF();
            negocio.EliminarBF(idProducto);

            llenarGrillaProductos();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            llenarGrillaProductos();
        }

        private void LimpiarFields()
        {
            txtIdProd.Text = "";
            txtNomProd.Text = "";
            txtDesc.Text = "";
            ddlIdCat.SelectedIndex = 0;
        }
    }
}
