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
using SQLite;

namespace Profus_mobile
{
    [Activity(Label = "Inscription")]
    public class Inscription : Activity
    {
        public int Nb_Inscrit = 0;
        List<Spinner> spinner = new List<Spinner>();
        List<int> Joueur_Inscrit = new List<int>();
        
        Button Bouton_Jouer;




        protected override void OnRestart()
        {
            base.OnRestart();
            Setup_Spinner(spinner[Nb_Inscrit]);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Inscription);

            // Create your application here
            FindViewById<Button>(Resource.Id.BoutonRetourCarte).Click += this.RetourVersModeDeJeu;
            Bouton_Jouer = FindViewById<Button>(Resource.Id.buttonJouer);
            Bouton_Jouer.Click += this.JouerAuJeu;

            #region Initalisation des spinners
            spinner.Clear();
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ1));
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ2));
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ3));
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ4));
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ5));
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ6));
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ7));
            spinner.Add(FindViewById<Spinner>(Resource.Id.spinnerJ8));
            #endregion

            Bouton_Jouer.Enabled = false;
            spinner[0].Enabled = true;
            for (int i = 1; i < 8; i++)
            {
                spinner[i].Enabled = false;
            }
            Setup_Spinner(spinner[0]);
        }

        void RetourVersModeDeJeu (object sender, System.EventArgs e)
        {
           //TODO activity result pour retourner à l'activité précédente avec les mêmme choix qu'avant (mode de jeu  temporaire)
            StartActivity(new Intent(this, typeof(Mode_de_Jeu)));
        }

        void JouerAuJeu(object sender, System.EventArgs e)
        {
            var db = new SQLiteConnection(DB_Manager.dbPath);
            var table = db.Table<Users>();
            Variables.Joueurs.Clear();

            for (int i = 0; i < Variables.Nb_Joueur;i++)
            {
                foreach (var item in table)
                {
                    string text = item.Prenom + " " + item.Nom + " (" + item.Age + ")";
                    if(spinner[i].SelectedItem.ToString() == text)
                    {
                        Variables.Joueurs.Add(item.Numero);
                    }
                }
            }
            StartActivity(new Intent(this, typeof(interface_questions)));
        }


        private void Setup_Spinner(Spinner spin)
        {
            List<String> Joueurs_Disponible = new List<string>();
            Joueurs_Disponible.Add("Choix du Joueur");
            Joueurs_Disponible.Add("Inscription");

            
            spin.Prompt = "Joueur #"+ (Nb_Inscrit+1);
            spin.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            

            var db = new SQLiteConnection(DB_Manager.dbPath);
            var table = db.Table<Users>();

            foreach (var item in table)
            {
                if(Joueur_Inscrit.Contains(item.Numero) != true)
                {
                    Joueurs_Disponible.Add(item.Prenom + " " + item.Nom + " (" + item.Age + ")");
                }
            }

            
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, Joueurs_Disponible);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spin.Adapter = adapter;
        }


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (spinner[Nb_Inscrit].SelectedItem.ToString() == "Choix du Joueur")
            {

            }
            else if (spinner[Nb_Inscrit].SelectedItem.ToString() == "Inscription")
            {
                NouveauJoueur.Provenance = "Inscription";
                StartActivity(new Intent(this, typeof(NouveauJoueur)));
            }
            else
            {
                Nb_Inscrit++;
                
                if(Nb_Inscrit >= Variables.Nb_Joueur)
                {
                    spinner[Nb_Inscrit-1].Enabled = false;
                    Bouton_Jouer.Enabled = true;
                }
                else
                {
                    spinner[Nb_Inscrit - 1].Enabled = false;
                    spinner[Nb_Inscrit].Enabled = true;
                    Joueur_Inscrit.Add(DB_Manager.Read_User_Name(spinner[Nb_Inscrit - 1].SelectedItem.ToString()));
                    Setup_Spinner(spinner[Nb_Inscrit]);
                }
            }
        }
    }
}