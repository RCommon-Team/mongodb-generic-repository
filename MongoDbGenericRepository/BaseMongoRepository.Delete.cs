﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDbGenericRepository.DataAccess.Delete;
using MongoDbGenericRepository.Models;

namespace MongoDbGenericRepository
{
    public abstract partial class BaseMongoRepository : IBaseMongoRepository_Delete
    {
        private IMongoDbEraser _mongoDbEraser;

        /// <summary>
        ///     The MongoDbEraser used to delete documents.
        /// </summary>
        protected virtual IMongoDbEraser MongoDbEraser
        {
            get
            {
                if (_mongoDbEraser != null)
                {
                    return _mongoDbEraser;
                }

                lock (_initLock)
                {
                    if (_mongoDbEraser == null)
                    {
                        _mongoDbEraser = new MongoDbEraser(MongoDbContext);
                    }
                }

                return _mongoDbEraser;
            }
            set => _mongoDbEraser = value;
        }

        #region Delete

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument>(TDocument document)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteOne(document, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument>(TDocument document, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteOne<TDocument, Guid>(document, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteOne(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteOne(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteOne(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteOne<TDocument, Guid>(filter, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument>(TDocument document)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteOneAsync(document, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument>(TDocument document, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteOneAsync<TDocument, Guid>(document, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteOneAsync(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteOneAsync(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteOneAsync(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument>(
            Expression<Func<TDocument, bool>> filter,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteOneAsync<TDocument, Guid>(filter, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteManyAsync(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteManyAsync(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteManyAsync(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public async Task<long> DeleteManyAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteManyAsync<TDocument, Guid>(filter, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument>(IEnumerable<TDocument> documents)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteManyAsync<TDocument, Guid>(documents);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument>(IEnumerable<TDocument> documents, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return await DeleteManyAsync<TDocument, Guid>(documents, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument>(IEnumerable<TDocument> documents)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteMany<TDocument, Guid>(documents, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument>(IEnumerable<TDocument> documents, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteMany<TDocument, Guid>(documents, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteMany(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteMany(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteMany(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<Guid>
        {
            return DeleteMany<TDocument, Guid>(filter, partitionKey, cancellationToken);
        }

        #endregion Delete

        #region Delete TKey

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument, TKey>(TDocument document)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteOne<TDocument, TKey>(document, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument, TKey>(TDocument document, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return MongoDbEraser.DeleteOne<TDocument, TKey>(document, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument, TKey>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteOne<TDocument, TKey>(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteOne<TDocument, TKey>(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteOne<TDocument, TKey>(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteOne<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return MongoDbEraser.DeleteOne<TDocument, TKey>(filter, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument, TKey>(TDocument document)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteOneAsync<TDocument, TKey>(document, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument, TKey>(TDocument document, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await MongoDbEraser.DeleteOneAsync<TDocument, TKey>(document, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument, TKey>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteOneAsync<TDocument, TKey>(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteOneAsync<TDocument, TKey>(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteOneAsync<TDocument, TKey>(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteOneAsync<TDocument, TKey>(
            Expression<Func<TDocument, bool>> filter,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await MongoDbEraser.DeleteOneAsync<TDocument, TKey>(filter, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument, TKey>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteManyAsync<TDocument, TKey>(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteManyAsync<TDocument, TKey>(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteManyAsync<TDocument, TKey>(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument, TKey>(
            Expression<Func<TDocument, bool>> filter,
            string partitionKey,
            CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await MongoDbEraser.DeleteManyAsync<TDocument, TKey>(filter, partitionKey, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument, TKey>(IEnumerable<TDocument> documents)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await DeleteManyAsync<TDocument, TKey>(documents, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual async Task<long> DeleteManyAsync<TDocument, TKey>(IEnumerable<TDocument> documents, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await MongoDbEraser.DeleteManyAsync<TDocument, TKey>(documents, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument, TKey>(IEnumerable<TDocument> documents)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteMany<TDocument, TKey>(documents, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument, TKey>(IEnumerable<TDocument> documents, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return MongoDbEraser.DeleteMany<TDocument, TKey>(documents, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument, TKey>(Expression<Func<TDocument, bool>> filter)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteMany<TDocument, TKey>(filter, null, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteMany<TDocument, TKey>(filter, null, cancellationToken);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, string partitionKey)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return DeleteMany<TDocument, TKey>(filter, partitionKey, CancellationToken.None);
        }

        /// <inheritdoc />
        public virtual long DeleteMany<TDocument, TKey>(Expression<Func<TDocument, bool>> filter, string partitionKey, CancellationToken cancellationToken)
            where TDocument : IBusinessEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return MongoDbEraser.DeleteMany<TDocument, TKey>(filter, partitionKey, cancellationToken);
        }

        #endregion
    }
}