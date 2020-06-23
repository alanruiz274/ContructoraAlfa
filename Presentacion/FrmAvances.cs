using System;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class FrmAvances : Form
    {
        public Validaciones validar;
        private AvancesManejador avancesManejador;
        private ProyectoManejador proyectoManejador;
        private EmpleadoManejador empleadoManejador;
        private Avances avances;
        int idAvance;
        public FrmAvances()
        {
            InitializeComponent();
            avances = new Avances();
            avancesManejador = new AvancesManejador();
            validar = new Validaciones();
            proyectoManejador = new ProyectoManejador();
            empleadoManejador = new EmpleadoManejador();
            //BindingMaterial();
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            BuscarAvance("");
            llenarProyectos("");
            llenarEmpleados("");
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "yyyy-MM-dd";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingMaterial();
                Guardar();
                BuscarAvance("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
        }
        private void BuscarAvance(String filtro)
        {
            dtgProyectos.DataSource = avancesManejador.ObtenerAvances(filtro);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAvance(txtBuscar.Text);
        }
        private void dtgProyectos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingSelectMaterial();
            BindingPasarDatos();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            BindingSelectMaterial();
            BindingPasarDatos();
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BindingSelectMaterial();
            if (MessageBox.Show("Estas seguro que deseas eliminar el registro", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Eliminar();
                    BuscarAvance("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo Eliminar \n", ex.Message);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //Metodos generales para mandar llamar
        private void BindingMaterial()
        {
            //pasamos los datos de UI alas entidades
            avances.Proyecto = cmbProyecto.SelectedValue.ToString();
            avances.Encargado = cmbEmpleado.SelectedValue.ToString();
            avances.FechaAvance = dtpFecha.Text;
            avances.Avance = txtAvance.Text;
            avances.Metros = Convert.ToDouble(txtMetros.Text);
            avances.Pago = Convert.ToDouble(txtMetros.Text);
        }
        private void BindingSelectMaterial()
        {
            //pasamos los datos de la celda de data grid alas entidades
            avances.Ida = Convert.ToInt32(dtgProyectos.CurrentRow.Cells["Ida"].Value.ToString());
            avances.Proyecto = dtgProyectos.CurrentRow.Cells["Proyecto"].Value.ToString();
            avances.Encargado = dtgProyectos.CurrentRow.Cells["Encargado"].Value.ToString();
            avances.FechaAvance = dtgProyectos.CurrentRow.Cells["FechaAvance"].Value.ToString();
            avances.Avance = dtgProyectos.CurrentRow.Cells["Avance"].Value.ToString();
            avances.Metros = Convert.ToDouble(dtgProyectos.CurrentRow.Cells["Metros"].Value);
            avances.Pago = Convert.ToDouble(dtgProyectos.CurrentRow.Cells["Pago"].Value);
        }
        private void BindingPasarDatos()
        {
            //pasamos los datos de las entidades a UI

            cmbProyecto.Text = avances.Proyecto;
            cmbEmpleado.Text = avances.Encargado;
            idAvance = avances.Ida;
            dtpFecha.Text = avances.FechaAvance;
            txtAvance.Text = avances.Avance;
            txtMetros.Text = (avances.Metros).ToString();
            txtPago.Text = (avances.Pago).ToString();
        }
        private void Eliminar()
        {
            //seleccionamos el ID que vamos a eliminar
            avances.Ida = Convert.ToInt32(dtgProyectos.CurrentRow.Cells["Ida"].Value);
            avancesManejador.Eliminar(avances);
        }
        private void Guardar()
        {
            MessageBox.Show((avances.Proyecto + avances.Encargado + avances.FechaAvance + avances.Avance + avances.Metros.ToString() + avances.Pago.ToString()));
            //primero validamos que los datos ingresados sean correctos
            if (validar.Vacio(avances.Proyecto) && validar.Vacio(avances.Encargado) && validar.Vacio(avances.FechaAvance)
                && validar.Letras(avances.Avance)
                && validar.Numero(avances.Metros.ToString()) && validar.Numero(avances.Pago.ToString()))
            {
                //despues validamos si contien ID para saber si va a modificar o guardar
                if (idAvance > 0)
                {
                    avancesManejador.Modificar(avances);
                    Limpiar();
                }
                else
                {
                    avancesManejador.Guardar(avances);
                    Limpiar();
                }
            }
            else
                MessageBox.Show("Asegurese de que los datos ingresados sean correctos");
        }
        private void llenarProyectos(string filtro)
        {
            cmbProyecto.DataSource = proyectoManejador.ObtenerProyectosCombo(filtro);
            cmbProyecto.DisplayMember = "Descripcion";
            cmbProyecto.ValueMember = "Idp";
        }
        private void llenarEmpleados(string filtro)
        {
            cmbEmpleado.DataSource = empleadoManejador.llenarCombo(filtro);
            cmbEmpleado.DisplayMember = "Nombre";
            cmbEmpleado.ValueMember = "Ide";
        }
        private void Limpiar()
        {
            //vaciamos los datos de las cajas de texto
            idAvance = 0;
            cmbEmpleado.Text = "";
            txtPago.Text = "";
            cmbProyecto.Text = "";
            dtpFecha.Text = "";
            txtAvance.Text = "";
            txtMetros.Text = "";
        }
    }
}
