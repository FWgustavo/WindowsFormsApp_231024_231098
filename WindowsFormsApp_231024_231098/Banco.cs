using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp_231024_231098
{
    public class Banco
    {
        public static MySqlConnection Conexao;

        public static MySqlCommand Comando;

        public static MySqlDataAdapter Adaptador;

        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=1234");

                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FecharConexao();
            }

        }
        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();

                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cidades"+
                                           "(id int auto_increment primary key, "+
                                           "nome char(40), "+
                                           "uf char(02))", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS marcas" +
                                           "(id int auto_increment primary key, " +
                                           "marca char(20)) ", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS categorias " +
                                           "(id int auto_increment primary key, " +
                                           "categoria char(20))", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS clientes" +
                                           "(id integer auto_increment primary key, " +
                                           "nome char(40), " +
                                           "idCidade integer, " +
                                           "dataNasc date, " +
                                           "renda decimal(10,2), " +
                                           "cpf char(14), " +
                                           "foto varchar(100), " +
                                           "venda boolean)", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS produtos " +
                                           "(id integer auto_increment primary key, " +
                                           "descricao char(40), " +
                                           "idCategoria integer, " +
                                           "idMarca integer, " +
                                           "estoque decimal(10,3), " +
                                           "valorVenda decimal(10,2))", Conexao);

                Comando.ExecuteNonQuery();


                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FecharConexao();
            }
        }
    }
}
