namespace WormGearKursovaya;

public static class RandomExtensions
{
    public static double
        NextDouble( // метод расширения, тк класс Random из коробки не умеет генерировать дабл в заданном промежутке
            this Random random,
            double minValue,
            double maxValue)
    {
        return random.NextDouble() * (maxValue - minValue) + minValue;
    }
}