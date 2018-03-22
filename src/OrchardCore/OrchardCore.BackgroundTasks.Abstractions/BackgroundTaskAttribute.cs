using System;

namespace OrchardCore.BackgroundTasks
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BackgroundTaskAttribute : Attribute
    {
        public bool Enable { get; set; } = true;
        public string Schedule { get; set; } = "* * * * *";
    }
}
