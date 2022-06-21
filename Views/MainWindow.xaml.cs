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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Pds_Escola_AprendeMaisSoft.Models;
using Pds_Escola_AprendeMaisSoft.Helpers;

namespace Pds_Escola_AprendeMaisSoft
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private Escola _escola = new Escola();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += EscolaMainWindow_Loaded;
        }

        public MainWindow(Escola escola)
        {
            InitializeComponent();
            Loaded += EscolaMainWindow_Loaded;

            _escola = escola;

        }

        private void EscolaMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtNome.Text = _escola.NomeFantasia;
            txtRazao.Text = _escola.RazaoSocial;
            txtCnpj.Text = _escola.Cnpj;
            txtInscricao.Text = _escola.InscEstadual;
            txtResponsavel.Text = _escola.Responsavel;
            txtTelResp.Text = _escola.ResponsavelTelefone;
            txtEmail.Text = _escola.Email;
            txtTelefone.Text = _escola.Telefone;
            txtRua.Text = _escola.Rua;
            txtNumero.Text = _escola.Numero;
            txtBairro.Text = _escola.Bairro;
            txtComp.Text = _escola.Complemento;
            txtCep.Text = _escola.Cep;
            txtCidade.Text = _escola.Cidade;
            txtEstado.Text = _escola.Estado;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _escola.NomeFantasia = txtNome.Text;
                _escola.RazaoSocial = txtRazao.Text;
                _escola.Cnpj = txtCnpj.Text;
                _escola.InscEstadual = txtInscricao.Text;
                _escola.DataCriacao = dtCriacao.SelectedDate;
                _escola.Responsavel = txtResponsavel.Text;
                _escola.ResponsavelTelefone = txtTelResp.Text;
                _escola.Telefone = txtTelefone.Text;
                _escola.Email = txtEmail.Text;
                _escola.Rua = txtRua.Text;
                _escola.Numero = txtNumero.Text;
                _escola.Bairro = txtBairro.Text;
                _escola.Complemento = txtComp.Text;
                _escola.Cidade = txtCidade.Text;
                _escola.Estado = txtEstado.Text;
                _escola.Cep = txtCep.Text;
                _escola.Tipo = "Pública";

                if ((bool)rdPrivada.IsChecked)
                    _escola.Tipo = "Privada";

                try
                {
                    var dao = new EscolaDAO();

                    if (_escola.Id > 0)
                        dao.Update(_escola);
                    else
                        dao.Insert(_escola);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                MessageBox.Show("Escola Cadastrada com Sucesso!","Cadastro Concluido", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja cadastrar um nova escola?", "Cadastro Escola!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                //continuar cadastro de escola
                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void ClearInputs()
        {
            txtNome.Text = "";
            txtRazao.Text = "";
            txtCnpj.Text = "";
            txtInscricao.Text = "";
            txtResponsavel.Text = "" ;
            txtTelResp.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtRua.Text= "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtComp.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtCep.Text = "";
        }
    }
}
