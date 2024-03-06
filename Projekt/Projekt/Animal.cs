using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konsola
{
    public abstract class Animal
    {
        protected int weight;
        protected string owner;
        public enum gender
        {
            male,
            female
        }
        protected gender animalgender;
        protected double price;
        public abstract double value();
    }
}
