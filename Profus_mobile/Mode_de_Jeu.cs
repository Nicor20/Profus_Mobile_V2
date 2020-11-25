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
using static Android.App.ActionBar;

namespace Profus_mobile
{

    [Activity(Label = "Mode de Jeu", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Mode_de_Jeu : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.Mode_de_Jeu);
            FindViewById<Button>(Resource.Id.button_Mort).Click += this.Mode_Mort;
            FindViewById<Button>(Resource.Id.button_Montre).Click += this.Mode_Montre;
            FindViewById<Button>(Resource.Id.button_Categorie).Click += this.Mode_Categorie;
            FindViewById<Button>(Resource.Id.button_Retour).Click += this.Retour;
        }

        void Mode_Mort(object sender,EventArgs e)
        {
            Variables.Mode_Jeu = "Mort";
            StartActivity(new Intent(this, typeof(Montrer_Carte)));
        }

        void Mode_Montre(object sender, EventArgs e)
        {
            Variables.Mode_Jeu = "Montre";
            StartActivity(new Intent(this, typeof(Montrer_Carte)));
        }

        void Mode_Categorie(object sender, EventArgs e)
        {
            Variables.Mode_Jeu = "Categorie";
            StartActivity(new Intent(this, typeof(Montrer_Carte)));
        }

        void Retour(object sender, EventArgs e)
        {
            this.Finish();
        }

    }
}