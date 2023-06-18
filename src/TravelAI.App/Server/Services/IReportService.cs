using TravelAI.App.Shared;

namespace TravelAI.App.Server.Services
{
    public interface IReportService
    {
        // return URL to generated report
        Task<string> GenerateReport(ReportModel model);
    }
}
