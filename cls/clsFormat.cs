using System;
using System.Net;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace WebMaintenance.cls
{
    public class clsFormat : Page

    {
        string strInputParam;
        string strOutputParam;
        int intInputParamLenght = 0;

        public clsFormat()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string stripHTML(string strHTML)
        {
            System.Text.RegularExpressions.Regex objRegEx = new Regex("<[^>]*>");
            strHTML = (String)objRegEx.Replace(strHTML, "");
            return strHTML;

        }
        public string stripSingleQuote(string strHTML)
        {
            System.Text.RegularExpressions.Regex objRegEx = new Regex("<[^>]*>");
            strHTML = (String)strHTML.Replace("'", "''");//"&#39;"
            return strHTML;
        }

        public string replaceOnSingleQuote(string strHTML)
        {
            System.Text.RegularExpressions.Regex objRegEx = new Regex("<[^>]*>");
            strHTML = (String)strHTML.Replace("&#39;", "'");//"&#39;"
            return strHTML;
        }
        //Format Special Characters
        public string FormatingSpecialChars(string strInput)
        {
            string strInputParam = strInput;
            strInputParam = strInputParam.Replace("'", "`");
            strInputParam = strInputParam.Replace("--", "-");
            strInputParam = Server.HtmlEncode(strInputParam);
            strInputParam = strInputParam.Replace("&amp;", "&");
            strInputParam = strInputParam.Replace("&AMP;", "&");
            strInputParam = strInputParam.Replace("\r\n", "<br />");
            return strInputParam;
        }
        //--------------------------------FORMATING INPUT-OUTPUT V 1.0-----------------------------------------------
        #region "FORMATING INPUT-OUTPUT V 1.0"
        //FormatInputString function takes (SizeOfInput as Integer, ValueOfInput as string)
        public string FormatingInputString(int intSizeOfInput, string strValueOfInput)
        {
            strInputParam = strValueOfInput;
            intInputParamLenght = intSizeOfInput;
            if (strValueOfInput != null && intInputParamLenght > 0)
            {
                strInputParam = strInputParam.Trim();
                //strInputParam = strInputParam.Replace("'", "&#39;");
                strInputParam = strInputParam.Replace("'", "`");
                strInputParam = Server.HtmlEncode(strInputParam);
                strInputParam = strInputParam.Replace("&", "&amp;");
                strInputParam = strInputParam.Replace("&", "&AMP;");
                //strInputParam = strInputParam.Replace(Environment.NewLine, "<br/>");
                strInputParam = strInputParam.Replace("<br />", "\r\n");
                //strInputParam = strInputParam.Replace("<br />", "&lt;br /&gt;");

                strInputParam = strInputParam.Substring(0, Math.Min(intInputParamLenght, strInputParam.Length)).ToString();
            }
            else
            {
                strInputParam = null;
            }
            return strInputParam;
        }
        //FormatOutputString function takes (ValueOfOutput as string)
        public string FormatingOutputString(string strValueOfOutput)
        {
            //string varApostrophe = "&#39;";
            string varApostrophe = "`";
            strOutputParam = strValueOfOutput;
            if (strOutputParam.Length > 0)
            {
                strOutputParam = strOutputParam.Trim();
                //-----------------------
                strOutputParam = Server.HtmlDecode(strOutputParam).ToString();
                //-----------------------
                strOutputParam = strOutputParam.Replace(varApostrophe, Server.HtmlDecode(varApostrophe).ToString());
                strOutputParam = strOutputParam.Replace("&amp;", "&");
                strOutputParam = strOutputParam.Replace("&AMP;", "&");
                //strOutputParam = strOutputParam.Replace("<br/>",Environment.NewLine);
                //strOutputParam = strOutputParam.Replace("<br/>", "\r\n");
                strOutputParam = strOutputParam.Replace("&lt;br/&gt;", "<br />");
                strOutputParam = strOutputParam.Replace("&lt;br /&gt;", "<br />");
            }
            else
            {
                strOutputParam = "";
            }
            return strOutputParam;
        }

        #endregion


        //--------------------------------FORMATING INPUT-OUTPUT V 2.0-----------------------------------------------
        #region "FORMATING INPUT-OUTPUT V 2.0"
        //FormatOutputString function takes (ValueOfOutput as string)
        public string FormatingOutputString_HTMLDecode(string strValueOfOutput)
        {
            //string varApostrophe = "&#39;";
            string varApostrophe = "`";
            strOutputParam = strValueOfOutput;
            if (strOutputParam.Length > 0)
            {
                strOutputParam = strOutputParam.Trim();
                strOutputParam = Server.HtmlDecode(strOutputParam).ToString();
                strOutputParam = strOutputParam.Replace(varApostrophe, Server.HtmlDecode(varApostrophe).ToString());
                strOutputParam = strOutputParam.Replace("&amp;", "&");
                strOutputParam = strOutputParam.Replace("&AMP;", "&");
                //strOutputParam = strOutputParam.Replace("<br/>",Environment.NewLine);
                //strOutputParam = strOutputParam.Replace("<br/>", "\r\n");
                strOutputParam = strOutputParam.Replace("&lt;br/&gt;", "<br />");
                strOutputParam = strOutputParam.Replace("&lt;br /&gt;", "<br />");
            }
            else
            {
                strOutputParam = "";
            }
            return strOutputParam;
        }
        #endregion


        public string FormatingOutputString_TextBox(string strValueOfOutput)
        {
            //string varApostrophe = "&#39;";
            string varApostrophe = "`";
            strOutputParam = strValueOfOutput;
            if (strOutputParam.Length > 0)
            {
                strOutputParam = strOutputParam.Trim();
                strOutputParam = strOutputParam.Replace(varApostrophe, Server.HtmlDecode(varApostrophe).ToString());
                strOutputParam = strOutputParam.Replace("&amp;", "&");
                strOutputParam = strOutputParam.Replace("&AMP;", "&");
                //strOutputParam = strOutputParam.Replace("<br/>",Environment.NewLine);
                //strOutputParam = strOutputParam.Replace("<br/>", "\r\n");
                strOutputParam = strOutputParam.Replace("&lt;br/&gt;", "\r\n");
            }
            else
            {
                strOutputParam = "";
            }

            return strOutputParam;
        }

        //---------------MD5 Encrypt-Decrypt------------------------------------
        #region "MD5 INPUT-OUTPUT V 3.0"
        //-----------------------------------------------------------------
        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                //of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray = cTransform.TransformFinalBlock
                    (toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        //--------------MD5 Decrypt----------------------------------------
        public string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            //-----------------------------------------
            //keyArray = UTF8Encoding.UTF8.GetBytes(key);
            //---------------------------
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        public string MD5Encrypt(string valueString)
        {
            string ret = String.Empty;
            //Setup crypto
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //Get bytes
            byte[] data = System.Text.Encoding.ASCII.GetBytes(valueString);
            //Encrypt
            data = md5Hasher.ComputeHash(data);
            //Convert from byte 2 hex
            for (int i = 0; i < data.Length; i++)
            {
                ret += data[i].ToString("x2").ToLower();
            }
            //Return encoded string
            return ret;

        }

        //--------------------------------FORMATING Encrypt-Decrypt V 4.0-----------------------------------------------
        #region "FORMATING INPUT-OUTPUT V 4.0"
        public string Encrypt(string strToEncrypt, string strKey)
        {
            try
            {
                //----------------------------------------
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = strKey;

                byteHash = objHashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = UTF8Encoding.UTF8.GetBytes(strToEncrypt);

                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                //----------------------------------------
                //TripleDESCryptoServiceProvider objDESCrypto =
                //    new TripleDESCryptoServiceProvider();
                //MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                //byte[] byteHash, byteBuff;
                //string strTempKey = strKey;
                //byteHash = objHashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(strTempKey));
                //objHashMD5 = null;
                //objDESCrypto.Key = byteHash;
                //objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                //byteBuff = UTF8Encoding.UTF8.GetBytes(strToEncrypt);
                //return Convert.ToBase64String(objDESCrypto.CreateEncryptor().
                //    TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
            }
        }

        public string Decrypt(string strEncrypted, string strKey)
        {
            //strEncrypted = strEncrypted.Replace(" ", "+");
            //strEncrypted = strEncrypted.Trim();
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = strKey;
                byteHash = objHashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Convert.FromBase64String(strEncrypted);
                string strDecrypted = UTF8Encoding.UTF8.GetString
                (objDESCrypto.CreateDecryptor().TransformFinalBlock
                (byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;
                return strDecrypted;
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
            }
        }

        #endregion
        //--------------------------------FORMATING INPUT-OUTPUT V 5.0-----------------------------------------------
        #region "FORMATING INPUT-OUTPUT V 5.0"
        //FormatInputString function takes (SizeOfInput as Integer, ValueOfInput as string)
        public string FormatingInputString_V5(int intSizeOfInput, string strValueOfInput)
        {
            strInputParam = strValueOfInput;
            intInputParamLenght = intSizeOfInput;
            if (strValueOfInput != null & intInputParamLenght > 0)
            {
                strInputParam = strInputParam.Trim();
                ////strInputParam = strInputParam.Replace("'", "&#39;");
                strInputParam = strInputParam.Replace("'", "`");
                //strInputParam = Server.HtmlEncode(strInputParam);
                //strInputParam = strInputParam.Replace("&amp;", "&");
                //strInputParam = strInputParam.Replace("&AMP;", "&");
                ////strInputParam = strInputParam.Replace(Environment.NewLine, "<br/>");
                strInputParam = strInputParam.Replace("\r\n", "<br/>");
                ////strInputParam = strInputParam.Replace("<br />", "&lt;br /&gt;");

                strInputParam = strInputParam.Substring(0, Math.Min(intInputParamLenght, strInputParam.Length)).ToString();
                strInputParam = Server.UrlEncode(strInputParam);
            }
            else
            {
                strInputParam = null;
            }
            return strInputParam;
        }
        //FormatOutputString function takes (ValueOfOutput as string)
        public string FormatingOutputString_V5(string strValueOfOutput)
        {
            strOutputParam = strValueOfOutput;
            if (strOutputParam.Length > 0)
            {
                strOutputParam = strOutputParam.Trim();
                strOutputParam = Server.UrlDecode(strOutputParam);
                strOutputParam = strOutputParam.Replace("<", "[");
                strOutputParam = strOutputParam.Replace(">", "]");
                strOutputParam = strOutputParam.Replace("\r\n", "<br/>");
                strOutputParam = strOutputParam.Replace("[br/]", "<br/>");
                strOutputParam = strOutputParam.Replace("[br /]", "<br/>");


            }
            else
            {
                strOutputParam = "";
            }
            return strOutputParam;
        }
        public string FormatingOutputString_TextBox_V5(string strValueOfOutput)
        {
            string varApostrophe = "`";
            strOutputParam = strValueOfOutput;
            if (strOutputParam.Length > 0)
            {
                strOutputParam = strOutputParam.Trim();
                strOutputParam = Server.UrlDecode(strOutputParam);
                strOutputParam = strOutputParam.Replace("<", "[");
                strOutputParam = strOutputParam.Replace(">", "]");
                strOutputParam = strOutputParam.Replace("[br/]", "\r\n");
                strOutputParam = strOutputParam.Replace("[br /]", "\r\n");
            }
            else
            {
                strOutputParam = "";
            }

            return strOutputParam;
        }
        #endregion

      
        //------------------------------Formating and Resizing Using HTML Encode/Decode methods-----------------
        public string HTMLEncrDecr_InpOutStr(int intMaxLength, string strContent, bool flEncode)
        {
            if (strContent != "" && strContent != null)
            {
                if (flEncode == true) //Encoding
                {
                    strContent = strContent.Replace("<", "&lt;");
                    strContent = strContent.Replace(">", "&gt;");
                    strContent = Server.HtmlEncode(strContent);
                    int intContentLength = strContent.Length;
                    strContent = strContent.Substring(0, Math.Min(intMaxLength, intContentLength));
                }
                else //Decoding
                {
                    strContent = Server.HtmlDecode(strContent);
                    strContent = strContent.Replace("&lt;", "<");
                    strContent = strContent.Replace("&gt;", ">");
                }

            }
            else
            {
                strContent = "";
            }
            return strContent;
        }
    }
}