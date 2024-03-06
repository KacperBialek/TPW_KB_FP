using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konsola
{
    public class Cow : Animal
    {
        private int obtained_milk;
        public int Obtained_milk
        { get; set; }
        public Cow(int weight, string owner, gender animalgender, double price, int obtained_milk)
        {
            this.weight = weight;
            this.owner = owner;
            this.animalgender = animalgender;
            this.price = price;
            this.obtained_milk = obtained_milk;
        }
        public override double value()
        { return obtained_milk * price; }
    }
}
