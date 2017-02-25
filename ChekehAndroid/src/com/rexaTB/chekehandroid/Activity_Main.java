package com.rexaTB.chekehandroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

public class Activity_Main extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		Class_About.MyApplicationContext = getApplicationContext();

		Class_FileManager CFM = new Class_FileManager();

		CFM.CreateFolder("Temp");
		CFM.CreateFolder("List");

		final Button button_Confirm = (Button) findViewById(R.id.button_Confirm);
		final Button button_Refresh = (Button) findViewById(R.id.button_Refresh);
		final ListView listview_ChooseProduct = (ListView) findViewById(R.id.listview_Products);

		try {int i = 0;
			for (String row : CFM.Text_Read("Temp/Login.txt").split("&")) {
				
				String[] fields = row.split("=");

				if (fields[0].equals("Username")) {
					Class_About.Username = fields[1];
					i++;
				} else if (fields[0].equals("Password")) {
					Class_About.Password = fields[1];
					i++;
				}
				if (i == 2)
					Class_About.isUserLogin = true;
			}
		} catch (Exception e) {

		}

		new Thread(new Runnable() {

			@Override
			public void run() {

				try {

					MenuAdapter_Product menuadapter_main = new MenuAdapter_Product(getApplicationContext(),
							Class_DownloadProducts.GetOfflineList());
					listview_ChooseProduct.setAdapter(menuadapter_main);

					button_Confirm.setEnabled(true);

				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		}).run();

		button_Refresh.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Thread updateList = new Thread(new Runnable() {

					@Override
					public void run() {

						try {

							MenuAdapter_Product menuadapter_main = new MenuAdapter_Product(getApplicationContext(),
									Class_DownloadProducts.GetProducts());
							listview_ChooseProduct.setAdapter(menuadapter_main);

							button_Confirm.setEnabled(true);

						} catch (Exception e) {
							Toast.makeText(new Activity().getApplicationContext(), "خطا در دریافت اطلاعات از سرور",
									Toast.LENGTH_LONG).show();
						}
					}
				});
				updateList.run();
			}
		});
		button_Confirm.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				if (Class_About.ProductCount > 0) {
					startActivity(new Intent(Activity_Main.this, Activity_SaveList.class));
				} else {
					Toast.makeText(Class_About.MyApplicationContext, "لطفا محصولی را به لیست خود اضافه کنید!",
							Toast.LENGTH_LONG).show();
				}
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main_menu, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.item_UserRegister) {
			startActivity(new Intent(Activity_Main.this, Activity_UserRegister.class));
			return true;
		} else if (id == R.id.item_UserLogin) {
			startActivity(new Intent(Activity_Main.this, Activity_Login.class));
			return true;
		} else if (id == R.id.item_PrevLists) {
			startActivity(new Intent(Activity_Main.this, Activity_Factors.class));
			return true;
		} else if (id == R.id.item_About) {
			startActivity(new Intent(Activity_Main.this, Activity_About.class));
			return true;
		}
		return super.onOptionsItemSelected(item);
	}
}
