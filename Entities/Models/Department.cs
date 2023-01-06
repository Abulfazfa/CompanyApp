using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public static int _counter { get; set; }
        public string Name { get; set; }
        public int Capasity { get; set; }

        public int MemberCount { get; set; }
        public Department()
        {
            _counter++;
            Id = _counter;
        }
    }
    
}
