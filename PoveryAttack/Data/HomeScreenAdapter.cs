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

namespace PoveryAttack
{
    class HomeScreenAdapter : BaseAdapter<Data.ProviderOrg>
    {
        List<Data.ProviderOrg> myProviders;
        Activity context;

        public HomeScreenAdapter(Activity context, List<Data.ProviderOrg> contacts) : base()
        {
            this.myProviders = contacts;
            this.context = context;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Data.ProviderOrg this[int position]
        {
            get
            {
                return myProviders[position];
            }
        }

        public override int Count
        {
            get
            {
                return myProviders.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //this sets up to re-use an existing view if one is available
            View view = convertView;
            if(view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = myProviders[position].ToString();
            return view;
        }
    }
}