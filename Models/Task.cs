using System;
using System.Collections.Generic;
using System.Text;


namespace FishFeedingTask.Models
{
    class Task
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime DueDate { get; protected set; }
       
        public Task(string name, DateTime DueDate)
        {
            this.Name = name;
            this.DueDate = DueDate;
        }


        public override string ToString()
        {
            return String.Format("Id {0} name {1} DueDate {2}", this.Id, this.Name, this.DueDate);
        }
    }
}
