using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbLibrary;

namespace rawhid
{
    [Serializable]
    public class Command
    {
        public string Name  { get; set; }
        public string Desc  { get; set; }
        public Keys   Key   { get; set; }
        public int    RType { get; set; }
        public byte   RID   { get; set; }
        public byte[] RData { get; set; }

        internal Command()
        {
            Name = "";
            Desc = "";
            Key = Keys.None;
            RType = 0;
            RID = 0;
            RData = null;
        }

        internal Command(string name, string desc, Keys key, byte[] rdata=null, byte rid=0, int rtype = 0)
        {
            Name = name;
            Desc = desc;
            Key  = key;
            RType = rtype;
            RID   = rid;
            RData = rdata;
        }

        public HIDReport GetHidReport()
        {
            return new HIDReport(RID, RData);
        }

        public string GetDataAsStr()
        {
            string sd = "";

            foreach (byte a in RData) {
                sd += String.Format("{0:X2} ", a);
            }
            return sd;
        }

        public bool SetData(string val)
        {
            try
            {
                var slist = val.Split(' ');
                for (int i = 0; i < slist.Length; i++)
                {
                    if (RData == null)
                    {
                        RData = new byte[64];
                    }
                    if (i < RData.Length)
                    {
                        RData[i] = Convert.ToByte(slist[i], 16);
                    }
                }

                return true;
            } catch {
                RData = new byte[64];
                MessageBox.Show("DATA: "+val, "Data Error");
                return false;
            }
        }

        public string GetShortKeyAsStr()
        {
            string sk = "";
            var kcon = new KeysConverter();
            return kcon.ConvertToString(Key);
        }

        public void SetShortKey(string val)
        {
            var keys = val;
            keys = keys.Replace("+", ",");
            keys = keys.Replace("Ctrl", "Control");
            keys = keys.Replace("Esc", "Escape");
            Key = (Keys)Enum.Parse(typeof(Keys), keys);
        }

        public string GetTypeAsStr()
        {
            string rval;

            if (RType == 0)
            {
                rval = string.Format("S:{0:d}", RID);
            } else {
                rval = string.Format("F:{0:d}", RID);
            }

            return rval;
        }
    }
}
