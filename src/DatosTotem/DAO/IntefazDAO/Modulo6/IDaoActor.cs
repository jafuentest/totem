using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio; 

namespace DAO.IntefazDAO.Modulo6
{
    public interface IDaoActor : IDao<Entidad, bool, Entidad>
    {
        bool VerificarExistenciaActor(string nombre);
        List<Entidad> ConsultarActoresCombo(string codigoProyecto);

        List<string> ConsultarActoresXCasoDeUso(int idCasoUso);
        List<Entidad> ConsultarListarActores(string codigoProy); 
    }
}
