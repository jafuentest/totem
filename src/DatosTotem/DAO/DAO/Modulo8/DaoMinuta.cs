using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Data;

namespace DAO.DAO.Modulo8
{
    public class DaoMinuta : DAO, IntefazDAO.Modulo8.IDaoMinuta
    {
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }

}