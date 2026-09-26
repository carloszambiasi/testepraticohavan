namespace Havan.Exercises.Exercises;

public static class PaymentProcessor
{
    private const decimal BaseAmount = 1000.00m;
    private static readonly DateTime DueDate = new(2026, 10, 10);

    public static decimal Calculate(DateTime paymentDate)
    {
        paymentDate = paymentDate.Date;

        Console.WriteLine($"Valor base: {BaseAmount:C}");
        Console.WriteLine($"Vencimento: {DueDate:dd/MM/yyyy}");
        Console.WriteLine($"Pagamento: {paymentDate:dd/MM/yyyy}");

        if (paymentDate < DueDate)
        {
            var daysEarly = (DueDate - paymentDate).Days;

            var discountPercentage = Math.Min(daysEarly * 0.01m, 0.10m);
            var discountAmount = BaseAmount * discountPercentage;

            var finalAmount = BaseAmount - discountAmount;

            Console.WriteLine($"Pagamento antecipado em {daysEarly} dia(s).");
            Console.WriteLine($"Desconto: {discountPercentage:P0}");
            Console.WriteLine($"Valor do desconto: {discountAmount:C}");
            Console.WriteLine($"Valor final: {finalAmount:C}");

            return finalAmount;
        }

        if (paymentDate == DueDate)
        {
            Console.WriteLine("Pagamento realizado na data de vencimento.");
            Console.WriteLine("Sem juros, multa ou desconto.");
            Console.WriteLine($"Valor final: {BaseAmount:C}");

            return BaseAmount;
        }

        var daysLate = (paymentDate - DueDate).Days;

        const decimal finePercentage = 0.02m;
        var interestPercentage = daysLate * 0.005m;

        var fineAmount = BaseAmount * finePercentage;
        var interestAmount = BaseAmount * interestPercentage;

        var lateFinalAmount =
            BaseAmount + fineAmount + interestAmount;

        Console.WriteLine($"Pagamento atrasado em {daysLate} dia(s).");
        Console.WriteLine($"Multa fixa: {finePercentage:P0}");
        Console.WriteLine($"Valor da multa: {fineAmount:C}");
        Console.WriteLine($"Juros: {interestPercentage:P1}");
        Console.WriteLine($"Valor dos juros: {interestAmount:C}");
        Console.WriteLine($"Valor final: {lateFinalAmount:C}");

        return lateFinalAmount;
    }
}