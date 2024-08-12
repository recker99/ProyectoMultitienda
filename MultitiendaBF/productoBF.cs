using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultitiendaDAL;

namespace MultitiendaBF
{
    public class productoBF
    {
        public DataSet BuscarProductoBF(int idProducto)
        {
            DataSet ds = new DataSet();
            MultitiendaDAL.productoDAL capaDatos = new MultitiendaDAL.productoDAL();
            ds = capaDatos.BuscarProductos(idProducto);
            return ds;
        }

        public DataSet ReadAllBF()
        {
            DataSet ds = new DataSet();
            MultitiendaDAL.productoDAL capaDatos = new MultitiendaDAL.productoDAL();
            ds = capaDatos.ReadAllProductos();
            return ds;
        }

        public bool CrearBF(int idProducto, string Nombre, string Descripcion, int IdCategoria)
        {
            bool transaction = false;

            MultitiendaDAL.productoDAL capaDatos = new MultitiendaDAL.productoDAL();
            transaction = capaDatos.Crear(idProducto, Nombre, Descripcion, IdCategoria);
            return transaction;

        }

        public bool EditarBF(int idProducto, string Nombre, string Descripcion, int idCategoria)
        {
            bool transaction = false;
            MultitiendaDAL.productoDAL capaDatos = new MultitiendaDAL.productoDAL();
            transaction = capaDatos.Editar(idProducto, Nombre, Descripcion, idCategoria);
            return transaction;
        }

        public bool EliminarBF(int idProducto)
        {
            bool transaction = false;

            MultitiendaDAL.productoDAL capaDatos = new MultitiendaDAL.productoDAL();
            transaction = capaDatos.Eliminar(idProducto);
            return transaction;
        }


    }
}


