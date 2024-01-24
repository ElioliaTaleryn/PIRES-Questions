﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TimerCD
    {
        #region Fields
        public int Id { get; set; }
        public int CountDown { get; set; }
        #endregion
        #region Relative Fields
        public List<Question>? Question { get; set; }
        public List<Form>? Forms { get; set; }
        #endregion
    }
}