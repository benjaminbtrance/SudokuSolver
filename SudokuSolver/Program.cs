﻿using SudokuSolver.Strategies;
using SudokuSolver.Workers;
using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();

                bool runProgram = true;
                string answer = "";

                while (runProgram)
                {
                    Console.WriteLine("Welcome to the Sudoku Puzzle Program\n");
                    Console.WriteLine("Please enter the filename containing the Sudoku Puzzle:");
                    var filename = Console.ReadLine();
                    

                    var sudokuBoard = sudokuFileReader.ReadFile(filename);
                    sudokuBoardDisplayer.Display("Initial State", sudokuBoard);

                    bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                    sudokuBoardDisplayer.Display("Final State", sudokuBoard);

                    Console.WriteLine(isSudokuSolved
                        ? "You have successfully solved this Sudoku Puzzle!\n"
                        : "Unfortunatley, current algorithm(s) were not enough to solve the current Sudoku Puzzle!\n");

                    Console.WriteLine("Would you like to try another Sudoku Puzzel? [Y or N]\n");
                    answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        runProgram = true;
                    }
                    else
                    {
                        runProgram = false;
                    }
                }

                Console.WriteLine("Thanks for playing. Good-Bye.");

                

            }
            catch (Exception ex)
            {
                // In real world we would want to log this message
                Console.WriteLine("{0} : {1}", "Sudoku Puzzle cannot be solved because there was an error:", ex.Message);
            }
        }
    }
}