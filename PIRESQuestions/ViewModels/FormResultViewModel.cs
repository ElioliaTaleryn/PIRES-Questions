using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class FormResultViewModel
    {
        public Form Form { get; set; }
        public List<Question> Questions { get; set; }
        public List<Choice> Choices { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Anonymous> Anonymous { get; set; }
    }
}
