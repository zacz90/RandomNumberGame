using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tydzień_3_LEKCJA_23_Praca_Domowa
{
    class Program
    {
        const int MIN_NUMBER = 0;
        const int MAX_NUMBER = 100;

        static Random random = new Random();
        static void Main(string[] args)
        {
            try
            {
                Game();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nDziękuję za korzystanie z programu.");
            }
        }

        private static void Game()
        {
            //Najpierw aplikacja losuje 1 liczbę z zakresu od 0 do 100.
            //Następnie użytkownik próbuje odgadnąć wylosowaną liczbę.
            //Po każdej próbie odgadnięcia liczby, użytkownik dostaje odpowiedni komunikat (Twoja liczba jest za mała/za duża lub odgadłeś wylosowaną liczbę w x próbach).            
            int randomNumber = random.Next(MIN_NUMBER, MAX_NUMBER+1);
            int userNumber;
            bool numberFound = false;
            int tryCounter = 0;

            Console.WriteLine($"Została wylosowana liczba od {MIN_NUMBER} do {MAX_NUMBER}. Spróbuj odgadnąć.");
            while (!numberFound)
            {
                tryCounter++;
                userNumber = GetInput();
                numberFound = CompareResults(userNumber, randomNumber);
            }
            Console.WriteLine($"Odgadnięto za {tryCounter} razem");
        }
        private static int GetInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Nieprawidłowe dane, spróbuj ponownie.");
            }            
            return result;
        }
        private static bool CompareResults(int userNumber, int randomNumber)
        {
            if (userNumber > randomNumber)
                Console.WriteLine("Podana liczba jest za duża. Spróbuj ponownie.");
            else if (userNumber < randomNumber)
                Console.WriteLine("Podana liczba jest za mała. Spróbuj ponownie.");
            else
            {
                Console.WriteLine("Brawo. Liczba trafiona.");
                return true;
            }
            return false;
        }
    }
}
