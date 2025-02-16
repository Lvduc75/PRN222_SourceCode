using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorInjectionPatternDemo.Model
{
    public class BookManager
    {
        public IBookReader bookReader;
        public BookManager(IBookReader bookReader)
        {
            this.bookReader = bookReader;
        }
        public void ReadBooks()
        {
            bookReader.ReadBooks();
        }   
    }
}
