using System;
using System.Collections.Generic;

namespace SpotifyDyslect
{
    class Program
    {
        static void Main()
        {
            Artist artist = new Artist("The Weeknd");
            Artist artist1 = new Artist("test artist");
            Song song1 = new Song("Blinding Lights", 200, artist);
            Song song2 = new Song("Save Your Tears", 210, artist);
            Song song3 = new Song("wat een leuk nummer", 99, artist);
            Song song4 = new Song("wat een saai nummer", 99, artist1);
            Song song5 = new Song("wat een grappig  nummer", 99, artist1);
            Song song6 = new Song("wat een irritant nummer", 99, artist1);


            Album album = new Album("After Hours", artist);
            Album album1 = new Album("After Hours", artist1);
            Playlist playlist = new Playlist();

            album.AddSong(song1);
            album.AddSong(song2);
            album.AddSong(song3);
            album1.AddSong(song4);
            album1.AddSong(song5);
            album1.AddSong(song6);

            // Vriendenlijst
            string friends = "Vrienden: \n" +
                             "1. Jan\n" +
                             "2. Piet\n" +
                             "3. Klaas\n" +
                             "4. Kees\n" +
                             "5. Henk\n";

            bool isPlayingApp = true;
            Song currentSong = null;
            bool isPaused = false;
            bool isRepeat = false;

            while (isPlayingApp)
            {
                Console.WriteLine("\nWelkom bij SpotifyDyslect");
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("1. Speel nummer van album");
                Console.WriteLine("2. Speel nummer van playlist");
                Console.WriteLine("3. Pauzeer / Hervat");
                Console.WriteLine("4. Herhaal nummer aan/uit");
                Console.WriteLine("5. Shuffle album");
                Console.WriteLine("6. Shuffle playlist");
                Console.WriteLine("7. Maak nieuwe playlist");
                Console.WriteLine("8. Voeg nummer toe aan playlist");
                Console.WriteLine("9. Bekijk albums");
                Console.WriteLine("10. Bekijk playlists");
                Console.WriteLine("11. Bekijk vrienden");
                Console.WriteLine("12. Afsluiten");

                string inputMain = Console.ReadLine();

                switch (inputMain)
                {
                    case "1":
                        Console.WriteLine($"\nAlbum: {album.Title} - door {album.Artist.Name}");
                        album.DisplaySongs();
                        Console.Write("Kies een nummer om af te spelen (nummer): ");
                        if (int.TryParse(Console.ReadLine(), out int albumIndex))
                        {
                            Song chosenSong = album.GetSong(albumIndex - 1);
                            if (chosenSong != null)
                            {
                                currentSong = chosenSong;
                                currentSong.Play();
                                isPaused = false;
                            }
                            else
                            {
                                Console.WriteLine("Ongeldig nummer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige invoer.");
                        }
                        break;

                    case "2":
                        playlist.DisplayPlaylists();
                        Console.Write("Kies een playlist om nummers van af te spelen (naam): ");
                        string plName = Console.ReadLine();
                        List<Song> songsFromPlaylist = playlist.GetSongsFromPlaylist(plName);
                        if (songsFromPlaylist != null && songsFromPlaylist.Count > 0)
                        {
                            Console.WriteLine($"Speel nummers van playlist '{plName}':");
                            foreach (var s in songsFromPlaylist)
                            {
                                Console.WriteLine($"- {s.Title} van {s.Artist.Name}");
                            }
                            Console.Write("Kies een nummer (nummer) om af te spelen: ");
                            if (int.TryParse(Console.ReadLine(), out int plSongIndex) && plSongIndex > 0 && plSongIndex <= songsFromPlaylist.Count)
                            {
                                currentSong = songsFromPlaylist[plSongIndex - 1];
                                currentSong.Play();
                                isPaused = false;
                            }
                            else
                            {
                                Console.WriteLine("Ongeldig nummer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Playlist niet gevonden of leeg.");
                        }
                        break;

                    case "3":
                        if (currentSong != null)
                        {
                            if (!isPaused)
                            {
                                currentSong.Pause();
                                isPaused = true;
                            }
                            else
                            {
                                currentSong.Play();
                                isPaused = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Er wordt geen nummer afgespeeld.");
                        }
                        break;

                    case "4":
                        isRepeat = !isRepeat;
                        Console.WriteLine($"Herhalen staat nu {(isRepeat ? "aan" : "uit")}");
                        if (isRepeat && currentSong != null)
                        {
                            currentSong.Play();
                        }
                        break;

                    case "5":
                        List<Song> albumSongs = album.GetAllSongs();
                        ShuffleList(albumSongs);
                        Console.WriteLine("Shuffle album:");
                        foreach (var s in albumSongs)
                        {
                            s.Play();
                        }
                        break;

                    case "6":
                        playlist.DisplayPlaylists();
                        Console.Write("Kies een playlist om te shufflen (naam): ");
                        string shufflePlName = Console.ReadLine();
                        List<Song> plSongs = playlist.GetSongsFromPlaylist(shufflePlName);
                        if (plSongs != null && plSongs.Count > 0)
                        {
                            ShuffleList(plSongs);
                            Console.WriteLine($"Shuffle playlist '{shufflePlName}':");
                            foreach (var s in plSongs)
                            {
                                s.Play();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Playlist niet gevonden of leeg.");
                        }
                        break;

                    case "7":
                        Console.Write("Voer een naam in voor je nieuwe playlist: ");
                        string newPlaylistName = Console.ReadLine();
                        playlist.CreatePlaylist(newPlaylistName);
                        break;

                    case "8":
                        playlist.DisplayPlaylists();
                        Console.Write("Kies een playlist om nummer aan toe te voegen (naam): ");
                        string addToPlName = Console.ReadLine();
                        Console.WriteLine($"\nAlbum: {album.Title} - door {album.Artist.Name}");
                        album.DisplaySongs();
                        Console.Write("Kies een nummer om toe te voegen (nummer): ");
                        if (int.TryParse(Console.ReadLine(), out int addSongIndex))
                        {
                            Song songToAdd = album.GetSong(addSongIndex - 1);
                            if (songToAdd != null)
                            {
                                if (playlist.AddSongToPlaylist(addToPlName, songToAdd))
                                {
                                    Console.WriteLine($"Nummer '{songToAdd.Title}' toegevoegd aan playlist '{addToPlName}'.");
                                }
                                else
                                {
                                    Console.WriteLine("Playlist niet gevonden.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ongeldig nummer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige invoer.");
                        }
                        break;

                    case "9":
                        Console.WriteLine($"\nAlbum: {album.Title} - door {album.Artist.Name}");
                        album.DisplaySongs();
                        break;

                    case "10":
                        playlist.DisplayPlaylists();
                        break;

                    case "11":
                        Console.WriteLine(friends);
                        break;

                    case "12":
                        Console.WriteLine("Tot ziens!");
                        isPlayingApp = false;
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
                        break;
                }
            }
        }

        // Helper: shuffle een lijst
        static void ShuffleList<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
