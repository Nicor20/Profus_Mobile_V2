using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace Profus_mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int Nb_joueur;
        Spinner spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            #region Initialisation des boutons
            FindViewById<Button>(Resource.Id.Bouton_Jouer).Click += this.Jouer;
            FindViewById<Button>(Resource.Id.Bouton_Info).Click += this.Info;
            FindViewById<Button>(Resource.Id.Bouton_Parametre).Click += this.Parametre;
            FindViewById<Button>(Resource.Id.Bouton_Score).Click += this.Score;
            FindViewById<Button>(Resource.Id.Bouton_Quitter).Click += this.Quitter;
            #endregion

            #region Initialisation spinner
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.Prompt = "Nombre de joueurs?";
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Player, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            #endregion




            #region Creation DB
            /*
            DB_Manager.Create_Question(1, 6, "Corps Humain", "Quelle partie du corps est affectée si une personne souffre d'un orgelet?", 1, "L'œil", "Le nez", "La bouche", "Les oreilles");
            DB_Manager.Create_Question(2, 6, "Divers", "Si vous faites face au soleil vers midi, en direction de quel point cardinal regardez-vous?", 2, "Nord", "Sud", "Est", "Ouest");
            DB_Manager.Create_Question(3, 6, "Littérature et Expressions", "Dans le conte « Le petit prince »   de St-Exupéry, quelle fleur est, paraît-il, unique au monde?", 2, "La marguerite", "La rose", "L'œillet", "La pivoine");
            DB_Manager.Create_Question(4, 6, "Sport et Culture", "Dans les Pierrafeu, quel est le nom de la femme de Fred Caillou?", 2, "Bertha", "Délima", "Agathe", "Célina");
            DB_Manager.Create_Question(5, 6, "Astronomie", "Quelle planète est appelée la Planète Bleue?", 3, "Mars", "Jupiter", "La Terre", "Mercure");
            DB_Manager.Create_Question(6, 6, "Divers", "Quel nom porte la lance qui sert à chasser les baleines?", 2, "La  harpe", "Le harpon", "La lance", "L' hameçon");
            DB_Manager.Create_Question(7, 6, "Sport et Culture", "Quel groupe a popularisé la chanson «Dégénération»?", 2, "Kaïn", "Mes Aïeux", "Les Respectables", "Loco Locas");
            DB_Manager.Create_Question(8, 6, "Science et Technologie", "Le vent est causé par le déplacement de quel élément naturel?", 4, "Les nuages", "La pluie", "L'oxygène", "L'air");
            DB_Manager.Create_Question(9, 6, "Histoire et Géographie", "Dans quelle ville québécoise trouve-t-on la Place des Arts?", 2, "Québec", "Montréal", "Trois-Rivières", "Drummondville");
            DB_Manager.Create_Question(10, 6, "Histoire et Géographie", "Dans quelle province canadienne est située la ville de Niagara Falls?", 3, "Manitoba", "Québec", "Ontario", "Alberta");
            DB_Manager.Create_Question(11, 6, "Faune et Flore", "La zoologie est une science naturelle qui étudie quoi?", 1, "Les animaux", "Les oiseaux", "Les saisons", "Les planètes");
            DB_Manager.Create_Question(12, 6, "Faune et Flore", "Après l'homme, quel est l'animal qui modifie le plus son environnement?", 2, "L'ours", "Le castor", "L'orignal", "Le loup");
            DB_Manager.Create_Question(13, 6, "Histoire et Géographie", "Dans quelle région du Québec est situé le Rocher Percé?", 2, "Abitibi-Témiscamingue", "Gaspésie", "Centre du Québec", "Lac St-Jean");
            DB_Manager.Create_Question(14, 6, "Faune et Flore", "Quel animal est actif tout l'hiver?", 2, "L'ours", "L'écureuil", "La marmotte", "Le raton laveur");
            DB_Manager.Create_Question(15, 6, "Corps Humain", "Dans quelle partie du corps humain se trouve le plus petit et le plus léger des os appelé «étrier»?", 1, "L'oreille", "Le pied", "Le bras", "Le nez");
            DB_Manager.Create_Question(16, 6, "Corps Humain", "Quelle partie du corps humain est affectée par la méningite?", 3, "Le cœur", "Les reins", "Le cerveau", "La gorge");
            DB_Manager.Create_Question(17, 6, "Histoire et Géographie", "Sur quel continent faut-il aller pour visiter le Japon?", 1, "Asie", "Afrique", "Europe", "Océanie");
            DB_Manager.Create_Question(18, 6, "Astronomie", "L'étoile polaire fait partie de quelle constellation?", 2, "La Grande Ourse", "La Petite Ourse", "Orion", "Grand Chien");
            DB_Manager.Create_Question(19, 6, "Astronomie", "De quel état des États-Unis sont lancées les fusées spatiales américaines?", 4, "Colorado", "Virginie", "Californie", "Floride");
            DB_Manager.Create_Question(20, 6, "Corps Humain", "Comment appelle-t-on le spécialiste des maladies du coeur?", 4, "Podiatre", "Oncologue", "Dermatologue", "Cardiologue");
            DB_Manager.Create_Question(21, 6, "Histoire et Géographie", "Dans quel pays coule le Nil, le deuxième plus long fleuve au monde?", 2, "Italie", "Égypte", "France", "Canada");
            DB_Manager.Create_Question(22, 6, "Histoire et Géographie", "En quelle année se termina la Seconde Guerre mondiale?", 4, "1914", "1939", "1918", "1945");
            DB_Manager.Create_Question(23, 6, "Faune et Flore", "Quelle sorte d'arbre obtiendrez-vous si vous plantez un gland?", 1, "Un chêne", "Un sapin", "Un érable", "Un peuplier");
            DB_Manager.Create_Question(24, 6, "Corps Humain", "Quelle est la plus grosse artère du corps humain?", 1, "L'aorte", "Le ventricule gauche", "Le cœur", "La veine cave");
            DB_Manager.Create_Question(25, 6, "Sport et Culture", "À quel âge Harry Potter découvre-t-il qu'il est sorcier?", 3, "12 ans", "14 ans", "11 ans", "10 ans");
            DB_Manager.Create_Question(26, 6, "Science et Technologie", "De quelle couleur est le rubis?", 2, "Vert", "Rouge", "Noir", "Blanc");
            DB_Manager.Create_Question(27, 6, "Histoire et Géographie", "Quelle est la capitale de la Russie?", 1, "Moscou", "Borovitchi", "Beslan", "Volga");
            DB_Manager.Create_Question(28, 6, "Faune et Flore", "Quel serpent est aussi appelé «serpent à lunettes»?", 1, "Cobra", "Anaconda", "Boa", "Python");
            DB_Manager.Create_Question(29, 6, "Faune et Flore", "Comment appelle-t-on la personne qui étudie les végétaux?", 4, "Un végétarien", "Un biologiste", "Un naturaliste", "Un botaniste");
            DB_Manager.Create_Question(30, 6, "Histoire et Géographie", "À quel pays appartient l'Alaska?", 2, "Russie", "États-Unis", "Canada", "France");
            DB_Manager.Create_Question(31, 6, "Science et Technologie", "Quelle est la formule chimique de l'eau?", 1, "H2O", "HO2", "O4", "HO");
            DB_Manager.Create_Question(32, 6, "Divers", "Que symbolise la colombe?", 2, "Le mauvais temps", "La paix", "La guerre", "La joie");
            DB_Manager.Create_Question(33, 6, "Divers", "Quel est l'âge de la majorité et du droit de vote au Canada?", 4, "16 ans", "17 ans", "21 ans", "18 ans");
            DB_Manager.Create_Question(34, 6, "Sport et Culture", "Combien y a-t-il d'anneaux sur le drapeau des Jeux olympiques?", 3, "4", "6", "5", "3");
            DB_Manager.Create_Question(35, 6, "Littérature et Expressions", "Que signifie l'expression : prendre ses jambes à son cou?", 2, "Faire de l'exercice", "S'enfuir", "Marcher", "Être souple");
            DB_Manager.Create_Question(36, 6, "Histoire et Géographie", "Nommez le plus petit état au monde?", 1, "Le Vatican", "Espagne", "Afrique du Sud", "Canada");
            DB_Manager.Create_Question(37, 6, "Astronomie", "Sans l'aide d'un télescope, combien d'étoile l'homme peut-il voir à l'œil nu?", 3, "30000", "300000", "3000", "300");
            DB_Manager.Create_Question(38, 6, "Pseudosciences", "De quel signe astrologique sont les personnes nées le 24 juin?", 2, "Bélier", "Cancer", "Gémeaux", "Balance");
            DB_Manager.Create_Question(39, 6, "Faune et Flore", "Un «okapi» est de la même famille et ressemble à quel animal?", 1, "Une girafe", "Un lion", "Un rhinocéros", "Un éléphant");
            DB_Manager.Create_Question(40, 6, "Pseudosciences", "Combien y a-t-il de signes dans le zodiaque?", 4, "24", "6", "14", "12");
            DB_Manager.Create_Question(41, 6, "Faune et Flore", "Combien de paires de pattes les arachnides possèdent-ils?", 2, "6", "4", "8", "2");
            DB_Manager.Create_Question(42, 6, "Sport et Culture", "Dans quelle ville canadienne irez-vous pour visiter le Temple de la Renommée du hockey?", 2, "Calgary", "Toronto", "Montréal", "Québec");
            DB_Manager.Create_Question(43, 6, "Sport et Culture", "En quelle année eurent lieu les Jeux olympiques de Montréal?", 2, "1986", "1976", "1967", "1996");
            DB_Manager.Create_Question(44, 6, "Science et Technologie", "Qu'est-ce qui donne la couleur verte aux plantes et aux feuilles?", 3, "La lumière", "Le Soleil", "La chlorophylle", "Les racines");
            DB_Manager.Create_Question(45, 6, "Faune et Flore", "Quel nom donne-t-on à la femelle du sanglier?", 2, "La vache", "La laie", "La biche", "La chèvre");
            DB_Manager.Create_Question(46, 6, "Sport et Culture", "Au golf, comment appelle-t-on le monticule sur lequel repose la coupe, communément appelé le trou?", 3, "La coupe", "Le monticule", "Le vert ( le green)", "Le socle");
            DB_Manager.Create_Question(47, 6, "Histoire et Géographie", "De quelle langue principale provient la langue française?", 3, "de l'anglais", "de l'espagnol", "du latin", "ancique");
            DB_Manager.Create_Question(48, 6, "Littérature et Expressions", "Que signifie l'expression suivante : «Le sujet est traité à la une dans les journaux»?", 2, "De dernière minute", "En première page", "En priorité", "À la légère");
            DB_Manager.Create_Question(49, 6, "Divers", "Sous quel nom populaire connaissons-nous la pastèque?", 3, "Le cantaloup", "Le melon miel", "Le melon d'eau", "La papaye");
            DB_Manager.Create_Question(50, 6, "Faune et Flore", "C'est le mouvement de quelqu'un qui s'élance vivement. C'est aussi un cervidé du Canada ou du nord de l'Europe ou d'Asie?", 3, "L'orignal", "Le cerf", "L'élan", "Le wapiti");
            DB_Manager.Create_Question(51, 6, "Faune et Flore", "Quel est le plus grand des singes?", 1, "Le gorille", "L'orang-outang", "Le chimpanzé", "Le wistiti");
            DB_Manager.Create_Question(52, 6, "Littérature et Expressions", "Complétez l'expression suivante : Cela se vendait comme des petits……", 2, "Biscuits", "Pains chauds", "Fromages", "Bonbons");
            DB_Manager.Create_Question(53, 6, "Faune et Flore", "Quel oiseau est le plus rapide au sol avec ses 40 km à l' heure?", 3, "Le faisan", "La perdrix", "L'autruche", "Le canard");
            DB_Manager.Create_Question(54, 6, "Divers", "Quel ustensile manuel sert à battre les œufs et les sauces?", 2, "Un batteur", "Un fouet", "Un malaxeur", "Un mélangeur");
            DB_Manager.Create_Question(55, 6, "Divers", "De combien de cases se compose un jeu d'échecs?", 2, "120", "64", "100", "81");
            DB_Manager.Create_Question(56, 6, "Histoire et Géographie", "Le fleuve St-Laurent se déverse dans :", 1, "L'océan Atlantique", "L'océan Pacifique", "Les Grands Lacs", "La Baie d'Hudson");
            DB_Manager.Create_Question(57, 6, "Sport et Culture", "Qui a été le chef de l'orchestre symphonique de Montréal de 2006 à 2020?", 1, "Kent Nagano", "Chales Dutoit", "Yanick Nézet-Séguin", "Wilfrid Pelletier");
            DB_Manager.Create_Question(58, 6, "Science et Technologie", "Comment nomme-t-on la science qui consiste à prédire la température et le temps qu'il fera?", 2, "La températurologie", "La météorologie", "La cartomancie", "La gérontologie");
            DB_Manager.Create_Question(59, 6, "Divers", "Que collectionne un philatéliste?", 2, "De la monnaie", "Des timbres ( poste)", "Des cartes postales", "Des images");
            DB_Manager.Create_Question(60, 6, "Sport et Culture", "Comment se nomme le chien dans Les Aventures de Tintin?", 4, "Lassie", "Snoopy", "Rantanplan", "Milou");
            DB_Manager.Create_Question(61, 6, "Astronomie", "Quelle est la 4e planète de notre système solaire à partir du Soleil?", 1, "Mars", "Jupiter", "Terren", "Mercure");
            DB_Manager.Create_Question(62, 6, "Histoire et Géographie", "Selon la chanson et le mythe, qui aurait inventé l'école?", 4, "Richard Cœur de lion", "Roi Arthur", "Napoléon", "Charlemagne");
            DB_Manager.Create_Question(63, 6, "Littérature et Expressions", "Qui est l'auteur ou l'autrice de la série de livres Amos Daragon?", 4, "Geronimo Stilton", "Anne Robillard", "Hergé", "Bryan Perro");
            DB_Manager.Create_Question(64, 6, "Histoire et Géographie", "Quel navigateur et explorateur français aurait découvert le Canada en 1534?", 3, "Samuel de Champlain", "Marco Polo", "Jacques Cartier", "Christophe Colomb");
            DB_Manager.Create_Question(65, 6, "Sport et Culture", "Quel nom porte l'équipe de soccer qui représente la ville de Montréal dans la MLS (Major Ligue Soccer)?", 4, "Expos", "Canadiens", "Alouettes", "Impact");
            DB_Manager.Create_Question(66, 6, "Histoire et Géographie", "Qui a été le 1er président des États-Unis? Une ville et un état portent son nom!", 1, "Washington", "Bush", "Obama", "Lincoln");
            DB_Manager.Create_Question(67, 6, "Histoire et Géographie", "Quelle est la dernière province à se joindre au Canada en 1949?", 2, "Québec", "Terre-Neuve", "Colombie-Britanique", "Ontario");
            DB_Manager.Create_Question(68, 6, "Sport et Culture", "Quel joueur a été le 1er des Canadiens de Montréal et de la LNH à compter 50 buts en 50 parties et 500 buts en carrière?", 3, "Boum Boum Geoffrion", "Guy Lafleur", "Maurice Richard", "Henri Richard");
            DB_Manager.Create_Question(69, 6, "Sport et Culture", "Qui interprète la chanson Si jamais j’oublie?", 1, "Zaz", "Ariane Moffat", "Louane", "Jennifer");
            DB_Manager.Create_Question(70, 6, "Sport et Culture", "Laquelle de ces chansons n’est pas de Loud?", 1, " Alors on danse", "Toutes les femmes savent danser", "Devenir immortel (et mourir)", " Fallait y aller");
            */
            #endregion
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #region Boutons
        void Jouer(object sender, System.EventArgs e)
        {
            Variables.Nb_Joueur = Nb_joueur;
            StartActivity(new Intent(this, typeof(Mode_de_Jeu)));
        }


        void Info(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Info)));
        }

        void Parametre(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Parametre)));
        }

       
        void Score(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Leaderboard)));
        }

        void Quitter(object sender, System.EventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
        #endregion

        #region Spinner
        private void spinner_ItemSelected(object sender,AdapterView.ItemSelectedEventArgs e)
        {
            Nb_joueur = int.Parse(spinner.SelectedItemPosition.ToString()) + 1;
        }
        #endregion
    }
}