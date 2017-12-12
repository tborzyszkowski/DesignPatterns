using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoREST
{
	public class RestService : IRestService
	{
		HttpClient client;

		public List<TodoItem> Items { get; private set; }

		public RestService ()
		{
			var authData = string.Format ("{0}:{1}", Constants.Username, Constants.Password);
			var authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));

			// Singleton
			client = new HttpClient ();
			client.MaxResponseContentBufferSize = 256000;
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authHeaderValue);
		}

		public async Task<List<TodoItem>> RefreshDataAsync ()
		{
			Items = new List<TodoItem> ();

			// RestUrl = /api/todoitems/{0}
			var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));

			try {
				var response = await client.GetAsync (uri);
				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync ();
					Items = JsonConvert.DeserializeObject <List<TodoItem>> (content);
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}

			return Items;
		}

		public async Task CloneTodoItemAsync(TodoItem item)
		{
			// RestUrl = /api/todoitems/clone/{0}
			var uri = new Uri(string.Format(Constants.RestUrl + "clone/{0}", item.ID));

			try
			{
				var json = JsonConvert.SerializeObject(item);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				response = await client.PutAsync(uri, content);


				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				TodoItem successfully cloned.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}

		public async Task SaveTodoItemAsync (TodoItem item, bool isNewItem = false)
		{
			// RestUrl = /api/todoitems/edit/{0}
			var uri = new Uri (string.Format (Constants.RestUrl + "{0}", item.ID));

			try {
				var json = JsonConvert.SerializeObject (item);
				var content = new StringContent (json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				if (isNewItem) {
					response = await client.PostAsync (uri, content);
				} else {
					uri = new Uri(string.Format(Constants.RestUrl + "edit/{0}", item.ID));
					response = await client.PutAsync (uri, content);
				}
				
				if (response.IsSuccessStatusCode) {
					Debug.WriteLine (@"				TodoItem successfully saved.");
				}
				
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}

		public async Task DeleteTodoItemAsync (string id)
		{
			// RestUrl = /api/todoitems/{0}
			var uri = new Uri (string.Format (Constants.RestUrl + "{0}", id));

			try {
				var response = await client.DeleteAsync (uri);

				if (response.IsSuccessStatusCode) {
					Debug.WriteLine (@"				TodoItem successfully deleted.");	
				}
				
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}
	}
}
