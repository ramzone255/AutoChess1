using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractWork
{
    [Table("Type_Of_Contract")]
    public class TypeOfContract
    {
        [PrimaryKey, AutoIncrement, Column("id_type")]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
