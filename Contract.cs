using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractWork
{
    [Table("Contract")]
    public class Contract
    {
        [PrimaryKey, AutoIncrement, Column("code")]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Date_Of_Conclusion { get; set; }
        public string Ending_Date { get; set; }
        public double Summ{ get; set; }
        [Indexed]
        [Column("id_status")]
        public int Id_Status { get; set;}
		[Indexed]
		[Column("id_type")]
		public int Id_Type { get; set; }
	}
}
