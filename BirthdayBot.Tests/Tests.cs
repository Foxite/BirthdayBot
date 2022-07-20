namespace BirthdayBot.Tests;

public class Tests {
	private MockClock m_Clock;

	[SetUp]
	public void Setup() {
		m_Clock = new MockClock();
	}
 
	public void TestWithClockOffset(IBirthdayProvider provider, TimeSpan timezone, TimeSpan clockOffset) {
		m_Clock.SetUtcNow(new DateTimeOffset(2022, 7, 2, 0, 0, 0, timezone) + clockOffset);
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "1"));
		
		m_Clock.SetUtcNow(new DateTimeOffset(2022, 7, 18, 0, 0, 0, timezone) + clockOffset);
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "2"));
		
		m_Clock.SetUtcNow(new DateTimeOffset(2022, 7, 19, 0, 0, 0, timezone) + clockOffset);
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "3"));
		
		m_Clock.SetUtcNow(new DateTimeOffset(2022, 7, 20, 0, 0, 0, timezone) + clockOffset);
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "4"));
		
		m_Clock.SetUtcNow(new DateTimeOffset(2022, 7, 29, 0, 0, 0, timezone) + clockOffset);
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "5"));
		
		
		m_Clock.SetUtcNow(new DateTimeOffset(2022, 7, 28, 0, 0, 0, timezone) + clockOffset);
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.Zero);
		
		m_Clock.SetUtcNow(new DateTimeOffset(2022, 7, 30, 0, 0, 0, timezone) + clockOffset);
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.Zero);
	}

	private void TestWithTimezone(IBirthdayProvider provider, TimeSpan timeZone) {
		TestWithClockOffset(provider, timeZone, TimeSpan.Zero);
		TestWithClockOffset(provider, timeZone, TimeSpan.FromSeconds(16));
		TestWithClockOffset(provider, timeZone, TimeSpan.FromSeconds(120));
	}

	private void TestWithProvider(IBirthdayProvider provider) {
		TestWithTimezone(provider, TimeSpan.Zero);
		TestWithTimezone(provider, TimeSpan.FromHours(2));
		TestWithTimezone(provider, TimeSpan.FromHours(-2));
		TestWithTimezone(provider, TimeSpan.FromHours(12));
		TestWithTimezone(provider, TimeSpan.FromHours(-12));
	}

	/// <summary>
	/// Tests only the functionality in <see cref="MemoryBirthdayProvider"/>, by manually specifying birthdays.
	/// </summary>
	[Test]
	public void TestMemoryProvider() {
		TestWithProvider(new MockBirthdayProvider(
			new List<Birthday>() {
				// These are the exact same ones as in the csv.
				new Birthday(DateTimeOffset.Parse("2022-07-02 +0000"), "1", 969681332697448509UL),
				new Birthday(DateTimeOffset.Parse("2022-07-18 +0000"), "2", 969681377425514616UL),
				new Birthday(DateTimeOffset.Parse("2022-07-19 +0000"), "3", 969681384304160788UL),
				new Birthday(DateTimeOffset.Parse("2022-07-20 +0000"), "4", 969681394731221042UL),
				new Birthday(DateTimeOffset.Parse("2022-07-29 +0000"), "5", 958327390956814459UL),
			})
		);
	}

	/// <summary>
	/// Tests the csv loading functionality of <see cref="CsvBirthdayProvider"/>.
	/// It also technically tests <see cref="MemoryBirthdayProvider"/> so you should also run <see cref="TestMemoryProvider"/> to ensure your problems are actually related to csv code.
	/// </summary>
	[Test]
	public void TestCsvProvider() {
		TestWithProvider(new CsvBirthdayProvider("birthdays.csv"));
	}
}
