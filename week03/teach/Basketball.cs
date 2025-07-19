using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Basketball
{
    public static void Run()
    {
        var totalPointsPerPlayer = new Dictionary<string, int>();

        foreach (var line in File.ReadLines("basketball.csv").Skip(1)) // Saltar encabezado
        {
            var parts = line.Split(',');

            string playerId = parts[0];       // Columna 0: ID del jugador
            string pointsStr = parts[8];      // Columna 8: Puntos anotados

            if (int.TryParse(pointsStr, out int points))
            {
                if (!totalPointsPerPlayer.ContainsKey(playerId))
                {
                    totalPointsPerPlayer[playerId] = points;
                }
                else
                {
                    totalPointsPerPlayer[playerId] += points;
                }
            }
        }

        // Obtener los 10 jugadores con más puntos totales
        var topPlayers = totalPointsPerPlayer
            .OrderByDescending(kvp => kvp.Value)
            .Take(10);

        Console.WriteLine("Top 10 jugadores por puntos totales:");
        foreach (var kvp in topPlayers)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} puntos");
        }
    }
}
