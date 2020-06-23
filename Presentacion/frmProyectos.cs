using System;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmProyectos : Form
    {
        public Validaciones validar;
        private ProyectoManejador proyectoManejador;
        private Proyectos proyectos;
        int idProyecto;
        public frmProyectos()
        {
            InitializeComponent();
            proyectos = new Proyectos();
            proyectoManejador = new ProyectoManejador();
            validar = new Validaciones();
            BindingProyectos();
            
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            BuscarProyectos("");
            dtpFInicio.Format = DateTimePickerFormat.Custom;
            dtpFInicio.CustomFormat = "yyyy-MM-dd";
            dtpFFin.Format = DateTimePickerFormat.Custom;
            dtpFFin.CustomFormat = "yyyy-MM-dd";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingProyectos();
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
            dtgProyectos.DataSource = proyectoManejador.ObtenerProyectos(filtro);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProyectos(txtBuscar.Text);
        }
        private void dtgProyectos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingSelectProyecto();
            BindingPasarDatos();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            BindingSelectProyecto();
            BindingPasarDatos();
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BindingSelectProyecto();
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
            try
            {
                double latitud = Convert.ToDouble(dtgProyectos.CurrentRow.Cells["Latitud"].Value);
                double longitud = Convert.ToDouble(dtgProyectos.CurrentRow.Cells["Longitud"].Value);
                frmMapa mapa = new frmMapa(latitud, longitud);
                mapa.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //Metodos generales para mandar llamar
        private void BindingProyectos()
        {
            //pasamos los datos de UI alas entidades
            proyectos.Descripcion = txtDescripcion.Text;
            proyectos.Direccion = txtDireccion.Text;
            proyectos.Estado = cmbEstado.Text;
            proyectos.FechaInicio = dtpFInicio.Text;
            proyectos.FechaFinalizado = dtpFFin.Text;
            proyectos.Latitud = txtLatitud.Text;
            proyectos.Longitud = txtLongitud.Text;
        }
        private void BindingSelectProyecto()
        {
            //pasamos los datos de la celda de data grid alas entidades
            proyectos.Idp = Convert.ToInt32(dtgProyectos.CurrentRow.Cells["Idp"].Value.ToString());
            proyectos.Descripcion = dtgProyectos.CurrentRow.Cells["Descripcion"].Value.ToString();
            proyectos.Direccion = dtgProyectos.CurrentRow.Cells["Direccion"].Value.ToString();
            proyectos.Estado = dtgProyectos.CurrentRow.Cells["Estado"].Value.ToString();
            proyectos.FechaInicio = dtgProyectos.CurrentRow.Cells["FechaInicio"].Value.ToString();
            proyectos.FechaFinalizado = dtgProyectos.CurrentRow.Cells["FechaFinalizado"].Value.ToString();
            proyectos.Latitud = dtgProyectos.CurrentRow.Cells["Latitud"].Value.ToString();
            proyectos.Longitud = dtgProyectos.CurrentRow.Cells["Longitud"].Value.ToString();
        }
        private void BindingPasarDatos()
        {
            //pasamos los datos de las entidades a UI
            idProyecto = proyectos.Idp;
            txtDescripcion.Text = proyectos.Descripcion;
            txtDireccion.Text = proyectos.Direccion;
            cmbEstado.Text = proyectos.Estado;
            dtpFInicio.Text = proyectos.FechaInicio;
            dtpFFin.Text = proyectos.FechaFinalizado;
            txtLatitud.Text = proyectos.Latitud;
            txtLongitud.Text = proyectos.Longitud;
        }
        private void Eliminar()
        {
            //seleccionamos el ID que vamos a eliminar
            proyectos.Idp = Convert.ToInt32(dtgProyectos.CurrentRow.Cells["Idp"].Value);
            proyectoManejador.Eliminar(proyectos);
        }
        private void Guardar()
        {
            //primero validamos que los datos ingresados sean correctos
            if (validar.Letras(proyectos.Descripcion) && validar.Letras(proyectos.Direccion) && validar.Letras(proyectos.Estado)
                && validar.Vacio(proyectos.FechaInicio) && validar.Vacio(proyectos.FechaFinalizado) && validar.Numero(proyectos.Latitud) && validar.Numero(proyectos.Longitud))
            {
                //despues validamos si contien ID para saber si va a modificar o guardar
                if (idProyecto > 0)
                {
                    proyectoManejador.Modificar(proyectos);
                    Limpiar();
                }
                else
                {
                    proyectoManejador.Guardar(proyectos);
                    Limpiar();
                }
            }
            else
                MessageBox.Show("Asegurese de que los datos ingresados sean correctos");
        }
        private void Limpiar()
        {
            //vaciamos los datos de las cajas de texto
            idProyecto = 0;
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
            cmbEstado.Text = "";
            dtpFInicio.Text = "";
            dtpFFin.Text = "";
            txtLatitud.Text = "";
            txtLongitud.Text = "";
        }
    }
}
