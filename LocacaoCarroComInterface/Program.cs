using System;
using static System.Console;
using System.Globalization;
using LocacaoCarroComInterface.Entidades;
using LocacaoCarroComInterface.Serviços;

namespace LocacaoCarroComInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Digite os dados do aluguel");
            ForegroundColor = ConsoleColor.Red;
            Write("Modelo do carro: ");
            string modelo = ReadLine();
            ResetColor();
            Write("Retirada do veículo: (dd/MM/yyyy hh:mm): ");
            ForegroundColor = ConsoleColor.Red;
            DateTime retirada = DateTime.Parse(ReadLine());
            ResetColor();
            Write("Entrega do veículo: (dd/MM/yyyy hh:mm): ");
            ForegroundColor = ConsoleColor.Red;
            DateTime entrega = DateTime.Parse(ReadLine());
            ResetColor();
            Write("Digite o preço por hora: ");
            ForegroundColor = ConsoleColor.Red;
            double precoPorHora = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
            ResetColor();
            Write("Digite o preço por dia: ");
            ForegroundColor = ConsoleColor.Red;
            double precoPorDia = double.Parse(ReadLine(), CultureInfo.InvariantCulture);

            //Instanciar um aluguel de veículo
            CarRental carRental = new CarRental(retirada, entrega, new Vehicle(modelo));
            //Instanciar um serviço de aluguel passando a dependêcia, que é a classe concreta BrazilTaxService 
            RentalService rentalService = new RentalService(precoPorHora, precoPorDia, new BrazilTaxService());
            //Associar o objeto Fatura ao aluguel do veículo
            rentalService.ProcessInvoice(carRental);

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine("::::::::::: FATURA :::::::::::");
            WriteLine(carRental.Invoice);
            ResetColor();
        }
    }
}
