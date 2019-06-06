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
   public class DateConverterTests
   {
      [TestMethod()]
      public void ConvertRangeDaysTest()
      {

         string myResult = "01-02.02.1996";
    
         DateConverter date = new DateConverter("01.02.1996", "02.02.1996");
         string result = date.ConvertRange();
         Assert.AreEqual(myResult, result);

      }
      [TestMethod()]
      public void ConvertRangeMonthsTest()
      {

         string myResult = "01.02-01.04.1996";

         DateConverter date = new DateConverter("01.02.1996", "01.04.1996");
         string result = date.ConvertRange();
         Assert.AreEqual(myResult, result);

      }
      [TestMethod()]
      public void ConvertRangeYearsTest()
      {

         string myResult = "01.02.1996-01.04.1997";

         DateConverter date = new DateConverter("01.02.1996", "01.04.1997");
         string result = date.ConvertRange();
         Assert.AreEqual(myResult, result);

      }
   }
}