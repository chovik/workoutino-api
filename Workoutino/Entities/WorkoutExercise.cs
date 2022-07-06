using System.Collections.Generic;

namespace Workoutino.Entities
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int ExerciseId { get; set; }
        public IReadOnlyCollection<ExerciseSet> Sets { get; set; }
    }
}
