using System;
namespace DIO.Registro
{
    public class Colaborador:EntidadeBase
    {
        private Tipo Contrato {get; set;}
        private string Nome {get; set;}
        private string Setor {get;set;}
        private int Matricula {get; set;}
        private bool Status {get; set;}

        public Colaborador(int id, Tipo contrato, string nome, string setor, int matricula)
        {
            this.Id = id;
            this.Contrato = contrato;
            this.Nome = nome;
            this.Setor = setor;
            this.Matricula = matricula;
            this.Status = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Setor: " + this.Setor + Environment.NewLine;
            retorno += "Contrato: " + this.Contrato + Environment.NewLine;
            retorno += "Matrícula: " + this.Matricula + Environment.NewLine;
            retorno += "Demitido?: " + this.Status;
            return retorno;
        }

        public string RetornaNome()
        {
            return this.Nome;
        }

        public int RetornaId()
        {
            return this.Id;
        }
        public bool RetornaStatus()
        {
            return this.Status;
        }

        public void Excluir()
        {
            this.Status = true;
        }
    }
}