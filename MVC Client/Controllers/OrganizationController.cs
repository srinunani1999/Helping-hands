using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;
using Newtonsoft.Json;

namespace MVC_Client.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: OrganizationController
        public async Task<ActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
               // _log4net.Info("token not found");

                return RedirectToAction("Login","Login");

            }
            List<Organization> organizations = new List<Organization>();
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                using (var response = await client.GetAsync("http://localhost:50839/api/Organizations"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    organizations = JsonConvert.DeserializeObject<List<Organization>>(apiResponse);
                }

            }
            return View(organizations);
        }

        [HttpGet]
        public ActionResult PostOrganization()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                // _log4net.Info("token not found");

                return RedirectToAction("Login", "Login");

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  async Task<IActionResult> PostOrganization(Organization organization)
        {
            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }
            using (var httpclinet=new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(organization), Encoding.UTF8, "application/json");
                using (var response = await httpclinet.PostAsync("http://localhost:50839/api/Organizations", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    organization = JsonConvert.DeserializeObject<Organization>(apiResponse);
                }
            }
            return RedirectToAction("Index");

        }

        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
