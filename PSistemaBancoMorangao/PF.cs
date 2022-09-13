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
            

            return "\nDADOS PESSOAIS: \nNome: " + Nome + "\nData de nascimento: " +
                DataNasc_Registro.ToShortDateString() + "\nCPF: " + Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00") + "\nRG: " + Convert.ToUInt64(Rg).ToString(@"00\.000\.000\-0") + Endereco.ToString();
        }

        public string ObterDados()
        {
            return Nome + ";" + DataNasc_Registro + ";" + FaturamentoMensal + ";" + Cpf + ";" + Rg + ";";
        }

        public PF CadastrarContaPF()
        {
            //TRATAR DADOS: EX não pode faturamento menor que 0
            Console.WriteLine("CADASTRO DE CONTA CORRENTE / POUPANÇA DE PESSOA FÍSICA");

            string[] vetorletras = new string[] {"Ç","ç","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S",
            "T","U","V","W","X","Y","Z","Á","É","Í","Ó","Ú","À","È","Ì","Ò","Ù","Â","Ê","Î","Ô","Û","Ã","Õ"," "};
            string[] vetornumeros = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string nome = "";
            DateTime datanasc = DateTime.Parse("01/01/0001");
            float faturamentomensal = 0;
            string cpf = "";
            string rg = "";
            string cidade = "";
            string rua = "";
            string bairro = "";
            int numero = 0;
            int cep = 0;
            string estado = "";
            bool validado = false;
            bool encontrado;


            do
            {
                encontrado = true;
                Console.Write("Nome: ");
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
                    Console.Write("Data de Nascimento: ");
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
                encontrado = true;
                Console.Write("Cpf: ");
                try
                {
                    cpf = Console.ReadLine();
                    
                    char[] letras = cpf.ToCharArray();

                    if (letras.Length == 11)
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
                        Console.WriteLine("Só aceita números válidos de 11 digitos");
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
                Console.Write("RG: ");
                try
                {
                    rg = Console.ReadLine();

                    char[] letras = rg.ToCharArray();

                    if (letras.Length == 9)
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
                        Console.WriteLine("Só aceita 9 digitos, se for digito X digite 0 no lugar");
                        encontrado = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    encontrado = false;
                }
            } while (encontrado == false);


            Console.Write("\nEndereço:\n\n");


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
            PF pessoafisica = new PF(endereco, nome, datanasc, faturamentomensal, cpf, rg);

            return pessoafisica;

        }
    }
}
