using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement;
using OrchardCore.Workflows.Abstractions.Models;
using OrchardCore.Workflows.Models;

namespace OrchardCore.Contents.Workflows.Activities
{
    public class DeleteContentTask : ContentTask
    {
        public DeleteContentTask(IContentManager contentManager, IStringLocalizer<DeleteContentTask> localizer) : base(contentManager, localizer)
        {
        }

        public override string Name => nameof(DeleteContentTask);
        public override LocalizedString Category => T["Content"];
        public override LocalizedString Description => T["Delete a content item."];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            return Outcomes(T["Deleted"]);
        }

        public override async Task<IEnumerable<string>> ExecuteAsync(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            var content = await GetContentAsync(workflowContext);
            await ContentManager.RemoveAsync(content.ContentItem);
            return Outcomes("Deleted");
        }
    }
}