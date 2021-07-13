using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class P
    {
        public businessClass business;
        public urlClass url;
    }

    public class businessClass
    {
        public string id_company; //Identificador del Comercio al que se le asociará el pago.
        public string id_branch;  //Identificador de la Sucursal del Comercio a la que se le asociará el pago.
        public string user;  //Usuario que genera la petición. Con este usuario se procesará la transacción de cobro.
        public string pwd; //Contraseña de acceso para autenticación del usuario.
    }

    public class urlClass
    {
        public string reference;  //Referencia única/irrepetible del comercio para conciliar un pago con su lógica de negocio. Se sugiere número de factura o pedido.
        public decimal amount;  //Importe a pagar con 2 decimales separado por un punto.
        public string moneda;  //Específica la moneda para la intención de cobro, si se tienen configuradas afiliaciones en pesos y dólares en la sucursal. Valores posibles: MXN ó USD.
        public char canal;  //Valor fijo, debe ser W.
        public int omitir_notif_default;  //Si este elemento se recibe con el valor 0 , se enviará la notificación de cobro realizada al tarjetahabiente vía correo electrónico, con formato e imagen de Centro de Pagos.
        public string promociones; //Si este elemento se recibe, indica las promociones a meses con las que se puede realizar el pago, cuando se tienen varias afiliaciones con promociones configuradas en la sucursal. En todos los casos, la opción de pago de contado siempre estará disponible. Para forzar el pago a sólo contado, deberá indicarse sólo C .
        public string st_correo; //Si este elemento se recibe con el valor 1 , se solicitará la captura del correo electrónico en el formulario de pago.
        public DateTime fh_vigencia;  //Si este elemento se recibe con el valor 1 , se solicitará la captura del correo electrónico en el formulario de pago.
        public string mail_cliente;  //Si el elemento está presente se precargará este valor en el campo “Correo Electrónico” del formulario de pago. El tarjetahabiente podrá cambiarlo si así lo desea. Nota: el campo st_correo deberá indicar 1 .
        public datos_adicionalesClass[] datos_adicionales;  //Si este elemento está presente, se incluirán los elementos hijos data en el formulario de pago y serán devueltos en la respuesta del resultado de un cobro. Si se especifica el atributo “display” con el booleano true , estos se mostrarán en el formulario de pago.
        public string version;  //Especifica el canal que manda a solicitar una liga. Es obligatorio colocar el valor IntegraWPP
    }
    public class datos_adicionalesClass
    {
        public string label;
        public string value;
    }
}
