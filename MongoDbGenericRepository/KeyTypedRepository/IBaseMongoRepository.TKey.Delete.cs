using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDbGenericRepository.Models;
using RCommon.Entities;

namespace MongoDbGenericRepository
{
    /// <summary>
    ///     The interface exposing deletion functionality for Key typed repositories.
    /// </summary>
    /// <typeparam name="TKey">The type of the document Id.</typeparam>
    public interface IBaseMongoRepository_Delete<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Deletes a document.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="document">The document you want to delete.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteOne<TDocument>(TDocument document)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes a document.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="document">The document you want to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteOne<TDocument>(TDocument document, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="document">The document you want to delete.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteOneAsync<TDocument>(TDocument document)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="document">The document you want to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteOneAsync<TDocument>(TDocument document, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;


        /// <summary>
        ///     Asynchronously deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes a document matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes a list of documents.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="documents">The list of documents to delete.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteManyAsync<TDocument>(IEnumerable<TDocument> documents)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Asynchronously deletes a list of documents.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="documents">The list of documents to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        Task<long> DeleteManyAsync<TDocument>(IEnumerable<TDocument> documents, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes a list of documents.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="documents">The list of documents to delete.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteMany<TDocument>(IEnumerable<TDocument> documents)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes a list of documents.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="documents">The list of documents to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteMany<TDocument>(IEnumerable<TDocument> documents, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>;

        /// <summary>
        ///     Deletes the documents matching the condition of the LINQ expression filter.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The number of documents deleted.</returns>
        long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>;
    }
}
