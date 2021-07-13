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
            P p = new P();
            businessClass _business = new businessClass();
            _business.id_company = "SNBX";
            _business.id_branch = "01SNBXBRNCH";
            _business.user = "SNBXUSR01";
            _business.pwd = "SECRETO";

            urlClass _url = new urlClass();
            _url.reference = trans.BuyOrder;
            _url.amount = trans.Amount;
            _url.moneda = "MXN";
            _url.canal = 'W'; // Valor fijo, no se menciona tipo de dato en la guía de integración, actualmente es char
            _url.omitir_notif_default = 1;
            _url.promociones = "C";
            _url.st_correo = "1";
            _url.fh_vigencia = DateTime.Now.Date;
            _url.mail_cliente = "mail@dominio.com";
            _url.version = "IntegraWPP";

            // falta agregar datos adicionales

            string regresa = XMLstandard.serializaXML(_business, _url);

            return new JsonResult(regresa);
        }
    }
}
