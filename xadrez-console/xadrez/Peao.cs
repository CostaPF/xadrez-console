using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeIninmigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;

        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                //1
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //2
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);

                if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {

                    mat[pos.linha, pos.coluna] = true;
                }
                //3
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeIninmigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                //4
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeIninmigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }


                // #jogada especial en passant
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeIninmigo(esquerda) && tab.peca(esquerda) == partida.vuneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }
                    
                        Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                        if (tab.posicaoValida(direita) && existeIninmigo(direita) && tab.peca(direita) == partida.vuneravelEnPassant)
                        {
                            mat[direita.linha - 1, direita.coluna] = true;
                        }
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
                    Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                    if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
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

                    // #jogada especial en passant
                    if(posicao.linha == 4) 
                    {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if(tab.posicaoValida(esquerda) && existeIninmigo(esquerda) && tab.peca(esquerda) == partida.vuneravelEnPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && existeIninmigo(direita) && tab.peca(direita) == partida.vuneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                

                }
            }

            return mat;
        }
    }
}

