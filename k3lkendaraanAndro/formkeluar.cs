using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Webkit;
using System.Data;
using System.Net;
using Android.Content;
using Java.Interop;
using System.Collections.Generic;
using System;
using Android.Provider;
using Android.Graphics;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Load.Engine;
using Com.Bumptech.Glide.Request;
using System.IO;
using static Android.Graphics.Bitmap;
using System.Threading;
using Android.Views;
using Android.Support.V4.Content;
using System.Threading.Tasks;
using SearchableSpinner.Droid.Controls;
using Android.Content.PM;
using Android.Support.V4.App;

namespace k3lkendaraanAndro
{
    [Activity(Label = "k3lkendaraanAndro", Theme = "@style/MyTheme", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustResize)]
    public class formkeluar : AppCompatActivity
    {
        public static byte[] bitmapdata = new byte[byte.MaxValue];
        public static byte[] bitmapdata2 = new byte[byte.MaxValue];
        public static byte[] bitmapdata3 = new byte[byte.MaxValue];
        public static byte[] bitmapdata4 = new byte[byte.MaxValue];
        public static byte[] bitmapdata5 = new byte[byte.MaxValue];
        public static byte[] bitmapdata6 = new byte[byte.MaxValue];
        public static byte[] bitmapdata7 = new byte[byte.MaxValue];
        public static byte[] bitmapdata8 = new byte[byte.MaxValue];

        int countlist3 = 0;
        DataTable d4 = new DataTable();
        int countfoto = 0;
        Android.App.AlertDialog.Builder _dialogBuilder;
        Android.App.AlertDialog alertdialog;
        int countback = 0;

        public static RadioButton rdnew, rdedit;
        public static localhost1.Service1 MyClient = new localhost1.Service1();
        WebView browser;
        Button btnsubmit, btnsyncexp, btnsynckendaraan;

        List<SpinnerItem> list1 = new List<SpinnerItem>();
        List<SpinnerItem> list2 = new List<SpinnerItem>();
        List<SpinnerItem> list3 = new List<SpinnerItem>();
        public static EditText txtNamaSupplier, txtNamaSupir, txtSJNo, txtNamaProduk, txtTujuan;
        public static ISharedPreferences sharedPreferences;
        public static string vendorcode = "";
        public static int count = 0;
        public static ImageView buktifoto, buktifoto2, buktifoto3, buktifoto4, buktifoto5, buktifoto6, buktifoto7, buktifoto8;
        public TextView notrans;
        public static Java.IO.File output, output2, output3, output4, output5, output6, output7, output8;
        public static SpinnerSearch spExp, spNoKendaraan, spporunningnumber;
        int progress = 0;
        string nopo = "", namasupliertmp = "", vendrotmp = "";
        DataTable dt2 = new DataTable();
        TextView title;
        public ProgressDialog progressShow;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
            base.OnCreate(savedInstanceState);

            

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.keluarbarang);
            sharedPreferences = this.GetSharedPreferences("sharedprefrences", 0);
            browser = FindViewById<WebView>(Resource.Id.webview);
            btnsubmit = FindViewById<Button>(Resource.Id.btnsubmit);
            spExp = FindViewById<SpinnerSearch>(Resource.Id.spExp);

            txtNamaSupplier = FindViewById<EditText>(Resource.Id.txtNamaSupplier1);
            txtNamaSupir = FindViewById<EditText>(Resource.Id.txtNamaSupir);
            spNoKendaraan = FindViewById<SpinnerSearch>(Resource.Id.spNoKendaraan);
            txtSJNo = FindViewById<EditText>(Resource.Id.txtSJNo);
            txtNamaProduk = FindViewById<EditText>(Resource.Id.txtNamaProduk);
            txtTujuan = FindViewById<EditText>(Resource.Id.txtTujuan);
            rdnew = FindViewById<RadioButton>(Resource.Id.rdnew);
            rdedit = FindViewById<RadioButton>(Resource.Id.rdedit);
            spporunningnumber = FindViewById<SpinnerSearch>(Resource.Id.spporunningnumber);

            btnsyncexp = FindViewById<Button>(Resource.Id.btnsyncexp);
            btnsynckendaraan = FindViewById<Button>(Resource.Id.btnsynckendaraan);

            buktifoto = FindViewById<ImageView>(Resource.Id.buktifoto);
            buktifoto2 = FindViewById<ImageView>(Resource.Id.buktifoto2);
            buktifoto3 = FindViewById<ImageView>(Resource.Id.buktifoto3);
            buktifoto4 = FindViewById<ImageView>(Resource.Id.buktifoto4);
            buktifoto5 = FindViewById<ImageView>(Resource.Id.buktifoto5);
            buktifoto6 = FindViewById<ImageView>(Resource.Id.buktifoto6);
            buktifoto7 = FindViewById<ImageView>(Resource.Id.buktifoto7);
            buktifoto8 = FindViewById<ImageView>(Resource.Id.buktifoto8);

            notrans = FindViewById<TextView>(Resource.Id.notrans);

            notrans.Visibility = Android.Views.ViewStates.Invisible;

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            title = toolbar.FindViewById<TextView>(Resource.Id.title);
            title.Text = "Pengiriman Barang";

            btnsyncexp.Click += delegate {

                ProgressDialog progressDialog = ProgressDialog.Show(this, "", "Please Wait...", true);
                progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                new Thread(new ThreadStart(delegate
                {
                    RunOnUiThread(async () =>
                    {
                        try
                        {

                            dt2.Clear();
                            localhost1.EXPEDISI emp1 = new localhost1.EXPEDISI();
                            emp1 = MyClient.GetExpedisi();
                            dt2 = emp1.expedisi1;
                            list1.Clear();
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                list1.Add(new SpinnerItem { Id = i, Name = dt2.Rows[i][0].ToString() });


                            }
                            spExp.SetItems(list1, -1, null);


                            await Task.Delay(3000);
                            progress = 1;


                            if (progress == 1)
                            {
                                progress = 0;
                                progressDialog.Dismiss();
                            }


                        }
                        catch (Exception ex)
                        {
                            progressDialog.Dismiss();
                        }

                    });

                })).Start();


            };

            btnsynckendaraan.Click += delegate {

                ProgressDialog progressDialog = ProgressDialog.Show(this, "", "Please Wait...", true);
                progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                new Thread(new ThreadStart(delegate
                {
                    RunOnUiThread(async () =>
                    {
                        try
                        {

                            d4.Clear();
                            localhost1.nokendaraan emp4 = new localhost1.nokendaraan();
                            emp4 = MyClient.GetNokendaraan(DateTime.Now.ToString("yyyy-MM-dd"));
                            d4 = emp4.nokendaraantab;
                            list3.Clear();
                            for (int i = 0; i < d4.Rows.Count; i++)
                            {
                                list3.Add(new SpinnerItem { Id = i, Name = d4.Rows[i][0].ToString() });
                            }
                            countlist3 = list3.Count;
                            spNoKendaraan.SetItems(list3, -1, null);

                            await Task.Delay(3000);


                            progress = 1;


                            if (progress == 1)
                            {
                                progress = 0;
                                progressDialog.Dismiss();
                            }
                        }
                        catch (Exception ex)
                        {
                            progressDialog.Dismiss();
                        }
                    });

                })).Start();

            };
            // buktifoto.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
            buktifoto.Click += delegate
            {
                if (output != null)
                {
                    if (output.Exists())
                    {
                        File.Delete(output.AbsolutePath);
                    }
                }

                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output = new Java.IO.File(dir, "1.jpg");

                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                       this,
                       "k3lkendaraanAndro",
                       output
               );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);

                StartActivityForResult(intent, 1);

            };

            buktifoto2.Click += delegate
            {
                if (output2 != null)
                {
                    if (output2.Exists())
                    {
                        File.Delete(output2.AbsolutePath);
                    }
                }
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output2 = new Java.IO.File(dir, "2.jpg");

                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                            this,
                            "k3lkendaraanAndro",
                            output2
                    );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);

                StartActivityForResult(intent, 2);

            };


            buktifoto3.Click += delegate
            {
                if (output3 != null)
                {
                    if (output3.Exists())
                    {
                        File.Delete(output3.AbsolutePath);
                    }
                }

                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output3 = new Java.IO.File(dir, "3.jpg");

                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                           this,
                           "k3lkendaraanAndro",
                           output3
                   );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);

                StartActivityForResult(intent, 3);

            };

            buktifoto4.Click += delegate
            {
                if (output4 != null)
                {
                    if (output4.Exists())
                    {
                        File.Delete(output4.AbsolutePath);
                    }
                }

                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output4 = new Java.IO.File(dir, "4.jpg");
                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                            this,
                            "k3lkendaraanAndro",
                            output4
                    );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);
                StartActivityForResult(intent, 4);

            };


            buktifoto5.Click += delegate
            {
                if (output5 != null)
                {
                    if (output5.Exists())
                    {
                        File.Delete(output5.AbsolutePath);
                    }
                }

                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output5 = new Java.IO.File(dir, "5.jpg");
                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                            this,
                            "k3lkendaraanAndro",
                            output5
                    );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);

                StartActivityForResult(intent, 5);

            };


            buktifoto6.Click += delegate
            {
                if (output6 != null)
                {
                    if (output6.Exists())
                    {
                        File.Delete(output6.AbsolutePath);
                    }
                }
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output6 = new Java.IO.File(dir, "6.jpg");
                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                            this,
                            "k3lkendaraanAndro",
                            output6
                    );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);

                StartActivityForResult(intent, 6);

            };


            buktifoto7.Click += delegate
            {
                if (output7 != null)
                {
                    if (output7.Exists())
                    {
                        File.Delete(output7.AbsolutePath);
                    }
                }
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output7 = new Java.IO.File(dir, "7.jpg");
                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                             this,
                             "k3lkendaraanAndro",
                             output7
                     );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);


                StartActivityForResult(intent, 7);

            };


            buktifoto8.Click += delegate
            {
                if (output8 != null)
                {
                    if (output8.Exists())
                    {
                        File.Delete(output8.AbsolutePath);
                    }
                }

                Intent intent = new Intent(MediaStore.ActionImageCapture);
                Java.IO.File dir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
                output8 = new Java.IO.File(dir, "8.jpg");
                Android.Net.Uri Photouri = FileProvider.GetUriForFile(
                             this,
                             "k3lkendaraanAndro",
                             output8
                     );


                intent.PutExtra(MediaStore.ExtraOutput, Photouri);

                StartActivityForResult(intent, 8);

            };

            if (sharedPreferences.GetString("bagian", null) == "SCR")
            {
                spporunningnumber.Visibility = Android.Views.ViewStates.Invisible;
                txtSJNo.Enabled = false;
                txtNamaProduk.Visibility = Android.Views.ViewStates.Gone;
                txtTujuan.Visibility = Android.Views.ViewStates.Gone;
                rdnew.Checked = true;

            }
            else
            {
                txtNamaSupir.Enabled = false;
                txtNamaSupplier.Enabled = false;
                spNoKendaraan.Enabled = false;
                txtNamaProduk.Visibility = Android.Views.ViewStates.Visible;
                txtTujuan.Visibility = Android.Views.ViewStates.Visible;
                rdnew.Visibility = Android.Views.ViewStates.Gone;
                spporunningnumber.Visibility = Android.Views.ViewStates.Visible;

            }

            rdnew.Click += delegate
            {
                nopo = "";
                vendrotmp = "";
                namasupliertmp = "";
                notrans.Visibility = Android.Views.ViewStates.Invisible;

                if (list3.Count != countlist3)
                {
                    d4.Rows.RemoveAt(list3.Count - 1);
                    list3.RemoveAt(list3.Count - 1);
                }

                DataTable dt = new DataTable();
                localhost1.pernyataankirim emp = new localhost1.pernyataankirim();
                emp = MyClient.GetPernyataanKirim(sharedPreferences.GetString("bagian", null), "");
                dt = emp.pernyataankirim1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtNamaSupplier.Text = "";
                    txtNamaSupir.Text = "";
                    txtSJNo.Text = dt.Rows[0][2].ToString();
                    var test = dt.Rows[0][0].ToString();
                    browser.LoadDataWithBaseURL(null, dt.Rows[0][0].ToString(), "text/html", "utf-8", null);
                    buktifoto.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
                    buktifoto2.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
                    buktifoto3.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
                    buktifoto4.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
                    buktifoto5.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
                    buktifoto6.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
                    buktifoto7.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));
                    buktifoto8.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    bitmapdata = new byte[byte.MaxValue];
                    bitmapdata2 = new byte[byte.MaxValue];
                    bitmapdata3 = new byte[byte.MaxValue];
                    bitmapdata4 = new byte[byte.MaxValue];
                    bitmapdata5 = new byte[byte.MaxValue];
                    bitmapdata6 = new byte[byte.MaxValue];
                    bitmapdata7 = new byte[byte.MaxValue];
                    bitmapdata8 = new byte[byte.MaxValue];

                }

                list2.Clear();
                rdedit.Checked = false;
                spporunningnumber.Visibility = Android.Views.ViewStates.Invisible;
            };

            rdedit.Click += delegate
            {
                try
                {
                    notrans.Visibility = Android.Views.ViewStates.Visible;

                    rdnew.Checked = false;
                    spporunningnumber.Visibility = Android.Views.ViewStates.Visible;

                    DataTable dt3 = new DataTable();
                    localhost1.porunningnumber emp1 = new localhost1.porunningnumber();
                    emp1 = MyClient.GetPorunningkirimnumber();
                    dt3 = emp1.porunningnumbertab;
                    list2.Clear();
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        list2.Add(new SpinnerItem { Id = i, Name = dt3.Rows[i][0].ToString() });


                    }
                    spporunningnumber.SetItems(list2, -1, null);


                }
                catch (Exception ex)
                {

                }
            };

            try
            {
                DataTable dtper = new DataTable();
                localhost1.pernyataankirim emper = new localhost1.pernyataankirim();
                emper = MyClient.GetPernyataanKirim(sharedPreferences.GetString("bagian", null), "");
                dtper = emper.pernyataankirim1;
                for (int i = 0; i < dtper.Rows.Count; i++)
                {
                    var test = dtper.Rows[0][0].ToString();
                    browser.LoadDataWithBaseURL(null, dtper.Rows[0][0].ToString(), "text/html", "utf-8", null);
                }


                dt2.Clear();
                localhost1.EXPEDISI emp1 = new localhost1.EXPEDISI();
                emp1 = MyClient.GetExpedisi();
                dt2 = emp1.expedisi1;
                list1.Clear();
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    list1.Add(new SpinnerItem { Id = i, Name = dt2.Rows[i][0].ToString() });
                }
                spExp.SetItems(list1, -1, null);


                d4.Clear();
                localhost1.nokendaraan emp4 = new localhost1.nokendaraan();
                emp4 = MyClient.GetNokendaraan(DateTime.Now.ToString("yyyy-MM-dd"));
                d4 = emp4.nokendaraantab;
                list3.Clear();
                for (int i = 0; i < d4.Rows.Count; i++)
                {
                    list3.Add(new SpinnerItem { Id = i, Name = d4.Rows[i][0].ToString() });
                }
                countlist3 = list3.Count;
                spNoKendaraan.SetItems(list3, -1, null);


                /*if (d4.Rows.Count > 0)
                {
                    txtNamaSupir.Text = d4.Rows[spNoKendaraan.SelectedItemPosition][1].ToString();
                }*/


                spNoKendaraan.ItemSelected += delegate
                {
                    if (spNoKendaraan.SelectedItem.ToString() != "No Selected Item")
                    {
                        try
                        {
                            txtNamaSupir.Text = d4.Rows[list3.IndexOf(list3.Find(a => a.Name == spNoKendaraan.SelectedItem.ToString()))][1].ToString();
                        }
                        catch
                        {

                        }
                    }

                };

                spExp.ItemSelected += delegate
                {

                    try
                    {
                        if (rdedit.Checked)
                        {

                            rdnew.Checked = false;
                            spporunningnumber.Visibility = Android.Views.ViewStates.Visible;



                        }

                        if (spExp.SelectedItem.ToString() == "")
                        {
                            txtNamaSupplier.Enabled = false;
                        }
                        else
                        {
                            txtNamaSupplier.Enabled = true;
                        }

                        if (spExp.SelectedItem.ToString().Contains("BI") || spExp.SelectedItem.ToString().Contains("TI"))
                        {
                            if (spExp.SelectedItem.ToString() != nopo)
                            {
                                txtNamaSupplier.Text = "";
                                vendorcode = "";
                            }
                            else
                            {
                                txtNamaSupplier.Text = namasupliertmp;
                                vendorcode = vendrotmp;
                            }
                        }
                        else
                        {
                            if (spExp.SelectedItem.ToString() != "No Selected Item")
                            {
                                txtNamaSupplier.Text = dt2.Rows[list1.IndexOf(list1.Find(a => a.Name == spExp.SelectedItem.ToString()))][1].ToString();
                                vendorcode = dt2.Rows[list1.IndexOf(list1.Find(a => a.Name == spExp.SelectedItem.ToString()))][0].ToString();
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                    }

                };


                spporunningnumber.ItemSelected += delegate
                {
                    if (spporunningnumber.SelectedItem.ToString() != "No Selected Item")
                    {
                        ProgressDialog progressDialog = ProgressDialog.Show(this, "", "Loading...", true);
                        progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                        new Thread(new ThreadStart(delegate
                        {
                            RunOnUiThread(() =>
                            {

                                try
                                {
                                    buktifoto.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    buktifoto2.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    buktifoto3.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    buktifoto4.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    buktifoto5.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    buktifoto6.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    buktifoto7.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    buktifoto8.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                                    DataTable dt = new DataTable();
                                    localhost1.pernyataankirim emp = new localhost1.pernyataankirim();
                                    emp = MyClient.GetPernyataanKirim(sharedPreferences.GetString("bagian", null), spporunningnumber.SelectedItem.ToString());
                                    dt = emp.pernyataankirim1;
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        txtNamaSupir.Text = dt.Rows[0][1].ToString();
                                        txtSJNo.Text = dt.Rows[0][2].ToString();
                                        txtNamaProduk.Text = dt.Rows[0][16].ToString();
                                        txtTujuan.Text = dt.Rows[0][17].ToString();


                                        for (int k = 0; k < list3.Count; k++)
                                        {
                                            spNoKendaraan.Items[k].IsSelected = false;
                                        }
                                        for (int k = 0; k < list1.Count; k++)
                                        {
                                            spExp.Items[k].IsSelected = false;
                                        }

                                        if (list3.Count != countlist3)
                                        {
                                            d4.Rows.RemoveAt(list3.Count - 1);
                                            list3.RemoveAt(list3.Count - 1);
                                        }

                                        d4.Rows.Add(dt.Rows[0][3].ToString(), txtNamaSupir.Text.ToString());
                                        list3.Add(new SpinnerItem { Id = list3.Count + 1, Name = dt.Rows[0][3].ToString() });
                                        spNoKendaraan.SetItems(list3, list3.IndexOf(list3.Find(a => a.Name == dt.Rows[0][3].ToString())), null);
                                        spExp.SetItems(list1, list1.IndexOf(list1.Find(a => a.Name == dt.Rows[0][13].ToString())), null);


                                        var test = dt.Rows[0][0].ToString();
                                        browser.LoadDataWithBaseURL(null, dt.Rows[0][0].ToString(), "text/html", "utf-8", null);
                                        bitmapdata = (byte[])dt.Rows[0][5];
                                        bitmapdata2 = (byte[])dt.Rows[0][6];
                                        bitmapdata3 = (byte[])dt.Rows[0][7];
                                        bitmapdata4 = (byte[])dt.Rows[0][8];
                                        bitmapdata5 = (byte[])dt.Rows[0][9];
                                        bitmapdata6 = (byte[])dt.Rows[0][10];
                                        bitmapdata7 = (byte[])dt.Rows[0][11];
                                        bitmapdata8 = (byte[])dt.Rows[0][12];

                                        string base64string = Convert.ToBase64String(bitmapdata).Replace("A", "");
                                        string base64string2 = Convert.ToBase64String(bitmapdata2).Replace("A", "");
                                        string base64string3 = Convert.ToBase64String(bitmapdata3).Replace("A", "");
                                        string base64string4 = Convert.ToBase64String(bitmapdata4).Replace("A", "");
                                        string base64string5 = Convert.ToBase64String(bitmapdata5).Replace("A", "");
                                        string base64string6 = Convert.ToBase64String(bitmapdata6).Replace("A", "");
                                        string base64string7 = Convert.ToBase64String(bitmapdata7).Replace("A", "");
                                        string base64string8 = Convert.ToBase64String(bitmapdata8).Replace("A", "");

                                        if (spExp.SelectedItem.ToString().Contains("BI") || spExp.SelectedItem.ToString().Contains("TI"))
                                        {
                                            nopo = spExp.SelectedItem.ToString();
                                            namasupliertmp = dt.Rows[0][4].ToString();
                                            vendrotmp = "";
                                            txtNamaSupplier.Text = dt.Rows[0][4].ToString();
                                            vendorcode = "";
                                        }
                                        else
                                        {
                                            txtNamaSupplier.Text = dt.Rows[0][14].ToString();
                                            vendorcode = dt.Rows[0][15].ToString();
                                        }
                                        if (base64string != "")
                                        {
                                            Glide.With(this).Load(bitmapdata).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto);
                                        }

                                        if (base64string2 != "")
                                        {
                                            Glide.With(this).Load(bitmapdata2).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto2);
                                        }
                                        if (base64string3 != "")
                                        {
                                            Glide.With(this).Load(bitmapdata3).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto3);
                                        }
                                        if (base64string4 != "")
                                        {
                                            Glide.With(this).Load(bitmapdata4).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto4);
                                        }
                                        if (base64string5 != "")
                                        {
                                            Glide.With(this).Load(bitmapdata5).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto5);
                                        }
                                        if (base64string6 != "")
                                        {
                                            Glide.With(this).Load(bitmapdata6).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto6);
                                        }
                                        if (base64string7 != "")
                                        {
                                            Glide.With(this).Load(bitmapdata7).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto7);
                                        }
                                        if (base64string8 != "")
                                        {
                                            Glide.With(this).Load(bitmapdata8).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(count))).Into(buktifoto8);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    progressDialog.Dismiss();
                                }
                                progressDialog.Dismiss();
                            });
                        })).Start();
                    }
                };

            }
            catch (WebException ex)
            {

            }
            browser.SetWebViewClient(new WebViewClient());
            browser.Settings.JavaScriptEnabled = true;
            browser.AddJavascriptInterface(new JSInterface3(this), "JSInterface3");


            btnsubmit.Click += delegate
            {
                countfoto = 0;
                count = 0;
                if (txtNamaSupir.Text != "" && spNoKendaraan.SelectedItem.ToString() != "No Selected Item" && spNoKendaraan.SelectedItem.ToString() != "")
                {
                    if (sharedPreferences.GetString("bagian", null) == "SCR")
                    {
                        if (Convert.ToBase64String(bitmapdata).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata2).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata3).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata4).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata5).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata6).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata7).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata8).Replace("A", "") != "")
                        {

                            using (_dialogBuilder = new Android.App.AlertDialog.Builder(this))
                            {

                                _dialogBuilder.SetMessage("Anda yakin?");
                                _dialogBuilder.SetCancelable(false);
                                _dialogBuilder.SetPositiveButton("OK", ok);
                                _dialogBuilder.SetNegativeButton("Cancel", cancel);
                                //_dialogBuilder.SetNegativeButton("Cancel", BatalAction);
                                alertdialog = _dialogBuilder.Create();

                                alertdialog.Show();
                            }

                        }
                        else
                        {
                            Toast.MakeText(this, "Mohon melengkapi Foto, Minimal Satu Foto!", ToastLength.Long).Show();
                        }
                    }
                    else
                    {
                        if (spExp.SelectedItem.ToString() != "No Selected Item" && spExp.SelectedItem.ToString() != "")
                        {
                            if ((Convert.ToBase64String(bitmapdata).Replace("A", "") != "" && Convert.ToBase64String(bitmapdata2).Replace("A", "") != "") || Convert.ToBase64String(bitmapdata3).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata4).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata5).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata6).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata7).Replace("A", "") != "" || Convert.ToBase64String(bitmapdata8).Replace("A", "") != "")
                            {

                                using (_dialogBuilder = new Android.App.AlertDialog.Builder(this))
                                {

                                    _dialogBuilder.SetMessage("Anda yakin?");
                                    _dialogBuilder.SetCancelable(false);
                                    _dialogBuilder.SetPositiveButton("OK", ok);
                                    _dialogBuilder.SetNegativeButton("Cancel", cancel);
                                    //_dialogBuilder.SetNegativeButton("Cancel", BatalAction);
                                    alertdialog = _dialogBuilder.Create();

                                    alertdialog.Show();
                                }

                            }
                            else
                            {
                                Toast.MakeText(this, "Mohon melengkapi Foto, Minimal Satu Foto!", ToastLength.Long).Show();
                            }
                        }
                        else
                        {
                            Toast.MakeText(this, "Mohon melengkapi No Po", ToastLength.Long).Show();
                        }
                    }
                }
                else
                {
                    Toast.MakeText(this, "Mohon melengkapi No Polisi dan Nama Supir!", ToastLength.Long).Show();
                }
            };
        }
        private void ok(object sender, DialogClickEventArgs e)
        {
            _dialogBuilder.Dispose();
            alertdialog.Dismiss();
            progressShow = ProgressDialog.Show(this, "", "Loading...", true);
            progressShow.SetProgressStyle(ProgressDialogStyle.Spinner);
            browser.LoadUrl("javascript:show1();");
        }
        public void deleteImage()
        {
            new Thread(new ThreadStart(delegate
            {
                RunOnUiThread(() =>
                {

                    buktifoto.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    buktifoto2.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    buktifoto3.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    buktifoto4.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    buktifoto5.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    buktifoto6.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    buktifoto7.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    buktifoto8.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.camera));

                    if (output != null)
                    {
                        if (output.Exists())
                        {
                            File.Delete(output.AbsolutePath);
                        }
                    }
                    if (output2 != null)
                    {
                        if (output2.Exists())
                        {
                            File.Delete(output2.AbsolutePath);
                        }
                    }
                    if (output3 != null)
                    {
                        if (output3.Exists())
                        {
                            File.Delete(output3.AbsolutePath);
                        }
                    }
                    if (output4 != null)
                    {
                        if (output4.Exists())
                        {
                            File.Delete(output4.AbsolutePath);
                        }
                    }
                    if (output5 != null)
                    {
                        if (output5.Exists())
                        {
                            File.Delete(output5.AbsolutePath);
                        }
                    }
                    if (output6 != null)
                    {
                        if (output6.Exists())
                        {
                            File.Delete(output6.AbsolutePath);
                        }
                    }
                    if (output7 != null)
                    {
                        if (output7.Exists())
                        {
                            File.Delete(output7.AbsolutePath);
                        }
                    }
                    if (output8 != null)
                    {
                        if (output8.Exists())
                        {
                            File.Delete(output8.AbsolutePath);
                        }
                    }
                    Thread.Sleep(500);
                    progressShow.Dismiss();
                });
            })).Start();
        }
        private void cancel(object sender, DialogClickEventArgs e)
        {
            _dialogBuilder.Dispose();
            alertdialog.Dismiss();
        }
        public override void OnBackPressed()
        {
            if (countback == 0)
            {
                Toast.MakeText(this, "Tekan sekali lagi untuk keluar", ToastLength.Short).Show();
                countback++;
            }
            else
            {
                if (output != null)
                {
                    if (output.Exists())
                    {
                        File.Delete(output.AbsolutePath);
                    }
                }
                if (output2 != null)
                {
                    if (output2.Exists())
                    {
                        File.Delete(output2.AbsolutePath);
                    }
                }
                if (output3 != null)
                {
                    if (output3.Exists())
                    {
                        File.Delete(output3.AbsolutePath);
                    }
                }
                if (output4 != null)
                {
                    if (output4.Exists())
                    {
                        File.Delete(output4.AbsolutePath);
                    }
                }
                if (output5 != null)
                {
                    if (output5.Exists())
                    {
                        File.Delete(output5.AbsolutePath);
                    }
                }
                if (output6 != null)
                {
                    if (output6.Exists())
                    {
                        File.Delete(output6.AbsolutePath);
                    }
                }
                if (output7 != null)
                {
                    if (output7.Exists())
                    {
                        File.Delete(output7.AbsolutePath);
                    }
                }
                if (output8 != null)
                {
                    if (output8.Exists())
                    {
                        File.Delete(output8.AbsolutePath);
                    }
                }

                countback = 0;
                Intent i = new Intent(this, typeof(home));
                StartActivity(i);
                Finish();
                base.OnBackPressed();

            }



        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {


            if (requestCode == 1)
            {
                if (output.Exists())
                {
                    Java.IO.File imgFile = new Java.IO.File(output.AbsolutePath);
                    if (imgFile.Exists())
                    {
                        MemoryStream bos = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos);
                        bitmapdata = bos.ToArray();

                        Glide.With(this).Load(imgFile.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto);


                        countfoto++;
                    };
                }
            }
            else if (requestCode == 2)
            {
                if (output2.Exists())
                {
                    Java.IO.File imgFile2 = new Java.IO.File(output2.AbsolutePath);
                    if (imgFile2.Exists())
                    {
                        MemoryStream bos2 = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile2.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos2);
                        bitmapdata2 = bos2.ToArray();

                        Glide.With(this).Load(imgFile2.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto2);

                        countfoto++;
                    };
                }
            }

            else if (requestCode == 3)
            {
                if (output3.Exists())
                {
                    Java.IO.File imgFile3 = new Java.IO.File(output3.AbsolutePath);
                    if (imgFile3.Exists())
                    {
                        MemoryStream bos3 = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile3.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos3);
                        bitmapdata3 = bos3.ToArray();

                        Glide.With(this).Load(imgFile3.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto3);

                        countfoto++;
                    };
                }
            }
            else if (requestCode == 4)
            {
                if (output4.Exists())
                {
                    Java.IO.File imgFile4 = new Java.IO.File(output4.AbsolutePath);
                    if (imgFile4.Exists())
                    {
                        MemoryStream bos4 = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile4.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos4);
                        bitmapdata4 = bos4.ToArray();

                        Glide.With(this).Load(imgFile4.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto4);

                        countfoto++;
                    };
                }
            }
            else if (requestCode == 5)
            {
                if (output5.Exists())
                {
                    Java.IO.File imgFile5 = new Java.IO.File(output5.AbsolutePath);
                    if (imgFile5.Exists())
                    {
                        MemoryStream bos5 = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile5.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos5);
                        bitmapdata5 = bos5.ToArray();

                        Glide.With(this).Load(imgFile5.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto5);

                        countfoto++;
                    };
                }
            }
            else if (requestCode == 6)
            {
                if (output6.Exists())
                {
                    Java.IO.File imgFile6 = new Java.IO.File(output6.AbsolutePath);
                    if (imgFile6.Exists())
                    {
                        MemoryStream bos6 = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile6.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos6);
                        bitmapdata6 = bos6.ToArray();

                        Glide.With(this).Load(imgFile6.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto6);

                        countfoto++;
                    };
                }
            }
            else if (requestCode == 7)
            {
                if (output7.Exists())
                {
                    Java.IO.File imgFile7 = new Java.IO.File(output7.AbsolutePath);
                    if (imgFile7.Exists())
                    {
                        MemoryStream bos7 = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile7.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos7);
                        bitmapdata7 = bos7.ToArray();

                        Glide.With(this).Load(imgFile7.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto7);

                        countfoto++;
                    };
                }
            }
            else if (requestCode == 8)
            {
                if (output8.Exists())
                {
                    Java.IO.File imgFile8 = new Java.IO.File(output8.AbsolutePath);
                    if (imgFile8.Exists())
                    {
                        MemoryStream bos8 = new MemoryStream();
                        BitmapFactory.DecodeFile(imgFile8.AbsolutePath).Compress(CompressFormat.Jpeg, 50, bos8);
                        bitmapdata8 = bos8.ToArray();

                        Glide.With(this).Load(imgFile8.AbsolutePath).Apply(RequestOptions.SkipMemoryCacheOf(true)).Apply(RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None)).Apply(RequestOptions.SignatureOf(new Com.Bumptech.Glide.Signature.ObjectKey(countfoto))).Into(buktifoto8);

                        countfoto++;
                    };
                }
            }

        }
    }

    public class JSInterface3 : Java.Lang.Object
    {
        Context mContext;
        public JSInterface3(Context c)
        {
            mContext = c;
        }
        [Export]
        [JavascriptInterface]
        public void onShare(string value, string message)
        {

            try
            {
                
                string[] valuesplit = value.Split('_');
                if (formkeluar.count == 0)
                {


                    if (formkeluar.rdnew.Checked)
                    {
                        if (formkeluar.vendorcode == "")
                        {
                            formkeluar.vendorcode = formkeluar.txtNamaSupplier.Text.ToString();
                        }
                        formkeluar.MyClient.Insertk3lKirimHeader(formkeluar.vendorcode, formkeluar.spNoKendaraan.SelectedItem.ToString(), formkeluar.txtSJNo.Text.ToString(), formkeluar.txtNamaProduk.Text.ToString(), formkeluar.txtTujuan.Text.ToString(), formkeluar.spExp.SelectedItem.ToString(), formkeluar.txtNamaSupir.Text.ToString(), formkeluar.sharedPreferences.GetString("UserId", null), formkeluar.sharedPreferences.GetString("bagian", null), "", formkeluar.bitmapdata, formkeluar.bitmapdata2, formkeluar.bitmapdata3, formkeluar.bitmapdata4, formkeluar.bitmapdata5, formkeluar.bitmapdata6, formkeluar.bitmapdata7, formkeluar.bitmapdata8);
                        formkeluar.count++;
                    }
                    else
                    {
                        if (formkeluar.vendorcode == "")
                        {
                            formkeluar.vendorcode = formkeluar.txtNamaSupplier.Text.ToString();
                        }

                        formkeluar.MyClient.Insertk3lKirimHeader(formkeluar.vendorcode, formkeluar.spNoKendaraan.SelectedItem.ToString(), formkeluar.txtSJNo.Text.ToString(), formkeluar.txtNamaProduk.Text.ToString(), formkeluar.txtTujuan.Text.ToString(), formkeluar.spExp.SelectedItem.ToString(), formkeluar.txtNamaSupir.Text.ToString(), formkeluar.sharedPreferences.GetString("UserId", null), formkeluar.sharedPreferences.GetString("bagian", null), formkeluar.spporunningnumber.SelectedItem.ToString(), formkeluar.bitmapdata, formkeluar.bitmapdata2, formkeluar.bitmapdata3, formkeluar.bitmapdata4, formkeluar.bitmapdata5, formkeluar.bitmapdata6, formkeluar.bitmapdata7, formkeluar.bitmapdata8);
                        formkeluar.count++;

                    }

                }
                if (formkeluar.rdnew.Checked)
                {
                    if (valuesplit[0] != "")
                    {
                        formkeluar.MyClient.Insertk3lkirimdetail(formkeluar.vendorcode, formkeluar.spNoKendaraan.SelectedItem.ToString(), formkeluar.txtSJNo.Text.ToString(), formkeluar.spExp.SelectedItem.ToString(), formkeluar.txtNamaSupir.Text.ToString(), valuesplit[0], valuesplit[1], "");
                    }

                }
                else
                {
                    if (valuesplit[0] != "")
                    {
                        formkeluar.MyClient.Insertk3lkirimdetail(formkeluar.vendorcode, formkeluar.spNoKendaraan.SelectedItem.ToString(), formkeluar.txtSJNo.Text.ToString(), formkeluar.spExp.SelectedItem.ToString(), formkeluar.txtNamaSupir.Text.ToString(), valuesplit[0], valuesplit[1], formkeluar.spporunningnumber.SelectedItem.ToString());
                    }
                }


                if (message != "")
                {
                    if (!formkeluar.rdedit.Checked)
                    {

                        formkeluar.txtNamaSupplier.Text = "";
                        formkeluar.txtNamaSupir.Text = "";
                        formkeluar.txtSJNo.Text = "";

                        formkeluar.bitmapdata = new byte[byte.MaxValue];
                        formkeluar.bitmapdata2 = new byte[byte.MaxValue];
                        formkeluar.bitmapdata3 = new byte[byte.MaxValue];
                        formkeluar.bitmapdata4 = new byte[byte.MaxValue];
                        formkeluar.bitmapdata5 = new byte[byte.MaxValue];
                        formkeluar.bitmapdata6 = new byte[byte.MaxValue];
                        formkeluar.bitmapdata7 = new byte[byte.MaxValue];
                        formkeluar.bitmapdata8 = new byte[byte.MaxValue];
                    }
                    if (formkeluar.sharedPreferences.GetString("bagian", null) == "SCR")
                    {
                        formkeluar.MyClient.sendmailkendaraan();
                        Toast.MakeText(mContext, "Success", ToastLength.Short).Show();
                    }
                    else
                    {
                        ISharedPreferencesEditor editor = formkeluar.sharedPreferences.Edit();
                        editor.PutString("NoPolisi", formkeluar.spNoKendaraan.SelectedItem.ToString());
                        editor.Commit();

                        Intent i = new Intent(mContext, typeof(formkendaraanmasukgudang));
                        mContext.StartActivity(i);
                        ((formkeluar)mContext).Finish();
                        Toast.MakeText(mContext, "Mohon mengisi Kondisi Kendaraan", ToastLength.Short).Show();
                    }

                }

            }
            catch (WebException ex)
            {

            }
            catch (Exception ex)
            {

            }

        }
        [Export]
        [JavascriptInterface]
        public void onDeleteImage()
        {
            ((formkeluar)mContext).deleteImage();
        }
        [Export]
        [JavascriptInterface]
        public void getValidasi(string value)
        {
            ((formkeluar)mContext).progressShow.Dismiss();
            Toast.MakeText(mContext, value, ToastLength.Short).Show();
        }
    }
}

