using Microsoft.WindowsAzure.Storage.Table;

namespace Models
{
    public class StudentEntity:TableEntity
    {
        public StudentEntity(string universitate, string cnp)
        {
            this.PartitionKey=universitate;
            this.RowKey=cnp;
        }
        public StudentEntity(){ }
        public string Nume{get; set;}
        public string Prenume{get;set;}

        public string Email{get; set;}
        public string PhoneNumber{get;set;}

        public int An{get; set;}
        public string Facultate{get; set;}
    }
}