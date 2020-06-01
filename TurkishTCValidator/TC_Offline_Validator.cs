using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkishTCValidator
{
    public class TC_Offline_Validator
    {
        private static TC_Offline_Validator _shared;

        public static TC_Offline_Validator GetInstance()
        {
            if (_shared == null)
                _shared = new TC_Offline_Validator();
            return _shared;
        }
        public TC_Offline_Validator()
        {
        }
        /// <summary>
        /// this will check ID number offlie
        /// </summary>
        /// <param name="TC"></param>
        /// <returns></returns>
        public bool Validate(long TC)
        {
            string tc = TC.ToString();
            if (tc.Length != 11) return false;
            var d11 = int.Parse(tc[10].ToString());
            var d10 = int.Parse(tc[9].ToString());
            var d9 = int.Parse(tc[8].ToString());
            var d8 = int.Parse(tc[7].ToString());
            var d7 = int.Parse(tc[6].ToString());
            var d6 = int.Parse(tc[5].ToString());
            var d5 = int.Parse(tc[4].ToString());
            var d4 = int.Parse(tc[3].ToString());
            var d3 = int.Parse(tc[2].ToString());
            var d2 = int.Parse(tc[1].ToString());
            var d1 = int.Parse(tc[0].ToString());
            if (((((d1 + d3 + d5 + d7 + d9) * 7) - (d2 + d4 + d6 + d8)) % 10) != d10) return false;
            return (d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10) % 10 == d11;
        }

    }
}
