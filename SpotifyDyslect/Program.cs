using System;

namespace SpotifyDyslect
{
    class program
    {


        static void Main()
        {
            Artist artist = new Artist("The Weeknd");
            Song song1 = new Song("Blinding Lights", 200, artist);
            Song song2 = new Song("Save Your Tears", 210, artist);
            Album album = new Album("After Hours", artist);
            album.AddSong(song1);
            album.AddSong(song2);
            string Friends = "Vrienden: \n" +
            "1. Jan\n" +
            "2. Piet\n" +
            "3. Klaas\n" +
            "4. Kees\n" +
            "5. Henk\n";
            string pauzePlay = "pauze";
            Boolean isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine("Welkom bij SpotifyDyslect");
                Console.WriteLine("Maak uw keuze");
                Console.Write("1. terug ");
                Console.Write("2. " + pauzePlay);
                Console.WriteLine(" 3. verder");
                Console.WriteLine("4. Bekijk albums");
                Console.WriteLine("5. Maak playlist");
                Console.WriteLine("6. Bekijk playlisten");
                Console.WriteLine("7. Bekijk vrienden");
                Console.WriteLine("8. Vergelijk playlisten met vrienden");
                Console.WriteLine("9. afsluiten");

                var inputMain = Console.ReadLine();

                switch (inputMain)
                {
                    case "1":

                        break;
                    case "2":
                        if (pauzePlay == "pauze")
                        {
                            pauzePlay = "play";
                        }
                        else
                        {
                            pauzePlay = "pauze";
                        }

                        break;
                    case "3":

                        break;
                    case "4":
                        Console.WriteLine($"\nAlbum: {album.Title} - door {album.Artist.Name}");
                        album.DisplaySongs();
                        Console.Write("Kies een nummer om af te spelen: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            Song gekozenLied = album.GetSong(index - 1);
                            if (gekozenLied != null)
                            {
                                gekozenLied.Play();
                            }
                            else
                            {
                                Console.WriteLine("Ongeldig nummer.");
                            }
                        }
                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    case "7":
                        Console.WriteLine(Friends);
                        break;
                    case "8":

                        break;
                    case "9":

                        break;
                }
            }


        }
    }
}
