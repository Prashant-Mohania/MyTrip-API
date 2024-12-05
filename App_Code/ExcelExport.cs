using System;
using System.Data;
using System.Web;
using ClosedXML.Excel;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Linq;

public class ExcelExport
{

    public ExcelExport()
    {

    }
    public Stream DownloadExcel<T>(List<T> data, string fileName)
    {
        try
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Data");
                var properties = typeof(T).GetProperties();

                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = properties[i].Name;
                }

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < properties.Length; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = (XLCellValue)properties[j].GetValue(data[i]);
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;
                    return stream;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred during Excel export: " + ex.Message);
            throw;
        }
    }

}