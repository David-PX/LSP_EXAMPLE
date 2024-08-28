namespace LiskovViolationExample
{
    public class Payment
    {
        public virtual void ProcessPayment(decimal amount)
        {
            // Lógica general para procesar un pago
            Console.WriteLine($"Procesando un pago de {amount:C}.");
        }
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
        public override void ProcessPayment(decimal amount)
        {
            // Supongamos que necesitamos una autorización especial
            throw new InvalidOperationException("Este tipo de pago requiere autorización manual.");
        }
    }

    class Program
    {
        static void Process(Payment payment, decimal amount)
        {
            payment.ProcessPayment(amount);
        }

        static void Main(string[] args)
        {
            try
            {
                Payment payment = new BankTransferPayment();
                Process(payment, 1000);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
