using System;
using System.Collections.Generic;
using System.Text;
using LocacaoCarroComInterface.Entidades;
using LocacaoCarroComInterface.Serviços;

namespace LocacaoCarroComInterface.Serviços
{
    class RentalService
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        //Serviços desacoplados entre si por meio da interface
        private ITaxService _taxService;

        //Realizando inversão de controle por meio de injeção de dependência (ITaxService) - Princípios SOLID
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxservice)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxservice;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = 0.0;

            //Valida a duração da locação do veículo e arredonda para cima
            if (duration.TotalHours <= 12)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            //Calcula a taxa de imposto
            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
