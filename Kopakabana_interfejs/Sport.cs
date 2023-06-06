﻿using System;
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
            return "Siatkowka";
        }
    }
    [Serializable()]
    public class DwaOgnie : Sport
    {
        public override string ToString()
        {
            return "DwaOgnie";
        }
    }
    [Serializable()]
    public class PrzeciaganieLiny : Sport
    {
        public override string ToString()
        {
            return "PrzeciaganieLiny";
        }
    }
}
