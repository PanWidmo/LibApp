using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.ViewModels
{
    public class BookFormModel
    {
        public Book Book { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title
        {
            get
            {
                if(Book != null && Book.Id != 0)
                {
                    return "Edit Book";
                }

                return "New Book";
            }
        }

    }
}
