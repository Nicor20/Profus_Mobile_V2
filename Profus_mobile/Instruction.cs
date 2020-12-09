using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Profus_mobile
{
    [Activity(Label = "Instruction", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Instruction : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Instruction);
            // Create your application here

            FindViewById<Button>(Resource.Id.buttonDemarer).Click += Demarer;
        }

        private void Demarer(object sender, EventArgs e)
        {
            if(Variables.Play_With_Bluetooth == true)
            {
                Bluetooth_Manager.Write(1);
                Thread.Sleep(150);
                int reponse = Bluetooth_Manager.Read();
                if ( reponse == 1 || reponse == 2)
                {
                    StartActivity(new Intent(this, typeof(interface_questions)));
                    this.Finish();
                }
                else
                {
                    Toast.MakeText(Application.Context, "Allo", ToastLength.Long);
                }
            }
            else
            {
                StartActivity(new Intent(this, typeof(interface_questions)));
                this.Finish();
            }
        }
    }
}