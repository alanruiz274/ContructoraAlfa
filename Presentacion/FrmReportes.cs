using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class FrmReportes : Form
    {
        public Validaciones validar;
        private ReportesManejador reportesManejador;
        public FrmReportes()
        {
            InitializeComponent();
            reportesManejador = new ReportesManejador();
        }
        private void frmProyectos_Load(object sender, EventArgs e)
        {
            llenarProyectos();
            Ocultar();
            dtpFechaInicial.Format = DateTimePickerFormat.Custom;
            dtpFechaInicial.CustomFormat = "yyyy-MM-dd";
            dtpFechaFinal.Format = DateTimePickerFormat.Custom;
            dtpFechaFinal.CustomFormat = "yyyy-MM-dd";
            
        }
        private void cmbRangos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscar.Text == "Proyectos" && cmbRangos.Text == "Todos")
            {
                Ocultar();
                VerProyectosTodos();
            }
            if (cmbBuscar.Text == "Proyectos" && cmbRangos.Text == "Por Fechas")
            {
                Ocultar();
                VerProyectosFechas();
            }
            if (cmbBuscar.Text == "Material" && cmbRangos.Text == "Todos" || cmbBuscar.Text == "Avances" && cmbRangos.Text == "Todos")
            {
                Ocultar();
                VerMATodos();
            }
            if (cmbBuscar.Text == "Material" && cmbRangos.Text == "Por Fechas" || cmbBuscar.Text == "Avances" && cmbRangos.Text == "Por Fechas")
            {
                Ocultar();
                VerMAFechas();
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Todo();
            Limpiar();
            Ocultar();
        }
        private void Todo()
        {
            if (cmbBuscar.Text == "Proyectos" && cmbRangos.Text == "Todos" && cmbEstado.Text == "Todos")
            {
                dtgDatos.DataSource = reportesManejador.MostarPT();
            }
            if (cmbBuscar.Text == "Proyectos" && cmbRangos.Text == "Todos" && cmbEstado.SelectedIndex >= 1)
            {
                dtgDatos.DataSource = reportesManejador.MostarPTE(cmbEstado.Text);
            }
            if (cmbBuscar.Text == "Proyectos" && cmbRangos.Text == "Por Fechas" && cmbEstado.Text == "Todos")
            {
                dtgDatos.DataSource = reportesManejador.MostarPF(dtpFechaInicial.Text, dtpFechaFinal.Text);

            }
            if (cmbBuscar.Text == "Proyectos" && cmbRangos.Text == "Por Fechas" && cmbEstado.SelectedIndex >= 1)
            {
                dtgDatos.DataSource = reportesManejador.MostarPFE(cmbEstado.Text, dtpFechaInicial.Text, dtpFechaFinal.Text);
            }
            if (cmbBuscar.Text == "Material" && cmbRangos.Text == "Todos")
            {
                dtgDatos.DataSource = reportesManejador.MostarMT(cmbProyecto.SelectedValue.ToString());
            }
            if (cmbBuscar.Text == "Material" && cmbRangos.Text == "Por Fechas")
            {
                dtgDatos.DataSource = reportesManejador.MostarMTF(cmbProyecto.SelectedValue.ToString(), dtpFechaInicial.Text, dtpFechaFinal.Text);
            }
            if (cmbBuscar.Text == "Avances" && cmbRangos.Text == "Todos")
            {
                dtgDatos.DataSource = reportesManejador.MostarAT(cmbProyecto.SelectedValue.ToString());
            }
            if (cmbBuscar.Text == "Avances" && cmbRangos.Text == "Por Fechas")
            {
                dtgDatos.DataSource = reportesManejador.MostarAF(cmbProyecto.SelectedValue.ToString(), dtpFechaInicial.Text, dtpFechaFinal.Text);
            }
        }
        private void llenarProyectos()
        {
            cmbProyecto.DataSource = reportesManejador.MostarCombo();
            cmbProyecto.DisplayMember = "Descripcion";
            cmbProyecto.ValueMember = "Idp";
        }
        private void Limpiar()
        {
            //vaciamos los datos de las cajas de texto
            cmbBuscar.Text = "";
            cmbRangos.Text = "";
            cmbProyecto.Text = "";
            cmbEstado.Text = "";
        }
        private void Ocultar()
        {
            lblProyecto.Visible = false;
            cmbProyecto.Visible = false;
            lblEstado.Visible = false;
            cmbEstado.Visible = false;
            lblFechaInicial.Visible = false;
            dtpFechaInicial.Visible = false;
            lblFechaFinal.Visible = false;
            dtpFechaFinal.Visible = false;
        }
        private void VerProyectosTodos()
        {
            lblEstado.Visible = true;
            cmbEstado.Visible = true;
        }
        private void VerProyectosFechas()
        {
            lblEstado.Visible = true;
            cmbEstado.Visible = true;
            lblFechaInicial.Visible = true;
            dtpFechaInicial.Visible = true;
            lblFechaInicial.Visible = true;
            dtpFechaFinal.Visible = true;
        }
        private void VerMAFechas()
        {
            lblProyecto.Visible = true;
            cmbProyecto.Visible = true;
            lblFechaInicial.Visible = true;
            dtpFechaInicial.Visible = true;
            lblFechaInicial.Visible = true;
            dtpFechaFinal.Visible = true;
        }
        private void VerMATodos()
        {
            lblProyecto.Visible = true;
            cmbProyecto.Visible = true;
        }

       

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedIndex >= 0)
                cmbRangos.Enabled = true;
            else
                MessageBox.Show("Selecciona una Busqueda");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            reportesManejador.ExportarExcel(dtgDatos);
        }
    }
}
