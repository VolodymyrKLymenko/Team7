using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
	public enum MenuItemType
	{
		Events, //TODO:Add more pages
	}

	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string TextColor { get; set; }

		public string Title { get; set; }

		public string ImagePath { get; set; }
	}
}
