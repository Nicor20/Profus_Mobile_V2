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

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Setup initial de la fenetre
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.interface_questions);

            //Variables
            Variables.Recap_Game.Clear();
            NbQuestion = Variables.List_Question.Count();
            NbJoueur = Variables.List_Joueur.Count();

            //Exemple d'appel pour l'affichage selon le numero
            View_Info_Joueur = FindViewById<TextView>(Resource.Id.textViewInfo_Joueur);
            View_Info_Question = FindViewById<TextView>(Resource.Id.textViewInfo_Question);
            View_Question = FindViewById<TextView>(Resource.Id.textView_Question);

            //Setup des boutons dans l'écran
            FindViewById<Button>(Resource.Id.buttonA).Click += Bouton_A;
            FindViewById<Button>(Resource.Id.buttonB).Click += Bouton_B;
            FindViewById<Button>(Resource.Id.buttonC).Click += Bouton_C;
            FindViewById<Button>(Resource.Id.buttonD).Click += Bouton_D;
            FindViewById<Button>(Resource.Id.button_Retour).Click += Retour;
            FindViewById<Button>(Resource.Id.button_Terminer).Click += Terminer;

            //Setup de la question
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
            Thread.Sleep(150);
            Bluetooth_Manager.Write(6);
            Reponse_bon_faux(1);
        }
        private void Bouton_B(object sender, EventArgs e)
        {
            Thread.Sleep(150);
            Bluetooth_Manager.Write(7);
            Reponse_bon_faux(2);
        }
        private void Bouton_C(object sender, EventArgs e)
        {
            Thread.Sleep(150);
            Bluetooth_Manager.Write(8);
            Reponse_bon_faux(3);
        }
        private void Bouton_D(object sender, EventArgs e)
        {
            Thread.Sleep(150);
            Bluetooth_Manager.Write(9);
            Reponse_bon_faux(4);
        }


        private void Reponse_bon_faux(int bouton)
        {
            Thread.Sleep(150);

            int reponse = Bluetooth_Manager.Read();

            if (reponse == 1)
            {
                Recap_Game(true, bouton);
                if (Variables.Mode_Jeu == "Mort")
                {
                    Variables.List_Joueur[Num_Joueur].Max_Mort++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                }
                else if (Num_Question < NbQuestion)
                {
                    Variables.List_Joueur[Num_Joueur].Reussi++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                }
                else
                {
                    Variables.List_Joueur[Num_Joueur].Reussi++;
                    Fin_Partie();
                }
            }
            else if(reponse == 2)
            {
                Recap_Game(false, bouton);
                if (Variables.Mode_Jeu == "Mort")
                {
                    Fin_Partie();
                }
                else if (Num_Question < NbQuestion)
                {
                    Variables.List_Joueur[Num_Joueur].Echec++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                }
                else
                {
                    Variables.List_Joueur[Num_Joueur].Echec++;
                    Fin_Partie();
                }
            }



            /*
            if(bouton == Num_Reponse)
            {
                Recap_Game(true, bouton);
                if(Variables.Mode_Jeu == "Mort")
                {
                    Variables.List_Joueur[Num_Joueur].Max_Mort++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                }
                else if(Num_Question < NbQuestion)
                {
                    Variables.List_Joueur[Num_Joueur].Reussi++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                }
                else
                {
                    Variables.List_Joueur[Num_Joueur].Reussi++;
                    Fin_Partie();
                }
            }
            else
            {
                Recap_Game(false, bouton);
                if (Variables.Mode_Jeu == "Mort")
                {
                    Fin_Partie();
                }
                else if(Num_Question < NbQuestion)
                {
                    Variables.List_Joueur[Num_Joueur].Echec++;
                    Changer_Joueur();
                    Choisir_Question();
                    Afficher_Question();
                }
                else
                {
                    Variables.List_Joueur[Num_Joueur].Echec++;
                    Fin_Partie();
                }
            }
            */
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
            Thread.Sleep(150);
            if (Num_Reponse == 1)
            {
                Bluetooth_Manager.Write(2);
            }
            else if(Num_Reponse == 2)
            {
                Bluetooth_Manager.Write(3);
            }
            else if (Num_Reponse == 3)
            {
                Bluetooth_Manager.Write(4);
            }
            else
            {
                Bluetooth_Manager.Write(5);
            }
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
            Finish();
            StartActivity(new Intent(this, typeof(Recap_Game)));
        }

        
    }
}