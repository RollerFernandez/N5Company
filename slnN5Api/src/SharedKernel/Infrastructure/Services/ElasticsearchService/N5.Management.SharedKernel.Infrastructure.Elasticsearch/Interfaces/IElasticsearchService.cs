using Nest;
using System.Linq.Expressions;
namespace N5.Management.SharedKernel.Infrastructure.Elasticsearch.Interfaces
{
    public interface IElasticsearchService
    {
        Task<bool> IndexDocument<T>(T document, string indexName) where T : class;
        Task<bool> UpdateDocument<T>(T document, string indexName, Expression<Func<T, object>> idField) where T : class;
        Task<List<T>> SearchDocuments<T>(string indexName, QueryContainer query = null) where T : class;
    }
}
