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
    [Activity(Label = "Options_Jeu", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Options_Jeu : Activity
    {
        Spinner Spinner_Joueur;
        Spinner Spinner_Niveau;
        Spinner Spinner_Categorie;

        RadioButton Radio_Normal;
        RadioButton Radio_Mort;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Options_Jeu);

            #region Initialisation spinner
            //Joueur
            Spinner_Joueur = FindViewById<Spinner>(Resource.Id.spinnerJoueur);
            Spinner_Joueur.Prompt = "Nombre de joueurs?";
            Spinner_Joueur.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Joueur_Spinner);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Player, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Spinner_Joueur.Adapter = adapter;

            //Niveau
            Spinner_Niveau = FindViewById<Spinner>(Resource.Id.spinnerNiveau);
            Spinner_Niveau.Prompt = "Niveau de scolarité?";
            Spinner_Joueur.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Niveau_Spinner);
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, Variables.List_Niveau);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Spinner_Niveau.Adapter = adapter;

            //Catégorie
            Spinner_Categorie = FindViewById<Spinner>(Resource.Id.spinnerCategorie);
            Spinner_Categorie.Prompt = "Choix de la catégorie";
            #endregion

            Radio_Normal = FindViewById<RadioButton>(Resource.Id.radioButtonNormal);
            Radio_Mort = FindViewById<RadioButton>(Resource.Id.radioButtonMort);
            FindViewById<Button>(Resource.Id.Bouton_Suivant).Click += this.Suivant;
            FindViewById<Button>(Resource.Id.Bouton_Retour).Click += this.Retour;
        }

        private void Joueur_Spinner(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            string[] nombre = Spinner_Joueur.SelectedItem.ToString().Split(" ");
            if (int.Parse(nombre[0]) == 1)
            {
                Radio_Normal.Enabled = true;
                Radio_Mort.Enabled = true;
            }
            else
            {
                Radio_Normal.Enabled = false;
                Radio_Mort.Enabled = false;
            }
        }

        private void Niveau_Spinner(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            DB_Manager.Create_Categorie_List(Spinner_Niveau.SelectedItem.ToString());
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, Variables.List_Categorie);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Spinner_Categorie.Adapter = adapter;
        }

        void Suivant(object sender, EventArgs e)
        {
            string[] split = Spinner_Joueur.SelectedItem.ToString().Split(" ");
            Variables.NbJoueur = int.Parse(split[0]);

            //Envoyer la variable pour le mode
            if (Radio_Normal.Checked == false && int.Parse(split[0]) == 1)
            {
                Variables.Mode_Jeu = "Mort";
                DB_Manager.Create_Question_List(Spinner_Niveau.SelectedItem.ToString(), "Aléatoire");
            }
            else
            {
                Variables.Mode_Jeu = "Normal";
                DB_Manager.Create_Question_List(Spinner_Niveau.SelectedItem.ToString(), Spinner_Categorie.SelectedItem.ToString());
            }

            StartActivity(new Intent(this, typeof(Inscription)));
        }

        void Retour(object sender, System.EventArgs e)
        {
            Finish();
        }
    }
}