using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Studenti.Controllers
{
    
    
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentRepo.Students;
        }

        [HttpGet("{id}")]
        public Student GetStudents(int id)
        {
         return StudentRepo.Students.FirstOrDefault(s =>s.Id==id);
        }
        
        [HttpPost]
        public string Post(Student st)
        {
            try{
                StudentRepo.Students.Add(st);
                return "S-a adaugat studentul!";

            }
            catch(System.Exception e)
            {
                return "Eroare:" +e.Message;
                throw;
            }
            
        }
       [HttpPut("{id}")]
       public void Put(int id, [FromBody] Student st)
       {
           StudentRepo.Students[id]=st;
       }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudentRepo.Students.RemoveAt(id);
        }

    }

}