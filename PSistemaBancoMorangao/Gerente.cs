using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Gerente : Funcionario
    {
        public Gerente() { }

        public Gerente(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentomensal, string cpf, string rg, string matricula)
            : base(endereco, nome, dataNasc_Registro, faturamentomensal, cpf, rg, matricula) { }

        
        public override string ToString()
        {
            return "\nDADOS DO GERENTE: \nMatricula: " + Matricula + Endereco.ToString() + "\nNome: " + Nome +
                "\nData de nascimento: " + DataNasc_Registro.ToLongDateString() + "\nCPF: " + Cpf + "\nRG: " + Rg + "\n";
        }

        
        public bool AprovarConta(string tipodeconta, Pessoa pessoa)
        {
            if (pessoa.FaturamentoMensal <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AprovarEmprestimo(float valorparcelado, float faturamentomensal)
        {
            if ((faturamentomensal * 0.5) > valorparcelado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
