using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContractWork
{
    [Table("Contract_Status")]
    public class ContractStatus
    {
        [PrimaryKey, AutoIncrement, Column("id_status")]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
