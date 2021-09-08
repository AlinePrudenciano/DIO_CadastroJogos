using System;
using System.Collections.Generic;
using System.Text;

namespace DIOJogos
{
    public class JogoRepositorio : IRepositorio<Jogo>
    {
        private List<Jogo> listaJogo = new List<Jogo>();

        public void Atualiza(int id, Jogo game)
        {
            listaJogo[id] = game;
        }

        public void Exclui(int id)
        {
            listaJogo[id].Excluir();
       // sugestão envio de email sempre queum titulo for excluido ou adicionado
        }

        public void Insere(Jogo game)
        {
            listaJogo.Add(game);
        }

        public List<Jogo> Lista()
        {
            return listaJogo;
        }

        public int ProximoId()
        {
            return listaJogo.Count;
        }

        public Jogo RetornaPorId(int id)
        {
            return listaJogo[id];
        }
    }
}
