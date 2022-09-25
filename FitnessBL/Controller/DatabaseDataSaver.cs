using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Controller
{
    public class DatabaseDataSaver<T> : IDataSaver
    {
        public List<T1> Load<T1>() where T1 : class
        {

            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }
}

        public void Save<T1>(List<T1> item) where T1 : class
        {
            using(var db = new FitnessContext)
            {
                db.Set<T>().Add(item);
                db.SaveChanges();

            }
        }
    }
}
