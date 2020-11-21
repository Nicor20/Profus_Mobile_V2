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
    [Activity(Label = "Inscription", NoHistory = true)]
    public class Inscription : Activity
    {
        #region spinners
        Spinner spinnerJ1;
        Spinner spinnerJ2;
        Spinner spinnerJ3;
        Spinner spinnerJ4;
        Spinner spinnerJ5;
        Spinner spinnerJ6;
        Spinner spinnerJ7;
        Spinner spinnerJ8;
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Inscription);

            // Create your application here
            FindViewById<Button>(Resource.Id.BoutonRetourCarte).Click += this.RetourVersModeDeJeu;
            FindViewById<Button>(Resource.Id.buttonJouer).Click += this.JouerAuJeu;
            #region Initalisation des spinners
            spinnerJ1 = FindViewById<Spinner>(Resource.Id.spinnerJ1);
            spinnerJ1.Prompt = "Choisissez votre nom ->";
            spinnerJ2 = FindViewById<Spinner>(Resource.Id.spinnerJ2);
            spinnerJ2.Prompt = "Choisissez votre nom ->";
            spinnerJ3 = FindViewById<Spinner>(Resource.Id.spinnerJ3);
            spinnerJ3.Prompt = "Choisissez votre nom ->";
            spinnerJ4 = FindViewById<Spinner>(Resource.Id.spinnerJ4);
            spinnerJ4.Prompt = "Choisissez votre nom ->";
            spinnerJ5 = FindViewById<Spinner>(Resource.Id.spinnerJ5);
            spinnerJ5.Prompt = "Choisissez votre nom ->";
            spinnerJ6 = FindViewById<Spinner>(Resource.Id.spinnerJ6);
            spinnerJ6.Prompt = "Choisissez votre nom ->";
            spinnerJ7 = FindViewById<Spinner>(Resource.Id.spinnerJ7);
            spinnerJ7.Prompt = "Choisissez votre nom ->";
            spinnerJ8 = FindViewById<Spinner>(Resource.Id.spinnerJ8);
            spinnerJ8.Prompt = "Choisissez votre nom ->";
            #endregion
        }

        void RetourVersModeDeJeu (object sender, System.EventArgs e)
        {
           //TODO activity result pour retourner à l'activité précédente avec les mêmme choix qu'avant (mode de jeu  temporaire)
            StartActivity(new Intent(this, typeof(Mode_de_Jeu)));
        }

        void JouerAuJeu(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(interface_questions)));
        }
    }
}