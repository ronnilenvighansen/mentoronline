using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MentorOnlineV3.Models;
using MentorOnlineV3.Models.Entities;


namespace MentorOnlineV3.Controllers
{
    public class HomeController : Controller
    {
 
        MentorDbContext db = new MentorDbContext();

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Create mentor
        [HttpGet]
        public IActionResult CreateMentor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMentor(Mentor ment)
        {
            db.Mentors.Add(ment);
            db.SaveChanges();
            return View();
        }

        //Create student
         [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(Student stud)
        {
            db.Students.Add(stud);
            db.SaveChanges();
            return View();
        }
        
        // search metode
        // søg på - id
        // få udskrevet alt info on den ene person
        public IActionResult SearchMentor(int id = 1)
        {
            ViewBag.number = id;

            ViewBag.ment = db.Mentors.ToList();

            return View();
        }

         public IActionResult SearchStudent(int id = 1)
        {
            ViewBag.number = id;

            ViewBag.stud = db.Students.ToList();

            return View();
        }

    //Update Mentor

     [HttpGet]
        public IActionResult UpdateMentor(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateMentor(int id, string name, string password, string email, string subjects, int role, int online, string imgurl)
        {
            Mentor ment = new Mentor()
            {
                MentorId = id,
                Name = name,
                Password = password,
                Email = email,
                Subjects = subjects,
                Role = role,
                Online = online,
                Imgurl = imgurl
            };
            db.Update(ment);
            db.SaveChanges();
            return View();
        }

    //Update Student

    [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStudent(int id, string name, string password, string email, int subscribed, int role, int paymentinfo)
        {
            Student stud = new Student()
            {
                StudentId = id,
                Name = name,
                Password = password,
                Email = email,
                Subscribed = subscribed,
                Role = role,
                Paymentinfo = paymentinfo,
            };
            db.Update(stud);
            db.SaveChanges();
            return View();
        }

        
    [HttpGet]
        public IActionResult UpdateMessage(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateMessage(int id, string text, string sender, string receiver, string topic)
        {
            Message mess = new Message()
            {
                MessageId = id,
                Text = text,
                Sender = sender,
                Receiver = receiver,
                Topic = topic,
            };
            db.Update(mess);
            db.SaveChanges();
            return View();
        }


        //DeleteMentor

         [HttpGet]
        public IActionResult DeleteMentor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteMentor(int id)
        {
            Mentor ment = new Mentor() { MentorId = id };
            db.Mentors.Remove(ment);
            db.SaveChanges();
            return View();
        }

          [HttpGet]
        public IActionResult DeleteStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            Student stud = new Student() { StudentId = id };
            db.Students.Remove(stud);
            db.SaveChanges();
            return View();
        }

         [HttpGet]
        public IActionResult StudentPage(string id)
        {
            ViewBag.subject = id;
            ViewBag.ment = db.Mentors.ToList();
            return View();
        }

        
       

         [HttpGet]
        public IActionResult SendMailMentor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMailMentor(Message mess)
        {
            db.Messages.Add(mess);
            db.SaveChanges();
            return View();
        }



           [HttpGet]
        public IActionResult SendMailStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMailStudent(Message mess)
        {
            db.Messages.Add(mess);
            db.SaveChanges();
            return View();
        }

        
        public IActionResult GetMailMentor(String id)
        {
            ViewBag.receivername = id;
            ViewBag.mess = db.Messages.ToList();
            return View();
        }

         [HttpGet]
         public IActionResult GetMailStudent(String id)
        {
            ViewBag.receivername = id;
            ViewBag.mess = db.Messages.ToList();
            return View();
        }

       
         public IActionResult GetMailMentors(String id)
        {
            ViewBag.receivername = id;
            ViewBag.mess = db.Messages.ToList();
            return View();
        }
        
         [HttpGet]
        public IActionResult Mentor(int id)
        {
            ViewBag.number = id;

            ViewBag.ment = db.Mentors.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Online()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Offline()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Online(int id)
        {
            Mentor ment = db.Mentors 
                    .Where(b => b.MentorId == id) 
                    .FirstOrDefault();
                    if(ment != null){
                        ment.Online = 1;
                        db.SaveChanges();
                    }    
            return View();
        }
        
        [HttpPost]
        public IActionResult Offline(int id)
        {
            Mentor ment = db.Mentors 
                    .Where(b => b.MentorId == id) 
                    .FirstOrDefault();
                    if(ment != null){
                        ment.Online = 0;
                        db.SaveChanges();
                    }    
            return View();
        }

        [HttpGet]
        public IActionResult Student()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Subscribe()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Unsubscribe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Subscribe(int id)
        {
            Student stud = db.Students 
                    .Where(b => b.StudentId == id) 
                    .FirstOrDefault();
                    if(stud != null)
                    {
                        stud.Subscribed = 1;
                        db.SaveChanges();
                    }    
            return View();
        }

        [HttpPost]
        public IActionResult Unsubscribe(int id)
        {
            Student stud = db.Students 
                    .Where(b => b.StudentId == id) 
                    .FirstOrDefault();
                    if(stud != null)
                    {
                        stud.Subscribed = 0;
                        db.SaveChanges();
                    }    
            return View();
        }

    }
}
