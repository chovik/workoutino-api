namespace Workoutino.Domain.Entities
{
    public class WorkoutSet
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }
        public double PercentageFromPreviousWeight { get; set; }
        public int NumberOfReps { get; set; }
        public int MyProperty { get; set; }
    }
}
