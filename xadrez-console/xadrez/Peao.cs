using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeIninmigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
           return tab.peca(pos) == null;
            
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if(cor == Cor.Branca)
            {
                //1
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if(tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //2
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //3
                pos.definirValores(posicao.linha - 1, posicao.coluna -1);
                if (tab.posicaoValida(pos) && existeIninmigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //4
                pos.definirValores(posicao.linha - 1, posicao.coluna +1);
                if (tab.posicaoValida(pos) && existeIninmigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

            }
            else
            {
                //1
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //2
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //3
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeIninmigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //4
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeIninmigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

            }

            return mat;
        }
    }
}

