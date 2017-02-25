package com.rexaTB.chekehandroid;

import java.util.Arrays;
import java.util.Comparator;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.TextView;

public class MenuAdapter_Factor extends BaseAdapter {

	static public Class_Factor[] factors;

	public MenuAdapter_Factor(Context context, Class_Factor[] rows) {

		MenuAdapter_Factor.factors = rows;

		inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
	}

	@Override
	public int getCount() {
		return factors.length;
	}

	@Override
	public long getItemId(int position) {
		return position;
	}

	@Override
	public Object getItem(int position) {
		return factors[position];
	}

	static private LayoutInflater inflater;

	@Override
	public View getView(final int position, View convertView, final ViewGroup parent) {

		if (convertView == null)
			convertView = inflater.inflate(R.layout.menuitem_factor, null);

		TextView textview_Title = (TextView) convertView.findViewById(R.id.textview_Title);
		textview_Title.setText(factors[position].GetName().substring(0, factors[position].GetName().length() - 4));

		Button button_Details = (Button) convertView.findViewById(R.id.button_Details);
		button_Details.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Class_About.LastFactorName = factors[position].GetName();
				parent.getContext().startActivity(new Intent(parent.getContext(), Activity_FactorDetails.class));
			}
		});

		return convertView;
	}

}
