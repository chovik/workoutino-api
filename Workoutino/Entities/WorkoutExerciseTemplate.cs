using System.Collections.Generic;

namespace Workoutino.Entities
{
    public class WorkoutExerciseTemplate
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int ExerciseId { get; set; }
        public IReadOnlyCollection<ExerciseSetTemplate> Sets { get; set; }
    }
}
