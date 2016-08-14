using System;
using System.Collections.Generic;
using System.IO;

namespace mmp
{
    public class Ini
    {
        string mypath;
        Dictionary<string, Dictionary<string, string>> items;

        public Ini(string path)
        {
            mypath = path;
            Clear();

            if (!path.Equals("") && File.Exists(path))
            {
                string current = "";
                StreamReader r = File.OpenText(path);
                try
                {
                    string l;
                    while ((l = r.ReadLine()) != null)
                    {
                        l = l.Trim();
                        if (l.StartsWith("[") && l.EndsWith("]"))
                        {
                            current = l = l.Substring(1, l.Length - 2).Trim();
                            if (!l.Equals(""))
                            {
                                if (!items.ContainsKey(l))
                                    items[l] = new Dictionary<string, string>();
                            }
                        }
                        else
                        {
                            try
                            {
                                int e = l.IndexOf("=");
                                string name = l.Substring(0, e).Trim();
                                string value = l.Substring(e + 1).Trim();
                                if (!name.Equals(""))
                                    items[current][name] = value;
                            }
                            catch (System.Exception)
                            { }
                            finally
                            { }
                        }
                    }
                }
                finally
                {
                    r.Close();
                }
            }
        }

        ~Ini()
        {
            Close();
        }

        public void Clear()
        {
            items = new Dictionary<string, Dictionary<string, string>>();
            items[""] = new Dictionary<string, string>();
        }

        public void Close()
        {
            if (!mypath.Equals(""))
            {
                StreamWriter w = File.CreateText(mypath);
                try
                {
                    foreach (KeyValuePair<string, Dictionary<string, string>> s in items)
                    {
                        if (s.Value.Count > 0)
                        {
                            w.WriteLine("[" + s.Key + "]");
                            foreach (KeyValuePair<string, string> i in s.Value)
                            {
                                w.WriteLine(i.Key + " = " + i.Value);
                            }
                        }
                    }
                }
                finally
                {
                    w.Close();
                }
            }
            mypath = "";
        }

        private Dictionary<string, string> sect(string name)
        {
            if (!items.ContainsKey(name))
                items[name] = new Dictionary<string, string>();
            return items[name];
        }

        public string Read(string section, string name, string def)
        {
            Dictionary<string, string> s = sect(section);
            if (s.ContainsKey(name))
                return s[name];
            return def;
        }

        public float Read(string section, string name, float def)
        {
            try
            {
                return Convert.ToSingle(Read(section, name, def.ToString()));
            }
            catch (System.Exception)
            {
                return def;
            }
        }

        public int Read(string section, string name, int def)
        {
            try
            {
                return Convert.ToInt32(Read(section, name, def.ToString()));
            }
            catch (System.Exception)
            {
                return def;
            }
        }

        public void Write(string section, string name, string value)
        {
            Dictionary<string, string> s = sect(section);
            s[name] = value;
        }
    }
}
