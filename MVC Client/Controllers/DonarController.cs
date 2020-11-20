using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;
using Newtonsoft.Json;

namespace MVC_Client.Controllers
{
    public class DonarController : Controller
    {
        // GET: DonarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DonarController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {


            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }

            List<Donar> donars = new List<Donar>();
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                using (var response = await client.GetAsync("https://localhost:44348/api/donar"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    donars = JsonConvert.DeserializeObject<List<Donar>>(apiResponse);
                }

            }
            List<Donar> donarsList = new List<Donar>();

            foreach (var item in donars)
            {
                if (item.organization_Id==id)
                {
                    donarsList.Add(item);
                }
            }
            return View(donarsList);
        }

        // GET: DonarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DonarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DonarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
