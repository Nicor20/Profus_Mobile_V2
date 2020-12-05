using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace Profus_mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            #region Initialisation des boutons
            FindViewById<Button>(Resource.Id.Bouton_Jouer).Click += this.Jouer;
            FindViewById<Button>(Resource.Id.Bouton_Inscription).Click += this.Inscription;
            FindViewById<Button>(Resource.Id.Bouton_Info).Click += this.Info;
            FindViewById<Button>(Resource.Id.Bouton_Parametre).Click += this.Parametre;
            FindViewById<Button>(Resource.Id.Bouton_Score).Click += this.Score;
            FindViewById<Button>(Resource.Id.Bouton_Quitter).Click += this.Quitter;
            #endregion

            FindViewById<Button>(Resource.Id.Bouton_Info).Enabled = false;
            FindViewById<Button>(Resource.Id.Bouton_Parametre).Enabled = false;

            //Création de la Db
            //DB_Manager.Delete_DB();
            DB_Manager.Start_DB();
            Bluetooth_Manager.Start_Bluetooth();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void Jouer(object sender, System.EventArgs e)
        {
            if(Variables.Bluetooth_Connected == true)
            {
                StartActivity(new Intent(this, typeof(Options_Jeu)));
            }
            else
            {
                if(Bluetooth_Manager.Connect() == true)
                {
                    Variables.Bluetooth_Connected = true;
                    StartActivity(new Intent(this, typeof(Options_Jeu)));
                }
                else
                {
                    Variables.Bluetooth_Connected = false;
                    Toast.MakeText(this, "Ouvrir le robot", ToastLength.Long);
                }
            }
        }

        void Inscription(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(NouveauJoueur)));
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
    }
}