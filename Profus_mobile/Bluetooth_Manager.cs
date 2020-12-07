using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace Profus_mobile
{
    //https://forums.xamarin.com/discussion/61763/bluetooth-inputstream-not-read-all-byte-sometime
    class Bluetooth_Manager
    {
        public static BluetoothConnection myConnection;
        public static BluetoothSocket _socket;

        public static void Start_Bluetooth()
        {
            _socket = null;
        }

        public static bool Connect()
        {
            myConnection = new BluetoothConnection();
            myConnection.thisSocket = null;
            _socket = null;

            myConnection.getAdapter();
            myConnection.thisAdapter.StartDiscovery();

            try
            {
                myConnection.getDevice();
                myConnection.thisDevice.SetPairingConfirmation(false);
                myConnection.thisDevice.SetPairingConfirmation(true);
                myConnection.thisDevice.CreateBond();
            }
            catch (Exception deviceEX)
            {
                Android.Util.Log.Info("Conection", deviceEX.ToString());
            }

            myConnection.thisAdapter.CancelDiscovery();
            _socket = myConnection.thisDevice.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
            myConnection.thisSocket = _socket;

            try
            {
                myConnection.thisSocket.Connect();
                return true;
            }
            catch (Exception CloseEX)
            {
                Android.Util.Log.Info("Close_EX", CloseEX.ToString());
                return false;
            }
        }

        public static void Disconnect()
        {
            try
            {
                myConnection.thisDevice.Dispose();

                myConnection.thisSocket.OutputStream.WriteByte(187);
                myConnection.thisSocket.OutputStream.Close();

                myConnection.thisSocket.Close();

                myConnection = new BluetoothConnection();
                _socket = null;
            }
            catch { }
        }

        public static void Write(byte text)
        {
            try
            {
                _socket.OutputStream.WriteByte(text);
                _socket.OutputStream.Flush();
            }
            catch (Exception outPutEX)
            {
                Android.Util.Log.Info("Out_Put_EX", outPutEX.ToString());
            }
        }

        public static int Read()
        {
            byte[] rbuffer = new byte[200];
            byte[] RetArray = new byte[] { };
            int reponse = 0;

            while(reponse == 0)
            {

                try
                {
                    if (_socket.InputStream.IsDataAvailable() == true && _socket.InputStream.CanRead == true)
                    {
                        int readByte = _socket.InputStream.Read(rbuffer, 0, rbuffer.Length);

                        RetArray = new byte[readByte];
                        Array.Copy(rbuffer.ToArray(), 0, RetArray, 0, readByte);
                        for (int i = 0; i < RetArray.Length; i++)
                        {
                            if (RetArray[i] == 49)
                            {
                                reponse = 1;
                            }
                            else if (RetArray[i] == 50)
                            {
                                reponse = 2;
                            }
                        }
                    }
                    else
                    {
                        reponse = 0;
                    }
                }
                catch
                {
                    reponse = 0;
                }
                Log.Info("Lecture Bluetooth", reponse.ToString());
            }
            return reponse;





/*
            try
            {
                if(_socket.InputStream.IsDataAvailable() == true && _socket.InputStream.CanRead == true)
                {
                    int readByte = _socket.InputStream.Read(rbuffer, 0, rbuffer.Length);

                    RetArray = new byte[readByte];
                    Array.Copy(rbuffer.ToArray(), 0, RetArray, 0, readByte);
                    for(int i = 0;i<RetArray.Length;i++)
                    {
                        if (RetArray[i] == 49)
                        {
                            return 1;
                        }
                        else if (RetArray[i] == 50)
                        {
                            return 2;
                        }
                    }
                }
                
                while(_socket.InputStream.IsDataAvailable() != true)
                {

                }

                
                while (!_socket.InputStream.CanRead || !_socket.InputStream.IsDataAvailable())
                {
                    //Console.WriteLine("------------------------------------------------");
                }
                
                //return int.Parse(_socket.InputStream.ReadByte().ToString());
                
                int readByte = _socket.InputStream.Read(rbuffer, 0, rbuffer.Length);

                RetArray = new byte[readByte];
                Array.Copy(rbuffer.ToArray(), 0, RetArray, 0, readByte);

                if(RetArray.Contains<byte>(49) == true)
                {
                    return 1;
                }
                else if (RetArray.Contains<byte>(50) == true)
                {
                    return 2;
                }
                 
            }
            catch
            {

            }
            return 0;
*/

        }

        public static string Array2Text(byte[] sBuffer)
        {
            string sOut = "";
            int i = 0;
            while(Convert.ToChar(sBuffer[i]).ToString() != "$")
            {
                if(Convert.ToChar(sBuffer[i]).ToString() == "1")
                {

                }
                else
                {

                }
                sOut += "test";
                i++;
            }

            return sOut;
        }

    }




    public class BluetoothConnection
    {

        public void getAdapter()
        {
            this.thisAdapter = BluetoothAdapter.DefaultAdapter;
        }
        public void getDevice()
        {
            this.thisDevice = (from bd in this.thisAdapter.BondedDevices where bd.Name == "DSD TECH HC-05" select bd).FirstOrDefault();
        }

        public BluetoothAdapter thisAdapter { get; set; }
        public BluetoothDevice thisDevice { get; set; }
        public BluetoothSocket thisSocket { get; set; }
    }
}