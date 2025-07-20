using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n======================\nDuplicate Counter\n======================");
        DuplicateCounter.Run();

        Console.WriteLine("\n======================\nTranslator\n======================");
        Translator.Run();

        Console.WriteLine("\n======================\nMaze Test\n======================");
        Console.WriteLine("\n======================\nEarthquake Summary\n======================");

        var quakes = SetsAndMaps.EarthquakeDailySummary();
        foreach (var quake in quakes)
        {
            Console.WriteLine(quake);
        }

        // Creamos un pequeño mapa de 3x3 sin paredes (todos los movimientos permitidos)
        var myMazeMap = new Dictionary<(int, int), bool[]>
        {
            { (1,1), new bool[] { false, true, false, true } },   // solo puede ir derecha o abajo
            { (2,1), new bool[] { true, true, false, true } },    // puede ir izquierda, derecha, abajo
            { (3,1), new bool[] { true, false, false, true } },   // puede ir izquierda, abajo

            { (1,2), new bool[] { false, true, true, true } },
            { (2,2), new bool[] { true, true, true, true } },
            { (3,2), new bool[] { true, false, true, true } },

            { (1,3), new bool[] { false, true, true, false } },
            { (2,3), new bool[] { true, true, true, false } },
            { (3,3), new bool[] { true, false, true, false } }
        };

        var maze = new Maze(myMazeMap);

        Console.WriteLine(maze.GetStatus()); // Debe decir (1,1)

        try
        {
            maze.MoveRight();  // (2,1)
            maze.MoveRight();  // (3,1)
            maze.MoveDown();   // (3,2)
            maze.MoveLeft();   // (2,2)
            maze.MoveDown();   // (2,3)
            Console.WriteLine(maze.GetStatus()); // Debe decir (2,3)
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"¡Pared! {ex.Message}");
        }
    }
}

