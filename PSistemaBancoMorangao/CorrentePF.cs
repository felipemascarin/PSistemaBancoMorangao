using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class CorrentePF : ContaCorrente
    {
        public PF PessoaFisica { get; set; }

        public CorrentePF() { }
        public CorrentePF(int idagencia, int idconta, string senha, float saldo, float limite, DateTime dataabertura, bool statusaberta, string tipoConta, Cartao cartao, PF pessoafisica)
            : base(idagencia, idconta, senha, saldo, limite, dataabertura, statusaberta, tipoConta, cartao)
        {
            PessoaFisica = pessoafisica;
        }

        public override string ToString()
        {
            return "\nDADOS DA CONTA CORRENTE: \nId Agencia: " + IdAgencia + "\nId Conta: " + IdConta + "\nSenha: " + Senha +
                "\nSaldo: " + Saldo + "\nData de Abertura: " + DataAbertura.ToLongDateString() + "\nLimite: " + Limite +
                "\nTipo de conta: " + TipoConta + "\n\n" + PessoaFisica.ToString() + Cartao.ToString();
        }

        public string ObterDados()
        {
            return IdAgencia + ";" + IdConta + ";" + Senha + ";" + Saldo + ";" + Limite + ";" + DataAbertura + ";" + StatusAberta +
                ";" + TipoConta;
        }

    }
}
