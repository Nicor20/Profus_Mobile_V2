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
    [Activity(Label = "Info", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Info : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Info);

            FindViewById<Button>(Resource.Id.buttonRetour).Click += Retour;



            // Create your application here
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