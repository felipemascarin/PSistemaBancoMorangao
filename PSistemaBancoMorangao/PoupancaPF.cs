using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class PoupancaPF : Conta
    {
        public PF PessoaFisica { get; set; }

        public PoupancaPF() { }

        public PoupancaPF(int idagencia, int idconta, string senha, float saldo, DateTime dataabertura, bool statusaberta, PF pessoafisica)
            : base(idagencia, idconta, senha, saldo, dataabertura, statusaberta)
        {
            PessoaFisica = pessoafisica;
        }
        
        public override string ToString()
        {
            return "\nDADOS DA CONTA POUPANÇA: \nId Agencia: " + IdAgencia + "\nId Conta: " + IdConta + "\nSenha: " + Senha +
                "\nSaldo: " + Saldo + "\nData de Abertura: " + DataAbertura.ToLongDateString() +"\n";
        }

        public string ObterDados()
        {
            return IdAgencia + ";" + IdConta + ";" + Senha + ";" + Saldo + ";" + DataAbertura + ";" + StatusAberta;
        }

    }
}
