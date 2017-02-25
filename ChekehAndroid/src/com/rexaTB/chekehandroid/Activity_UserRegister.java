package com.rexaTB.chekehandroid;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.EditTextPreference;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Activity_UserRegister extends Activity {
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_userregister);

		((Button) findViewById(R.id.button_Register)).setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// Regsiter user
				try {
					EditText et_FirstName = (EditText) findViewById(R.id.edittext_Firstname);
					EditText et_LastName = (EditText) findViewById(R.id.edittext_Lastname);
					EditText et_Password = (EditText) findViewById(R.id.edittext_Password);
					EditText et_ConfirmPass = (EditText) findViewById(R.id.edittext_Confirm);
					EditText et_Username = (EditText) findViewById(R.id.edittext_Username);

					String PhoneNumber = "";

					if (et_Password.getText().toString().equals(et_ConfirmPass.getText().toString())) {
						List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>(5);
						nameValuePairs.add(new BasicNameValuePair("FirstName", et_FirstName.getText().toString()));
						nameValuePairs.add(new BasicNameValuePair("LastName", et_LastName.getText().toString()));
						nameValuePairs.add(new BasicNameValuePair("Password", et_Password.getText().toString()));
						nameValuePairs.add(new BasicNameValuePair("Username", et_Username.getText().toString()));
						nameValuePairs.add(new BasicNameValuePair("PhoneNumber", PhoneNumber));

						// Do post in background
						POST post = new POST();
						post.execute(nameValuePairs);

						// redirect to login activity
						startActivity(new Intent(Activity_UserRegister.this, Activity_Login.class));
					} else {
						Toast.makeText(getApplicationContext(), "کلمه عبور با تکرار آن همخوانی ندارد",
								Toast.LENGTH_LONG).show();
					}
				} catch (Exception e) {
					Toast.makeText(getApplicationContext(), "مشکل هرچه باشد به خاطر سرور است", Toast.LENGTH_LONG)
							.show();
				}

			}
		});
	}

	class MyParams {
		String Route;
		List<NameValuePair> NameValuePairs;

		public MyParams(String Route, List<NameValuePair> NameValuePairs) {
			this.Route = Route;
			this.NameValuePairs = NameValuePairs;
		}
	}

	class POST extends AsyncTask<List<NameValuePair>, String, String> {
		
		@Override
		protected String doInBackground(List<NameValuePair>... NameValuePairs) {
			Class_WebClient webClient = new Class_WebClient();
			try {
				return webClient.Post("Users", NameValuePairs[0]);
			} catch (Exception e) {
				return null;
			}
		}

	}
}