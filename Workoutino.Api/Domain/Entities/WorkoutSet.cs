namespace Workoutino.Api.Domain.Entities
{
    public class WorkoutSet
    {
        public int Id { get; set; }
        public Weight Weight { get; set; }
        public Repetition Repetition { get; set; }

        public WorkoutSet(Weight weight, Repetition repetition)
        {
            Weight = weight;
            Repetition = repetition;
        }
    }
}
