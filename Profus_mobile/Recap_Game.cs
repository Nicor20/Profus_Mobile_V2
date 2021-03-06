﻿using System;
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
    [Activity(Label = "Recap_Game", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Recap_Game : Activity
    {
        TextView Affichage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Recap_Game);
            // Create your application here
            FindViewById<Button>(Resource.Id.button_Menu).Click += this.Menu;
            FindViewById<Button>(Resource.Id.button_Rejouer).Click += this.Rejouer;

            foreach (var player in Variables.List_Joueur)
            {
                DB_Manager.Update_User(player.Numero, player.Prenom, player.Nom, player.Age, player.Reussi, player.Echec, player.Max_Mort);
            }

            Affichage = FindViewById<TextView>(Resource.Id.textView1);
            Affichage.Text = "";

            if(Variables.Mode_Jeu == "Mort")
            {
                Affichage.Text = Variables.List_Joueur[0].Prenom + " " + Variables.List_Joueur[0].Nom + "\nNombre de bonne réponse : " + Variables.List_Joueur[0].Max_Mort;
            }
            else
            {
                int i = 1;
                foreach(var player in Variables.List_Joueur)
                {
                    Affichage.Text += "J" + i + " - " + player.Prenom + " " + player.Nom + "\n";
                    Affichage.Text += "Nombre réussi = " + player.Reussi + "\n";
                    Affichage.Text += "Nombre échoué = " + player.Echec + "\n";
                    i++;
                }
                Affichage.Text += "\n";
                Affichage.Text += "Résumé des questions\n";
                Affichage.Text += "\n";
                foreach (var item in Variables.Recap_Game)
                {
                    Affichage.Text += item + "\n";
                }
            }
        }

        private void Rejouer(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Instruction)));
            Finish();
        }

        private void Menu(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTask);
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.AddFlags(ActivityFlags.NewTask);
            Bluetooth_Manager.Disconnect();
            Variables.Bluetooth_Connected = false;


            StartActivity(intent);
            Finish();
        }
    }
}