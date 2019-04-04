using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using AutoDashboard.UniversalApp.Models;

namespace AutoDashboard.UniversalApp.ViewModels
{
    public class ConfigurationViewModel : INotifyPropertyChanged
    {
        //private string _selectedReader;
        //private DashboardViewModel _dashboardViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        //public ConfigurationViewModel(DashboardViewModel dashboardViewModel)
        //{
        //    this._dashboardViewModel = dashboardViewModel;
        //}

        //public ICommand UseReaderCommand { get; }

        //public IEnumerable<string> Readers { get; } = new string[]
        //{
        //    "Internal Simulator",
        //    "External Simulator",
        //};

        //public string SelectedReader
        //{
        //    get => _selectedReader;
        //    set
        //    {
        //        _selectedReader = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedReader)));
        //    }
        //}

        //private void UseReader()
        //{
        //    if (this.SelectedReader == "Internal Simulator")
        //    {
        //        _dashboardViewModel.AutoReader = new Simulator
        //    }
        //    else if (this.SelectedReader == "External Simulator")
        //    {

        //    }
        //}
    }
}
