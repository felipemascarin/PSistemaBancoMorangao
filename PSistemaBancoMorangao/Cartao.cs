using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Cartao
    {
        public bool FuncaoCredito { get; set; }
        public bool FuncaoDebito { get; set; }
        public float Fatura { get; set; }
        public float Limite { get; set; }
        public string Senha { get; set; }
        public string NrCartao { get; set; }
        public string CodVerificacao { get; set; }
        public DateTime DataValidade { get; set; }
        public List<string> Extrato { get; set; }

        public Cartao(bool funcaoCredito, bool funcaoDebito, float fatura, float limite, string senha, string nrCartao, string codVerificacao, DateTime dataValidade)
        {
            FuncaoCredito = funcaoCredito;
            FuncaoDebito = funcaoDebito;
            Fatura = fatura;
            Limite = limite;
            Senha = senha;
            NrCartao = nrCartao;
            CodVerificacao = codVerificacao;
            DataValidade = dataValidade;
            Extrato = new List<string>();
        }

        public void GerarFatura()
        {
            Console.WriteLine("O valor da fatura é : " + Fatura + " reais");
            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
            Console.ReadKey();
            Console.Clear();
        }

        public override string ToString()
        {
            return "\n\nDADOS DO CARTÃO: \nNúmero: " + NrCartao + "\nCodVerificacao: " + CodVerificacao +
                "\nLimite: " + Limite + "\nSenha: " + Senha + "\nValidade: " + DataValidade.ToString("MM/yy") + "\n";
        }


        public string ObterDados()
        {
            return FuncaoCredito + ";" + FuncaoDebito + ";" + Fatura + ";" + Limite + ";" + Senha + ";" + NrCartao +
                ";" + CodVerificacao + ";" + DataValidade + ";";
        }
    }
}
