using System;
using Microsoft.AspNetCore.Mvc;
using ot7.Models;

namespace ot7.Controllers
{
    public class AsukastilastoController : Controller
    {
        public IActionResult Index()
        {

            try {

            Asukastilasto asukastilasto = new Asukastilasto();

            return View("Index", asukastilasto.haeKaikki());


            } catch (Exception e) {

                return View("Virhe", e.Message);
            }
        }

        public IActionResult rajaa(int maara) {

            try {

            Asukastilasto asukastilasto = new Asukastilasto();

            return View("Kunta", asukastilasto.RajaaKunnat(maara));


            } catch (Exception e) {

                return View("Virhe", e.Message);
            }

            
        }

        public IActionResult haku(string hakuehto) {

            try {

            Asukastilasto asukastilasto = new Asukastilasto();

            return View("Kunta", asukastilasto.HaeKunta(hakuehto));


            } catch (Exception e) {

                return View("Virhe", e.Message);
            }

            
        }
    }
}
