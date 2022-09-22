using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessBL.Controller
{
    public abstract class  ConrollerBase
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
        //public ConrollerBase() { }
        //protected void Save(string fileName,object item) 
        //{

        //    //var formatter = new BinaryFormatter();
        //    //using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    //{
        //    //    formatter.Serialize(fs, item);
        //    //}
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    };
        //    using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        JsonSerializer.Serialize(fs,item,options);
        //        Console.WriteLine("Data has been saved to file");
        //    }
        //}
        //protected T Load<T>(string fileName)
        //{

        //    //var formatter = new BinaryFormatter();
        //    using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        if (fs.Length > 0)
        //        {
        //            T items = JsonSerializer.Deserialize<T>(fs);
        //            return items;
        //        }
        //        else
        //        {
        //            return default(T);
        //        }
        //    }
        //}
    }
}
