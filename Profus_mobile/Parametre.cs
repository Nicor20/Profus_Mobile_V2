using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Profus_mobile
{
    [Activity(Label = "Parametre", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Parametre : Activity
    {
        Button Bluetooth;
        TextView Text;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Parametre);

            Bluetooth = FindViewById<Button>(Resource.Id.buttonBluetooth);
            Bluetooth.Click += bluetooth;
            FindViewById<Button>(Resource.Id.buttonRetour).Click += Retour;
            Text = FindViewById<TextView>(Resource.Id.textView2);
            if(Variables.Play_With_Bluetooth == true)
            {
                Text.Text = "Utilisation du Bluetooth : Activer";
                Bluetooth.Text = "Désactiver le bluetooth";
            }
            else
            {
                Text.Text = "Utilisation du Bluetooth : Désactiver";
                Bluetooth.Text = "Activer le bluetooth";
            }
        }

        void bluetooth(object sender, System.EventArgs e)
        {
            if(Variables.Play_With_Bluetooth == true)
            {
                Variables.Play_With_Bluetooth = false;
                Text.Text = "Utilisation du Bluetooth : Désactiver";
                Bluetooth.Text = "Activer le bluetooth";
            }
            else
            {
                Variables.Play_With_Bluetooth = true;
                Text.Text = "Utilisation du Bluetooth : Activer";
                Bluetooth.Text = "Désactiver le bluetooth";
            }
        }

        void Retour(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTask);
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.AddFlags(ActivityFlags.NewTask);
            StartActivity(intent);
            Finish();
        }



    }
}