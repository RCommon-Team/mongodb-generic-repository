﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDbGenericRepository.DataAccess.Index;
using MongoDbGenericRepository.Models;

namespace MongoDbGenericRepository
{
    /// <summary>
    ///     The base Repository, it is meant to be inherited from by your custom custom MongoRepository implementation.
    ///     Its constructor must be given a connection string and a database name.
    /// </summary>
    public abstract partial class BaseMongoRepository<TKey> : IBaseMongoRepository_Index<TKey>
        where TKey : IEquatable<TKey>
    {
        private IMongoDbIndexHandler _mongoDbIndexHandler;

        /// <summary>
        ///     The MongoDb accessor to manage indexes.
        /// </summary>
        protected virtual IMongoDbIndexHandler MongoDbIndexHandler
        {
            get
            {
                if (_mongoDbIndexHandler != null)
                {
                    return _mongoDbIndexHandler;
                }

                lock (_initLock)
                {
                    if (_mongoDbIndexHandler == null)
                    {
                        _mongoDbIndexHandler = new MongoDbIndexHandler(MongoDbContext);
                    }
                }

                return _mongoDbIndexHandler;
            }
            set => _mongoDbIndexHandler = value;
        }

        /// <inheritdoc />
        public virtual async Task<List<string>> GetIndexesNamesAsync<TDocument>()
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.GetIndexesNamesAsync<TDocument, TKey>();
        }

        /// <inheritdoc />
        public virtual async Task<List<string>> GetIndexesNamesAsync<TDocument>(CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.GetIndexesNamesAsync<TDocument, TKey>(cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<List<string>> GetIndexesNamesAsync<TDocument>(string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.GetIndexesNamesAsync<TDocument, TKey>(partitionKey);
        }

        /// <inheritdoc />
        public virtual async Task<List<string>> GetIndexesNamesAsync<TDocument>(string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.GetIndexesNamesAsync<TDocument, TKey>(partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(Expression<Func<TDocument, object>> field)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateTextIndexAsync(field, null, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateTextIndexAsync(field, null, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, IndexCreationOptions indexCreationOptions)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateTextIndexAsync(field, indexCreationOptions, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateTextIndexAsync(field, indexCreationOptions, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateTextIndexAsync(field, indexCreationOptions, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateTextIndexAsync(field, null, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateTextIndexAsync(field, null, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateTextIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.CreateTextIndexAsync<TDocument, TKey>(field, indexCreationOptions, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(Expression<Func<TDocument, object>> field)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateAscendingIndexAsync(field, null, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateAscendingIndexAsync(field, null, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateAscendingIndexAsync(field, indexCreationOptions, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateAscendingIndexAsync(field, indexCreationOptions, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateAscendingIndexAsync(field, null, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateAscendingIndexAsync(field, null, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateAscendingIndexAsync(field, indexCreationOptions, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateAscendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.CreateAscendingIndexAsync<TDocument, TKey>(field, indexCreationOptions, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(Expression<Func<TDocument, object>> field)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateDescendingIndexAsync(field, null, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateDescendingIndexAsync(field, null, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateDescendingIndexAsync(field, indexCreationOptions, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateDescendingIndexAsync(field, indexCreationOptions, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateDescendingIndexAsync(field, null, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateDescendingIndexAsync(field, null, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateDescendingIndexAsync(field, indexCreationOptions, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateDescendingIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.CreateDescendingIndexAsync<TDocument, TKey>(field, indexCreationOptions, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(Expression<Func<TDocument, object>> field)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateHashedIndexAsync(field, null, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateHashedIndexAsync(field, null, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateHashedIndexAsync(field, indexCreationOptions, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateHashedIndexAsync(field, indexCreationOptions, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(Expression<Func<TDocument, object>> field, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateHashedIndexAsync(field, null, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateHashedIndexAsync(field, null, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateHashedIndexAsync(field, indexCreationOptions, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateHashedIndexAsync<TDocument>(
            Expression<Func<TDocument, object>> field,
            IndexCreationOptions indexCreationOptions,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.CreateHashedIndexAsync<TDocument, TKey>(field, indexCreationOptions, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(IEnumerable<Expression<Func<TDocument, object>>> fields)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateCombinedTextIndexAsync(fields, null, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(
            IEnumerable<Expression<Func<TDocument, object>>> fields,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateCombinedTextIndexAsync(fields, null, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(
            IEnumerable<Expression<Func<TDocument, object>>> fields,
            IndexCreationOptions indexCreationOptions)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateCombinedTextIndexAsync(fields, indexCreationOptions, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(
            IEnumerable<Expression<Func<TDocument, object>>> fields,
            IndexCreationOptions indexCreationOptions,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateCombinedTextIndexAsync(fields, indexCreationOptions, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(IEnumerable<Expression<Func<TDocument, object>>> fields, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateCombinedTextIndexAsync(fields, null, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(
            IEnumerable<Expression<Func<TDocument, object>>> fields,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateCombinedTextIndexAsync(fields, null, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(
            IEnumerable<Expression<Func<TDocument, object>>> fields,
            IndexCreationOptions indexCreationOptions,
            string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            return await CreateCombinedTextIndexAsync(fields, indexCreationOptions, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<string> CreateCombinedTextIndexAsync<TDocument>(
            IEnumerable<Expression<Func<TDocument, object>>> fields,
            IndexCreationOptions indexCreationOptions,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            return await MongoDbIndexHandler.CreateCombinedTextIndexAsync<TDocument, TKey>(fields, indexCreationOptions, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task DropIndexAsync<TDocument>(string indexName)
            where TDocument : IBusinessEntity<TKey>
        {
            await DropIndexAsync<TDocument>(indexName, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task DropIndexAsync<TDocument>(string indexName, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            await DropIndexAsync<TDocument>(indexName, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task DropIndexAsync<TDocument>(string indexName, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
        {
            await DropIndexAsync<TDocument>(indexName, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task DropIndexAsync<TDocument>(string indexName, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
        {
            await MongoDbIndexHandler.DropIndexAsync<TDocument, TKey>(indexName, partitionKey, cancellationToken);
        }
    }
}