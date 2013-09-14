﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using videopuzzle.Resources;
using System.Windows.Documents;
using System.Windows.Media;

namespace videopuzzle
{
    public partial class MainPage : PhoneApplicationPage
    {
        private PuzzleBoard puzzleBoard;
        private SolidColorBrush boardColor;
        private List<SolidColorBrush> colors;
        Random rand;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            List<Square> squares = new List<Square>();
            InitializeSquares(squares);
            puzzleBoard = new PuzzleBoard(squares);
            boardColor = new SolidColorBrush(Colors.Cyan);
            colors = new List<SolidColorBrush>();
            colors.Add(new SolidColorBrush(Colors.DarkGray));
            colors.Add(new SolidColorBrush(Colors.Magenta));
            colors.Add(new SolidColorBrush(Colors.Purple));
            colors.Add(new SolidColorBrush(Colors.Yellow));
            colors.Add(new SolidColorBrush(Colors.Blue));
            rand = new Random();
        }

        private void InitializeSquares(List<Square> squares)
        {
            squares.Add(new Square(image01, 1));
            squares.Add(new Square(image02, 2));
            squares.Add(new Square(image03, 3));
            squares.Add(new Square(image04, 4));
            squares.Add(new Square(image05, 5));
            squares.Add(new Square(image06, 6));
            squares.Add(new Square(image07, 7));
            squares.Add(new Square(image08, 8));
            squares.Add(new Square(image09, 9));
            squares.Add(new Square(image10, 10));
            squares.Add(new Square(image11, 11));
            squares.Add(null);
        }

        private void MainGrid_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            if (e.ManipulationContainer.GetType() == typeof (TextBlock)) 
            {
                TextBlock temp = (TextBlock)e.ManipulationContainer;
                int idx = ((int)Canvas.GetLeft(temp)) / 152 + ((int)Canvas.GetTop(temp)) / 152 * 3;
                puzzleBoard.MoveTile(idx);
                if (puzzleBoard.IsWon())
                    MainGrid.Background = new SolidColorBrush(Colors.Green);
                else
                    MainGrid.Background = boardColor;
            }
            
        }

        private void ApplicationBarShuffle_Click(object sender, EventArgs e)
        {
            MainGrid.Background = boardColor;
            puzzleBoard.Shuffle();
            
        }

        private void ApplicationBarNext_Click(object sender, EventArgs e)
        {
            var idx = (int)(rand.NextDouble() * colors.Count);
            boardColor = colors.ElementAt(idx);
            MainGrid.Background = boardColor;
            puzzleBoard.Shuffle();
        }


    }
}