/*
 * Description:     A basic PONG simulator
 * Author:           
 * Date:            
 */

#region libraries

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Diagnostics;

#endregion

namespace Pong
{
    public partial class Form1 : Form
    {
        #region global values

        //graphics objects for drawing
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        Font drawFont = new Font("Courier New", 10);

        // Sounds for game
        SoundPlayer scoreSound = new SoundPlayer(Properties.Resources.score);
        SoundPlayer collisionSound = new SoundPlayer(Properties.Resources.collision);

        //determines whether a key is being pressed or not
        Boolean wKeyDown, sKeyDown, upKeyDown, downKeyDown;

        // check to see if a new game can be started
        Boolean newGameOk = true;

        //ball values
        Boolean ballMoveRight = true;
        Boolean ballMoveDown = true;
        int BALL_SPEED = 4;
        const int BALL_WIDTH = 15;
        const int BALL_HEIGHT = 15;
        Rectangle ball;

        //player values
        const int PADDLE_SPEED = 4;
        const int PADDLE_EDGE = 20;  // buffer distance between screen edge and paddle            
        const int PADDLE_WIDTH = 10;
        const int PADDLE_HEIGHT = 80;
        Rectangle player1, player2;

        Rectangle testFill = new Rectangle(0, 0, 0, 0);

        List<Rectangle> powerUp1;
        List<Rectangle> powerUp2;
        Random randGen = new Random();
        int catcher;

        //player and game scores
        int player1Score = 0;
        int player2Score = 0;
        int gameWinScore = 2;  // number of points needed to win game

        bool p1Confirm = false;
        bool p2Confirm = false;

        int p1Counter;
        int p2Counter;

        int p1Slower;
        int p2Slower;

        bool betweenConfirm = false;

        int player1Speed = 0;
        int player2Speed = 0;

        bool p1JumpMode = false;
        bool p2JumpMode = false;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (p1JumpMode == false)
                    {
                        wKeyDown = true;
                        p1Speed.Start();
                    }
                    else if (player1.Y >= this.Height - player1.Height - 20 && player1.Y <= this.Height - player1.Height + 2)
                    {
                        p1Speed.Start();
                    }
                    break;
                case Keys.S:
                    if (p1JumpMode == false)
                    {
                        sKeyDown = true;
                        p1Speed.Start();
                    }
                    break;
                case Keys.Up:
                    if (p2JumpMode == false)
                    {
                        upKeyDown = true;
                        p2Speed.Start();
                    }
                    else if (player2.Y >= this.Height - player2.Height - 20 && player2.Y <= this.Height - player2.Height + 2)
                    {
                        p2Speed.Start();
                    }
                    break;
                case Keys.Down:
                    if (p2JumpMode == false)
                    {
                        downKeyDown = true;
                        p2Speed.Start();
                    }
                    break;
                case Keys.Y:
                case Keys.Space:
                    if (newGameOk)
                    {
                        SetParameters();
                    }
                    break;
                case Keys.Escape:
                    if (newGameOk)
                    {
                        Application.Exit();
                    }
                    break;
            }
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.W:
                    wKeyDown = false;
                    p1Speed.Stop();
                    p1Counter = 0;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    p1Speed.Stop();
                    p1Counter = 0;
                    break;
                case Keys.Up:
                    upKeyDown = false;
                    p2Speed.Stop();
                    p2Counter = 0;
                    break;
                case Keys.Down:
                    downKeyDown = false;
                    p2Speed.Stop();
                    p2Counter = 0;
                    break;
            }
        }

        private void ballUpSpeed_Tick(object sender, EventArgs e)
        {
            BALL_SPEED++;
        }

        private void p1Speed_Tick(object sender, EventArgs e)
        {
            p1Counter++;
            if (p1JumpMode == false && p1Counter >= 4)
            {
                if (wKeyDown == true)
                {
                    p1Counter = 0;
                    //up speed in that direction
                    player1Speed -= 1;
                }
                else
                {
                    p1Counter = 0;
                    //up speed in that direction
                    player1Speed += 1;
                }
            }
            else if (p1JumpMode == true)
            {
                player1Speed -= 4;
                if (player1Speed <= -12) 
                {
                    player1Speed = -12;
                }
                if (player1.Y <= this.Height / 2 - 50)
                {
                    p1Speed.Stop(); 
                }
            }
        }

        private void p2Speed_Tick(object sender, EventArgs e)
        {
            p2Counter++;
            if (p2JumpMode == false && p2Counter >= 4)
            {
                if (upKeyDown == true)
                {
                    p2Counter = 0;
                    //up speed in that direction
                    player2Speed -= 1;
                }
                else
                {
                    p2Counter = 0;
                    //up speed in that direction
                    player2Speed += 1;
                }
            }
            else if (p2JumpMode == true)
            {
                player2Speed -= 4;
                if (player2Speed <= -12)
                {
                    player2Speed = -12;
                }
                if (player2.Y <= this.Height / 2 - 50)
                {
                    p2Speed.Stop();
                }
            }
        }

        /// <summary>
        /// sets the ball and paddle positions for game start
        /// </summary>
        private void SetParameters()
        {
            if (newGameOk)
            {
                player1Score = player2Score = 0;
                player1ScoreLabel.Text = "0";
                player2ScoreLabel.Text = "0";
                newGameOk = false;
                startLabel.Visible = false;

                gameUpdateLoop.Start();
            }

            //player start positions
            player1 = new Rectangle(PADDLE_EDGE, this.Height - PADDLE_HEIGHT, PADDLE_WIDTH, PADDLE_HEIGHT);
            player2 = new Rectangle(this.Width - PADDLE_EDGE - PADDLE_WIDTH, this.Height / 2 - PADDLE_HEIGHT / 2, PADDLE_WIDTH, PADDLE_HEIGHT);

            // TODO create a ball rectangle in the middle of screen
            ball = new Rectangle(this.Width / 2, this.Height / 2, BALL_WIDTH, BALL_HEIGHT);

            p1Ready.ForeColor = Color.Firebrick;
            p2Ready.ForeColor = Color.Firebrick;

            p1Confirm = false;
            p2Confirm = false;

            p1Ready.Visible = true;
            p2Ready.Visible = true;

            BALL_SPEED = 3;
            betweenConfirm = false;

            player1Speed = 0;
            player2Speed = 0;

            p1JumpMode = false;
            p2JumpMode = false;
        }

        /// <summary>
        /// This method is the game engine loop that updates the position of all elements
        /// and checks for collisions.
        /// </summary>
        private void gameUpdateLoop_Tick(object sender, EventArgs e)
        {

            if (p1Confirm == false || p2Confirm == false)
            {
                    if (wKeyDown == true || sKeyDown == true)
                    {
                        p1Confirm = true;
                        p1Ready.ForeColor = Color.Green;
                    }

                    if (upKeyDown == true || downKeyDown == true)
                    {
                        p2Confirm = true;
                        p2Ready.ForeColor = Color.Green;
                    }
            }
            else if (betweenConfirm == false)
            {
                betweenConfirm = true;

                ballUpSpeed.Start();
                //p2JumpMode = true;
                p1JumpMode = true;
            }
            else
            {
                p1Ready.Visible = false;
                p2Ready.Visible = false;

                #region update ball position

                // TODO create code to move ball either left or right based on ballMoveRight and using BALL_SPEED
                if (ballMoveRight == true)
                {
                    ball.X += BALL_SPEED;
                }
                else
                {
                    ball.X -= BALL_SPEED;
                }

                // TODO create code move ball either down or up based on ballMoveDown and using BALL_SPEED
                if (ballMoveDown == true)
                {
                    ball.Y += BALL_SPEED;
                }
                else
                {
                    ball.Y -= BALL_SPEED;
                }

                #endregion

                #region update paddle positions

                if (p1JumpMode == true)
                {
                    //player 1 gravity mechanic
                    if (wKeyDown == false)
                    {
                        p1Slower++;
                        if (p1Slower >= 2)
                        {
                            player1Speed++;
                            p1Slower = 0;
                        }
                    }

                    player1.Y += player1Speed;

                    // Bounce
                    if (player1.Y > this.Height - player1.Height)
                    {
                        player1.Y = this.Height - player1.Height;
                        player1Speed = -player1Speed + 4;
                    }
                }
                else
                {
                    //player 1 slowing mechanic
                    if (wKeyDown == false && sKeyDown == false)
                    {
                        p1Slower++;
                        if (p1Slower >= 5)
                        {
                            if (player1Speed > 0)
                            {
                                player1Speed--;
                            }
                            else if (player1Speed < 0)
                            {
                                player1Speed++;
                            }

                            p1Slower = 0;
                        }
                    }

                    // TODO create code to move player 1 up
                    player1.Y += player1Speed;

                    // TODO create an if statement and code to move player 1 down 
                    if (player1.Y < 0)
                    {
                        player1.Y = 0;
                        player1Speed = Math.Abs(player1Speed);
                    }
                    else if (player1.Y > this.Height - player1.Height)
                    {
                        player1.Y = this.Height - player1.Height;
                        if (player1Speed > 0)
                        {
                            player1Speed = -player1Speed;
                        }
                    }
                }

                if (p2JumpMode == true)
                {
                    //player 1 gravity mechanic
                    if (upKeyDown == false)
                    {
                        p2Slower++;
                        if (p2Slower >= 2)
                        {
                            player2Speed++;
                            p2Slower = 0;
                        }
                    }

                    player2.Y += player2Speed;

                    // Bounce
                    if (player2.Y > this.Height - player2.Height)
                    {
                        player2.Y = this.Height - player2.Height;
                        player2Speed = -player2Speed + 4;
                    }
                }
                else
                {
                    //player 2 slowing mechanic
                    if (upKeyDown == false && downKeyDown == false)
                    {
                        p2Slower++;
                        if (p2Slower >= 5)
                        {
                            if (player2Speed > 0)
                            {
                                player2Speed--;
                            }
                            else if (player2Speed < 0)
                            {
                                player2Speed++;
                            }

                            p2Slower = 0;
                        }
                    }
                    //constantly update speed
                    player2.Y += player2Speed;

                    if (player2.Y < 0)
                    {
                        player2.Y = 0;
                        player2Speed = Math.Abs(player2Speed);
                    }
                    else if (player2.Y > this.Height - player2.Height)
                    {
                        player2.Y = this.Height - player2.Height;
                        if (player2Speed > 0)
                        {
                            player2Speed = -player2Speed;
                        }
                    }
                }

                //player2ScoreLabel.Text = player2Speed.ToString();
                //player1ScoreLabel.Text = player1Speed.ToString();
                

                #endregion

                #region ball collision with top and bottom lines

                if (ball.Y < 0) // if ball hits top line
                {
                    // TODO use ballMoveDown boolean to change direction
                    // TODO play a collision sound

                    collisionSound.Play();
                    ballMoveDown = true;
                }
                // TODO In an else if statement check for collision with bottom line
                // If true use ballMoveDown boolean to change direction
                else if (ball.Y > this.Height - 7)
                {
                    collisionSound.Play();
                    ballMoveDown = false;
                }

                #endregion

                #region ball collision with paddles

                // TODO create if statment that checks if player1 collides with ball and if it does
                // --- play a "paddle hit" sound and
                // --- use ballMoveRight boolean to change direction

                if (ball.IntersectsWith(player1))
                {
                    collisionSound.Play();
                    ballMoveRight = true;
                }

                //for (int i = 0; i < powerUp2.Count; i++)
                //{
                //    //powerUp2[i].X += 5;
                //}

                // TODO create if statment that checks if player2 collides with ball and if it does
                // --- play a "paddle hit" sound and
                // --- use ballMoveRight boolean to change direction

                if (ball.IntersectsWith(player2))
                {
                    collisionSound.Play();
                    ballMoveRight = false;
                }

                /*  ENRICHMENT
                 *  Instead of using two if statments as noted above see if you can create one
                 *  if statement with multiple conditions to play a sound and change direction
                 */

                #endregion

                #region ball collision with side walls (point scored)


                if (ball.X < 0)  // ball hits left wall logic
                {
                    player2Score += 1;
                    player2ScoreLabel.Text = player2Score.ToString();

                    ballMoveRight = true;

                    scoreSound.Play();
                    // TODO
                    // --- play score sound
                    // --- update player 2 score and display it to the label

                    // TODO use if statement to check to see if player 2 has won the game. If true run 
                    // GameOver() method. Else change direction of ball and call SetParameters() method.

                    if (player2Score >= 3)
                    {
                        GameOver("Player 2");
                    }
                    else
                    {
                        SetParameters();
                    }
                }

                // TODO same as above but this time check for collision with the right wall
                if (ball.X > this.Width)
                {
                    player1Score += 1;
                    player1ScoreLabel.Text = player1Score.ToString();

                    ballMoveRight = false;

                    scoreSound.Play();

                    if (player1Score >= 3)
                    {
                        GameOver("Player 1");
                    }
                    else
                    {
                        SetParameters();
                    }
                }

                #endregion
            }

            //refresh the screen, which causes the Form1_Paint method to run
            this.Refresh();
        }
        
        /// <summary>
        /// Displays a message for the winner when the game is over and allows the user to either select
        /// to play again or end the program
        /// </summary>
        /// <param name="winner">The player name to be shown as the winner</param>
        private void GameOver(string winner)
        {
            newGameOk = true;

            // TODO create game over logic
            // --- stop the gameUpdateLoop
            // --- show a message on the startLabel to indicate a winner, (may need to Refresh).
            // --- use the startLabel to ask the user if they want to play again

            gameUpdateLoop.Stop();

            startLabel.Visible = true;

            startLabel.Text = winner + " Wins!";
            startLabel.Text += " Press Space to Play Again.";

            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // TODO draw player2 using FillRectangle
            e.Graphics.FillRectangle(whiteBrush, player1);
            e.Graphics.FillRectangle(whiteBrush, player2);

            // TODO draw ball using FillRectangle
            e.Graphics.FillRectangle(whiteBrush, ball);


                //for (int i = 0; i < powerUp1.Count; i++)
                //{
                //    e.Graphics.FillRectangle(orangeBrush, powerUp1[i]);
                //}
                //for (int i = 0; i < powerUp2.Count; i++)
                //{
                //    e.Graphics.FillRectangle(orangeBrush, powerUp2[i]);
                //}
        }
    }
}
