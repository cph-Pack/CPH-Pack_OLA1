using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_Pack_OLA1
{
    public class TestTask
    {
        public required String TaskName { get; set; }
        public required String TaskValue { get; set; }
        public DateOnly Deadline { get; set; } = new DateOnly();
        public Boolean IsCompleted { get; set; } = false;

    }
}
