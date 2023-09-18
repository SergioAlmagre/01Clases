using System.Collections;
using System.Globalization;
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
                                            Console.WriteLine("Introduce el núevo titulo");
                                            newJuego.titulo = Console.ReadLine();
                                            
                                        break;
                                        case 2:
                                            Console.WriteLine("Introduce el núevo año");
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
                                    // eliminarJuego();
                                    break;
                            }


                            break;

                        case 3:
                            Console.WriteLine("Caso 3");

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

        /*
        static void menu1(int minMenu, int maxMenu)
        {
            do
            {
                Console.WriteLine(
                "    Manejor de fechas        " + '\n' +
                "---------------------" + '\n' +
                "1 - Conoce el día de la semana mediante una fecha " + '\n' +
                "2 - Conoce que día será dentro del Nº de días " + '\n' +
                "3 - Conoce la diferencia entre dos fechas " + '\n' +
                "4 - Compara entre dos fechas para conocer si es mayor o menor " + '\n' +
                "5 - Mostrar fecha en formato largo" + '\n' +
                "                    " + '\n' +
                "Seleccione una opción");


                selection = Console.ReadLine();
                correct = int.TryParse(selection, out nSelection);
            } while (nSelection < minMenu || nSelection > maxMenu);
        }
        */

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

        static void insertarJuego()
        {

            Console.WriteLine("Introduce el titulo del juego" + '\n');
            juego.titulo = Console.ReadLine();
            Console.WriteLine("Introduce el año de publicacion");
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

        static void modificarJuego(String titulo)
        {



            Juego newJuego = new Juego();
           

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

            Console.WriteLine("Primero introduce el título del juego que quieras modificar");
            string titulo = Console.ReadLine();

            foreach (Juego gameS in shelving)
            {
                if (titulo == gameS.titulo)
                {
                    game = gameS;
                }
            }
            Console.WriteLine("Introduce el titulo del juego" + '\n');
            return game;    
        }



    }
  
}