using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Models;

namespace studenti_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
       private IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
          _studentRepository=studentRepository; 

        }

        [HttpGet]
        public async Task<IEnumerable<StudentEntity>> Get()
        {
            return await _studentRepository.GetAllStudents();
        }

       [HttpPost]
       
       public async Task <string> Post( [FromBody] StudentEntity student)
       {
           try
           {
               await _studentRepository.CreateNewStudent(student);
               return "S-a adaugat cu succes";
           }
           catch(System.Exception e)
           {
               return "Eroare:" +e.Message;
               throw;
           }
       }
      
    }
}
