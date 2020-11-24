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
        [PrimaryKey]
        public int Numero { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public int Reussi { get; set; }
        public int Echec { get; set; }

        public Users(int numero,string prenom,string nom,int age,int reussi,int echec)
        {
            Numero = numero;
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Reussi = reussi;
            Echec = echec;
        }

        public Users()
        {

        }


        public override string ToString()
        {
            return Prenom + " " + Nom + " " + (Reussi / (Reussi + Echec)) * 100 + "%";
        }

    }

    class Questions
    {
        public int Numero { get; set; }
        public int Niveau { get; set; }
        public string Categorie { get; set; }
        public string Question { get; set; }
        public int Num_Reponse { get; set; }
        public string Reponse1 { get; set; }
        public string Reponse2 { get; set; }
        public string Reponse3 { get; set; }
        public string Reponse4 { get; set; }

        public Questions(int numero,int niveau,string categorie,string question,int num_reponse,string reponse1,string reponse2,string reponse3,string reponse4)
        {
            Numero = numero;
            Niveau = niveau;
            Categorie = categorie;
            Question = question;
            Num_Reponse = num_reponse;
            Reponse1 = reponse1;
            Reponse2 = reponse2;
            Reponse3 = reponse3;
            Reponse4 = reponse4;
        }

        public Questions()
        {

        }

        public override string ToString()
        {
            return Categorie + "\nQuestion :\n\t" + Question + "\n\nA) " + Reponse1 + "\nB) " + Reponse2 + "\nC) " + Reponse3 + "\nD) " + Reponse4;
        }
    }

    class DB_Manager
    {
        public static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Profus_db.db3");
        public static void Create_Question(int numero, int niveau, string categorie, string question, int num_reponse, string reponse1, string reponse2, string reponse3, string reponse4)
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Questions>();
            Questions New_Question = new Questions(numero, niveau, categorie, question, num_reponse, reponse1, reponse2, reponse3, reponse4);
            db.Insert(New_Question);
        }

        public static string Read_Question_Number(int numero)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Questions>();
            foreach(var item in table)
            {
                if(item.Numero == numero)
                {
                    interface_questions.Reponse = item.Num_Reponse;
                    return "Catégorie : " + item.Categorie +
                           "\nNiveau : " + (item.Niveau<=6?item.Niveau + " année": "Secondaire " + (item.Niveau-6)) +
                           "\nQuestion : " + item.Question + 
                           "\n\nA) " + item.Reponse1 + 
                           "\nB) " + item.Reponse2 + 
                           "\nC) " + item.Reponse3 + 
                           "\nD) " + item.Reponse4;
                }
            }
            return "Erreur question introuvable";
        }

        public static void Create_User(string prenom, string nom,int age)
        {
            int numero = 0;
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Users>();
            if(db.Table<Users>().Count() == 0)
            {
                numero = 1;
            }
            else
            {
                var table = db.Table<Users>();
                foreach (var item in table)
                {
                    numero = item.Numero + 1;
                }
            }
             
            Users New_User = new Users(numero,prenom, nom,age, 0, 0);
            db.Insert(New_User);
        }

        public static void Delete_User(string prenom, string nom,int age)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Users>();
            foreach (var item in table)
            {
                if (item.Prenom == prenom && item.Nom == nom && item.Age == age)
                {
                    Users New_User = new Users(item.Numero, item.Prenom, item.Nom, item.Age, item.Reussi, item.Echec);
                    db.Delete(New_User);
                    break;
                }
            }
        }
        public static void Read_User()
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Users>();

            foreach(var item in table)
            {
               
            }


        }

        public static int Read_User_Name(string text)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Users>();

            foreach (var item in table)
            {
                string value = item.Prenom + " " + item.Nom + " (" + item.Age + ")";
                if (text == value)
                {
                    return item.Numero;
                }
            }
            return 0;
        }

        public static bool Check_User_Exist(string prenom,string nom,int age)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Users>();

            foreach (var item in table)
            {
                if (item.Prenom == prenom && item.Nom == nom && item.Age == age)
                {
                    return true;
                }
            }
            return false;
        }

    }
}