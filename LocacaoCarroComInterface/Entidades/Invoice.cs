using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace LocacaoCarroComInterface.Entidades
{
    public class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double totalPayment
        {
            get { return BasicPayment + Tax;  }
        }

        public override string ToString()
        {
            return "Pagamento Básico: "
                + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
            + "\nTaxa: "
            + Tax.ToString("F2", CultureInfo.InvariantCulture)
            + "\nPagamento Total: "
            + totalPayment.ToString("F2",CultureInfo.InvariantCulture);
        }
    }
}
