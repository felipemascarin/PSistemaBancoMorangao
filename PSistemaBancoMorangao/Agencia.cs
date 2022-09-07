using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace PSistemaBancoMorangao
{
    internal class Agencia
    {
        public int IdAgencia { get; set; }
        public int QtdFuncionarios { get; set; }
        public List<Funcionario> ListaFuncionarios { get; set; }
        public List<Conta> ListaContas { get; set; }

        public CaixaEletronico Caixa { get; set; }

        public Agencia(int idagencia, int qtdfuncionarios)
        {
            IdAgencia = idagencia;
            QtdFuncionarios = qtdfuncionarios;
            ListaContas = new List<Conta>();
            ListaFuncionarios = new List<Funcionario>();
            Caixa = new CaixaEletronico();
        }


        public override string ToString()
        {
            return "Agencia de acesso ID: " + IdAgencia;
        }

        public string ObterDados()
        {
            return IdAgencia + ";" + QtdFuncionarios;
        }


        public int EfetuarLogin(Agencia agencia)
        {
            bool validado = false;
            int usuario = 0;
            string senhaacesso = "";

            Console.Clear();
            Console.WriteLine("Insira seus dados para acessar o menu do caixa eletrônico");
            Console.Write("IdConta: ");

            do
            {
                try
                {
                    usuario = int.Parse(Console.ReadLine());
                    if (usuario < 0)
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

            Console.Clear();
            Console.WriteLine("Insira seus dados para acessar o menu do caixa eletrônico");
            Console.WriteLine("IdConta: " + usuario);
            Console.Write("Senha: ");

            do
            {
                try
                {
                    senhaacesso = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);

            Console.Clear();
            Console.WriteLine("Insira seus dados para acessar o menu do caixa eletrônico");
            Console.WriteLine("IdConta: " + usuario);
            Console.WriteLine("Senha: " + senhaacesso);
            Console.Write("PRESISONE ENTER PARA AUTENTICAÇÃO");
            Console.ReadKey();
            Console.Clear();

            bool idencontrado = false;
            bool senhaencontrada = false;
            

            foreach (var conta in agencia.ListaContas)
            {
                if (conta.IdConta == usuario)
                {
                    idencontrado = true;

                    if (conta.Senha == senhaacesso)
                    {
                        senhaencontrada = true;
                        return usuario;
                    } 
                    else senhaencontrada = false;
                }
            }

            if (idencontrado)
            {
                if (senhaencontrada)
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("Senha incorreta");
                    Console.WriteLine("\n\nRecupere sua senha no menu do gerente");
                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                    Console.ReadKey();
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Número da conta está incorreto.");
                Console.WriteLine("\n\nRecupere os dados de suas contas no menu do gerente");
                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                Console.ReadKey();
                return 0;
            }
        }





    }
}
