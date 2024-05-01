using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bilard.Data
{
    public abstract class DataAbstractAPI
    {

        public static DataAbstractAPI CreateAPI()
        {
            return new DataAPI();
        }
    }

    internal class DataAPI : DataAbstractAPI
    {

    }
}
