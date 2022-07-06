namespace Workoutino.Entities
{
    public class ExerciseSetTemplate
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int NumberOfSets { get; set; }
        public int MaxNumberOfRepetitions { get; set; }
        public int MinNumberOfRepetitions { get; set; }
        public bool UntilFailure { get; set; }
        public double Weight { get; set; }
        public double WeightPercentageFromRepetitionMax { get; set; }
    }
}
