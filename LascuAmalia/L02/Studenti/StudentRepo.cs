using System.Collections.Generic;
namespace Studenti
{
    public static class StudentRepo
    {
        public static List<Student> Students=new List<Student>()
        {
            new Student(){ Id=0, Nume="Lascu", Prenume="Amalia", Facultate="AC",AnStudiu=4},
            new Student(){Id=1, Nume="Benea", Prenume="Bianca", Facultate="AC", AnStudiu=3},
            new Student(){Id=2, Nume="Barbu", Prenume="Debora", Facultate="MPT", AnStudiu=2},
            new Student(){Id=3, Nume="Ban", Prenume="Madalina", Facultate="ETC", AnStudiu=1}
        };
    }
}