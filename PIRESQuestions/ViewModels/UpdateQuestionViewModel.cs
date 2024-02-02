using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UpdateQuestionViewModel
    {
        public Question Question { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
