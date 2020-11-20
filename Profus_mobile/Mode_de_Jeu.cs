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
using static Android.App.ActionBar;

namespace Profus_mobile
{

    [Activity(Label = "Mode de Jeu", NoHistory = true)]
    public class Mode_de_Jeu : Activity
    {
        public static int Nb_joueur;
        TextView Titre;
        List<String> List_Mode = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.Mode_de_Jeu);

            // Create your application here

            //Chrono
            //Par catégorie
            //Jusqu'a la mort
            //
            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.Linear_Layout_Button_MJ);
            LayoutParams lp = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            if(Nb_joueur == 1)
            {
                List_Mode.Clear();
                List_Mode.Add("Chrono");
                List_Mode.Add("Par Catégorie");
                List_Mode.Add("Jusqu'a la mort");
                List_Mode.Add("Retour");
            }
            else if(Nb_joueur == 2)
            {
                List_Mode.Clear();
                List_Mode.Add("Retour");
            }
            else
            {
                List_Mode.Clear();
                List_Mode.Add("Retour");
            }


            foreach(var list in List_Mode)
            {
                Button button = new Button(this);
                button.Text = list;
                button.Click += new EventHandler(this.Button_Click);
                layout.AddView(button, lp);
            }
        }

        void Button_Click(object sender,EventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Text == "Retour")
            {
                //Quitter
                StartActivity(new Intent(this, typeof(MainActivity)));
            }
            else
            {
                Montrer_Carte.Mode_Jeu = btn.Text;
                Montrer_Carte.NB_joueur = Nb_joueur;
                StartActivity(new Intent(this, typeof(Montrer_Carte)));
            }
            
            







        }
    }
}