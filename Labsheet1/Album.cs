using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labsheet1
{
	public class Album
	{
		//properties
		public string Name { get; set; }
		public DateTime YearRealease { get; set; }
		public int Sales { get; set; }
		

		//constructors
		public Album(string name, DateTime yearRealease, int sales)
		{
			Name = name;
			YearRealease = yearRealease;
			Sales = sales;

			
		}

	public Album()
		{

		}


		//Methods
		public override string ToString()
		{
			return (this.Name+ "-"+ (DateTime.Now.Year - Released.Year)+" Year since release");
		}

		public int GetYearSniceRelease()
		{
			
				//Get Todays Date
				DateTime today = DateTime.Now;


				//Get the Date of release
				DateTime dateofRelease = new DateTime(1990, 1, 1);

				//take one from the other
				int Year = today.Year - dateofRelease.Year;


		
			
		}
	}

	internal class Released
	{
		public static int Year { get; internal set; }
	}
}
