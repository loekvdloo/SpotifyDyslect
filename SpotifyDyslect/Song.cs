using System;

namespace SpotifyDyslect
{
    public class Song
    {
        public string Title { get; private set; }
        public int DurationSeconds { get; private set; }
        public Artist Artist { get; private set; }

        private bool isPlaying = false;
        private bool isPaused = false;

        public Song(string title, int durationSeconds, Artist artist)
        {
            Title = title;
            DurationSeconds = durationSeconds;
            Artist = artist;
        }

        public void Play()
        {
            isPlaying = true;
            isPaused = false;
            Console.WriteLine($"\n🎵 Nu speelt: '{Title}' van {Artist.Name} ({DurationSeconds} sec)");
        }

        public void Pause()
        {
            if (isPlaying && !isPaused)
            {
                isPaused = true;
                Console.WriteLine($"⏸️ '{Title}' is gepauzeerd.");
            }
            else if (isPaused)
            {
                Console.WriteLine($"'{Title}' is al gepauzeerd.");
            }
            else
            {
                Console.WriteLine($"'{Title}' wordt niet afgespeeld.");
            }
        }
    }
}
