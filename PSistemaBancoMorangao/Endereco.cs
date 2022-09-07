using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancoMorangao
{
    internal class Endereco
    {
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }


        public Endereco() { }

        public Endereco(string cidade, string rua, string bairro, string numero, string cep, string estado)
        {
            Cidade = cidade;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Cep = cep;
            Estado = estado;
        }

        public override string ToString()
        {
            return "\nEndereço:\n" + this.Rua + ", " + this.Numero + " - " + this.Bairro + " - " + this.Cep + " - " + this.Cidade + " - "  + this.Estado + "\n";
        }

        public string ObterDados()
        {
            return Cidade + ";" + Rua + ";" + Bairro + ";" + Numero + ";" + Cep + ";" + Estado + ";";
        }
    }
}
