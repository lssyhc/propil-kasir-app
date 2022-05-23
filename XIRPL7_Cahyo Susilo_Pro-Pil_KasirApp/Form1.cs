using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace XIRPL7_Cahyo_Susilo_Pro_Pil_KasirApp
{
    public partial class Form1 : Form
    {
        SqlConnection co = new SqlConnection("Server = LAPTOP-B3524FDF; Database = DBKasir; integrated security = true;");
        SqlCommand myCommand = new SqlCommand();
        SqlDataAdapter myAdapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
            bersihkan();
            readData();
        }

        

        void bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "";
        }

        void readData()
        {
            try
            {
                myCommand.Connection = co;
                myAdapter.SelectCommand = myCommand;
                myCommand.CommandText = "SELECT * FROM Table_Barang";
                DataSet ds = new DataSet();

                if (myAdapter.Fill(ds, "Table_Barang") > 0)
                {
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Table_Barang";
                }
                co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Masukkan data terlebih dahulu");
            }
            else
            {
                try
                {
                    myCommand.Connection = co;
                    myAdapter.SelectCommand = myCommand;
                    myCommand.CommandText = "INSERT INTO Table_Barang VALUES('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"', '"+textBox5.Text+"', '"+textBox6.Text+"')";
                    DataSet ds = new DataSet();

                    if (myAdapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Data berhasil diinput");
                        readData();
                        bersihkan();
                    co.Close();
                }catch(Exception)
                {
                    MessageBox.Show("Data gagal diinput");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
                textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
                textBox3.Text = row.Cells["HargaJual"].Value.ToString();
                textBox4.Text = row.Cells["HargaBeli"].Value.ToString();
                textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
                textBox6.Text = row.Cells["SatuanBarang"].Value.ToString();
            }catch(Exception)
            {
                MessageBox.Show("Data gagal ditampilkan");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Masukkan data terlebih dahulu");
            }
            else
            {
                try
                {
                    myCommand.Connection = co;
                    myAdapter.SelectCommand = myCommand;
                    myCommand.CommandText = "UPDATE Table_Barang SET KodeBarang = '"+textBox1.Text+"', NamaBarang = '"+textBox2.Text+"', HargaJual = '"+textBox3.Text+"', HargaBeli = '"+textBox4.Text+"', JumlahBarang = '"+textBox5.Text+"', SatuanBarang = '"+textBox6.Text+ "' WHERE KodeBarang = '" + textBox1.Text + "'";
                    DataSet ds = new DataSet();

                    if (myAdapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Data berhasil diubah");
                        readData();
                        bersihkan();
                    co.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Data gagal diubah");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus "+textBox2.Text+"?", "Hapus data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    myCommand.Connection = co;
                    myAdapter.SelectCommand = myCommand;
                    myCommand.CommandText = "DELETE FROM Table_Barang WHERE KodeBarang = '"+textBox1.Text+"'";
                    DataSet ds = new DataSet();

                    if (myAdapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Data berhasil dihapus");
                        readData();
                        bersihkan();
                    co.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Data gagal dihapus");
                }
            }
            else
            {
                MessageBox.Show("Data batal dihapus");
            }
        }
    }
}
