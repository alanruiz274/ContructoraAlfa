using System;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmEmpleados : Form
    {
        public Validaciones validar;
        private EmpleadoManejador empleadosManejador;
        private Empleados empleados;
        int idEmpleado;
        public frmEmpleados()
        {
            InitializeComponent();
            empleados = new Empleados();
            empleadosManejador = new EmpleadoManejador();
            validar = new Validaciones();
            BindingEmpleados();
            
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            BuscarEmpleados("");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingEmpleados();
                Guardar();
                BuscarEmpleados("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
        }
        private void BuscarEmpleados(String filtro)
        {
            dtgEmpleados.DataSource = empleadosManejador.ObtenerEmpleados(filtro);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEmpleados(txtBuscar.Text);
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
                    BuscarEmpleados("");
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
            empleados.Ide = Convert.ToInt32(dtgEmpleados.CurrentRow.Cells["Ide"].Value);
            empleadosManejador.Eliminar(empleados);
        }
        private void Guardar()
        {
            //primero validamos que los datos ingresados sean correctos
            if (validar.Letras(empleados.Nombre) && validar.Letras(empleados.ApellidoPaterno) && validar.Numero(empleados.Telefono) && validar.Letras(empleados.ApellidoMaterno))
            {
                //despues validamos si contien ID para saber si va a modificar o guardar
                if (idEmpleado > 0)
                {
                    empleadosManejador.Modificar(empleados);
                    Limpiar();
                }
                else
                {
                    empleadosManejador.Guardar(empleados);
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
