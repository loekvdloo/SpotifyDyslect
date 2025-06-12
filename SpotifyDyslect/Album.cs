using System;
using System.Collections.Generic;

namespace SpotifyDyslect
{
    public class Album
    {
        public string Title { get; private set; }
        public Artist Artist { get; private set; }
        private List<Song> songs;

        public Album(string title, Artist artist)
        {
            Title = title;
            Artist = artist;
            songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public void DisplaySongs()
        {
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {songs[i].Title} ({songs[i].DurationSeconds} sec)");
            }
        }

        public Song GetSong(int index)
        {
            if (index >= 0 && index < songs.Count)
                return songs[index];
            return null;
        }

        public List<Song> GetAllSongs()
        {
            return new List<Song>(songs);
        }
    }
}
