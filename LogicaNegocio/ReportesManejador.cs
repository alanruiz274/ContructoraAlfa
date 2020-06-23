using System.Collections.Generic;
using Entidades;
using AccesoDatos;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class ReportesManejador
    {
        private static ReportesAccesoDatos reportesAccesoDatos;
        public ReportesManejador()
        {
            reportesAccesoDatos = new ReportesAccesoDatos();
        }
        public List<Proyectos> MostarCombo()
        {
            var list = new List<Proyectos>();
            list = reportesAccesoDatos.MostarCombo();
            return list;
        }
        public List<Proyectos> MostarPT()
        {
            var list = new List<Proyectos>();
            list = reportesAccesoDatos.MostarPT();
            return list;
        }
        public List<Proyectos> MostarPTE(string estado)
        {
            var list = new List<Proyectos>();
            list = reportesAccesoDatos.MostarPTE(estado);
            return list;
        }
        public List<Proyectos> MostarPF(string f1, string f2)
        {
            var list = new List<Proyectos>();
            list = reportesAccesoDatos.MostarPF( f1,  f2);
            return list;
        }
        public List<Proyectos> MostarPFE(string estado, string f1, string f2)
        {
            var list = new List<Proyectos>();
            list = reportesAccesoDatos.MostarPFE( estado,  f1,  f2);
            return list;
        }
        //material
        public List<Material> MostarMT(string p)
        {
            var list = new List<Material>();
            list = reportesAccesoDatos.MostarMT( p);
            return list;
        }
        public List<Material> MostarMTF(string p, string f1, string f2)
        {
            var list = new List<Material>();
            list = reportesAccesoDatos.MostarMTF( p,  f1,  f2);
            return list;
        }
        //avances
        public List<Avances> MostarAT(string p)
        {
            var list = new List<Avances>();
            list = reportesAccesoDatos.MostarAT(p);
            return list;
        }
        public List<Avances> MostarAF(string p, string f1, string f2)
        {
            var list = new List<Avances>();
            list = reportesAccesoDatos.MostarAF( p,  f1,  f2);
            return list;
        }
        public void ExportarExcel(DataGridView tabla)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn col in tabla.Columns) // Columnas
            {
                IndiceColumna++;
                excel.Cells[1, IndiceColumna] = col.Name;
            }
            int IndeceFila = 0;
            foreach (DataGridViewRow row in tabla.Rows) // Filas
            {
                IndeceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    IndiceColumna++;
                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                }
            }
            excel.Visible = true;
        }
    }
}
