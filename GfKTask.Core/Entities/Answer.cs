using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfKTask.Core.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public virtual Question Question { get; set; }
    }
}
