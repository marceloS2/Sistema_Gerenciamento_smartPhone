using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileAsist
{
    public partial class Peças : Form
    {
        Functions Con;
        public Peças()
        {
            InitializeComponent();
            Con = new Functions();
            MonstrarPeca();
        }
        private void MonstrarPeca()
        {
            string Query = "SELECT * FROM PecaTbl"; //Fazendo uma consulta no banco
            PecaList.DataSource = Con.GetData(Query);

        }
        private void Clear() 
        {

            PcNomeTb.Text = "";
            PcCustTb.Text = "";
            Key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PcNomeTb.Text == "" || PcCustTb.Text == "" )
            {
                MessageBox.Show("Erro ao Criar");
            }
            else
            {

                try
                {
                    string PcNome = PcNomeTb.Text;
                    int Cust = Convert.ToInt32(PcCustTb.Text);
                    
                    string Query = "INSERT INTO PecaTbl VALUES ('{0}','{1}')";
                    Query = string.Format(Query,PcNome,Cust );
                    Con.SetData(Query);
                    MessageBox.Show("Peça Criado!");
                    MonstrarPeca();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }


        }
        int Key = 0;
        private void PecaList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PcNomeTb.Text = PecaList.SelectedRows[0].Cells[1].Value.ToString();
            PcCustTb.Text = PecaList.SelectedRows[0].Cells[2].Value.ToString();
           
            if (PcNomeTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PecaList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e) //atualizar
        {
            if (PcNomeTb.Text == "" || PcCustTb.Text == "")
            {
                MessageBox.Show("Erro ao Criar");
            }
            else
            {

                try
                {
                    string PcNome = PcNomeTb.Text;
                    int Cust = Convert.ToInt32(PcCustTb.Text);

                    string Query = "UPDATE PecaTbl SET PcNome = '{0}', PcCust = {1} WHERE PcCode = {2}";
                    Query = string.Format(Query, PcNome, Cust, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Peça Atualizada!");
                    MonstrarPeca();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Erro ao Criar");
            }
            else
            {

                try
                {
                    string PcNome = PcNomeTb.Text;
                    int Cust = Convert.ToInt32(PcCustTb.Text);

                    string Query = "DELETE FROM PecaTbl WHERE PcCode = {0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Peça Deletada!");
                    MonstrarPeca();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Clientes Obj = new Clientes();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Reparar Obj = new Reparar(); // botão de porcentagem vai pra tela final fechar orçamento
            Obj.Show();
            this.Hide();
        }
    }
}

