using System.Collections.Generic;

namespace Workoutino.Entities
{
    public class WorkoutDayTemplate
    {
        public int Day { get; set; }
        public string Description { get; set; }
        public IReadOnlyCollection<WorkoutExercise> Exercises { get; set; }
    }
}
