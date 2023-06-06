using System;
using System.Xml.Linq;

namespace Kopakabana
{
    [Serializable()]
    public class Sport{}
    [Serializable()]
    public class Siatkowka : Sport
    {
        public override bool Equals(object? obj)
        {
            return obj is Siatkowka;
        }
        public override string ToString()
        {
            return "Siatkówka";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    [Serializable()]
    public class DwaOgnie : Sport
    {
        public override bool Equals(object? obj)
        {
            return obj is DwaOgnie;
        }
        public override string ToString()
        {
            return "Dwa Ognie";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    [Serializable()]
    public class PrzeciaganieLiny : Sport
    {
        public override bool Equals(object? obj)
        {
            return obj is PrzeciaganieLiny;
        }
        public override string ToString()
        {
            return "Przeciąganie Liny";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
