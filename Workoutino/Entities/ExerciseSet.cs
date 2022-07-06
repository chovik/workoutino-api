namespace Workoutino.Entities
{
    public class ExerciseSet
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int NumberOfSets { get; set; }
        public int MaxNumberOfRepetitions { get; set; }
        public int MinNumberOfRepetitions { get; set; }
        public bool UntilFailure { get; set; }
        public double Weight { get; set; }
    }
}
