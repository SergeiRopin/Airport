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
        public string CityDeparture;
        public string CityArrival;
        public string Airline;
        public char Terminal;
        public FlightStatus Status;
    }

    public class Program
    {
        static string unexpectedNumber = "\nPlease choose a number from the menu list!";

        static void Main(string[] args)
        {
            #region Arrival flights

            Flight beijing;
            beijing.Number = 288;
            beijing.Terminal = 'A';
            beijing.At = new DateTime(2016, 06, 11, 00, 35, 0);
            beijing.CityDeparture = "Beijing";
            beijing.CityArrival = "Kyiv";
            beijing.Airline = "Turkish Airlines Inc.";

            Flight almaty;
            almaty.Number = 537;
            almaty.Terminal = 'D';
            almaty.At = new DateTime(2016, 06, 11, 01, 15, 0);
            almaty.CityDeparture = "Almaty";
            almaty.CityArrival = "Kyiv";
            almaty.Airline = "Ukraine International Airlines";

            Flight telAviv;
            telAviv.Number = 778;
            telAviv.Terminal = 'A';
            telAviv.At = new DateTime(2016, 06, 11, 02, 45, 0);
            telAviv.CityDeparture = "Tel-Aviv";
            telAviv.CityArrival = "Kyiv";
            telAviv.Airline = "Ukraine International Airlines";

            Flight amsterdam;
            amsterdam.Number = 106;
            amsterdam.Terminal = 'A';
            amsterdam.At = new DateTime(2016, 06, 11, 03, 20, 0);
            amsterdam.CityDeparture = "Amsterdam";
            amsterdam.CityArrival = "Kyiv";
            amsterdam.Airline = "Ukraine International Airlines";

            Flight antalya;
            antalya.Number = 5412;
            antalya.Terminal = 'A';
            antalya.At = new DateTime(2016, 06, 11, 04, 00, 0);
            antalya.CityDeparture = "Antalya";
            antalya.CityArrival = "Kyiv";
            antalya.Airline = "Air France";

            Flight barcelona;
            barcelona.Number = 7152;
            barcelona.Terminal = 'A';
            barcelona.At = new DateTime(2016, 06, 11, 04, 15, 0);
            barcelona.CityDeparture = "Barcelona";
            barcelona.CityArrival = "Kyiv";
            barcelona.Airline = "Wind Rose Aviation Company";

            Flight london;
            london.Number = 114;
            london.Terminal = 'A';
            london.At = new DateTime(2016, 06, 11, 05, 20, 0);
            london.CityDeparture = "London";
            london.CityArrival = "Kyiv";
            london.Airline = "Ukraine International Airlines";

            Flight zaporizhia;
            zaporizhia.Number = 3144;
            zaporizhia.Terminal = 'B';
            zaporizhia.At = new DateTime(2016, 06, 11, 07, 30, 0);
            zaporizhia.CityDeparture = "Zaporizhia";
            zaporizhia.CityArrival = "Kyiv";
            zaporizhia.Airline = "KLM Royal Dutch Airlines";

            Flight yerevan;
            yerevan.Number = 612;
            yerevan.Terminal = 'D';
            yerevan.At = new DateTime(2016, 06, 11, 07, 50, 0);
            yerevan.CityDeparture = "Yerevan";
            yerevan.CityArrival = "Kyiv";
            yerevan.Airline = "Ukraine International Airlines";

            Flight baku;
            baku.Number = 6602;
            baku.Terminal = 'D';
            baku.At = new DateTime(2016, 06, 11, 07, 50, 0);
            baku.CityDeparture = "Baku";
            baku.CityArrival = "Kyiv";
            baku.Airline = "Azerbaijan Hava Yollary";

            Flight tbilisi;
            tbilisi.Number = 3140;
            tbilisi.Terminal = 'D';
            tbilisi.At = new DateTime(2016, 06, 11, 09, 50, 0);
            tbilisi.CityDeparture = "Tbilisi";
            tbilisi.CityArrival = "Kyiv";
            tbilisi.Airline = "KLM Royal Dutch Airlines";

            Flight kutaisi;
            kutaisi.Number = 506;
            kutaisi.Terminal = 'D';
            kutaisi.At = new DateTime(2016, 06, 11, 10, 55, 0);
            kutaisi.CityDeparture = "Kutaisi";
            kutaisi.CityArrival = "Kyiv";
            kutaisi.Airline = "KLM Royal Dutch Airlines";

            Flight dnipropetrovsk;
            dnipropetrovsk.Number = 3130;
            dnipropetrovsk.Terminal = 'B';
            dnipropetrovsk.At = new DateTime(2016, 06, 11, 12, 00, 0);
            dnipropetrovsk.CityDeparture = "Dnipropetrovsk";
            dnipropetrovsk.CityArrival = "Kyiv";
            dnipropetrovsk.Airline = "Dniproavia - Joint Stock Aviation Co.";

            Flight kharkiv;
            kharkiv.Number = 24;
            kharkiv.Terminal = 'B';
            kharkiv.At = new DateTime(2016, 06, 11, 12, 30, 0);
            kharkiv.CityDeparture = "Kharkiv";
            kharkiv.CityArrival = "Kyiv";
            kharkiv.Airline = "Ukraine International Airlines";

            Flight istanbul;
            istanbul.Number = 716;
            istanbul.Terminal = 'A';
            istanbul.At = new DateTime(2016, 06, 11, 14, 15, 0);
            istanbul.CityDeparture = "Istanbul";
            istanbul.CityArrival = "Kyiv";
            istanbul.Airline = "Turkish Airlines Inc.";

            Flight minsk;
            minsk.Number = 894;
            minsk.Terminal = 'D';
            minsk.At = new DateTime(2016, 06, 11, 16, 30, 0);
            minsk.CityDeparture = "Minsk";
            minsk.CityArrival = "Kyiv";
            minsk.Airline = "Ukraine International Airlines";

            Flight dubai;
            dubai.Number = 374;
            dubai.Terminal = 'A';
            dubai.At = new DateTime(2016, 06, 11, 17, 00, 0);
            dubai.CityDeparture = "Dubai";
            dubai.CityArrival = "Kyiv";
            dubai.Airline = "Ukraine International Airlines";

            Flight teheran;
            teheran.Number = 752;
            teheran.Terminal = 'A';
            teheran.At = new DateTime(2016, 06, 11, 18, 00, 0);
            teheran.CityDeparture = "Teheran";
            teheran.CityArrival = "Kyiv";
            teheran.Airline = "Ukraine International Airlines";

            Flight larnaca;
            larnaca.Number = 344;
            larnaca.Terminal = 'A';
            larnaca.At = new DateTime(2016, 06, 11, 20, 50, 0);
            larnaca.CityDeparture = "Larnaca";
            larnaca.CityArrival = "Kyiv";
            larnaca.Airline = "Ukraine International Airlines";

            Flight venezia;
            venezia.Number = 336;
            venezia.Terminal = 'A';
            venezia.At = new DateTime(2016, 06, 11, 21, 15, 0);
            venezia.CityDeparture = "Venezia";
            venezia.CityArrival = "Kyiv";
            venezia.Airline = "Ukraine International Airlines";

            Flight chisinau;
            chisinau.Number = 9898;
            chisinau.Terminal = 'D';
            chisinau.At = new DateTime(2016, 06, 11, 23, 30, 0);
            chisinau.CityDeparture = "Chisinau";
            chisinau.CityArrival = "Kyiv";
            chisinau.Airline = "Air Moldova";
            #endregion

            try
            {
                Console.WriteLine("**********AIRPORT**********\n");
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    ConsoleColor defaultColour = Console.ForegroundColor;

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
                                Console.ForegroundColor = defaultColour;
                                break;
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPostive value from 1 to 4 expected!");
                        Console.ForegroundColor = defaultColour;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWrong input! " + ex.Message);
                        Console.ForegroundColor = defaultColour;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPress \"Space\" to exit; press any key to continue\n");
                    Console.ForegroundColor = defaultColour;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
            Console.WriteLine("\n*****Flight Information menu*****\n");
            Console.WriteLine(@"Please choose flights you would like to see:
            1. Arrival;
            2. Departure.");

            int? index = null;
            index = (int)uint.Parse(Console.ReadLine());
            switch (index)
            {
                case 1:

                    break;

                case 2:

                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(unexpectedNumber);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        #endregion

        #region SearchFlight() code

        static void SearchFlight()
        {

        }
        #endregion
    }
}
