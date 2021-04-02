using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labsheet1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Band> allBands = new List<Band>();
		
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e )
		{
			// populates combobox
			string[] genres = { "All ", "Rock", "Pop", "Indie" };
			cbxgenere.ItemsSource = genres;

			RockBand b1 = new RockBand() { BandName = "The Foo Fighter", YearFormed = 1994, Members = "Dave Grohl , Nate Mendel, Pat Smear,Taylor Hawkins,Chirs Shifflett, Rami Jafee  " };
			RockBand b2 = new RockBand() { BandName = "The Rolling Ststus", YearFormed = 1962, Members = "Mick Jagger , Iran Stewart,Dick Taylor, Bill Wyam, Mick Taylor " };

			PopBand b3 = new PopBand() { BandName = "The Beatlea", YearFormed = 1965, Members = "James Lehonon , Paul MaCartney, George Harrison, Ringo Starr" };
			PopBand b4 = new PopBand() { BandName = "Green Day", YearFormed = 1996, Members = "Billie Joe Armstrong , Mike Drint , Tre Cool" };

			IndieBand b5 = new IndieBand() { BandName = "Arctic Money ", YearFormed = 2002, Members = "Alex Tuner , Mart Heldens, Jamie Cook, Nick O'Malley" };
			IndieBand b6 = new IndieBand() { BandName = "The Strokes", YearFormed = 1998, Members = "Julin Csablances, Nick Valensi, Albert Hammond Jr, Nikolai Fraiture,Fabrizio Moretti   " };
			// create albums
			Random rand = new Random();
			//Foo fighter album
			Album a1 = new Album() {Name= "Gneatest Hits",YearRealease =GetRandomDate(r1, rand.Next(1960, 2020)),Sales= rand.Next(100000, 100000) };
			Album a2 = new Album() { Name = "one by one", YearRealease =GetRandomDate(r2, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			r1.Albums[0] = a1;
			r1.Albums[1] = a2;
			
			//Rolling  Stones Album
			Album a3 = new Album() { Name ="Beggars Banquet", YearRealease =GetRandomDate(r2, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			Album a4 = new Album() { Name = "Blue & Lonesome", YearRealease =GetRandomDate(r2, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			r2.Albums[0] = a3;
			r2.Album[1] = a4;
			
			// The Beatles Album
			Album a5 = new Album() { Name = "Let it be", YearRealease =GetRandomDate(p1, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			Album a6 = new Album() { Name = "Sgt. Pepper's Lonely Heart Club Band ", YearRealease =GetRandomDate(p1, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			p1.Albums[0] = a5;
			p1.Albums[1] = a6;
			
			//Green Day Albums
			Album a7 = new Album() { Name = "Dookie", YearRealease =GetRandomDate(p2, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			Album a8 = new Album() { Name = "American Idiots", YearRealease =GetRandomDate(p2, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			p2.Albums[0] = a7;
			p2.Albums[1] = a8;
			//Arctic Monkeys Albums
			Album a9 = new Album() { Name = "Whatever prople say i am , that's what i am not", YearRealease =GetRandomDate(i1, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			Album a10 = new Album() { Name = "Favourite Worst Hightmare", YearRealease =GetRandomDate(i1, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			i1.Albums[0] = a9;
			i1.Albums[1] = a10;
			
			//The Strokes album
			Album a11= new Album() { Name = "Room on Fire", YearRealease =GetRandomDate(i2, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			Album a12= new Album() { Name = "The Modern Age", YearRealease =GetRandomDate(i2, rand.Next(1960, 2020)), Sales = rand.Next(100000, 100000) };
			i2.Albums[0] = a11;
			i2.Albums[1] = a12;




			//Add to Collection
			allBands.Add(b1);
			allBands.Add(b2);
			allBands.Add(b3);
			allBands.Add(b4);
			allBands.Add(b5);
			allBands.Add(b6);
			

			//Add Albums
			b1.AlbumList.Add(a1);
			b2.AlbumList.Add(a2);

			b3.AlbumList.Add(a3);
			b4.AlbumList.Add(a4);

			b5.AlbumList.Add(a5);
			b6.AlbumList.Add(a6);

			b6.AlbumList.Add(a7);
			b6.AlbumList.Add(a8);

			b6.AlbumList.Add(a9);
			b6.AlbumList.Add(a10);

			b6.AlbumList.Add(a11);
			b6.AlbumList.Add(a12);


			//sort bands
			allBands.Sort();

			//Display
			lbxbands.ItemsSource = allBands;
		}

		

		private void lbxbands_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Band selestedBand = lbxbands.SelectedItem as Band;

			if (selestedBand != null)
			{
				lbxalbums.ItemsSource = selestedBand.AlbumList;
				tblkband.Text = string.Format($"Formed: {selestedBand.YearFormed}" +
					$"\nMembers: {selestedBand.Members}");
			}
		}
		//Filter bands based on Combbox
		private void cbxgenere_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//determines what is selected in combobox
			string selectedGenre = cbxgenere.SelectedItem as string;

			//setup a feltered list 
			List<Band> filteredList = new List<Band>();

			// if/else - switch
			switch(selectedGenre)
			{
				case "All":
					lbxbands.ItemsSource = allBands;
					break;

				case "Rock":
					foreach (Band band in allBands)
					{
						if (band is RockBand)
							filteredList.Add(band);
					}
					lbxbands.ItemsSource = filteredList;
					break;

				case "Pop":
					foreach (Band band in allBands)
					{
						if (band is PopBand)
							filteredList.Add(band);
					}
					lbxbands.ItemsSource = filteredList;
					break;

				case "Indie":
					foreach (Band band in allBands)
					{
						if (band is IndieBand)
							filteredList.Add(band);
					}
					lbxbands.ItemsSource = filteredList;
					break;
			}

			// update display

		}
		//Genrate random date within range
		private DateTime GetRandomDate(Band band, Random randomFactor)
		{
			//calculates a time range given two integers
			DateTime startDate = new DateTime(band.YearFormed, 01, 01);
			DateTime endtime = new DateTime(2019, 09, 01);
			TimeSpan timespan = endtime - startDate;
			TimeSpan newSpan = new TimeSpan(0, randomFactor.Next(0, (int)timespan.TotalMinutes), 0);
			DateTime newDate = startDate + newSpan;


			return newDate;
		}

	

	}
}
