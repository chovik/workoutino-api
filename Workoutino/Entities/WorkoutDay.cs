using System.Collections.Generic;

namespace Workoutino.Entities
{
    public class WorkoutDay
    {
        public int Day { get; set; }
        public string Description { get; set; }
        public IReadOnlyCollection<WorkoutExercise> Exercises { get; set; }
    }
}
