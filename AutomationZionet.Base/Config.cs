using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationZionet.Base
{
    public interface IConfig
    {
        Dictionary<string, string> Params { get; }
    }

    public class ConfigParams : IConfig
    {
        public string this[string  i]
        {
            get { return Params[i]; }
            set { Params[i] = value; }
        }

        Dictionary<string, string>  _Params = new Dictionary<string, string>();
        public virtual Dictionary<string, string> Params
        {
            get { return _Params; }
        }


        public void Save()
        {

        }

        public void Load()
        {

        }
    }


}
