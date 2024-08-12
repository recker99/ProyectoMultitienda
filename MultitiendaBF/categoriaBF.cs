using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultitiendaDAL;

namespace MultitiendaBF
{
    public class categoriaBF
    {
        public DataSet BuscarCategoriaBF(int IdCategoria)
        {
            DataSet ds = new DataSet();
            MultitiendaDAL.categoriaDAL capaDatos = new MultitiendaDAL.categoriaDAL();
            ds = capaDatos.BuscarCategoria(IdCategoria);
            return ds;
        }

        public DataSet ReadAllBF()
        {
            DataSet ds = new DataSet();
            MultitiendaDAL.categoriaDAL capaDatos = new MultitiendaDAL.categoriaDAL();
            ds = capaDatos.ReadAllCategoria();
            return ds;
        }

        public bool CrearBF(int IdCategoria, string nombre)
        {
            bool transaction = false;

            MultitiendaDAL.categoriaDAL capaDatos = new MultitiendaDAL.categoriaDAL();
            transaction = capaDatos.Crear(IdCategoria, nombre);
            return transaction;
        }

        public bool EditarBF(int IdCategoria, string nombre)
        {
            bool transaction = false;
            MultitiendaDAL.categoriaDAL capaDatos = new MultitiendaDAL.categoriaDAL();
            transaction = capaDatos.Editar(IdCategoria, nombre);
            return transaction;
        }

        public bool EliminarBF(int IdCategoria)
        {
            bool transaction = false;

            MultitiendaDAL.categoriaDAL capaDatos = new MultitiendaDAL.categoriaDAL();
            transaction = capaDatos.Eliminar(IdCategoria);
            return transaction;
        }

        public DataSet ReadAllCategoriasBF()
        {
            MultitiendaDAL.categoriaDAL capaDatos = new MultitiendaDAL.categoriaDAL();
            return capaDatos.ReadAllCategorias();
        }
    }
}
