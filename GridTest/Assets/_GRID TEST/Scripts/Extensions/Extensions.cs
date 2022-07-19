public static class Extensions
{
    public static bool IsNumber(this string str, out int resultNumber)
    {
        return int.TryParse(str, out resultNumber);
    }
}
