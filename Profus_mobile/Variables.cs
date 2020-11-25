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

namespace Profus_mobile
{
    class Variables
    {
        public static int Nb_Joueur;
        public static string Mode_Jeu;
        public static string Categorie;
        public static List<int> Joueurs = new List<int>();
        public static int timer;

        public static List<string> List_Question_Categorie = new List<string>();
        public static List<string> List_All_Question = new List<string>();
        public static List<string> Recap_Game = new List<string>();
    }
}