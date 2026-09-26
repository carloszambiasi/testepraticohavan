using System.Globalization;
using System.Text;

namespace Havan.Exercises.Exercises;

public static class StringAnalyzer
{
    public static void Analyze(string text)
    {
        var normalizedText = NormalizeText(text);

        var frequencies = normalizedText
            .GroupBy(character => character)
            .ToDictionary(
                group => group.Key,
                group => group.Count()
            );

        var firstNonRepeated = normalizedText
            .FirstOrDefault(character => frequencies[character] == 1);

        var topThree = frequencies
            .OrderByDescending(item => item.Value)
            .ThenBy(item => normalizedText.IndexOf(item.Key))
            .Take(3);

        Console.WriteLine($"Entrada: \"{text}\"");
        Console.WriteLine($"Texto higienizado: \"{normalizedText}\"");

        if (firstNonRepeated != default)
        {
            Console.WriteLine(
                $"Primeiro caractere não repetido: '{firstNonRepeated}'"
            );
        }
        else
        {
            Console.WriteLine("Não existe caractere não repetido.");
        }

        Console.WriteLine("Top 3 caracteres mais frequentes:");

        foreach (var item in topThree)
        {
            Console.WriteLine(
                $"Letra '{item.Key}': {item.Value} vezes"
            );
        }
    }

    private static string NormalizeText(string text)
    {
        var decomposedText = text.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder();

        foreach (var character in decomposedText)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(character);

            if (category == UnicodeCategory.NonSpacingMark)
                continue;

            if (char.IsLetterOrDigit(character))
            {
                builder.Append(char.ToLowerInvariant(character));
            }
        }

        return builder
            .ToString()
            .Normalize(NormalizationForm.FormC);
    }
}