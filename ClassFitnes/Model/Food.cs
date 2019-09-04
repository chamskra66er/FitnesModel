using System;

namespace ClassFitnes.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Callories { get; set; }
        public Food() { }
        public Food(string name):this(name, 0,0,0,0) { }
        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
