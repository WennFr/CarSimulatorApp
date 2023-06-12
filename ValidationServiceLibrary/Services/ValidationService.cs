using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ValidationServiceLibrary.Services
{
    public class ValidationService : IValidationService
    {
        public int ValidateMenuSelection(int selectionMenuMaxLimit)
        {
            int intSelection;
            Console.WriteLine($"What would you like to do? {Environment.NewLine}");
            while (true)
            {
                Console.Write($">");
                if (int.TryParse(Console.ReadLine(), out intSelection) && intSelection >= 0 && intSelection <= selectionMenuMaxLimit)
                    return intSelection;

                Console.WriteLine($"{Environment.NewLine}Choose between the available menu numbers{Environment.NewLine}");
            }
        }
    }
}
