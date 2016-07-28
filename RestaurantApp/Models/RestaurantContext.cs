namespace RestaurantApp.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Collections.Generic;

	public partial class RestaurantContext : DbContext
	{
		public RestaurantContext()
			: base("name=RestaurantConn")
		{
		}

		public virtual DbSet<Drink> Drinks { get; set; }
		public virtual DbSet<Appetizer> Appetizers { get; set; }
		public virtual DbSet<MainCourse> MainCourses { get; set; }
		public virtual DbSet<Dessert> Desserts { get; set; }

		public static IEnumerable<T> createList<T>(T t)
		{
			return new List<T>();
		}
	}
}
