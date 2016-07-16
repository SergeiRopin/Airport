using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public enum FlightStatus
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

    public struct Flight
    {
        public DateTime Time;
        public int Number;
        public string CityTo;
        public string CityFrom;
        public string Airline;
        public string Terminal;
        public FlightStatus? Status;

        public override string ToString()
        {
            return $"Time: {Time}, Flight: {Number}, From: {CityFrom}, To: {CityTo}, Terminal: {Terminal}, Airline: {Airline}, Status: {Status}";
        }
    }

    public class Program
    {
        private static string unexpectedNumber = "\nPlease choose a number from the menu list!";
        private static string homeAirport = "Kyiv";

        /// <summary>
        /// Copy of initialized array of arrivals
        /// </summary>
        private static Flight[] arrivedFlights;

        /// <summary>
        /// Copy of initialized array of departures
        /// </summary>
        private static Flight[] departuredFlights;

        static void Main(string[] args)
        {
            try
            {
                // Flights initialization.
                ArrivedFlightsInitialization();
                DeparturedFlightsInitialization();

                Console.WindowHeight = Console.LargestWindowHeight;
                Console.WindowWidth = Console.LargestWindowWidth;

                Console.ForegroundColor = ConsoleColor.Green;
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
                        Console.WriteLine("\nUnexpected value has been entered!");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWrong input! " + ex.Message);
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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
        /// <summary>
        /// Editing an information about the flight
        /// </summary>
        static void EditFlight()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n*****Flight Edit menu*****\n");
                Console.ResetColor();

                Console.Write("Please type the number of flight to edit: ");
                int index = (int)uint.Parse(Console.ReadLine());

                for (int i = 0; i < arrivedFlights.Length; i++)
                {
                    if (arrivedFlights[i].Number == index)
                    {
                        Console.WriteLine("\nActual flight information:");
                        PrintArrivals(i);

                        // Time updating.
                        Console.WriteLine("\nPlease enter a new Time in the following format: ");
                        Console.Write("Hours (from 0 to 23): ");
                        int hours = (int)uint.Parse(Console.ReadLine());
                        Console.Write("Minutes (from 0 to 59): ");
                        int minutes = (int)uint.Parse(Console.ReadLine());

                        int year = GetActualTime().Year;
                        int month = GetActualTime().Month;
                        int day = GetActualTime().Day;
                        arrivedFlights[i].Time = new DateTime(year, month, day, hours, minutes, 00);

                        // CityFrom updating.
                        Console.Write("\nPlease enter a new City From: ");
                        string cityFromEdit = Console.ReadLine();
                        arrivedFlights[i].CityFrom = cityFromEdit;

                        // CityTo updating.
                        Console.Write("\nPlease enter a new City To: ");
                        string cityToEdit = Console.ReadLine();
                        arrivedFlights[i].CityTo = cityToEdit;

                        // Terminal updating.
                        Console.Write("\nPlease enter a new Terminal: ");
                        string terminalEdit = Console.ReadLine();
                        arrivedFlights[i].Terminal = terminalEdit;

                        // Airline updating.
                        Console.Write("\nPlease enter a new Airline: ");
                        string airlineEdit = Console.ReadLine();
                        arrivedFlights[i].Airline = airlineEdit;

                        // Flight number updating.
                        Console.Write("\nPlease enter a new flight Number: ");
                        int numberEdit = (int)uint.Parse(Console.ReadLine());
                        arrivedFlights[i].Number = numberEdit;

                        //Status updating.
                        Console.WriteLine();
                        Console.WriteLine(@"Please enter a new flight Status. Choose a number from the following List:
                        1. CheckIn,
                        2. GateClosed,
                        3. Arrived,
                        4. DeparturedAt,
                        5. Unknown,
                        6. Canceled,
                        7. ExpectedAt,
                        8. Delayed,
                        9. InFlight,
                        10. Boarding");
                        Console.Write("Please enter a number: ");
                        int statusEdit = (int)uint.Parse(Console.ReadLine());
                        switch (statusEdit)
                        {
                            case 1:
                                arrivedFlights[i].Status = FlightStatus.CheckIn;
                                break;
                            case 2:
                                arrivedFlights[i].Status = FlightStatus.GateClosed;
                                break;
                            case 3:
                                arrivedFlights[i].Status = FlightStatus.Arrived;
                                break;
                            case 4:
                                arrivedFlights[i].Status = FlightStatus.DeparturedAt;
                                break;
                            case 5:
                                arrivedFlights[i].Status = FlightStatus.Unknown;
                                break;
                            case 6:
                                arrivedFlights[i].Status = FlightStatus.Canceled;
                                break;
                            case 7:
                                arrivedFlights[i].Status = FlightStatus.ExpectedAt;
                                break;
                            case 8:
                                arrivedFlights[i].Status = FlightStatus.Delayed;
                                break;
                            case 9:
                                arrivedFlights[i].Status = FlightStatus.InFlight;
                                break;
                            case 10:
                                arrivedFlights[i].Status = FlightStatus.Boarding;
                                break;
                            default:
                                Console.WriteLine(unexpectedNumber);
                                break;
                        }
                        Console.WriteLine();
                        Console.WriteLine($"The flight {index} has been edited to flight {numberEdit}!");
                        PrintArrivals(i);
                        break;
                    }

                    else if (departuredFlights[i].Number == index)
                    {
                        Console.WriteLine("\nActual flight information:");
                        PrintDepartures(i);

                        // Time updating.
                        Console.WriteLine("\nPlease enter a new Time in the following format: ");
                        Console.Write("Hours (from 0 to 23): ");
                        int hours = (int)uint.Parse(Console.ReadLine());
                        Console.Write("Minutes (from 0 to 59): ");
                        int minutes = (int)uint.Parse(Console.ReadLine());

                        int year = GetActualTime().Year;
                        int month = GetActualTime().Month;
                        int day = GetActualTime().Day;
                        departuredFlights[i].Time = new DateTime(year, month, day, hours, minutes, 00);

                        // CityFrom updating.
                        Console.Write("\nPlease enter a new City From: ");
                        string cityFromEdit = Console.ReadLine();
                        departuredFlights[i].CityFrom = cityFromEdit;

                        // CityTo updating.
                        Console.Write("\nPlease enter a new City To: ");
                        string cityToEdit = Console.ReadLine();
                        departuredFlights[i].CityTo = cityToEdit;

                        // Terminal updating.
                        Console.Write("\nPlease enter a new Terminal: ");
                        string terminalEdit = Console.ReadLine();
                        departuredFlights[i].Terminal = terminalEdit;

                        // Airline updating.
                        Console.Write("\nPlease enter a new Airline: ");
                        string airlineEdit = Console.ReadLine();
                        departuredFlights[i].Airline = airlineEdit;

                        // Flight number updating
                        Console.Write("\nPlease enter a new flight Number: ");
                        int numberEdit = (int)uint.Parse(Console.ReadLine());
                        departuredFlights[i].Number = numberEdit;

                        // Status updating.
                        Console.WriteLine();
                        Console.WriteLine(@"Please enter a new flight Status. Choose a number from the following List:
                        1. CheckIn,
                        2. GateClosed,
                        3. Arrived,
                        4. DeparturedAt,
                        5. Unknown,
                        6. Canceled,
                        7. ExpectedAt,
                        8. Delayed,
                        9. InFlight,
                        10. Boarding");
                        Console.Write("Please enter a number: ");
                        int statusEdit = (int)uint.Parse(Console.ReadLine());
                        switch (statusEdit)
                        {
                            case 1:
                                departuredFlights[i].Status = FlightStatus.CheckIn;
                                break;
                            case 2:
                                departuredFlights[i].Status = FlightStatus.GateClosed;
                                break;
                            case 3:
                                departuredFlights[i].Status = FlightStatus.Arrived;
                                break;
                            case 4:
                                departuredFlights[i].Status = FlightStatus.DeparturedAt;
                                break;
                            case 5:
                                departuredFlights[i].Status = FlightStatus.Unknown;
                                break;
                            case 6:
                                departuredFlights[i].Status = FlightStatus.Canceled;
                                break;
                            case 7:
                                departuredFlights[i].Status = FlightStatus.ExpectedAt;
                                break;
                            case 8:
                                departuredFlights[i].Status = FlightStatus.Delayed;
                                break;
                            case 9:
                                departuredFlights[i].Status = FlightStatus.InFlight;
                                break;
                            case 10:
                                departuredFlights[i].Status = FlightStatus.Boarding;
                                break;
                            default:
                                Console.WriteLine(unexpectedNumber);
                                break;
                        }
                        Console.WriteLine();
                        Console.WriteLine($"The flight {index} has been edited to flight {numberEdit}!");
                        PrintDepartures(i);
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nPress \"Backpace\" to return to the main menu; press any key to edit another flight");
                Console.ResetColor();
            }
            while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
        #endregion

        #region DeleteFlight() code
        /// <summary>
        /// Allows to set the status of flight to Canceled
        /// </summary>
        static void DeleteFlight()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n*****Flight Cancelation menu*****\n");
                Console.ResetColor();

                Console.Write("Please type the number of flight to cancel: ");
                int index = (int)uint.Parse(Console.ReadLine());

                for (int i = 0; i < arrivedFlights.Length; i++)
                {
                    if (arrivedFlights[i].Number == index)
                    {
                        arrivedFlights[i].Status = FlightStatus.Canceled;

                        Console.WriteLine();
                        Console.WriteLine($"The flight {index} has been canceled!");
                        PrintArrivals(i);
                    }

                    if (departuredFlights[i].Number == index)
                    {
                        departuredFlights[i].Status = FlightStatus.Canceled;

                        Console.WriteLine();
                        Console.WriteLine($"The flight {index} has been canceled!");
                        PrintDepartures(i);
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nPress \"Backpace\" to return to the main menu; press any key to cancel another flight");
                Console.ResetColor();
            }
            while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
        #endregion

        #region DisplayFlight() code
        /// <summary>
        /// Print an information about all arrival/departured flights
        /// </summary>
        static void DisplayFlight()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
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
                        for (int i = 0; i < arrivedFlights.Length; i++)
                        {
                            PrintArrivals(i);
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nThe list of Departures:\n");
                        for (int i = 0; i < departuredFlights.Length; i++)
                        {
                            PrintDepartures(i);
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(unexpectedNumber);
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nPress \"Backpace\" to return to the main menu; press any key to select another flights");
                Console.ResetColor();
            }
            while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
        #endregion

        #region SearchFlight() code
        /// <summary>
        /// Search flights by the specified criteria and print an information about ones
        /// </summary>
        static void SearchFlight()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n*****Search Flight menu*****\n");
                Console.ResetColor();
                Console.WriteLine(@"Please choose one of the following menu items:

                1. Search by number;
                2. Search by time of arrival/departure;
                3. Search by city;
                4. Search all flights in this hour;");

                Console.Write("Your choise: ");
                int index = (int)uint.Parse(Console.ReadLine());
                int tmp = new int();
                string noMatching = "\nNo flights with specified data!";

                switch (index)
                {
                    case 1:
                        Console.Write("\nPlease enter a number of your flight: ");
                        int flightNumber = (int)uint.Parse(Console.ReadLine());
                        Console.WriteLine();

                        // Print matching flights.
                        for (int i = 0; i < arrivedFlights.Length; i++)
                        {
                            if (flightNumber == arrivedFlights[i].Number)
                            {
                                tmp++;
                                PrintArrivals(i);
                            }
                        }

                        for (int i = 0; i < departuredFlights.Length; i++)
                        {
                            if (flightNumber == departuredFlights[i].Number)
                            {
                                tmp++;
                                PrintDepartures(i);
                            }
                        }

                        if (tmp == 0)
                        {
                            Console.WriteLine(noMatching);
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nSpecify the time of a flight in the following format: ");
                        Console.Write("Hours (from 0 to 23): ");
                        int hours = (int)uint.Parse(Console.ReadLine());
                        Console.Write("Minutes (from 0 to 59): ");
                        int minutes = (int)uint.Parse(Console.ReadLine());
                        Console.WriteLine();

                        // Print matching flights.
                        for (int i = 0; i < arrivedFlights.Length; i++)
                        {
                            if (arrivedFlights[i].Time.Hour == hours && arrivedFlights[i].Time.Minute == minutes)
                            {
                                tmp++;
                                PrintArrivals(i);
                            }
                        }

                        for (int i = 0; i < departuredFlights.Length; i++)
                        {
                            if (departuredFlights[i].Time.Hour == hours && departuredFlights[i].Time.Minute == minutes)
                            {
                                tmp++;
                                PrintDepartures(i);
                            }
                        }

                        if (tmp == 0)
                        {
                            Console.WriteLine(noMatching);
                        }
                        break;

                    case 3:
                        Console.Write("\nPlease enter an arrival/departure city: ");
                        string city = Console.ReadLine();

                        // Convert city into the right format. First letter in upper register, others in lower.
                        char[] cityChars = city.ToCharArray();
                        for (int i = 0; i < cityChars.Length; i++)
                        {
                            cityChars[i] = char.ToLower(cityChars[i]);
                        }
                        char updatedChar = char.ToUpper(cityChars[0]);
                        cityChars[0] = updatedChar;
                        string updatedCity = new string(cityChars);

                        Console.WriteLine();

                        // Print matching flights.
                        for (int i = 0; i < arrivedFlights.Length; i++)
                        {
                            if (arrivedFlights[i].CityFrom == updatedCity | arrivedFlights[i].CityTo == updatedCity)
                            {
                                tmp++;
                                PrintArrivals(i);
                            }
                        }

                        for (int i = 0; i < departuredFlights.Length; i++)
                        {
                            if (departuredFlights[i].CityFrom == updatedCity | departuredFlights[i].CityTo == updatedCity)
                            {
                                tmp++;
                                PrintDepartures(i);
                            }
                        }

                        if (tmp == 0)
                        {
                            Console.WriteLine(noMatching);
                        }
                        break;

                    case 4:
                        Console.WriteLine("\nFlights in this hour: ");

                        // Print arrival flights.
                        for (int i = 0; i < arrivedFlights.Length; i++)
                        {
                            if (GetActualTime() > arrivedFlights[i].Time.AddMinutes(-30) & GetActualTime() < arrivedFlights[i].Time.AddMinutes(30))
                            {
                                tmp++;
                                PrintArrivals(i);
                            }
                        }
                        // Print departured flights.
                        for (int i = 0; i < departuredFlights.Length; i++)
                        {
                            if (GetActualTime() > departuredFlights[i].Time.AddMinutes(-30) & GetActualTime() < departuredFlights[i].Time.AddMinutes(30))
                            {
                                tmp++;
                                PrintDepartures(i);
                            }
                        }

                        if (tmp == 0)
                        {
                            Console.WriteLine(noMatching);
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(unexpectedNumber);
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nPress \"Backpace\" to return to the main menu; press any key to search another flight");
                Console.ResetColor();
            }
            while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
        #endregion

        /// <summary>
        /// Print flight info about arrived flights.
        /// </summary>
        static void PrintArrivals(int i)
        {
            if (arrivedFlights[i].Status == FlightStatus.ExpectedAt)
                Console.WriteLine(arrivedFlights[i] + $": {arrivedFlights[i].Time};");
            else
                Console.WriteLine(arrivedFlights[i]);
        }

        /// <summary>
        /// Print flight info about departured flights.
        /// </summary>
        static void PrintDepartures(int i)
        {
            if (departuredFlights[i].Status == FlightStatus.DeparturedAt)
                Console.WriteLine(departuredFlights[i] + $": {departuredFlights[i].Time};");
            else
                Console.WriteLine(departuredFlights[i]);
        }

        /// <summary>
        /// Initialize an array of arrived Flights
        /// </summary>
        static void ArrivedFlightsInitialization()
        {
            #region Arrived flights

            int year = GetActualTime().Year;
            int month = GetActualTime().Month;
            int day = GetActualTime().Day;

            Flight beijing = new Flight();
            beijing.Number = 288;
            beijing.Terminal = "A";
            beijing.Time = new DateTime(year, month, day, 00, 35, 0);
            beijing.CityFrom = "Beijing";
            beijing.CityTo = homeAirport;
            beijing.Airline = "Turkish Airlines Inc.";
            beijing.Status = FlightStatus.Arrived;

            Flight almaty = new Flight();
            almaty.Number = 537;
            almaty.Terminal = "D";
            almaty.Time = new DateTime(year, month, day, 01, 15, 0);
            almaty.CityFrom = "Almaty";
            almaty.CityTo = homeAirport;
            almaty.Airline = "Ukraine International Airlines";
            almaty.Status = FlightStatus.Arrived;

            Flight telAviv = new Flight();
            telAviv.Number = 778;
            telAviv.Terminal = "A";
            telAviv.Time = new DateTime(year, month, day, 02, 45, 0);
            telAviv.CityFrom = "Tel-Aviv";
            telAviv.CityTo = homeAirport;
            telAviv.Airline = "Ukraine International Airlines";
            telAviv.Status = FlightStatus.Arrived;

            Flight amsterdam = new Flight();
            amsterdam.Number = 106;
            amsterdam.Terminal = "A";
            amsterdam.Time = new DateTime(year, month, day, 03, 20, 0);
            amsterdam.CityFrom = "Amsterdam";
            amsterdam.CityTo = homeAirport;
            amsterdam.Airline = "Ukraine International Airlines";
            amsterdam.Status = FlightStatus.Arrived;

            Flight antalya = new Flight();
            antalya.Number = 5412;
            antalya.Terminal = "A";
            antalya.Time = new DateTime(year, month, day, 04, 00, 0);
            antalya.CityFrom = "Antalya";
            antalya.CityTo = homeAirport;
            antalya.Airline = "Air France";
            antalya.Status = FlightStatus.Arrived;

            Flight barcelona = new Flight();
            barcelona.Number = 7152;
            barcelona.Terminal = "A";
            barcelona.Time = new DateTime(year, month, day, 04, 15, 0);
            barcelona.CityFrom = "Barcelona";
            barcelona.CityTo = homeAirport;
            barcelona.Airline = "Wind Rose Aviation Company";
            barcelona.Status = FlightStatus.Arrived;

            Flight london = new Flight();
            london.Number = 114;
            london.Terminal = "A";
            london.Time = new DateTime(year, month, day, 05, 20, 0);
            london.CityFrom = "London";
            london.CityTo = homeAirport;
            london.Airline = "Ukraine International Airlines";
            london.Status = FlightStatus.Arrived;

            Flight zaporizhia = new Flight();
            zaporizhia.Number = 3144;
            zaporizhia.Terminal = "B";
            zaporizhia.Time = new DateTime(year, month, day, 07, 30, 0);
            zaporizhia.CityFrom = "Zaporizhia";
            zaporizhia.CityTo = homeAirport;
            zaporizhia.Airline = "KLM Royal Dutch Airlines";
            zaporizhia.Status = FlightStatus.Arrived;

            Flight yerevan = new Flight();
            yerevan.Number = 612;
            yerevan.Terminal = "D";
            yerevan.Time = new DateTime(year, month, day, 07, 50, 0);
            yerevan.CityFrom = "Yerevan";
            yerevan.CityTo = homeAirport;
            yerevan.Airline = "Ukraine International Airlines";
            yerevan.Status = FlightStatus.Arrived;

            Flight baku = new Flight();
            baku.Number = 6602;
            baku.Terminal = "D";
            baku.Time = new DateTime(year, month, day, 07, 50, 0);
            baku.CityFrom = "Baku";
            baku.CityTo = homeAirport;
            baku.Airline = "Azerbaijan Hava Yollary";
            baku.Status = FlightStatus.Arrived;

            Flight tbilisi = new Flight();
            tbilisi.Number = 3140;
            tbilisi.Terminal = "D";
            tbilisi.Time = new DateTime(year, month, day, 09, 50, 0);
            tbilisi.CityFrom = "Tbilisi";
            tbilisi.CityTo = homeAirport;
            tbilisi.Airline = "KLM Royal Dutch Airlines";
            tbilisi.Status = FlightStatus.Arrived;

            Flight kutaisi = new Flight();
            kutaisi.Number = 506;
            kutaisi.Terminal = "D";
            kutaisi.Time = new DateTime(year, month, day, 10, 55, 0);
            kutaisi.CityFrom = "Kutaisi";
            kutaisi.CityTo = homeAirport;
            kutaisi.Airline = "KLM Royal Dutch Airlines";
            kutaisi.Status = FlightStatus.Arrived;

            Flight dnipropetrovsk = new Flight();
            dnipropetrovsk.Number = 3130;
            dnipropetrovsk.Terminal = "B";
            dnipropetrovsk.Time = new DateTime(year, month, day, 12, 00, 0);
            dnipropetrovsk.CityFrom = "Dnipropetrovsk";
            dnipropetrovsk.CityTo = homeAirport;
            dnipropetrovsk.Airline = "Dniproavia - Joint Stock Aviation Co.";
            dnipropetrovsk.Status = FlightStatus.InFlight;

            Flight kharkiv = new Flight();
            kharkiv.Number = 24;
            kharkiv.Terminal = "B";
            kharkiv.Time = new DateTime(year, month, day, 12, 30, 0);
            kharkiv.CityFrom = "Kharkiv";
            kharkiv.CityTo = homeAirport;
            kharkiv.Airline = "Ukraine International Airlines";
            kharkiv.Status = FlightStatus.InFlight;

            Flight istanbul = new Flight();
            istanbul.Number = 716;
            istanbul.Terminal = "A";
            istanbul.Time = new DateTime(year, month, day, 14, 15, 0);
            istanbul.CityFrom = "Istanbul";
            istanbul.CityTo = homeAirport;
            istanbul.Airline = "Turkish Airlines Inc.";
            istanbul.Status = FlightStatus.InFlight;

            Flight minsk = new Flight();
            minsk.Number = 894;
            minsk.Terminal = "D";
            minsk.Time = new DateTime(year, month, day, 16, 30, 0);
            minsk.CityFrom = "Minsk";
            minsk.CityTo = homeAirport;
            minsk.Airline = "Ukraine International Airlines";
            minsk.Status = FlightStatus.InFlight;

            Flight dubai = new Flight();
            dubai.Number = 374;
            dubai.Terminal = "A";
            dubai.Time = new DateTime(year, month, day, 17, 00, 0);
            dubai.CityFrom = "Dubai";
            dubai.CityTo = homeAirport;
            dubai.Airline = "Ukraine International Airlines";
            dubai.Status = FlightStatus.InFlight;

            Flight teheran = new Flight();
            teheran.Number = 752;
            teheran.Terminal = "A";
            teheran.Time = new DateTime(year, month, day, 18, 00, 0);
            teheran.CityFrom = "Teheran";
            teheran.CityTo = homeAirport;
            teheran.Airline = "Ukraine International Airlines";
            teheran.Status = FlightStatus.InFlight;

            Flight larnaca = new Flight();
            larnaca.Number = 344;
            larnaca.Terminal = "A";
            larnaca.Time = new DateTime(year, month, day, 20, 50, 0);
            larnaca.CityFrom = "Larnaca";
            larnaca.CityTo = homeAirport;
            larnaca.Airline = "Ukraine International Airlines";
            larnaca.Status = FlightStatus.ExpectedAt;

            Flight venezia = new Flight();
            venezia.Number = 336;
            venezia.Terminal = "A";
            venezia.Time = new DateTime(year, month, day, 21, 15, 0);
            venezia.CityFrom = "Venezia";
            venezia.CityTo = homeAirport;
            venezia.Airline = "Ukraine International Airlines";
            venezia.Status = FlightStatus.ExpectedAt;

            Flight chisinau = new Flight();
            chisinau.Number = 9898;
            chisinau.Terminal = "D";
            chisinau.Time = new DateTime(year, month, day, 23, 30, 0);
            chisinau.CityFrom = "Chisinau";
            chisinau.CityTo = homeAirport;
            chisinau.Airline = "Air Moldova";
            chisinau.Status = FlightStatus.ExpectedAt;

            #endregion

            // Declare an arrow of arrivals.
            Flight[] arrivals = new Flight[] { beijing, almaty, telAviv, amsterdam, antalya, barcelona, london,
                zaporizhia, yerevan, baku, tbilisi, kutaisi, dnipropetrovsk, kharkiv, istanbul, minsk, dubai, teheran,
                larnaca, venezia, chisinau };

            arrivedFlights = arrivals;
        }

        /// <summary>
        /// Initialize an array of departured Flights
        /// </summary>
        static void DeparturedFlightsInitialization()
        {
            #region Departured flights

            int year = GetActualTime().Year;
            int month = GetActualTime().Month;
            int day = GetActualTime().Day;

            Flight chisinau = new Flight();
            chisinau.Number = 9899;
            chisinau.Terminal = "D";
            chisinau.Time = new DateTime(year, month, day, 00, 00, 0);
            chisinau.CityFrom = homeAirport;
            chisinau.CityTo = "Chisinau";
            chisinau.Airline = "Air Moldova";
            chisinau.Status = FlightStatus.DeparturedAt;

            Flight beijing = new Flight();
            beijing.Number = 289;
            beijing.Terminal = "A";
            beijing.Time = new DateTime(year, month, day, 01, 05, 0);
            beijing.CityFrom = homeAirport;
            beijing.CityTo = "Beijing";
            beijing.Airline = "Turkish Airlines Inc.";
            beijing.Status = FlightStatus.DeparturedAt;

            Flight almaty = new Flight();
            almaty.Number = 538;
            almaty.Terminal = "D";
            almaty.Time = new DateTime(year, month, day, 01, 45, 0);
            almaty.CityFrom = homeAirport;
            almaty.CityTo = "Almaty";
            almaty.Airline = "Ukraine International Airlines";
            almaty.Status = FlightStatus.DeparturedAt;

            Flight telAviv = new Flight();
            telAviv.Number = 779;
            telAviv.Terminal = "A";
            telAviv.Time = new DateTime(year, month, day, 03, 15, 0);
            telAviv.CityFrom = homeAirport;
            telAviv.CityTo = "Tel-Aviv";
            telAviv.Airline = "Ukraine International Airlines";
            telAviv.Status = FlightStatus.DeparturedAt;

            Flight amsterdam = new Flight();
            amsterdam.Number = 107;
            amsterdam.Terminal = "A";
            amsterdam.Time = new DateTime(year, month, day, 03, 50, 0);
            amsterdam.CityFrom = homeAirport;
            amsterdam.CityTo = "Amsterdam";
            amsterdam.Airline = "Ukraine International Airlines";
            amsterdam.Status = FlightStatus.DeparturedAt;

            Flight antalya = new Flight();
            antalya.Number = 5413;
            antalya.Terminal = "A";
            antalya.Time = new DateTime(year, month, day, 04, 30, 0);
            antalya.CityFrom = homeAirport;
            antalya.CityTo = "Antalya";
            antalya.Airline = "Air France";
            antalya.Status = FlightStatus.DeparturedAt;

            Flight barcelona = new Flight();
            barcelona.Number = 7153;
            barcelona.Terminal = "A";
            barcelona.Time = new DateTime(year, month, day, 04, 45, 0);
            barcelona.CityFrom = homeAirport;
            barcelona.CityTo = "Barcelona";
            barcelona.Airline = "Wind Rose Aviation Company";
            barcelona.Status = FlightStatus.DeparturedAt;

            Flight london = new Flight();
            london.Number = 115;
            london.Terminal = "A";
            london.Time = new DateTime(year, month, day, 05, 50, 0);
            london.CityFrom = homeAirport;
            london.CityTo = "London";
            london.Airline = "Ukraine International Airlines";
            london.Status = FlightStatus.DeparturedAt;

            Flight zaporizhia = new Flight();
            zaporizhia.Number = 3145;
            zaporizhia.Terminal = "B";
            zaporizhia.Time = new DateTime(year, month, day, 08, 00, 0);
            zaporizhia.CityFrom = homeAirport;
            zaporizhia.CityTo = "Zaporizhia";
            zaporizhia.Airline = "KLM Royal Dutch Airlines";
            zaporizhia.Status = FlightStatus.Boarding;

            Flight yerevan = new Flight();
            yerevan.Number = 613;
            yerevan.Terminal = "D";
            yerevan.Time = new DateTime(year, month, day, 08, 20, 0);
            yerevan.CityFrom = homeAirport;
            yerevan.CityTo = "Yerevan";
            yerevan.Airline = "Ukraine International Airlines";
            yerevan.Status = FlightStatus.Boarding;

            Flight baku = new Flight();
            baku.Number = 6603;
            baku.Terminal = "D";
            baku.Time = new DateTime(year, month, day, 08, 30, 0);
            baku.CityFrom = homeAirport;
            baku.CityTo = "Baku";
            baku.Airline = "Azerbaijan Hava Yollary";
            baku.Status = FlightStatus.Boarding;

            Flight tbilisi = new Flight();
            tbilisi.Number = 3141;
            tbilisi.Terminal = "D";
            tbilisi.Time = new DateTime(year, month, day, 10, 20, 0);
            tbilisi.CityFrom = homeAirport;
            tbilisi.CityTo = "Tbilisi";
            tbilisi.Airline = "KLM Royal Dutch Airlines";
            tbilisi.Status = FlightStatus.CheckIn;

            Flight kutaisi = new Flight();
            kutaisi.Number = 507;
            kutaisi.Terminal = "D";
            kutaisi.Time = new DateTime(year, month, day, 11, 25, 0);
            kutaisi.CityFrom = homeAirport;
            kutaisi.CityTo = "Kutaisi";
            kutaisi.Airline = "KLM Royal Dutch Airlines";
            kutaisi.Status = FlightStatus.CheckIn;

            Flight dnipropetrovsk = new Flight();
            dnipropetrovsk.Number = 3131;
            dnipropetrovsk.Terminal = "B";
            dnipropetrovsk.Time = new DateTime(year, month, day, 12, 30, 0);
            dnipropetrovsk.CityFrom = homeAirport;
            dnipropetrovsk.CityTo = "Dnipropetrovsk";
            dnipropetrovsk.Airline = "Dniproavia - Joint Stock Aviation Co.";
            dnipropetrovsk.Status = FlightStatus.CheckIn;

            Flight kharkiv = new Flight();
            kharkiv.Number = 25;
            kharkiv.Terminal = "B";
            kharkiv.Time = new DateTime(year, month, day, 13, 00, 0);
            kharkiv.CityFrom = homeAirport;
            kharkiv.CityTo = "Kharkiv";
            kharkiv.Airline = "Ukraine International Airlines";
            kharkiv.Status = FlightStatus.CheckIn;

            Flight istanbul = new Flight();
            istanbul.Number = 717;
            istanbul.Terminal = "A";
            istanbul.Time = new DateTime(year, month, day, 14, 45, 0);
            istanbul.CityFrom = homeAirport;
            istanbul.CityTo = "Istanbul";
            istanbul.Airline = "Turkish Airlines Inc.";
            istanbul.Status = FlightStatus.CheckIn;

            Flight minsk = new Flight();
            minsk.Number = 895;
            minsk.Terminal = "D";
            minsk.Time = new DateTime(year, month, day, 17, 00, 0);
            minsk.CityFrom = homeAirport;
            minsk.CityTo = "Minsk";
            minsk.Airline = "Ukraine International Airlines";
            minsk.Status = FlightStatus.Unknown;

            Flight dubai = new Flight();
            dubai.Number = 375;
            dubai.Terminal = "A";
            dubai.Time = new DateTime(year, month, day, 17, 30, 0);
            dubai.CityFrom = homeAirport;
            dubai.CityTo = "Dubai";
            dubai.Airline = "Ukraine International Airlines";
            dubai.Status = FlightStatus.Unknown;

            Flight teheran = new Flight();
            teheran.Number = 753;
            teheran.Terminal = "A";
            teheran.Time = new DateTime(year, month, day, 18, 30, 0);
            teheran.CityFrom = homeAirport;
            teheran.CityTo = "Teheran";
            teheran.Airline = "Ukraine International Airlines";
            teheran.Status = FlightStatus.Unknown;

            Flight larnaca = new Flight();
            larnaca.Number = 345;
            larnaca.Terminal = "A";
            larnaca.Time = new DateTime(year, month, day, 21, 20, 0);
            larnaca.CityFrom = homeAirport;
            larnaca.CityTo = "Larnaca";
            larnaca.Airline = "Ukraine International Airlines";
            larnaca.Status = FlightStatus.Unknown;

            Flight venezia = new Flight();
            venezia.Number = 337;
            venezia.Terminal = "A";
            venezia.Time = new DateTime(year, month, day, 23, 45, 0);
            venezia.CityFrom = homeAirport;
            venezia.CityTo = "Venezia";
            venezia.Airline = "Ukraine International Airlines";
            venezia.Status = FlightStatus.Unknown;

            #endregion

            // Declare an arrow of departures.
            Flight[] departures = new Flight[] {chisinau, beijing, almaty, telAviv, amsterdam, antalya, barcelona,
                london, zaporizhia, yerevan, baku, tbilisi, kutaisi, dnipropetrovsk, kharkiv, istanbul, minsk, dubai, teheran,
                larnaca, venezia };

            departuredFlights = departures;
        }

        /// <summary>
        /// Create an instance of DateTime.Now
        /// </summary>
        /// <returns>current time</returns>
        static DateTime GetActualTime()
        {
            DateTime now = DateTime.Now;
            return now;
        }
    }
}
