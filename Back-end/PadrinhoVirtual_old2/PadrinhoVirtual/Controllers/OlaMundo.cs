using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace PadrinhoVirtual.Controllers
{
    public class OlaMundo : Controller
    {       
    {       
        
        // GET: /OlaMundo/
        public string Index()
        {
            return "Este é a Action padrão (Index)...";
        }
        // 
        // GET: /OlaMundo/BemVindo/ 
        public string BemVindo(string nome, int numVezes = 1)
        {
            return HtmlEncoder.Default.Encode($"Ola {nome}, NumVezes igual a : {numVezes}");
        }
    }
}
