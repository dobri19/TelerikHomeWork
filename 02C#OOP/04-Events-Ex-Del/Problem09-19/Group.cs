using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem09_19
{
    public class Group
    {
        public Group(string groupNumber)
        {
            this.GroupNumber = groupNumber;
        }

        public Group(string groupNumber, string departName) : this(groupNumber)
        {
            this.DepartmentName = departName;
        }

        public string GroupNumber { get; set; }
        public string DepartmentName { get; set; }
    }
}
