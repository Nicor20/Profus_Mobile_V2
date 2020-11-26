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
    class DB_Manager
    {
        public static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Profus_db.db3");

        public static void Start_DB()
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Questions>();
            db.CreateTable<Users>();

            var question = db.Table<Questions>();
            
            if(question.Count() == 0)
            {
                //Create all
                Create_Question(1, "Primaire 6", "Corps Humain", "Quelle partie du corps est affectée si une personne souffre d'un orgelet?", 1, "L'œil", "Le nez", "La bouche", "Les oreilles");
                Create_Question(2, "Primaire 6", "Divers", "Si vous faites face au soleil vers midi, en direction de quel point cardinal regardez-vous?", 2, "Nord", "Sud", "Est", "Ouest");
                Create_Question(3, "Primaire 6", "Littérature et Expressions", "Dans le conte « Le petit prince »   de St-Exupéry, quelle fleur est, paraît-il, unique au monde?", 2, "La marguerite", "La rose", "L'œillet", "La pivoine");
                Create_Question(4, "Primaire 6", "Sport et Culture", "Dans les Pierrafeu, quel est le nom de la femme de Fred Caillou?", 2, "Bertha", "Délima", "Agathe", "Célina");
                Create_Question(5, "Primaire 6", "Astronomie", "Quelle planète est appelée la Planète Bleue?", 3, "Mars", "Jupiter", "La Terre", "Mercure");
                Create_Question(6, "Primaire 6", "Divers", "Quel nom porte la lance qui sert à chasser les baleines?", 2, "La  harpe", "Le harpon", "La lance", "L' hameçon");
                Create_Question(7, "Primaire 6", "Sport et Culture", "Quel groupe a popularisé la chanson «Dégénération»?", 2, "Kaïn", "Mes Aïeux", "Les Respectables", "Loco Locas");
                Create_Question(8, "Primaire 6", "Science et Technologie", "Le vent est causé par le déplacement de quel élément naturel?", 4, "Les nuages", "La pluie", "L'oxygène", "L'air");
                Create_Question(9, "Primaire 6", "Histoire et Géographie", "Dans quelle ville québécoise trouve-t-on la Place des Arts?", 2, "Québec", "Montréal", "Trois-Rivières", "Drummondville");
                Create_Question(10, "Primaire 6", "Histoire et Géographie", "Dans quelle province canadienne est située la ville de Niagara Falls?", 3, "Manitoba", "Québec", "Ontario", "Alberta");
                Create_Question(11, "Primaire 6", "Faune et Flore", "La zoologie est une science naturelle qui étudie quoi?", 1, "Les animaux", "Les oiseaux", "Les saisons", "Les planètes");
                Create_Question(12, "Primaire 6", "Faune et Flore", "Après l'homme, quel est l'animal qui modifie le plus son environnement?", 2, "L'ours", "Le castor", "L'orignal", "Le loup");
                Create_Question(13, "Primaire 6", "Histoire et Géographie", "Dans quelle région du Québec est situé le Rocher Percé?", 2, "Abitibi-Témiscamingue", "Gaspésie", "Centre du Québec", "Lac St-Jean");
                Create_Question(14, "Primaire 6", "Faune et Flore", "Quel animal est actif tout l'hiver?", 2, "L'ours", "L'écureuil", "La marmotte", "Le raton laveur");
                Create_Question(15, "Primaire 6", "Corps Humain", "Dans quelle partie du corps humain se trouve le plus petit et le plus léger des os appelé «étrier»?", 1, "L'oreille", "Le pied", "Le bras", "Le nez");
                Create_Question(16, "Primaire 6", "Corps Humain", "Quelle partie du corps humain est affectée par la méningite?", 3, "Le cœur", "Les reins", "Le cerveau", "La gorge");
                Create_Question(17, "Primaire 6", "Histoire et Géographie", "Sur quel continent faut-il aller pour visiter le Japon?", 1, "Asie", "Afrique", "Europe", "Océanie");
                Create_Question(18, "Primaire 6", "Astronomie", "L'étoile polaire fait partie de quelle constellation?", 2, "La Grande Ourse", "La Petite Ourse", "Orion", "Grand Chien");
                Create_Question(19, "Primaire 6", "Astronomie", "De quel état des États-Unis sont lancées les fusées spatiales américaines?", 4, "Colorado", "Virginie", "Californie", "Floride");
                Create_Question(20, "Primaire 6", "Corps Humain", "Comment appelle-t-on le spécialiste des maladies du coeur?", 4, "Podiatre", "Oncologue", "Dermatologue", "Cardiologue");
                Create_Question(21, "Primaire 6", "Histoire et Géographie", "Dans quel pays coule le Nil, le deuxième plus long fleuve au monde?", 2, "Italie", "Égypte", "France", "Canada");
                Create_Question(22, "Primaire 6", "Histoire et Géographie", "En quelle année se termina la Seconde Guerre mondiale?", 4, "1914", "1939", "1918", "1945");
                Create_Question(23, "Primaire 6", "Faune et Flore", "Quelle sorte d'arbre obtiendrez-vous si vous plantez un gland?", 1, "Un chêne", "Un sapin", "Un érable", "Un peuplier");
                Create_Question(24, "Primaire 6", "Corps Humain", "Quelle est la plus grosse artère du corps humain?", 1, "L'aorte", "Le ventricule gauche", "Le cœur", "La veine cave");
                Create_Question(25, "Primaire 6", "Sport et Culture", "À quel âge Harry Potter découvre-t-il qu'il est sorcier?", 3, "12 ans", "14 ans", "11 ans", "10 ans");
                Create_Question(26, "Primaire 6", "Science et Technologie", "De quelle couleur est le rubis?", 2, "Vert", "Rouge", "Noir", "Blanc");
                Create_Question(27, "Primaire 6", "Histoire et Géographie", "Quelle est la capitale de la Russie?", 1, "Moscou", "Borovitchi", "Beslan", "Volga");
                Create_Question(28, "Primaire 6", "Faune et Flore", "Quel serpent est aussi appelé «serpent à lunettes»?", 1, "Cobra", "Anaconda", "Boa", "Python");
                Create_Question(29, "Primaire 6", "Faune et Flore", "Comment appelle-t-on la personne qui étudie les végétaux?", 4, "Un végétarien", "Un biologiste", "Un naturaliste", "Un botaniste");
                Create_Question(30, "Primaire 6", "Histoire et Géographie", "À quel pays appartient l'Alaska?", 2, "Russie", "États-Unis", "Canada", "France");
                Create_Question(31, "Primaire 6", "Science et Technologie", "Quelle est la formule chimique de l'eau?", 1, "H2O", "HO2", "O4", "HO");
                Create_Question(32, "Primaire 6", "Divers", "Que symbolise la colombe?", 2, "Le mauvais temps", "La paix", "La guerre", "La joie");
                Create_Question(33, "Primaire 6", "Divers", "Quel est l'âge de la majorité et du droit de vote au Canada?", 4, "16 ans", "17 ans", "21 ans", "18 ans");
                Create_Question(34, "Primaire 6", "Sport et Culture", "Combien y a-t-il d'anneaux sur le drapeau des Jeux olympiques?", 3, "4", "6", "5", "3");
                Create_Question(35, "Primaire 6", "Littérature et Expressions", "Que signifie l'expression : prendre ses jambes à son cou?", 2, "Faire de l'exercice", "S'enfuir", "Marcher", "Être souple");
                Create_Question(36, "Primaire 6", "Histoire et Géographie", "Nommez le plus petit état au monde?", 1, "Le Vatican", "Espagne", "Afrique du Sud", "Canada");
                Create_Question(37, "Primaire 6", "Astronomie", "Sans l'aide d'un télescope, combien d'étoile l'homme peut-il voir à l'œil nu?", 3, "30000", "300000", "3000", "300");
                Create_Question(38, "Primaire 6", "Pseudosciences", "De quel signe astrologique sont les personnes nées le 24 juin?", 2, "Bélier", "Cancer", "Gémeaux", "Balance");
                Create_Question(39, "Primaire 6", "Faune et Flore", "Un «okapi» est de la même famille et ressemble à quel animal?", 1, "Une girafe", "Un lion", "Un rhinocéros", "Un éléphant");
                Create_Question(40, "Primaire 6", "Pseudosciences", "Combien y a-t-il de signes dans le zodiaque?", 4, "24", "6", "14", "12");
                Create_Question(41, "Primaire 6", "Faune et Flore", "Combien de paires de pattes les arachnides possèdent-ils?", 2, "6", "4", "8", "2");
                Create_Question(42, "Primaire 6", "Sport et Culture", "Dans quelle ville canadienne irez-vous pour visiter le Temple de la Renommée du hockey?", 2, "Calgary", "Toronto", "Montréal", "Québec");
                Create_Question(43, "Primaire 6", "Sport et Culture", "En quelle année eurent lieu les Jeux olympiques de Montréal?", 2, "1986", "1976", "1967", "1996");
                Create_Question(44, "Primaire 6", "Science et Technologie", "Qu'est-ce qui donne la couleur verte aux plantes et aux feuilles?", 3, "La lumière", "Le Soleil", "La chlorophylle", "Les racines");
                Create_Question(45, "Primaire 6", "Faune et Flore", "Quel nom donne-t-on à la femelle du sanglier?", 2, "La vache", "La laie", "La biche", "La chèvre");
                Create_Question(46, "Primaire 6", "Sport et Culture", "Au golf, comment appelle-t-on le monticule sur lequel repose la coupe, communément appelé le trou?", 3, "La coupe", "Le monticule", "Le vert ( le green)", "Le socle");
                Create_Question(47, "Primaire 6", "Histoire et Géographie", "De quelle langue principale provient la langue française?", 3, "de l'anglais", "de l'espagnol", "du latin", "ancique");
                Create_Question(48, "Primaire 6", "Littérature et Expressions", "Que signifie l'expression suivante : «Le sujet est traité à la une dans les journaux»?", 2, "De dernière minute", "En première page", "En priorité", "À la légère");
                Create_Question(49, "Primaire 6", "Divers", "Sous quel nom populaire connaissons-nous la pastèque?", 3, "Le cantaloup", "Le melon miel", "Le melon d'eau", "La papaye");
                Create_Question(50, "Primaire 6", "Faune et Flore", "C'est le mouvement de quelqu'un qui s'élance vivement. C'est aussi un cervidé du Canada ou du nord de l'Europe ou d'Asie?", 3, "L'orignal", "Le cerf", "L'élan", "Le wapiti");
                Create_Question(51, "Primaire 6", "Faune et Flore", "Quel est le plus grand des singes?", 1, "Le gorille", "L'orang-outang", "Le chimpanzé", "Le wistiti");
                Create_Question(52, "Primaire 6", "Littérature et Expressions", "Complétez l'expression suivante : Cela se vendait comme des petits……", 2, "Biscuits", "Pains chauds", "Fromages", "Bonbons");
                Create_Question(53, "Primaire 6", "Faune et Flore", "Quel oiseau est le plus rapide au sol avec ses 40 km à l' heure?", 3, "Le faisan", "La perdrix", "L'autruche", "Le canard");
                Create_Question(54, "Primaire 6", "Divers", "Quel ustensile manuel sert à battre les œufs et les sauces?", 2, "Un batteur", "Un fouet", "Un malaxeur", "Un mélangeur");
                Create_Question(55, "Primaire 6", "Divers", "De combien de cases se compose un jeu d'échecs?", 2, "120", "64", "100", "81");
                Create_Question(56, "Primaire 6", "Histoire et Géographie", "Le fleuve St-Laurent se déverse dans :", 1, "L'océan Atlantique", "L'océan Pacifique", "Les Grands Lacs", "La Baie d'Hudson");
                Create_Question(57, "Primaire 6", "Sport et Culture", "Qui a été le chef de l'orchestre symphonique de Montréal de 2006 à 2020?", 1, "Kent Nagano", "Chales Dutoit", "Yanick Nézet-Séguin", "Wilfrid Pelletier");
                Create_Question(58, "Primaire 6", "Science et Technologie", "Comment nomme-t-on la science qui consiste à prédire la température et le temps qu'il fera?", 2, "La températurologie", "La météorologie", "La cartomancie", "La gérontologie");
                Create_Question(59, "Primaire 6", "Divers", "Que collectionne un philatéliste?", 2, "De la monnaie", "Des timbres ( poste)", "Des cartes postales", "Des images");
                Create_Question(60, "Primaire 6", "Sport et Culture", "Comment se nomme le chien dans Les Aventures de Tintin?", 4, "Lassie", "Snoopy", "Rantanplan", "Milou");
                Create_Question(61, "Primaire 6", "Astronomie", "Quelle est la 4e planète de notre système solaire à partir du Soleil?", 1, "Mars", "Jupiter", "Terren", "Mercure");
                Create_Question(62, "Primaire 6", "Histoire et Géographie", "Selon la chanson et le mythe, qui aurait inventé l'école?", 4, "Richard Cœur de lion", "Roi Arthur", "Napoléon", "Charlemagne");
                Create_Question(63, "Primaire 6", "Littérature et Expressions", "Qui est l'auteur ou l'autrice de la série de livres Amos Daragon?", 4, "Geronimo Stilton", "Anne Robillard", "Hergé", "Bryan Perro");
                Create_Question(64, "Primaire 6", "Histoire et Géographie", "Quel navigateur et explorateur français aurait découvert le Canada en 1534?", 3, "Samuel de Champlain", "Marco Polo", "Jacques Cartier", "Christophe Colomb");
                Create_Question(65, "Primaire 6", "Sport et Culture", "Quel nom porte l'équipe de soccer qui représente la ville de Montréal dans la MLS (Major Ligue Soccer)?", 4, "Expos", "Canadiens", "Alouettes", "Impact");
                Create_Question(66, "Primaire 6", "Histoire et Géographie", "Qui a été le 1er président des États-Unis? Une ville et un état portent son nom!", 1, "Washington", "Bush", "Obama", "Lincoln");
                Create_Question(67, "Primaire 6", "Histoire et Géographie", "Quelle est la dernière province à se joindre au Canada en 1949?", 2, "Québec", "Terre-Neuve", "Colombie-Britanique", "Ontario");
                Create_Question(68, "Primaire 6", "Sport et Culture", "Quel joueur a été le 1er des Canadiens de Montréal et de la LNH à compter 50 buts en 50 parties et 500 buts en carrière?", 3, "Boum Boum Geoffrion", "Guy Lafleur", "Maurice Richard", "Henri Richard");
                Create_Question(69, "Primaire 6", "Sport et Culture", "Qui interprète la chanson Si jamais j’oublie?", 1, "Zaz", "Ariane Moffat", "Louane", "Jennifer");
                Create_Question(70, "Primaire 6", "Sport et Culture", "Laquelle de ces chansons n’est pas de Loud?", 1, " Alors on danse", "Toutes les femmes savent danser", "Devenir immortel (et mourir)", " Fallait y aller");

            }

            Variables.List_Niveau.Clear();
            Variables.List_Niveau.Add("Aléatoire");
            foreach (var item in question)
            {
                if (Variables.List_Niveau.Contains(item.Niveau)!= true)
                {
                    Variables.List_Niveau.Add(item.Niveau);
                }
            }
        }


        #region Question

        public static void Create_Question(int numero, string niveau, string categorie, string question, int num_reponse, string reponse1, string reponse2, string reponse3, string reponse4)
        {
            var db = new SQLiteConnection(dbPath);
            Questions New_Question = new Questions(numero, niveau, categorie, question, num_reponse, reponse1, reponse2, reponse3, reponse4);
            db.Insert(New_Question);
        }
        public static void Create_Categorie_List(string niveau)
        {
            Variables.List_Categorie.Clear();
            Variables.List_Categorie.Add("Aléatoire");
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Questions>();

            if (niveau == "Aléatoire")
            {
                foreach(var item in table)
                {
                    if(Variables.List_Categorie.Contains(item.Categorie) != true)
                    {
                        Variables.List_Categorie.Add(item.Categorie);
                    }
                }
            }
            else
            {
                foreach(var item in table)
                {
                    if (Variables.List_Categorie.Contains(item.Categorie) != true && item.Niveau == niveau)
                    {
                        Variables.List_Categorie.Add(item.Categorie);
                    }
                }
            }
        }



        public static void Create_Question_List(string Niveau,string Categorie)
        {
            Variables.List_Question.Clear();
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Questions>();
            if(Niveau == "Aléatoire" && Categorie == "Aléatoire")
            {
                foreach (var item in table)
                {
                    Questions list = new Questions(item.Niveau, item.Categorie, item.Question, item.Num_Reponse, item.Reponse1, item.Reponse2, item.Reponse3, item.Reponse4);
                    Variables.List_Question.Add(list);
                }
            }
            else if(Niveau == "Aléatoire" && Categorie != "Aléatoire")
            {
                foreach (var item in table)
                {
                    if(item.Categorie == Categorie)
                    {
                        Questions list = new Questions(item.Niveau, item.Categorie, item.Question, item.Num_Reponse, item.Reponse1, item.Reponse2, item.Reponse3, item.Reponse4);
                        Variables.List_Question.Add(list);
                    }
                }
            }
            else if(Niveau != "Aléatoire" && Categorie == "Aléatoire")
            {
                foreach (var item in table)
                {
                    if(item.Niveau == Niveau)
                    {
                        Questions list = new Questions(item.Niveau, item.Categorie, item.Question, item.Num_Reponse, item.Reponse1, item.Reponse2, item.Reponse3, item.Reponse4);
                        Variables.List_Question.Add(list);
                    }
                }
            }
            else
            {
                foreach (var item in table)
                {
                    if(item.Niveau == Niveau && item.Categorie == Categorie)
                    {
                        Questions list = new Questions(item.Niveau, item.Categorie, item.Question, item.Num_Reponse, item.Reponse1, item.Reponse2, item.Reponse3, item.Reponse4);
                        Variables.List_Question.Add(list);
                    }
                }
            }
        }

        #endregion

        #region Users

        public static void Create_User(string prenom, string nom,int age)
        {
            int numero = 0;
            var db = new SQLiteConnection(dbPath);
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
             
            Users New_User = new Users(numero,prenom, nom,age, 0, 0, 0);
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
                    Users New_User = new Users(item.Numero, item.Prenom, item.Nom, item.Age, item.Reussi, item.Echec,item.Max_Mort);
                    db.Delete(New_User);
                    break;
                }
            }
        }

        public static string Read_User_Info_By_Number(int numero)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Users>();

            foreach (var item in table)
            {
                if(numero == item.Numero)
                {
                    return item.Prenom + " " + item.Nom;
                }
            }
            return "erreur";
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

        public static void Update_User(int numero,int reussi,int echec,int max_mort)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Users>();

            foreach (var item in table)
            {
                if (numero == item.Numero)
                {
                    Users User;
                    if(item.Max_Mort < max_mort)
                    {
                        User = new Users(item.Numero,item.Prenom,item.Nom,item.Age,item.Reussi, item.Echec, max_mort);
                    }
                    else
                    {
                        User = new Users(item.Numero, item.Prenom, item.Nom, item.Age, item.Reussi + reussi, item.Echec + echec, item.Max_Mort);
                    }
                    db.Update(User);
                    break;
                }
            }
        }

        #endregion
    }
}