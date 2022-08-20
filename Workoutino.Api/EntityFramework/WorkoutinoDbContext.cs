using Microsoft.EntityFrameworkCore;
using Workoutino.Api.Domain.Entities;

namespace Workoutino.Api.EntityFramework
{
    public class WorkoutinoDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
