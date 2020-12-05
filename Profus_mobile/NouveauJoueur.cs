using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Profus_mobile
{
    [Activity(Label = "NouveauJoueur", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class NouveauJoueur : Activity
    {
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
            FindViewById<Button>(Resource.Id.boutonRetour).Click += this.Retour;
            prenom = FindViewById<TextView>(Resource.Id.editTextPreNom);
            prenom.TextChanged += this.Text_Prenom;
            nom = FindViewById<TextView>(Resource.Id.editTextNom);
            nom.TextChanged += this.Text_Nom;
            age = FindViewById<TextView>(Resource.Id.editTextAge);
            age.TextChanged += this.Text_Age;


        }

        void Text_Prenom(object sender, System.EventArgs e)
        {

        }

        void Text_Nom(object sender, System.EventArgs e)
        {

        }

        void Text_Age(object sender, System.EventArgs e)
        {
            /*
            if(int.Parse(age.Text) > 122)
            {
                age.SetBackgroundColor(Android.Graphics.Color.Red);
            }
            else
            {
                age.SetBackgroundColor(Android.Graphics.Color.White);
            }
            */
        }

        void Retour(object sender, System.EventArgs e)
        {
            this.Finish();
        }

        void Inscription(object sender, System.EventArgs e)
        {
            if(prenom.Text.Length > 0 && nom.Text.Length > 0 && age.Text.Length>0)
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
            else
            {
                Toast.MakeText(this, "Veillez remplir tout les zone", ToastLength.Long);
            }
            
        }

    }
}