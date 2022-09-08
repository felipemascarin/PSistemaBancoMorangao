# PSistemaBancoMorangao
<Trabalho do branco morangão, proposto em aula.

 <b><i>Sistema de gerenciamento de um banco fictício, exercício proposto em aula.</i></b>





 <b><i> Pré-requisitos para operação desse programa: </i></b>



Sempre que o programa é encerrado, todos os dados das contas são salvos em arquivos txt no destinatário c:\BancoMorangao; 

Sempre que o programa é executado, todos os dados das contas são lidos dos arquivos txt e carregado para dentro do programa; 

É preciso criar uma pasta com o nome BancoMorangao dentro de C: para que o programa salve os dados quando finalizado; 

No Menu do cliente é possível solicitar abertura e fechamento de contas PF e PJ;

É possível acessar as operações da sua conta inserindo id e senha no menu do caixa eletrônico;

No menu do gerente, quando inserida a senha de acesso "123456" é possível filtrar todas as informações das contas existentes por cpf e cnpj, bom também se caso esquecer a senha;

No programa é possível solicitar fechamento de contas, mas só são encerradas se o saldo e a fatura do cartão estiverem zerados;

Sempre que consultar o extrato vai ser mostrado todas as operações realizadas desde a criação da conta, não há filtro de extratos por meses ou dias;

Não existe menu do escriturário nessa versão;

A função transferência só pode ser realizada se existir a conta que vai receber a trensferência;

A conta que recebe a transferência recebe o valor depositado e recebe também as informações da transferência no extrato como transferência recebida, data e hora;






 <b><i>O sistema do banco morangão foi um trabalho proposto em aula, onde foi estipulado os seguintes passos:</i></b>



Desenvolver um diagrama de classes em um grupo de 3 pessoas baseado nos requisitos do enunciado;

Não desenvolver nada de código até o grupo entrar em consenso sobre o diagrama;

Entregar o diagrama de classes no prazo estipulado;

Não pode alterar o diagrama de classes depois de entregue, se for preciso alterar deve ser em consentimento do grupo;

O código deverá ser realizado individualmente e sendo fiel ao diagrama de classes entregue.



 <b><i>Considerações sobre o desenvolvimento:</i></b>



Esse trabalho serviu muito para treinar e praticar os conhecimentos adquiridos; Para seu desenvolvimento foi preciso estudar alguns conceitos novos;

O código realiza as mesmas coisas as vezes de formas diferentes, para aplicação da diversidade de conhecimentos;

Não houve manifestação de algum integrante do grupo durante o desenvolvimento do código sobre alterações no diagrama de classes depois de entregue;

A construção do programa e o conceito de orientação a objeto do código segue fiel ao diagrama de classes entregue;

Não foi utilizado banco de dados, os dados são armazenados em arquivos txt em destinatário específico do sistema operacional;

Não era permitido utilizar classes abstratas e nem interfaces;

Foi preciso utilizar várias funções de menu no programa principal, pois o programa não tem interfaces;

As funções também fazem procedimentos no lugar de métodos que não foram previstos antes no diagrama de classes, por limitação de conhecimento do grupo;

Foi previsto no diagrama de classes que iria existir uma lista do tipo classe mãe que iria guardar vários objetos de 4 tipos de classes filhas;

Além de várias estruturas condicionais a mais, essa lista genérica de classe mãe deixou o cógido pelo menos 5x maior, já que pra acessar os tipos classes filhas teve que sempre realizar o procedimento de filtro por cast utilizando a palavra resevada is, que foi um desafio e um conhecimento a mais adquirido.





 <b><i>Enunciado do trabalho proposto em aula:</i></b>



O Banco Morangão possui diversas agências. As agências também possuem caixas eletrônicos, através dos quais os clientes podem realizar algumas transações: sacar dinheiro, depositar na conta, transferir valores para outra conta, consultar extrato e saldo, realizar pagamentos e solicitar empréstimos. Para se cadastrar no banco, o potencial cliente deve dirigir-se a uma agência física e solicitar a abertura de uma conta. Há três opções de conta: universitária, normal e cliente vip. O funcionário irá avaliar, de acordo com o perfil do cliente e da sua faixa salarial, o tipo de conta que lhe será atribuída. Posteriormente, o gerente da agência deve aprovar ou não a criação da conta. Ressalte-se que, todo cliente do banco possui uma conta corrente, uma conta poupança, um cartão de crédito, que pode ou não ser desbloqueado para uso e um cheque especial (limite), que é um valor em dinheiro atribuído a sua conta e que pode ser consumido caso o cliente deseje ou o saldo da sua conta se torne negativo. O valor do cheque especial é atribuído no momento da criação da conta, de acordo com o tipo de conta e o perfil do cliente.
