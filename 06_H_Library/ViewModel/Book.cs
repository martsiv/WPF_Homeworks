using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_H_Library.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class Book
    {
        public string Author { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Genre { get; init; }
        public DateTime DatePublication { get; init; }
        public string DateFormated => DatePublication.ToString("d MMMM yyyy");
        public Book(string author, string title, string description, string genre, DateTime datePublication)
        {
            Author = author;
            Title = title;
            Description = description;
            Genre = genre;
            DatePublication = datePublication;
        }
        [DependsOn(nameof(Author), nameof(Title), nameof(Description), nameof(Genre), nameof(DatePublication))]
        public string Info => ToString();
        public override string ToString()
        {
            return $"{Title} by {Author}\t {DatePublication.ToShortDateString()}";
        }
    }
}
