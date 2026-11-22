namespace AddisEats_Day_4_ClassExercises.Services
{
    public class ClockService : IClock
    {
        public DateTime CreatedAtUtc { get; }

        public ClockService()
        {
            CreatedAtUtc = DateTime.UtcNow;
        }

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
