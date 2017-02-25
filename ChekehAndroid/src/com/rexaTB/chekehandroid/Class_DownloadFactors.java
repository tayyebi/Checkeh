package com.rexaTB.chekehandroid;

import java.io.File;
import java.io.FileNotFoundException;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;
import java.util.jar.Attributes.Name;
import java.util.regex.Pattern;

public class Class_DownloadFactors {
	static public Class_Factor[] GetFactors() {

		File file[] = new File(Class_About.MyApplicationContext.getFilesDir() + "/List").listFiles();
		List<Class_Factor> factor_List = new ArrayList<Class_Factor>();

		for (int i = 0; i < file.length; i++) {
			Class_Factor factor = new Class_Factor();
			factor.Name = file[i].getName();
			factor_List.add(factor);
		}

		Class_Factor[] output = new Class_Factor[factor_List.size()];
		output = factor_List.toArray(output);
		return output;
	}

	static public Class_Product[] GetFactorItems(String FactorName) {

		Class_FileManager CFM = new Class_FileManager();

		List<Class_Product> products = new ArrayList<Class_Product>();

		try {
			String data = CFM.Text_Read("List/" + FactorName);
			data = data.substring(1);
			data = data.substring(0, data.length() - 1);

			String[] rows = data.split(Pattern.quote("]["));

			data = null;

			System.gc();

			for (String row : rows) {
				Class_Product product = new Class_Product();

				for (String column : row.split("&")) {
					String[] values = column.split("=");

					if (values[0].equals("Id")) {
						product.Id = values[1];
					} else if (values[0].equals("Name")) {
						product.Name = values[1];
					} else if (values[0].equals("Count")) {
						product.Count = Integer.parseInt(values[1]);
					}
				}
				row = null;
				System.gc();

				products.add(product);
			}

		} catch (FileNotFoundException e) {
		}
		Class_Product[] output = new Class_Product[products.size()];
		output = products.toArray(output);

		products = null;
		System.gc();

		return output;
	}
}
