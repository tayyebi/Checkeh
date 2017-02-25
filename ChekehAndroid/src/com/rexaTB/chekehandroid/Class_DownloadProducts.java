package com.rexaTB.chekehandroid;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.regex.Pattern;

import android.os.AsyncTask;

public class Class_DownloadProducts {
	static public Class_Product[] GetOfflineList() throws IOException {

		Class_FileManager CFM = new Class_FileManager();
		String data = CFM.Text_Read("Temp/_MainList.txt");

		List<Class_Product> product_List = new ArrayList<Class_Product>();

		String[] rows = data.split(Pattern.quote("},{"));


		for (String row : rows) {
			Class_Product product = new Class_Product();

			for (String column : row.split(",")) {
				String[] values = column.split(":");

				values[0] = values[0].substring(1);
				values[0] = values[0].substring(0, values[0].length() - 1);

				values[1] = values[1].substring(1);
				values[1] = values[1].substring(0, values[1].length() - 1);

				if (values[0].equals("ProductId")) {
					product.Id = values[1];
				} else if (values[0].equals("ProductName")) {
					product.Name = values[1];
				}
			}
			product_List.add(product);
		}

		Class_Product[] output = new Class_Product[product_List.size()];
		output = product_List.toArray(output);

		product_List = null;
		System.gc();

		CFM.Text_Write("_MainList", data);

		data = null;
		System.gc();

		return output;
	}

	static public Class_Product[] GetProducts() throws IOException, InterruptedException, ExecutionException {

		DownloadProducts dp = new DownloadProducts();

		String data = dp.execute("").get();

		data = data.substring(2);
		data = data.substring(0, data.length() - 2);

		List<Class_Product> product_List = new ArrayList<Class_Product>();

		String[] rows = data.split(Pattern.quote("},{"));

		dp = null;

		System.gc();

		for (String row : rows) {
			Class_Product product = new Class_Product();

			for (String column : row.split(",")) {
				String[] values = column.split(":");

				values[0] = values[0].substring(1);
				values[0] = values[0].substring(0, values[0].length() - 1);

				values[1] = values[1].substring(1);
				values[1] = values[1].substring(0, values[1].length() - 1);

				if (values[0].equals("ProductId")) {
					product.Id = values[1];
				} else if (values[0].equals("ProductName")) {
					product.Name = values[1];
				}
			}
			product_List.add(product);
		}

		Class_Product[] output = new Class_Product[product_List.size()];
		output = product_List.toArray(output);

		product_List = null;
		System.gc();

		Class_FileManager CFM = new Class_FileManager();
		CFM.Text_Write("Temp/_MainList", data);

		data = null;
		System.gc();

		return output;

	}
}

class DownloadProducts extends AsyncTask<String, String, String> {

	@Override
	protected String doInBackground(String... params) {

		try {
			Class_WebClient webclient = new Class_WebClient();
			return webclient.Get("Products", "");
		} catch (Exception e) {
			return e.getMessage();
		}
	}

}