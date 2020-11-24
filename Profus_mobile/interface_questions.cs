using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Profus_mobile
{
    [Activity(Label = "interface_questions")]
    public class interface_questions : Activity
    {
        public static int Reponse;
        public int numero = 1;
        TextView View_Info_Joueur;
        TextView View_Info_Question;
        TextView View_Question;
        public int joueur = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.interface_questions);

            //Exemple d'appel pour l'affichage selon le numero
            View_Info_Joueur = FindViewById<TextView>(Resource.Id.textViewInfo_Joueur);
            View_Info_Question = FindViewById<TextView>(Resource.Id.textViewInfo_Question);
            View_Question = FindViewById<TextView>(Resource.Id.textView_Question);

            View_Info_Joueur.Text = "#" + (joueur + 1) + " " + DB_Manager.Read_User_Info_By_Number(Variables.Joueurs[joueur]);
            View_Info_Question.Text = "Question " + numero + " " + DB_Manager.Read_Question_Info_By_Number(numero);
            View_Question.Text = DB_Manager.Read_Question_By_Number(numero);

            FindViewById<Button>(Resource.Id.buttonA).Click += this.ReponseA;
            FindViewById<Button>(Resource.Id.buttonB).Click += this.ReponseB;
            FindViewById<Button>(Resource.Id.buttonC).Click += this.ReponseC;
            FindViewById<Button>(Resource.Id.buttonD).Click += this.ReponseD;
        }


        void ReponseA(object sender, System.EventArgs e)
        {
            if(Reponse == 1)
            {
                Reussi();
            }
            else
            {
                Echec();
            }

        }
        void ReponseB(object sender, System.EventArgs e)
        {
            if (Reponse == 2)
            {
                Reussi();
            }
            else
            {
                Echec();
            }
        }
        void ReponseC(object sender, System.EventArgs e)
        {
            if (Reponse == 3)
            {
                Reussi();
            }
            else
            {
                Echec();
            }
        }
        void ReponseD(object sender, System.EventArgs e)
        {
            if (Reponse == 4)
            {
                Reussi();
            }
            else
            {
                Echec();
            }
        }

        public void Reussi()
        {
            DB_Manager.Update_User(Variables.Joueurs[joueur], true);
            Next_Question();
        }
        private void Echec()
        {
            DB_Manager.Update_User(Variables.Joueurs[joueur], false);
            Next_Question();
        }
        private void Next_Question()
        {
            if (joueur < Variables.Nb_Joueur-1)
            {
                joueur++;
            }
            else
            {
                joueur = 0;
            }
            numero++;
            Task.Delay(2500).Wait();
            View_Info_Joueur.Text = "#" + (joueur + 1) + " " + DB_Manager.Read_User_Info_By_Number(Variables.Joueurs[joueur]);
            View_Info_Question.Text = "Question " + numero + " " + DB_Manager.Read_Question_Info_By_Number(numero);
            View_Question.Text = DB_Manager.Read_Question_By_Number(numero);
        }
    }
}