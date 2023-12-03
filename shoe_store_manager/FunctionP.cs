using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoe_store_manager
{
    internal class FunctionP
    {
        public static void chuanHoaChuoi(ref string chuoi)
        {
            string resultName = "";

            // loại bỏ khoảng trắng giữa hai đầu 
            chuoi = chuoi.Trim();


            // loại bỏ khoảng trắng thừa giừa các từ, chuyển thành 1 khoảng trắng
            while(chuoi.IndexOf("  ") != -1)
            {
                chuoi = chuoi.Replace("  ", " ");
            }

            // sao chép các kí tự của chuỗi vào một mảng 
            string[] arrayName = chuoi.Split(' ');

            // duyệt các phần tử trong mảng, chuyển ký tự đầu tiên mỗi từ thành viết hoa
            for(int i = 0; i < arrayName.Length; i++)
            {
                arrayName[i] = arrayName[i].Substring(0, 1).ToUpper() + arrayName[i].Substring(1).ToLower();
                resultName += arrayName[i].ToString() + " ";
            }

            chuoi = resultName;
        }
    }
}



