using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blowing.MoveHouse.Common
{
   public  class Md5Helper
    {
        /// <summary>
        /// 获取MD5得值，转换成BASE64
        /// </summary>
        /// <param name="Sourcein"></param>
        /// <returns></returns>
        public static string MD5(string Sourcein)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] MD5Source = System.Text.Encoding.UTF8.GetBytes(Sourcein);
            byte[] MD5Out = MD5CSP.ComputeHash(MD5Source);

            return Convert.ToBase64String(MD5Out);
        }
        /// <summary>
        /// 获取MD5得值，没有转换成Base64的
        /// </summary>
        /// <param name="sDataIn">需要加密的字符串</param>
        /// <param name="move">偏移量</param>
        /// <returns>sDataIn加密后的字符串</returns>
        public string GetMD5(string sDataIn, string move)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] byt, bytHash;
            byt = System.Text.Encoding.UTF8.GetBytes(move + sDataIn);
            bytHash = md5.ComputeHash(byt);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("x").PadLeft(2, '0');
            }
            return sTemp;
        }
    }
}
