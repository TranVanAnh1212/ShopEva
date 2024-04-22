
namespace ShopEva.Web.Models
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _shutdownFile;

        public Worker(ILogger<Worker> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _logger.LogInformation("Constructed");

            _shutdownFile = Environment.GetEnvironmentVariable("WEBJOBS_SHUTDOWN_FILE");

            if (!string.IsNullOrEmpty(_shutdownFile))
            {
                _logger.LogInformation($"WebJob WEBJOBS_SHUTDOWN_FILE Environment Variable: {_shutdownFile}");

                var fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(_shutdownFile));
                fileSystemWatcher.Created += OnChanged;
                fileSystemWatcher.Changed += OnChanged;
                fileSystemWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastWrite;
                fileSystemWatcher.IncludeSubdirectories = false;
                fileSystemWatcher.EnableRaisingEvents = true;
            }
            else
            {
                _logger.LogWarning($"WebJob WEBJOBS_SHUTDOWN_FILE Environment Variable not found");
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            _logger.LogInformation($"Filechanged: {e.FullPath}");
            _logger.LogInformation($"WebShutDownFile: {_shutdownFile}");

            _logger.LogInformation($"FileName: {Path.GetFileName(_shutdownFile)}");

            if (e.FullPath.IndexOf(Path.GetFileName(_shutdownFile), StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // Found the file mark this WebJob as finished
                _logger.LogInformation($"***WebJob shutdown file found - shutting down service***");
            }
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogInformation("Worker cancellation token finished ");
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Worker STARTING");

            await Task.Delay(millisecondsDelay: 2_000, cancellationToken: CancellationToken.None);

            _logger.LogInformation("StartAsync");

            await base.StartAsync(cancellationToken: cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Worker STOPPING: {time}", DateTimeOffset.Now);

            // Xóa thông tin của người dùng khỏi session
            _httpContextAccessor.HttpContext.Session.Remove("UserId");
            _httpContextAccessor.HttpContext.Session.Remove("UserName");

            await base.StopAsync(cancellationToken: cancellationToken);

            await Task.Delay(millisecondsDelay: 2_000, cancellationToken: CancellationToken.None);

            _logger.LogInformation("StopAsync");
        }
    }
}
