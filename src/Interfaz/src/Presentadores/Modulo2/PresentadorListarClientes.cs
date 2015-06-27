using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Dominio;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;
using System.Web;

namespace Presentadores.Modulo2
{
    /// <summary>
    /// Presentador para la ventana Listar Clientes
    /// </summary>
    public class PresentadorListarClientes
    {
        private IContratoListarClientes vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarClientes(IContratoListarClientes laVista)
        {
            vista = laVista;
        }
        /// <summary>
        /// metodo para consultar la lista de los clientes naturales
        /// </summary>
        public void consultarClientes()
        {
            try
            {
                Comando<bool, List<Entidad>> comandoListarClientes =
                    FabricaComandos.CrearComandoConsultarTodosClienteNatural();

                List<Entidad> laLista = comandoListarClientes.Ejecutar(true);

                foreach (ClienteNatural elCliente in laLista)
                {
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_tr;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Cedula
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Nombre
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Apellido
                       + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonDetalleCliente + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonModificarCliente + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_tr;
                }


            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Metodo para consultar las variables del URL
        /// </summary>
        public void ObtenerVariablesURL()
        {
            String variable = HttpContext.Current.Request.QueryString["error"];
            if (variable != null && variable.Equals("input_malicioso"))
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
            variable = HttpContext.Current.Request.QueryString["success"];
            if (variable != null && variable.Equals("agregar"))
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Exito;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursoInterfazM2.Alerta_Cliente_Agregado +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
            else
                if (variable != null && variable.Equals("modificar"))
                {
                    vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Exito;
                    vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                    vista.alerta = RecursoInterfazM2.Alerta_Html +
                        RecursoInterfazM2.Alerta_Cliente_Modificado +
                        RecursoInterfazM2.Alerta_Html_Final;
                }
        }
    }
}
