using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }        
        public bool IsDone { get; set; }
        public virtual int CategoryId { get; set; }
        public string CategoryUrl { get; set; }
    }
}