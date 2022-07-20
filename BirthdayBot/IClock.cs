namespace BirthdayBot;

public interface IClock {
	DateTimeOffset GetUtcNow();
}

public class SystemClock : IClock {
	public DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
}
