using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Models;

namespace studenti_webapi
{
    public class StudentRepository : IStudentRepository
    {
        private string _connectionString;
        private CloudTableClient _tableClient;
        private CloudTable _studentsTable;
public StudentRepository(IConfiguration configuration)
{
    _connectionString=configuration.GetValue<string>("AzureStorageAccountConnectionString");
    Task.Run(async()=>{await InitializeTable();})
    .GetAwaiter()
    .GetResult();
}
    

  public async Task CreateNewStudent(StudentEntity student)
  {
            var insertOperation=TableOperation.Insert(student);

            await _studentsTable.ExecuteAsync(insertOperation);
 }

        public async Task<List<StudentEntity>> GetAllStudents()
        {
            var students=new List<StudentEntity>();
          
           TableQuery<StudentEntity> query= new TableQuery<StudentEntity>();
          
           TableContinuationToken token=null;
           do{
               TableQuerySegment<StudentEntity> resultSegmant= await _studentsTable.ExecuteQuerySegmentedAsync(query, token);
               token= resultSegmant.ContinuationToken;
               
               students.AddRange(resultSegmant.Results);

           }while(token!=null);

           return students;
        }

        Task IStudentRepository.CreateNewStudent(StudentEntity student)
        {
            throw new System.NotImplementedException();
        }

        private async Task InitializeTable(){
            
            var account=CloudStorageAccount.Parse(_connectionString);
            _tableClient= account.CreateCloudTableClient();

            _studentsTable=_tableClient.GetTableReference("studenti");
            await _studentsTable.CreateIfNotExistsAsync();
        }
    }
}