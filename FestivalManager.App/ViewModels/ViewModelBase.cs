﻿using FestivalManager.App.ViewModels.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FestivalManager.App.ViewModels
{
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
