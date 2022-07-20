namespace BirthdayBot;

/// <summary>
/// Provides the current time. Useful for mocking.
/// </summary>
public interface IClock {
	DateTimeOffset GetUtcNow();
}

/// <summary>
/// Provides the real current time. Not useful for mocking.
/// </summary>
public class SystemClock : IClock {
	public DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
}
