using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace _WPF_JsonReadAndWrite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Movie> movies = new List<Movie>() {
                new Movie()
                {
                    Name = "asda",
                    Year = 1995
                },
                new Movie()
                {
                    Name = "asda",
                    Year = 1995
                }
            };
            //new line
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"movie.json", JsonConvert.SerializeObject(movies));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, movies);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"movie.json"))
            {
                List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(@"movie.json"));
                MessageBox.Show(movies.Count.ToString());
            }
            else
            {
                MessageBox.Show("File Not Exists");
            }

            //// deserialize JSON directly from a file
            //using (StreamReader file = File.OpenText(@"movie.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
            //}
           
        }

        public class Movie
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }
    }
}