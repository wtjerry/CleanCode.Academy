// ReSharper disable CheckNamespace
namespace CleanCode.Design.SolidExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        private bool isInitialized;

        private List<Item> allItems;

        public void Initialize()
        {
            this.allItems = DeserializeJson(ItemsAsJsonString);
            this.isInitialized = true;
        }

        public IReadOnlyList<Item> GetAllItems()
        {
            this.CheckInitialized();
            return this.allItems.ToArray();
        }

        public Pen GetPen(ItemColor color)
        {
            this.CheckInitialized();
            return this.allItems.First(item => item.Type == ItemType.Pen && item.Color == color) as Pen;
        }

        public Book GetBook()
        {
            this.CheckInitialized();
            return this.allItems.First(item => item.Type == ItemType.Book) as Book;
        }

        public Notebook GetNotebook(ItemColor color)
        {
            this.CheckInitialized();
            return this.allItems.First(item => item.Type == ItemType.Notebook && item.Color == color) as Notebook;
        }

        private static List<Item> DeserializeJson(string json)
        {
            var result = new List<Item>();

            var items = json
                .Split("{".ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Contains("id:"))
                .ToArray();

            foreach (var j in items)
            {
                var idString = ReadJsonPropertyValue("id", j);
                var id = int.Parse(idString);
                var type = ReadJsonPropertyValue("type", j);
                var title = ReadJsonPropertyValue("title", j);
                var priceString = ReadJsonPropertyValue("price", j);
                var price = decimal.Parse(priceString);

                Item item;

                switch (type)
                {
                    case "book":
                    {
                        var author = ReadJsonPropertyValue("author", j);
                        item = new Book(id, title, price, author);
                        break;
                    }
                    case "notebook":
                        item = new Notebook(id, title, price);
                        break;
                    case "pen":
                        item = new Pen(id, title, price);
                        break;
                    default:
                        throw new ArgumentException($"Unknown type: {type}");
                }

                var colorString = ReadJsonPropertyValue("color", j);
                if (!string.IsNullOrEmpty(colorString))
                {
                    var color = (ItemColor)Enum.Parse(typeof(ItemColor), colorString);
                    item.ChangeColor(color);
                }

                result.Add(item);
            }

            return result;
        }

        private static string ReadJsonPropertyValue(string propertyName, string jsonString)
        {
            var propertyPrefix = $"{propertyName}:'";

            // if property not found, return empty string.
            if (!jsonString.Contains(propertyName))
            {
                return string.Empty;
            }

            var startPosition = jsonString
                .IndexOf(propertyPrefix, StringComparison.OrdinalIgnoreCase) + propertyPrefix.Length;
            var endPosition = jsonString.IndexOf("'", startPosition, StringComparison.OrdinalIgnoreCase);
            var length = endPosition - startPosition;

            return jsonString.Substring(startPosition, length);
        }

        private void CheckInitialized()
        {
            if (!this.isInitialized)
            {
                throw new InvalidOperationException("not initialized");
            }
        }
    }
}