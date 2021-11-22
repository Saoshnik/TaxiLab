using System;

namespace Lab_3.InterfaceImplementers.Parts.Bodies
{
    [Serializable]
    public class PremiumBody : Body
    {
        public PremiumBody() { }
        public PremiumBody(Body body) : base(body) { }

        public override string Doors() { return $"tuf"; }
    }
}
