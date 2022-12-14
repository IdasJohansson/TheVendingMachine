using System;
namespace TheVendingMachine.Services
{
	public class Helper
	{
        // Metod som ändrar färg på texten till röd
        public static void ErrorColor(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        // Metod som används för att skicka tillbaka användaren till menyn
        public static void ReturnMenuMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------");
            Console.WriteLine("Press a key to return to Menu");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Menus.StartMenu();
        }

        // Rubriken i startmenyn
        public static void HeadLine()
        {
            Console.WriteLine(@"

████████╗██╗  ██╗███████╗    ███╗   ███╗ █████╗  ██████╗██╗  ██╗██╗███╗   ██╗███████╗
╚══██╔══╝██║  ██║██╔════╝    ████╗ ████║██╔══██╗██╔════╝██║  ██║██║████╗  ██║██╔════╝
   ██║   ███████║█████╗      ██╔████╔██║███████║██║     ███████║██║██╔██╗ ██║█████╗  
   ██║   ██╔══██║██╔══╝      ██║╚██╔╝██║██╔══██║██║     ██╔══██║██║██║╚██╗██║██╔══╝  
   ██║   ██║  ██║███████╗    ██║ ╚═╝ ██║██║  ██║╚██████╗██║  ██║██║██║ ╚████║███████╗
   ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝
                                                                                     

");
        }

        public static void ByeBye()
        {
            Console.WriteLine(@"
 ____ ____ ____ 
||B |||Y |||E ||
||__|||__|||__||
|/__\|/__\|/__\|
");
        }

        // Symbol som används i Use metoden när användaren har köpt en produkt
        public static void SodaSymbol()
        {
            Console.WriteLine(@"
            _                                   
          .!.!.                             
           ! !                                   
           ; :                                
          ;   :                                
         ;_____:                                 
         ! SODA!                                 
         !_____!                                 
         :     :
         :     ;                                       
         .'   '.                             
         :     :                            
          '''''");
        }

        // Symbol som används i Use metoden när användaren har köpt en produkt
        public static void StrawberrySymbol()
        {
            Console.WriteLine(@"
         \VW/
       .::::::.
       ::::::::
       '::::::'
        '::::'
         `""`");
        }

        // Symbol som används i Use metoden när användaren har köpt en produkt
        public static void RasberrySymbol()
        {
            Console.WriteLine(@"
       .\V/,
      ()_()_)
     (.(_)()_)
      (_(_).)'
       `'""'´");
        }

        // Symbol som används i Use metoden när användaren har köpt en produkt
        public static void BlueberrySymbol()
        {
            Console.WriteLine(@"
       .\()/,
      ()_()_)
     (.(_)()_)
      (_(_).)'
       `'()'´

      .--./ 
     /#   \  \.--.
     \    /  /#   \
      '--'   \    /
              '--'");
        }

        // Symbol som används i Use metoden när användaren har köpt en produkt
        public static void SorbetSymbol()
        {
            Console.WriteLine(@"
       .-''`'''-.
       /        \
       \        /
       /'---'--`\
      |          |
      \_.--.__.-./
        [=-=-=-]
         |=-=-|
         |-=-=|
         '-==-'");
        }

        
    }
}

