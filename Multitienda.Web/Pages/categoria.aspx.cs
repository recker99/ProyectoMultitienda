using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Multitienda.Web.Pages
{
    public partial class categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarGrillaCategorias();
            }
        }

        private void llenarGrillaCategorias()
        {
            MultitiendaBF.categoriaBF negocio = new MultitiendaBF.categoriaBF();
            // Llenar el GridView
            GridView1.DataSource = negocio.ReadAllBF();
            GridView1.DataBind();
        }

        protected void btnGuardarCat_Click(object sender, EventArgs e)
        {
            if (txtIdCat.Text != "")
            {
                LimpiarLabelError();

                if (txtNom.Text != "")
                {
                    LimpiarLabelError();

                    MultitiendaBF.categoriaBF negocio = new MultitiendaBF.categoriaBF();
                    if (negocio.CrearBF(Convert.ToInt32(txtIdCat.Text), txtNom.Text))
                    {
                        llenarGrillaCategorias();
                        LimpiarLabelError();
                        LimpiarFields();
                        LblError.Text = "Se grabó la categoría con éxito.";
                    }
                    else
                    {
                        LblError.Text = "No se grabó la categoría.";
                    }
                }
                else
                {
                    LblError.Text = "El nombre de la categoría no puede estar vacío.";
                }
            }
            else
            {
                LblError.Text = "El ID de la categoría no puede estar vacío.";
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            llenarGrillaCategorias();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int idCategoria = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string nombre = (row.FindControl("txtNom") as TextBox).Text;

            MultitiendaBF.categoriaBF negocio = new MultitiendaBF.categoriaBF();
            negocio.EditarBF(idCategoria, nombre);

            GridView1.EditIndex = -1;
            llenarGrillaCategorias();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idCategoria = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            MultitiendaBF.categoriaBF negocio = new MultitiendaBF.categoriaBF();
            negocio.EliminarBF(idCategoria);

            llenarGrillaCategorias();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            llenarGrillaCategorias();
        }

        private void LimpiarLabelError()
        {
            LblError.Text = "";
        }

        private void LimpiarFields()
        {
            txtIdCat.Text = "";
            txtNom.Text = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[index];

            txtIdCat.Text = row.Cells[0].Text;
            txtNom.Text = row.Cells[1].Text;
        }

    }
}