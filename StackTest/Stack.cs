namespace StackTest;

public static class Stack
{
    private static readonly List<StackEvent> StackMemory = new();

    public static void PlaceOnStack()
    {
        while (true)
        {
            var userInput = StackInput();

            if (userInput is null)
            {
                ProcessStack();
            }
            else
            {
                StackMemory.Add(userInput.Value);
            }
        }
    }

    private static void ProcessStack()
    {
        if (StackMemory.Count != 0)
        {
            var eventHappens = StackMemory.Last();

            StackMemory.RemoveAt(StackMemory.Count - 1);

            ProcessEvent(eventHappens);
        }
        else
        {
            Console.WriteLine("There are no elements left on the stack.");
        }
    }

    private static void ProcessEvent(StackEvent eventOccurring)
    {
        Console.WriteLine(eventOccurring.GetDescription());
    }
    
    private static StackEvent? StackInput()
    {
        Console.WriteLine("We'll throw an event on the stack. Pick one:\n" +
                          "1. Deal 1 damage to the opponent\n" +
                          "2. Opponent shields themselves for 1 damage\n" +
                          "3. The next instance of damage increases by 1.\n"+
                          "4. Let the Stack Progress.");

        while (true)
        {
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    return StackEvent.TakesDamage;
                case 2:
                    return StackEvent.GainsShields;
                case 3:
                    return StackEvent.IncreasesNextDamage;
                case 4:
                    return null;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    continue;
            }
        }
    }
}