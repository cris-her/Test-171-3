using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TransactionRequest
    {
        public Decimal Amount { get; set; } // entero o decimal es indistinto por el momento
        public string ClientCode { get; set; } // concatenado con fecha y hora del front, ¿o debe ser del back?
        public string BuyOrder { get; set; } // referencia, por el momento viene del front

    }
}
