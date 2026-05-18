using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolate.Types;

public class IssueInferCollectionNameTests
{
    [Fact]
    public async Task Paging_With_MultipleQueries_Can_Infer_Name_From_Type()
    {
        var exception = await Record.ExceptionAsync(
            async () => await new ServiceCollection()
                .AddGraphQLServer(disableDefaultSecurity: true)
                .AddIntegrationTestTypes()
                .AddGlobalObjectIdentification()
                .ModifyPagingOptions(o =>
                {
                    o.InferCollectionSegmentNameFromField = false;
                    o.InferConnectionNameFromField = false;
                })
                .BuildSchemaAsync());

        Assert.Null(exception);
    }
}
