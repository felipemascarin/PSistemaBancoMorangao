using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class ContaCorrente : Conta
    {
        public string TipoConta { get; set; }
        public float Limite { get; set; }
        public Cartao Cartao { get; set; }

        public ContaCorrente() { }
        public ContaCorrente(int idagencia, int idconta, string senha, float saldo, float limite, DateTime dataabertura, bool statusaberta, string tipoConta, Cartao cartao)
            : base(idagencia, idconta, senha, saldo, dataabertura, statusaberta)
        {
            TipoConta = tipoConta;
            Limite = limite;
            Cartao = cartao;
        }


        public bool Transferir(float valortransferir, float saldo, float limite, int transferencia, Conta contatransfere, Conta contarecebe)
        {
            bool transferido;
            transferido = contatransfere.Sacar(valortransferir, saldo, limite);

            if (transferido)
            {
                contarecebe.Depositar(valortransferir);
                return true;
            }
            else
            {
                return false;
            }
        }

        /*Esse Metodo foi previsto no diagrama de classes, porém ainda não foi implementado nessa versão
          pois não tem funcionalidade ainda, já q o pagamento atual é só com cartão de crédito ou transferencia

        public void Pagar()
        {}*/ 

    }
}
