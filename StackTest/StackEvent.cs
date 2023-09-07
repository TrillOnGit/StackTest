namespace StackTest;

public enum StackEvent
{
    TakesDamage,
    GainsShields,
    IncreasesNextDamage,
}

public static class StackEventExtensions
{
    public static string GetDescription(this StackEvent ev)
    {
        return ev switch
        {
            StackEvent.TakesDamage => "The opponent takes 1 damage",
            StackEvent.GainsShields => "The opponent shields themselves, reducing the next instance of damage by 1",
            StackEvent.IncreasesNextDamage => "The next instance of damage increases by 1.",
            _ => throw new ArgumentOutOfRangeException(nameof(ev), ev, null)
        };
    }
}