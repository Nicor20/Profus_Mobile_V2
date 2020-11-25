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
    [Activity(Label = "Recap_Game")]
    public class Recap_Game : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Recap_Game);
            // Create your application here
            FindViewById<Button>(Resource.Id.button_Fermer).Click += this.Fermer;
            FindViewById<TextView>(Resource.Id.textView1).Text = "";
            foreach (var item in Variables.Recap_Game)
            {
                FindViewById<TextView>(Resource.Id.textView1).Text += item + "\n";
            }
        }

        private void Fermer(object sender, System.EventArgs e)
        {
            this.Finish();
        }
    }
}