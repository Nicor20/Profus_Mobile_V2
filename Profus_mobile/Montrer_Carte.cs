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

            FindViewById<TextView>(Resource.Id.textView_NbJoueur).Text = Variables.Nb_Joueur + (Variables.Nb_Joueur > 1 ? " Joueurs" : " Joueur");

            
            if(Variables.Mode_Jeu == "Categorie")
            {
                FindViewById<TextView>(Resource.Id.textView_Mode).Text = "Mode : Par catégorie";
                FindViewById<Spinner>(Resource.Id.spinnerCarte).Enabled = true;
                Setup_Spinner_Categorie(FindViewById<Spinner>(Resource.Id.spinnerCarte));
            }
            else if(Variables.Mode_Jeu == "Montre")
            {
                FindViewById<TextView>(Resource.Id.textView_Mode).Text = "Mode : Contre la montre";
                FindViewById<Spinner>(Resource.Id.spinnerCarte).Enabled = true;
                Setup_Spinner_Montre(FindViewById<Spinner>(Resource.Id.spinnerCarte));
            }
            else
            {
                FindViewById<TextView>(Resource.Id.textView_Mode).Text = "Mode : Jusqu'a la mort";
                FindViewById<Spinner>(Resource.Id.spinnerCarte).Enabled = false;
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
            this.Finish();
        }

        void Setup_Spinner_Categorie(Spinner spin)
        {
            List<string> list = new List<string>();
            list.Add("Corps Humain");
            list.Add("Littérature et Expressions");
            list.Add("Sport et Culture");
            list.Add("Astronomie");
            list.Add("Science et Technologie");
            list.Add("Faune et Flore");
            list.Add("Histoire et Géographie");
            list.Add("Pseudosciences");
            list.Add("Divers");

            spin.Prompt = "Choisir la catégorie";
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, list);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spin.Adapter = adapter;
        }
        void Setup_Spinner_Montre(Spinner spin)
        {
            List<string> list = new List<string>();
            list.Add("30 secondes");
            list.Add("45 secondes");
            list.Add("60 secondes");

            spin.Prompt = "Choisir le temps de jeu";
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, list);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spin.Adapter = adapter;
        }
    }
}