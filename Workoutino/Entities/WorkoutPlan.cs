using System.Collections.Generic;

namespace Workoutino.Entities
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<WorkoutDay> WorkoutDays { get; set; }
        public IReadOnlyCollection<WorkoutExerciseMaximum> ExercisesMaximums { get; set; }
    }
}
