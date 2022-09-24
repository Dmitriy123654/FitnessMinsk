using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    [Serializable]
    public class Workout
    {
        public DateTime Start { get;  }
        public DateTime Finish { get;  }
        public Activity Activity { get;  }
        public User User { get;  }
        public Workout(DateTime start, DateTime finish, Activity activity, User user)
        {
            //проверка
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }   
}
