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
    [Activity(Label = "Montrer_Carte")]
    public class Montrer_Carte : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Montrer_Carte);

            // Create your application here

            if(Variables.Nb_Joueur == 1)
            {
                //Image 1
            }
            else if(Variables.Nb_Joueur == 2)
            {
                //Image 2
            }
            else if (Variables.Nb_Joueur == 3)
            {
                //Image 3
            }
            else if (Variables.Nb_Joueur == 4)
            {
                //Image 4
            }
            else if (Variables.Nb_Joueur == 5)
            {
                //Image 5
            }
            else if (Variables.Nb_Joueur == 6)
            {
                //Image 6
            }
            else if (Variables.Nb_Joueur == 7)
            {
                //Image 7
            }
            else
            {
                //Image 8
            }

            FindViewById<Button>(Resource.Id.Bouton_Suivant).Click += this.Suivant;
            FindViewById<Button>(Resource.Id.Bouton_Retour).Click += this.Retour;
        }

        void Suivant(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Inscription)));
        }

        void Retour(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Mode_de_Jeu)));
        }

    }
}