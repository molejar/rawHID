using System;
using System.ComponentModel;


namespace rawhid
{
    public class UInt16HexTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) { return true; }
            else { return base.CanConvertFrom(context, sourceType); }
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string)) { return true; }
            else { return base.CanConvertTo(context, destinationType); }
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value.GetType() == typeof(int)) {
                return string.Format("{0:X4}", value);
            } else {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string)) {
                string input = (string)value;
                try
                {
                    return (int) ushort.Parse(input, System.Globalization.NumberStyles.HexNumber, culture);
                }
                catch
                {
                    return -1;
                }
            } else {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }

    [Serializable]
    public class AppSettings
    {
        // default values
        private const bool dMultiCmd      = false;
        private const int  dCmdDelay = 1000;
        private const bool dUsbAutoCon    = false;
        private const int  dUsbVid        = 0x1F00;
        private const int  dUsbPid        = 0x2012;

        // Private variables
        private bool  m_multiCmd;
        private int   m_multiCmdDelay;
        private bool  m_usbAutoCon;
        private int   m_usbVid;
        private int   m_usbPid;

        internal AppSettings()
        {
            LoadDefault();
        }

        [Category("Common"),
        DisplayName("Multiple Commands"),
        Description("Support multiple commands with the same shortcut keys"),
        DefaultValue(dMultiCmd)]
        public bool CMD_Multiple
        {
            get { return m_multiCmd;  }
            set { m_multiCmd = value; }
        }

        [Category("Common"),
        DisplayName("Delay After Command"),
        Description("The time delay after command in milisecounds."),
        DefaultValue(dCmdDelay)]
        public int CMD_Delay
        {
            get { return m_multiCmdDelay;  }
            set { m_multiCmdDelay = value; }
        }


        [Category("USB"),
        DisplayName("Vendor ID"),
        Description("The vendor specific ID in HEX format."),
        TypeConverter(typeof(UInt16HexTypeConverter)),
        DefaultValue(dUsbVid)]
        public int USB_VID
        {
            get { return m_usbVid; }
            set {
                if (value >= 0 && value <= 0xFFFF) {
                    m_usbVid = value;
                }
            }
        }

        [Category("USB"),
        DisplayName("Product ID"),
        Description("The product specific ID in HEX format."),
        TypeConverter(typeof(UInt16HexTypeConverter)),
        DefaultValue(dUsbPid)]
        public int USB_PID
        {
            get { return m_usbPid; }
            set {
                if (value >= 0 && value <= 0xFFFF) {
                    m_usbPid = value;
                }
            }
        }

        [Category("USB"),
        DisplayName("Auto Connect"),
        Description("Automatic connection of USB if present. From multiple devices the first will be selected."),
        DefaultValue(dUsbAutoCon)]
        public bool USB_AutoConnect
        {
            get { return m_usbAutoCon; }
            set { m_usbAutoCon = value; }
        }

        public void LoadDefault()
        {
            m_multiCmdDelay = dCmdDelay;
            m_usbAutoCon    = dUsbAutoCon;
            m_usbVid        = dUsbVid;
            m_usbPid        = dUsbPid;
        }

        public AppSettings DeepCopy() {
            return (AppSettings)MemberwiseClone();
        }
    }
}
