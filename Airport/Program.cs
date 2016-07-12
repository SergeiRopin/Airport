﻿using System;
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
        InFlight,
        Boarding
    }

    struct Flight
    {
        public DateTime Time;
        public int Number;
        public string CityTo;
        public string CityFrom;
        public string Airline;
        public char Terminal;
        public FlightStatus Status;

        public override string ToString()
        {
            return $"Time: {Time}, Flight: {Number}, From: {CityFrom}, To: {CityTo}, Terminal: {Terminal}, Airline: {Airline}";
        }
    }

    public class Program
    {
        static string unexpectedNumber = "\nPlease choose a number from the menu list!";
        static string homeAirport = "Kyiv";
        private static int i;

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
                        Console.Write("Your choise: ");
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

                Console.Write("Your choise: ");
                int index = (int)uint.Parse(Console.ReadLine());

                switch (index)
                {
                    case 1:
                        Console.WriteLine("\nThe list of Arrivals:\n");
                        for (int i = 0; i < ArrivedFlight().Length; i++)
                        {
                            if (GetActualTime() >= ArrivedFlight()[i].Time)
                            {
                                var status = FlightStatus.Arrived;
                                //Console.WriteLine(ArrivedFlight()[i] + $", Status: {status};");
                                Console.WriteLine(ArrivedFlight()[i] + $", Status: {GetArrivalsStatus()};");

                            }
                            else if (GetActualTime() < ArrivedFlight()[i].Time & GetActualTime() > ArrivedFlight()[i].Time.AddHours(-3))
                            {
                                var status = FlightStatus.InFlight;
                                //Console.WriteLine(ArrivedFlight()[i] + $", Status: {status};");
                                Console.WriteLine(ArrivedFlight()[i] + $", Status: {GetArrivalsStatus()};");

                            }
                            else if (GetActualTime() < ArrivedFlight()[i].Time.AddHours(-3))
                            {
                                var status = FlightStatus.ExpectedAt;
                                //Console.WriteLine(ArrivedFlight()[i] + $", Status: {status}: {ArrivedFlight()[i].Time};");
                                Console.WriteLine(ArrivedFlight()[i] + $", Status: {GetArrivalsStatus()}: {ArrivedFlight()[i].Time};");

                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nThe list of Departures:\n");
                        for (int i = 0; i < DeparturedFlight().Length; i++)
                        {
                            if (GetActualTime() > DeparturedFlight()[i].Time.AddMinutes(5))
                            {
                                var status = FlightStatus.DeparturedAt;
                                Console.WriteLine(DeparturedFlight()[i] + $", Status: {status}: {DeparturedFlight()[i].Time};");
                            }
                            else if (GetActualTime() <= DeparturedFlight()[i].Time.AddMinutes(5) & GetActualTime() >= DeparturedFlight()[i].Time.AddMinutes(-5))
                            {
                                var status = FlightStatus.GateClosed;
                                Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                            }
                            else if (GetActualTime() >= DeparturedFlight()[i].Time.AddMinutes(-30) & GetActualTime() < DeparturedFlight()[i].Time.AddMinutes(-5))
                            {
                                var status = FlightStatus.Boarding;
                                Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                            }
                            else if (GetActualTime() >= DeparturedFlight()[i].Time.AddHours(-2) & GetActualTime() < DeparturedFlight()[i].Time.AddMinutes(-30))
                            {
                                var status = FlightStatus.CheckIn;
                                Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                            }
                            else if (GetActualTime() < DeparturedFlight()[i].Time.AddHours(-2))
                            {
                                var status = "---";
                                Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                            }
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(unexpectedNumber);
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPress \"Backpace\" to return to the main menu; press any key to select another flights");
                Console.ResetColor();
            }
            while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
        #endregion

        #region SearchFlight() code

        static void SearchFlight()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n*****Search Flight menu*****\n");
                Console.ResetColor();
                Console.WriteLine(@"Please choose one of the following menu items:

                1. Search by number;
                2. Search by time of arrival;
                3. Search by city;
                4. Search all flights in this hour;");

                Console.Write("Your choise: ");
                int index = (int)uint.Parse(Console.ReadLine());

                switch (index)
                {
                    case 1:
                        Console.Write("\nPlease enter a number of your flight: ");
                        int flightNumber = (int)uint.Parse(Console.ReadLine());
                        int tmp = new int();

                        for (int i = 0; i < ArrivedFlight().Length; i++)
                        {
                            if (flightNumber == ArrivedFlight()[i].Number)
                            {
                                tmp++;
                                GetArrivalsStatus();
                                //Console.WriteLine("\n" + ArrivedFlight()[i]);
                            }
                        }

                        for (int i = 0; i < DeparturedFlight().Length; i++)
                        {
                            if (flightNumber == DeparturedFlight()[i].Number)
                            {
                                tmp++;
                                GetDeparturesStatus();
                                //Console.WriteLine("\n" + DeparturedFlight()[i]);
                            }
                        }

                        if (tmp == 0)
                        {
                            Console.WriteLine("\nNo flights with specified data!");
                        }


                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(unexpectedNumber);
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPress \"Backpace\" to return to the main menu; press any key to search another flight");
                Console.ResetColor();
            }
            while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
        #endregion

        static FlightStatus GetArrivalsStatus()
        {
            FlightStatus status = new FlightStatus();
            for (int i = 0; i < ArrivedFlight().Length; i++)
            {
                if (GetActualTime() >= ArrivedFlight()[i].Time)
                {
                    status = FlightStatus.Arrived;
                }
                else if (GetActualTime() < ArrivedFlight()[i].Time & GetActualTime() > ArrivedFlight()[i].Time.AddHours(-3))
                {
                    status = FlightStatus.InFlight;
                }
                else if (GetActualTime() < ArrivedFlight()[i].Time.AddHours(-3))
                {
                    status = FlightStatus.ExpectedAt;
                }
            }
            return status;
        }

        static void GetDeparturesStatus()
        {
            for (int i = 0; i < DeparturedFlight().Length; i++)
            {
                if (GetActualTime() > DeparturedFlight()[i].Time.AddMinutes(5))
                {
                    var status = FlightStatus.DeparturedAt;
                    Console.WriteLine(DeparturedFlight()[i] + $", Status: {status}: {DeparturedFlight()[i].Time};");
                }
                else if (GetActualTime() <= DeparturedFlight()[i].Time.AddMinutes(5) & GetActualTime() >= DeparturedFlight()[i].Time.AddMinutes(-5))
                {
                    var status = FlightStatus.GateClosed;
                    Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                }
                else if (GetActualTime() >= DeparturedFlight()[i].Time.AddMinutes(-30) & GetActualTime() < DeparturedFlight()[i].Time.AddMinutes(-5))
                {
                    var status = FlightStatus.Boarding;
                    Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                }
                else if (GetActualTime() >= DeparturedFlight()[i].Time.AddHours(-2) & GetActualTime() < DeparturedFlight()[i].Time.AddMinutes(-30))
                {
                    var status = FlightStatus.CheckIn;
                    Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                }
                else if (GetActualTime() < DeparturedFlight()[i].Time.AddHours(-2))
                {
                    var status = "---";
                    Console.WriteLine(DeparturedFlight()[i] + $", Status: {status};");
                }
            }
        }

        static Flight[] ArrivedFlight()
        {
            #region Arrived flights

            int year = GetActualTime().Year;
            int month = GetActualTime().Month;
            int day = GetActualTime().Day;

            Flight beijing = new Flight();
            beijing.Number = 288;
            beijing.Terminal = 'A';
            beijing.Time = new DateTime(year, month, day, 00, 35, 0);
            beijing.CityFrom = "Beijing";
            beijing.CityTo = homeAirport;
            beijing.Airline = "Turkish Airlines Inc.";

            Flight almaty = new Flight();
            almaty.Number = 537;
            almaty.Terminal = 'D';
            almaty.Time = new DateTime(year, month, day, 01, 15, 0);
            almaty.CityFrom = "Almaty";
            almaty.CityTo = homeAirport;
            almaty.Airline = "Ukraine International Airlines";

            Flight telAviv = new Flight();
            telAviv.Number = 778;
            telAviv.Terminal = 'A';
            telAviv.Time = new DateTime(year, month, day, 02, 45, 0);
            telAviv.CityFrom = "Tel-Aviv";
            telAviv.CityTo = homeAirport;
            telAviv.Airline = "Ukraine International Airlines";

            Flight amsterdam = new Flight();
            amsterdam.Number = 106;
            amsterdam.Terminal = 'A';
            amsterdam.Time = new DateTime(year, month, day, 03, 20, 0);
            amsterdam.CityFrom = "Amsterdam";
            beijing.CityTo = homeAirport;
            amsterdam.Airline = "Ukraine International Airlines";

            Flight antalya = new Flight();
            antalya.Number = 5412;
            antalya.Terminal = 'A';
            antalya.Time = new DateTime(year, month, day, 04, 00, 0);
            antalya.CityFrom = "Antalya";
            antalya.CityTo = homeAirport;
            antalya.Airline = "Air France";

            Flight barcelona = new Flight();
            barcelona.Number = 7152;
            barcelona.Terminal = 'A';
            barcelona.Time = new DateTime(year, month, day, 04, 15, 0);
            barcelona.CityFrom = "Barcelona";
            barcelona.CityTo = homeAirport;
            barcelona.Airline = "Wind Rose Aviation Company";

            Flight london = new Flight();
            london.Number = 114;
            london.Terminal = 'A';
            london.Time = new DateTime(year, month, day, 05, 20, 0);
            london.CityFrom = "London";
            london.CityTo = homeAirport;
            london.Airline = "Ukraine International Airlines";

            Flight zaporizhia = new Flight();
            zaporizhia.Number = 3144;
            zaporizhia.Terminal = 'B';
            zaporizhia.Time = new DateTime(year, month, day, 07, 30, 0);
            zaporizhia.CityFrom = "Zaporizhia";
            beijing.CityTo = homeAirport;
            zaporizhia.Airline = "KLM Royal Dutch Airlines";

            Flight yerevan = new Flight();
            yerevan.Number = 612;
            yerevan.Terminal = 'D';
            yerevan.Time = new DateTime(year, month, day, 07, 50, 0);
            yerevan.CityFrom = "Yerevan";
            yerevan.CityTo = homeAirport;
            yerevan.Airline = "Ukraine International Airlines";

            Flight baku = new Flight();
            baku.Number = 6602;
            baku.Terminal = 'D';
            baku.Time = new DateTime(year, month, day, 07, 50, 0);
            baku.CityFrom = "Baku";
            beijing.CityTo = homeAirport;
            baku.Airline = "Azerbaijan Hava Yollary";

            Flight tbilisi = new Flight();
            tbilisi.Number = 3140;
            tbilisi.Terminal = 'D';
            tbilisi.Time = new DateTime(year, month, day, 09, 50, 0);
            tbilisi.CityFrom = "Tbilisi";
            tbilisi.CityTo = homeAirport;
            tbilisi.Airline = "KLM Royal Dutch Airlines";

            Flight kutaisi = new Flight();
            kutaisi.Number = 506;
            kutaisi.Terminal = 'D';
            kutaisi.Time = new DateTime(year, month, day, 10, 55, 0);
            kutaisi.CityFrom = "Kutaisi";
            kutaisi.CityTo = homeAirport;
            kutaisi.Airline = "KLM Royal Dutch Airlines";

            Flight dnipropetrovsk = new Flight();
            dnipropetrovsk.Number = 3130;
            dnipropetrovsk.Terminal = 'B';
            dnipropetrovsk.Time = new DateTime(year, month, day, 12, 00, 0);
            dnipropetrovsk.CityFrom = "Dnipropetrovsk";
            dnipropetrovsk.CityTo = homeAirport;
            dnipropetrovsk.Airline = "Dniproavia - Joint Stock Aviation Co.";

            Flight kharkiv = new Flight();
            kharkiv.Number = 24;
            kharkiv.Terminal = 'B';
            kharkiv.Time = new DateTime(year, month, day, 12, 30, 0);
            kharkiv.CityFrom = "Kharkiv";
            beijing.CityTo = homeAirport;
            kharkiv.Airline = "Ukraine International Airlines";

            Flight istanbul = new Flight();
            istanbul.Number = 716;
            istanbul.Terminal = 'A';
            istanbul.Time = new DateTime(year, month, day, 14, 15, 0);
            istanbul.CityFrom = "Istanbul";
            istanbul.CityTo = homeAirport;
            istanbul.Airline = "Turkish Airlines Inc.";

            Flight minsk = new Flight();
            minsk.Number = 894;
            minsk.Terminal = 'D';
            minsk.Time = new DateTime(year, month, day, 16, 30, 0);
            minsk.CityFrom = "Minsk";
            minsk.CityTo = homeAirport;
            minsk.Airline = "Ukraine International Airlines";

            Flight dubai = new Flight();
            dubai.Number = 374;
            dubai.Terminal = 'A';
            dubai.Time = new DateTime(year, month, day, 17, 00, 0);
            dubai.CityFrom = "Dubai";
            dubai.CityTo = homeAirport;
            dubai.Airline = "Ukraine International Airlines";

            Flight teheran = new Flight();
            teheran.Number = 752;
            teheran.Terminal = 'A';
            teheran.Time = new DateTime(year, month, day, 18, 00, 0);
            teheran.CityFrom = "Teheran";
            teheran.CityTo = homeAirport;
            teheran.Airline = "Ukraine International Airlines";

            Flight larnaca = new Flight();
            larnaca.Number = 344;
            larnaca.Terminal = 'A';
            larnaca.Time = new DateTime(year, month, day, 20, 50, 0);
            larnaca.CityFrom = "Larnaca";
            larnaca.CityTo = homeAirport;
            larnaca.Airline = "Ukraine International Airlines";

            Flight venezia = new Flight();
            venezia.Number = 336;
            venezia.Terminal = 'A';
            venezia.Time = new DateTime(year, month, day, 21, 15, 0);
            venezia.CityFrom = "Venezia";
            venezia.CityTo = homeAirport;
            venezia.Airline = "Ukraine International Airlines";

            Flight chisinau = new Flight();
            chisinau.Number = 9898;
            chisinau.Terminal = 'D';
            chisinau.Time = new DateTime(year, month, day, 23, 30, 0);
            chisinau.CityFrom = "Chisinau";
            chisinau.CityTo = homeAirport;
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

            int year = GetActualTime().Year;
            int month = GetActualTime().Month;
            int day = GetActualTime().Day;

            Flight chisinau = new Flight();
            chisinau.Number = 9899;
            chisinau.Terminal = 'D';
            chisinau.Time = new DateTime(year, month, day, 00, 00, 0);
            chisinau.CityFrom = homeAirport;
            chisinau.CityTo = "Chisinau";
            chisinau.Airline = "Air Moldova";

            Flight beijing = new Flight();
            beijing.Number = 289;
            beijing.Terminal = 'A';
            beijing.Time = new DateTime(year, month, day, 01, 05, 0);
            beijing.CityFrom = homeAirport;
            beijing.CityTo = "Beijing";
            beijing.Airline = "Turkish Airlines Inc.";

            Flight almaty = new Flight();
            almaty.Number = 538;
            almaty.Terminal = 'D';
            almaty.Time = new DateTime(year, month, day, 01, 45, 0);
            almaty.CityFrom = homeAirport;
            almaty.CityTo = "Almaty";
            almaty.Airline = "Ukraine International Airlines";

            Flight telAviv = new Flight();
            telAviv.Number = 779;
            telAviv.Terminal = 'A';
            telAviv.Time = new DateTime(year, month, day, 03, 15, 0);
            telAviv.CityFrom = homeAirport;
            telAviv.CityTo = "Tel-Aviv";
            telAviv.Airline = "Ukraine International Airlines";

            Flight amsterdam = new Flight();
            amsterdam.Number = 107;
            amsterdam.Terminal = 'A';
            amsterdam.Time = new DateTime(year, month, day, 03, 50, 0);
            amsterdam.CityFrom = homeAirport;
            amsterdam.CityTo = "Amsterdam";
            amsterdam.Airline = "Ukraine International Airlines";

            Flight antalya = new Flight();
            antalya.Number = 5413;
            antalya.Terminal = 'A';
            antalya.Time = new DateTime(year, month, day, 04, 30, 0);
            antalya.CityFrom = homeAirport;
            antalya.CityTo = "Antalya";
            antalya.Airline = "Air France";

            Flight barcelona = new Flight();
            barcelona.Number = 7153;
            barcelona.Terminal = 'A';
            barcelona.Time = new DateTime(year, month, day, 04, 45, 0);
            barcelona.CityFrom = homeAirport;
            barcelona.CityTo = "Barcelona";
            barcelona.Airline = "Wind Rose Aviation Company";

            Flight london = new Flight();
            london.Number = 115;
            london.Terminal = 'A';
            london.Time = new DateTime(year, month, day, 05, 50, 0);
            london.CityFrom = homeAirport;
            london.CityTo = "London";
            london.Airline = "Ukraine International Airlines";

            Flight zaporizhia = new Flight();
            zaporizhia.Number = 3145;
            zaporizhia.Terminal = 'B';
            zaporizhia.Time = new DateTime(year, month, day, 08, 00, 0);
            zaporizhia.CityFrom = homeAirport;
            zaporizhia.CityTo = "Zaporizhia";
            zaporizhia.Airline = "KLM Royal Dutch Airlines";

            Flight yerevan = new Flight();
            yerevan.Number = 613;
            yerevan.Terminal = 'D';
            yerevan.Time = new DateTime(year, month, day, 08, 20, 0);
            yerevan.CityFrom = homeAirport;
            yerevan.CityTo = "Yerevan";
            yerevan.Airline = "Ukraine International Airlines";

            Flight baku = new Flight();
            baku.Number = 6603;
            baku.Terminal = 'D';
            baku.Time = new DateTime(year, month, day, 08, 30, 0);
            baku.CityFrom = homeAirport;
            baku.CityTo = "Baku";
            baku.Airline = "Azerbaijan Hava Yollary";

            Flight tbilisi = new Flight();
            tbilisi.Number = 3141;
            tbilisi.Terminal = 'D';
            tbilisi.Time = new DateTime(year, month, day, 10, 20, 0);
            tbilisi.CityFrom = homeAirport;
            tbilisi.CityTo = "Tbilisi";
            tbilisi.Airline = "KLM Royal Dutch Airlines";

            Flight kutaisi = new Flight();
            kutaisi.Number = 507;
            kutaisi.Terminal = 'D';
            kutaisi.Time = new DateTime(year, month, day, 11, 25, 0);
            kutaisi.CityFrom = homeAirport;
            kutaisi.CityTo = "Kutaisi";
            kutaisi.Airline = "KLM Royal Dutch Airlines";

            Flight dnipropetrovsk = new Flight();
            dnipropetrovsk.Number = 3131;
            dnipropetrovsk.Terminal = 'B';
            dnipropetrovsk.Time = new DateTime(year, month, day, 12, 30, 0);
            dnipropetrovsk.CityFrom = homeAirport;
            dnipropetrovsk.CityTo = "Dnipropetrovsk";
            dnipropetrovsk.Airline = "Dniproavia - Joint Stock Aviation Co.";

            Flight kharkiv = new Flight();
            kharkiv.Number = 25;
            kharkiv.Terminal = 'B';
            kharkiv.Time = new DateTime(year, month, day, 13, 00, 0);
            kharkiv.CityFrom = homeAirport;
            kharkiv.CityTo = "Kharkiv";
            kharkiv.Airline = "Ukraine International Airlines";

            Flight istanbul = new Flight();
            istanbul.Number = 717;
            istanbul.Terminal = 'A';
            istanbul.Time = new DateTime(year, month, day, 14, 45, 0);
            istanbul.CityFrom = homeAirport;
            istanbul.CityTo = "Istanbul";
            istanbul.Airline = "Turkish Airlines Inc.";

            Flight minsk = new Flight();
            minsk.Number = 895;
            minsk.Terminal = 'D';
            minsk.Time = new DateTime(year, month, day, 17, 00, 0);
            minsk.CityFrom = homeAirport;
            minsk.CityTo = "Minsk";
            minsk.Airline = "Ukraine International Airlines";

            Flight dubai = new Flight();
            dubai.Number = 375;
            dubai.Terminal = 'A';
            dubai.Time = new DateTime(year, month, day, 17, 30, 0);
            dubai.CityFrom = homeAirport;
            dubai.CityTo = "Dubai";
            dubai.Airline = "Ukraine International Airlines";

            Flight teheran = new Flight();
            teheran.Number = 753;
            teheran.Terminal = 'A';
            teheran.Time = new DateTime(year, month, day, 18, 30, 0);
            teheran.CityFrom = homeAirport;
            teheran.CityTo = "Teheran";
            teheran.Airline = "Ukraine International Airlines";

            Flight larnaca = new Flight();
            larnaca.Number = 345;
            larnaca.Terminal = 'A';
            larnaca.Time = new DateTime(year, month, day, 21, 20, 0);
            larnaca.CityFrom = homeAirport;
            larnaca.CityTo = "Larnaca";
            larnaca.Airline = "Ukraine International Airlines";

            Flight venezia = new Flight();
            venezia.Number = 337;
            venezia.Terminal = 'A';
            venezia.Time = new DateTime(year, month, day, 21, 45, 0);
            venezia.CityFrom = homeAirport;
            venezia.CityTo = "Venezia";
            venezia.Airline = "Ukraine International Airlines";

            #endregion

            // Declare an arrow of departures.
            Flight[] departuredFlight = new Flight[] {chisinau, beijing, almaty, telAviv, amsterdam, antalya, barcelona,
                london, zaporizhia, yerevan, baku, tbilisi, kutaisi, dnipropetrovsk, kharkiv, istanbul, minsk, dubai, teheran,
                larnaca, venezia };

            return departuredFlight;
        }

        static DateTime GetActualTime()
        {
            DateTime now = DateTime.Now;
            return now;
        }
    }
}
