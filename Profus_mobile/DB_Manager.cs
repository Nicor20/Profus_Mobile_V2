using System;
using System.Collections.Generic;
using System.IO;
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
    class Users
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Reussi { get; set; }
        public int Echoue { get; set; }

        public Users(string prenom,string nom,int reussi,int echoue)
        {
            Prenom = prenom;
            Nom = nom;
            Reussi = reussi;
            Echoue = echoue;
        }

        public Users()
        {

        }


        public override string ToString()
        {
            return Prenom + " " + Nom + " " + (Reussi / (Reussi + Echoue)) * 100 + "%";
        }

    }












    class DB_Manager
    {
        public static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Profus_db.db3");

        public static void Create_User(string prenom, string nom)
        {
             var db = new SQLiteConnection(dbPath);

             db.CreateTable<Users>();

             Users New_User = new Users(prenom, nom, 0, 0);

             db.Insert(New_User);
        }

        public static void Read_User()
        {
            var db = new SQLiteConnection(dbPath);

            var table = db.Table<Users>();

            foreach(var item in table)
            {
                Users user = new Users(item.Prenom, item.Nom, item.Reussi, item.Echoue);
            }


        }



    }
}