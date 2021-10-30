using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace client
{
    public class result
    {
        public result(int id,string name,int cn,int ddt,int hp,int tv)
        {
            this.iD = id;
            this.name = name;
            this.cn = cn;
            this.ddt = ddt;
            this.hp = hp;
            this.tv = tv;
        }
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int Cn { get => cn; set => cn = value; }
        public int Ddt { get => ddt; set => ddt = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Tv { get => tv; set => tv = value; }
        private int iD;
        private string name;
        private int cn;
        private int ddt;
        private int hp;
        private int tv;
    }
}
