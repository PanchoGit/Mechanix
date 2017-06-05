using System.Collections.Generic;

namespace Mechanix.Domain
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public int Year { get; set; }

        public string Patent { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
