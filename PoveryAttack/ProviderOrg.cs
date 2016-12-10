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
using SQLite;

namespace PoveryAttack
{
    public class ProviderOrg
    {
        [PrimaryKey]
        public int RESOURCEID
        {
            get;
            set;
        }
        public string RESOURCENAME;
        public string ADDRESS1;
        public string ADDRESS2;
        public string CITY;
        public string STATE;
        public string ZIP;
        public string COUNTY;
        public string PHONE;
        public string FAX;
        public string TTY;
        public string TOLLFREE;
        public string HOTLINE;
        public string EMAIL;
        public string WEBPAGE;
        public string FACEBOOKURL;
        public string TWITTER;
        public string SERVICES;
        public string NEED;
        public string[] DEMOGRAPHICS;

        public override string ToString()
        {
            return RESOURCENAME + "\n" + SERVICES;
        }


    }
}