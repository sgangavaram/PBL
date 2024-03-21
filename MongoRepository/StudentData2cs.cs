using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLRepository;

namespace MongoRepository
{
    public class StudentData
    {
        public static List<string> Student =
        [
            "Madhura",
            "Vinaya",
            "Vibha",
            "Laasya",
            "Lekha",
            "Madhuri"
        ];

        public List<string> getNames()
        {
            return Student;
        }
    }
}
