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
        Spinner Spinner_Carte;
        Spinner Spinner_Joueur;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Montrer_Carte);

            #region Initialisation spinner
            Spinner_Joueur = FindViewById<Spinner>(Resource.Id.spinnerJoueur);
            Spinner_Joueur.Prompt = "Nombre de joueurs?";
            Spinner_Joueur.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Player, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Spinner_Joueur.Adapter = adapter;
            #endregion

            // Create your application here

            if (Variables.Nb_Joueur == 1)
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

            Spinner_Carte = FindViewById<Spinner>(Resource.Id.spinnerCarte);
            
            if(Variables.Mode_Jeu == "Categorie")
            {
                FindViewById<TextView>(Resource.Id.textView_Mode).Text = "Mode : Par catégorie";
                Spinner_Carte.Enabled = true;
                Setup_Spinner_Categorie(Spinner_Carte);
            }
            else if(Variables.Mode_Jeu == "Montre")
            {
                FindViewById<TextView>(Resource.Id.textView_Mode).Text = "Mode : Contre la montre";
                Spinner_Carte.Enabled = true;
                Setup_Spinner_Montre(Spinner_Carte);
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
            if(Variables.Mode_Jeu == "Categorie")
            {
                Variables.List_Question_Categorie = DB_Manager.Create_Categorie_Question(Spinner_Carte.SelectedItem.ToString());
                Variables.Categorie = Spinner_Carte.SelectedItem.ToString();
            }
            else if(Variables.Mode_Jeu == "Montre")
            {
                Variables.List_All_Question = DB_Manager.Create_Question_List();
                string[] list = Spinner_Carte.SelectedItem.ToString().Split(" ");
                if(list[1] == "secondes")
                {
                    Variables.timer = int.Parse(list[0]) * 1000;
                }
                else if(list[1] == "minutes")
                {
                    Variables.timer = int.Parse(list[0]) * 1000 * 60;
                }
            }
            else
            {
                Variables.List_All_Question = DB_Manager.Create_Question_List();
            }
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

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            string[] nombre = Spinner_Joueur.SelectedItem.ToString().Split(" ");
            Variables.Nb_Joueur = int.Parse(nombre[0]);
        }
    }
}