using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo1
{

    public class LogicaLogin
    {
        private int intentos {
            private get {return this.intentos;}
            private set {
                if (this.intentos <=3){
                    this.intentos = value;}
            }
        }

        public LogicaLogin()
        {
            this.intentos = 0;
        }

        
        public DominioTotem.Usuario Login(string usuario, string clave)
        {
            throw new System.NotImplementedException();
        }    

        public bool RecuperacionDeClave(DominioTotem.Usuario usuario){
            throw new System.NotImplementedException();
        
        }
        public string GenerarLink()
        {
            throw new System.NotImplementedException();

        }
        public bool EnviarEmail()
        {
            throw new System.NotImplementedException();

        }
        public bool ValidarRespuestaSecreta(string respuesta)
        {
            throw new System.NotImplementedException();

        }
        public bool CambioDeClave(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();

        }
        public bool CerrarSesion()
        {
            throw new System.NotImplementedException();

        }

    }
}
