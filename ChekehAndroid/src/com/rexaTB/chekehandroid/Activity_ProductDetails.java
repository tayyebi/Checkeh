package com.rexaTB.chekehandroid;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.util.concurrent.ExecutionException;

import org.apache.http.client.ClientProtocolException;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.opengl.Visibility;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class Activity_ProductDetails extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_productdetails);

		final TextView textview_Title = (TextView) findViewById(R.id.textview_Title);
		final TextView textview_Description = (TextView) findViewById(R.id.textview_Description);

		Thread updateInfo = new Thread(new Runnable() {

			@Override
			public void run() {

				textview_Description.setVisibility(1);
				DownloadInfo di = new DownloadInfo();
				try {
					String data = di.execute("").get();
					data = data.substring(1);
					data = data.substring(0, data.length() - 1);

					for (String field : data.split(",")) {
						String[] cell = field.split(":");

						cell[0] = cell[0].substring(1);
						cell[0] = cell[0].substring(0, cell[0].length() - 1);

						cell[1] = cell[1].substring(1);
						cell[1] = cell[1].substring(0, cell[1].length() - 1);

						if (cell[0].equals("ProductName")) {
							textview_Title.setText(cell[1]);
						} else if (cell[0].equals("ProductDescription")) {
							textview_Description.setText(cell[1]);
						}
					}

				} catch (Exception e) {
					e.printStackTrace();
				}

				SetImage si = new SetImage();
				try {
					Toast.makeText(getApplicationContext(), si.execute("").get(), Toast.LENGTH_LONG).show();
				} catch (Exception e) {
				}
			}
		});
		updateInfo.run();
	}

	private class SetImage extends AsyncTask<String, String, String> {

		@Override
		protected String doInBackground(String... params) {
			try {
				ImageView imageview_Picture = (ImageView) findViewById(R.id.imageview_Picture);
				BitmapFactory.Options bmOptions;
				bmOptions = new BitmapFactory.Options();
				bmOptions.inSampleSize = 1;
				Bitmap bm = LoadImage(Class_About.Serverlocation.substring(0, Class_About.Serverlocation.length() - 4)
						+ "Download/ProductImage/" + Class_About.LastProductId, bmOptions);
				imageview_Picture.setImageBitmap(bm);
				return null;
			} catch (Exception e) {
				return "تصویر بارگزاری نشد";
			}
		}

	}

	private Bitmap LoadImage(String URL, BitmapFactory.Options options) throws IOException {
		Bitmap bitmap = null;
		InputStream in = null;

		in = OpenHttpConnection(URL);
		bitmap = BitmapFactory.decodeStream(in, null, options);
		in.close();

		return bitmap;
	}

	private InputStream OpenHttpConnection(String strURL) throws IOException {
		InputStream inputStream = null;
		URL url = new URL(strURL);
		URLConnection conn = url.openConnection();

		HttpURLConnection httpConn = (HttpURLConnection) conn;
		httpConn.setRequestMethod("GET");
		httpConn.connect();

		if (httpConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
			inputStream = httpConn.getInputStream();
		}

		return inputStream;
	}

	private class DownloadInfo extends AsyncTask<String, String, String> {

		@Override
		protected String doInBackground(String... params) {
			Class_WebClient webclient = new Class_WebClient();
			try {
				return webclient.Get("Products", "/" + Class_About.LastProductId);
			} catch (ClientProtocolException e) {
				Toast.makeText(Class_About.MyApplicationContext, "خطا در دریافت اطلاعات از سرور", Toast.LENGTH_LONG)
						.show();
			} catch (IOException e) {
				Toast.makeText(Class_About.MyApplicationContext, "خطا در مدیریت سیستم فایل", Toast.LENGTH_LONG).show();
			}
			return null;
		}

	}
}