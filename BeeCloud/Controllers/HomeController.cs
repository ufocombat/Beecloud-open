using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeeCloud.Models;
using System.Data.SqlClient;
using System.IO;

namespace BeeCloud.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(Lead lead)
        {
            try
            {
                SqlConnection connection = new SqlConnection("***");
                connection.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO beecloud(Name,Email,Phone,Message) VALUES (@name,@email,@phone,@msg)", connection);
                cmd.Parameters.AddWithValue("name", lead.Name ?? String.Empty);
                cmd.Parameters.AddWithValue("email", lead.Email ?? String.Empty);
                cmd.Parameters.AddWithValue("phone", lead.Phone ?? String.Empty);
                cmd.Parameters.AddWithValue("msg", lead.Message??String.Empty);

                cmd.ExecuteNonQuery();
                connection.Close();

                return Redirect("Contact");
            }
            catch (Exception e)
            {
                return new ObjectResult(e.ToString());
                //return new ObjectResult($"Please, do it correctlly...");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
