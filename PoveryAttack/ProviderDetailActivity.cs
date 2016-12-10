using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using Newtonsoft.Json;

namespace PoveryAttack
{
    [Activity(Label = "ProviderDetailActivity")]
    public class ProviderDetailActivity : Activity
    {
        List<ProviderOrg> items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "providers.db3");

            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ProviderDetail);

            //what provider do we want?
            int resourceID = Intent.GetIntExtra("id", 0);

            //load the json data to populate a list of objects
            Android.Content.Res.AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("services.json")))
            {
                string json = sr.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<ProviderOrg>>(json);
            }

            //get the specific record for the recordID
            var record = from i in items
                                       where i.RESOURCEID == resourceID
                                       select i;

            TextView providerName = FindViewById<TextView>(Resource.Id.providerNameBox);
            providerName.Text = record.RESOURCENAME;
            TextView address1 = FindViewById<TextView>(Resource.Id.address1Box);
            address1.Text = record.ADDRESS1;
            TextView address2 = FindViewById<TextView>(Resource.Id.address2Box);
            address2.Text = record.ADDRESS2;
            string cityStateZip = record.CITY + ", " + record.STATE + " " + record.ZIP;
            TextView city = FindViewById<TextView>(Resource.Id.cityBox);
            city.Text = cityStateZip;


        }
    }
}