using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Logs
    {
        [Key]
        public int LogId { get; set; }
        public string LogContent { get; set; }
    }
}
