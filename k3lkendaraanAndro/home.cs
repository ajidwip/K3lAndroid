using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace k3lkendaraanAndro
{
    [Activity(Label = "home", Theme = "@style/MyTheme")]
    public class home : AppCompatActivity
    {
        Button MasukKendaraanGudang, MasukKendaraan, KeluarKendaraan;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            MasukKendaraanGudang = FindViewById<Button>(Resource.Id.MasukKendaraanGudang);
            MasukKendaraan = FindViewById<Button>(Resource.Id.MasukKendaraan);
            KeluarKendaraan = FindViewById<Button>(Resource.Id.KeluarKendaraan);

            MasukKendaraan.Click += delegate
            {
                ProgressDialog progressDialog = ProgressDialog.Show(this, "", "Loading...", true);
                progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                new Thread(new ThreadStart(delegate
                {
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                    Finish();
                })).Start();
            };
            MasukKendaraanGudang.Click += delegate
            {
                ProgressDialog progressDialog = ProgressDialog.Show(this, "", "Loading...", true);
                progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                new Thread(new ThreadStart(delegate
                {
                    Intent i = new Intent(this, typeof(formkendaraanmasukgudang));
                    StartActivity(i);
                    Finish();
                })).Start();
            };
            KeluarKendaraan.Click += delegate
            {
                ProgressDialog progressDialog = ProgressDialog.Show(this, "", "Loading...", true);
                progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                new Thread(new ThreadStart(delegate
                {
                    Intent i = new Intent(this, typeof(formkeluar));
                    StartActivity(i);
                    Finish();
                })).Start();
            };
            // Create your application here
        }
    }
}