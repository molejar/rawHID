using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsbLibrary
{
    public class HIDReport : EventArgs
    {
        public readonly byte   ID;
        public readonly byte[] Data;

        /// <summary>
        /// HIDReport Constructor
        /// </summary>
        public HIDReport(byte id, byte[] data)
        {
            ID = id;
            Data = data;
        }

        /// <summary>
        /// HIDReport Constructor
        /// </summary>
        public HIDReport(byte[] rawData)
        {
            ID = rawData[0];
            Data = new byte[rawData.Length - 1];
            Array.Copy(rawData, 1, Data, 0, Data.Length);
        }

        public int Length
        {
            get { return Data.Length + 1; }
        }

        /// <summary>
        /// Report as Array
        /// </summary>
        public byte[] ToArray()
        {

            byte[] buffer = null;

            if (Data.Length > 0)
            {
                buffer = new byte[Data.Length + 1];
                buffer[0] = ID;
                Array.Copy(Data, 0, buffer, 1, Data.Length);
            }

            return buffer;
        }
    }


    public delegate void DataRecievedEventHandler(object sender, HIDReport args);
    public delegate void DataSendEventHandler(object sender, HIDReport args);
}
