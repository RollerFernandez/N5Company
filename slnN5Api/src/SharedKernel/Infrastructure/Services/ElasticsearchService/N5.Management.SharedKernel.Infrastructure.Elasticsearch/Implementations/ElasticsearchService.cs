
using Microsoft.Extensions.Options;
using N5.Management.SharedKernel.Infrastructure.Elasticsearch.Interfaces;
using Nest;
using System.Linq.Expressions;

namespace N5.Management.SharedKernel.Infrastructure.Elasticsearch.Implementations
{
    public class ElasticsearchOptions
    {
        public string Url { get; set; }
        public string DefaultIndex { get; set; }
    }

    public class ElasticsearchService: IElasticsearchService
    {
        private readonly IElasticClient _client;

        public ElasticsearchService(IOptions<ElasticsearchOptions> options)
        {
            var settings = new ConnectionSettings(new Uri(options.Value.Url))
                .DefaultIndex(options.Value.DefaultIndex);

            _client = new ElasticClient(settings);
        }

        public IElasticClient GetClient() => _client;

        public async Task<bool> IndexDocument<T>(T document, string indexName) where T : class
        {
            var response = await _client.IndexAsync(document, idx => idx.Index(indexName));
            return response.IsValid;
        }

        public async Task<bool> UpdateDocument<T>(T document, string indexName, Expression<Func<T, object>> idField) where T : class
        {
            var response = await _client.UpdateAsync<T>(new DocumentPath<T>(document), u => u
                .Index(indexName)
                .Doc(document)
                .DocAsUpsert());
            return response.IsValid;
        }

        public async Task<List<T>> SearchDocuments<T>(string indexName, QueryContainer query = null) where T : class
        {
            var searchResponse = await _client.SearchAsync<T>(s => s
                .Index(indexName)
                .Query(q => query ?? q.MatchAll())
                .Size(10000));

            return searchResponse.Documents.ToList();
        }
    }
}
