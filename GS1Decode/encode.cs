using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GS1Decode
{
    public class GS1EncodeEngine
    {
        //Maps the AI to the corresponding data from the barcode.
        List<Response> output = new List<Response>();

        /// <summary>
        /// The raw view of the data in the string
        /// </summary>
        public List<Response> Data
        {
            get
            {
                return output;
            }
        }

        public class Response
        {
            public string encData { get; set; }
            public object error { get; set; }
        }

        
        public GS1EncodeEngine(dynamic data, char fnc1)
        {
            ParseData(data, fnc1);
        }
        
        public void ParseData(dynamic data, char fnc1)
        {
            AI info;
            output.Clear();
            List<String> encList = new List<String>();
            Dictionary<string, string> errList = new Dictionary<string, string>();
            Response res = new Response();
            foreach (var d in data)
            {
                string str = "";
                string value = d.Value.ToString();
                try
                {
                    if (!AI.AIMaster.TryGetValue(d.Name, out info))
                    {
                        throw new Exception("Not a valid AI[" + d.Name + "] ");
                    }
                    var match = Regex.Match(info.ai + d.Value, info.regex, RegexOptions.IgnoreCase);
                    if (!match.Success)
                    {
                        throw new Exception("Validation Error AI[" + d.Name + "]"+ value + " - "+ info.description);
                    }
                    if (d.Name == "02") {

                        int ldigit = (int) (Convert.ToInt64(value) % 10);
                        if (GetCheckDigit(value.Substring(0, value.Length - 1)) != ldigit)
                        {
                            throw new Exception("Invalid Check Digit AI[" + d.Name + "]"+ value);
                        }
                    }                    
                    str = (info.fnc1=="1")? d.Name + d.Value + fnc1 : d.Name + d.Value;
                    encList.Add(str);
                }
                catch(Exception e)
                {
                    errList.Add(d.Name, e.Message);
                    continue;
                }

            }
            if (errList.Count == 0)
            {
                res.encData = String.Join("", encList.ToArray()); 
            }
            else
            {
                res.error = errList;
            }
            output.Add(res);

        }

        public static int GetCheckDigit(string code)
        {
            var sum = code.Reverse().Select((c, i) => (int)char.GetNumericValue(c) * (i % 2 == 0 ? 3 : 1)).Sum();
            return (10 - sum % 10) % 10;
        }


    }
}
