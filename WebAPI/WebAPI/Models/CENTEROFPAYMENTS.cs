using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CENTEROFPAYMENTS
    {
        public string reference;
        public string response;
        public int foliocpagos; //Confirmacion de que este seria el tipo de dato?
        public int auth; //Confirmacion de que este seria el tipo de dato?
        public string cd_response;
        public int  cd_error; //Confirmacion de que este seria el tipo de dato?
        public string nb_error;
        public DateTime Time;
        public DateTime Date;
        public string nb_company;
        public string nb_merchant;
        public string cc_type;
        public string tb_operation;
        public string cc_name;
        public int cc_number;
        public Decimal amount;
        public string id_url;
        public string email;
        public string cc_mask;
        public List<data> datos_adicionales;
    }
}
