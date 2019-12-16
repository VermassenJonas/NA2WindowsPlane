using System;
using System.Collections.ObjectModel;

namespace ProjectWindowsVliegtuig.Model
{
    public class Movie
    {
        public string Title { get; set; }
        public string File { get; set; }
        public string Description { get; set; }
        public ObservableCollection<String> Tags { get; set; }

        public Movie(string title, string file, string desc)
        {
            Title = title;
            File = file;
            Description = desc;
            Tags = new ObservableCollection<string>
            {
                "Text1",
                "Text12",
                "Text123"
            };
        }

        public string TagsToString()
        {
            string tags = "";

            foreach (string s in Tags) {
                tags += s + ", ";
            }

            // substring om onnodige komma te verwijderen op het einde
            return tags.Substring(0, tags.Length - 2);
        }
    }

}
