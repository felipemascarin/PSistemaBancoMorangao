using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Pessoa
    {
        public Endereco Endereco { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc_Registro { get; set; }
        public float FaturamentoMensal { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public Pessoa() { }

        public Pessoa(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentoMensal, string cpf, string rg)
        {
            Endereco = endereco;
            Nome = nome;
            DataNasc_Registro = dataNasc_Registro;
            FaturamentoMensal = faturamentoMensal;
            Cpf = cpf;
            Rg = rg;
        }

        public Pessoa(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentoMensal)
        {
            Endereco = endereco;
            Nome = nome;
            DataNasc_Registro = dataNasc_Registro;
            FaturamentoMensal = faturamentoMensal;
            Cpf = null;
            Rg = null;
        }
    }
}
