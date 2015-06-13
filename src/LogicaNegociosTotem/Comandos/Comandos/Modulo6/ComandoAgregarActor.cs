using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio; 

namespace Comandos.Comandos.Modulo6
{
   public class ComandoAgregarActor : Comando<Entidad,bool>
    {
       /// <summary>
       /// Comando que se ejecuta para agregar un actor de caso de uso
       /// a Base de Datos, recibe el actor como parámetro y retorna
       /// true si lo insertó y false en caso contrario.
       /// </summary>
       /// <param name="parametro">Entidad de tipo Actor a insertar</param>
       /// <returns>True si la inserción fue éxitosa, false en caso
       /// contrario</returns>
       public override bool Ejecutar(Entidad parametro)
       {
           throw new NotImplementedException();
       }
    }
}
