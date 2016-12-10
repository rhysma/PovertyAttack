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
    [Activity(Label = "CuratedListActivity")]
    public class CuratedListActivity : Activity
    {
        //path string for the database file
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "providers.db3");
        List<Data.ProviderOrg> items;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CuratedList);

            //get all of the variables that were passed over from the previous activity
            bool male = Intent.GetBooleanExtra("Male", false);
            bool Female = Intent.GetBooleanExtra("Female", false);
            bool Trans = Intent.GetBooleanExtra("Trans", false);
            bool Senior = Intent.GetBooleanExtra("Senior", false);
            bool Minor = Intent.GetBooleanExtra("Minor", false);
            bool Pregnant = Intent.GetBooleanExtra("Pregnant", false);
            bool Children = Intent.GetBooleanExtra("Children", false);
            bool Vet = Intent.GetBooleanExtra("Vet", false);
            bool Disabled = Intent.GetBooleanExtra("Disabled", false);
            bool Uninsured = Intent.GetBooleanExtra("Uninsured", false);
            bool LGBT = Intent.GetBooleanExtra("LGBT", false);
            bool Homeless = Intent.GetBooleanExtra("Homeless", false);


            //setup the db connection
            var db = new SQLiteConnection(dbPath);
            deleteAll();

            //setup a table for an organization
            db.CreateTable<Data.ProviderOrg>();

            //load the json data to populate a list of objects
            Android.Content.Res.AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("services.json")))
            {
                string json = sr.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Data.ProviderOrg>>(json);
            }

            //store the objects into the table
            foreach (var item in items)
            {
                db.Insert(item);
            }

            //get our listview 
            var lv = FindViewById<ListView>(Resource.Id.providerListView);

            //assign the adapter
            lv.Adapter = new HomeScreenAdapter(this, items);

        }

        //a method that deletes all of the records in the table
        //for use in testing the app so we don't fill the DB with
        //records every time we run
        public void deleteAll()
        {
            var db = new SQLiteConnection(dbPath);
            db.Execute("delete from ProviderOrg");
        }
    }
}