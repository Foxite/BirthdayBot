namespace BirthdayBot.Tests;

/// <summary>
/// Lets you mock the current time.
/// </summary>
public class MockClock : IClock {
	private DateTimeOffset m_Now = DateTimeOffset.UtcNow;

	public DateTimeOffset GetUtcNow() {
		return m_Now;
	}

	public void SetUtcNow(DateTimeOffset now) {
		m_Now = now;
	}
}
