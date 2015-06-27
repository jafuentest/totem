using Contratos.Modulo7;
using Presentadores.Modulo7;
using System;
using System.Data;

namespace Vista.Modulo7
{
	public partial class ModificarUsuario : System.Web.UI.Page, IContratoModificarUsuario
	{
		private PresentadorModificarUsuario presentador;

		public ModificarUsuario()
		{
			this.presentador = new PresentadorModificarUsuario(this);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.Master.idModulo = "7";
				this.Master.presentador.CargarMenuLateral();
				presentador.CargarDatos();
				//presentador.ObtenerCargos();
				//presentador.ObtenerRoles();
			}
		}

		#region Contratos
		public string Nombre
		{
			get { return this.nombre.Value; }
			set { this.nombre.Value = value; }
		}

		public string Apellido
		{
			get { return this.apellido.Value; }
			set { this.apellido.Value = value; }
		}

		public string Username
		{
			get { return username.Value; }
			set { this.username.Value = value; }
		}

		public string Correo
		{
			get { return correo.Value; }
			set { this.correo.Value = value; }
		}

		public string Clave
		{
			get { return clave.Value; }
			set { this.clave.Value = value; }
		}

		public string ConfirmarClave
		{
			get { return confirmarClave.Value; }
			set { this.confirmarClave.Value = value; }
		}

		public string Rol
		{
			get { return rol.Value; }
			set { this.rol.Value = value; }
		}

		public string Cargo
		{
			get { return cargo.Value; }
			set { this.cargo.Value = value; }
		}

		public string Pregunta
		{
			get { return pregunta.Value; }
			set { this.pregunta.Value = value; }
		}

		public string Respuesta
		{
			get { return respuesta.Value; }
			set { this.respuesta.Value = value; }
		}

		public DataSet Roles
		{
			get { return (DataSet)rol.DataSource; }
			set
			{
				this.rol.DataSource = value;
				this.rol.DataTextField = "nombre";
				this.rol.DataValueField = "id";
				this.rol.DataBind();
			}
		}

		public DataSet Cargos
		{
			get { return (DataSet)cargo.DataSource; }
			set
			{
				this.cargo.DataSource = value;
				this.cargo.DataTextField = "nombre";
				this.cargo.DataValueField = "id";
				this.cargo.DataBind();
			}
		}
		#endregion
	}
}