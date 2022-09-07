using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Conta
    {
        public int IdAgencia { get; set; }
        public int IdConta { get; set; }
        public string Senha { get; set; }
        public List<string> Extrato { get; set; }
        public float Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool StatusAberta { get; set; }

        public Conta() { }
        public Conta(int idagencia, int idconta, string senha, float saldo, DateTime dataabertura, bool statusaberta)
        {
            IdAgencia = idagencia;
            IdConta = idconta;
            Senha = senha;
            Saldo = saldo;
            DataAbertura = dataabertura;
            StatusAberta = statusaberta;
            Extrato = new List<string>();
        }


        public bool Sacar(float valorsaque, float saldo, float limite)
        {
            if (valorsaque > saldo && valorsaque > (saldo + limite))
            {
                return false;
            }
            else
            {
                if (valorsaque > saldo && valorsaque < (saldo + limite))
                {
                    float diferencasaquesaldo = valorsaque - saldo;
                    Saldo = 0 - diferencasaquesaldo;
                    return true;
                }
                else
                {
                    Saldo = Saldo - valorsaque;
                    return true;
                }
            }

        }



        public bool Sacar(float valorsaque, float saldo)
        {
            if (valorsaque > saldo)
            {
                return false;
            }
            else
            {
                if (valorsaque > saldo)
                {
                    float diferencasaquesaldo = valorsaque - saldo;
                    Saldo = 0 - diferencasaquesaldo;
                    return true;
                }
                else
                {
                    Saldo = Saldo - valorsaque;
                    return true;
                }
            }

        }


        public void Depositar(float valor)
        {
            Saldo = Saldo + valor;
        }


        public string ConsultarSaldo()
            {
            return "Saldo: " + Saldo;
        }


        public  void ExibirExtrato()
        {
            if (Extrato.Count == 0)
            {
                Console.WriteLine("Nenhum extrato a exibir");
            }
            else
            {
                for (int i = 0; i < Extrato.Count; i++)
                {
                    Console.WriteLine(Extrato[i]);
                }
            }
        }
    }
}
