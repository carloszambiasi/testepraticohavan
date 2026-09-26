using Havan.Exercises.Exercises;

Console.WriteLine("=== Questão 2 ===");

var numbers = new List<int>
{
    100, 4, 200, 1, 3, 2
};

var sequence = ConsecutiveSequence.FindLongestSequence(numbers);

Console.WriteLine($"Entrada: [{string.Join(", ", numbers)}]");
Console.WriteLine($"Maior sequência: [{string.Join(", ", sequence)}]");
Console.WriteLine($"Tamanho: {sequence.Count}");

Console.WriteLine();
Console.WriteLine("=== Questão 3 ===");

var text = "A Bateria do computador está Fraca!";

StringAnalyzer.Analyze(text);

Console.WriteLine();
Console.WriteLine("=== Questão 4 ===");

var paymentDate = new DateTime(2026, 10, 15);

PaymentProcessor.Calculate(paymentDate);