using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMaintenance.Entities
{
    class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string firstname { get; set; } 
        public string lastname { get; set; }
        public string fullname
        {
            get
            {
                return string.Format("{0} {1}", lastname, firstname);
            }
        }
    }
}
