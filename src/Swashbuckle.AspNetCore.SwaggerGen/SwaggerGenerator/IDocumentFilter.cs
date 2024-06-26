﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    public interface IDocumentFilter
    {
        void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context);
    }

    public interface IDocumentAsyncFilter
    {
        Task ApplyAsync(OpenApiDocument swaggerDoc, DocumentFilterContext context, CancellationToken cancellationToken);
    }

    public class DocumentFilterContext
    {
        public DocumentFilterContext(
            IEnumerable<ApiDescription> apiDescriptions,
            ISchemaGenerator schemaGenerator,
            SchemaRepository schemaRepository)
        {
            ApiDescriptions = apiDescriptions;
            SchemaGenerator = schemaGenerator;
            SchemaRepository = schemaRepository;
        }

        public IEnumerable<ApiDescription> ApiDescriptions { get; }

        public ISchemaGenerator SchemaGenerator { get; }

        public SchemaRepository SchemaRepository { get; }

        public string DocumentName => SchemaRepository.DocumentName;
    }
}
