namespace AddisEats_Day_4_ClassExercises.Services
{
    public interface IClock
    {
        DateTime UtcNow { get; }

        DateTime CreatedAtUtc { get; }
    }
}
