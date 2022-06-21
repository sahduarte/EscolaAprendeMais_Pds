using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Pds_Escola_AprendeMaisSoft.Models;

namespace Pds_Escola_AprendeMaisSoft.Views
{
    /// <summary>
    /// Lógica interna para CursoWindow.xaml
    /// </summary>
    public partial class CursoWindow : Window
    {
        private Curso _curso = new Curso();

        public CursoWindow()
        {
            InitializeComponent();
            Loaded += CursoWindow_Loaded;

        } 
        public CursoWindow(Curso curso)
        {

            InitializeComponent();
            Loaded += CursoWindow_Loaded;

            _curso = curso;
        }

        

        private void CursoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeCurso.Text = _curso.Nome;
            txtCarga.Text = _curso.Carga;
            txtDescricao.Text = _curso.Descricao;
            CbTurno.Text = _curso.Turno;

        }
        

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var curso = new Models.Curso();

                curso.Nome = txtNomeCurso.Text;
                curso.Carga  = txtCarga.Text;
                curso.Descricao = txtDescricao.Text;
                curso.Turno = CbTurno.Text;

                var InserirDados = new Models.CursoDAO();
                InserirDados.InserirDados(curso);


                MessageBox.Show("Curso Cadastrado com Sucesso!", "Cadastro Concluido", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja cadastrar um novo curso?", "Cadastro Curso!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                //continuar cadastro de curso
                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void ClearInputs()
        {
            txtNomeCurso.Text = "";
            txtCarga.Text = "";
            txtDescricao.Text = "";
            CbTurno.Text = "";
        }
    }
}
