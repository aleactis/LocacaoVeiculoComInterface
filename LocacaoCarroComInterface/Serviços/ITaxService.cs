using System;
using System.Collections.Generic;
using System.Text;

namespace LocacaoCarroComInterface.Serviços
{
    interface ITaxService
    {
        double Tax(double amount);
    }
}