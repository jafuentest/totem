using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.IntefazDAO
{
    public interface IDao<Parametro, Resultado1, Resultado2>
    {
        Resultado1 Agregar(Parametro parametro);
        Resultado1 Modificar(Parametro parametro);
        Resultado2 ConsultarXId(Parametro parametro);
        List<Resultado2> ConsultarTodos();	
    }
}
