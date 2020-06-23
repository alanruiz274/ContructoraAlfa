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
        public void ExportarExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < grd.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }
    }
}
