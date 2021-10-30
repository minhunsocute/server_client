using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class resultInstance
    {
        private static resultInstance _instance;
        public static resultInstance Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new resultInstance();
                return _instance;
            }
        }
        private resultInstance() { }
        string built_string(int i,string check)
        {
            string result = "";
            while(check[i]!='|' && check[i] != '*')
            {
                result += check[i]; 
                i++;
            }
            i++;
            return result;
        }
        public List<result> load(int i,string check_stirng)
        {
            //string check_stirng = Client.data_ofTable;
            List<result> table = new List<result>();
            while (i < check_stirng.Length)
            {
                /*int id = int.Parse(built_string(i, check_stirng));
                string name = built_string(i,check_stirng);
                int cn = int.Parse(built_string(i, check_stirng));
                int ddt = int.Parse(built_string(i, check_stirng));
                int hp = int.Parse(built_string(i, check_stirng)); 
                int tv = int.Parse(built_string(i, check_stirng));
                result p = new result(id, name, cn, ddt, hp, tv);
                table.Add(p);
                i++;*/
                string result = "";
                while (check_stirng[i] != '|' && check_stirng[i] != '*')
                {
                    result += check_stirng[i];
                    i++;
                }
                int id = int.Parse(result);
                i++;
                result = "";
                while (check_stirng[i] != '|' && check_stirng[i] != '*')
                {
                    result += check_stirng[i];
                    i++;
                }
                string name = result;
                i++;
                result = "";
                while (check_stirng[i] != '|' && check_stirng[i] != '*')
                {
                    result += check_stirng[i];
                    i++;
                }
                int cn = int.Parse(result);
                i++;
                result = "";
                while (check_stirng[i] != '|' && check_stirng[i] != '*')
                {
                    result += check_stirng[i];
                    i++;
                }
                int ddt = int.Parse(result);
                i++;
                result = "";
                while (check_stirng[i] != '|' && check_stirng[i] != '*')
                {
                    result += check_stirng[i];
                    i++;
                }
                int hp = int.Parse(result);
                i++;
                result = "";
                while (check_stirng[i] != '|' && check_stirng[i] != '*')
                {
                    result += check_stirng[i];
                    i++;
                }
                int tv = int.Parse(result);
                i++;
                result p = new result(id, name, cn, ddt, hp, tv);
                table.Add(p);
            }
            return table;
        }
    }
}
