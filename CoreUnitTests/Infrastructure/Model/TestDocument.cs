using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Models;
using RCommon.Entities;

namespace CoreUnitTests.Infrastructure.Model;

public class TestDocument : BusinessEntity
{
    public TestDocument()
    {
        //Version = 2;
        Nested = new Nested {SomeDate = DateTime.UtcNow};
        Children = new List<Child>();
    }

    [BsonId]
    public Guid Id { get; set; }

    public int SomeValue { get; set; }

    public decimal SomeDecimalValue { get; set; }

    public string SomeContent { get; set; }

    public string SomeContent2 { get; set; }

    public string SomeContent3 { get; set; }

    public int GroupingKey { get; set; }

    public Guid OtherGroupingKey { get; set; }

    public Nested Nested { get; set; }

    public List<Child> Children { get; set; }

    public override object[] GetKeys() => throw new NotImplementedException();
}
