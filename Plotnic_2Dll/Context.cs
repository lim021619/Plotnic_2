using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;


namespace Plotnic_2Dll
{
    /// <summary>
    /// Базовый контекст данных библиотеки
    /// </summary>
    public class Context:DbContext
    {
        public const string Ex_db3 = ".db3";
        public string Ex { get; set; }
        public string Path { get; set; }
        public const string NameDb = "PlotnicDataBase";

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product>  Products{ get; set; }
        public DbSet<Component> Components{ get; set; }
        public DbSet<Furniture> Furnitures{ get; set; }
        public DbSet<Material> Materials{ get; set; }

        //Строка подключения для андроид

        //        private string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Child_Feeding_Db.db3");

        
        //Строка подключения для десктопа
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        //}
    }
}
