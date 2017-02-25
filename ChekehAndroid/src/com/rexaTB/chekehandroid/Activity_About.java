package com.rexaTB.chekehandroid;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ImageView;

public class Activity_About extends Activity{

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_about);
		// ((ImageView)findViewById(R.id.imageview_About)).setBackgroundResource(R.drawable.about);
	}

}
