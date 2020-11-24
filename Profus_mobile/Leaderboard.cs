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
    [Activity(Label = "Leaderboard")]
    public class Leaderboard : Activity
    {
        TextView score;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Leaderboard);
            score = FindViewById<TextView>(Resource.Id.textViewScore);
            score.Text = "Prenom        | Nom             | Age  | Réussi | Échoué | Résultat\n";
            score.Text += "----------------------------------------------------------------------\n";
            Display_Score();
            FindViewById<Button>(Resource.Id.buttonRetour).Click += this.Retour;





            // Create your application here
        }

        void Retour(object sender, System.EventArgs e)
        {
            this.Finish();
        }

        void Display_Score()
        {
            var db = new SQLiteConnection(DB_Manager.dbPath);
            var table = db.Table<Users>();
            foreach (var item in table)
            {
                string resultat;
                if(item.Reussi != 0 && item.Echec == 0)
                {
                    resultat = "100%";
                }
                else if(item.Reussi == 0 && item.Echec != 0)
                {
                    resultat = "0%";
                }
                else if(item.Reussi != 0 && item.Echec != 0)
                {
                    resultat = ((item.Reussi / (item.Reussi + item.Echec)) * 100.0) + "%";
                }
                else
                {
                    resultat = "0%";
                }
                score.Text +="\n" + String.Format("{0,-15} | {1,-15} | {2,-5} | {3,-11} | {4,-11} | {5,-7}",item.Prenom,item.Nom,item.Age,item.Reussi,item.Echec,resultat);
            }
        }

    }
}