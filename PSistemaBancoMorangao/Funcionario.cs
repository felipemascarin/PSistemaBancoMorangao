using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Funcionario : Pessoa
    {
        public string Matricula { get; set; }

        public Funcionario() { }

        public Funcionario(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentomensal, string cpf, string rg, string matricula)
            : base(endereco, nome, dataNasc_Registro, faturamentomensal, cpf, rg)
        {
            Matricula = matricula;
        }
    }
}
