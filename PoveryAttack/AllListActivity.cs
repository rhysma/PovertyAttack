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
    [Activity(Label = "AllListActivity")]
    public class AllListActivity : Activity
    {
        int id;


        List<ProviderOrg> items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AllList);

            //load the json data to populate a list of objects
            Android.Content.Res.AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("services.json")))
            {
                string json = sr.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<ProviderOrg>>(json);
            }

            //get our listview 
            var lv = FindViewById<ListView>(Resource.Id.providerListView);

            //assign the adapter
            lv.Adapter = new HomeScreenAdapter(this, items);

            //we have to register the listview for context menu
            //so that the system knows the behavior to use
            RegisterForContextMenu(lv);

        }

        
        public override bool OnContextItemSelected(IMenuItem item)
        {
            var info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
            var index = item.ItemId;
            var menuItem = Resources.GetStringArray(Resource.Array.menu);
            var menuItemName = menuItem[index];
            if (menuItemName == "Details")
            {
                ProviderOrg contactName = items[info.Position];
                id = info.Position;
                int resourceID = contactName.RESOURCEID;
                var intent = new Intent(this, typeof(ProviderDetailActivity));

                intent.PutExtra("id", resourceID);
                StartActivity(intent);
            }
            if (menuItemName == "Get Directions")
            {
                var org = items[info.Position];
                id = info.Position;
                var providerAddress = $"{org.ADDRESS1} {org.ADDRESS2}, {org.CITY}, {org.STATE}, {org.ZIP}";
                this.launchMap(providerAddress);
            }
            if (menuItemName == "Phone Call")
            {
                var org = items[info.Position];
                var uri = Android.Net.Uri.Parse("tel:" + org.PHONE);
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }
            return true;
        }

        /// <summary>
        /// Open a GoogleMaps instance
        /// </summary>
        /// <param name="providerAddress"></param>
        public void launchMap(string providerAddress)
        {
            //Encode the address
            string encodedAddress = "geo:0,0?q=" + Android.Net.Uri.Encode(providerAddress);
            //Set the variable for the map intent
            var geoUri = Android.Net.Uri.Parse(encodedAddress);
            //Declare the map intent
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            //Start the activity and open the maps application
            StartActivity(mapIntent);
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


    }
}