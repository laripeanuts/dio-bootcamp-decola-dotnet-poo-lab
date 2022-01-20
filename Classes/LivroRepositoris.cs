using dio.livros.Interfaces;

namespace dio.livros.Classes
{
        public class LivroRepositorio : IRepositorio<Livros>
        {
            private List<Livros> listaLivros = new List<Livros>();
    
            public void Atualiza(int id, Livros entidade)
            {
                listaLivros[id] = entidade;     
            }

            public void Exclui(int id)
            {
                listaLivros[id].Excluir();
            }

            public void Insere(Livros objeto)
            {
                listaLivros.Add(objeto);
            }

            public List<Livros> Lista()
            {
                return listaLivros;
            }

            public int ProximoId()
            {
                return listaLivros.Count;
            }

            public Livros RetornaPorId(int id)
            {
                return listaLivros[id];
            }
        }
    }
