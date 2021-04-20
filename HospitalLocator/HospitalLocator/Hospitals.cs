using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace HospitalLocator
{
    class Hospitals
    {
        public string Link { get; set; }
        public string Label { get; set; }
        public Position Position { get; set; }
    }

    public class Rootobject
    {
        public Head head { get; set; }
        public Results results { get; set; }
    }

    public class Head
    {
        public string[] vars { get; set; }
    }

    public class Results
    {
        public Binding[] bindings { get; set; }
    }

    public class Binding
    {
        public Item item { get; set; }
        public Itemlabel itemLabel { get; set; }
        public Lat lat { get; set; }
        public Lon lon { get; set; }
    }

    public class Item
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Itemlabel
    {
        public string xmllang { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Lat
    {
        public string datatype { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Lon
    {
        public string datatype { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }


}
