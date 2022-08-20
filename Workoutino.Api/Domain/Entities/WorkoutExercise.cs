namespace Workoutino.Api.Domain.Entities
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public ICollection<Exercise> Exercises { get; } = new List<Exercise>();
        public ICollection<WorkoutSet> Sets { get; } = new List<WorkoutSet>();

        public WorkoutExercise(int orderNumber)
        {
            OrderNumber = orderNumber;
        }

        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }

        public void AddSet(WorkoutSet set)
        {
            Sets.Add(set);
        }

        public void RemoveSet(WorkoutSet set)
        {
            Sets.Remove(set);
        }
    }
}
