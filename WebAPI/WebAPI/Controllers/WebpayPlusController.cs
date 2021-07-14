using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Transbank.Webpay.WebpayPlus;
using WebAPI.Models;
using Transbank.Webpay.WebpayPlus.Responses;
using WebAPI.Helpers;
using System.Text.RegularExpressions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebpayPlusController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WebpayPlusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult Post(TransactionRequest trans)
        {
            businessClass _business = new businessClass();
            _business.id_company = "SNBX"; // Estos datos continuan estando hardcodeados
            _business.id_branch = "01SNBXBRNCH";
            _business.user = "SNBXUSR01";
            _business.pwd = "SECRETO";

            urlClass _url = new urlClass();
            _url.reference = trans.BuyOrder;
            _url.amount = trans.Amount;
            _url.moneda = "MXN";
            _url.canal = "W"; // Se cambió de char a string 13-Jul-21
            _url.omitir_notif_default = 1;
            _url.promociones = "C";
            _url.st_correo = "1";
            _url.fh_vigencia = DateTime.Now.ToString("dd/MM/yyyy"); // Se cambió de datetime a string 13-Jul-21
            _url.mail_cliente = "mail@dominio.com";
            // Agregado 13-Jul-21 y se eliminó datos_adicionalesClass
            _url.datos_adicionales = new List<data>() {
                new data() { id=1, display=true, label = "Código de clientes", value = trans.ClientCode }
            };
            _url.version = "IntegraWPP";

            string xmlSinCifrar = XMLstandard.serializaXML(_business, _url);
            string xmlCifrado = XMLstandard.CifrarCadena(xmlSinCifrar);
            string respuestaCifrada = XMLstandard.ServicioDeGeneracion(xmlCifrado);
            string respuestaDescifrada = XMLstandard.DescifrarRespuesta(respuestaCifrada);
            string ligaDeCobro = XMLstandard.leerXml(respuestaDescifrada);

            return new JsonResult(ligaDeCobro);
        }
    }
}
