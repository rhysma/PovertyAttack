using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PoveryAttack
{
    [Activity(Label = "PovertyAttack", MainLauncher = true, Icon = "@android:style/Theme.Light")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            ImageButton foodButton = FindViewById<ImageButton>(Resource.Id.foodButton);
            foodButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DemographicsActivity));
                intent.PutExtra("need", "Food");
                StartActivity(intent);
            };

            ImageButton shelterButton = FindViewById<ImageButton>(Resource.Id.shelterButton);
            shelterButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DemographicsActivity));
                intent.PutExtra("need", "Shelter");
                StartActivity(intent);
            };

            ImageButton healthButton = FindViewById<ImageButton>(Resource.Id.healthButton);
            healthButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DemographicsActivity));
                intent.PutExtra("need", "Health");
                StartActivity(intent);
            };

            ImageButton transpoButton = FindViewById<ImageButton>(Resource.Id.transpoButton);
            transpoButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DemographicsActivity));
                intent.PutExtra("need", "Transpo");
                StartActivity(intent);
            };
        }
    }
}

