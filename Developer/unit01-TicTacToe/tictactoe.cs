/*
    Author: Jaxon Hamm
    
    Class: CSE-210 Programming with Classes

    Project: Tic-Tac-Toe

    Summary: The goal of this project was to learn c# by programming
    a simple game in the console, using the concepts we have learned
    in python and applying them in a new language.
*/


using System;
using System.Collections.Generic;

namespace PROJECT {
    class PROGRAM {
        static void Main(string[] args) {
            // Run the game
            char response = 'y';
            do {
                game();
                Console.Write("Would you like to play again? (y/n) ");
                response = Char.Parse(Console.ReadLine());
            } while (response == 'y');
            
        }

        /*
        GAME

        The game loop is as such:
            Create the board
            Display the board
            Make a valid turn
            Check if the game is won
            Repeat until the game is over
            Display win message.
        */
        static void game() {
            int won = 0;
            List<char> board = createBoard();
            int turn = 0;
            do {
                displayBoard(board);
                takeTurn(turn, board);
                turn++;
                won = checkEndCondition(board);
            } while(won == 0);
            displayBoard(board);
            displayWin(won);
            return;
        }

        /*
        CREATE BOARD

        Create an empty play board for the user to play in.
        */
        static List<char> createBoard() {
            List<char> board = new List<char> {'1', '2', '3',
                                               '4', '5', '6',
                                               '7', '8', '9'};
            return board;
        }

        /*
        DISPLAY

        Displays the board for the user to look at.
        */
        static void displayBoard(List<char> board) {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        /*
        TAKE TURN

        Run the turn step of the game by determining whose turn it is then
        getting a valid square to play on.
        */
        static void takeTurn(int turn, List<char> board) {
            
            // Decide whose turn it is are checking for.
            char playerTurn; 
            if ((turn % 2) == 0) playerTurn = 'X';
            else playerTurn = 'O';

            // Tell the player whose turn it is.
            Console.WriteLine($"It is {playerTurn}'s turn.");

            // Get a valid spot.
            int decision = 0;
            do {
                Console.Write("Enter a value 1-9 that is not already taken. ");
                decision = int.Parse(Console.ReadLine());
            } while (((decision < 1) || (decision > 9 )) 
                    || ((board[decision - 1 ] == 'X') || (board[decision - 1] == 'O')));
            
            // Edit the board finally.
            board[decision - 1] = playerTurn;
        }
        
        /*
        CHECK END CONDITION
        
        This function checks whether or not the end condition has been met.
        It returns 4 values:
            0 - No end condition has been met.
            1 - Player X has won the game
            2 - Player O has won the game
            4 - It is a draw because the board is full.
        */
        static int checkEndCondition(List<char> board) {
            // Check if the board is full
            bool fullBoard = true;
            for (int i = 0; i < 9; i++) {
                if ((board[i] != 'X') && (board[i] != 'O')) {
                     fullBoard = false;
                }
            }
            if (fullBoard) return 3;

            // Check for X win
            if (win('X', board)) return 1;

            // Check for O win
            if (win('O', board)) return 2;

            // Return 0 for no win condition
            return 0;
        }

        /*
        WIN

        Runs through every row, column, and diagonal searching for a win condition.
        Returns true if there is a win, false if there isn't.
        */
        static bool win(char check, List<char> board) {
            // Check the rows.
            bool won = true;
            for(int i = 0; i < 3; i++) {
                if (board[i] != check) won = false;
            }
            if (won) return true;
            won = true;
            for (int i = 3; i < 6; i++) {
                if (board[i] != check) won = false;
            }
            if (won) return true;
            won = true;
            for (int i = 5; i < 9; i++) {
                if (board[i] != check) won = false;
            }
            if (won) return true;

            // Check the columns.
            won = true;
            for(int i = 0;i < 9; i += 3) {
                if (board[i] != check) won = false;
            }
            if (won) return true;
            won = true;
            for (int i = 1; i < 9; i += 3) {
                if (board[i] != check) won = false;
            }
            if (won) return true;
            won = true;
            for (int i = 2; i < 9; i += 3) {
                if (board[i] != check) won = false;
            }
            if (won) return true;

            // Check diagonals
            won = true;
            for (int i = 0; i < 9; i += 4) {
                if (board[i] != check) won = false;
            }
            if (won) return true;
            won = true;
            for (int i = 2; i < 7; i += 2) {
                if (board[i] != check) won = false;
            }
            if (won) return true;
            
            return false;
        }

        /* 
        DISPLAY WIN

        Display the win message for the player who won the game.
        */
        static void displayWin(int winner) {
            switch (winner) {
                case 3: 
                    Console.WriteLine("It's a tie!\n");
                    break;
                case 1: 
                    Console.WriteLine("X's have won!\n");
                    break;
                case 2: 
                    Console.WriteLine("O's have won!\n");
                    break;
            }
            return;
        }
    }
}