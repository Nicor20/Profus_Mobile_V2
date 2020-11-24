using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profus_mobile
{
    [Activity(Label = "NouveauJoueur")]
    public class NouveauJoueur : Activity
    {
        public static string Provenance;
        TextView prenom;
        TextView nom;
        TextView age;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.NouveauJoueur);
            // Create your application here

            FindViewById<Button>(Resource.Id.boutonInscrire).Click += this.Inscription;
            prenom = FindViewById<TextView>(Resource.Id.editTextPreNom);
            nom = FindViewById<TextView>(Resource.Id.editTextNom);
            age = FindViewById<TextView>(Resource.Id.editTextAge);



        }

        void Inscription(object sender, System.EventArgs e)
        {
            if(DB_Manager.Check_User_Exist(prenom.Text,nom.Text,Convert.ToInt32(Math.Floor(Convert.ToDecimal(age.Text)))) == false)
            {
                DB_Manager.Create_User(prenom.Text, nom.Text, Convert.ToInt32(Math.Floor(Convert.ToDecimal(age.Text))));
                this.Finish();
            }
            else
            {
                Toast.MakeText(this, "L'utilisateur existe déja", ToastLength.Long);
            }
        }

    }
}