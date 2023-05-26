using System;

namespace Kopakabana
{
    [Serializable()]
    class Sport
    {

    }
    [Serializable()]
    class Siatkowka : Sport
    {
        public override string ToString()
        {
            return "Siatkowka";
        }
    }
    [Serializable()]
    class DwaOgnie : Sport
    {
        public override string ToString()
        {
            return "DwaOgnie";
        }
    }
    [Serializable()]
    class PrzeciaganieLiny : Sport
    {
        public override string ToString()
        {
            return "PrzeciaganieLiny";
        }
    }
}
