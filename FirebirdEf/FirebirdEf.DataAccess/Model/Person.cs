using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirebirdEf.DataAccess.Model
{
    [Table("PERSONS")]
    public class Person
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("FIRSTNAME")]
        public string FirstName { get; set; }
        [Column("LASTNAME")]
        public string LastName { get; set; }
    }
}
