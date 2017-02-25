package com.rexaTB.chekehandroid;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;
import android.widget.Toast;

public class Activity_Factors extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_factors);
		
		Thread updateList = new Thread(new Runnable() {

			@Override
			public void run() {

				try {
					final ListView listview_ChooseProduct = (ListView) findViewById(R.id.listview_factors);

					MenuAdapter_Factor menuadapter_factor = new MenuAdapter_Factor(getApplicationContext(),
							Class_DownloadFactors.GetFactors());
					listview_ChooseProduct.setAdapter(menuadapter_factor);

				} catch (Exception e) {
					Toast.makeText(new Activity().getApplicationContext(), "خطا در دریافت اطلاعات از سرور",
							Toast.LENGTH_LONG).show();
				}
			}
		});
		updateList.run();

	}

}
