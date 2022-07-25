namespace BirthdayBot.Tests;

public class Tests {
	private MockClock m_Clock;

	[SetUp]
	public void Setup() {
		m_Clock = new MockClock();
	}
 
	private void TestProvider(IBirthdayProvider provider) {
		m_Clock.SetDate(new DateTime(2022, 7, 2, 0, 0, 0));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "1"));
		
		m_Clock.SetDate(new DateTime(2022, 7, 18, 0, 0, 0));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "2"));
		
		m_Clock.SetDate(new DateTime(2022, 7, 19, 0, 0, 0));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "3"));
		
		m_Clock.SetDate(new DateTime(2022, 7, 20, 0, 0, 0));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "4"));
		
		m_Clock.SetDate(new DateTime(2022, 7, 29, 0, 0, 0));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.EqualTo(1));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.One.Matches<Birthday>(bd => bd.Name == "5"));
		
		
		m_Clock.SetDate(new DateTime(2022, 7, 28, 0, 0, 0));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.Zero);
		
		m_Clock.SetDate(new DateTime(2022, 7, 30, 0, 0, 0));
		Assert.That(provider.GetBirthdays(m_Clock).Result, Has.Count.Zero);
	}

	/// <summary>
	/// Tests only the functionality in <see cref="MemoryBirthdayProvider"/>, by manually specifying birthdays.
	/// </summary>
	[Test]
	public void TestMemoryProvider() {
		TestProvider(new MockBirthdayProvider(
			new List<Birthday>() {
				// These are the exact same ones as in the csv.
				new Birthday(07, 02, "1", 969681332697448509UL),
				new Birthday(07, 18, "2", 969681377425514616UL),
				new Birthday(07, 19, "3", 969681384304160788UL),
				new Birthday(07, 20, "4", 969681394731221042UL),
				new Birthday(07, 29, "5", 958327390956814459UL),
			})
		);
	}

	/// <summary>
	/// Tests the csv loading functionality of <see cref="CsvBirthdayProvider"/>.
	/// It also technically tests <see cref="MemoryBirthdayProvider"/> so you should also run <see cref="TestMemoryProvider"/> to ensure your problems are actually related to csv code.
	/// </summary>
	[Test]
	public void TestCsvProvider() {
		TestProvider(new CsvBirthdayProvider("birthdays.csv"));
	}
}
