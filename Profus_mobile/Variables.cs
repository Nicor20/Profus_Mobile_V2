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
    class Player_Game
    {
        public int Numero { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public int Reussi { get; set; }
        public int Echec { get; set; }

        public Player_Game(int numero, string prenom, string nom, int age, int reussi, int echec)
        {
            Numero = numero;
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Reussi = reussi;
            Echec = echec;
        }

        public Player_Game()
        {

        }
    }

    class List_Questions
    {
        public int Niveau { get; set; }
        public string Categorie { get; set; }
        public string Question { get; set; }
        public int Num_Reponse { get; set; }
        public string Reponse1 { get; set; }
        public string Reponse2 { get; set; }
        public string Reponse3 { get; set; }
        public string Reponse4 { get; set; }

        public List_Questions(int niveau, string categorie, string question, int num_reponse, string reponse1, string reponse2, string reponse3, string reponse4)
        {
            Niveau = niveau;
            Categorie = categorie;
            Question = question;
            Num_Reponse = num_reponse;
            Reponse1 = reponse1;
            Reponse2 = reponse2;
            Reponse3 = reponse3;
            Reponse4 = reponse4;
        }

        public List_Questions()
        {

        }
    }


    class Variables
    {
        public static int Nb_Joueur;
        public static string Mode_Jeu;
        public static string Categorie;
        public static List<int> Joueurs = new List<int>();
        public static int timer;

        public static List<Player_Game> Game_Player = new List<Player_Game>();
        public static List<List_Questions> Question_List= new List<List_Questions>();


        //public static List<string> List_Question_Categorie = new List<string>();
        //public static List<string> List_All_Question = new List<string>();
        public static List<string> Recap_Game = new List<string>();
    }
}