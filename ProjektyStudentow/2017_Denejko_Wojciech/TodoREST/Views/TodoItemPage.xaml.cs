using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoItemPage : ContentPage
	{
		List<string> colorNames = new List<string>
		{
			"Aqua", "Blue", "Lime", "Olive", "Black", "Yellow", "Green"

		};

		bool isNewItem;
		public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
			isNewItem = isNew;

			foreach (string name in colorNames)
			{
				colorPicker.Items.Add(name);
			}
		}

		async void OnSaveActivated (object sender, EventArgs e)
		{
			// obserwator
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.SaveTaskAsync (todoItem, isNewItem);
			await Navigation.PopAsync ();
		}

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTaskAsync (todoItem);
			await Navigation.PopAsync ();
		}

		void OnCancelActivated (object sender, EventArgs e)
		{
			Navigation.PopAsync ();
		}

		async void OnCloneActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.CloneTaskAsync(todoItem);
			await Navigation.PopAsync();
		}

		// dekorator
		void Handle_SelectedIndexChanged(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;

			if (colorPicker.SelectedIndex == -1)
			{
				colorBoxView.Color = Color.Default;
				todoItem.Color = "Default";
			}
			else
			{
				ColorTypeConverter colortype = new ColorTypeConverter();
				string colorName = colorPicker.Items[colorPicker.SelectedIndex];
				todoItem.Color = colorName;
				colorBoxView.Color = (Color)colortype.ConvertFromInvariantString(colorName);
			}
		}
	}
}
