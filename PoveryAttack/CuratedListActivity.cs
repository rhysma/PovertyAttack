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
        List<ProviderOrg> items;
        List<ProviderOrg> curatedList;
        int id;

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


            //load the json data to populate a list of objects
            Android.Content.Res.AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("services.json")))
            {
                string json = sr.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<ProviderOrg>>(json);
            }

            //filter the list based on the need and demographic information
            var curatedNeed = from item in items
                          where item.NEED == need
                          select item;

            //TO DO:if they don't check any of the boxes on the previous screen we need to not do this step
            //curatedDemo = curatedNeed.Where(u => demoChecks.Contains(u.DEMOGRAPHICS));
            var checkList = demoChecks.Where(check => check != null).ToList();
            var curatedDemo = (from org in curatedNeed from demo in org.DEMOGRAPHICS from check in checkList where demo == check select org).ToList();

            curatedList = new List<ProviderOrg>();
            foreach (var provider in curatedDemo)
            {
                curatedList.Add(provider);
            }


            //get our listview 
            var lv = FindViewById<ListView>(Resource.Id.providerListView);

            //assign the adapter
            lv.Adapter = new HomeScreenAdapter(this, curatedList);

            

            //we have to register the listview for context menu
            //so that the system knows the behavior to use
            RegisterForContextMenu(lv);
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            if (v.Id == Resource.Id.providerListView)
            {
                var info = (AdapterView.AdapterContextMenuInfo)menuInfo;
                menu.SetHeaderTitle("Choose Action");
                var menuItems = Resources.GetStringArray(Resource.Array.menu);
                for (int i = 0; i < menuItems.Length; i++)
                {
                    menu.Add(Menu.None, i, i, menuItems[i]);
                }
            }
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            var info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
            var index = item.ItemId;
            var menuItem = Resources.GetStringArray(Resource.Array.menu);
            var menuItemName = menuItem[index];
            ProviderOrg contactName = curatedList[info.Position];
            id = info.Position;
            int resourceID = contactName.RESOURCEID;
            var intent = new Intent(this, typeof(ProviderDetailActivity));

            intent.PutExtra("id", resourceID);
            StartActivity(intent);

            //Toast.MakeText(this, string.Format("Selected {0} for item {1}", menuItemName, contactName), ToastLength.Short).Show();

            return true;
        }


    }
}