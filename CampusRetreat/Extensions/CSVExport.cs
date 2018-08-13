using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CampusRetreat.Extensions
{
    public class CsvExport<T>
        where T: class
    {
        private readonly List<T> _objects;

        public CsvExport(List<T> objects)
        {
            _objects = objects;
        }

        public string Export(bool includeHeaderLine = true)
        {

            StringBuilder sb = new StringBuilder();
            //Get properties using reflection.
            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

            if (includeHeaderLine)
            {
                //add header line.
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(propertyInfo.Name).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (T obj in _objects)
            {               
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            return sb.ToString();
        }

        //export to a file.
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, Export());
        }

        //export as binary data.
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }

        //get the csv value for field.
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is DateTime time)
            {
                return time.ToString(time.TimeOfDay.TotalSeconds == 0 ? "yyyy-MM-dd" : "yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }
    }
}