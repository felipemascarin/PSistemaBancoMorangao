using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class CaixaEletronico
    {
        public CaixaEletronico() { }


        public void ExibirMenu(Agencia agencia, int idacesso)
        {

            bool validado = false;
            int opc = 0;

            foreach (var conta in agencia.ListaContas)
            {
                if (conta.IdConta == idacesso)
                {
                    if (conta.StatusAberta == true)
                    {
                        if (conta is CorrentePF contaacesso)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\nConta Corrente: " + contaacesso.IdConta + " " + contaacesso.TipoConta + "\n");

                                if (contaacesso.Cartao.FuncaoCredito)
                                    Console.WriteLine("Status do cartão de crédito: Desbloqueado\n\n");
                                else Console.WriteLine("Status do cartão de crédito: Bloqueado\n\n");



                                Console.WriteLine("1  - Consultar o saldo da conta");//
                                Console.WriteLine("2  - Depositar dinheiro na conta");//
                                Console.WriteLine("3  - Sacar dinheiro da conta");//
                                Console.WriteLine("4  - Transferência");//
                                Console.WriteLine("5  - Pagamento cartão de crédito");//
                                Console.WriteLine("6  - Solicitar empréstimo");//
                                Console.WriteLine("7  - Exibir extrato de todas as operações da conta");//
                                Console.WriteLine("8  - Desbloquear/Bloquear Cartão de crédito");
                                Console.WriteLine("9  - Limite disponível do cartão");//
                                Console.WriteLine("10 - Fatura do cartão de crédito");//
                                Console.WriteLine("11 - Alterar senha de acesso");//
                                Console.WriteLine("12 - Exibir dados da conta e cartão");//
                                Console.WriteLine("13 - Pagar fatura do cartão de crédito com saldo da conta");//
                                Console.WriteLine("14 - Exibir extrato do cartão de crédito");//
                                Console.WriteLine("\n\n0 - Encerrar Sessão");//

                                do
                                {
                                    try
                                    {
                                        opc = int.Parse(Console.ReadLine());
                                        if (opc < 0 || opc > 14)
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

                                Console.Clear();


                                switch (opc)
                                {
                                    case 1:
                                        Console.WriteLine(contaacesso.ConsultarSaldo());
                                        Console.WriteLine("\nLimite cheque especial: " + contaacesso.Limite);
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    case 2:
                                        float valordeposito = 0;
                                        Console.WriteLine("Depósito:");
                                        Console.WriteLine("Informe o valor a ser depositado na conta:");
                                        do
                                        {
                                            try
                                            {
                                                valordeposito = int.Parse(Console.ReadLine());
                                                if (valordeposito < 0)
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

                                        contaacesso.Depositar(valordeposito);

                                        Console.Clear();
                                        Console.WriteLine("Valor " + valordeposito + " depositado com sucesso!");
                                        contaacesso.Extrato.Add("Depósito " + valordeposito + " reais " + System.DateTime.Now);
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    case 3:
                                        float valorsaque = 0;
                                        Console.WriteLine("Saque:");
                                        Console.WriteLine("Informe o valor de saque:");
                                        do
                                        {
                                            try
                                            {
                                                valorsaque = int.Parse(Console.ReadLine());
                                                if (valorsaque < 0)
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

                                        bool sacado = contaacesso.Sacar(valorsaque, contaacesso.Saldo, contaacesso.Limite);

                                        if (sacado)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Valor " + valorsaque + " retirado da conta com sucesso!");
                                            contaacesso.Extrato.Add("Saque " + valorsaque + " reais " + System.DateTime.Now);
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Saldo insuficiente!");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }
                                        break;



                                    case 4:
                                        float valortransferir = 0;
                                        int idtransferencia = 0;
                                        bool encontrado = false;
                                        bool transferido = false;

                                        Console.WriteLine("Transferência / PIX");
                                        Console.WriteLine("\n\nInforme o número da conta (id conta) que receberá a transferência: ");
                                        do
                                        {
                                            try
                                            {
                                                idtransferencia = int.Parse(Console.ReadLine());
                                                if (idtransferencia < 0)
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

                                        Conta contarecebe = new Conta();
                                        foreach (var c in agencia.ListaContas)
                                        {
                                            if (c.IdConta == idtransferencia)
                                            {
                                                contarecebe = c;
                                                encontrado = true;
                                                break;
                                            }
                                            encontrado = false;
                                        }

                                        if (encontrado)
                                        {
                                            Console.WriteLine("Informe o valor da Transferência:");
                                            do
                                            {
                                                try
                                                {
                                                    valortransferir = int.Parse(Console.ReadLine());
                                                    if (valortransferir < 0)
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

                                            transferido = contaacesso.Transferir(valortransferir, contaacesso.Saldo, contaacesso.Limite, idtransferencia, contaacesso, contarecebe);

                                            if (transferido)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Valor de " + valortransferir + " reais transferido com sucesso!");
                                                contaacesso.Extrato.Add("Transferido " + valortransferir + " reais  para " + idtransferencia + " " + System.DateTime.Now);
                                                contarecebe.Extrato.Add("Recebido Transferência de " + valortransferir + " reais  de conta " + contaacesso.IdConta + " " + System.DateTime.Now);
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Transferência não realizada por falta de saldo");
                                                Console.ReadKey();
                                            }

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Esse numero de conta não existe.");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        break;

                                    case 5:
                                        //essa versão não está considerando vencimento do cartão para pagamento
                                        if (contaacesso.Cartao.FuncaoCredito)
                                        {
                                            float pagamento = 0;
                                            Console.WriteLine("Insira o valor do pagamento: ");

                                            do
                                            {
                                                try
                                                {
                                                    pagamento = float.Parse(Console.ReadLine());

                                                    if (pagamento < 0)
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

                                            if (pagamento <= contaacesso.Cartao.Limite)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Dados do cartão\n\n");
                                                Console.WriteLine(contaacesso.Cartao.ToString());
                                                string escolha = "";

                                                do
                                                {
                                                    Console.WriteLine("\n\nDeseja realmente Realizar uma compra com o cartão de crédito?\nDigite S para sim ou C para cancelar");
                                                    try
                                                    {
                                                        escolha = Console.ReadLine().ToUpper();

                                                        if (escolha == "S" || escolha == "C")
                                                            validado = true;
                                                        else
                                                        {
                                                            Console.WriteLine("Digite apenas a letra S para sim ou a letra C para cancelar");
                                                            validado = false;
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("Insira um valor válido!");
                                                        validado = false;
                                                    }
                                                } while (validado == false);

                                                if (escolha == "S")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Pagamento realizado com sucesso!\n\n");
                                                    contaacesso.Cartao.Extrato.Add("Realizado pagamento de " + pagamento + " reais " + System.DateTime.Now);
                                                    contaacesso.Cartao.Limite = contaacesso.Cartao.Limite - pagamento;
                                                    contaacesso.Cartao.Fatura = pagamento;
                                                    Console.WriteLine("Limite atual do cartão: " + contaacesso.Cartao.Limite + " reais ");
                                                    Console.WriteLine("Fatura atual do cartão: " + contaacesso.Cartao.Fatura + " reais ");
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Cartão não tem limite para esse pagamento!");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Cartão Bloqueado!");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }



                                        break;


                                    case 6:
                                        float valoraprovado = contaacesso.PessoaFisica.PedirEmprestimo(contaacesso.PessoaFisica.FaturamentoMensal);

                                        if (valoraprovado == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Empréstimo negado!");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            contaacesso.Depositar(valoraprovado);
                                            Console.Clear();
                                            Console.WriteLine("Empréstimo aprovado!\nO dinheiro foi depositado em sua conta.");
                                            contaacesso.Extrato.Add("Depósito de empréstimo do banco " + valoraprovado + " reais " + System.DateTime.Now);
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        break;

                                    case 7:
                                        contaacesso.ExibirExtrato();
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                        break;

                                    case 8:
                                        if (contaacesso.Cartao.FuncaoCredito == false)
                                        {
                                            contaacesso.Cartao.FuncaoCredito = true;
                                            Console.WriteLine("Cartão Desbloqueado");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            contaacesso.Cartao.FuncaoCredito = false;
                                            Console.WriteLine("Cartão Bloqueado");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }

                                        break;

                                    case 9:
                                        Console.WriteLine("O limite atual disponível do cartão de crédito é de: " + contaacesso.Cartao.Limite + " reais");
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                        break;

                                    case 10:
                                        contaacesso.Cartao.GerarFatura();
                                        break;


                                    case 11:
                                        string opcao = "";
                                        do
                                        {
                                            Console.WriteLine("Deseja realmente trocar a senha?\nDigite S para sim ou C para cancelar");
                                            try
                                            {
                                                opcao = Console.ReadLine().ToUpper();

                                                if (opcao == "S" || opcao == "C")
                                                    validado = true;
                                                else
                                                {
                                                    Console.WriteLine("Digite apenas a letra S para sim ou a letra C para cancelar");
                                                    validado = false;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Insira um valor válido!");
                                                validado = false;
                                            }
                                        } while (validado == false);

                                        if (opcao == "S")
                                        {
                                            int senhanova = 0;
                                            Console.Clear();
                                            do
                                            {
                                                Console.WriteLine("Digite a nova senha de 6 números: ");
                                                try
                                                {
                                                    senhanova = int.Parse(Console.ReadLine());
                                                    if (senhanova < 0)
                                                    {
                                                        Console.WriteLine("Insira um valor válido!");
                                                        validado = false;
                                                    }
                                                    else
                                                    {
                                                        if (senhanova.ToString().Length != 6)
                                                        {
                                                            Console.WriteLine("A senha deve conter 6 numeros.");
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

                                            contaacesso.Senha = senhanova.ToString();

                                            Console.Clear();
                                            Console.WriteLine("Senha alterada com sucesso!\nNova senha: " + senhanova);
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        break;

                                    case 12:
                                        Console.WriteLine(contaacesso.ToString());
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                        break;

                                    case 13:
                                        if (contaacesso.Cartao.Fatura == 0)
                                        {
                                            Console.WriteLine("O valor da fatura está zerado");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Informação: Não é possível pagar com o valor do cheque especial\n\n");
                                            if (contaacesso.Cartao.Fatura <= contaacesso.Saldo)
                                            {
                                                contaacesso.Extrato.Add("Pagamento limite cartão de crédito " + contaacesso.Cartao.Fatura + " reais " + " " + System.DateTime.Now);
                                                Console.WriteLine("Saldo anterior: " + contaacesso.Saldo + " reais");
                                                contaacesso.Saldo = contaacesso.Saldo - contaacesso.Cartao.Fatura;
                                                contaacesso.Cartao.Fatura = 0;

                                                if (contaacesso.TipoConta == "UNIVERSITARIA")
                                                    contaacesso.Cartao.Limite = 500;
                                                else if (contaacesso.TipoConta == "NORMAL")
                                                    contaacesso.Cartao.Limite = 7000;
                                                else
                                                    contaacesso.Cartao.Limite = 25000;

                                                Console.WriteLine("Saldo atual: " + contaacesso.Saldo + " reais");
                                                Console.WriteLine("\nFatura paga com sucesso!");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nSua conta não possui saldo para o pagamento da fatura do cartão\n");
                                                Console.WriteLine("Saldo atual: " + contaacesso.Saldo + " reais\n");
                                                contaacesso.Cartao.GerarFatura();
                                            }
                                        }
                                        break;

                                    case 14:                                        
                                        foreach (var e in contaacesso.Cartao.Extrato)
                                        {
                                            Console.WriteLine(e);
                                        }
                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                        Console.ReadKey();
                                        break;


                                    case 0:

                                        break;
                                }
                            } while (opc != 0);
                        }















                        else
                        {

                            if (conta is CorrentePJ contaacesso1)
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("\nConta Corrente: " + contaacesso1.IdConta + " " + contaacesso1.TipoConta + "\n");

                                    if (contaacesso1.Cartao.FuncaoCredito)
                                        Console.WriteLine("Status do cartão de crédito: Desbloqueado\n\n");
                                    else Console.WriteLine("Status do cartão de crédito: Bloqueado\n\n");



                                    Console.WriteLine("1  - Consultar o saldo da conta");//
                                    Console.WriteLine("2  - Depositar dinheiro na conta");//
                                    Console.WriteLine("3  - Sacar dinheiro da conta");//
                                    Console.WriteLine("4  - Transferência");//
                                    Console.WriteLine("5  - Pagamento cartão de crédito");//
                                    Console.WriteLine("6  - Solicitar empréstimo");//
                                    Console.WriteLine("7  - Exibir extrato de todas as operações da conta");//
                                    Console.WriteLine("8  - Desbloquear/Bloquear Cartão de crédito");
                                    Console.WriteLine("9  - Limite disponível do cartão");//
                                    Console.WriteLine("10 - Fatura do cartão de crédito");//
                                    Console.WriteLine("11 - Alterar senha de acesso");//
                                    Console.WriteLine("12 - Exibir dados da conta e cartão");//
                                    Console.WriteLine("13 - Pagar fatura do cartão de crédito com saldo da conta");//
                                    Console.WriteLine("14 - Exibir extrato do cartão de crédito");//
                                    Console.WriteLine("\n\n0 - Encerrar Sessão");//

                                    do
                                    {
                                        try
                                        {
                                            opc = int.Parse(Console.ReadLine());
                                            if (opc < 0 || opc > 14)
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

                                    Console.Clear();


                                    switch (opc)
                                    {
                                        case 1:                                            
                                            Console.WriteLine(contaacesso1.ConsultarSaldo());
                                            Console.WriteLine("\nLimite cheque especial: " + contaacesso1.Limite);
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;

                                        case 2:
                                            float valordeposito = 0;
                                            Console.WriteLine("Depósito:");
                                            Console.WriteLine("Informe o valor a ser depositado na conta:");
                                            do
                                            {
                                                try
                                                {
                                                    valordeposito = int.Parse(Console.ReadLine());
                                                    if (valordeposito < 0)
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

                                            contaacesso1.Depositar(valordeposito);

                                            Console.Clear();
                                            Console.WriteLine("Valor " + valordeposito + " depositado com sucesso!");
                                            contaacesso1.Extrato.Add("Depósito " + valordeposito + " reais " + System.DateTime.Now);
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;

                                        case 3:
                                            float valorsaque = 0;                                            
                                            Console.WriteLine("Saque:");
                                            Console.WriteLine("Informe o valor de saque:");
                                            do
                                            {
                                                try
                                                {
                                                    valorsaque = int.Parse(Console.ReadLine());
                                                    if (valorsaque < 0)
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

                                            bool sacado = contaacesso1.Sacar(valorsaque, contaacesso1.Saldo, contaacesso1.Limite);

                                            if (sacado)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Valor " + valorsaque + " retirado da conta com sucesso!");
                                                contaacesso1.Extrato.Add("Saque " + valorsaque + " reais " + System.DateTime.Now);
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Saldo insuficiente!");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            break;



                                        case 4:
                                            float valortransferir = 0;
                                            int idtransferencia = 0;
                                            bool encontrado = false;
                                            bool transferido = false;

                                            Console.WriteLine("Transferência / PIX");
                                            Console.WriteLine("\n\nInforme o número da conta (id conta) que receberá a transferência: ");
                                            do
                                            {
                                                try
                                                {
                                                    idtransferencia = int.Parse(Console.ReadLine());
                                                    if (idtransferencia < 0)
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

                                            Conta contarecebe = new Conta();
                                            foreach (var c in agencia.ListaContas)
                                            {
                                                if (c.IdConta == idtransferencia)
                                                {
                                                    contarecebe = c;
                                                    encontrado = true;
                                                    break;
                                                }
                                                encontrado = false;
                                            }

                                            if (encontrado)
                                            {
                                                Console.WriteLine("Informe o valor da Transferência:");
                                                do
                                                {
                                                    try
                                                    {
                                                        valortransferir = int.Parse(Console.ReadLine());
                                                        if (valortransferir < 0)
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

                                                transferido = contaacesso1.Transferir(valortransferir, contaacesso1.Saldo, contaacesso1.Limite, idtransferencia, contaacesso1, contarecebe);

                                                if (transferido)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Valor de " + valortransferir + " reais transferido com sucesso!");
                                                    contaacesso1.Extrato.Add("Transferido " + valortransferir + " reais  para " + idtransferencia + " " + System.DateTime.Now);
                                                    contarecebe.Extrato.Add("Recebido Transferência de " + valortransferir + " reais  de conta " + contaacesso1.IdConta + " " + System.DateTime.Now);
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Transferência não realizada por falta de saldo");
                                                    Console.ReadKey();
                                                }

                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Esse numero de conta não existe.");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            break;

                                        case 5:
                                            //essa versão não está considerando vencimento do cartão para pagamento
                                            if (contaacesso1.Cartao.FuncaoCredito)
                                            {
                                                float pagamento = 0;
                                                Console.WriteLine("Insira o valor do pagamento: ");

                                                do
                                                {
                                                    try
                                                    {
                                                        pagamento = float.Parse(Console.ReadLine());

                                                        if (pagamento < 0)
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

                                                if (pagamento <= contaacesso1.Cartao.Limite)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Dados do cartão\n\n");
                                                    Console.WriteLine(contaacesso1.Cartao.ToString());
                                                    string escolha = "";

                                                    do
                                                    {
                                                        Console.WriteLine("\n\nDeseja realmente Realizar uma compra com o cartão de crédito?\nDigite S para sim ou C para cancelar");
                                                        try
                                                        {
                                                            escolha = Console.ReadLine().ToUpper();

                                                            if (escolha == "S" || escolha == "C")
                                                                validado = true;
                                                            else
                                                            {
                                                                Console.WriteLine("Digite apenas a letra S para sim ou a letra C para cancelar");
                                                                validado = false;
                                                            }
                                                        }
                                                        catch (Exception)
                                                        {
                                                            Console.WriteLine("Insira um valor válido!");
                                                            validado = false;
                                                        }
                                                    } while (validado == false);

                                                    if (escolha == "S")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Pagamento realizado com sucesso!\n\n");
                                                        contaacesso1.Cartao.Extrato.Add("Realizado pagamento de " + pagamento + " reais " + System.DateTime.Now);
                                                        contaacesso1.Cartao.Limite = contaacesso1.Cartao.Limite - pagamento;
                                                        contaacesso1.Cartao.Fatura = pagamento;
                                                        Console.WriteLine("Limite atual do cartão: " + contaacesso1.Cartao.Limite + " reais ");
                                                        Console.WriteLine("Fatura atual do cartão: " + contaacesso1.Cartao.Fatura + " reais ");
                                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                        Console.ReadKey();
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Cartão não tem limite para esse pagamento!");
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Cartão Bloqueado!");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            break;


                                        case 6:                                            
                                            float valoraprovado = contaacesso1.PessoaJuridica.PedirEmprestimo(contaacesso1.PessoaJuridica.FaturamentoMensal);

                                            if (valoraprovado == 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Empréstimo negado!");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                contaacesso1.Depositar(valoraprovado);
                                                Console.Clear();
                                                Console.WriteLine("Empréstimo aprovado!\nO dinheiro foi depositado em sua conta.");
                                                contaacesso1.Extrato.Add("Depósito de empréstimo do banco " + valoraprovado + " reais " + System.DateTime.Now);
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            break;

                                        case 7:                                            
                                            contaacesso1.ExibirExtrato();
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            break;

                                        case 8:                                            
                                            if (contaacesso1.Cartao.FuncaoCredito == false)
                                            {
                                                contaacesso1.Cartao.FuncaoCredito = true;
                                                Console.WriteLine("Cartão Desbloqueado");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                contaacesso1.Cartao.FuncaoCredito = false;
                                                Console.WriteLine("Cartão Bloqueado");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }

                                            break;

                                        case 9:                                            
                                            Console.WriteLine("O limite atual disponível do cartão de crédito é de: " + contaacesso1.Cartao.Limite + " reais");
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            break;

                                        case 10:                                            
                                            contaacesso1.Cartao.GerarFatura();
                                            break;


                                        case 11:
                                            string opcao = "";
                                            
                                            do
                                            {
                                                Console.WriteLine("Deseja realmente trocar a senha?\nDigite S para sim ou C para cancelar");
                                                try
                                                {
                                                    opcao = Console.ReadLine().ToUpper();

                                                    if (opcao == "S" || opcao == "C")
                                                        validado = true;
                                                    else
                                                    {
                                                        Console.WriteLine("Digite apenas a letra S para sim ou a letra C para cancelar");
                                                        validado = false;
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Insira um valor válido!");
                                                    validado = false;
                                                }
                                            } while (validado == false);

                                            if (opcao == "S")
                                            {
                                                int senhanova = 0;
                                                Console.Clear();
                                                do
                                                {
                                                    Console.WriteLine("Digite a nova senha de 6 números: ");
                                                    try
                                                    {
                                                        senhanova = int.Parse(Console.ReadLine());
                                                        if (senhanova < 0)
                                                        {
                                                            Console.WriteLine("Insira um valor válido!");
                                                            validado = false;
                                                        }
                                                        else
                                                        {
                                                            if (senhanova.ToString().Length != 6)
                                                            {
                                                                Console.WriteLine("A senha deve conter 6 numeros.");
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

                                                contaacesso1.Senha = senhanova.ToString();

                                                Console.Clear();
                                                Console.WriteLine("Senha alterada com sucesso!\nNova senha: " + senhanova);
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            break;

                                        case 12:
                                            Console.WriteLine(contaacesso1.ToString());
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            break;

                                        case 13:    
                                            if (contaacesso1.Cartao.Fatura == 0)
                                            {
                                                Console.WriteLine("O valor da fatura está zerado");
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Informação: Não é possível pagar com o valor do cheque especial\n\n");
                                                if (contaacesso1.Cartao.Fatura <= contaacesso1.Saldo)
                                                {
                                                    contaacesso1.Extrato.Add("Pagamento limite cartão de crédito " + contaacesso1.Cartao.Fatura + " reais " + " " + System.DateTime.Now);
                                                    Console.WriteLine("Saldo anterior: " + contaacesso1.Saldo + " reais");
                                                    contaacesso1.Saldo = contaacesso1.Saldo - contaacesso1.Cartao.Fatura;
                                                    contaacesso1.Cartao.Fatura = 0;
                                                    contaacesso1.Cartao.Limite = 25000;

                                                    Console.WriteLine("Saldo atual: " + contaacesso1.Saldo + " reais");
                                                    Console.WriteLine("\nFatura paga com sucesso!");
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nSua conta não possui saldo para o pagamento da fatura do cartão\n");
                                                    Console.WriteLine("Saldo atual: " + contaacesso1.Saldo + " reais\n");
                                                    contaacesso1.Cartao.GerarFatura();
                                                }
                                            } 
                                            break;

                                        case 14:                                            
                                            foreach (var e in contaacesso1.Cartao.Extrato)
                                            {
                                                Console.WriteLine(e);
                                            }
                                            Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                            Console.ReadKey();
                                            break;


                                        case 0:

                                            break;
                                    }


                                } while (opc != 0);
                            }



















                            else
                            {
                                if (conta is PoupancaPF contaacesso2)
                                {
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nConta Poupanca Pessoa Física: " + contaacesso2.IdConta + "\n");

                                        Console.WriteLine("1 - Consultar o saldo da conta");//
                                        Console.WriteLine("2 - Depositar dinheiro na conta");//
                                        Console.WriteLine("3 - Sacar dinheiro da conta");//
                                        Console.WriteLine("4 - Exibir extrato de todas as operações da conta");//
                                        Console.WriteLine("5 - Alterar senha de acesso");//
                                        Console.WriteLine("6 - Exibir dados da conta");


                                        Console.WriteLine("\n\n0 - Encerrar Sessão");//

                                        do
                                        {
                                            try
                                            {
                                                opc = int.Parse(Console.ReadLine());
                                                if (opc < 0 || opc > 6)
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


                                        Console.Clear();

                                        switch (opc)
                                        {
                                            case 1:                                                
                                                Console.WriteLine(contaacesso2.ConsultarSaldo());
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;

                                            case 2:
                                                float valordeposito = 0;                                               
                                                Console.WriteLine("Depósito:");
                                                Console.WriteLine("Informe o valor a ser depositado na conta:");
                                                do
                                                {
                                                    try
                                                    {
                                                        valordeposito = int.Parse(Console.ReadLine());
                                                        if (valordeposito < 0)
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

                                                contaacesso2.Depositar(valordeposito);

                                                Console.Clear();
                                                Console.WriteLine("Valor " + valordeposito + " depositado com sucesso!");
                                                contaacesso2.Extrato.Add("Depósito " + valordeposito + " reais " + System.DateTime.Now);
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;

                                            case 3:
                                                float valorsaque = 0;                                                
                                                Console.WriteLine("Saque:");
                                                Console.WriteLine("Informe o valor de saque:");
                                                do
                                                {
                                                    try
                                                    {
                                                        valorsaque = int.Parse(Console.ReadLine());
                                                        if (valorsaque < 0)
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

                                                bool sacado = contaacesso2.Sacar(valorsaque, contaacesso2.Saldo);

                                                if (sacado)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Valor " + valorsaque + " retirado da conta com sucesso!");
                                                    contaacesso2.Extrato.Add("Saque " + valorsaque + " reais " + System.DateTime.Now);
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Saldo insuficiente!");
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                                break;



                                            case 4:
                                                contaacesso2.ExibirExtrato();
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                                break;

                                            case 5:
                                                string opcao = "";                                                
                                                do
                                                {
                                                    Console.WriteLine("Deseja realmente trocar a senha?\nDigite S para sim ou C para cancelar");
                                                    try
                                                    {
                                                        opcao = Console.ReadLine().ToUpper();

                                                        if (opcao == "S" || opcao == "C")
                                                            validado = true;
                                                        else
                                                        {
                                                            Console.WriteLine("Digite apenas a letra S para sim ou a letra C para cancelar");
                                                            validado = false;
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("Insira um valor válido!");
                                                        validado = false;
                                                    }
                                                } while (validado == false);

                                                if (opcao == "S")
                                                {
                                                    int senhanova = 0;
                                                    Console.Clear();
                                                    do
                                                    {
                                                        Console.WriteLine("Digite a nova senha de 6 números: ");
                                                        try
                                                        {
                                                            senhanova = int.Parse(Console.ReadLine());
                                                            if (senhanova < 0)
                                                            {
                                                                Console.WriteLine("Insira um valor válido!");
                                                                validado = false;
                                                            }
                                                            else
                                                            {
                                                                if (senhanova.ToString().Length != 6)
                                                                {
                                                                    Console.WriteLine("A senha deve conter 6 numeros.");
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

                                                    contaacesso2.Senha = senhanova.ToString();

                                                    Console.Clear();
                                                    Console.WriteLine("Senha alterada com sucesso!\nNova senha: " + senhanova);
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                }
                                                break;


                                            case 6:                                                
                                                Console.WriteLine(contaacesso2.ToString());
                                                Console.WriteLine(contaacesso2.PessoaFisica.ToString());
                                                Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                Console.ReadKey();
                                                break;


                                        }
                                    } while (opc != 0);
                                }




























                                else
                                {





                                    if (conta is PoupancaPJ contaacesso3)
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\nConta Poupanca Pessoa Empresarial: " + contaacesso3.IdConta + "\n");

                                            Console.WriteLine("1 - Consultar o saldo da conta");//
                                            Console.WriteLine("2 - Depositar dinheiro na conta");//
                                            Console.WriteLine("3 - Sacar dinheiro da conta");//
                                            Console.WriteLine("4 - Exibir extrato de todas as operações da conta");//
                                            Console.WriteLine("5 - Alterar senha de acesso");//
                                            Console.WriteLine("6 - Exibir dados da conta");


                                            Console.WriteLine("\n\n0 - Encerrar Sessão");//

                                            do
                                            {
                                                try
                                                {
                                                    opc = int.Parse(Console.ReadLine());
                                                    if (opc < 0 || opc > 6)
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


                                            Console.Clear();

                                            switch (opc)
                                            {
                                                case 1:                                                    
                                                    Console.WriteLine(contaacesso3.ConsultarSaldo());
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;

                                                case 2:
                                                    float valordeposito = 0;                                                    
                                                    Console.WriteLine("Depósito:");
                                                    Console.WriteLine("Informe o valor a ser depositado na conta:");
                                                    do
                                                    {
                                                        try
                                                        {
                                                            valordeposito = int.Parse(Console.ReadLine());
                                                            if (valordeposito < 0)
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

                                                    contaacesso3.Depositar(valordeposito);

                                                    Console.Clear();
                                                    Console.WriteLine("Valor " + valordeposito + " depositado com sucesso!");
                                                    contaacesso3.Extrato.Add("Depósito " + valordeposito + " reais " + System.DateTime.Now);
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;

                                                case 3:
                                                    float valorsaque = 0;                                                    
                                                    Console.WriteLine("Saque:");
                                                    Console.WriteLine("Informe o valor de saque:");
                                                    do
                                                    {
                                                        try
                                                        {
                                                            valorsaque = int.Parse(Console.ReadLine());
                                                            if (valorsaque < 0)
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

                                                    bool sacado = contaacesso3.Sacar(valorsaque, contaacesso3.Saldo);

                                                    if (sacado)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Valor " + valorsaque + " retirado da conta com sucesso!");
                                                        contaacesso3.Extrato.Add("Saque " + valorsaque + " reais " + System.DateTime.Now);
                                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Saldo insuficiente!");
                                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }
                                                    break;



                                                case 4:
                                                    contaacesso3.ExibirExtrato();
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                    break;

                                                case 5:
                                                    string opcao = "";                                                    
                                                    do
                                                    {
                                                        Console.WriteLine("Deseja realmente trocar a senha?\nDigite S para sim ou C para cancelar");
                                                        try
                                                        {
                                                            opcao = Console.ReadLine().ToUpper();

                                                            if (opcao == "S" || opcao == "C")
                                                                validado = true;
                                                            else
                                                            {
                                                                Console.WriteLine("Digite apenas a letra S para sim ou a letra C para cancelar");
                                                                validado = false;
                                                            }
                                                        }
                                                        catch (Exception)
                                                        {
                                                            Console.WriteLine("Insira um valor válido!");
                                                            validado = false;
                                                        }
                                                    } while (validado == false);

                                                    if (opcao == "S")
                                                    {
                                                        int senhanova = 0;
                                                        Console.Clear();
                                                        do
                                                        {
                                                            Console.WriteLine("Digite a nova senha de 6 números: ");
                                                            try
                                                            {
                                                                senhanova = int.Parse(Console.ReadLine());
                                                                if (senhanova < 0)
                                                                {
                                                                    Console.WriteLine("Insira um valor válido!");
                                                                    validado = false;
                                                                }
                                                                else
                                                                {
                                                                    if (senhanova.ToString().Length != 6)
                                                                    {
                                                                        Console.WriteLine("A senha deve conter 6 numeros.");
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

                                                        contaacesso3.Senha = senhanova.ToString();

                                                        Console.Clear();
                                                        Console.WriteLine("Senha alterada com sucesso!\nNova senha: " + senhanova);
                                                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                        Console.ReadKey();
                                                    }
                                                    break;


                                                case 6:                                                    
                                                    Console.WriteLine(contaacesso3.ToString());
                                                    Console.WriteLine(contaacesso3.PessoaJuridica.ToString());
                                                    Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                                                    Console.ReadKey();
                                                    break;
                                            }
                                        } while (opc != 0);
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Essa conta se encontra inativa! Favor falar com gerente");
                        Console.WriteLine("\n\nPRESSIONE ENTER PARA VOLTAR!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }

        }
    }
}
