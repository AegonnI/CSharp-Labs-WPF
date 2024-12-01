using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp_Labs_WPF
{
    internal class ExcelDataBase
    {
        Dictionary<int, Account> accounts { get; }
        Dictionary<int, ExchangeRate> exchangeRates { get; }
        Dictionary<int, Accrual> accruals { get; }

        public ExcelDataBase(string pathXLS, string pathXLSX) 
        {
            if (!File.Exists(pathXLS)) throw new Exception();

            if (!File.Exists(pathXLSX))
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(pathXLS);
                workbook.SaveAs(pathXLSX, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
                workbook.Close();
                excelApp.Quit();
            }

            try
            {
                using (XLWorkbook wb = new XLWorkbook(pathXLSX))
                {
                    IXLWorksheet ws = wb.Worksheet(1);

                    accounts = ws.RowsUsed()
                                          .Skip(1)
                                          .ToDictionary(
                                              row => (int)row.Cell(1).Value.GetNumber(),
                                              row => new Account(row.Cell(2).GetText(), row.Cell(3).GetDateTime())
                                          );

                    ws = wb.Worksheet(2);

                    exchangeRates = ws.RowsUsed()
                                          .Skip(1)
                                          .ToDictionary(
                                              row => (int)row.Cell(1).Value.GetNumber(),
                                              row => new ExchangeRate(row.Cell(2).GetText(), row.Cell(3).Value.GetNumber(), row.Cell(4).GetText().Trim())
                                          );

                    ws = wb.Worksheet(3);

                    accruals = ws.RowsUsed()
                                          .Skip(1)
                                          .ToDictionary(
                                              row => (int)row.Cell(1).Value.GetNumber(),
                                              row => new Accrual((int)row.Cell(2).Value.GetNumber(), (int)row.Cell(3).Value.GetNumber(), row.Cell(4).GetDateTime(), row.Cell(5).Value.GetNumber())
                                          );
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public static string ShowDataBase<T>(Dictionary<int, T> dict) where T : class
        {
            string result = "";
            if (dict.Count <= 5)
            {
                foreach (int id in dict.Keys)
                {
                    result += id.ToString() + " " + dict[id].ToString() + "\n";
                }
            }
            else
            {
                int i = 0;
                foreach (int id in dict.Keys)
                {
                    if (i == 5) break;
                    i++;
                    result += id.ToString() + " " + dict[id].ToString() + "\n";
                }
                result += "...\n";               
            }
            return result + $"{dict.Count} rows";
        }

        public void DelElemInAccounts(int key)
        {
            try { accounts.Remove(key); }
            catch (Exception ex) { throw ex; }
        }

        public void DelElemInExchangeRates(int key)
        {
            try { exchangeRates.Remove(key); }
            catch (Exception ex) { throw ex; }
        }

        public void DelElemInAccrual(int key)
        {
            try { accruals.Remove(key); }
            catch (Exception ex) { throw ex; }
        }

        public void AddElemInAccounts(int key, Account account) { accounts[key] = account; }

        public void AddElemInExchangeRates(int key, ExchangeRate exchangeRate) { exchangeRates[key] = exchangeRate; }

        public void AddElemInAccrual(int key, Accrual accrual) { accruals[key] = accrual; }

        public Dictionary<int, Account> GetAccount() { return accounts; }
        public Dictionary<int, ExchangeRate> GetExchangeRate() { return exchangeRates; }
        public Dictionary<int, Accrual> GetAccrual() { return accruals; }
    }
}
