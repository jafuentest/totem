using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Entidades.Modulo6;

namespace DAO.IntefazDAO.Modulo6
{
   public interface IDaoCasoDeUso:IDao<Entidad,bool,Entidad>
    {
       List<Entidad> ConsultarCasosDeUsoPorActor(Entidad actor);
       List<Entidad> ConsultarRequerimientosXCasoDeUso(int idCasoDeUso); 
    }
}
