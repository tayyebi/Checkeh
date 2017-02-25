package com.rexaTB.chekehandroid;

import java.util.Arrays;
import java.util.Comparator;
import java.util.zip.Inflater;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class MenuAdapter_Product extends BaseAdapter {

	static public Class_Product[] products;

	public MenuAdapter_Product(Context context, Class_Product[] rows) {
		if (rows != null) {
			MenuAdapter_Product.products = rows;
		} else if (products != null) {
			Arrays.sort(products, new Comparator<Class_Product>() {
				@Override
				public int compare(Class_Product o1, Class_Product o2) {
					return new StringBuilder().append(o2.getCount()).toString()
							.compareTo(new StringBuilder().append(o1.getCount()).toString());
				}
			});
		}
		inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
	}

	@Override
	public int getCount() {
		return products.length;
	}

	@Override
	public long getItemId(int position) {
		return position;
	}

	@Override
	public Object getItem(int position) {
		return products[position];
	}

	static private LayoutInflater inflater;

	@Override
	public View getView(final int position, View convertView, final ViewGroup parent) {

		if (convertView == null)
			convertView = inflater.inflate(R.layout.menuitem_product, null);

		TextView textview_Title = (TextView) convertView.findViewById(R.id.textview_Title);
		textview_Title.setText(products[position].Name);
		final TextView textview_Count = (TextView) convertView.findViewById(R.id.textview_Count);
		textview_Count.setText(new StringBuilder().append(products[position].Count));

		((Button) convertView.findViewById(R.id.button_Plus)).setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				products[position].Count += 1;
				Class_About.ProductCount += 1;
				textview_Count.setText(new StringBuilder().append(products[position].Count));
			}
		});
		((Button) convertView.findViewById(R.id.button_Minus)).setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				if (products[position].Count > 0) {
					products[position].Count -= 1;
					Class_About.ProductCount -= 1;
					textview_Count.setText(new StringBuilder().append(products[position].Count));
				}
			}
		});

		((Button) convertView.findViewById(R.id.button_Details)).setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Class_About.LastProductId = products[position].Id;

				Intent zoom = new Intent(parent.getContext(), Activity_ProductDetails.class);
				parent.getContext().startActivity(zoom);

			}
		});

		return convertView;
	}
}
