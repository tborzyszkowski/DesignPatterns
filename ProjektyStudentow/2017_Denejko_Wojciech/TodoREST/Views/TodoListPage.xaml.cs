﻿using System;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			listView.ItemsSource = await App.TodoManager.GetTasksAsync();
		}

		void OnAddItemClicked (object sender, EventArgs e)
		{
			var todoItem = new TodoItem()
			{
				ID = Guid.NewGuid().ToString(),
				Color = "Default"
			};
			var todoPage = new TodoItemPage(true);
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync(todoPage);
		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var todoItem = e.SelectedItem as TodoItem;
			var todoPage = new TodoItemPage ();
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync (todoPage);
		}
	}
}
