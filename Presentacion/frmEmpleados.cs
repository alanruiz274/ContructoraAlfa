using System;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmEmpleados : Form
    {
        public Validaciones validar;
        private EmpleadoManejador empleadoManejador;
        private Empleados empleados;
        int idEmpleado;
        public frmEmpleados()
        {
            InitializeComponent();
            empleados = new Empleados();
            empleadoManejador = new EmpleadoManejador();
            validar = new Validaciones();
            BindingEmpleados();
            
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            BuscarProyectos("");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingEmpleados();
                Guardar();
                BuscarProyectos("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
        }
        private void BuscarProyectos(String filtro)
        {
            dtgEmpleados.DataSource = empleadoManejador.ObtenerProyectos(filtro);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProyectos(txtBuscar.Text);
        }
        private void dtgProyectos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingSelectEmpleado();
            BindingPasarDatos();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            BindingSelectEmpleado();
            BindingPasarDatos();
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BindingSelectEmpleado();
            if (MessageBox.Show("Estas seguro que deseas eliminar el registro", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Eliminar();
                    BuscarProyectos("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo Eliminar \n", ex.Message);
                }
            }
        }
        private void btnUbicacion_Click(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //Metodos generales para mandar llamar
        private void BindingEmpleados()
        {
            //pasamos los datos de UI alas entidades
            empleados.Nombre = txtNombre.Text;
            empleados.ApellidoPaterno = txtApellidoPaterno.Text;
            empleados.ApellidoMaterno = txtApellidoMAterno.Text;
            empleados.Telefono = txtTelefono.Text;
        }
        private void BindingSelectEmpleado()
        {
            //pasamos los datos de la celda de data grid alas entidades
            empleados.Ide = Convert.ToInt32(dtgEmpleados.CurrentRow.Cells["Idp"].Value.ToString());
            empleados.Nombre = dtgEmpleados.CurrentRow.Cells["Nombre"].Value.ToString();
            empleados.ApellidoPaterno = dtgEmpleados.CurrentRow.Cells["ApellidoPaterno"].Value.ToString();
            empleados.ApellidoMaterno = dtgEmpleados.CurrentRow.Cells["ApellidoMaterno"].Value.ToString();
            empleados.Telefono = dtgEmpleados.CurrentRow.Cells["Telefono"].Value.ToString();
        }
        private void BindingPasarDatos()
        {
            //pasamos los datos de las entidades a UI
            idEmpleado = empleados.Ide;
            txtNombre.Text = empleados.Nombre;
            txtApellidoPaterno.Text = empleados.ApellidoPaterno;
            txtApellidoMAterno.Text = empleados.ApellidoMaterno;
            txtTelefono.Text = empleados.Telefono;
        }
        private void Eliminar()
        {
            //seleccionamos el ID que vamos a eliminar
            empleados.Ide = Convert.ToInt32(dtgEmpleados.CurrentRow.Cells["Idp"].Value);
            empleadoManejador.Eliminar(empleados);
        }
        private void Guardar()
        {
            //primero validamos que los datos ingresados sean correctos
            if (validar.Letras(empleados.Nombre) && validar.Letras(empleados.ApellidoPaterno) && validar.Numero(empleados.Telefono) && validar.Letras(empleados.ApellidoMaterno))
            {
                //despues validamos si contien ID para saber si va a modificar o guardar
                if (idEmpleado > 0)
                {
                    empleadoManejador.Modificar(empleados);
                    Limpiar();
                }
                else
                {
                    empleadoManejador.Guardar(empleados);
                    Limpiar();
                }
            }
            else
                MessageBox.Show("Asegurese de que los datos ingresados sean correctos");
        }
        private void Limpiar()
        {
            //vaciamos los datos de las cajas de texto
            idEmpleado = 0;
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMAterno.Text = "";
            txtTelefono.Text = "";
        }
    }
}
