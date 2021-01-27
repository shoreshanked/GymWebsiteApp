using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class TrainingBlock
    {
        public int ID { get; set; }

        public string BlockName { get; set; }

        [ForeignKey("User")]
        public  int UserId { get; set; }

        public virtual User User { get; set; }
    }
}

    