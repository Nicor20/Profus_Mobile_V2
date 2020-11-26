using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
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
        //https://forums.xamarin.com/discussion/172326/how-to-make-a-bluetooth-connection-classic-bluetooth-crash-on-connect
        //https://stackoverflow.com/questions/17300744/how-to-implement-countdowntimer-class-in-xamarin-c-sharp-android/17301154

        public static int Reponse;
        public int numero = 1;
        TextView View_Info_Joueur;
        TextView View_Info_Question;
        TextView View_Question;
        public int joueur = 0;

        public int nbQuestion;
        public List<int> exclude = new List<int>();
        public List<int> Pos_reponse = new List<int>();

        public int[] pos = new int[4];

        public int Num_Question_List;
        public int bouton_click;


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

            FindViewById<Button>(Resource.Id.buttonA).Click += this.Bouton_A;
            FindViewById<Button>(Resource.Id.buttonB).Click += this.Bouton_B;
            FindViewById<Button>(Resource.Id.buttonC).Click += this.Bouton_C;
            FindViewById<Button>(Resource.Id.buttonD).Click += this.Bouton_D;
            FindViewById<Button>(Resource.Id.button_Retour).Click += this.Retour;

            nbQuestion = Variables.Question_List.Count();

            affichage_question();
        }

        private void Retour(object sender, System.EventArgs e)
        {
            this.Finish();
        }
        private void Bouton_A(object sender, System.EventArgs e)
        {
            bouton_click = 1;
            if (Reponse == 1)
            {
                Reponse_bon_faux(true);
            }
            else
            {
                Reponse_bon_faux(false);
            }
        }
        private void Bouton_B(object sender, System.EventArgs e)
        {
            bouton_click = 2;
            if (Reponse == 2)
            {
                Reponse_bon_faux(true);
            }
            else
            {
                Reponse_bon_faux(false);
            }
        }
        private void Bouton_C(object sender, System.EventArgs e)
        {
            bouton_click = 3;
            if (Reponse == 3)
            {
                Reponse_bon_faux(true);
            }
            else
            {
                Reponse_bon_faux(false);
            }
        }
        private void Bouton_D(object sender, System.EventArgs e)
        {
            bouton_click = 4;
            if (Reponse == 4)
            {
                Reponse_bon_faux(true);
            }
            else
            {
                Reponse_bon_faux(false);
            }
        }


        private void Reponse_bon_faux(bool rep)
        {
            if(rep == true)
            {
                Variables.Game_Player[joueur].Reussi++;
            }
            else
            {
                Variables.Game_Player[joueur].Echec++;
            }
            Recap_Game(rep);

            if(rep == false && Variables.Mode_Jeu == "Mort")
            {
                this.Finish();
                StartActivity(new Intent(this, typeof(Recap_Game)));
            }
            else if(numero < nbQuestion)
            {
                Next_Question();
            }
            else
            {
                this.Finish();
                StartActivity(new Intent(this, typeof(Recap_Game)));
            }
            //byte t = Convert.to;
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
            View_Info_Joueur.Text = "J" + (joueur + 1) + " - " + Variables.Game_Player[joueur].Prenom + " " + Variables.Game_Player[joueur].Nom + " (" + Variables.Game_Player[joueur].Age + ")";
            Num_Question_List = Choix_Question();

            View_Info_Question.Text = "Question " + numero + "/" + nbQuestion + " (" + Variables.Question_List[Num_Question_List].Categorie + ")";
            Reponse = Variables.Question_List[Num_Question_List].Num_Reponse;



            View_Question.Text = "Niveau : " + Variables.Question_List[Num_Question_List].Niveau + "\n";
            View_Question.Text += "Question : " + Variables.Question_List[Num_Question_List].Question + "\n";
            View_Question.Text += "\n";
            View_Question.Text += "A) " + Rep_At_Pos(1, Num_Question_List) + "\n";
            View_Question.Text += "B) " + Rep_At_Pos(2, Num_Question_List) + "\n";
            View_Question.Text += "C) " + Rep_At_Pos(3, Num_Question_List) + "\n";
            View_Question.Text += "D) " + Rep_At_Pos(4, Num_Question_List) + "\n";

            /*
            Choix_Pos_Reponse();
            Reponse = Pos_reponse[Variables.Question_List[Num_Question_List].Num_Reponse - 1];
            Log.Info("réponse", "Réponse était  " + Variables.Question_List[Num_Question_List].Num_Reponse + " Maintenant " + Reponse);

            View_Question.Text = "Niveau : " + Variables.Question_List[Num_Question_List].Niveau + "\n";
            View_Question.Text += "Question : " + Variables.Question_List[Num_Question_List].Question + "\n";
            View_Question.Text += "\n";
            View_Question.Text += "A) " + Rep_At_Pos(Pos_reponse[0], Num_Question_List) + "\n";
            View_Question.Text += "B) " + Rep_At_Pos(Pos_reponse[1], Num_Question_List) + "\n";
            View_Question.Text += "C) " + Rep_At_Pos(Pos_reponse[2], Num_Question_List) + "\n";
            View_Question.Text += "D) " + Rep_At_Pos(Pos_reponse[3], Num_Question_List) + "\n";
            */
        }

        private int Choix_Question()
        {
            var range = Enumerable.Range(0, nbQuestion).Where(i => !exclude.Contains(i));
            int numero = range.ElementAt(new System.Random().Next(0, nbQuestion - exclude.Count));
            exclude.Add(numero);

            return numero;
        }

        private void Choix_Pos_Reponse()
        {
            List<int> ex = new List<int>();
            Pos_reponse.Clear();

            for(int i = 0;i<4;i++)
            {
                var range = Enumerable.Range(1, 4).Where(i => !ex.Contains(i));
                int numero = range.ElementAt(new System.Random().Next(0, 4 - ex.Count));
                ex.Add(numero);
                Pos_reponse.Add(numero);
                pos[i] = numero;
                Log.Info("Aléatoire", "Question " + (i+1) + " = position " + numero);
            }
        }

        private string Rep_At_Pos(int pos,int question)
        {
            if(pos == 1)
            {
                return Variables.Question_List[question].Reponse1;
            }
            else if(pos == 2)
            {
                return Variables.Question_List[question].Reponse2;
            }
            else if(pos == 3)
            {
                return Variables.Question_List[question].Reponse3;
            }
            else
            {
                return Variables.Question_List[question].Reponse4;
            }
        }

        private void Recap_Game(bool rep)
        {
            string text = "Question #" + numero + " = " + (rep==true? "Réussi" : "Échoué" ) + "\n";
            text += Variables.Question_List[Num_Question_List].Question + "\n";
            text += "Réponse choisi : " + Rep_At_Pos(bouton_click, Num_Question_List) + "\n";
            text += "Bonne réponse : " + Rep_At_Pos(Reponse, Num_Question_List) + "\n";


            /*
            text += "Réponse choisi : " + Rep_At_Pos(Pos_reponse[bouton_click-1], Num_Question_List) + "\n";
            text += "Bonne réponse : " + Rep_At_Pos(Pos_reponse[Reponse-1], Num_Question_List) + "\n";
            */
            Variables.Recap_Game.Add(text);
        }

    }
}