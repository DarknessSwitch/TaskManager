using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Subtask
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual int TaskId { get; set; }
        public bool IsDone { get; set; }
    }
}