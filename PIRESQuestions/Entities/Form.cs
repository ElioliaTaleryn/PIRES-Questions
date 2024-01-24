using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Form
    {
        //Attributs propres
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Liens des autres entités
        // n-n
        public List<Question>? Questions { get; set; }
        // 0-1
        public int? TimerId { get; set; }
        public Timer? Timer { get; set; }
        public int? DurationId { get; set; }
        public Duration? Duration { get; set; }
        // 1-1
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
