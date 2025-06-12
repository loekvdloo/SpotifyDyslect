using System;
using System.Collections.Generic;

namespace SpotifyDyslect
{
    public class Playlist
    {
        // Dictionary met playlistnaam en lijst van songs
        private Dictionary<string, List<Song>> playlists;

        public Playlist()
        {
            playlists = new Dictionary<string, List<Song>>(StringComparer.OrdinalIgnoreCase);
        }

        public void CreatePlaylist(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!playlists.ContainsKey(name))
                {
                    playlists.Add(name, new List<Song>());
                    Console.WriteLine($"Playlist '{name}' is aangemaakt!");
                }
                else
                {
                    Console.WriteLine("Playlist bestaat al.");
                }
            }
            else
            {
                Console.WriteLine("Ongeldige naam. Playlist is niet aangemaakt.");
            }
        }

        public void DisplayPlaylists()
        {
            if (playlists.Count == 0)
            {
                Console.WriteLine("Er zijn nog geen playlists aangemaakt.");
            }
            else
            {
                Console.WriteLine("Playlists:");
                int i = 1;
                foreach (var pl in playlists.Keys)
                {
                    Console.WriteLine($"{i}. {pl}");
                    i++;
                }
            }
        }

        public bool AddSongToPlaylist(string playlistName, Song song)
        {
            if (playlists.ContainsKey(playlistName))
            {
                playlists[playlistName].Add(song);
                return true;
            }
            return false;
        }

        public List<Song> GetSongsFromPlaylist(string playlistName)
        {
            if (playlists.ContainsKey(playlistName))
                return playlists[playlistName];
            return null;
        }
    }
}
