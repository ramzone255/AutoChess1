using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractWork
{
    [Table("User")]
    public class Users
    {
        [PrimaryKey, AutoIncrement, Column("id_user")]
        public int Id { get; set; }
        public string Log { get; set; }
        public string Pass { get; set; }
        public string Pass2 { get; set; }
    }
}
