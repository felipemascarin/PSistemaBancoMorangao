using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class PJ : Cliente
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }

        public PJ(){ }

        public PJ(Endereco endereco, string nome, DateTime dataNasc_Registro, float faturamentoMensal, string razaoSocial, string Cnpj)
             : base(endereco, nome, dataNasc_Registro, faturamentoMensal, null, null)
        {
            RazaoSocial = razaoSocial;
            CNPJ = Cnpj;
        }

        public override string ToString()
        {
            return "\nDADOS EMPRESARIAL: \nNome Fantasia: " + Nome + "\nData de abertura: " +
                DataNasc_Registro.ToShortDateString() + "\nRazão Social: " + RazaoSocial + "\nCNPJ: " + Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00") + Endereco.ToString();
        }


        public string ObterDados()
        {
            return Nome + ";" + DataNasc_Registro + ";" + FaturamentoMensal + ";" + RazaoSocial + ";" + CNPJ + ";";
        }


        public PJ CadastrarContaPJ()
        {
            Console.WriteLine("CADASTRO DE CONTA CORRENTE / POUPANÇA DE PESSOA JURÍDICA");


            string nome = "";
            DateTime datanasc = DateTime.Parse("01/01/0001");
            float faturamentomensal = 0;
            string razaosocial = "";
            long cnpj = 0;
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
                    Console.Write("Nome Fantasia: ");
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
                    Console.Write("Data de Abertura da Empresa (xx/MM/yyyy): ");
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
                    Console.Write("Faturamento Mensal da Empresa: ");
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
                Console.Write("CNPJ: ");
                try
                {
                    cnpj = long.Parse(Console.ReadLine());
                    if (cnpj < 0)
                    {
                        Console.WriteLine("Insira um valor válido positivo!");
                        validado = false;
                    }
                    else
                    {
                        if (cnpj.ToString().Length != 14)
                        {
                            Console.WriteLine("Insira apenas os 14 números do CNPJ para prosseguir!");
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
                    Console.WriteLine("Insira um valor válido! Insira apenas os 14 números do CNPJ para prosseguir!");
                    validado = false;
                }
            } while (validado == false);


            do
            {
                Console.Write("Razão Social: ");
                try
                {
                    razaosocial = Console.ReadLine();
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
                Console.Write("\nEndereço da Empresa:\n\nCidade: ");
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
            PJ pessoajuridica = new PJ(endereco, nome, datanasc, faturamentomensal, razaosocial, cnpj.ToString());

            return pessoajuridica;
        }


    }
}
