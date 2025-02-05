using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using static APILogic;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    public static T GetEncodeValue<T>(string[] encodes, string key, T defaultValue)
    {
        if (encodes == null) throw new ArgumentNullException(nameof(encodes));
        if (key == null) throw new ArgumentNullException(nameof(key));

        // Find the first matching key-value pair
        string encodedValue = encodes
            .FirstOrDefault(e => e.ToLower().StartsWith(key.ToLower() + "="))?
            .Substring(key.Length + 1);

        if (string.IsNullOrEmpty(encodedValue))
        {
            return defaultValue;
        }

        try
        {
            // Convert the string value to the specified type T
            return (T)Convert.ChangeType(encodedValue, typeof(T));
        }
        catch
        {
            // Return defaultValue in case of any conversion error
            return defaultValue;
        }
    }

    public static Tuple<bool, List<string>> ValidateReturnProduct(List<ReturnProductModel> products)
    {
        List<string> valMessages = new List<string>();
        if (products.Any(p => p.quantity < 1))
            valMessages.Add("Quantity cannot be less than 1");
        return Tuple.Create<bool, List<string>>(valMessages.Count == 0, valMessages);
    }

    public static string FormatProductF4(string input)
    {
        // Define a regex pattern to match the required parts
        string pattern = @"^(\d+)\.?\d*-?(.*)$";

        // Use Regex.Match to extract groups
        var match = Regex.Match(input, pattern);
        if (match.Success)
        {
            string numberPart = match.Groups[1].Value; // Extract the number before '.'
            string textPart = match.Groups[2].Value;   // Extract the text after '-'

            // Combine the results
            return string.IsNullOrEmpty(textPart) ? numberPart : $"{numberPart} - {textPart}";
        }

        return input; // Return the original input if it doesn't match
    }

    public static string SaveRequestedImage(HttpPostedFile file, string configPath)
    {
        if (file == null || file.ContentLength == 0)
        {
            return null;
        }

        string folderPath = GenerateFilePath(configPath);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string fileName = Path.GetFileName(file.FileName);
        string filePath = Path.Combine(folderPath, fileName);
        file.SaveAs(filePath);
        return fileName;
    }

    public static string GenerateFilePath(string pathName)
    {
        string path = ConfigurationManager.AppSettings[pathName];
        string filePath = AppDomain.CurrentDomain.BaseDirectory + path;

        return filePath;
    }


    // delete file
    public static void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }


    // convert DataTable to List
    public static List<T> ConvertDataTable<T>(DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = _GetItem<T>(row);
            data.Add(item);
        }
        return data;
    }

    private static T _GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();
        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }
}