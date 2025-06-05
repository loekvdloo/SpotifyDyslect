using System;
using System.Collections.Generic;

public class Playlist
{
    private static List<string> playlists = new List<string>();

    public static void CreatePlaylist()
    {
        Console.Write("Voer een naam in voor je nieuwe playlist: ");
        string naam = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(naam))
        {
            playlists.Add(naam);
            Console.WriteLine($"Playlist '{naam}' is aangemaakt!");
        }
        else
        {
            Console.WriteLine("Ongeldige naam. Playlist is niet aangemaakt.");
        }
    }

    public static void DisplayPlaylists()
    {
        if (playlists.Count == 0)
        {
            Console.WriteLine("Er zijn nog geen playlists aangemaakt.");
        }
        else
        {
            Console.WriteLine("Playlists:");
            for (int i = 0; i < playlists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {playlists[i]}");
            }
        }
    }
}
