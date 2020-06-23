using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmMaterial : Form
    {
        public Validaciones validar;
        private MaterialManejador materialManejador;
        private ProyectoManejador proyectoManejador;
        private Material material;
        int idMaterial;
        public frmMaterial()
        {
            InitializeComponent();
            material = new Material();
            materialManejador = new MaterialManejador();
            validar = new Validaciones();
            proyectoManejador = new ProyectoManejador();
            //BindingMaterial();
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            BuscarMaterial("");
            llenarProyectos("");
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "yyyy-MM-dd";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingMaterial();
                Guardar();
                BuscarMaterial("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
        }
        private void BuscarMaterial(String filtro)
        {
            dtgProyectos.DataSource = materialManejador.ObtenerProyectos(filtro);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarMaterial(txtBuscar.Text);
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
                    BuscarMaterial("");
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
            material.Proyecto = cmbProyecto.SelectedValue.ToString();
            material.Nombre = txtNombre.Text;
            material.Concepto = txtConcepto.Text;
            material.Fecha = dtpFecha.Text;
            material.Cantidad = Convert.ToDouble(txtCantidad.Text);
            material.Costo = Convert.ToDouble(txtCosto.Text);
        }
        private void BindingSelectMaterial()
        {
            //pasamos los datos de la celda de data grid alas entidades
            material.Idm = Convert.ToInt32(dtgProyectos.CurrentRow.Cells["Idm"].Value.ToString());
            material.Proyecto = dtgProyectos.CurrentRow.Cells["Proyecto"].Value.ToString();
            material.Fecha = dtgProyectos.CurrentRow.Cells["Fecha"].Value.ToString();
            material.Nombre = dtgProyectos.CurrentRow.Cells["Nombre"].Value.ToString();
            material.Concepto = dtgProyectos.CurrentRow.Cells["Concepto"].Value.ToString();
            material.Cantidad = Convert.ToDouble(dtgProyectos.CurrentRow.Cells["Cantidad"].Value);
            material.Costo = Convert.ToDouble(dtgProyectos.CurrentRow.Cells["Costo"].Value);
        }
        private void BindingPasarDatos()
        {
            //pasamos los datos de las entidades a UI

            cmbProyecto.Text = material.Proyecto;
            idMaterial = material.Idm;
            txtNombre.Text = material.Nombre;
            txtConcepto.Text = material.Concepto;
            dtpFecha.Text = material.Fecha;
            txtCantidad.Text = (material.Cantidad).ToString();
            txtCosto.Text = (material.Costo).ToString();
        }
        private void Eliminar()
        {
            //seleccionamos el ID que vamos a eliminar
            material.Idm = Convert.ToInt32(dtgProyectos.CurrentRow.Cells["Idm"].Value);
            materialManejador.Eliminar(material);
        }
        private void Guardar()
        {
            //primero validamos que los datos ingresados sean correctos
            if (validar.Vacio(material.Fecha) && validar.Letras(material.Nombre) && validar.Letras(material.Concepto)
                && validar.Numero(material.Cantidad.ToString()) && validar.Numero(material.Costo.ToString()))
            {
                //despues validamos si contien ID para saber si va a modificar o guardar
                if (idMaterial > 0)
                {
                    materialManejador.Modificar(material);
                    Limpiar();
                }
                else
                {
                    materialManejador.Guardar(material);
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
        private void Limpiar()
        {
            //vaciamos los datos de las cajas de texto
            idMaterial = 0;
            txtNombre.Text = "";
            txtConcepto.Text = "";
            cmbProyecto.Text = "";
            dtpFecha.Text = "";
            txtCantidad.Text = "";
            txtCosto.Text = "";
        }
    }
}
