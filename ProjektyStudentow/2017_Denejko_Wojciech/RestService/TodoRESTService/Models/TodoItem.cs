﻿namespace TodoRESTService.Models
{
    public class TodoItem
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public bool Done { get; set; }

		public string Color { get; set;}

		public TodoItem Clone()
		{
			return (TodoItem)this.MemberwiseClone();
		}
    }
}