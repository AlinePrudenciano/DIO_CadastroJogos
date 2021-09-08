using System;
using System.Collections.Generic;
using System.Text;

namespace DIOJogos
{
    public class Jogo : EntidadeBase
    {
        private object id;
        private int ano;
        private string metacritic;

        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private string Ano { get; set; }
        private decimal Metacritic { get; set; }
        private bool Excluido { get; set; }

        //Metodos
        public Jogo(int id, Genero genero, string titulo, string descricao, int ano, decimal metacritic)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Metacritic = metacritic;
            this.Excluido = false;
        }

        public Jogo(object id, Genero genero, string titulo, int ano, string descricao, string metacritic)
        {
            this.id = id;
            Genero = genero;
            Titulo = titulo;
            this.ano = ano;
            Descricao = descricao;
            this.metacritic = metacritic;
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Classificação Metacritic: " + this.Metacritic + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}