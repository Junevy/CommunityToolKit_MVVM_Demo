using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IoC_WPF_Demo.Services;
using Serilog;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace IoC_WPF_Demo
{
    partial class MainWindowViewModel : ObservableRecipient
    {
        private readonly ILogger Log;
        private readonly ICatFacts _catFacts;
        public ObservableCollection<string> FactList { get; } = [];

        [ObservableProperty]
        private int limit;

        public MainWindowViewModel(ILogger logger, ICatFacts catFacts)
        {
            this.Log = logger;
            this._catFacts = catFacts;
            Log.Information("Application Initialized.");
        }

        [RelayCommand]
        async Task GetFacts(string limit)
        {
            FactList.Clear();
            var facts = await _catFacts
                .GetCatFactsAsync
                    (int.TryParse(limit, out var n) && n != 0 ? n : 1);
            foreach (var fact in facts)
            {
                FactList.Add(fact);
            }
        }
    }
}
