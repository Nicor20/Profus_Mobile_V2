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
    [Activity(Label = "Leaderboard", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Leaderboard : Activity
    {
        TextView prenom;
        TextView nom;
        TextView age;
        TextView reussi;
        TextView echec;
        TextView resultat;
        TextView max_mort;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Leaderboard);
            prenom = FindViewById<TextView>(Resource.Id.textViewPrenom);
            nom = FindViewById<TextView>(Resource.Id.textViewNom);
            age = FindViewById<TextView>(Resource.Id.textViewAge);
            reussi = FindViewById<TextView>(Resource.Id.textViewReussi);
            echec = FindViewById<TextView>(Resource.Id.textViewEchec);
            resultat = FindViewById<TextView>(Resource.Id.textViewResultat);
            max_mort = FindViewById<TextView>(Resource.Id.textViewMax_mort);

            prenom.Text = "Prenom\n";
            nom.Text = "Nom\n";
            age.Text = "Age\n";
            reussi.Text = "Réussi\n";
            echec.Text = "Échoué\n";
            resultat.Text = "Résultat\n";
            max_mort.Text = "Max Mort\n";
            Display_Score();
            FindViewById<Button>(Resource.Id.buttonRetour).Click += this.Retour;
        }

        void Retour(object sender, System.EventArgs e)
        {
            Finish();
        }

        void Display_Score()
        {
            var db = new SQLiteConnection(DB_Manager.dbPath);
            var table = db.Table<Users>();
            foreach (var item in table)
            {
                string pourcentage;
                if(item.Reussi != 0 && item.Echec == 0)
                {
                    pourcentage = "100.00%";
                }
                else if(item.Reussi == 0 && item.Echec == 0)
                {
                    pourcentage = "NaN";
                }
                else
                {
                    pourcentage = (((float)item.Reussi / ((float)item.Reussi + (float)item.Echec)) * 100.0).ToString("0.00") + "%";
                }

                prenom.Text += "\n" + item.Prenom;
                nom.Text += "\n" + item.Nom;
                age.Text += "\n" + item.Age;
                reussi.Text += "\n" + item.Reussi;
                echec.Text += "\n" + item.Echec;
                resultat.Text += "\n" + pourcentage;
                max_mort.Text += "\n" + item.Max_Mort.ToString();
            }
        }
    }
}