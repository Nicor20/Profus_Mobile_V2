using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using System.Threading;

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
            FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.Logo_Decale);
            FindViewById<ImageView>(Resource.Id.imageView1).LayoutParameters.Width = FindViewById<LinearLayout>(Resource.Id.linearLayout1).Width / 2;

            #region Initialisation des boutons
            FindViewById<Button>(Resource.Id.Bouton_Jouer).Click += this.Jouer;
            FindViewById<Button>(Resource.Id.Bouton_Inscription).Click += this.Inscription;
            FindViewById<Button>(Resource.Id.Bouton_Info).Click += this.Info;
            FindViewById<Button>(Resource.Id.Bouton_Parametre).Click += this.Parametre;
            FindViewById<Button>(Resource.Id.Bouton_Score).Click += this.Score;
            FindViewById<Button>(Resource.Id.Bouton_Quitter).Click += this.Quitter;
            #endregion

            //Création de la Db
            //DB_Manager.Delete_DB();
            DB_Manager.Start_DB();

            if(Variables.Play_With_Bluetooth == true)
            {
                Bluetooth_Manager.Start_Bluetooth();
            }
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void Jouer(object sender, System.EventArgs e)
        {
            if(Variables.Bluetooth_Connected == false && Variables.Play_With_Bluetooth == true)
            {
                Thread.Sleep(2000);
                if(Bluetooth_Manager.Connect() == true)
                {
                    Variables.Bluetooth_Connected = true;
                    StartActivity(new Intent(this, typeof(Options_Jeu)));
                }
                else
                {
                    Variables.Bluetooth_Connected = false;
                    Toast.MakeText(this, "Appareil bluetooth introuvable", ToastLength.Long).Show();
                }
            }
            else
            {
                StartActivity(new Intent(this, typeof(Options_Jeu)));
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