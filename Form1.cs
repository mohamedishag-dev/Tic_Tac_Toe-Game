using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen penWhite = new Pen(White, 10);


            penWhite.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penWhite.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            e.Graphics.DrawLine(penWhite, 633, 93, 633, 400);
            e.Graphics.DrawLine(penWhite, 507, 93, 507, 400);

            // Degonale
            e.Graphics.DrawLine(penWhite, 381, 197, 753, 197);
            e.Graphics.DrawLine(penWhite, 381, 303, 753, 303);


        }

        private bool CheckValue(Button btn1, Button btn2, Button btn3)
        {

            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

                else if (btn1.Tag.ToString() == "O")
                {
                    lblWinner.Text = "Player 2";
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }


            GameStatus.GameOver = false;
            return false;

        }

        public void CheckWinner()
        {
            // Checked Rows
            // Checked Row 1
            if (CheckValue(button1, button2, button3))
                return;

            // Checked Row 2
            else if (CheckValue(button4, button5, button6)) 
                return;

            // Checked Row 3
            else if (CheckValue(button7, button8, button9)) 
                return;

            // Checked Cols
            // Checked Col 1
            else if (CheckValue(button1, button4, button7))
                return;

            // Checked Col 2
            else if (CheckValue(button2, button5, button8)) 
                return;

            // Checked Col 3
            else if (CheckValue(button3, button6, button9)) 
                return;

            // Checked Diagonls

            // Checked Diagonl 1
            else if (CheckValue(button1, button5, button9)) 
                return;

            // Checked Diagonl 2
            else if (CheckValue(button3, button5, button7)) 
                return;
         
        }

        public void CheckImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {

                switch (PlayerTurn)
                {

                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
               
            }

            else
            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            CheckImage((Button)sender); 
        }
      
        private void EndGame()
        {

            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                break;

                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                break;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            GameStatus.Winner = enWinner.GameInProgress;
            PlayerTurn = enPlayer.Player1;
            GameStatus.GameOver = false;
            GameStatus.PlayCount = 0;
            lblWinner.Text = "In Progress";
            lblTurn.Text = "Player 1";

        }
    }
}