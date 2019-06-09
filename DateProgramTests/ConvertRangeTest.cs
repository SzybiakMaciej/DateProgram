using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DateProgram.Tests
{
   [TestClass()]
   public class ConvertRangeTest
   {
      [TestMethod()]
      public void ConvertRangeDaysTest()
      {
         string expectedResult = "01-02.02.1996";
         DateConverter date = new DateConverter("01.02.1996", "02.02.1996");
         date.Validate(out _);
         string result = date.ConvertRange();
         Assert.AreEqual(expectedResult, result);
      }
      [TestMethod()]
      public void ConvertRangeMonthsTest()
      {
         string expectedResult = "01.02-01.04.1996";
         DateConverter date = new DateConverter("01.02.1996", "01.04.1996");
         date.Validate(out _);
         string result = date.ConvertRange();
         Assert.AreEqual(expectedResult, result);
      }
      [TestMethod()]
      public void ConvertRangeYearsTest()
      {
         string expectedResult = "01.02.1996-01.04.1997";
         DateConverter date = new DateConverter("01.02.1996", "01.04.1997");
         date.Validate(out _);
         string result = date.ConvertRange();
         Assert.AreEqual(expectedResult, result);

      }

      [TestMethod()]
      public void ConvertRangeExceptionTest()
      {
         DateConverter date = new DateConverter("01.02.1996", "02.02.1996");
         bool exceptionThrowed = false;
         try
         {
            string result = date.ConvertRange();
         }
         catch
         {
            exceptionThrowed = true;
         }
         Assert.IsTrue(exceptionThrowed);         
      }

      [TestMethod()]
      public void ValidateFirstDateTest()
      {
         DateConverter date = new DateConverter("01.02.199", "02.02.1996");
         bool validationCorrectly = false;
         if(!date.Validate(out List<string> messages))
         {
            foreach(string message in messages)
            {
               if(message== "Invalid format of first date.")
               {
                  validationCorrectly = true;
               }
            }
         }

         Assert.IsTrue(validationCorrectly);
      }

      [TestMethod()]
      public void ValidateSecondDateTest()
      {
         DateConverter date = new DateConverter("01.02.1996", "02.02.199");
         bool validationCorrectly = false;
         if (!date.Validate(out List<string> messages))
         {
            foreach (string message in messages)
            {
               if (message == "Invalid format of second date.")
               {
                  validationCorrectly = true;
               }
            }
         }

         Assert.IsTrue(validationCorrectly);
      }

      [TestMethod()]
      public void ValidateBothDateTest()
      {
         DateConverter date = new DateConverter("01.02.199", "02.02.199");
         bool validationCorrectly = false;
         if (!date.Validate(out List<string> messages))
         {
            if (messages.Count == 2)
            {
               validationCorrectly = true;
            }
         }

         Assert.IsTrue(validationCorrectly);
      }
   }
}