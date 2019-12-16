using ProjectWindowsVliegtuig.Model;
using System.Collections.ObjectModel;

namespace ProjectWindowsVliegtuig.ViewModel
{
    public class MoviesVM
    {
        public ObservableCollection<Movie> MoviesList { get; set; }

        public MoviesVM()
        {
            MoviesList = new ObservableCollection<Movie>
            {
                new Movie("Test", "SampleVideo1.mp4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Integer feugiat scelerisque varius morbi."),
                new Movie("Test1", "SampleVideo1.mp4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Integer feugiat scelerisque varius morbi."),
                new Movie("Test1", "SampleVideo1.mp4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Integer feugiat scelerisque varius morbi."),
                new Movie("Test1", "SampleVideo1.mp4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Integer feugiat scelerisque varius morbi."),
                new Movie("Test1", "SampleVideo1.mp4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Integer feugiat scelerisque varius morbi."),
                new Movie("Test1", "SampleVideo1.mp4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Integer feugiat scelerisque varius morbi."),
                new Movie("Test1", "SampleVideo1.mp4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Integer feugiat scelerisque varius morbi.")
            };
        }

    }
}
