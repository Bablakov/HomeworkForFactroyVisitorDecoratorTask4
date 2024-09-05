public class ElfHealth : IHealthStat
{
    private IHealthStat _healthStat;
    private int _healMultilplier;

    public ElfHealth(IHealthStat healthStat, int healMultilplier)
    {
        _healthStat = healthStat;
        _healMultilplier = healMultilplier;
    }

    public int MaxHealth => _healthStat.MaxHealth;

    public int Value => _healthStat.MaxHealth;

    public void Add(int value)
    {
        value *= _healMultilplier;

        _healthStat.Add(value);
    }

    public void Reduce(int value) => _healthStat.Reduce(value);
}
