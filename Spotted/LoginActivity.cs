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
using Android.Support.V7.App;

namespace Spotted
{
    [Activity(Label = "Login", MainLauncher =true)]
    public class LoginActivity : AppCompatActivity {
        EditText login;
        EditText password;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            // Create your application here
            login = FindViewById<EditText>(Resource.Id.login);
            password = FindViewById<EditText>(Resource.Id.password);


            Button btnLogar = FindViewById<Button>(Resource.Id.btnLogar);
            btnLogar.Click += handleClick;

        }

        public void handleClick (object sender, EventArgs e){
            LoginFactory lf = new LoginFactory();
            string token = lf.login(login.Text, password.Text);

            Toast.MakeText(this, token, ToastLength.Long).Show();
        }
    }
}