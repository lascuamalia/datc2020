using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Models
{
    public class Metrici : TableEntity
    {
        

        public Metrici(string universiate, string timestamp)
        {
            this.PartitionKey = universiate;
            this.RowKey = timestamp;
          
        }

        public Metrici() { }

        public int Count { get; set; }
     //  public string RowKey { get ; set; }
    }
}