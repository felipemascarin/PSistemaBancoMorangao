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

            string[] vetorletras = new string[] {"F","Ç","ç","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S",
            "T","U","V","W","X","Y","Z","Á","É","Í","Ó","Ú","À","È","Ì","Ò","Ù","Â","Ê","Î","Ô","Û","Ã","Õ"," "};
            string[] vetornumeros = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string nome = "";
            DateTime datanasc = DateTime.Parse("01/01/0001");
            float faturamentomensal = 0;
            string razaosocial = "";
            string cnpj = "";
            string cidade = "";
            string rua = "";
            string bairro = "";
            int numero = 0;
            int cep = 0;
            string estado = "";
            bool validado = false;
            bool encontrado = true;

            do
            {
                encontrado = true;
                Console.Write("Nome Fantasia: ");
                try
                {
                    nome = Console.ReadLine();

                    char[] letras = nome.ToCharArray();


                    for (int i = 0; i < letras.Length && encontrado != false; i++)
                    {
                        foreach (var v in vetorletras)
                        {
                            if (letras[i].ToString().ToUpper().Equals(v))
                            {
                                encontrado = true;
                                break;
                            }
                            else encontrado = false;
                        }
                    }

                    if (encontrado == false) Console.WriteLine("Nome só aceita letras.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


            do
            {
                try
                {
                    Console.Write("Data de Abertura da Empresa : ");
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
                encontrado = true;
                Console.Write("CNPJ: ");
                try
                {
                    cnpj = Console.ReadLine();

                    char[] letras = cnpj.ToCharArray();

                    if (letras.Length == 14)
                    {
                        for (int i = 0; i < letras.Length && encontrado != false; i++)
                        {
                            foreach (var v in vetornumeros)
                            {
                                if (letras[i].ToString().ToUpper().Equals(v))
                                {
                                    encontrado = true;
                                    break;
                                }
                                else encontrado = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Só aceita números válidos de 14 dígitos para CNPJ");
                        encontrado = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


            do
            {
                encontrado = true;
                Console.Write("Razão Social: ");
                try
                {
                    razaosocial = Console.ReadLine();

                    char[] letras = razaosocial.ToCharArray();


                    for (int i = 0; i < letras.Length && encontrado != false; i++)
                    {
                        foreach (var v in vetorletras)
                        {
                            if (letras[i].ToString().ToUpper().Equals(v))
                            {
                                encontrado = true;
                                break;
                            }
                            else encontrado = false;
                        }
                    }

                    if (encontrado == false) Console.WriteLine("Nome só aceita letras.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


                Console.Write("\nEndereço da Empresa:\n\n");

            do
            {
                encontrado = true;
                Console.Write("Cidade: ");
                try
                {
                    cidade = Console.ReadLine();

                    char[] letras = cidade.ToCharArray();


                    for (int i = 0; i < letras.Length && encontrado != false; i++)
                    {
                        foreach (var v in vetorletras)
                        {
                            if (letras[i].ToString().ToUpper().Equals(v))
                            {
                                encontrado = true;
                                break;
                            }
                            else encontrado = false;
                        }
                    }

                    if (encontrado == false) Console.WriteLine("Nome só aceita letras.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


            do
            {
                encontrado = true;
                Console.Write("Rua: ");
                try
                {
                    rua = Console.ReadLine();

                    char[] letras = rua.ToCharArray();


                    for (int i = 0; i < letras.Length && encontrado != false; i++)
                    {
                        foreach (var v in vetorletras)
                        {
                            if (letras[i].ToString().ToUpper().Equals(v))
                            {
                                encontrado = true;
                                break;
                            }
                            else encontrado = false;
                        }
                    }

                    if (encontrado == false) Console.WriteLine("Nome só aceita letras.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


            do
            {
                encontrado = true;
                Console.Write("Bairro: ");
                try
                {
                    bairro = Console.ReadLine();

                    char[] letras = bairro.ToCharArray();


                    for (int i = 0; i < letras.Length && encontrado != false; i++)
                    {
                        foreach (var v in vetorletras)
                        {
                            if (letras[i].ToString().ToUpper().Equals(v))
                            {
                                encontrado = true;
                                break;
                            }
                            else encontrado = false;
                        }
                    }

                    if (encontrado == false) Console.WriteLine("Nome só aceita letras.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


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
                            validado = false;
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
                encontrado = true;
                Console.Write("Estado: ");
                try
                {
                    estado = Console.ReadLine();

                    char[] letras = estado.ToCharArray();


                    for (int i = 0; i < letras.Length && encontrado != false; i++)
                    {
                        foreach (var v in vetorletras)
                        {
                            if (letras[i].ToString().ToUpper().Equals(v))
                            {
                                encontrado = true;
                                break;
                            }
                            else encontrado = false;
                        }
                    }

                    if (encontrado == false) Console.WriteLine("Nome só aceita letras.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


            Endereco endereco = new Endereco(cidade, rua, bairro, numero.ToString(), cep.ToString(), estado);
            PJ pessoajuridica = new PJ(endereco, nome, datanasc, faturamentomensal, razaosocial, cnpj);

            return pessoajuridica;
        }
    }
}
