using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Fatti_di_Carta.Utility
{
    public class Book
    {
        private int id;
        private string title;
        private decimal price;
        private short quantity;
        private string isbn;
        private int year;
        private int nPage;

        public Book()
        {
            this.id = -1;
            this.title = "";
            this.price = 0;
            this.quantity = 0;
            this.isbn = "";
            this.nPage = 0;
            this.year = 0;
            this.IdAuthor = -1;
            this.IdEditor = -1;
            this.IdSupplier = -1;
        }
        /// The ID inside access
        /// </summary>
        public int Id { get => this.id; }
        /// <summary>
        /// The title property.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Il campo titolo è obbligatorio");
                }
                else
                {
                    this.title = value;
                }
            }
        }
        /// <summary>
        /// Property for the price it take care that the price is above the zero.
        /// </summary>
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if(value > 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException("Il prezzo deve essere maggiore di zero");
                }
            }
        }
        /// <summary>
        /// Property for the quantity. It take care that no negative value are assigned.
        /// </summary>
        public short Quantity
        {
            get { return this.quantity; }
            set
            {
                if(value >= 0)
                {
                    this.quantity = value;
                }
                else
                {
                    throw new ArgumentException("La quantità del libro non può essere negativa");
                }
            }
        }
        /// <summary>
        /// ISBN code property.
        /// </summary>
        public String Isbn
        {
            get { return this.isbn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Il campo ISBN è obbligatorio.");
                }
                else
                {
                    this.isbn = value;
                }
            }
        }
        /// <summary>
        /// Number of page property. It assure that the number of page is above the zero.
        /// </summary>
        public int NPage
        {
            get{ return this.nPage; }
            set
            {
                if(value >= 0)
                {
                    this.nPage = value;
                }
                else
                {
                    throw new ArgumentException("Un libro non può avere meno di zero pagine");
                }
            }
        }
        /// <summary>
        /// Year date property.
        /// </summary>
        public int Year
        {
            get => this.year;
            set => this.year = value;
        }
        /// <summary>
        /// ID of the authro property.
        /// </summary>
        public int IdAuthor { get; set; }
        /// <summary>
        /// ID of the editor property.
        /// </summary>
        public int IdEditor { get; set; }
        /// <summary>
        /// ID of the supplier property.
        /// </summary>
        public int IdSupplier { get; set; }
        /// <summary>
        /// Find a book using the ISBN.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public static Book FindByISBN(string isbn)
        {
            Book book = null;
            bool hasOleDbError = false;
            //The connection string is required to actually connect
            string cs = Config.GetConnectionString();
            //The using statement will dispose the connection
            using (OleDbConnection connection = new OleDbConnection(cs))
            {
                try
                {
                    //The command will the the select query
                    OleDbCommand cmd = new OleDbCommand();
                    //Connecting to access
                    connection.Open();
                    //Set up the command
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT id, titolo, prezzo, deposito, anno, numero_pagine,
                        id_editore, id_fornitore, id_autore
                        FROM Libri WHERE isbn = @isbn;";
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    //Perform the query
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        book = new Book();
                        book.id = (int)reader[0];
                        book.Title = reader[1].ToString();
                        book.Price = (decimal)reader[2];
                        book.Quantity = (short)reader[3];
                        book.Year = (int)reader[4];
                        book.NPage = (int)reader[5];
                        book.IdEditor = (int)reader[6];
                        book.IdSupplier = (int)reader[7];
                        book.IdAuthor = (int)reader[8];
                        book.Isbn = isbn;
                    }
                    cmd.Dispose();
                    reader.Close();
                }
                catch (OleDbException)
                {
                    hasOleDbError = true;
                }
                catch (InvalidOperationException)
                {
                    hasOleDbError = true;
                }
                finally
                {
                    connection.Close();
                }
                if (hasOleDbError)
                {
                    throw new InvalidOperationException();
                }
                return book;
            }
        }
    }
}
