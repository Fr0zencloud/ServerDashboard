using System;
using System.Collections.Generic;
using System.Text;

namespace DashboardHelper
{
    class JSON
    {
        private String jsonstring;
        private Dictionary<String, String> jsonlist = new Dictionary<String, String>();

        public JSON()
        {
            this.jsonstring = "";
        }
        public void addArgument(String key, String value)
        {
            if (!jsonlist.ContainsKey(key))
            {
                jsonlist.Add(key, value);
            }
        }
        public void removeArgument(String key)
        {
            if (jsonlist.ContainsKey(key))
            {
                jsonlist.Remove(key);
            }
        }
        public void resetJson()
        {
            this.jsonlist.Clear();
        }
        public String build()
        {
            try
            {
                String prefix = "{";
                String suffix = "}";
                String endstring = prefix;
                int i = 0;
                foreach (String key in jsonlist.Keys)
                {
                    String value;
                    jsonlist.TryGetValue(key, out value);

                    if (i != (jsonlist.Count - 1))
                    {
                        if (value != null && value.Equals("true", StringComparison.InvariantCultureIgnoreCase) || value.Equals("false", StringComparison.InvariantCultureIgnoreCase))
                        {
                            endstring = endstring + "\"" + key + "\": " + value + ", \n";
                        }
                        else
                        {
                            endstring = endstring + "\"" + key + "\": \"" + value + "\", \n";
                        }
                    }
                    else
                    {
                        if (value != null && value.Equals("true", StringComparison.InvariantCultureIgnoreCase) || value.Equals("false", StringComparison.InvariantCultureIgnoreCase))
                        {
                            endstring = endstring + "\"" + key + "\": " + value + "";
                        }
                        else
                        {
                            endstring = endstring + "\"" + key + "\": \"" + value + "\"";
                        }
                    }
                    i++;
                }
                endstring = endstring + suffix;
                return endstring;
            }
            catch (Exception e)
            {
                return "{\n\"error\": true\n}";
            }
        }
    }
}
