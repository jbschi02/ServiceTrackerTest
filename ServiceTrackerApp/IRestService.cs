using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceTrackerApp
{
    public interface IRestService
    {
        Task<List<Jobs>> RefreshDataAsync();

        Task SaveJobsAsync(Jobs job, bool isNewJob);

        Task DeleteJobsAsync(string id);


    }
}
