using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutoLevelLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("books");
            dataSet.ExtendedProperties.Add("Owner", "ITStep"); // метаданные о наборе
            
            #region books columns
            DataTable booksTable = new DataTable("books");
            booksTable.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });

            booksTable.Columns.Add("name", typeof(string));
            booksTable.Columns.Add("price", typeof(int));
            booksTable.Columns.Add("authorId", typeof(int));
            #endregion

            #region books rows
            booksTable.Rows.Add("Skazka", 1000, 1);
            DataRow row = booksTable.NewRow();
            row.BeginEdit();
            row.ItemArray = new object[] { "Skazka part2", 1200, 1 };
            row.SetAdded();
            row.EndEdit();

            booksTable.Rows.Add(row);
            #endregion

            dataSet.Tables.Add(booksTable);


            #region author columns
            DataTable authorsTable = new DataTable("authors");
            authorsTable.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });

            authorsTable.Columns.Add("fullName", typeof(string));
            #endregion

            #region authors rows
            authorsTable.Rows.Add("Pushkin");
            #endregion

            dataSet.Tables.Add(authorsTable);

            DataRelation dataRelation = new DataRelation("authors_books_fk", "authors", "books", new string[] { "id" }, new string[] { "authorsId" }, false);
            dataSet.Relations.Add(dataRelation);

        }
    }
}
