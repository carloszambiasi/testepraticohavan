namespace Havan.Exercises.Exercises;

public static class ConsecutiveSequence
{
    public static List<int> FindLongestSequence(IEnumerable<int> numbers)
    {
        var numberSet = new HashSet<int>(numbers);
        var longestSequence = new List<int>();

        foreach (var number in numberSet)
        {
            if (numberSet.Contains(number - 1))
                continue;

            var currentSequence = new List<int>();
            var currentNumber = number;

            while (numberSet.Contains(currentNumber))
            {
                currentSequence.Add(currentNumber);
                currentNumber++;
            }

            if (currentSequence.Count > longestSequence.Count)
            {
                longestSequence = currentSequence;
            }
        }

        return longestSequence;
    }
}