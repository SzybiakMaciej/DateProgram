using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateProgram
{
   public class DateConverter
   {
      private string _firstDate;
      private string _secondDate;
      private DateTime _firstDateParsed;
      private DateTime _secondDateParsed;
      private bool _validated;
      private string _resultConvertRange;
      private CultureInfo _provider = CultureInfo.InvariantCulture;
      private const string _format = "dd.MM.yyyy";

      public DateConverter(string firstDate, string secondDate)
      {
         _firstDate = firstDate;
         _secondDate = secondDate;
      }
      public bool Validate(out List<string> messages)
      {
         bool result = true;
         messages = new List<string>();

         if (!DateTime.TryParseExact(_firstDate,_format,_provider, DateTimeStyles.None,out _firstDateParsed))
         {
            messages.Add("Invalid format of first date.");
            result = false;
         }
         if (!DateTime.TryParseExact(_secondDate, _format, _provider, DateTimeStyles.None, out _secondDateParsed))
         {
            messages.Add("Invalid format of second date.");
            result = false;
         }
         _validated = true;
         return result;
      }

      public string ConvertRange()
      {
         if (!_validated)
         {
            throw new Exception("Validate method not excecuted");
         }
         if (_secondDateParsed < _firstDateParsed)
         {
            DateTime tmp = _firstDateParsed;
            _firstDateParsed = _secondDateParsed;
            _secondDateParsed = tmp;
         }
         if (_firstDateParsed.Year == _secondDateParsed.Year)
         {
            if (_firstDateParsed.Month == _secondDateParsed.Month)
            {
               _resultConvertRange = _firstDateParsed.ToString("dd") + "-" + _secondDateParsed.ToString(_format);
            }
            else if (_firstDateParsed.Month != _secondDateParsed.Month)
            {
               _resultConvertRange = _firstDateParsed.ToString("dd.MM") + "-" + _secondDateParsed.ToString(_format);
            }
         }
         else
         {
            _resultConvertRange = _firstDateParsed.ToString(_format) + "-" + _secondDateParsed.ToString(_format);
         }
         return _resultConvertRange;
      }

   }
}
