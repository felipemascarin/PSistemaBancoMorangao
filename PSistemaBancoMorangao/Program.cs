using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PSistemaBancoMorangao
{
    //Deve ser criado uma pasta de nome BancoMorangao dentro de c: para que o programa possa gravar os arquivos txt.
    internal class Program
    {
        //Ler um valor int válido:
        static public int TryCatchint()
        {
            int op = 0;
            do
            {
                try
                {
                    op = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite uma opção válida!");
                    op = 0;
                }
            } while (op == 0);
            return op;
        }

        //Gravar dados da agência em arquivo txt:
        static public void GravarAgencia(Agencia agencia)
        {
            try
            {
                StreamWriter sw = new StreamWriter("c:\\BancoMorangao\\Agencia.txt");
                sw.WriteLine(agencia.ObterDados());
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);

                Console.WriteLine("Para salvar os dados das contas deve ser apenas criado uma pasta com o nome BancoMorangao dentro de c: , diretório -> c:\\BancoMorangao");
            }
            Console.WriteLine("DADOS DA AGENCIA SALVOS COM SUCESSO!");
        }

        //Gravar todos os dados da lista de contas da agência em arquivo txt:
        static public void GravarContas(Agencia agencia)
        {
            try
            {
                StreamWriter s1 = new StreamWriter("c:\\BancoMorangao\\ContasCorrentesPF.txt");
                StreamWriter s2 = new StreamWriter("c:\\BancoMorangao\\ContasPoupancasPF.txt");
                StreamWriter s3 = new StreamWriter("c:\\BancoMorangao\\ContasCorrentesPJ.txt");
                StreamWriter s4 = new StreamWriter("c:\\BancoMorangao\\ContasPoupancasPJ.txt");
                StreamWriter s5 = new StreamWriter("c:\\BancoMorangao\\ExtratosContas.txt");
                StreamWriter s6 = new StreamWriter("c:\\BancoMorangao\\ExtratosCartoesPFtxt");
                StreamWriter s7 = new StreamWriter("c:\\BancoMorangao\\ExtratosCartoesPJ.txt");

                foreach (var conta in agencia.ListaContas)
                {
                    if (conta.Extrato.Count != 0)
                    {
                        foreach (var extratocontas in conta.Extrato)
                        {
                            s5.Write(extratocontas + ";");
                        }
                        s5.WriteLine(conta.IdConta.ToString());
                    }

                    if (conta is CorrentePF correntepf)
                    {
                        s1.Write(correntepf.PessoaFisica.Endereco.ObterDados());
                        s1.Write(correntepf.PessoaFisica.ObterDados());
                        s1.Write(correntepf.Cartao.ObterDados());
                        s1.WriteLine(correntepf.ObterDados());

                        if (correntepf.Cartao.Extrato.Count != 0)
                        {
                            foreach (var extratocartao in correntepf.Cartao.Extrato)
                            {
                                s6.Write(extratocartao + ";");
                            }
                            s6.WriteLine(correntepf.IdConta.ToString());
                        }
                    }


                    if (conta is PoupancaPF poupancapf)
                    {
                        s2.Write(poupancapf.PessoaFisica.Endereco.ObterDados());
                        s2.Write(poupancapf.PessoaFisica.ObterDados());
                        s2.WriteLine(poupancapf.ObterDados());
                    }

                    if (conta is CorrentePJ correntepj)
                    {
                        s3.Write(correntepj.PessoaJuridica.Endereco.ObterDados());
                        s3.Write(correntepj.PessoaJuridica.ObterDados());
                        s3.Write(correntepj.Cartao.ObterDados());
                        s3.WriteLine(correntepj.ObterDados());

                        if (correntepj.Cartao.Extrato.Count != 0)
                        {
                            foreach (var extratocartao in correntepj.Cartao.Extrato)
                            {
                                s7.Write(extratocartao + ";");
                            }
                            s7.WriteLine(correntepj.IdConta.ToString());
                        }
                    }

                    if (conta is PoupancaPJ poupancapj)
                    {
                        s4.Write(poupancapj.PessoaJuridica.Endereco.ObterDados());
                        s4.Write(poupancapj.PessoaJuridica.ObterDados());
                        s4.WriteLine(poupancapj.ObterDados());
                    }
                }
                s1.Close();
                s2.Close();
                s3.Close();
                s4.Close();
                s5.Close();
                s6.Close();
                s7.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Para salvar os dados das contas deve ser apenas criado uma pasta com o nome BancoMorangao dentro de c: , diretório -> c:\\BancoMorangao");
            }
            Console.WriteLine("DADOS DE TODAS AS CONTAS SALVOS COM SUCESSO!");
        }

        //Ler dados do arquivo txt de dados da agencia e instanciar o objeto agencia:
        static public Agencia CarregarAgencia()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\Agencia.txt");

                string[] informacoes;

                List<string> dados = new List<string>();

                foreach (string line in lines)
                {
                    informacoes = line.Split(';');

                    if (informacoes.Length == 2)
                    {
                        for (int i = 0; i < informacoes.Length; i++)
                            dados.Add(informacoes[i]);
                    }
                    else
                        return null;
                }
                return new Agencia(int.Parse(dados[0].ToString()), int.Parse(dados[1].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

        //Ler dados do arquivo txt de dados das ContasCorrentesPF, instanciar todos os objetos e salvar na lista Contas da agencia:
        static public void CarregarContasCorrentesPF(Agencia agencia)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\ContasCorrentesPF.txt");

                string[] dados;

                foreach (string line in lines)
                {
                    dados = line.Split(';');

                    if (dados.Length == 27)
                    {
                        Endereco endereco = new Endereco(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString(), dados[4].ToString(), dados[5].ToString());
                        PF pessoafisica = new PF(endereco, dados[6].ToString(), DateTime.Parse(dados[7].ToString()), float.Parse(dados[8].ToString()), dados[9].ToString(), dados[10].ToString());
                        Cartao cartao = new Cartao(bool.Parse(dados[11].ToString()), bool.Parse(dados[12].ToString()), float.Parse(dados[13].ToString()), float.Parse(dados[14].ToString()), dados[15].ToString(), dados[16].ToString(), dados[17].ToString(), DateTime.Parse(dados[18].ToString()));
                        CorrentePF correntepf = new CorrentePF(int.Parse(dados[19].ToString()), int.Parse(dados[20].ToString()), dados[21].ToString(), float.Parse(dados[22].ToString()), float.Parse(dados[23].ToString()), DateTime.Parse(dados[24].ToString()), bool.Parse(dados[25].ToString()), dados[26].ToString(), cartao, pessoafisica);

                        agencia.ListaContas.Add(correntepf);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Não Foi Possível Carregar informações das contas correntes pessoa física");

            }
        }

        //Ler dados do arquivo txt de dados das ContasCorrentesPJ, instanciar todos os objetos e salvar na lista Contas da agencia:
        static public void CarregarContasCorrentesPJ(Agencia agencia)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\ContasCorrentesPJ.txt");

                string[] dados;

                foreach (string line in lines)
                {
                    dados = line.Split(';');

                    if (dados.Length == 27)
                    {
                        Endereco endereco = new Endereco(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString(), dados[4].ToString(), dados[5].ToString());
                        PJ pessoajuridica = new PJ(endereco, dados[6].ToString(), DateTime.Parse(dados[7].ToString()), float.Parse(dados[8].ToString()), dados[9].ToString(), dados[10].ToString());
                        Cartao cartao = new Cartao(bool.Parse(dados[11].ToString()), bool.Parse(dados[12].ToString()), float.Parse(dados[13].ToString()), float.Parse(dados[14].ToString()), dados[15].ToString(), dados[16].ToString(), dados[17].ToString(), DateTime.Parse(dados[18].ToString()));
                        CorrentePJ correntepj = new CorrentePJ(int.Parse(dados[19].ToString()), int.Parse(dados[20].ToString()), dados[21].ToString(), float.Parse(dados[22].ToString()), float.Parse(dados[23].ToString()), DateTime.Parse(dados[24].ToString()), bool.Parse(dados[25].ToString()), dados[26].ToString(), cartao, pessoajuridica);

                        agencia.ListaContas.Add(correntepj);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Não Foi Possível Carregar informações das contas correntes pessoa jurídica");

            }
        }

        //Ler dados do arquivo txt de dados das ContasPoupancasPF, instanciar todos os objetos e salvar na lista Contas da agencia:
        static public void CarregarContasPoupancasPF(Agencia agencia)
        {

            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\ContasPoupancasPF.txt");

                string[] dados;

                foreach (string line in lines)
                {
                    dados = line.Split(';');

                    if (dados.Length == 17)
                    {
                        Endereco endereco = new Endereco(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString(), dados[4].ToString(), dados[5].ToString());
                        PF pessoafisica = new PF(endereco, dados[6].ToString(), DateTime.Parse(dados[7].ToString()), float.Parse(dados[8].ToString()), dados[9].ToString(), dados[10].ToString());
                        PoupancaPF poupancapf = new PoupancaPF(int.Parse(dados[11].ToString()), int.Parse(dados[12].ToString()), dados[13].ToString(), float.Parse(dados[14].ToString()), DateTime.Parse(dados[15].ToString()), bool.Parse(dados[16].ToString()), pessoafisica);

                        agencia.ListaContas.Add(poupancapf);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Não Foi Possível Carregar informações das contas poupança pessoa física");

            }
        }

        //Ler dados do arquivo txt de dados das ContasPoupancasPJ, instanciar todos os objetos e salvar na lista Contas da agencia:
        static public void CarregarContasPoupancasPJ(Agencia agencia)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\ContasPoupancasPJ.txt");

                string[] dados;

                foreach (string line in lines)
                {
                    dados = line.Split(';');

                    if (dados.Length == 17)
                    {
                        Endereco endereco = new Endereco(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString(), dados[4].ToString(), dados[5].ToString());
                        PJ pessoajuridica = new PJ(endereco, dados[6].ToString(), DateTime.Parse(dados[7].ToString()), float.Parse(dados[8].ToString()), dados[9].ToString(), dados[10].ToString());
                        PoupancaPJ poupancapj = new PoupancaPJ(int.Parse(dados[11].ToString()), int.Parse(dados[12].ToString()), dados[13].ToString(), float.Parse(dados[14].ToString()), DateTime.Parse(dados[15].ToString()), bool.Parse(dados[16].ToString()), pessoajuridica);

                        agencia.ListaContas.Add(poupancapj);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Não Foi Possível Carregar informações das contas poupança pessoa jurídica");

            }
        }

        //Carrega dos arquivos txt todos os dados dos extratos de todas as contas existentes:
        static public void CarregarExtratosContas(Agencia agencia)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\ExtratosContas.txt");

                string[] dados;

                foreach (var line in lines)
                {
                    dados = line.Split(';');
                    int ultimapos = dados.Length - 1;
                    foreach (var conta in agencia.ListaContas)
                    {
                        if (conta.IdConta == int.Parse(dados[ultimapos]))
                        {
                            for (int i = 0; i < ultimapos; i++)
                            {
                                conta.Extrato.Add(dados[i]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Não Foi Possível Carregar informações dos extratos das contas");
            }
        }

        //Carrega dos arquivos txt todos os dados dos extratos dos cartões de todas as contas correntes PF existentes:
        static public void CarregarExtratosCartoesPF(Agencia agencia)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\ExtratosCartoesPF.txt");

                string[] dados;

                foreach (var line in lines)
                {
                    dados = line.Split(';');
                    int ultimapos = dados.Length - 1;
                    foreach (var conta in agencia.ListaContas)
                    {
                        if (conta.IdConta == int.Parse(dados[ultimapos]))
                        {
                            if (conta is CorrentePF correntepf)
                            {
                                for (int i = 0; i < ultimapos; i++)
                                {
                                    correntepf.Cartao.Extrato.Add(dados[i]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Não Foi Possível Carregar informações dos extratos das contas");
            }
        }

        //Carrega dos arquivos txt todos os dados dos extratos dos cartões de todas as contas correntes PJ existentes:
        static public void CarregarExtratosCartoesPJ(Agencia agencia)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\BancoMorangao\ExtratosCartoesPF.txt");

                string[] dados;

                foreach (var line in lines)
                {
                    dados = line.Split(';');
                    int ultimapos = dados.Length - 1;
                    foreach (var conta in agencia.ListaContas)
                    {
                        if (conta.IdConta == int.Parse(dados[ultimapos]))
                        {
                            if (conta is CorrentePJ correntepj)
                            {
                                for (int i = 0; i < ultimapos; i++)
                                {
                                    correntepj.Cartao.Extrato.Add(dados[i]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Não Foi Possível Carregar informações dos extratos das contas");
            }
        }

        //Gera um Id diferente que ainda não existe na base de dados do banco para as contas:
        static public int GerarIdContas(Agencia agencia)
        {
            Random random = new Random();
            int idnovo;
            bool idexistente;
            do
            {
                idnovo = random.Next(100000, 500001);
                idexistente = agencia.ListaContas.Exists(conta => conta.IdConta == idnovo);
            } while (idexistente == true);

            return idnovo;
        }

        //Gera um Número de cartão que ainda não existe na base de dados do banco:
        static public string GerarNrCartao(Agencia agencia)
        {
            //primeiros 4 números do cartão:
            int bandeira = 4000;

            //segunda, terceira e quarta sequencia de 4 numeros do cartão:
            int primeira, segunda, terceira;
            string nrcartao;
            bool[] nrexistente = new bool[1];
            Random random = new Random();

            //Laço para verificar se o Nr de cartão já existe na base de dados do banco:
            do
            {
                nrexistente[0] = false;
                primeira = random.Next(1, 10000);
                segunda = random.Next(1, 10000);
                terceira = random.Next(1, 10000);

                nrcartao = (bandeira.ToString() + primeira.ToString() + segunda.ToString() + terceira.ToString());

                foreach (var conta in agencia.ListaContas)
                {
                    if (conta is ContaCorrente contacorrente)
                    {
                        if (contacorrente.Cartao.NrCartao.CompareTo(nrcartao) == 0)
                        {
                            nrexistente[0] = true;
                            break;
                        }
                    }
                }
            } while (nrexistente[0]);
            return nrcartao;
        }

        //Gera um código de verificação aleatório para o cartão:
        static public string GerarCvc()
        {
            Random random = new Random();
            int nrcvc = random.Next(100, 999);
            string cvc = nrcvc.ToString();
            return cvc;
        }

        //Gera uma senha inicial para cada conta:
        static public string GerarSenha()
        {
            Random random = new Random();
            int nrsenha = random.Next(100000, 999999);
            string senha = nrsenha.ToString();
            return senha;
        }

        //Gera um valor de limite inicial para cada conta e cartão de crédito, baseado no tipo da conta atribuído pelo funcionário:
        static public float GerarLimite(string tipoconta)
        {
            float limite;
            if (tipoconta == "UNIVERSITARIA")
                limite = 500;
            else if (tipoconta == "NORMAL")
                limite = 7000;
            else
                limite = 25000;
            return limite;
        }

        //Menu primário, com opções de telas para cliente, escriturário e Gerente. Nessa versão ainda não tem o menu escriturário:
        public static void MenuPrincipal(Agencia agencia, Gerente gerente, Escriturario escriturario, CaixaEletronico caixaeletronico)
        {
            int op = 1;
            do
            {
                Console.Clear();
                Console.WriteLine("Opçoes de Serviço do Sistema Banco Morangão  Agencia: " + agencia.IdAgencia);
                Console.WriteLine("1 - Sou cliente");
                Console.WriteLine("2 - Sou Escriturário");
                Console.WriteLine("3 - Sou Gerente");
                Console.WriteLine("4 - Sair");
                op = TryCatchint();
                Console.Clear();

                switch (op)
                {
                    case 1:
                        MenuCliente(agencia, gerente, escriturario, caixaeletronico);
                        break;
                    case 2:
                        //MenuEscriturario(); - Não tem função nessa atualização
                        break;
                    case 3:
                        MenuGerente(agencia, gerente, escriturario, caixaeletronico);
                        break;
                    case 4:
                        break;
                }
            } while (op != 4);
        }

        //Menu do cliente com opções para abrir contas e acessar funções das contas.
        static public void MenuCliente(Agencia agencia, Gerente gerente, Escriturario escriturario, CaixaEletronico caixaeletronico)
        {
            int op = 1;
            do
            {
                Console.Clear();
                Console.WriteLine("Opcoes de Serviço Para Cliente");
                Console.WriteLine("1 - Solicitar abertura de conta");
                Console.WriteLine("2 - Solicitar encerramento de conta");
                Console.WriteLine("3 - Menu Caixa Eletrônico - Operações da conta");
                Console.WriteLine("4 - Voltar");
                op = TryCatchint();
                Console.Clear();

                switch (op)
                {
                    case 1:
                        int opc = 0;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Digite o numero do tipo da conta a ser aberta");
                            Console.WriteLine("1 - Conta Corrente e Poupança de Pessoa Fisica");
                            Console.WriteLine("2 - Conta Corrente e Poupança de Pessoa Juridica");
                            Console.WriteLine("3 - Voltar ");
                            opc = TryCatchint();
                            Console.Clear();

                            switch (opc)
                            {
                                case 1:
                                    string tipoconta = "";
                                    bool aprovada = false;
                                    bool cpfjaexiste = false;
                                    //Pessoa física se cadastra:
                                    PF pf = new PF();
                                    pf = pf.CadastrarContaPF();

                                    //Procura por cpf ou rg já existente na base de dados do banco:
                                    foreach (var conta in agencia.ListaContas)
                                    {
                                        if (conta is CorrentePF correntepf)
                                        {
                                            if (correntepf.PessoaFisica.Cpf == pf.Cpf || correntepf.PessoaFisica.Rg == pf.Rg)
                                            {
                                                cpfjaexiste = true;
                                            }
                                        }
                                    }

                                    //Se já existe uma conta com esse cpf ou rg a nova conta não é aberta e segue o processo:
                                    if (cpfjaexiste == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Essa conta não pode ser aberta, pois já existe esse cpf ou rg ");
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {

                                        //Envia os dados de cadastro para escriturário inserir o tipo de conta:
                                        tipoconta = escriturario.AtribuirTipoDeConta(pf);
                                        //Retorna o tipo de conta e envia os dados para o gerente:
                                        aprovada = gerente.AprovarConta(tipoconta, pf);
                                        //Gerente retorna true para aprovada ou false para reprovada

                                        if (aprovada)
                                        {
                                            int idnovo;
                                            string nrcartao, cvc, senha;

                                            //Gera um valor de limite para conta corrente e cartão.
                                            float limite = GerarLimite(tipoconta);

                                            //Gera um número de cartão que não existe na base de dados do banco:
                                            nrcartao = GerarNrCartao(agencia);

                                            //Gera um cod de verificação CVC do cartão:
                                            cvc = GerarCvc();

                                            //Gera uma senha de 6 números para o cartão:
                                            senha = GerarSenha();

                                            //Cria o cartão:
                                            Cartao cartao = new Cartao(false, true, 0, limite, senha, nrcartao, cvc, DateTime.Now.AddYears(5));

                                            //gera um id que ainda não existe para a conta corrente:
                                            idnovo = GerarIdContas(agencia);
                                            //Gera uma senha de 6 números para a conta corrente:
                                            senha = GerarSenha();

                                            //Cria a conta corrente:
                                            CorrentePF correntepf = new CorrentePF(agencia.IdAgencia, idnovo, senha, 0, limite, System.DateTime.Now, true, tipoconta, cartao, pf);

                                            //gera um id que ainda não existe para a conta poupanca:
                                            idnovo = GerarIdContas(agencia);
                                            //Gera uma senha de 6 números para a conta Poupança:
                                            senha = GerarSenha();

                                            //Cria a conta poupança:
                                            PoupancaPF poupancapf = new PoupancaPF(agencia.IdAgencia, idnovo, senha, 0, System.DateTime.Now, true, pf);

                                            //Envia para agencia armazenar todos os dados das contas:
                                            agencia.ListaContas.Add(correntepf);
                                            agencia.ListaContas.Add(poupancapf);

                                            //Informa que a conta foi criada:
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Sua conta foi aprovada com sucesso!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(correntepf.ToString() + poupancapf.ToString());
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Conta não aprovada. Favor falar com gerente.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                    }
                                    break;


                                case 2:

                                    //Pessoa jurídica se cadastra:
                                    bool cnpjjaexiste = false;
                                    PJ pj = new PJ();
                                    pj = pj.CadastrarContaPJ();

                                    //Procura por cnpj já existente na base de dados do banco:
                                    foreach (var conta in agencia.ListaContas)
                                    {
                                        if (conta is CorrentePJ correntepj)
                                        {
                                            if (correntepj.PessoaJuridica.CNPJ == pj.CNPJ)
                                            {
                                                cnpjjaexiste = true;
                                            }
                                        }
                                    }

                                    //Se já existe uma conta com esse cpf ou rg a nova conta não é aberta e segue o processo:
                                    if (cnpjjaexiste == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Essa conta não pode ser aberta, pois já existe uma conta com esse CNPJ ");
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        //Envia os dados de cadastro para escriturário inserir o tipo de conta:
                                        tipoconta = "EMPRESARIAL";
                                        //Retorna o tipo de conta e envia os dados para o gerente:
                                        aprovada = gerente.AprovarConta(tipoconta, pj);
                                        //Gerente retorna true para aprovada ou false para reprovada

                                        if (aprovada)
                                        {
                                            int idnovo;
                                            string nrcartao, cvc, senha;

                                            //Gera um valor de limite para conta corrente e cartão.
                                            float limite = GerarLimite(tipoconta);

                                            //Gera um número de cartão que não existe na base de dados do banco:
                                            nrcartao = GerarNrCartao(agencia);

                                            //Gera um cod de verificação CVC do cartão:
                                            cvc = GerarCvc();

                                            //Gera uma senha de 6 números para o cartão:
                                            senha = GerarSenha();

                                            //Cria o cartão:
                                            Cartao cartao = new Cartao(false, true, 0, limite, senha, nrcartao, cvc, DateTime.Now.AddYears(5));

                                            //gera um id que ainda não existe para a conta corrente:
                                            idnovo = GerarIdContas(agencia);
                                            //Gera uma senha de 6 números para a conta corrente:
                                            senha = GerarSenha();

                                            //Cria a conta corrente:
                                            CorrentePJ correntepj = new CorrentePJ(agencia.IdAgencia, idnovo, senha, 0, limite, System.DateTime.Now, true, tipoconta, cartao, pj);

                                            //gera um id que ainda não existe para a conta poupanca:
                                            idnovo = GerarIdContas(agencia);
                                            //Gera uma senha de 6 números para a conta Poupança:
                                            senha = GerarSenha();

                                            //Cria a conta poupança:
                                            PoupancaPJ poupancapj = new PoupancaPJ(agencia.IdAgencia, idnovo, senha, 0, System.DateTime.Now, true, pj);

                                            //Envia para agencia armazenar todos os dados das contas:
                                            agencia.ListaContas.Add(correntepj);
                                            agencia.ListaContas.Add(poupancapj);

                                            //Informa que a conta foi criada:
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("A conta da empresa foi aprovada com sucesso!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(correntepj.ToString() + poupancapj.ToString());
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Conta empresarial não aprovada. Favor falar com gerente.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                    }
                                    break;

                                case 3:
                                    break;

                            }
                        } while (opc != 3);
                        break;


                    //Solicitar encerramento de conta
                    case 2:
                        try
                        {
                            Console.WriteLine("Informe o numero da conta que deseja encerrar: ");
                            int idencerrar = TryCatchint();
                            bool encontrado = false;

                            foreach (Conta c in agencia.ListaContas)
                            {
                                if (c.IdConta == idencerrar)
                                {
                                    encontrado = true;
                                    if (c.Saldo <= 0)
                                    {
                                        if (c is ContaCorrente contacorrente)
                                        {
                                            if (contacorrente.Cartao.Fatura <= 0)
                                            {
                                                agencia.ListaContas.Remove(contacorrente);
                                                Console.WriteLine("Conta encerrada com sucesso.");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Para a conta ser encerrada o seu saldo deve estar zerado e ser pago a fatura de seu cartão de crédito.");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                        }
                                        else
                                        {
                                            agencia.ListaContas.Remove(c);
                                            Console.WriteLine("Conta encerrada com sucesso.");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Para a conta ser encerrada o seu saldo deve estar zerado.");
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            if (!encontrado)
                            {
                                Console.WriteLine("Número de conta não encontrado.");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    //Menu caixa eletrônico:
                    case 3:

                        int idacesso = agencia.EfetuarLogin(agencia);

                        if (idacesso != 0)
                            caixaeletronico.ExibirMenu(agencia, idacesso);

                        break;

                    case 4:

                        break;
                }
            } while (op != 4);
        }

        //Menu do cliente com opções para obter todas as informações de qualquer conta existente, filtrando por cpf ou cnpj
        static public void MenuGerente(Agencia agencia, Gerente gerente, Escriturario escriturario, CaixaEletronico caixaeletronico)
        {
            string senha = "";
            bool validado = false;
            do
            {//senha de gerente "123456"
                Console.Write("Informe a senha de acesso de Gerente\nSenha: ");
                try
                {
                    senha = Console.ReadLine();
                    validado = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um valor válido!");
                    validado = false;
                }
            } while (validado == false);

            if (senha == "123456")
            {
                int opc = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Exibir dados de uma conta corrente pessoa fisica");
                    Console.WriteLine("2 - Exibir dados de uma conta corrente pessoa jurídica");
                    Console.WriteLine("3 - Exibir dados de uma conta poupança pessoa fisica");
                    Console.WriteLine("4 - Exibir dados de uma conta poupança pessoa jurídica");
                    Console.WriteLine("5 - Sair");

                    do
                    {
                        try
                        {
                            opc = int.Parse(Console.ReadLine());
                            if (opc < 1 || opc > 5)
                            {
                                Console.WriteLine("Insira um valor válido!");
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


                    switch (opc)
                    {
                        case 1:
                            long cpf = 0;
                            bool buscado = false;
                            do
                            {
                                Console.Write("Digite o CPF: ");
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
                                            Console.WriteLine("Insira obrigatóriamente 11 digitos de números para prosseguir!");
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


                            Console.Clear();


                            foreach (var conta in agencia.ListaContas)
                            {
                                if (conta is CorrentePF correntepf)
                                {
                                    if (correntepf.PessoaFisica.Cpf == cpf.ToString())
                                    {
                                        Console.WriteLine(correntepf.ToString());
                                        buscado = true;
                                        break;
                                    }
                                    else buscado = false;
                                }
                            }

                            if (buscado)
                            {
                                Console.WriteLine("\n\nImpressão de dados finalizada!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\nDados não encontrados!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            break;


                        case 2:
                            buscado = false;
                            long cnpj = 0;
                            do
                            {
                                Console.Write("Digite o CNPJ: ");
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
                                            Console.WriteLine("Insira obrigatóriamente 14 digitos de números para prosseguir!");
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

                            Console.Clear();

                            foreach (var conta in agencia.ListaContas)
                            {
                                if (conta is CorrentePJ correntepj)
                                {
                                    if (correntepj.PessoaJuridica.CNPJ == cnpj.ToString())
                                    {
                                        Console.WriteLine(correntepj.ToString());
                                        buscado = true;
                                        break;
                                    }
                                    else buscado = false;
                                }
                            }

                            if (buscado)
                            {
                                Console.WriteLine("\n\nImpressão de dados finalizada!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\nDados não encontrados!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            break;

                        case 3:
                            cpf = 0;
                            buscado = false;
                            Console.WriteLine("Digite o cpf sem pontos: ");
                            do
                            {
                                try
                                {
                                    cpf = int.Parse(Console.ReadLine());
                                    if (cpf < 0)
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

                            foreach (var conta in agencia.ListaContas)
                            {
                                if (conta is PoupancaPF poupancapf)
                                {
                                    if (poupancapf.PessoaFisica.Cpf == cpf.ToString())
                                    {
                                        Console.WriteLine(poupancapf.ToString());
                                        buscado = true;
                                        break;
                                    }
                                    else buscado = false;
                                }
                            }

                            if (buscado)
                            {
                                Console.WriteLine("\n\nImpressão de dados finalizada!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\nDados não encontrados!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            break;

                        case 4:
                            buscado = false;
                            cnpj = 0;
                            Console.WriteLine("Digite o CNPJ sem pontos: ");
                            do
                            {
                                try
                                {
                                    cnpj = int.Parse(Console.ReadLine());
                                    if (cnpj < 0)
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

                            foreach (var conta in agencia.ListaContas)
                            {
                                if (conta is PoupancaPJ poupancapj)
                                {
                                    if (poupancapj.PessoaJuridica.CNPJ == cnpj.ToString())
                                    {
                                        Console.WriteLine(poupancapj.ToString());
                                        buscado = true;
                                        break;
                                    }
                                    else buscado = false;
                                }
                            }

                            if (buscado)
                            {
                                Console.WriteLine("\n\nImpressão de dados finalizada!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\nDados não encontrados!");
                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                Console.ReadKey();
                            }
                            break;

                        case 5:
                            break;
                    }
                } while (opc != 5);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Acesso negado!");
                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                Console.ReadKey();
            }
        }


        static void Main(string[] args)
        {
            //Cria um diretório para o salvamento dos arquivos.
            System.IO.Directory.CreateDirectory(@"C:\BancoMorangao");

            //Carrega dados da agência e conta salvos nos arquivos txt quando o programa é iniciado:
            Agencia agencia = CarregarAgencia();
            Console.WriteLine("Carregando Agencia .");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Carregando Agencia . .");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Carregando Agencia . . .");
            Thread.Sleep(200);
            Console.Clear();
            if (agencia == null)
            {
                Console.WriteLine("Não foi possível carregar as informações da agencia no banco de dados.");
                Console.WriteLine("Por favor, informe o Id da agencia que irá utilizar esse programa: ");
                int idagencia = TryCatchint();
                Console.WriteLine("Informe a quantidade de funcionarios da agencia: ");
                int qtd_funcionarios = TryCatchint();
                agencia = new Agencia(idagencia, qtd_funcionarios);
            }
            else
            {
                Console.WriteLine("Carregando base de dados das Contas .");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("Carregando base de dados das Contas . .");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("Carregando base de dados das Contas . . .");
                Thread.Sleep(200);
                Console.Clear();
                CarregarContasCorrentesPF(agencia);
                CarregarContasPoupancasPF(agencia);
                CarregarContasCorrentesPJ(agencia);
                CarregarContasPoupancasPJ(agencia);
                CarregarExtratosContas(agencia);
                CarregarExtratosCartoesPF(agencia);
                CarregarExtratosCartoesPJ(agencia);
            }

            Console.WriteLine(agencia.ToString());
            Console.WriteLine("\n\nPRESSIONE ENTER PARA INICIAR");
            Console.ReadKey();


            Escriturario escriturario = new Escriturario();
            Gerente gerente = new Gerente();
            CaixaEletronico caixaeletronico = new CaixaEletronico();

            MenuPrincipal(agencia, gerente, escriturario, caixaeletronico);

            //Salva todos os dados nos arquivos txt quando o programa é encerrado:
            Console.WriteLine("Salvando dados de Agencia e Contas  .");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Salvando dados de Agencia e Contas  . .");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Salvando dados de Agencia e Contas  . . .");
            Thread.Sleep(200);
            Console.Clear();
            GravarAgencia(agencia);
            GravarContas(agencia);

            Console.WriteLine("Programa encerrado com sucesso.");

        }

    }
}
