using Havan.Exercises.Exercises;

var numbers = new List<int>
{
    100, 4, 200, 1, 3, 2
};

var sequence = ConsecutiveSequence.FindLongestSequence(numbers);

Console.WriteLine($"Entrada: [{string.Join(", ", numbers)}]");
Console.WriteLine($"Maior sequência: [{string.Join(", ", sequence)}]");
Console.WriteLine($"Tamanho: {sequence.Count}");