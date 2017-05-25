using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Generic
{
    public class Money
    {
        public string Symbol { get; set; }
        public string Currency { get; set; }
        public double Value { get; set; }
        public override string ToString() => $"{Currency} {Symbol} {Value.ToString("N")}".Trim();
    }
}
