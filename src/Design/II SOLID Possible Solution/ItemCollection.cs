// ReSharper disable CheckNamespace

namespace CleanCode.Design.SolidSolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // using Newtonsoft.Json;

    /// <summary>
    /// Contains all available items.
    /// </summary>
    public class ItemCollection
    {
        /// <summary>
        /// The content of this string would usually be stored in a text file or in some kind of a database.
        /// However, for this exercise we take the items directly from this field variable.
        /// </summary>
        private const string ItemsAsJsonString = @"[
{id:'1',type:'book',title:'Clean Code',author:'Robert C. Martin',price:'29.90'},
{id:'2',type:'notebook',title:'A4 Notebook (Red)',price:'9.90',color:'Red'},
{id:'3',type:'notebook',title:'A4 Notebook (Blue)',price:'9.90',color:'Blue'},
{id:'4',type:'notebook',title:'A4 Notebook (Green)',price:'9.90',color:'Green'},
{id:'5',type:'notebook',title:'A4 Notebook (Yellow)',price:'9.90',color:'Yellow'},
{id:'6',type:'pen',title:'Pen (Red)',price:'4.90',color:'Red'},
{id:'7',type:'pen',title:'Pen (Blue)',price:'4.90',color:'Blue'},
{id:'8',type:'pen',title:'Pen (Green)',price:'4.90',color:'Green'},
]";

        private List<Item> allItems;

        public void Initialize()
        {
            this.allItems = DeserializeJson(ItemsAsJsonString);
        }

        public IReadOnlyList<Item> GetAllItems()
        {
            return this.allItems.ToArray();
        }

        public Pen GetPen(PenColor color)
        {
            // NOTE
            // This example shows, that abandoning the type property in the base class comes with some costs.
            // The select statement within the linq query is somewhat more complex than before.
            return this.allItems
                .First(item => item.IsA<Pen>() && item.As<Pen>().Color == color) as Pen;
        }

        public Book GetBook()
        {
            return this.allItems
                .First(item => item.IsA<Book>()) as Book;
        }

        public Notebook GetNotebook(NotebookColor color)
        {
            return this.allItems
                .First(item => item.IsA<Notebook>() && item.As<Notebook>().Color == color) as Notebook;
        }

        private static List<Item> DeserializeJson(string json)
        {
            // no longer working in .Net5+
            // todo wtjerry: implement a different solution
            //// var jsonDefinition = new[] { new { id = 0, type = "", title = "", author = "", price = 0m, color = "" } };
            //// var items = JsonConvert.DeserializeAnonymousType(json, jsonDefinition);

            var result = new List<Item>();

            // foreach (var j in items)
            // {
            //     var price = Price.FromChf(j.price);
            //
            //     switch (j.type)
            //     {
            //         case "book":
            //             var book = new Book(j.id, j.title, price, j.author);
            //             result.Add(book);
            //             break;
            //
            //         case "notebook":
            //             var notebookColor = (NotebookColor)Enum.Parse(typeof(NotebookColor), j.color);
            //             var notebook = new Notebook(j.id, j.title, price, notebookColor);
            //             result.Add(notebook);
            //             break;
            //
            //         case "pen":
            //             var penColor = (PenColor)Enum.Parse(typeof(PenColor), j.color);
            //             var pen = new Pen(j.id, j.title, price, penColor);
            //             result.Add(pen);
            //             break;
            //
            //         // CHALLENGE
            //         // It would be really nice, if we could avoid this switch statement for converting the json
            //         // objects into item types, so that we can be more "open" to new types
            //         // (without the need to extend this method).
            //         // Can you find a better way to reach this goal?
            //         default:
            //             throw new ArgumentException($"Unknown type: {j.type}");
            //     }
            // }

            return result;
        }
    }
}
