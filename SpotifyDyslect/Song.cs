class Song
{
    public string Title { get; private set; }
    public int DurationSeconds { get; private set; }
    public Artist Artist { get; private set; }

    public Song(string title, int durationSeconds, Artist artist)
    {
        Title = title;
        DurationSeconds = durationSeconds;
        Artist = artist;

    }

    public void Play()
    {
        Console.WriteLine($"\n🎵 Nu speelt: '{Title}' van {Artist.Name} ({DurationSeconds} sec)");
    }
}