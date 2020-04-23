using Dapper;
using Dapper.Contrib.Extensions;
using MyOrange.IServices;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyOrange.DbServices
{

    // dotnet add package Dapper

    public class DbDocumentService : IDocumentService
    {
        private readonly IDbConnection connection;

        public DbDocumentService(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Add(Document entity)
        {
            throw new NotImplementedException();
        }

        public IList<Document> Get()
        {
            string sql = "select d.*, c.Id, c.FirstName from dbo.Documents as d left outer join dbo.Customers as c on d.CustomerId = c.Id";

            // var documents = connection.Query<Document>(sql).ToList();

            var documents = connection.Query<Document, Customer, Document>(sql, (document, customer) =>
            {
                document.Customer = customer;
                return document;
            })
            .ToList();

            return documents;
        }

        public Document Get(int id)
        {
            string sql = "select * from dbo.Documents where Id = @DocumentId";

            var document = connection.QuerySingleOrDefault<Document>(sql, new { @DocumentId = id });

            return document;
        }

        public void Remove(int id)
        {
            string sql = "delete from dbo.Documents where Id = @DocumentId";

            connection.Execute(sql, new { @DocumentId = id });

        }


        // https://dapper-tutorial.net/update
        public void Update(Document entity)
        {
            // manual
            UpdateManual(entity);

            // automat
            UpdateAuto(entity);

        }

        private void UpdateAuto(Document entity)
        {
            using (var transaction = connection.BeginTransaction())
            {
                // dotnet add package Dapper.Contrib
                connection.Update(entity, transaction);

                connection.Update(entity, transaction);

            }
        }

        private void UpdateManual(Document entity)
        {
            string sql = "update dbo.Documents set Title = @Title, Description = @Description where Id = @DocumentId";

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    connection.Execute(sql, new { @DocumentId = entity.Id, @Title = entity.Title, @Description = entity.Description });
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
