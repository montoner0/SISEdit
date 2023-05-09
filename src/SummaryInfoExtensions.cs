using WindowsInstaller;

namespace sisedit
{
    internal static class SummaryInfoExtensions
    {
        public static void SetSisProperty(this SummaryInfo si, SisProp prop, object value)
        {
            si.Property[(int)prop] = value;
        }

        public static object GetSisProperty(this SummaryInfo si, SisProp prop)
        {
            return si.Property[(int)prop];
        }
    }
}
