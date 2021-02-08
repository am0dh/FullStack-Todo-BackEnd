using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Model
{
    public class TodoTask
    {
        public int id { get; set; }
        public string todoTask { get; set; }
        public int done { get; set; }
    }
}
