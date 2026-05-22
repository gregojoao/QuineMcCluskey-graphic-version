using QuineMcCluskey_GraficoC.Application;
using QuineMcCluskey_GraficoC.Domain;
using QuineMcCluskey_GraficoC.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QuineMcCluskey_GraficoC.View
{
    public partial class TelaPrincipal : Form
    {
        private string caminhoArquivo = "";

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void btnEscolherTXT_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoArquivo = openFileDialog.FileName;
                using var readerArquivo = new StreamReader(caminhoArquivo);
                txtSOP.Text = readerArquivo.ReadToEnd();
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            // Carrega todos os Mintermos e Don't Cares do arquivo TXT
            List<Mintermo> ColunaMintermos = KarnaughMapApplicationService.CarregarMintermosSoap(txtSOP.Text);

            // Executa o Método responsável pelo Quine McCluskey
            QuineMcCluskey Quine = new QuineMcCluskey(KarnaughMapApplicationService.numeroVariaveis);
            txtLog.Text = Quine.Executa(ColunaMintermos);
        }
    }
}
