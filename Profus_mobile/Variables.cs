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
using SQLite;

namespace Profus_mobile
{
    class Game_Player
    {
        public int Numero { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public int Reussi { get; set; }
        public int Echec { get; set; }
        public int Max_Mort { get; set; }

        public Game_Player(int numero, string prenom, string nom, int age, int reussi, int echec, int max_mort)
        {
            Numero = numero;
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Reussi = reussi;
            Echec = echec;
            Max_Mort = max_mort;
        }

        public Game_Player()
        {

        }


        public override string ToString()
        {
            return Prenom + " " + Nom + " " + (Reussi / (Reussi + Echec)) * 100 + "%";
        }

    }

    class Game_Question
    {
        public string Niveau { get; set; }
        public string Categorie { get; set; }
        public string Question { get; set; }
        public int Num_Reponse { get; set; }
        public string Reponse1 { get; set; }
        public string Reponse2 { get; set; }
        public string Reponse3 { get; set; }
        public string Reponse4 { get; set; }

        public Game_Question(string niveau, string categorie, string question, int num_reponse, string reponse1, string reponse2, string reponse3, string reponse4)
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
        public Game_Question()
        {

        }

        public override string ToString()
        {
            return Categorie + "\nQuestion :\n\t" + Question + "\n\nA) " + Reponse1 + "\nB) " + Reponse2 + "\nC) " + Reponse3 + "\nD) " + Reponse4;
        }
    }
    class Variables
    {
        public static int NbJoueur;
        public static string Mode_Jeu;
        public static bool Play_With_Bluetooth = true;
        public static List<Game_Player> List_Joueur = new List<Game_Player>();
        public static List<Game_Question> List_Question= new List<Game_Question>();
        public static List<string> List_Niveau = new List<string>();
        public static List<string> List_Categorie = new List<string>();
        public static List<string> Recap_Game = new List<string>();

        public static bool Bluetooth_Connected = false;
        public static List<int> Joueurs = new List<int>();
    }
}