package com.rexaTB.chekehandroid;

import java.io.IOException;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

public class Activity_SaveList extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_savelist);

		Thread updateList = new Thread(new Runnable() {

			@Override
			public void run() {

				try {
					final ListView listview_ChooseProduct = (ListView) findViewById(R.id.listview_Products);
					MenuAdapter_Product menuadapter_main = new MenuAdapter_Product(getApplicationContext(), null);
					listview_ChooseProduct.setAdapter(menuadapter_main);
					((Button) findViewById(R.id.button_Save)).setOnClickListener(new View.OnClickListener() {
						@Override
						public void onClick(View v) {
							EditText edittext_Title = (EditText) findViewById(R.id.edittext_Title);
							if (!"".equals(edittext_Title.getText().toString())) {

								String data = "";
								for (Class_Product product : MenuAdapter_Product.products) {
									if (product.Count > 0) {
										data += "[";
										data += "Id=" + product.Id;
										data += "&Name=" + product.Name;
										data += "&Count=" + product.Count;
										data += "]";
									}
								}
								Class_FileManager fileManager = new Class_FileManager();
								try {
									fileManager.Text_Write("List/" + edittext_Title.getText().toString(), data);
									if (Class_About.isUserLogin) {
										startActivity(new Intent(Activity_SaveList.this, Activity_Factors.class));
									} else {
										finish();
									}
								} catch (IOException e) {
									Toast.makeText(getApplicationContext(), "خطا در ذخیره فایل توسط سیستم عامل",
											Toast.LENGTH_LONG).show();
								}
							} else {
								Toast.makeText(getApplicationContext(), "لطفا عنوانی را برای این فهرست انتخاب کنید",
										Toast.LENGTH_LONG).show();
							}
						}
					});

				} catch (Exception e) {
					Toast.makeText(getApplicationContext(), "خطا", Toast.LENGTH_LONG).show();
				}
			}
		});
		updateList.run();

	}

}
