using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AuthCar2015
{
    public partial class Form_login : Form
    {
        public Form_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Variavel de Conexão//
            string connection = @"Data Source=(local);Initial Catalog=db_locadora;Persist Security Info=True;User ID=Sa;Password=pa$$word_2015";
            //Representa uma conexao aberta para um banco de dados SQL Server.
            SqlConnection cn = new SqlConnection (connection);
            //testando a conexao            
            try
                { // abre a conexao
                    cn.Open();
                }
                catch (SqlException)
                { // exebi uma mensagem caso o banco de dados não se conecte.
                MessageBox.Show("Não foi possivel ser conectar", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            //declara as string usuario e senha
            string usuario = textUsuario.Text;
            string senha = textSenha.Text;
            //*Representa uma instrução Sql ou procedimento armazenado para executar com 
            // um banco de dados do Sql//
            SqlCommand command = new SqlCommand("SELECT * FROM [tblUsuario] WHERE usuario= '" + usuario + "' AND SENHA='" + senha + "'", cn);
            //fornece uma maneira de ler um fluxo das linhas de uma base de dados.
            SqlDataReader reader = null;
                reader = command.ExecuteReader();
            //caso o usuario e a senha estejam corretas e abrindo o formulario principal.
                while (reader.Read())
                {
                    // seto a minha variavel com a Form
                    Form_Principal form_principal = new Form_Principal();
                    //oculta o form login
                    this.Hide();
                    //abre o form principal
                    form_principal.ShowDialog();
                    //encerra o projeto 
                    Application.Exit();
                }
            // caso o usuario e a senha estejam errado.
                    MessageBox.Show("Usuário não Cadastrado", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);        
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            //* fechando o formulario login *//
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             //*vamos minimizar o formulário *//
            this.WindowState = FormWindowState.Minimized;
         }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
