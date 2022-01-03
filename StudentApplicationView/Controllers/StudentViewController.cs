using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using StudentApplicationView.Models;
using Newtonsoft.Json;
using System.Text;

namespace StudentApplicationView.Controllers
{
    public class StudentViewController : Controller
    {
        // GET: StudentViewController
        public ActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5000/api/Students").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<Student> students=JsonConvert.DeserializeObject<List<Student>>(data);
            return View(students.ToList());
        }
        /*private void loaddept()
        {
            try
            {
                List<department> dep = new List<department>();
                dep = _Db.department.ToList();
                dep.Insert(0, new department { Id = 0, Department = "please Select" });
                ViewBag.DepList = dep;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/

        // GET: StudentViewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentViewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentViewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Student student)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await client.PostAsync("http://localhost:5000/api/Students", content);
            if (Response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
            /* try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }*/
        }

        // GET: StudentViewController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = new Student();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5000/api/Students/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<Student>(data);
            }
            return View(student);
            
        }

        // POST: StudentViewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                HttpClient client =new HttpClient();

                var data = JsonConvert.SerializeObject(student);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage res = client.PutAsync($"http://localhost:5000/api/Students/{student.StudentId}", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentViewController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            HttpClient client = new HttpClient();
            //StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await client.DeleteAsync("http://localhost:5000/api/Students/" + id);
            if (Response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: StudentViewController/Delete/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Student student)
        {
            HttpClient client = new HttpClient();
            //StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await client.DeleteAsync("http://localhost:5000/api/Students/"+id);
            if (Response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }*/
    }
}
