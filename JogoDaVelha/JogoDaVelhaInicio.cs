using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class frmJogo : Form
    {

        string[,] tabuleiro = new string[3, 3];

        public frmJogo()
        {
            InitializeComponent();
        }

        private void frmJogo_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Text = Marcador(lblPlayer.Text);
            tabuleiro[0, 0] = Marcador(lblPlayer.Text);
            btn1.Enabled = false;
            Jogada();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.Text = Marcador(lblPlayer.Text);
            tabuleiro[0, 1] = Marcador(lblPlayer.Text);
            btn2.Enabled = false;
            Jogada();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn3.Text = Marcador(lblPlayer.Text);
            tabuleiro[0, 2] = Marcador(lblPlayer.Text);
            btn3.Enabled = false;
            Jogada();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btn4.Text = Marcador(lblPlayer.Text);
            tabuleiro[1, 0] = Marcador(lblPlayer.Text);
            btn4.Enabled = false;
            Jogada();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btn5.Text = Marcador(lblPlayer.Text);
            tabuleiro[1, 1] = Marcador(lblPlayer.Text);
            btn5.Enabled = false;
            Jogada();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btn6.Text = Marcador(lblPlayer.Text);
            tabuleiro[1, 2] = Marcador(lblPlayer.Text);
            btn6.Enabled = false;
            Jogada();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btn7.Text = Marcador(lblPlayer.Text);
            tabuleiro[2, 0] = Marcador(lblPlayer.Text);
            btn7.Enabled = false;
            Jogada();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btn8.Text = Marcador(lblPlayer.Text);
            tabuleiro[2, 1] = Marcador(lblPlayer.Text);
            btn8.Enabled = false;
            Jogada();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btn9.Text = Marcador(lblPlayer.Text);
            tabuleiro[2, 2] = Marcador(lblPlayer.Text);
            btn9.Enabled = false;
            Jogada();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Inicializar()
        {
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    tabuleiro[l, c] = " ";
                }
            }
            lblPlayer.Text = "1";
            btn1.Enabled = btn2.Enabled = btn3.Enabled =
            btn4.Enabled = btn5.Enabled = btn6.Enabled =
            btn7.Enabled = btn8.Enabled = btn9.Enabled = true;
            btn1.Text = btn2.Text = btn3.Text =
            btn4.Text = btn5.Text = btn6.Text =
            btn7.Text = btn8.Text = btn9.Text = "";
            lblVencedor.Text = "";
        }


        public string Marcador(string jogador)
        {
            return (jogador == "1") ? "X" : "O";
        }
        static bool VerificaVencedor(string[,] matriz, string m)
        {
            bool vencedor = false;
            if ((matriz[0, 0] == m && matriz[0, 1] == m && matriz[0, 2] == m)
                || (matriz[1, 0] == m && matriz[1, 1] == m && matriz[1, 2] == m)
                || (matriz[2, 0] == m && matriz[2, 1] == m && matriz[2, 2] == m)
                || (matriz[0, 0] == m && matriz[1, 0] == m && matriz[2, 0] == m)
                || (matriz[0, 1] == m && matriz[1, 1] == m && matriz[2, 1] == m)
                || (matriz[0, 2] == m && matriz[1, 2] == m && matriz[2, 2] == m)
                || (matriz[0, 0] == m && matriz[1, 1] == m && matriz[2, 2] == m)
                || (matriz[0, 2] == m && matriz[1, 1] == m && matriz[2, 0] == m))
            {
                vencedor = true;
            }
            return vencedor;
        }

        public bool Empate(string[,] matriz)
        {
            bool empate = false;
            int count = 0;
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    if (matriz[l, c] != " ")
                    {
                        count++;
                    }
                }
            }
            if (count == 9)
            {
                empate = true;
            }
            return empate;
        }

        public void AlteraJogador()
        {
            if(lblPlayer.Text == "1")
            {
                lblPlayer.Text = "2";
            }
            else
            {
                lblPlayer.Text = "1";
            }
        }

        public void Jogada()
        {
            if (VerificaVencedor(tabuleiro, Marcador(lblPlayer.Text)))
            {
                lblVencedor.Text = "Jogador " + lblPlayer.Text + " venceu!";
                btn1.Enabled = btn2.Enabled = btn3.Enabled =
                btn4.Enabled = btn5.Enabled = btn6.Enabled =
                btn7.Enabled = btn8.Enabled = btn9.Enabled = false;
            }
            else if (Empate(tabuleiro))
            {
                lblVencedor.Text = "Deu Velha! Empate!";
            }
            else
            {
                AlteraJogador();
            }
        }


    }
}
