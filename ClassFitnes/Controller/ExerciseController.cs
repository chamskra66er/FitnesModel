using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassFitnes.Model;

namespace ClassFitnes.Controller
{
    public class ExerciseController:ControllerBase
    {
        private readonly User User;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            User = user ?? throw new ArgumentNullException("Поле не может быть пустым",nameof(user));
            Exercises = GetAllExercises();
            Activities = GaetAllActivities();
        }

        private List<Activity> GaetAllActivities()
        {
            return Load<List<Activity>>("activities.dat") ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>("exercises.dat") ?? new List<Exercise>();
        }
        private void Save()
        {
            Save("exercises.dat", Exercises);
            Save("activities.dat", Activities);
        }
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(f => f.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, User);
                Exercises.Add(exercise);              
            }
            else
            {
                var exercise = new Exercise(begin, end, act, User);
                Exercises.Add(exercise);               
            }
            Save();
        }
    }
}
