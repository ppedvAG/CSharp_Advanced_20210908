using System;

namespace Übung_Solid1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class BadEmployee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        public string ReportType { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(BadEmployee em)
        {
            // Insert into employee table.
            return true;
        }
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>


        public void GenerateReport(BadEmployee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                // Report generation with employee data in PDF.
            }
        }
    }

    //Lösung
    #region Datenstruktur
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
    }
    #endregion

    #region Wäre auch mit Repository ok
    public interface IRepository
    {
        bool InsertIntoEmployeeTable(Employee em);
    }

    public class Repository : IRepository
    {
        public bool InsertIntoEmployeeTable(Employee em)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ReportGenerator 
    public abstract class ReportGeneratorBase
    {
        public abstract void GenerateReport(Employee em);
    }

    public class PDFReport : ReportGeneratorBase
    {
        public override void GenerateReport(Employee em)
        {
            //....
        }
    }

    public class CRSReport : ReportGeneratorBase
    {
        public override void GenerateReport(Employee em)
        {
            //....
        }
    }

    #endregion













}
