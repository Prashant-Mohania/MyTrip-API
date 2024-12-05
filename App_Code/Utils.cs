using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}