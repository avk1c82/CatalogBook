using CatalogBook.Wpf.Infrastructure.Commands.Base;
using System;

namespace CatalogBook.Wpf.Infrastructure.Commands
{
    public class ActionCommand : BaseCommand
    {
        private readonly Action<object> _execute;

        private readonly Func<object, bool>? _canExecute;

        public ActionCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;

            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            if(_canExecute is null)
            {
                return true;
            }

            return _canExecute.Invoke(parameter);
        }

        public override void Execute(object? parameter)
        {
            if(!CanExecute(parameter))
            {
                return;
            }

            _execute(parameter);
        }
    }
}
