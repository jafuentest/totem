using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio; 

namespace DAO.IntefazDAO.Modulo6
{
   public interface IDaoActor: IDao<Entidad,bool,Entidad>
    {
       List<Entidad> consultarListaDeActores(Entidad parametro);
    }
}
