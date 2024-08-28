namespace LiskovCompliantExample
{
    public abstract class Payment
    {
        public abstract void ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : Payment
    {
        public override void ProcessPayment(decimal amount)
        {
            // Procesar pago con tarjeta de crédito
            Console.WriteLine($"Procesando pago con tarjeta de crédito de {amount:C}.");
        }
    }

    public class BankTransferPayment : Payment
    {
        private bool IsSpecialAuthorizationGranted { get; set; }

        public BankTransferPayment(bool isSpecialAuthorizationGranted)
        {
            IsSpecialAuthorizationGranted = isSpecialAuthorizationGranted;
        }

        public override void ProcessPayment(decimal amount)
        {
            if (IsSpecialAuthorizationGranted)
            {
                Console.WriteLine($"Procesando transferencia bancaria de {amount:C} con autorización especial.");
            }
            else
            {
                Console.WriteLine($"Procesando transferencia bancaria de {amount:C}.");
            }
        }
    }

    // class Program
    // {
    //     static void Procesar(Payment payment, decimal amount)
    //     {
    //         payment.ProcessPayment(amount);
    //     }

    //     static void Main(string[] args)
    //     {
    //         Payment creditCardPayment = new CreditCardPayment();
    //         Procesar(creditCardPayment, 1000); // Correcto

    //         Payment bankTransferPayment = new BankTransferPayment(true);
    //         Procesar(bankTransferPayment, 1000); // Correcto
    //     }
    // }
}
