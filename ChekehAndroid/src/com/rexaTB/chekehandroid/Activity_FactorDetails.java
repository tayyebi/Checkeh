package com.rexaTB.chekehandroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

public class Activity_FactorDetails extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_factordetails);

		final Button button_Send = (Button) findViewById(R.id.button_Send);
		final Button button_Delete = (Button) findViewById(R.id.button_Delete);

		Thread updateList = new Thread(new Runnable() {

			@Override
			public void run() {

				try {
					final ListView listview_Products = (ListView) findViewById(R.id.listview_Products);

					MenuAdapter_Product menuadapter_main = new MenuAdapter_Product(getApplicationContext(),
							Class_DownloadFactors.GetFactorItems(Class_About.LastFactorName));
					listview_Products.setAdapter(menuadapter_main);

					if (Class_About.isUserLogin)
						button_Send.setEnabled(true);
					button_Delete.setEnabled(true);

					button_Delete.setOnClickListener(new View.OnClickListener() {

						@Override
						public void onClick(View v) {

							Class_FileManager CFM = new Class_FileManager();
							CFM.Delete("List/" + Class_About.LastFactorName);

							finish();
						}
					});

					button_Send.setOnClickListener(new View.OnClickListener() {
						@Override
						public void onClick(View v) {
						}
					});

				} catch (Exception e) {
					Toast.makeText(new Activity().getApplicationContext(), "خطا در دریافت اطلاعات", Toast.LENGTH_LONG)
							.show();
				}
			}
		});
		updateList.run();
	}
}
