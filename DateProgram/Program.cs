using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DateProgram
{
   public class Program
   {
      //TEst
      public static void Main(string[] args)
      {
         if (args.Length != 2)
         {
            Console.WriteLine("Invalid paremeters count");
         }
         string dateOne = args[0];
         string dateTwo = args[1];

         DateConverter dateConverter = new DateConverter(dateOne, dateTwo);

         if (!dateConverter.Validate(out List<string> messages))
         {
            messages.ForEach(m => Console.WriteLine(m));
            return;
         }
         Console.WriteLine(dateConverter.ConvertRange());
         

      }
   }
}
