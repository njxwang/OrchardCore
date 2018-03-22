using System;
using System.Reflection;
using System.Threading.Tasks;

namespace OrchardCore.BackgroundTasks
{
    public class BackgroundTaskAttributeSettingsProvider : IBackgroundTaskSettingsProvider
    {
        public int Order => 100;

        public Task<BackgroundTaskSettings> GetSettingsAsync(Type type)
        {
            var attribute = type.GetCustomAttribute<BackgroundTaskAttribute>();

            if (attribute != null)
            {
                return Task.FromResult(new BackgroundTaskSettings
                {
                    Enable = attribute.Enable,
                    Schedule = attribute.Schedule
                });
            }

            return Task.FromResult(BackgroundTaskSettings.None);
        }
    }
}