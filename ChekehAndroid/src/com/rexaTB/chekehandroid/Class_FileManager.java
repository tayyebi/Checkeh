package com.rexaTB.chekehandroid;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class Class_FileManager {
	public void Delete(String FileName) {
		new File(Class_About.MyApplicationContext.getFilesDir() + "/" + FileName).delete();
	}

	public String Text_Read(String FileName) throws FileNotFoundException {

		return new Scanner(new File(Class_About.MyApplicationContext.getFilesDir() + "/" + FileName), "UTF-8")
				.useDelimiter("\\A").next();

	}

	public void Text_Write(String Filename, String Data) throws IOException {

		File outputFile = new File(Class_About.MyApplicationContext.getFilesDir(), Filename + ".txt");
		FileWriter writer = new FileWriter(outputFile);
		writer.append(Data);
		writer.flush();
		writer.close();
	}

	public void CreateFolder(String Name) {
		File dir = new File(Class_About.MyApplicationContext.getFilesDir() + "/" + Name);
		if (dir.exists() && dir.isDirectory()) {
			// Do nothing!
		} else {
			dir.mkdirs();
		}
	}
}
