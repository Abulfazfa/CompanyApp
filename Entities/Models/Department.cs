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
        public string Name { get; set; }
        public int Capasity { get; set; }
        public DateTime CreatingTime { get; set; }
    }
}
