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
        List<Data.ProviderOrg> curatedList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CuratedList);

            //get all of the variables that were passed over from the previous activity
            string[] demoChecks = new string[12];
            demoChecks[0] = Intent.GetStringExtra("Male");
            demoChecks[1] = Intent.GetStringExtra("Female");
            demoChecks[2] = Intent.GetStringExtra("Trans");
            demoChecks[3] = Intent.GetStringExtra("Senior");
            demoChecks[4] = Intent.GetStringExtra("Minor");
            demoChecks[5] = Intent.GetStringExtra("Pregnant");
            demoChecks[6] = Intent.GetStringExtra("Children");
            demoChecks[7] = Intent.GetStringExtra("Vet");
            demoChecks[8] = Intent.GetStringExtra("Disabled");
            demoChecks[9] = Intent.GetStringExtra("Uninsured");
            demoChecks[10] = Intent.GetStringExtra("LGBT");
            demoChecks[11] = Intent.GetStringExtra("Homeless");
            //this is the need information from the button they clicked on the previous activity
            string need = Intent.GetStringExtra("need") ?? "Data not available";

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

            foreach (var demoItem in demoChecks)
            {
                
            }

            //filter the list based on the need and demographic information
            IEnumerable<Data.ProviderOrg> curatedNeed = from item in items
                          where item.NEED == need
                          select item;

            //IEnumerable<Data.ProviderOrg> curatedDemo = from item in curatedNeed
            //                                            where demoChecks.Contains(item.DEMOGRAPHICS)
            //                                            select item;

            curatedList = new List<Data.ProviderOrg>();
            foreach (var provider in curatedNeed)
            {
                curatedList.Add(provider);
            }


            //get our listview 
            var lv = FindViewById<ListView>(Resource.Id.providerListView);

            //assign the adapter
            lv.Adapter = new HomeScreenAdapter(this, curatedList);

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