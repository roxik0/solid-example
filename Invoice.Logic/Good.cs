using System;

namespace Fakturownik.Logic
{
    public class Good
    {
        public string Name { get; internal set; }

        public static object[] GetAll()
        {
            return new Good[]{
                new Good { Name = "Piwo" },
                new Good { Name = "Mleko" },
                new Good { Name = "Chleb" },
            };

        }
        public override string ToString()
        {
            return Name;
        }
    }
}