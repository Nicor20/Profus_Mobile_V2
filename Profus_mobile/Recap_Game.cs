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
    [Activity(Label = "Recap_Game", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Recap_Game : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Recap_Game);
            // Create your application here
            FindViewById<Button>(Resource.Id.button_Menu).Click += this.Menu;
            FindViewById<Button>(Resource.Id.button_Rejouer).Click += this.Rejouer;





            FindViewById<TextView>(Resource.Id.textView1).Text = "";
            foreach (var item in Variables.Recap_Game)
            {
                FindViewById<TextView>(Resource.Id.textView1).Text += item + "\n";
            }
        }

        private void Rejouer(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(interface_questions)));
            Finish();
        }

        private void Menu(object sender, System.EventArgs e)
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