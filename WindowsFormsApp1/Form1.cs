using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class FormLogin : Form
    {
        string passwordDB = "GambaBlanca80";
        bool conexion = false;
        bool cerrado = false;
        DBConnect nuevaConexion = new DBConnect();
        List<Product> listaDatos = new List<Product>();


        public FormLogin()
        {
            InitializeComponent();
            this.loadGrid();          
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wmsg, int wparam, int lparam);


        public void loadGrid()
        {
            if (nuevaConexion.getStatus() == "Open")
            {
                listaDatos = nuevaConexion.SelectSubProduct();
               
            }
            else
            {
                if (nuevaConexion.OpenConnection() == true)
                {
                    listaDatos = nuevaConexion.SelectSubProduct();
                    this.clearDataGrid();
                    int n = listaDatos.Count();   
                    int i = 0;

                    foreach (var item in listaDatos)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getName();
                        dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getSize();
                        dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getKg();
                        dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getQuantity();
                        dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getLote();
                        dataGridView1.Rows[i].Cells[5].Value = listaDatos.ElementAt(i).getInfo();

                        i++;
                    }        
                }
            }
        }

        public void conect()
        {
            conexion = nuevaConexion.OpenConnection();

        }

        private void Form1_Load(object sender, EventArgs e)
        {     
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 newProduct = new Form3();
            newProduct.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //obtiene el valor de la celda seleccionada
            //label2.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //listaDatos = nuevaConexion.SelectSubProduct(label2.Text);
            /*
            int i = 0;
            foreach (var item in listaDatos)
            {
                dataGridView1.Rows[i].Cells[0].Value = listaDatos.ElementAt(i).getName();
                dataGridView1.Rows[i].Cells[1].Value = listaDatos.ElementAt(i).getSize();
                dataGridView1.Rows[i].Cells[2].Value = listaDatos.ElementAt(i).getKg();
                dataGridView1.Rows[i].Cells[3].Value = listaDatos.ElementAt(i).getQuantity();
                dataGridView1.Rows[i].Cells[4].Value = listaDatos.ElementAt(i).getLote();
                dataGridView1.Rows[i].Cells[5].Value = listaDatos.ElementAt(i).getInfo();
                i++;
            }*/
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 35;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    ep.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DeepSkyBlue, left, top);
                    left += col.Width;

                    if (col.Index < dataGridView1.ColumnCount - 1)
                        ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dataGridView1.RowCount - 1) * DGV_ALTO);
                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == dataGridView1.RowCount - 1) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Segoe UI", 13), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DGV_ALTO;
                    ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                }
            };
            ppd.ShowDialog();
        }

        public void clearDataGrid()
        {
            dataGridView1.Rows.Clear();
        }
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.clearDataGrid();
            this.loadGrid();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //label2.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //listaDatos = nuevaConexion.SelectSubProduct(label2.Text);
        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //label2.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //listaDatos = nuevaConexion.SelectSubProduct(label2.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Form2 newPro = new Form2();

            newPro.Show();
        }

        private void buttonSalida_Click(object sender, EventArgs e)
        {
            Form4 newSalida = new Form4();
            newSalida.Show();
        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;

        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = false;
        }

        private void iconminimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112,0xf012,0);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(this.dataGridView1.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                if (Convert.ToInt32(e.Value) <= 20)
                {
                    e.CellStyle.ForeColor = Color.BlueViolet;
                    e.CellStyle.BackColor = Color.Gray;
                }
                if ( Convert.ToInt32(e.Value) <= 10)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.Orange;
                }

            }
        }
    }
}
