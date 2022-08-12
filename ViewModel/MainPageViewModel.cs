namespace FitForTime.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    #region Private Fields

    /// <summary>
    /// Backing field for the ISugarWodManager property
    /// </summary>
    private readonly ISugarWodManager sugarWodManager;

    /// <summary>
    /// Backing field for the CancellationTokenSource property
    /// </summary>
    private CancellationTokenSource cancellationTokenSource;

    /// <summary>
    /// Backing field for the CancellationToken property
    /// </summary>
    private CancellationToken cancellationToken;

    /// <summary>
    /// Backing field for the page link
    /// </summary>
    private string link;

    [ObservableProperty]
    private bool hasNextPage;

    /// <summary>
    /// Backing field for the isBusy property
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    /// <summary>
    /// Backing field for the coaches property
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<Datum> coaches = new();
    #endregion

    /// <summary>
    /// Defines the MainPageViewModel class.
    /// </summary>
    /// <param name="manager">The ISugarWodManager singleton</param>
    public MainPageViewModel(ISugarWodManager manager)
    {
        // wire up our services
        sugarWodManager = manager;
    }

    /// <summary>
    /// Gets the IsNotBusy property
    /// </summary>
    public bool IsNotBusy => !this.IsBusy;

    /// <summary>
    /// Gets a list of coaches
    /// </summary>
    /// <returns>A task</returns>
    [RelayCommand]
    public async Task GetCoachesAsync()
    {
        try
        {
            this.IsBusy = true;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            var result = await sugarWodManager.GetAthletesAsync("athletes", cancellationToken);
            if (result.IsSuccess)
            {
                var athletes = result.Value?.Data;

                if (athletes == null)
                {
                    // TODO: MessageService.Show -> Result.Fail<T>("Response success but no results returned");
                    return;
                }

                foreach (var athlete in athletes)
                {
                    this.Coaches.Add(athlete);
                }

                link = result.Value.Links?.Next?.ToString();
                this.HasNextPage = !string.IsNullOrWhiteSpace(this.link);
            }
        }
        catch (Exception ex)
        {
            // TODO: Log exception
        }
        finally
        {
            this.IsBusy = false;
            cancellationTokenSource?.Dispose();
        }
    }
}

