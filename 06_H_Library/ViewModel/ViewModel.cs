using _06_H_Library.Help;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace _06_H_Library.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class ViewModel
    {
        //Selected мусить відповідати реальному селектеду, або якщо не відповідає селектелу, то кнопки вперед, назад
        //мають бути не активні
        private ObservableCollection<Book> books = new ObservableCollection<Book>();
        public IEnumerable<Book> Books => books;
        private Book? selectedBook;
        public Book? SelectedBook 
        { 
            get => selectedBook;
            set
            {
                selectedBook = value;
            }
        }

        private readonly RelayCommand nextBook;
        private readonly RelayCommand previusBook;
        public ICommand NextBook => nextBook;
        public ICommand PreviusBook => previusBook;
        public void Next()
        {
            SelectedBook = books[books.IndexOf(SelectedBook) + 1];
        }
        public void Previus()
        {
            SelectedBook = books[books.IndexOf(SelectedBook) - 1];
        }
        
        public ViewModel()
        {
            books.Add(new Book("Jane Austen", "Pride and Prejudice", "Pride and Prejudice is a classic romantic novel by Jane Austen. It explores themes of love, marriage, and social status in 19th-century England. The story follows Elizabeth Bennet, a spirited and independent young woman, as she navigates the intricacies of society and encounters the proud Mr. Darcy. With its engaging characters and witty dialogue, this novel continues to captivate readers.", "Romance", DateTime.Parse("28.01.1813")));
            books.Add(new Book("Harper Lee", "To Kill a Mockingbird", "To Kill a Mockingbird is a renowned novel by Harper Lee. Set in the 1930s in the fictional town of Maycomb, Alabama, it tackles racial injustice and the loss of innocence through the eyes of Scout Finch. The story unfolds as Scout's father, Atticus Finch, defends a black man accused of rape, challenging the deeply ingrained prejudices of the community. This powerful and poignant novel remains a timeless classic.", "Drama", DateTime.Parse("11.07.1960")));
            books.Add(new Book("George Orwell", "1984", "1984 is a dystopian novel by George Orwell. Set in a totalitarian society ruled by the Party, it depicts a world where individualism is suppressed, and government surveillance is omnipresent. The story follows Winston Smith as he rebels against the oppressive regime and strives for freedom and self-expression. With its chilling depiction of a dystopian future, this novel serves as a cautionary tale.", "Fiction", DateTime.Parse("08.06.1949")));
            books.Add(new Book("Herman Melville", "Moby-Dick", "Moby-Dick, or The Whale, is an epic tale by Herman Melville. It follows Captain Ahab's relentless pursuit of the white whale, Moby Dick, and delves into themes of obsession, fate, and the human condition. Through vivid descriptions and rich symbolism, the novel explores the depths of human nature and the consequences of unchecked ambition. This masterpiece continues to resonate with readers worldwide.", "Adventure", DateTime.Parse("18.11.1851")));
            selectedBook = books[0];
            nextBook = new((o) => Next(), (с) => books.IndexOf(selectedBook) != books.Count - 1);
            previusBook = new((o) => Previus(), (с) => books.IndexOf(selectedBook) != 0);
        }
    }
}
