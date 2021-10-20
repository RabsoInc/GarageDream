using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.BaseModels.System;
using Services.Interfaces.Dapper;
using Services.Interfaces.System;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ISystemJob SystemJobService;
        private readonly IDapper DapperService;
        private readonly IConfiguration ConfigurationService;
        private readonly ISystemJobHistory SystemJobHistoryService;

        public HomeController(ISystemJob SystemJobService, IDapper DapperService, IConfiguration ConfigurationService, ISystemJobHistory SystemJobHistoryService)
        {
            this.SystemJobService = SystemJobService;
            this.DapperService = DapperService;
            this.ConfigurationService = ConfigurationService;
            this.SystemJobHistoryService = SystemJobHistoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SystemJob> SystemJobsToRun = SystemJobService.AllAutoRunSystemJobs();
            foreach (var job in SystemJobsToRun)
            {
                SystemJob Job = SystemJobService.ReturnSingleRecord(job.SystemJobId);
                DapperService.ManualRunSystemJob(
                    Job
                    , ConfigurationService.GetConnectionString("Default"));
                SystemJobHistory history = new();
                history.SystemJobHistoryId = Guid.NewGuid();
                history.SystemJob = Job;
                history.DateExecuted = DateTime.Now;
                history.AutoExecuted = false;

                SystemJobHistoryService.CreateNewRecord(history);
                SystemJobHistoryService.SaveChanges();
            }
            return View();
        }
    }
}
