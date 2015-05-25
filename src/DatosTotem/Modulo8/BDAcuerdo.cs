using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DatosTotem.Modulo8
{
    /// <summary>
    /// Clase para el gestionamiento de los acuerdos establecidos y tratados en las Minutas
    /// de los proyectos
    /// </summary>
    public class BDAcuerdo
    {
        public List<Acuerdo> ConsultarAcuerdoBD(int idMinuta)
        {
            List<Acuerdo> listaAcuerdo = new List<Acuerdo>();

            return listaAcuerdo;
        }
        
        public Contacto ObtenerObjetoUsarioBD(SqlDataReader BDContacto)
        {
            Contacto contacto = new Contacto();

            try
            {
                contacto.Con_Id = int.Parse(BDContacto[RecursosBDModulo8.AtributoIDContacto].ToString());
                contacto.Con_Nombre = BDContacto[RecursosBDModulo8.AtributoNombreContacto].ToString();
                contacto.Con_Apellido = BDContacto[RecursosBDModulo8.AtributoApellidoContacto].ToString();

                BDContacto.Close();
                return contacto;
            }

            catch (Exception ex)
            {

                throw ex;

            }
        }
        public Usuario ObtenerObjetoContactoBD(SqlDataReader BDUsuario)
        {
            Usuario usuario = new Usuario();

            try
            {
                usuario.clave = BDUsuario[RecursosBDModulo8.AtributoIDUsuario].ToString();
                usuario.nombre = BDUsuario[RecursosBDModulo8.AtributoNombreUsuario].ToString();
                usuario.apellido = BDUsuario[RecursosBDModulo8.AtributoApellidoUsuario].ToString();

                BDUsuario.Close();
                return usuario;
            }

            catch (Exception ex)
            {

                throw ex;

            }
        }

       
        
    }
}
