using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Controller
{
    public class WorkoutController : ConrollerBase<Workout>
    {
        private readonly User user;
        private const string WORKOUT_FILE_NAME = "wordouts.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        public List<Workout> Workouts;
        public List<Activity> Activities;
        
        public WorkoutController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Workouts = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity>? GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private List<Workout>? GetAllExercises()
        {
            return Load<List<Workout>>(WORKOUT_FILE_NAME) ?? new List<Workout>();
        }
        private void Save()
        {
            Save(WORKOUT_FILE_NAME, Workouts);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
        public void Add(Activity activity,DateTime begin,DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if(act == null)
            {
                Activities.Add(activity);
                var workout = new Workout(begin, end, activity, user);
                Workouts.Add(workout);
            }
            else
            {
                var workout = new Workout(begin, end, act, user);
                Workouts.Add(workout);
                
            }
            Save();

        }
    }
}
