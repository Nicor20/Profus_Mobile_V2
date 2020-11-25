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
            // Set our view from the "main" layout resource
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

            #region Creation DB
            DB_Manager.Create_DB(this);
            #endregion
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void Jouer(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Mode_de_Jeu)));
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