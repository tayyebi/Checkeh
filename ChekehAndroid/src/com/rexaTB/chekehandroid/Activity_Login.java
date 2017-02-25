package com.rexaTB.chekehandroid;

import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Activity_Login extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_login);

		((Button) findViewById(R.id.button_Login)).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				// Post login data to server

				EditText et_Username = (EditText) findViewById(R.id.edittext_Username);
				EditText et_Password = (EditText) findViewById(R.id.edittext_Password);

				String Username = et_Username.getText().toString();
				String Password = et_Password.getText().toString();

				GET get = new GET();
				String data = "";
				try {
					data = get.execute(new StringBuilder("Username=" + Username + "&Password=" + Password).toString())
							.get();
				} catch (Exception e) {

				}

				if (data.equals("\"user\"")) {
					// Login done
					Class_About.isUserLogin = true;
					Class_About.Username = Username;
					Class_About.Password = Password;

					// Save login to text file
					try {
						Class_FileManager CFM = new Class_FileManager();
						CFM.Text_Write("Temp/Login", "Username=" + Username + "&Password=" + Password);
					} catch (Exception e) {
					}

					// Return to main
					finish();
				} else {
					Toast.makeText(getApplicationContext(), "نام کاربری یا کلمه عبور معتبر نیست", Toast.LENGTH_LONG)
							.show();
				}
			}
		});
	}

	class GET extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... Params) {

			Class_WebClient client = new Class_WebClient();
			try {
				return client.Get("Login", "?" + Params[0]);
			} catch (Exception e) {
				return null;
			}
		}

	}

}
