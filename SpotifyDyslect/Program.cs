using System;

namespace SpotifyDyslect
{
    class program
    {


        static void Main()
        {
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
