using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppDomain.Enum;

namespace ToDoAppDomain.Entity
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTime? DueDate { get; set; }

        public string UserId { get; set; }

        public List<string> Tags { get; set; }

        public PriorityLevel PriorityLevel { get; set; }

    }
}
