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
        public static int numero = 1;
        TextView question;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.interface_questions);

            //Exemple d'appel pour l'affichage selon le numero
            question = FindViewById<TextView>(Resource.Id.textView1);
            question.Text = DB_Manager.Read_Question_Number(numero);

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
            numero++;
            Task.Delay(2500).Wait();
            question.Text = DB_Manager.Read_Question_Number(numero);
        }

        private void Echec()
        {   
            numero++;
            Task.Delay(2500).Wait();
            question.Text = DB_Manager.Read_Question_Number(numero);
        }
    }
}