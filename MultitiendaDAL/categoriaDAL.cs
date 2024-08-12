using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultitiendaDAL
{
    public class categoriaDAL
    {
        public DataSet BuscarCategoria(int codigo)
        {
            List<Categoria> list = new List<Categoria>();
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCategoria", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));

            MultitiendaEntities context = new MultitiendaEntities();
            list = (from Categoria in context.Categoria where Categoria.IdCategoria == codigo select Categoria).ToList();

            foreach (Categoria items in list)
            {
                DataRow row = dt.NewRow();
                row["IdCategoria"] = items.IdCategoria;
                row["nombre"] = items.nombre;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public DataSet ReadAllCategoria()
        {
            List<Categoria> list = new List<Categoria>();
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCategoria", typeof(string));
            dt.Columns.Add("nombre", typeof(string));

            MultitiendaEntities context = new MultitiendaEntities();
            list = (from Categoria in context.Categoria select Categoria).ToList();

            foreach (Categoria items in list)
            {
                DataRow row = dt.NewRow();
                row["IdCategoria"] = items.IdCategoria;
                row["nombre"] = items.nombre;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(int IdCategoria, string nombre)
        {
            bool transaction = false;
            try
            {
                MultitiendaEntities context = new MultitiendaEntities();
                Categoria objcat = new Categoria();
                objcat.IdCategoria = IdCategoria;
                objcat.nombre = nombre;
                context.Categoria.Add(objcat);
                context.SaveChanges();
                transaction = true;
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }

        public bool Editar(int IdCategoria, string nombre)
        {
            bool transaction = false;
            try
            {
                MultitiendaEntities context = new MultitiendaEntities();
                Categoria objcat = (from c in context.Categoria
                                    where c.IdCategoria == IdCategoria
                                    select c).FirstOrDefault();
                if (objcat != null)
                {
                    objcat.nombre = nombre;
                    context.SaveChanges();
                    transaction = true;
                }
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }

        public bool Eliminar(int codigo)
        {
            bool transaction = false;
            try
            {
                MultitiendaEntities context = new MultitiendaEntities();
                Categoria objcat = (from c in context.Categoria
                                    where c.IdCategoria == codigo
                                    select c).FirstOrDefault();
                if (objcat != null)
                {
                    context.Categoria.Remove(objcat);
                    context.SaveChanges();
                    transaction = true;
                }
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }

        public DataSet ReadAllCategorias()
        {
            // Crear un DataSet para almacenar los datos
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            // Definir las columnas del DataTable
            dt.Columns.Add("idCategoria", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));

            // Utilizar el contexto para acceder a la base de datos
            using (MultitiendaEntities context = new MultitiendaEntities())
            {
                // Obtener todas las categorías
                var categorias = from Categoria in context.Categoria
                                 select Categoria;

                // Agregar los datos al DataTable
                foreach (var categoria in categorias)
                {
                    DataRow row = dt.NewRow();
                    row["idCategoria"] = categoria.IdCategoria;
                    row["Nombre"] = categoria.nombre;
                    dt.Rows.Add(row);
                }
            }

            // Agregar el DataTable al DataSet
            ds.Tables.Add(dt);

            return ds;
        }
    }
}
