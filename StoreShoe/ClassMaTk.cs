using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoe_store_manager
{
    public static class GlobalVariables
    {
        public static string MaTK { get; set; }
    }

    public class ClassMaTk
    {
        public ClassMaTk()
        {
        }

        public ClassMaTk(string maTK)
        {
            GlobalVariables.MaTK = maTK;
        }
    }
}
