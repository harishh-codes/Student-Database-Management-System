using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Database_Management_System.Models;
using Student_Database_Management_System.Repositories;

namespace Student_Database_Management_System.Controllers
{
    public class HomeController : Controller
    {

        StudentRepositories sr = new StudentRepositories();

        //Get
        public ActionResult Index()
        {
            return View(sr.GetAllStudents());
        }

        //Add
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            if(ModelState.IsValid == true)
            {
                sr.AddStudent(student);
                ModelState.Clear();
            }

            return View();
        }

        //GetStudentsById
        public ActionResult Details(int id)
        {
            var row = sr.GetStudentByID(id);
            return View(row);
        }


        //Update
        public ActionResult Update(int id)
        {
            var row = sr.GetStudentByID(id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            
           sr.UpdateStudent(student);
         
           return RedirectToAction("Index");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            var row = sr.GetStudentByID(id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            
            sr.DeleteStudent(student);
            
            return RedirectToAction("Index");
        }

      
    }
}