// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BitcoinMessageVerify.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
