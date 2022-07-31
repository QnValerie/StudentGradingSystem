using System.Collections.Generic;

namespace DataLayer
{
    internal abstract class TextfilestreamBase
    {
        internal static abstract void AppendFile(List<string> Studentnumber, List<string> Studentname, List<string> Gender, List<string> OOP, List<string> IM, List<string> HCI, List<string> NetAd, List<string> Integ);
    }
}