using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using CoreUnitTests.Infrastructure;
using CoreUnitTests.Infrastructure.Model;
using FluentAssertions;
using MongoDbGenericRepository.DataAccess.Read;
using Moq;
using Xunit;

namespace CoreUnitTests.KeyedReadOnlyMongoRepositoryTests;

public class GetByIdAsyncTests : TestKeyedReadOnlyMongoRepositoryContext<int>
{
    [Fact]
    public async Task WithId_Gets()
    {
        // Arrange
        var document = Fixture.Create<TestDocumentWithKey<int>>();

        SetupReader(document);

        // Act
        var result = await Sut.GetByIdAsync<TestDocumentWithKey<int>>(document.Id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(document);
        Reader.Verify(
            x => x.GetByIdAsync<TestDocumentWithKey<int>, int>(document.Id, null, CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public async Task WithIdAndCancellationToken_Gets()
    {
        // Arrange
        var document = Fixture.Create<TestDocumentWithKey<int>>();
        var token = new CancellationToken(true);

        SetupReader(document);

        // Act
        var result = await Sut.GetByIdAsync<TestDocumentWithKey<int>>(document.Id, token);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(document);
        Reader.Verify(
            x => x.GetByIdAsync<TestDocumentWithKey<int>, int>(document.Id, null, token),
            Times.Once);
    }

    [Fact]
    public async Task WithIdAndPartitionKey_Gets()
    {
        // Arrange
        var document = Fixture.Create<TestDocumentWithKey<int>>();
        var partitionKey = Fixture.Create<string>();

        SetupReader(document);

        // Act
        var result = await Sut.GetByIdAsync<TestDocumentWithKey<int>>(document.Id, partitionKey);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(document);
        Reader.Verify(
            x => x.GetByIdAsync<TestDocumentWithKey<int>, int>(document.Id, partitionKey, CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public async Task WithIdAndPartitionKeyAndCancellationToken_Gets()
    {
        // Arrange
        var document = Fixture.Create<TestDocumentWithKey<int>>();
        var partitionKey = Fixture.Create<string>();
        var token = new CancellationToken(true);

        SetupReader(document);

        // Act
        var result = await Sut.GetByIdAsync<TestDocumentWithKey<int>>(document.Id, partitionKey, token);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(document);
        Reader.Verify(
            x => x.GetByIdAsync<TestDocumentWithKey<int>, int>(document.Id, partitionKey, token),
            Times.Once);
    }

    private void SetupReader(TestDocumentWithKey<int> document)
    {
        Reader = new Mock<IMongoDbReader>();
        Reader
            .Setup(
                x => x.GetByIdAsync<TestDocumentWithKey<int>, int>(
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(document);
    }
}
