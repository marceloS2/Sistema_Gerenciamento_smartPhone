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
    public partial class Clientes : Form
    {
        Functions Con;
        public Clientes()
        {
            InitializeComponent();
            Con = new Functions();
            MonstrarClientes();


        }
        private void MonstrarClientes()
        {
            string Query = "SELECT * FROM ClientesTbl"; //Fazendo uma consulta no banco
            ClienteList.DataSource = Con.GetData(Query);

        }

       
        private void SaveBtn_Click(object sender, EventArgs e) //parte  para salva no banco
        {

            if ( ClientNomeTb.Text == "" || ClientPhoneTb.Text == "" || ClientAddTb.Text == "")
            {
                MessageBox.Show("Erro ao Criar");
            }
            else
            {

                try
                {
                    string CNome = ClientNomeTb.Text;
                    string CPhone = ClientPhoneTb.Text;
                    string CAdd = ClientAddTb.Text;
                    string Query = "INSERT INTO ClientesTbl VALUES ('{0}','{1}','{2}')";
                    Query = string.Format(Query, CNome, CPhone, CAdd);
                    Con.SetData(Query);
                    MessageBox.Show("Cliente Criado!");
                    MonstrarClientes();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }


        }

        int Key = 0;
        private void ClienteList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientNomeTb.Text = ClienteList.SelectedRows[0].Cells[1].Value.ToString();
            ClientPhoneTb.Text = ClienteList.SelectedRows[0].Cells[2].Value.ToString();
            ClientAddTb.Text = ClienteList.SelectedRows[0].Cells[3].Value.ToString();
            if (ClientNomeTb.Text == "")
            {
                Key = 0;
            }
            else 
            {
                Key = Convert.ToInt32(ClienteList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e) //atualizar
        {

            if (ClientNomeTb.Text == "" || ClientPhoneTb.Text == "" || ClientAddTb.Text == "")
            {
                MessageBox.Show("Erro ao  Atualizar");
            }
            else
            {

                try
                {
                    string CNome = ClientNomeTb.Text;
                    string CPhone = ClientPhoneTb.Text;
                    string CAdd = ClientAddTb.Text;
                    string Query = "UPDATE  ClientesTbl SET ClientNome = '{0}',ClientPhone = '{1}',ClientAdd = '{2}' WHERE ClientCode = {3}";
                    Query = string.Format(Query, CNome, CPhone, CAdd,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Cliente Atualizado!!!");
                    MonstrarClientes();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }



        }
        private void Clear()
        {
            ClientNomeTb.Text = "";
            ClientPhoneTb.Text = "";
            ClientAddTb.Text = "";
            Key = 0;
        }
        private void DeleteBtn_Click(object sender, EventArgs e) //DELETAR
        {
            if (Key == 0)
            {
                MessageBox.Show("Selecione um Cliente");
            }
            else
            {

                try
                {
                  
                    string Query = "DELETE FROM ClientesTbl WHERE ClientCode = {0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Cliente Deletado!!!");
                    MonstrarClientes();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Peças Obj = new Peças();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Reparar Obj = new Reparar(); // envendo dos botoes icone celular 
            Obj.Show();
            this.Hide();
        }
    }
}
