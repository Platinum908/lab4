using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Price <T>:ICloneable,IComparable
    {
        public int id { get; set; }// его невозможно сделать обобщеным по причине не работы IComparable c обобщенным полем
        public string name { get; set; }
        public double cost { get; set; }
        public static int Count = 0;
        public object Clone()
        {
            return new Price<T>()
            {
                id = this.id,
                name = this.name,
                cost = this.cost
            };
        }
        public int CompareTo(object obj)
        {
            if (obj is Price<T>)
            {
                Price<T> price = obj as Price<T>;
                return this.id.CompareTo(price.id);
            }
            else throw new Exception("Невозможно сравнить 2 объекта");
        }
    }
}
