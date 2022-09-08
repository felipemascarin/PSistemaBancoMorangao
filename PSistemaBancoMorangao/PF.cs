using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class PF : Cliente
    {
        public PF() { }

        public PF(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentoMensal, string cpf, string rg)
            : base(endereco, nome, dataNasc_Registro, faturamentoMensal, cpf, rg) { }

        public override string ToString()
        {
            string rg;
            if (Rg.ToString().Length == 8)
                rg = Rg + "-X";
            else rg = Rg;

            return "\nDADOS PESSOAIS: \nNome: " + Nome + "\nData de nascimento: " +
                DataNasc_Registro.ToShortDateString() + "\nCPF: " + Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00") + "\nRG: " + Convert.ToUInt64(rg).ToString(@"00\.000\.000\-0") + Endereco.ToString();
        }

        public string ObterDados()
        {
            return Nome + ";" + DataNasc_Registro + ";" + FaturamentoMensal + ";" + Cpf + ";" + Rg + ";";
        }

        public PF CadastrarContaPF()
        {
            //TRATAR DADOS: EX não pode faturamento menor que 0
            Console.WriteLine("CADASTRO DE CONTA CORRENTE / POUPANÇA DE PESSOA FÍSICA");


            string nome = "";
            DateTime datanasc = DateTime.Parse("01/01/0001");
            float faturamentomensal = 0;
            long cpf = 0;
            int rg = 0;
            string cidade = "";
            string rua = "";
            string bairro = "";
            int numero = 0;
            int cep = 0;
            string estado = "";
            bool validado = false;

            do
            {
                try
                {
                    Console.Write("Nome: ");
                    nome = Console.ReadLine();
                    validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                try
                {
                    Console.Write("Data de Nascimento (xx/MM/yyyy): ");
                    datanasc = DateTime.Parse(Console.ReadLine());
                    validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor no formato: Exemplo: 02/02/2002 Obs: Digite as barras.");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                try
                {
                    Console.Write("Faturamento Mensal: ");
                    faturamentomensal = float.Parse(Console.ReadLine());

                    if (faturamentomensal < 0)
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


            do
            {
                Console.Write("CPF: ");
                try
                {
                    cpf = long.Parse(Console.ReadLine());
                    if (cpf < 0)
                    {
                        Console.WriteLine("Insira um valor válido positivo!");
                        validado = false;
                    }
                    else
                    {
                        if (cpf.ToString().Length != 11)
                        {
                            Console.WriteLine("Insira obrigatóriamente os 11 números para prosseguir!");
                            validado = false;
                        }
                        else
                            validado = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido! Apenas os números");
                    validado = false;
                }
            } while (validado == false);



            do
            {
                Console.Write("RG: ");
                try
                {
                    rg = int.Parse(Console.ReadLine());
                    if (rg < 0)
                    {
                        Console.WriteLine("Insira um valor válido positivo!");
                        validado = false;
                    }
                    else
                    {
                        if (rg.ToString().Length < 8 || rg.ToString().Length > 9)
                        {
                            Console.WriteLine("Insira obrigatóriamente 8 ou 9 números para prosseguir! Não insira o último digito se ele for X");
                            validado = false;
                        }
                        else
                            validado = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira obrigatóriamente 8 ou 9 números para prosseguir! Não insira o último digito se ele for X");
                    validado = false;
                }
            } while (validado == false);



            do
            {
                Console.Write("Cidade: ");
                try
                {
                    cidade = Console.ReadLine();
                    validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                Console.Write("Rua: ");
                try
                {
                    rua = Console.ReadLine();
                    validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                Console.Write("Bairro: ");
                try
                {
                    bairro = Console.ReadLine();
                    validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                Console.Write("Numero: ");
                try
                {
                    numero = int.Parse(Console.ReadLine());
                    if (numero < 0)
                    {
                        Console.WriteLine("Insira um valor válido positivo!");
                        validado = false;
                    }
                    else
                    {
                        if (numero.ToString().Length > 7)
                        {
                            Console.WriteLine("Insira um valor válido, esse número é muito grande!");
                            validado = false;
                        }
                        else
                            validado = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                Console.Write("CEP: ");
                try
                {
                    cep = int.Parse(Console.ReadLine());
                    if (cep < 0)
                    {
                        Console.WriteLine("Insira um valor válido positivo!");
                        validado = false;
                    }
                    else
                    {
                        if (cep.ToString().Length != 8)
                        {
                            Console.WriteLine("Insira um valor válido! Apenas 8 números!");
                        }
                        else
                            validado = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido! Apenas números!");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                Console.Write("Estado: ");
                try
                {
                    estado = Console.ReadLine();
                    validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);


            Endereco endereco = new Endereco(cidade, rua, bairro, numero.ToString(), cep.ToString(), estado);
            PF pessoafisica = new PF(endereco, nome, datanasc, faturamentomensal, cpf.ToString(), rg.ToString());

            return pessoafisica;

        }



    }
}
