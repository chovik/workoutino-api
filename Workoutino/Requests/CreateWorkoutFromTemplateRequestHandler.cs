using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workoutino.Entities;

namespace Workoutino.Requests
{
    public class ExerciseRepetitionMaximum
    {
        public int ExerciseId { get; set; }
        public double RepetitionMax { get; set; }
    }

    public class CreateWorkoutFromTemplateRequest
    {
        public CreateWorkoutFromTemplateRequest(
            int sourceWorkoutId,
            IReadOnlyCollection<ExerciseRepetitionMaximum> repetitionsMaximums)
        {
            SourceWorkoutId = sourceWorkoutId;
            RepetitionsMaximums = repetitionsMaximums;
        }

        public int SourceWorkoutId { get; }
        public IReadOnlyCollection<ExerciseRepetitionMaximum> RepetitionsMaximums { get; }
    }
}
