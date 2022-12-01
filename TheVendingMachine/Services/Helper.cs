using System;
namespace TheVendingMachine.Services
{
	public class Helper
	{
        // Method that changes color of the text when something dosen't go as planned
        public static void ErrorColor(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void ReturnMenuMessage()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Press a key to return to Menu");
            Console.ReadKey();
            Console.Clear();
            Menus.StartMenu();
        }

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

        public static void RasberrySymbol()
        {
            Console.WriteLine(@"
       .\V/,
      ()_()_)
     (.(_)()_)
      (_(_).)'
       `'""'´");
        }

        public static void BlackcurrantSymbol()
        {
            Console.WriteLine(@"        __
     __ {_/ 
     \_}\\ _
        _\(_)_
       (_)_)(_)_
      (_)(_)_)(_)
       (_)(_))_)
        (_(_(_)
         (_)_)
          (_)");


        }
    }
}

