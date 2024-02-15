using System;
using System.Collections.Generic;
using System.Linq;

public class Invoice
{
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public decimal RemainingAmount { get; set; }

    public Invoice(string name, DateTime dueDate, decimal amount)
    {
        Name = name;
        DueDate = dueDate;
        Amount = amount;
        RemainingAmount = amount;
    }
}

public class PaymentAllocation
{
    public static void AllocatePayment(decimal paymentAmount, List<Invoice> invoices)
    {
        if (paymentAmount <= 0)
        {
            Console.WriteLine("Input payment amount must be greater than 0.");
            return;
        }

        invoices = invoices.OrderBy(i => i.DueDate).ThenBy(i => i.Amount).ToList();

        foreach (var invoice in invoices)
        {
            decimal amountToPay = Math.Min(paymentAmount, invoice.RemainingAmount);
            invoice.RemainingAmount -= amountToPay;
            paymentAmount -= amountToPay;

            Console.WriteLine($"{invoice.Name}\tDue: {invoice.DueDate:dd MMM yy}\t{invoice.Amount}\t{amountToPay}");

            if (paymentAmount == 0)
                break;
        }

        if (paymentAmount > 0)
        {
            Console.WriteLine($"Remaining payment amount: {paymentAmount}");
        }
    }

    public static void Main(string[] args)
    {
        List<Invoice> invoices = new List<Invoice>
        {
            new Invoice("Tagihan#1", new DateTime(2023, 1, 10), 165000),
            new Invoice("Tagihan#2", new DateTime(2023, 2, 15), 80000),
            new Invoice("Tagihan#3", new DateTime(2023, 1, 20), 130000),
            new Invoice("Tagihan#4", new DateTime(2023, 3, 25), 416000),
            new Invoice("Tagihan#5", new DateTime(2023, 2, 10), 95500),
            new Invoice("Tagihan#6", new DateTime(2023, 8, 17), 523000)
        };

        Console.WriteLine("Payment Allocation:");
        Console.WriteLine();

        decimal payment1 = 200000;
        Console.WriteLine($"Input Payment = {payment1}");
        AllocatePayment(payment1, invoices.Select(i => new Invoice(i.Name, i.DueDate, i.Amount)).ToList());
        Console.WriteLine();

        decimal payment2 = 500000;
        Console.WriteLine($"Input Payment = {payment2}");
        AllocatePayment(payment2, invoices.Select(i => new Invoice(i.Name, i.DueDate, i.Amount)).ToList());
        Console.WriteLine();

        // Query to get Total Undue and Total Overdue
        DateTime currentDate = new DateTime(2023, 3, 25);
        decimal totalUndue = invoices.Where(i => i.DueDate > currentDate).Sum(i => i.Amount);
        decimal totalOverdue = invoices.Where(i => i.DueDate <= currentDate && i.RemainingAmount > 0).Sum(i => i.RemainingAmount);

        Console.WriteLine($"Total Undue: {totalUndue}");
        Console.WriteLine($"Total Overdue: {totalOverdue}");
    }
}
