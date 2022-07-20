namespace BirthdayBot.Tests;

public class MockClock : IClock {
	private DateTimeOffset m_Now = DateTimeOffset.UtcNow;

	public DateTimeOffset GetUtcNow() {
		return m_Now;
	}

	public void SetUtcNow(DateTimeOffset now) {
		m_Now = now;
	}
}
