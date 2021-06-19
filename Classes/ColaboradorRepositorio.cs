using DIO.Registro.Interfaces;
using System;
using System.Collections.Generic;
namespace DIO.Registro
{
    public class ColaboradorRepositorio : IRepositorio<Colaborador>
    {
        private List<Colaborador> listaColaboradores = new List<Colaborador>();
        public void Atualiza(int id, Colaborador entidade)
        {
            listaColaboradores[id] = entidade;
        }
        public void Exclui(int id) 
        {   
            listaColaboradores[id].Excluir();
        }
        public void Insere(Colaborador entidade)
        {
            listaColaboradores.Add(entidade);
        }
        public List<Colaborador> Lista()
        {
            return listaColaboradores;
        }
        public int ProximoId()
        {
            return listaColaboradores.Count;
        }
        public Colaborador RetornaPorId(int id) 
        {
            return listaColaboradores[id];
        }
    }
}