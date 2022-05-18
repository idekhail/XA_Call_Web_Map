using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android;
using Android.Content;

namespace XA_Call_Web_Map
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var website = FindViewById<EditText>(Resource.Id.website);
            var mobile = FindViewById<Button>(Resource.Id.mobile);
            var call = FindViewById<Button>(Resource.Id.call);
            var map = FindViewById<Button>(Resource.Id.map);
            var web = FindViewById<Button>(Resource.Id.web);
            var clear = FindViewById<Button>(Resource.Id.clear);



            // Call Me
            call.Click += delegate
            {
                var url = Android.Net.Uri.Parse("tel:" + mobile.Text);
                var i = new Intent(Intent.ActionDial, url);
                StartActivity(i);

                //try
                //{
                //    PhoneDialer.Open(mobile.Text);
                //}
                //catch (ArgumentNullException anEx)
                //{
                //    // Number was null or white space
                //}
                //catch (FeatureNotSupportedException ex)
                //{
                //    // Phone Dialer is not supported on this device.
                //}
                //catch (Exception ex)
                //{
                //    // Other error has occurred.
                //}
            };
            //Open Web
            web.Click += delegate
            {
                var url = Android.Net.Uri.Parse("https://" + website.Text);
                var i = new Intent(Intent.ActionView, url);
                StartActivity(i);
            };

            map.Click += delegate
            {
                var latitude = website.Text;
                var longitude = mobile.Text;
                //  ( "geo:27.477474,43.y7554")
                var url = Android.Net.Uri.Parse("geo:" + latitude + "," + longitude);
                var i = new Intent(Intent.ActionView, url);
                StartActivity(i);
            };

        }
    }
}