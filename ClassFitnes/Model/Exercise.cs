using System;

namespace ClassFitnes.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Activity Activity { get; }
        public virtual int ActivityId { get; set; }
        public virtual User User { get; set; }
        public Exercise() { }
        public int UserId { get; set; }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

    }
}
