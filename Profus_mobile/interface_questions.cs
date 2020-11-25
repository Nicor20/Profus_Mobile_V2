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
    [Activity(Label = "interface_questions", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class interface_questions : Activity
    {
        public static int Reponse;
        public int numero = 1;
        TextView View_Info_Joueur;
        TextView View_Info_Question;
        TextView View_Question;
        public int joueur = 0;

        public int nbQuestion;
        public List<int> exclude = new List<int>();

        protected override void OnDestroy()
        {
            base.OnDestroy();








        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.interface_questions);
            Variables.Recap_Game.Clear();
            //Exemple d'appel pour l'affichage selon le numero
            View_Info_Joueur = FindViewById<TextView>(Resource.Id.textViewInfo_Joueur);
            View_Info_Question = FindViewById<TextView>(Resource.Id.textViewInfo_Question);
            View_Question = FindViewById<TextView>(Resource.Id.textView_Question);



            FindViewById<Button>(Resource.Id.buttonA).Click += this.ReponseA;
            FindViewById<Button>(Resource.Id.buttonB).Click += this.ReponseB;
            FindViewById<Button>(Resource.Id.buttonC).Click += this.ReponseC;
            FindViewById<Button>(Resource.Id.buttonD).Click += this.ReponseD;
            FindViewById<Button>(Resource.Id.button_Retour).Click += this.Retour;

            if(Variables.Mode_Jeu =="Categorie")
            {
                nbQuestion= Variables.List_Question_Categorie.Count();
            }
            else
            {
                nbQuestion = Variables.List_All_Question.Count();
            }

            affichage_question();
        }

        private void Retour(object sender, System.EventArgs e)
        {
            this.Finish();
        }
        private void ReponseA(object sender, System.EventArgs e)
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
        private void ReponseB(object sender, System.EventArgs e)
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
        private void ReponseC(object sender, System.EventArgs e)
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
        private void ReponseD(object sender, System.EventArgs e)
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

        private void Reussi()
        {
            DB_Manager.Update_User(Variables.Joueurs[joueur], true);
            Variables.Recap_Game.Add("Question #" + numero + " : Réussi");
            //Thread.Sleep(1000);

            if (numero < nbQuestion)
            {
                Next_Question();
            }
            else
            {
                this.Finish();
                StartActivity(new Intent(this, typeof(Recap_Game)));
            }
        }
        private void Echec()
        {
            DB_Manager.Update_User(Variables.Joueurs[joueur], false);
            Variables.Recap_Game.Add("Question #" + numero + " : Échoué");
            //Thread.Sleep(1000);

            if (Variables.Mode_Jeu == "Mort")
            {
                this.Finish();
                StartActivity(new Intent(this, typeof(Recap_Game)));
            }
            else if (numero < nbQuestion)
            {
                Next_Question();
            }
            else
            {
                this.Finish();
                StartActivity(new Intent(this, typeof(Recap_Game)));
            }
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
            

            affichage_question();
            
        }

        private void affichage_question()
        {
            View_Info_Joueur.Text = "#" + (joueur + 1) + " " + DB_Manager.Read_User_Info_By_Number(Variables.Joueurs[joueur]);
            if(Variables.Mode_Jeu == "Categorie")
            {
                View_Info_Question.Text = "Question " + numero + "/" +nbQuestion +" Catégorie : " + Variables.Categorie;
            }
            else
            {
                View_Info_Question.Text = "Question " + numero + "/" + nbQuestion;
            }
            string[] question = Choix_Question().Split("-|-|-");
            Reponse = int.Parse(question[0]);
            View_Question.Text = question[1];
        }


        private string Choix_Question()
        {
            var range = Enumerable.Range(0, nbQuestion).Where(i => !exclude.Contains(i));
            int numero = range.ElementAt(new System.Random().Next(0, nbQuestion - exclude.Count));
            exclude.Add(numero);

            if(Variables.Mode_Jeu == "Categorie")
            {
                return Variables.List_Question_Categorie[numero];
            }
            else
            {
                return Variables.List_All_Question[numero];
            }
        }




    }
}