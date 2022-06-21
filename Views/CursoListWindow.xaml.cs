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
using Pds_Escola_AprendeMaisSoft.Models;
using Pds_Escola_AprendeMaisSoft.Views;

namespace Pds_Escola_AprendeMaisSoft.Views
{
    /// <summary>
    /// Lógica interna para CursoListWindow.xaml
    /// </summary>
    public partial class CursoListWindow : Window
    {
        public CursoListWindow()
        {
            InitializeComponent();
            CarregarLista();
        }
     
        private void CarregarLista()
        {
            try
            {
                var dao = new CursoDAO();
                List<Curso> listaCurso = dao.List();

                dataGridCursos.ItemsSource = listaCurso;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var cursosSelecionados = dataGridCursos.SelectedItem as Curso;

            var curso = new CursoListWindow();
            curso.ShowDialog();



        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelecionado = dataGridCursos.SelectedItem as Curso;

            var resultado = MessageBox.Show($"Deseja realmente excluir este Curso?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao= new CursoDAO();
                    dao.Delete(cursoSelecionado);

                    MessageBox.Show("Registro removido com sucesso.");
                    CarregarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
