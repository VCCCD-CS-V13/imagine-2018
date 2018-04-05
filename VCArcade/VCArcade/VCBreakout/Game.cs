﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using VCArcade.VCBreakout.Objects;
using VCArcade.VCBreakout.Helpers;

namespace VCArcade.VCBreakout
{
    public partial class frmBreakout : Form
    {

        #region PROPERTIES

        public int score { get; set; }

        public int lives { get; set; }

        public int level { get; set; }

        private System.Windows.Media.MediaPlayer bgm { get; set; }

        private BGState bgState { get; set; }

        private Ticker ticker { get; set; }

        private Ball ball { get; set; }

        private Paddle paddle { get; set; }

        #endregion

        #region FORM INITALIZER

        public frmBreakout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start the background music.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGame_Load(object sender, EventArgs e)
        {
            bgState = BGState.Menu;

            bgm = new System.Windows.Media.MediaPlayer();

            bgm.MediaEnded += new EventHandler(bgm_Loop);

            bgm.Open(new System.Uri(@"..\\Resources\\Mars.wav", UriKind.Relative));

            bgm.Play();

            Cursor.Show();
        }

        private void bgm_Loop(object sender, EventArgs e)
        {
            if (this.bgState == BGState.Menu)
            {
                bgm.Open(new System.Uri(@"..\\Resources\\Mars.wav"));

                bgm.Play();
            }
            else if (this.bgState == BGState.Level)
            {
                bgm.Open(new System.Uri(@"..\\Resources\\Map.wav"));

                bgm.Play();
            }
        }

        /// <summary>
        /// Override the default event for pressing the esccape key.
        /// This allows the escape key to be used to pause the game.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                pauseGame();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region FORM CONTROL EVENTS

        /// <summary>
        /// Hide the start screen UI components and start the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            hideMenuUI();

            initGame();
        }

        /// <summary>
        /// Unpause the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResume_Click(object sender, EventArgs e)
        {
            unPauseGame();
        }

        /// <summary>
        /// Exit the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Set the score to 0 and start a new game by showing the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetry_Click(object sender, EventArgs e)
        {
            score = 0;

            lblScoreCounter.Text = score.ToString();

            newGameMenu();
        }

        /// <summary>
        /// The main run of the program. Every tick the ball will move and check for collisions.
        /// The paddle will track the movement of the cursor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ticker_Tick(object sender, EventArgs e)
        {
            paddle.Left = Cursor.Position.X - (paddle.Width / 2);

            ball.Left += ball.hSpeed;

            ball.Top += ball.vSpeed;

            if (ball.Bottom >= paddle.Top && ball.Bottom <= paddle.Bottom && ball.Left >= paddle.Left && ball.Right <= paddle.Right)
            {
                ball.HitPaddle();

                updateScore(5);
            }

            if (ball.Left <= gameBoard.Left || ball.Right >= gameBoard.Right)
            {
                ball.HitWall(Sides.RightOrLeft);
            }

            if (ball.Top <= gameBoard.Top || ball.Bottom >= gameBoard.Bottom)
            {
                ball.HitWall(Sides.TopOrBottom);
            }

            if (ball.Bottom >= gameBoard.Bottom)
            {
                loseLife();
            }
        }

        #endregion

        #region CLASS INITIALIZERS

        /// <summary>
        /// Set the scoreboard and draw the game elements.
        /// </summary>
        private void initGame()
        {
            bgState = BGState.Level;

            bgm.Stop();
            
            bgm.Open(new System.Uri(@"..\\Resources\\Map.wav"));

            bgm.Play();

            initScores();

            initBricks();

            initPaddle();

            initBall();

            initTicker();
        }

        /// <summary>
        /// Load all the bricks on the board. There will be 5 rows of 12 bricks per level.
        /// </summary>
        private void initBricks()
        {

        }

        /// <summary>
        /// Put the paddle on the gameboard.
        /// </summary>
        private void initPaddle()
        {
            paddle = new Paddle(gameBoard);

            paddle.Draw();
        }

        /// <summary>
        /// Invoke the ball class to draw it on the game screen and begin its movement.
        /// </summary>
        private void initBall()
        {
            ball = new Ball(gameBoard);

            ball.Draw();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        private void initTicker()
        {
            ticker = new Ticker();

            ticker.Tick += new EventHandler(ticker_Tick);

            ticker.Start();
        }

        /// <summary>
        /// Setup the initial score board values with score of 0, level 1 and 5 lives.
        /// </summary>
        private void initScores()
        {
            score = 0;

            level = 1;

            lives = 5;

            lblScoreCounter.Text = score.ToString();

            lblLevelCounter.Text = level.ToString();

            lblLivesCounter.Text = lives.ToString();
        }

        #endregion

        #region HELPER METHODS

        /// <summary>
        /// Hide everything on the loading screen except the score board.
        /// </summary>
        private void hideMenuUI()
        {
            Cursor.Hide();

            btnStart.Visible = false;

            btnHelp.Visible = false;

            lblTitle.Visible = false;

            lblTitleB.Visible = false;

            lblTitleT.Visible = false;
        }

        /// <summary>
        /// When a new game is started, show the main menu.
        /// </summary>
        private void newGameMenu()
        {
            bgm.Stop();

            bgm = new System.Windows.Media.MediaPlayer();

            bgm.Open(new System.Uri(@"..\\Resources\\Map.wav"));

            bgm.Play();

            Cursor.Hide();

            btnRetry.Visible = false;

            btnStart.Visible = true;

            btnHelp.Visible = true;

            lblTitle.Visible = true;

            lblTitleB.Visible = true;

            lblTitleT.Visible = true;
        }

        /// <summary>
        /// Stop the timer object and bring up a UI to interact with the game while paused.
        /// </summary>
        private void pauseGame()
        {
            ticker.Stop();

            hideGameElements();

            showPauseUI();

            Cursor.Show();
        }

        /// <summary>
        /// Hide the ball, paddle and bricks while the game is paused.
        /// </summary>
        private void hideGameElements()
        {
            ball.Visible = false;

            paddle.Visible = false;
        }

        /// <summary>
        /// Shows the resume and quit buttons after hiding other game elements.
        /// </summary>
        private void showPauseUI()
        {
            btnResume.Visible = true;

            btnResume.Left = btnStart.Left;

            btnResume.Top = btnStart.Top;

            btnQuit.Visible = true;

            btnQuit.Left = btnHelp.Left;

            btnQuit.Top = btnHelp.Top;
        }

        /// <summary>
        /// Hide the pause menu and resume the timer object.
        /// </summary>
        private void unPauseGame()
        {
            showGameElements();

            hidePauseUI();

            Cursor.Hide();

            ticker.Start();
        }

        /// <summary>
        /// Hides the pause menu when resume is clicked.
        /// </summary>
        private void hidePauseUI()
        {
            btnResume.Visible = false;

            btnQuit.Visible = false;
        }

        /// <summary>
        /// Show the ball, paddle and bricks upon unpause.
        /// </summary>
        private void showGameElements()
        {
            ball.Visible = true;

            paddle.Visible = true;

        }

        /// <summary>
        /// Updates the score by the points specified.
        /// </summary>
        /// <param name="points">Number of points to increase score.</param>
        private void updateScore(int points)
        {
            score += points;

            lblScoreCounter.Text = score.ToString();
        }

        /// <summary>
        /// Subtracts 1 from total lives. If 0, restarts the game.
        /// </summary>
        private void loseLife()
        {
            if (lives > 1)
            {
                newLife();
            }
            else
            {
                endGame();
            }
        }

        /// <summary>
        /// Reset the ball location and speed and reinit the timer.
        /// </summary>
        private void newLife()
        {
            lives -= 1;

            lblLivesCounter.Text = lives.ToString();

            ticker.Dispose();

            ball.Dispose();

            initBall();

            initTicker();
        }

        /// <summary>
        /// Removes all instances of game elements, writes the score to a file and sets all variable to default values.
        /// </summary>
        private void endGame()
        {
            recordStats();

            ticker.Dispose();

            ball.Reset();

            ball.Dispose();

            paddle.Dispose();

            Cursor.Show();

            if (!btnRetry.Visible)
            {
                btnRetry.Visible = true;
            }
        }

        private void recordStats()
        {
            int[] stats = new int[] {level, score};

            FileWriter file = new FileWriter(stats);
        }

        #endregion
    }
}
