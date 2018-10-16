using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackDragon.Testing
{
    public struct TestResult
    {
        public bool IsSuccess { get; set; }

        public object Result { get; set; }

        public string Message { get; set; }
    }
}
