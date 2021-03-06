/******************************************************************************
The MIT License (MIT)

Copyright (c) 2016 Matchbox Mobile Limited <info@matchboxmobile.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*******************************************************************************/

// This file was generated by Bluetooth (R) Developer Studio on 2016.03.17 21:39
// with plugin Windows 10 UWP Client (version 1.0.0 released on 2016.03.16).
// Plugin developed by Matchbox Mobile Limited.

using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;

namespace com.matchboxmobile.ble.wrappers
{
    public class HeartRateMeasurementParser : BleValueParser<short, short>
    {
        /// <summary>
        /// Parsing input bytes according to official Bluetooth specification:
        /// https://developer.bluetooth.org/gatt/characteristics/Pages/CharacteristicViewer.aspx?u=org.bluetooth.characteristic.heart_rate_measurement.xml
        /// </summary>
        /// <param name="raw">input buffer with raw bytes of the value</param>
        /// <returns></returns>
        protected override short ParseReadValue(IBuffer raw)
        {
            if (raw == null || raw.Length == 0)
                return -1;

            var reader = new BinaryReader(raw.AsStream());
            short value = 0;
            byte flag = reader.ReadByte();

            if (IsBitSet(flag, 0))
            {
                // UINT16 format
                reader.ReadByte(); // omit this, as it is not used in 16 bit format
                value = (short)reader.ReadUInt16();
            }
            else
            {
                // UINT8 format
                value = (short)reader.ReadByte();
            }

            return value;
        }

        protected override IBuffer ParseWriteValue(short data)
        {
            throw new NotImplementedException();
        }
    }
}
