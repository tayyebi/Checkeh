package com.rexaTB.chekehandroid;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import android.os.AsyncTask;
import android.util.Log;

public class Class_WebClient {

	String Post(String Route, List<NameValuePair> nameValuePairs) throws ClientProtocolException, IOException {

		HttpClient httpClient = new DefaultHttpClient();
		HttpPost httpPost = new HttpPost(new String(Class_About.Serverlocation + Route));
		httpPost.setEntity(new UrlEncodedFormEntity(nameValuePairs));
		HttpResponse response = httpClient.execute(httpPost);
		return response.toString();

	}

	String Get(String Route, String Params) throws ClientProtocolException, IOException {
		HttpClient httpClient = new DefaultHttpClient();
		HttpGet httpGet = new HttpGet(new String(Class_About.Serverlocation + Route + Params));
		HttpResponse response = httpClient.execute(httpGet);
		BufferedReader rd = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));

		StringBuffer result = new StringBuffer();
		String line = "";
		while ((line = rd.readLine()) != null) {
			result.append(line);
		}
		return result.toString();
	}
}
