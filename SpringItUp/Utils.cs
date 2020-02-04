using System;
using System.IO;
using Newtonsoft.Json;

namespace SpringItUp
{
    public class Utils
    {
        static public bool IsOnePropNullOrEmpty<T>(T model)
        {
            foreach (var prop in model.GetType().GetProperties())
            {
                if (prop == null || (prop.GetType() == typeof(int) && (int.Parse(prop.ToString()) < 1)))
                    return true;
            }
            return false;
        }
    }



}