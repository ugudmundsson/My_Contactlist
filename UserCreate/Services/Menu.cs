using System.Runtime.CompilerServices;
using UserCreate.Models;

namespace UserCreate.Services;
public class Menu
{
    private readonly UserService _userService = new();

    public void ShowMenu()
    {

        string option = null!;

        bool isRunning = true;

        while (isRunning)
        {
            #region Menu
            Console.Clear();

            string logo = Logo.Getlogo();
            UserRegForm user = new();
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(logo);
            Console.ResetColor();
            Console.WriteLine("  *------------------- MENY -------------------*");
            Console.WriteLine("  | Tryck 1. för att lägga till en användare   |");
            Console.WriteLine("  | Tryck 2. för att visa användar i listan    |");
            Console.WriteLine("  | Tryck 3. för att ta bort användar i listan |");
            Console.WriteLine("  | Tryck Q. för att avsluta programmet        |");
            Console.WriteLine("  `--------------------------------------------´");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.Write("Ditt val: ");
            Console.ResetColor();
            option = Console.ReadLine()!;
            #endregion

            switch (option.ToLower())
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    ShowList();
                    break;
                case "3":
                    RemoveFromList();
                    break;
                case "q":
                    Console.WriteLine("Vill du avsluta y/n: ");
                    string quit = Console.ReadLine()!;
                    if (quit.ToLower() == "y")
                    {
                        isRunning = false;
                        Console.ForegroundColor = ConsoleColor.Red;    
                        Console.WriteLine("\nStänger ner Appen........");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void CreateUser()
    {
        Console.Clear();
        string logo = Logo.Getlogo();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(logo);
        Console.ResetColor();
        
        var UserRegForm = UserFactory.Create();
        #region Input
        Console.Write("Skriv ditt Förnamn: ");
        UserRegForm.FirstName = Console.ReadLine();
        Console.Write("Skriv ditt Efternamn: ");
        UserRegForm.LastName = Console.ReadLine();
        Console.Write("Skriv din Email: ");
        UserRegForm.Email = Console.ReadLine();
        Console.Write("Skriv ditt Mobilnr: ");
        UserRegForm.Mobnr = Console.ReadLine();
        Console.Write("Skriv din Gatuadress: ");
        UserRegForm.Streetnr = Console.ReadLine();
        Console.Write("Skriv ditt Postnr: ");
        UserRegForm.Citycode = Console.ReadLine();
        Console.Write("Skriv din Ort: ");
        UserRegForm.City = Console.ReadLine();
        Console.Write("Skriv in ett Password: ");
        UserRegForm.Password = Console.ReadLine();
        #endregion

        var listAll = _userService.GetAll();

        _userService.Add(UserRegForm);
    }






    private void RemoveFromList()
    {
        
        var usersToRemove = _userService.GetAll();
        Console.WriteLine("");
        Console.WriteLine("Välj användare att ta bort genom att ange deras ID:");
        Console.WriteLine("");

        foreach (UserRegForm form in usersToRemove)
        {
            Console.WriteLine($"{"Id:",-20}{form.Id}");
            Console.WriteLine($"{"Förnamn:",-20}{form.FirstName}");
            Console.WriteLine($"{"Efternamn:",-20}{form.LastName}");
            Console.WriteLine($"{"E-postadress:",-20}{form.Email}");
            Console.WriteLine($"{"Mobilnr:",-20}{form.Mobnr}");
            Console.WriteLine($"{"Gatuadress:",-20}{form.Streetnr}");
            Console.WriteLine($"{"Postnr/Ort:",-20}{form.Citycode}, {form.City}");
            Console.WriteLine();
        }
        
        Console.Write("Ange ID: ");
        string userIdInput = Console.ReadLine()!;


        if (userIdInput == null)
        {
            Console.WriteLine("Ogiltigt id");
        }
        var userToRemove = usersToRemove.FirstOrDefault(u => u.Id == userIdInput);

        if (usersToRemove != null)
        {
            _userService.Remove(userToRemove!); 
        }

        Console.WriteLine("");
        Console.WriteLine("  Tryck 'Enter' för att komma tillbaka till Meny...");
        Console.ReadKey();
    }






    private void ShowList()
    {
        Console.Clear();
        string logo = Logo.Getlogo();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(logo);
        Console.ResetColor();
        Console.WriteLine("            ----------- Användar listan ----------");
        var users = _userService.GetAll();
        
        
        #region Output
        foreach (UserRegForm user in users)
            
        {
            var userEntity = UserFactory.Create(user);

            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"{"Id:",-20}{userEntity.Id}");
            Console.WriteLine($"{"Förnamn:",-20}{userEntity.FirstName}");
            Console.WriteLine($"{"Efternamn:",-20}{userEntity.LastName}");
            Console.WriteLine($"{"E-postadress:",-20}{userEntity.Email}");
            Console.WriteLine($"{"Mobilnr:",-20}{userEntity.Mobnr}");
            Console.WriteLine($"{"Gatuadress:",-20}{userEntity.Streetnr}");
            Console.WriteLine($"{"Postnr/Ort:",-20}{userEntity.Citycode}, {userEntity.City}");
            Console.WriteLine();
        }
        #endregion


        Console.WriteLine("");
        Console.Write("  Tryck 'Enter' för att komma tillbka till Meny...");
        Console.ReadKey();
    }
}