namespace BirthdayBot.Tests;

/// <summary>
/// Lets you mock the current time.
/// </summary>
public class MockClock : IClock {
	private DateTime m_Now = DateTime.Now;

	public DateTime GetDate() {
		return m_Now;
	}

	public void SetDate(DateTime now) {
		m_Now = now;
	}
}
