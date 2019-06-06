using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DateProgram
{

   public class DateConverter
   {
      private DateTime firstDate;
      private DateTime secondDate;
      private string resultConvertRange;

      public DateConverter(string _firstDate, string _secondDate)
      {
         firstDate = DateTime.Parse(_firstDate, System.Globalization.CultureInfo.CreateSpecificCulture("de-DE"));
         secondDate = DateTime.Parse(_secondDate, System.Globalization.CultureInfo.CreateSpecificCulture("de-DE"));
      }

      public string ConvertRange()
      {
         if (firstDate.Year == secondDate.Year)
         {
            if (firstDate.Month == secondDate.Month)
            {
               resultConvertRange = firstDate.ToString("dd") + "-" + secondDate.ToString("dd.MM.yyyy");
            }
            else if (firstDate.Month != secondDate.Month)
            {
               resultConvertRange = firstDate.ToString("dd.MM") + "-" + secondDate.ToString("dd.MM.yyyy");
            }
         }
         else
         {
            resultConvertRange = firstDate.ToString("dd.MM.yyyy") + "-" + secondDate.ToString("dd.MM.yyyy");
         }
         return resultConvertRange;
      }

      public void ShowRange()
      {
         Console.WriteLine(resultConvertRange);
      }

   }

   public class Program
   {


      public static void Main(string[] args)
      {
         string dateOne = Console.ReadLine();
         string dateTwo = Console.ReadLine();

         DateConverter date = new DateConverter(dateOne, dateTwo);

         date.ConvertRange();
         date.ShowRange();
         

         Console.ReadKey();
      }
   }
}
