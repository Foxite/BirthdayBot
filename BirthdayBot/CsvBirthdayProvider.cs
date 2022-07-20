using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace BirthdayBot;

public abstract class MemoryBirthdayProvider : IBirthdayProvider {
	// Has to be lazy, we can't call ReadBirthdays in the constructor (or we can restructure this class to use another provider, but no.)
	private readonly Lazy<ICollection<Birthday>> m_Birthdays;
	
	protected MemoryBirthdayProvider() {
		m_Birthdays = new Lazy<ICollection<Birthday>>(ReadBirthdays);
	}

	protected abstract ICollection<Birthday> ReadBirthdays();

	public Task<ICollection<Birthday>> GetBirthdays(IClock clock) {
		return Task.FromResult((ICollection<Birthday>) m_Birthdays.Value.Where(birthday => birthday.Date.Date == clock.GetUtcNow().Date).ToList());
	}
}

public class CsvBirthdayProvider : MemoryBirthdayProvider {
	private readonly string m_FilePath;

	public CsvBirthdayProvider(string filePath) {
		m_FilePath = filePath;
	}

	protected override ICollection<Birthday> ReadBirthdays() {
		using var csvReader = new CsvReader(File.OpenText(m_FilePath), new CsvConfiguration(CultureInfo.InvariantCulture));
		csvReader.Read();
		csvReader.ReadHeader();
		return csvReader.GetRecords<Birthday>().ToList();
	}
}
