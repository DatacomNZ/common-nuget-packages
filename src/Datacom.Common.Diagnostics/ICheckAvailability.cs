using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacom.Common.Diagnostics
{
    /// <summary>
    /// Indicates the ability to check health of service or component for a given system or components within the sytem
    /// 
    /// Example implementations might be a Datastore health checker, to ensure the database can be communicated with, and records can be read.
    /// </summary>
    public interface ICheckAvailability
    {
        /// <summary>
        /// Check the ensure the service this represents can be accessed. E.g. records can be read from the database, or files from a file system service.
        /// Intended to be polled frequently, so limit the extent and expense of the checks.
        /// Note, this should be non destructive, and not affect any data
        /// Can throw exceptions, as the consumer of this will explicitly handle exceptions
        /// </summary>
        /// <returns>true if happy happy joy joy, false if not</returns>
        Task<bool> CheckAccessAsync();

        /// <summary>
        /// Performs more extensive and expensive checks across the  service. E.g. Ensure all key tables can be read via the ORM for a Database.
        /// Note, this should be non destructive, and not affect any data
        /// </summary>
        /// <returns>true if all relevant items are accessible</returns>
        Task<bool> CheckAccessExtensivelyAsync();

        /// <summary>
        /// A label describing the resource being checked
        /// </summary>
        /// <returns>A concise label (20 characters or less)</returns>
        string GetLabel();

        /// <summary>
        /// Provide a list of warnings in relation to the service being monitored. E.g. for a file-store, the file system is nearing its capacity.
        /// </summary>
        /// <returns>Never null. Empty list in the case of no warnings.</returns>
        Task<List<string>> GetWarningsAsync();


        /// <summary>
        /// Provide a list of errors in relation to the service being monitored. E.g. for a filestore, the filesystem
        /// </summary>
        /// <returns>Never null. Empty list in the case of no errors.</returns>
        Task<List<string>> GetErrorsAsync();
    }
}
