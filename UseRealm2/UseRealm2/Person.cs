using System;
using Realms;

namespace UseRealm2
{
    public class Person : RealmObject
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
