// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

namespace BitcoinMessageVerify.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private string? _BitcoinAddress;    
    public string? BitcoinAddress
    {
        get => _BitcoinAddress;
        set
        {
            _BitcoinAddress = value;
            OnPropertyChanged(nameof(BitcoinAddress));
        }
    }

    private string? _Message;
    public string? Message 
    { 
        get => _Message;
        set
        {
            _Message = value;
            OnPropertyChanged(nameof(Message));
        }
    }

    private string? _SignedMessage;
    public string? SignedMessage
    {
        get => _SignedMessage;
        set
        {
            _SignedMessage = value;
            OnPropertyChanged(nameof(SignedMessage));
        }
    }

    private bool _IsBusy = false;
    public bool IsBusy
    {
        get => _IsBusy;
        set
        {
            _IsBusy = value;
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    private string? _ErrorMessage;
    public string? ErrorMessage 
    { 
        get => _ErrorMessage;
        set
        {
            _ErrorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }

}
