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
    public class DonarController : Controller
    {
        // GET: DonarController
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DonarController));

        public ActionResult Index()
        {
            return View();
        }

        // GET: DonarController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {


            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Error("Session Expired while acccessing details");
                
                return RedirectToAction("Login", "Login");

            }
            _log4net.Info("donar details of the organization with " + id);
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
           // double sum = 0;

            foreach (var item in donars)
            {
                if (item.organization_Id==id)
                {
                   // sum += item.Amount;
                    donarsList.Add(item);
                }
            }

            //Organization org = new Organization();
            //using (var httpclinet = new HttpClient())
            //{
            //    using (var response = await httpclinet.GetAsync("http://localhost:50839/api/Organizations/" + id))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        org = JsonConvert.DeserializeObject<Organization>(apiResponse);
            //    }
            //    org.TotalDonations = sum.ToString();
            //    StringContent content = new StringContent(JsonConvert.SerializeObject(org), Encoding.UTF8, "application/json");
            //    using (var response = await httpclinet.PutAsync("http://localhost:50839/api/Organizations", content))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
                

            //    }
            //}



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
        public async Task<ActionResult> CreateAsync(int id,Donar donar)
        {
           
            
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Error("Session Expired while creating donar");

                return RedirectToAction("Login", "Login");

            }
            _log4net.Info("http post  request initiated by donar "+donar.DonorName);

            //Code for Donation
            donar.organization_Id = id;
            using (var httpclinet = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(donar), Encoding.UTF8, "application/json");
                using (var response = await httpclinet.PostAsync("https://localhost:44348/api/donar", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    donar = JsonConvert.DeserializeObject<Donar>(apiResponse);
                  
                }
            }

            //Updating Total Funds Donated To Organization

            Organization org = new Organization();
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                using (var response = await client.GetAsync("http://localhost:50839/api/Organizations/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    org = JsonConvert.DeserializeObject<Organization>(apiResponse);
                }
                double donations= Convert.ToInt32(org.TotalDonations);
                org.TotalDonations = (donar.Amount + donations).ToString();
                StringContent content = new StringContent(JsonConvert.SerializeObject(org), Encoding.UTF8, "application/json");
                using (var response = await client.PutAsync("http://localhost:50839/api/Organizations", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();


                }

            }



            return RedirectToAction("Index","Organization");
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
