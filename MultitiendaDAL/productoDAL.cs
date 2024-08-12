using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultitiendaDAL
{
    public class productoDAL
    {
        public DataSet BuscarProductos(int idProducto)
        {
            List<Producto> list = new List<Producto>();
            DataTable dt = new DataTable();
            dt.Columns.Add("idProducto", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("idCategoria", typeof(string));

            MultitiendaEntities context = new MultitiendaEntities();
            list = (from Producto in context.Producto where Producto.idProducto == idProducto select Producto).ToList();

            foreach (Producto items in list)
            {
                DataRow row = dt.NewRow();
                row["idProducto"] = items.idProducto;
                row["Nombre"] = items.Nombre;
                row["Descripcion"] = items.Descripcion;
                row["idCategoria"] = items.idCategoria;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public DataSet ReadAllProductos()
        {
            List<Producto> list = new List<Producto>();
            DataTable dt = new DataTable();
            dt.Columns.Add("idProducto", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("idCategoria", typeof(string));

            MultitiendaEntities context = new MultitiendaEntities();
            list = (from Producto in context.Producto select Producto).ToList();

            foreach(Producto items in list)
            {
                DataRow row = dt.NewRow();
                row["idProducto"] = items.idProducto;
                row["Nombre"] = items.Nombre;
                row["Descripcion"] = items.Descripcion;
                row["idCategoria"] = items.idCategoria;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(int idProducto, string Nombre, string Descripcion, int idCategoria)
        {
            bool transaction = false;
            try
            {
                MultitiendaEntities context = new MultitiendaEntities();
                Producto objprod = new Producto();
                objprod.idProducto = idProducto;
                objprod.Nombre = Nombre;
                objprod.Descripcion = Descripcion;
                objprod.idCategoria = idCategoria;
                context.Producto.Add(objprod);
                context.SaveChanges();
                transaction = true;

            }
            catch (Exception ex)
            {
                transaction = false;
                
            }
            return transaction;
        }

        public bool Editar(int idProducto, string Nombre, string Descripcion, int idCategoria)
        {
            bool transaction = false;

            MultitiendaDAL.productoDAL capaDatos = new MultitiendaDAL.productoDAL();
            transaction = capaDatos.Editar(idProducto, Nombre, Descripcion, idCategoria);
            return transaction;
        }

        public bool Eliminar(int idProducto)
        {
            bool transaction = false;
            try
            {
                MultitiendaEntities context = new MultitiendaEntities();
                Producto producto = context.Producto.FirstOrDefault(p => p.idProducto == idProducto);
                if (producto != null)
                {
                    context.Producto.Remove(producto);
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

    }
}
