using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Cliente : Pessoa
    {
        public Cliente() { }
        public Cliente(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentoMensal, string cpf, string rg)
            : base(endereco, nome, dataNasc_Registro, faturamentoMensal, cpf, rg) { }


        public float PedirEmprestimo(float faturamentomensal)
        {
            Gerente gerente = new Gerente();
            float valoremprestimo = 0;
            int parcelas = 0;

            Console.Clear();
            Console.WriteLine("Digite o valor de emprestimo que deseja solicitar: ");
            bool validado = false;
            do
            {
                try
                {
                    valoremprestimo = float.Parse(Console.ReadLine());
                    if (valoremprestimo < 0)
                    {
                        Console.WriteLine("Insira um valor válido positivo!");
                        validado = false;
                    }

                    else
                        validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            Console.WriteLine("Digite a quantidade de parcelas que deseja: ");
            do
            {
                try
                {
                    parcelas = int.Parse(Console.ReadLine());
                    if (parcelas < 0)
                    {
                        Console.WriteLine("Insira um valor válido positivo!");
                        validado = false;
                    }
                    else
                    {
                        if (parcelas > 120)
                        {
                            Console.WriteLine("Insira parcelas menores que 120x");
                            validado = false;
                        }
                        else
                        {
                            validado = true;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            //Calcular o valor das parcelas por mês com o juros definido na va´riável juros:
            float juros = 0.2f;
            float valorparcelado = (valoremprestimo / parcelas) * juros;

            //Solicita aprovação do gerente e retorna a solicitação.
            bool aprovado = gerente.AprovarEmprestimo(valorparcelado, faturamentomensal);

            if (aprovado) return valoremprestimo;
            else return 0;
        }
    }
}
