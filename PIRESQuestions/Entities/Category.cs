using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        //Attributs propres
        public int Id { get; set; }
        public string Label { get; set; }

        //Liens des autres entités
        // n-n
        public List<Form>? Forms { get; set; }
    }
}
