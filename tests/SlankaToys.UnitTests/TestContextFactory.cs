using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SlankaToys.Infrastructure;

namespace SlankaToys.UnitTests
{
    public class TestContextFactory
    {
        

        private const string InMemoryConnectionString = "DataSource=:memory:";
        private SqliteConnection _connection;

        public SlankaToysDbContext SlankaToysDbContext;

        public TestContextFactory()
        {
            SetContext();
        }

        private void SetContext()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<SlankaToysDbContext>()
                    .UseSqlite(_connection)
                    .Options;
            var slankaToysDbContext = new SlankaToysDbContext(options);
            slankaToysDbContext.Database.EnsureCreated();
            SlankaToysDbContext = slankaToysDbContext;
        }

        public void CleanUp()
        {
            _connection.Close();
        }
    }
}

