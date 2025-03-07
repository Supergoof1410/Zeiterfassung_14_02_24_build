﻿using System;
using System.Net;
using System.Net.Sockets;

namespace Arbeitszeiterfassung_TN.TimeManager
{
    static internal class GetTimeActual
    {
        internal static DateTime GetTime()
        {
            // Check the internet connectivity
            var result = CheckInternetConnection.CheckConnection();
            DateTime timeNow;

            if (result == null)
            {
                timeNow = GetActualTimeOffline();
            }
            else
            {
                timeNow = GetNetworkTime();
            }
            return timeNow;
            //return new DateTime(2024, 11, 6, 8, 37, 25);
        }

        // Get the local computer time
        #region Lokale Zeit
        private static DateTime GetActualTimeOffline()
        {
            DateTime localTimeZone = DateTime.UtcNow;

            TimeZoneInfo systemTimeZone = TimeZoneInfo.Local;

            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(localTimeZone, systemTimeZone);

            return localDateTime;
        }
        #endregion

        // Get the NTP-Time from a NTP-Server
        #region Internetzeit
        private static DateTime GetNetworkTime()
        {
            // Default ntp-server
            const string ntpServer = "ptbtime1.ptb.de";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            byte[] ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
        #endregion
    }
}
