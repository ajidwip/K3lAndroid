using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace k3lkendaraanAndro
{
    [Activity(Label = "K3L Kendaraan", Theme = "@style/MyTheme", MainLauncher = true)]
    public class login : AppCompatActivity
    {
        public static localhost1.Service1 MyClient = new localhost1.Service1();
        EditText userid, password;
        Button btnlogin;
        public ISharedPreferences sharedPreferences;
        int requestPermissions;
        string cameraPermission = Android.Manifest.Permission.Camera;
        string locationPermission = Android.Manifest.Permission.AccessCoarseLocation;
        string locationfinePermission = Android.Manifest.Permission.AccessFineLocation;
        string readstoragePermission = Android.Manifest.Permission.ReadExternalStorage;
        string writestoragePermission = Android.Manifest.Permission.WriteExternalStorage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            sharedPreferences = this.GetSharedPreferences("sharedprefrences", 0);
            userid = FindViewById<EditText>(Resource.Id.txtUserId) ;
            password = FindViewById<EditText>(Resource.Id.txtpassword);
            btnlogin = FindViewById<Button>(Resource.Id.btnlogin);

            if (!(ContextCompat.CheckSelfPermission(this, locationPermission) == (int)Permission.Granted))
            {
                ActivityCompat.RequestPermissions(this, new String[] { locationPermission, cameraPermission, locationfinePermission, readstoragePermission, writestoragePermission }, requestPermissions);
            }

            btnlogin.Click += delegate
            {
                ProgressDialog progressDialog = ProgressDialog.Show(this, "", "Loading...", true);
                progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                new Thread(new ThreadStart(delegate
                {
                try
                {
                    int count = MyClient.cekuser(userid.Text.ToString(), password.Text.ToString()).count;
                    string dept = MyClient.cekuser(userid.Text.ToString(), password.Text.ToString()).dept;
                    if (count == 1)
                    {

                        ISharedPreferencesEditor editor = sharedPreferences.Edit();
                        editor.PutString("UserId", userid.Text.ToString());
                        editor.PutString("bagian", dept);
                        editor.Commit();

                        if (sharedPreferences.GetString("NoPolisi", null) != null)
                            {
                               
                                Intent i = new Intent(this, typeof(formkendaraanmasukgudang));
                            StartActivity(i);
                            Finish();

                                RunOnUiThread(() =>
                                {
                                    Toast.MakeText(this, "Mohon mengisi Kondisi Kendaraan " + sharedPreferences.GetString("NoPolisi", null), ToastLength.Long).Show();
                                });
                            }
                            else
                            {
                                Intent i = new Intent(this, typeof(home));
                                StartActivity(i);
                                Finish();
                            }
                    
                    }
                }
                catch(Exception ex)
                {
                        RunOnUiThread(() =>
                        {
                            Toast.MakeText(this, "server error", ToastLength.Short).Show();
                        });
                    }
                    progressDialog.Dismiss();
                })).Start();
            };
            // Create your application here
        }
    }
}