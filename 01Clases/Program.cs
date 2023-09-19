using System.Collections;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _01Clases
{
    internal class Program
    {
        static string selection = "";
        static Boolean correct = false;
        static Boolean exit = false;
        static int nSelection = 0;
        static Juego juego = new Juego();
        static ArrayList shelving = new ArrayList();
        static List<Ship> allShips = new List<Ship>();
        static ArrayList allRents = new ArrayList();
        static int index = 1;
        

        static void Main(string[] args)
        {

            //Dependencias para usar el Español, pero no funciona
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            CultureInfo culture = new CultureInfo("es-ES");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            do
            {
                Console.WriteLine(
                "         Menu        " + '\n' +
                "---------------------" + '\n' +
                "1 - Manejor de fechas " + '\n' +
                "2 - Gestión juegos" + '\n' +
                "3 - Alquiler puerto" + '\n' +
                "4 - Salir" + '\n'
                );

                String selection = Console.ReadLine();

                correct = int.TryParse(selection, out nSelection);
                try
                {

                    if (nSelection > 4 || nSelection < 1)
                    {
                        correct = false;
                    }

                    switch (nSelection)
                    {

                        case 1:
                            correct = false;
                            nSelection = 0;
                            DateTime date1;
                            DateTime date2;
                            string dateString1;
                            int intUser;
                            menu1();
                            checkNumberMenu(1, 5);

                            if (nSelection == 1)
                            {
                                Console.WriteLine("" +
                                "Introduzca la fecha en el siguiente formato: " + '\n' +
                                "              dd mm yyyy                     " + '\n' +
                                 +'\n');
                                dateString1 = Console.ReadLine();

                                date1 = Convert.ToDateTime(dateString1);
                                Console.WriteLine(date1.DayOfWeek);
                                Console.WriteLine('\n');
                            }
                            if (nSelection == 2)
                            {
                                date1 = DateTime.Today;

                                Console.WriteLine(
                                    "¿Cuantos días quieres sumar al día de hoy?" + '\n' +
                                    "Si quieres restar días, introduce el número en negativo"
                                    + '\n');

                                dateString1 = Console.ReadLine();
                                intUser = int.Parse(dateString1);
                                date1 = date1.AddDays(intUser);
                                Console.WriteLine("El día seleccionado es:");
                                Console.WriteLine(date1);
                                Console.WriteLine("Dia de la semana: " + date1.DayOfWeek);
                                Console.WriteLine("Día del año: " + date1.DayOfYear + "\n");
                            }
                            if (nSelection == 3)
                            {
                                Console.WriteLine("Introduce la primera fecha" + '\n');
                                dateString1 = Console.ReadLine();
                                date1 = Convert.ToDateTime(dateString1);
                                Console.WriteLine('\n' + "Introduce la segunda fecha" + '\n');
                                dateString1 = Console.ReadLine();
                                date2 = Convert.ToDateTime(dateString1);
                                Console.WriteLine('\n' + "La diferencia entre fechas es:" + '\n');
                                TimeSpan differencesDates = date1 - date2;

                                int positiveDate = (int)differencesDates.TotalDays;
                                positiveDate = Math.Abs(positiveDate);

                                int differencesMonths = differencesDates.Days / 30;
                                differencesMonths = Math.Abs(differencesMonths);

                                int differencesYears = differencesMonths / 12;
                                differencesYears = Math.Abs(differencesYears);

                                Console.WriteLine("Han transcurrido " + positiveDate + " días " +
                                    +differencesMonths + " Meses " + differencesYears + " Años " + '\n');

                            }
                            if (nSelection == 4)
                            {
                                DateTime[] dates = twoDates();
                                if (dates[0] < dates[1])
                                {
                                    Console.WriteLine("La primera fecha es mayor");
                                }
                                else if (dates[0] > dates[1])
                                {
                                    Console.WriteLine("La segunda fecha es mayor");
                                }
                                if (dates[0] == dates[1])
                                {
                                    Console.WriteLine("Las fechas son iguales");
                                }

                            }
                            if (nSelection == 5)
                            {
                                Console.WriteLine("Introduce una fecha con el siguiente formato dd/mm/yyyy" + '\n');
                                dateString1 = Console.ReadLine();
                                date1 = Convert.ToDateTime(dateString1);
                                Console.WriteLine(date1.ToString("D"));
                            }

                            break;

                        case 2:

                            subMenu2();
                            checkNumberMenu(1, 5);

                            switch (nSelection)
                            {
                                case 1:
                                    insertarJuego();
                                    break;
                                case 2:
                                    mostrarJuegos();
                                    break;
                                case 3:
                            
                                    Juego newJuego = buscarJuego();

                                    menuModificarJuego();
                                    checkNumberMenu(1,4);

                                    switch (nSelection)
                                    {
                                        case 1:
                                            Console.WriteLine("Introduce el núevo titulo " + '\n');
                                            newJuego.titulo = Console.ReadLine();
                                            
                                        break;
                                        case 2:
                                            Console.WriteLine("Introduce el núevo año " + '\n');
                                            newJuego.anno = checkNumberMenu(1800, 3000);
                                            
                                            break;
                                        case 3:
                                            menuGenero();
                                            newJuego.Genero = juego.Genero;

                                        break;
                                        case 4:
                                            menuPlataforma();
                                            newJuego.Plataforma = juego.Plataforma;
                                        break;
                                    }

                                    break;
                                case 4:
                                    eliminarJuego(buscarJuego());
                                    break;
                            }
                            break;

                        case 3:

                            menuPuerto();
                            switch (checkNumberMenu(1, 7))
                            {
                                case 1:
                                   menuTipoBarco();
                                    switch (checkNumberMenu(1,5))
                                    {
                                        case 1:
                                            insertarBarcoNormal();  
                                            break;
                                        case 2:
                                            insertarVelero();
                                            break;
                                        case 3:
                                            insertarDeportivo();
                                            break;
                                        case 4:
                                            insertarYate();
                                            break;
                                    }

                                    break;
                                case 2:
                                    AlquilarBarco();

                                    break;
                                case 3:
                                    mostrarTodosBarcos();

                                    break;
                                case 4:


                                    break;
                                case 5:


                                    break;
                                case 6:


                                    break;
                                case 7:



                                    break;




                            }


                           /* Console.WriteLine("Juego de barcos");
                            Sailboat chanqueteShip = new Sailboat("1564AD",20,1990,2);
                            Ship chanqueteShip2 = new Ship("8554AD", 20, 1990);

                            DateTime startDate = new DateTime(1991,06,20);
                            DateTime endDate = new DateTime(1991,09,10);

                            Rent rent1 = new Rent("Paco", "09884416", startDate, endDate, "A1", chanqueteShip);
                            Rent rent2 = new Rent("Paco", "09884416", startDate, endDate, "A2", chanqueteShip2);

                            int total = rent1.calculateTotalRent(rent1.ShipN.module(12));
                            int total2 = rent1.calculateTotalRent(rent2.ShipN.module(12));
                            
                            Console.WriteLine(total);
                            Console.WriteLine(total2);
                           */



                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Número incorrecto o valor inválido " + '\n');
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            } while (!exit);

        }
        static DateTime[] twoDates()
        {
            DateTime[] dates = new DateTime[2];

            Console.WriteLine("Introduce la primera fecha" + '\n');
            String dateString1 = Console.ReadLine();
            DateTime date1 = Convert.ToDateTime(dateString1);
            dates[0] = date1;
            Console.WriteLine('\n' + "Introduce la segunda fecha" + '\n');
            dateString1 = Console.ReadLine();
            DateTime date2 = Convert.ToDateTime(dateString1);
            dates[1] = date1;
            return dates;
        }

        static void menu1()
        {
            Console.WriteLine(
            "    Manejor de fechas        " + '\n' +
            "---------------------" + '\n' +
            "1 - Conoce el día de la semana mediante una fecha " + '\n' +
            "2 - Conoce que día será dentro del Nº de días " + '\n' +
            "3 - Conoce la diferencia entre dos fechas " + '\n' +
            "4 - Compara entre dos fechas para conocer si es mayor o menor " + '\n' +
            "5 - Mostrar fecha en formato largo" + '\n' +
            "                    " + '\n');
        }

        static void subMenu2()
        {
            Console.WriteLine(
            "    Gestion de juegos        " + '\n' +
            "---------------------" + '\n' +
            "1 - Insertar juego " + '\n' +
            "2 - Ver listado de juego " + '\n' +
            "3 - Modificar un juego ya añadido " + '\n' +
            "4 - Eliminar algún juego ya añadido " + '\n' +
            "5 - Salir" + '\n' +
            "                    " + '\n');
        }

        static void menuModificarJuego()
        {
            Console.WriteLine("¿Que deseas modificar" + '\n');
            Console.WriteLine("_____________________" + '\n');
            Console.WriteLine("1 - Titulo" + '\n');
            Console.WriteLine("2 - Año de lanzamiento" + '\n');
            Console.WriteLine("3 - Genero" + '\n');
            Console.WriteLine("4 - Plataforma" + '\n');
        }

        static void menuPuerto()
        {
            Console.WriteLine(
            "    Que deseas hacer        " + '\n' +
            "---------------------" + '\n' +
            "1 - Registrar un barco " + '\n' +
            "2 - Alquilar un barco " + '\n' +
            "3 - Ver todos los barcos registrados " + '\n' +
            "4 - Ver todos los barcos alquilados " + '\n' +
            "5 - Imprimir valor del alquiler " + '\n' +
            "6 - Eliminar un barci del registro" + '\n' +
            "7 - Eliminar un alquiler del registro" + '\n' +
            "                    " + '\n');
        }

        static void menuTipoBarco()
        {
            Console.WriteLine("¿Que tipo de barco es el tuyo?" + '\n');
            Console.WriteLine("1 - Normal" + '\n');
            Console.WriteLine("2 - Velero" + '\n');
            Console.WriteLine("3 - Deportivo" + '\n');
            Console.WriteLine("4 - Yate" + '\n');
        }

        static void insertarBarcoNormal()
        {
            Console.WriteLine("Introduce la matricula del barco");
            string shipPlate = Console.ReadLine();
            Console.WriteLine("Introduce la longitud en metros");
            int longitudBarco = checkNumberMenu(1, 200);
            Console.WriteLine("¿Cual es el año de matriculación?");
            int annoMatricula = checkNumberMenu(1900, 2024);

            Ship newNormalShip = new Ship(shipPlate,longitudBarco,annoMatricula);
            allShips.Add(newNormalShip);
        }

        static void insertarVelero()
        {
            Console.WriteLine("Introduce la matricula del barco");
            string shipPlate = Console.ReadLine();
            Console.WriteLine("Introduce la longitud en metros");
            int longitudBarco = checkNumberMenu(1, 200);
            Console.WriteLine("¿Cual es el año de matriculación?");
            int annoMatricula = checkNumberMenu(1900, 2024);
            Console.WriteLine("Introduce el número de mástiles");
            int nMastiles = checkNumberMenu(1, 20);

            Sailboat newSailboat = new Sailboat(shipPlate, longitudBarco, annoMatricula,nMastiles);
            allShips.Add(newSailboat);
        }

        static void insertarDeportivo()
        {
            Console.WriteLine("Introduce la matricula del barco");
            string shipPlate = Console.ReadLine();
            Console.WriteLine("Introduce la longitud en metros");
            int longitudBarco = checkNumberMenu(1, 200);
            Console.WriteLine("¿Cual es el año de matriculación?");
            int annoMatricula = checkNumberMenu(1900, 2024);
            Console.WriteLine("Introduce el número de mástiles");
            int power = checkNumberMenu(1, 10000);

            SportBoat newDeportivo = new SportBoat(shipPlate, longitudBarco, annoMatricula, power);
            allShips.Add(newDeportivo);
        }

        static void insertarYate()
        {
            Console.WriteLine("Introduce la matricula del barco");
            string shipPlate = Console.ReadLine();
            Console.WriteLine("Introduce la longitud en metros");
            int longitudBarco = checkNumberMenu(1, 200);
            Console.WriteLine("¿Cual es el año de matriculación?");
            int annoMatricula = checkNumberMenu(1900, 2024);
            Console.WriteLine("Introduce el número de mástiles");
            int power = checkNumberMenu(1, 10000);
            Console.WriteLine("Introduce el número de camerinos");
            int nCabin = checkNumberMenu(1, 100);

            yacht newDeportivo = new yacht(shipPlate, longitudBarco, annoMatricula, power,nCabin);
            allShips.Add(newDeportivo);
        }

        static void mostrarTodosBarcos()
        {
            foreach (Ship i in allShips) {
                Console.WriteLine(i);
            }
        }

        static void AlquilarBarco()
        {

            Console.WriteLine("Nombre del cliente");
            string customerName = Console.ReadLine();
            Console.WriteLine("DNI del cliente");
            string IdCustomer = Console.ReadLine();
            Console.WriteLine("Fecha de inicio del alquiler");
            string dateStartRentST = Console.ReadLine();
            DateTime dateStarRentDT = Convert.ToDateTime(dateStartRentST);
            Console.WriteLine("Fecha de fin del alquiler");
            string dateEndRentST = Console.ReadLine();
            DateTime dateEndRentDT = Convert.ToDateTime(dateEndRentST);
            
            string positionShipRent = "A" + index.ToString();
            index = index++;

            // como añado un contador de este tipo pero en el constructor de una clase?

            Ship newShip = buscarBarco();
            Rent newRent = new Rent(customerName, IdCustomer, dateStarRentDT, dateEndRentDT, positionShipRent, newShip);

        }






        static void insertarJuego()
        {

            Console.WriteLine("Introduce el titulo del juego" + '\n');
            juego.titulo = Console.ReadLine();
            Console.WriteLine("Introduce el año de publicacion" + '\n');
            juego.anno = checkNumberMenu(1800, 3000);

            menuGenero();
            menuPlataforma();

           
            Juego newJuego = new Juego(juego.titulo, juego.anno, juego.Genero, juego.Plataforma);
            shelving.Add(newJuego);
        }

        static int checkNumberMenu(int minMenu, int maxMenu)
        {
            do
            {
                selection = Console.ReadLine();
                correct = int.TryParse(selection, out nSelection);
                if (!correct || nSelection < minMenu || nSelection > maxMenu)
                {
                    correct = false;
                    Console.WriteLine("Seleccione alguna de las opciones válidas");
                }

            } while (!correct || nSelection < minMenu || nSelection > maxMenu);
            return nSelection;
        }

        static void mostrarJuegos()
        {
            foreach (Juego game in shelving)
            {
                Console.WriteLine(game);
            }
        }



        static void menuGenero()
        {
            Console.WriteLine("Introduce el genero: " + '\n' +
                "0 - Accion" + '\n' + "1 - Arcade" + '\n' + "2 - Estrategia" + '\n' + "3 - Aventura" + '\n' + "4 - Deportes" + '\n' + "5 - Simulación");
            switch (checkNumberMenu(0, 5))
            {
                case 0:
                    juego.Genero = Juego.genero.Accion;
                    break;
                case 1:
                    juego.Genero = Juego.genero.Arcade;
                    break;
                case 2:
                    juego.Genero = Juego.genero.Estrategia;
                    break;
                case 3:
                    juego.Genero = Juego.genero.Aventura;
                    break;
                case 4:
                    juego.Genero = Juego.genero.Deportes;
                    break;
                case 5:
                    juego.Genero = Juego.genero.Simulacion;
                    break;
            }
        }

        static void menuPlataforma()
        {
            Console.WriteLine("Introduce la plataforma: " + '\n' +
               "0 - PC" + '\n' + "1 - Play Station" + '\n' + "2 - Xbox" + '\n' + "3 - Nintendo" + '\n');
            switch (checkNumberMenu(0, 4))
            {
                case 0:
                    {
                        juego.Plataforma = Juego.plataforma.PC
                        ; break;
                    }
                case 1:
                    {
                        juego.Plataforma = Juego.plataforma.PlayStation
                        ; break;
                    }
                case 2:
                    {
                        juego.Plataforma = Juego.plataforma.Xbox
                        ; break;
                    }
                case 3:
                    {
                        juego.Plataforma = Juego.plataforma.Nintendo
                        ; break;
                    }
            }

        }

        static Juego buscarJuego()
        {
            Juego game = new Juego();
            ArrayList juegos = new ArrayList();

            Console.WriteLine("Primero introduce el título del juego que quieras modificar");
            string titulo = Console.ReadLine();

            foreach (Juego gameS in shelving)
            {
                if (gameS.titulo.Contains(titulo))
                {
                    game = gameS;
                    juegos.Add(game);
                }
            }

                Console.WriteLine("Se han encontrado los siguientes juegos que contienen el titulo " + titulo + '\n');
            int index = 0;

            foreach(Juego gameS in juegos)
            {
                Console.WriteLine(index + " - " + gameS.titulo + '\n');
                index++;
            }
            if (juegos.Count == 0)
            {
                Console.WriteLine("No se ha encontrado ningún juego que contenga el titulo " + titulo + '\n');
            }
            else
            {
                Console.WriteLine("Seleccione numéricamente cual es su opción");
                game = (Juego)juegos[checkNumberMenu(0, juegos.Count)];
            }
            return game;    
        }



        static Ship buscarBarco()
        {
            Ship shipN = new Ship();
            ArrayList foundShips = new ArrayList();

            Console.WriteLine("Introduce la matricula del barco que deseas alquilar");
            string matricula = Console.ReadLine();

            foreach (Ship shipS in allShips)
            {
                if (shipS.Plate.Contains(matricula))
                {
                    shipN = shipS;
                    foundShips.Add(shipN);
                }
            }

            Console.WriteLine("Se han encontrado los siguientes barcos que contienen la matricula " + matricula + '\n');
            int index = 0;

            foreach (Ship ShipS in foundShips)
            {
                Console.WriteLine(index + " - " + ShipS.Plate + '\n');
                index++;
            }
            if (foundShips.Count == 0)
            {
                Console.WriteLine("No se ha encontrado ningún barco que contenga la matricula " + matricula + '\n');
            }
            else
            {
                Console.WriteLine("Seleccione numéricamente cual es su opción");
                shipN = (Ship)foundShips[checkNumberMenu(0, foundShips.Count)];
            }
            return shipN;
        }



        static void eliminarJuego(Juego game)
        {
           shelving.Remove(game);
        }
    }
}