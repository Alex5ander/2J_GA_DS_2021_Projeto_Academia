﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoAcademia
{
    public partial class FormCadastroAluno : Form
    {
        internal Aluno Registro { get; set; }
        public FormCadastroAluno()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if(Registro == null) novo();
            else editar();
            this.Dispose();
        }

        private void novo()
        {
            AlunoDB tabela = new AlunoDB();
            Registro = new Aluno()
            {
                Codigo = Int64.Parse(txtNumeroMatricula.Text),
                Nome = txtNomeAluno.Text.ToUpper(),
                Idade = Int16.Parse(txtIdadeAluno.Text),
                Peso = Double.Parse(txtPesoAluno.Text),
                Altura = Double.Parse(txtAlturaAluno.Text),
            };
            tabela.inserir(Registro);
            MessageBox.Show("Mátricula efetuada com sucesso!");
        }

        private void editar()
        {
            AlunoDB tabela = new AlunoDB();
            Registro = new Aluno()
            {
                Nome = txtNomeAluno.Text.ToUpper(),
                Idade = Int16.Parse(txtIdadeAluno.Text),
                Peso = Convert.ToDouble(txtPesoAluno.Text),
                Altura = Convert.ToDouble(txtAlturaAluno.Text),
            };
            tabela.editar(Registro);
            MessageBox.Show("Mátricula alterada");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Registro = null;
            this.Dispose();
        }
    }
}
