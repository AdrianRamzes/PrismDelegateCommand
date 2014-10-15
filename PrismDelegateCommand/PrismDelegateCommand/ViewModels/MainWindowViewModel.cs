using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using PrismDelegateCommand.Helpers;
using System.Diagnostics;
using Microsoft.Practices.Prism.Commands;

namespace PrismDelegateCommand.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if(_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(() => Message);
                }
            }
        }

        private string _input;
        public string Input
        {
            get
            {
                return _input;
            }

            set 
            {
                if(value != _input)
                {
                    _input = value;
                    RaisePropertyChanged(() => Input);
                    ClickCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand ClickCommand { get; private set; }

        public MainWindowViewModel()
        {
            ClickCommand = new DelegateCommand(Click, CanExecuteClick);
        }

        private int _count = 0;
        private void Click()
        {
            _count++;
            Message = string.Format("Click #{0}", _count);
        }

        private bool CanExecuteClick()
        {
            Debug.WriteLine("called CanExecuteClick: {0}; Input value: {1}", DateTime.Now, Input);

            return string.IsNullOrEmpty(Input) ? false : (Input.Length % 2) == 0;
        }
    }
}
