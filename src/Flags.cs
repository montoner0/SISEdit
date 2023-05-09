using System;

namespace sisedit
{
    public class Flags
    {
        public Flags(uint value) => FlagsList = value;

        public override string ToString() => Convert.ToString(FlagsList);

        public uint FlagsList { get; set; } = 0;
    }
}
