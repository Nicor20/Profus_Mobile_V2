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
using System.Timers;
using static Android.App.ActionBar;

namespace Profus_mobile
{
    [Activity(Label = "interface_questions", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class interface_questions : Activity
    {

        //https://forums.xamarin.com/discussion/172326/how-to-make-a-bluetooth-connection-classic-bluetooth-crash-on-connect
        //https://stackoverflow.com/questions/17300744/how-to-implement-countdowntimer-class-in-xamarin-c-sharp-android/17301154

        private int Num_Reponse;
        private int Num_Question = 0;
        private int Num_Joueur = 0;
        public int Num_Question_List;

        private int NbQuestion;
        private int NbJoueur;

        TextView View_Info_Joueur;
        TextView View_Info_Question;
        TextView View_Question;

        public List<int> exclude = new List<int>();
        Dialog pop;
        System.Timers.Timer time;
        bool finGame = false;

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

            FindViewById<Button>(Resource.Id.buttonA).Click += Bouton_A;
            FindViewById<Button>(Resource.Id.buttonB).Click += Bouton_B;
            FindViewById<Button>(Resource.Id.buttonC).Click += Bouton_C;
            FindViewById<Button>(Resource.Id.buttonD).Click += Bouton_D;
            FindViewById<Button>(Resource.Id.button_Retour).Click += Retour;
            FindViewById<Button>(Resource.Id.button_Terminer).Click += Terminer;

            NbQuestion = Variables.List_Question.Count();
            NbJoueur = Variables.List_Joueur.Count();

            Choisir_Question();
            Afficher_Question();
        }

        private void Terminer(object sender, EventArgs e)
        {
            Fin_Partie();
        }

        private void Retour(object sender, EventArgs e)
        {
            Finish();
        }
        private void Bouton_A(object sender, EventArgs e)
        {
            if (Num_Reponse == 1)
            {
                Reponse_bon_faux(true,1);
            }
            else
            {
                Reponse_bon_faux(false,1);
            }
        }
        private void Bouton_B(object sender, EventArgs e)
        {
            if (Num_Reponse == 2)
            {
                Reponse_bon_faux(true,2);
            }
            else
            {
                Reponse_bon_faux(false,2);
            }
        }
        private void Bouton_C(object sender, EventArgs e)
        {
            if (Num_Reponse == 3)
            {
                Reponse_bon_faux(true,3);
            }
            else
            {
                Reponse_bon_faux(false,3);
            }
        }
        private void Bouton_D(object sender, EventArgs e)
        {
            if (Num_Reponse == 4)
            {
                Reponse_bon_faux(true,4);
            }
            else
            {
                Reponse_bon_faux(false,4);
            }
        }

        private void Reponse_bon_faux(bool rep,int bouton)
        {
            Recap_Game(rep,bouton);
            if (Variables.Mode_Jeu == "Mort")
            {
                if(rep == true && Num_Question < NbQuestion)
                {
                    Variables.List_Joueur[Num_Joueur].Max_Mort++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                }
                else
                {
                    Fin_Partie();
                }
            }
            else
            {
                if(rep == true && Num_Question < NbQuestion)
                {
                    Variables.List_Joueur[Num_Joueur].Reussi++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                    Popup("Bonne réponse!");
                }
                else if(rep == false && Num_Question < NbQuestion)
                {
                    Variables.List_Joueur[Num_Joueur].Echec++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                    Popup("Mauvaise réponse!");
                }
                else
                {
                    finGame = true;
                }
            }
        }

        private void Changer_Joueur()
        {
            if (Num_Joueur < NbJoueur-1)
            {
                Num_Joueur++;
            }
            else
            {
                Num_Joueur = 0;
            }
        }

        private void Choisir_Question()
        {
            Num_Question++;
            var range = Enumerable.Range(0, NbQuestion).Where(i => !exclude.Contains(i));
            Num_Question_List = range.ElementAt(new Random().Next(0, NbQuestion - exclude.Count()));
            exclude.Add(Num_Question_List);
            Num_Reponse = Variables.List_Question[Num_Question_List].Num_Reponse;
        }

        private void Afficher_Question()
        {
            View_Info_Joueur.Text = "J" + (Num_Joueur + 1) + " - " + Variables.List_Joueur[Num_Joueur].Prenom + " " + Variables.List_Joueur[Num_Joueur].Nom + " (" + Variables.List_Joueur[Num_Joueur].Age + ")";
            View_Info_Question.Text = "Question " + Num_Question + "/" + NbQuestion + " (" + Variables.List_Question[Num_Question_List].Categorie + ")";
            View_Question.Text = "Niveau : " + Variables.List_Question[Num_Question_List].Niveau + "\n";
            View_Question.Text += "Question : " + Variables.List_Question[Num_Question_List].Question + "\n";
            View_Question.Text += "\n";
            View_Question.Text += "A) " + Variables.List_Question[Num_Question_List].Reponse1 + "\n";
            View_Question.Text += "B) " + Variables.List_Question[Num_Question_List].Reponse2 + "\n";
            View_Question.Text += "C) " + Variables.List_Question[Num_Question_List].Reponse3 + "\n";
            View_Question.Text += "D) " + Variables.List_Question[Num_Question_List].Reponse4 + "\n";
        }

        private string Rep_At_Pos(int pos,int question)
        {
            if(pos == 1)
            {
                return Variables.List_Question[question].Reponse1;
            }
            else if(pos == 2)
            {
                return Variables.List_Question[question].Reponse2;
            }
            else if(pos == 3)
            {
                return Variables.List_Question[question].Reponse3;
            }
            else
            {
                return Variables.List_Question[question].Reponse4;
            }
        }

        private void Recap_Game(bool rep,int button)
        {
            string text = "Question #" + Num_Question + " = " + (rep==true? "Réussi" : "Échoué" ) + "\n";
            text += Variables.List_Question[Num_Question_List].Question + "\n";
            text += "Réponse choisi : " + Rep_At_Pos(button, Num_Question_List) + "\n";
            text += "Bonne réponse : " + Rep_At_Pos(Num_Reponse, Num_Question_List) + "\n";

            Variables.Recap_Game.Add(text);
        }


        private void Fin_Partie()
        {
            foreach(var player in Variables.List_Joueur)
            {
                DB_Manager.Update_User(player.Numero, player.Reussi, player.Echec, player.Max_Mort);
            }
            Finish();
            StartActivity(new Intent(this, typeof(Recap_Game)));
        }

        private void Popup(string Resultat)
        {
            pop = new Dialog(this);
            pop.SetContentView(Resource.Layout.Popup);
            pop.Window.SetSoftInputMode(SoftInput.AdjustResize);
            pop.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            pop.Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);
            pop.FindViewById<TextView>(Resource.Id.textViewResultat).Text = Resultat;
            pop.Show();
            time = new System.Timers.Timer(2000);
            time.Elapsed += ClosePopup;
            time.AutoReset = false;
            time.Enabled = true;

        }

        public void ClosePopup(Object source, ElapsedEventArgs e)
        {   
            if(finGame == true)
            {
                Fin_Partie();
            }
            time.Stop();
            time.Dispose();
            pop.Dismiss();
            pop.Hide();


        }
    }
}