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
    public partial class Reparar : Form
    {
        Functions Con;
        public Reparar()
        {
            InitializeComponent();
            Con = new Functions();
            MonstrarReparo();
            GetClientes();
            GetPeca();
        }
        private void GetCust()
        {
            string Query = "SELECT * FROM PecaTbl WHERE PcCode = {0}";
            Query = string.Format(Query, PeçaCb.SelectedValue.ToString());
            foreach (DataRow item in Con.GetData(Query).Rows)
            {
                PeçaCustTb.Text = item["PcCust"].ToString();
            }
            //MessageBox.Show("hello");

        }
        private void GetClientes() // inteação entre as tebale para monstra na dataTable
        {
            String Query = "SELECT * FROM ClientesTbl";
            ClientCb.DisplayMember = Con.GetData(Query).Columns["ClientNome"].ToString();
            ClientCb.ValueMember = Con.GetData(Query).Columns["ClientCode"].ToString();

            ClientCb.DataSource = Con.GetData(Query);
        }

        private void GetPeca() // interação entrea as tebelas peças
        {
            String Query = "SELECT * FROM PecaTbl";
            PeçaCb.DisplayMember = Con.GetData(Query).Columns["pcNome"].ToString();
            PeçaCb.ValueMember = Con.GetData(Query).Columns["pcCode"].ToString();


            PeçaCb.DataSource = Con.GetData(Query);


        }

        public void MonstrarReparo() // fazendo um select 
        {
            string Query = "SELECT * FROM RepararTbl";
            ReparoList.DataSource = Con.GetData(Query);


        }
        private void SalveBtn_Click(object sender, EventArgs e)
        {
            if (ClientCb.SelectedIndex == -1 || PhoneTb.Text == "" || ApNomeTb.Text == "" || ApModeloTb.Text == "" || ProblemTb.Text == "" || PeçaCb.SelectedIndex == -1 || PeçaCustTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Erro ao Criar");
            }
            else
            {

                try
                {
                    string RData = RepDataTb.Value.Date.ToString();
                    int Cliente = Convert.ToInt32(ClientCb.SelectedValue.ToString());
                    string CPhone = PhoneTb.Text;
                    string ApNome = ApNomeTb.Text;
                    string ApModelo = ApModeloTb.Text;
                    string Problem = ProblemTb.Text;
                    int peça = Convert.ToInt32(PeçaCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(PeçaCustTb.Text) + Total;


                    string Query = "INSERT INTO RepararTbl VALUES ('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, RData, Cliente, CPhone, ApNome, ApModelo, Problem, peça, GrdTotal);
                    Con.SetData(Query);
                    MessageBox.Show("Reparo Criado!");
                    MonstrarReparo();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }

        }

        private void PeçaCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

            GetCust();


        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("Selecione um reparo");
            }
            else
            {

                try
                {
                  
                    string Query = "DELETE FROM RepararTbl WHERE RepCode = {0}"; // esse numero são minha tabela
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Reparo Deletado!");
                    MonstrarReparo();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }



        }
      
        
        int Key = 0;

        private void ReparoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Key = Convert.ToInt32(ReparoList.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Peças Obj = new Peças(); //eventon botao peça um celular pequeno na lateral
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Clientes Obj = new Clientes();
            Obj.Show();
            this.Hide();
        }
    }
}



