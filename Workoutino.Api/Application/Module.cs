using MediatR;
using Workoutino.Api.Application.Extensions;
using Workoutino.Api.Domain.Entities;

namespace Workoutino.Api.Application
{
    public static class Module
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            app.MapPost("workoutExercise", async (WorkoutExerciseCreateModel createModel, IMediator mediator, CancellationToken cancellationToken) =>
                {
                    var workoutExercise = new WorkoutExercise(createModel.OrderNumber);
                    await mediator.CreateEntity(workoutExercise, cancellationToken);
                });

            app.MapPut("workoutExercise", async (int id, WorkoutExerciseUpdateModel updateModel, IMediator mediator, CancellationToken cancellationToken) =>
                {
                    var workoutExercise = await mediator.GetEntityById<WorkoutExercise>(id, cancellationToken);

                    if (workoutExercise == null)
                    {
                        throw new BadHttpRequestException($"Workout exercise with id = {id} does not exist.");
                    }

                    var exercises = await mediator.GetEntitiesById<Exercise>(updateModel.ExerciseIds, cancellationToken);

                    foreach (var exercise in exercises)
                    {
                        workoutExercise.AddExercise(exercise);
                    }

                    await mediator.CreateEntity(workoutExercise, cancellationToken);
                });

            app.MapPut("workoutExercise", async (int id, WorkoutSetCreateModel setCreateModel, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var workoutExercise = await mediator.GetEntityById<WorkoutExercise>(id, cancellationToken);

                if (workoutExercise == null)
                {
                    throw new BadHttpRequestException($"Workout exercise with id = {id} does not exist.");
                }

                //workoutExercise.AddSet(new WorkoutSet());

                await mediator.CreateEntity(workoutExercise, cancellationToken);
            });

            return app;
        }
    }
}
