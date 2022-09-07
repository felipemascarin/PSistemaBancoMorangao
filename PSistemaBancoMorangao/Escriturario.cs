using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Escriturario : Funcionario
    {
        public Escriturario() { }

        public Escriturario(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentomensal, string cpf, string rg, string matricula)
            : base(endereco, nome, dataNasc_Registro, faturamentomensal, cpf, rg, matricula) { }

        public string AtribuirTipoDeConta(PF cliente)
        {

            if(cliente.FaturamentoMensal < 1000 && cliente.FaturamentoMensal >= 0)
            {
                return "UNIVERSITARIA";
            }
            else
            {
                if (cliente.FaturamentoMensal >= 1000 && cliente.FaturamentoMensal <= 10000)
                {
                    return "NORMAL";
                }
                else
                {
                    return "VIP";
                }
            }
        }


        public override string ToString()
        {
            return "\nDADOS DO ESCRITURÁRIO: \nMatricula: " + Matricula + Endereco.ToString() + "\nNome: " + Nome +
                "\nData de nascimento: " + DataNasc_Registro.ToLongDateString() + "\nCPF: " + Cpf + "\nRG: " + Rg + "\n";
        }

    }
}
