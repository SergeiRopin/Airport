using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    enum FlightStatus
    {
        CheckIn,
        GateClosed,
        Arrived,
        DeparturedAt,
        Unknown,
        Canceled,
        ExpectedAt,
        Delayed,
        InFlight
    }

    struct Flight
    {
        public DateTime At;
        public int Number;
        public string CityTo;
        public string CityFrom;
        public string Airline;
        public char Terminal;
        public FlightStatus Status;

        public override string ToString()
        {
            return $"Time: {At}, Flight: {Number}, From: {CityFrom}, Terminal: {Terminal}, Airline: {Airline}, Status: ";
        }
    }

    public class Program
    {
        static string unexpectedNumber = "\nPlease choose a number from the menu list!";

        static void Main(string[] args)
        {
            try
            {
                Console.WindowHeight = Console.LargestWindowHeight;
                Console.WindowWidth = Console.LargestWindowWidth;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("**********AIRPORT**********\n");
                Console.ResetColor();
                do
                {
                    Console.WriteLine(@"Please make your choise:

                1. Edit a flight information;
                2. Delete a flight;
                3. Display all flight information;
                4. Search a flight;");

                    try
                    {
                        int index = (int)uint.Parse(Console.ReadLine());

                        switch (index)
                        {
                            case 1:
                                EditFlight();
                                break;

                            case 2:
                                DeleteFlight();
                                break;

                            case 3:
                                DisplayFlight();
                                break;

                            case 4:
                                SearchFlight();
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(unexpectedNumber);
                                Console.ResetColor();
                                break;
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPositive value is expected!");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWrong input! " + ex.Message);
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPress \"Space\" to exit; press any key to return to the main menu\n");
                    Console.ResetColor();
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static Flight[] ArrivedFlight()
        {
            #region Arrived flights

            Flight beijing = new Flight();
            beijing.Number = 288;
            beijing.Terminal = 'A';
            beijing.At = new DateTime(2016, 06, 11, 00, 35, 0);
            beijing.CityFrom = "Beijing";
            beijing.Airline = "Turkish Airlines Inc.";

            Flight almaty = new Flight();
            almaty.Number = 537;
            almaty.Terminal = 'D';
            almaty.At = new DateTime(2016, 06, 11, 01, 15, 0);
            almaty.CityFrom = "Almaty";
            almaty.Airline = "Ukraine International Airlines";

            Flight telAviv = new Flight();
            telAviv.Number = 778;
            telAviv.Terminal = 'A';
            telAviv.At = new DateTime(2016, 06, 11, 02, 45, 0);
            telAviv.CityFrom = "Tel-Aviv";
            telAviv.Airline = "Ukraine International Airlines";

            Flight amsterdam = new Flight();
            amsterdam.Number = 106;
            amsterdam.Terminal = 'A';
            amsterdam.At = new DateTime(2016, 06, 11, 03, 20, 0);
            amsterdam.CityFrom = "Amsterdam";
            amsterdam.Airline = "Ukraine International Airlines";

            Flight antalya = new Flight();
            antalya.Number = 5412;
            antalya.Terminal = 'A';
            antalya.At = new DateTime(2016, 06, 11, 04, 00, 0);
            antalya.CityFrom = "Antalya";
            antalya.Airline = "Air France";

            Flight barcelona = new Flight();
            barcelona.Number = 7152;
            barcelona.Terminal = 'A';
            barcelona.At = new DateTime(2016, 06, 11, 04, 15, 0);
            barcelona.CityFrom = "Barcelona";
            barcelona.Airline = "Wind Rose Aviation Company";

            Flight london = new Flight();
            london.Number = 114;
            london.Terminal = 'A';
            london.At = new DateTime(2016, 06, 11, 05, 20, 0);
            london.CityFrom = "London";
            london.Airline = "Ukraine International Airlines";

            Flight zaporizhia = new Flight();
            zaporizhia.Number = 3144;
            zaporizhia.Terminal = 'B';
            zaporizhia.At = new DateTime(2016, 06, 11, 07, 30, 0);
            zaporizhia.CityFrom = "Zaporizhia";
            zaporizhia.Airline = "KLM Royal Dutch Airlines";

            Flight yerevan = new Flight();
            yerevan.Number = 612;
            yerevan.Terminal = 'D';
            yerevan.At = new DateTime(2016, 06, 11, 07, 50, 0);
            yerevan.CityFrom = "Yerevan";
            yerevan.Airline = "Ukraine International Airlines";

            Flight baku = new Flight();
            baku.Number = 6602;
            baku.Terminal = 'D';
            baku.At = new DateTime(2016, 06, 11, 07, 50, 0);
            baku.CityFrom = "Baku";
            baku.Airline = "Azerbaijan Hava Yollary";

            Flight tbilisi = new Flight();
            tbilisi.Number = 3140;
            tbilisi.Terminal = 'D';
            tbilisi.At = new DateTime(2016, 06, 11, 09, 50, 0);
            tbilisi.CityFrom = "Tbilisi";
            tbilisi.Airline = "KLM Royal Dutch Airlines";

            Flight kutaisi = new Flight();
            kutaisi.Number = 506;
            kutaisi.Terminal = 'D';
            kutaisi.At = new DateTime(2016, 06, 11, 10, 55, 0);
            kutaisi.CityFrom = "Kutaisi";
            kutaisi.Airline = "KLM Royal Dutch Airlines";

            Flight dnipropetrovsk = new Flight();
            dnipropetrovsk.Number = 3130;
            dnipropetrovsk.Terminal = 'B';
            dnipropetrovsk.At = new DateTime(2016, 06, 11, 12, 00, 0);
            dnipropetrovsk.CityFrom = "Dnipropetrovsk";
            dnipropetrovsk.Airline = "Dniproavia - Joint Stock Aviation Co.";

            Flight kharkiv = new Flight();
            kharkiv.Number = 24;
            kharkiv.Terminal = 'B';
            kharkiv.At = new DateTime(2016, 06, 11, 12, 30, 0);
            kharkiv.CityFrom = "Kharkiv";
            kharkiv.Airline = "Ukraine International Airlines";

            Flight istanbul = new Flight();
            istanbul.Number = 716;
            istanbul.Terminal = 'A';
            istanbul.At = new DateTime(2016, 06, 11, 14, 15, 0);
            istanbul.CityFrom = "Istanbul";
            istanbul.Airline = "Turkish Airlines Inc.";

            Flight minsk = new Flight();
            minsk.Number = 894;
            minsk.Terminal = 'D';
            minsk.At = new DateTime(2016, 06, 11, 16, 30, 0);
            minsk.CityFrom = "Minsk";
            minsk.Airline = "Ukraine International Airlines";

            Flight dubai = new Flight();
            dubai.Number = 374;
            dubai.Terminal = 'A';
            dubai.At = new DateTime(2016, 06, 11, 17, 00, 0);
            dubai.CityFrom = "Dubai";
            dubai.Airline = "Ukraine International Airlines";

            Flight teheran = new Flight();
            teheran.Number = 752;
            teheran.Terminal = 'A';
            teheran.At = new DateTime(2016, 06, 11, 18, 00, 0);
            teheran.CityFrom = "Teheran";
            teheran.Airline = "Ukraine International Airlines";

            Flight larnaca = new Flight();
            larnaca.Number = 344;
            larnaca.Terminal = 'A';
            larnaca.At = new DateTime(2016, 06, 11, 20, 50, 0);
            larnaca.CityFrom = "Larnaca";
            larnaca.Airline = "Ukraine International Airlines";

            Flight venezia = new Flight();
            venezia.Number = 336;
            venezia.Terminal = 'A';
            venezia.At = new DateTime(2016, 06, 11, 21, 15, 0);
            venezia.CityFrom = "Venezia";
            venezia.Airline = "Ukraine International Airlines";

            Flight chisinau = new Flight();
            chisinau.Number = 9898;
            chisinau.Terminal = 'D';
            chisinau.At = new DateTime(2016, 06, 11, 23, 30, 0);
            chisinau.CityFrom = "Chisinau";
            chisinau.Airline = "Air Moldova";
            #endregion

            // Declare an arrow of arrivals.
            Flight[] arrivedFlight = new Flight[] { beijing, almaty, telAviv, amsterdam, antalya, barcelona, london,
                zaporizhia, yerevan, baku, tbilisi, kutaisi, dnipropetrovsk, kharkiv, istanbul, minsk, dubai, teheran,
                larnaca, venezia, chisinau };

            return arrivedFlight;
        }

        static Flight[] DeparturedFlight()
        {
            #region Departured flights

            #endregion

            // Declare an arrow of arrivals.
            Flight[] departuredFlight = new Flight[] { };

            return departuredFlight;
        }

        #region EditFlight() code

        static void EditFlight()
        {

        }
        #endregion

        #region DeleteFlight() code

        static void DeleteFlight()
        {

        }
        #endregion

        #region DisplayFlight() code

        static void DisplayFlight()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n*****Flight Information menu*****\n");
                Console.ResetColor();
                Console.WriteLine(@"Please choose flights you would like to see:

                1. Arrivals;
                2. Departures.");

                int? index = null;
                index = (int)uint.Parse(Console.ReadLine());
                switch (index)
                {
                    case 1:
                        Console.WriteLine("\nThe list of arrivals:\n");
                        for (int i = 0; i < ArrivedFlight().Length; i++)
                        {
                            Console.WriteLine(ArrivedFlight()[i]);
                            //Console.WriteLine($"Time: {ArrivedFlight()[i].At}, Flight: {ArrivedFlight()[i].Number}, From: {ArrivedFlight()[i].CityFrom}, Terminal: {ArrivedFlight()[i].Terminal}, Airline: {ArrivedFlight()[i].Airline}, Status: ");
                        }
                        break;

                    case 2:

                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(unexpectedNumber);
                        Console.ResetColor();
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPress \"Backpace\" to return to the main menu; press any key to select another flights");
                Console.ResetColor();//.ForegroundColor = ConsoleColor.White;
            }
            while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
        #endregion

        #region SearchFlight() code

        static void SearchFlight()
        {

        }
        #endregion
    }
}
