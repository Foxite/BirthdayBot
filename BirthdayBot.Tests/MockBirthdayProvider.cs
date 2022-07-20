namespace BirthdayBot.Tests;

/// <summary>
/// Extends <seealso cref="MemoryBirthdayProvider"/> and provides birthdays that were passed to its constructor.
/// </summary>
public class MockBirthdayProvider : MemoryBirthdayProvider {
	private readonly ICollection<Birthday> m_Birthdays;

	public MockBirthdayProvider(ICollection<Birthday> birthdays) {
		m_Birthdays = birthdays;
	}

	protected override ICollection<Birthday> ReadBirthdays() {
		return m_Birthdays;
	}
}
