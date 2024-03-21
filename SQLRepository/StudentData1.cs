using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    public class StudentData1 
    {
        public static List<string> Student =
        [
            "Nitya",
            "Sreenidhi",
            "Uma",
            "Moukthi",
            "Priya",
            "Spoorthi"
        ];

        public List<string> getNames()
        {
            return Student;
        }
    }
}
