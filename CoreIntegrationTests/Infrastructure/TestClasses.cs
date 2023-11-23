using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Models;
using MongoDbGenericRepository.Utils;
using RCommon.Entities;
using System;
using System.Collections.Generic;

namespace CoreIntegrationTests.Infrastructure
{
    public class ProjectedGroup
    {
        public int Key { get; set; }
        public List<string> Content { get; set; }
    }

    public class MyTestProjection
    {
        public string SomeContent { get; set; }
        public DateTime SomeDate { get; set; }
    }

    public class Nested
    {
        public DateTime SomeDate { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal SomeAmount { get; set; }
    }

    public class Child
    {
        public Child(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class TestDoc : BusinessEntity<Guid>
    {
        public TestDoc()
        {
            //Version = 2;
            Nested = new Nested
            {
                SomeDate = DateTime.UtcNow
            };
            Children = new List<Child>();
        }

        public int SomeValue { get; set; }

        public string SomeContent { get; set; }
        public string SomeContent2 { get; set; }
        public string SomeContent3 { get; set; }

        public int GroupingKey { get; set; }

        public Nested Nested { get; set; }

        public List<Child> Children { get; set; }

        public override object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }

    public class TestDoc<TKey> : BusinessEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        [BsonId]
        public Guid Id { get; set; }
        public int Version { get; set; }

        public TestDoc()
        {
            InitializeFields();
            Version = 2;
            Nested = new Nested
            {
                SomeDate = DateTime.UtcNow
            };
            Children = new List<Child>();
        }

        public int GroupingKey { get; set; }
        public string SomeContent { get; set; }
        public string SomeContent4 { get; set; }
        public string SomeContent5 { get; set; }

        public Nested Nested { get; set; }

        public List<Child> Children { get; set; }

        public TId Init<TId>()
        {
            return IdGenerator.GetId<TId>();
        }

        private void InitializeFields()
        {
            Id = Init<Guid>();
        }

    }
}
