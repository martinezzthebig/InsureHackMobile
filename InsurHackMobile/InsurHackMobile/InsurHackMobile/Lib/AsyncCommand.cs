using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InsurHackMobile.Lib
{
    public class AsyncCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Func<T, Task> _action;
        private readonly Func<T, bool> _canExecuteAction;
        private Task task = null;

        public AsyncCommand(Func<T, Task> action, Func<T, bool> canExecuteAction = null)
        {
            _action = action;
            _canExecuteAction = canExecuteAction;
        }
        public AsyncCommand(Func<Task> action, Func<T, bool> canExecuteAction = null)
        {
            Task FakeFunc(T o) => action();
            _action = FakeFunc;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke((T)parameter) ?? task?.IsCompleted ?? true;

        public async void Execute(object parameter) => await ExecuteAsync((T)parameter);

        public async Task ExecuteAsync(T parameter)
        {
            task = _action(parameter);
            await task;
        }
    }
    public class AsyncCommand : AsyncCommand<object>
    {
        public AsyncCommand(Func<object, Task> action, Func<object, bool> canExecuteAction = null)
            : base(action, canExecuteAction)
        {
        }
        public AsyncCommand(Func<Task> action, Func<object, bool> canExecuteAction = null)
            : base(action, canExecuteAction)
        {
        }
    }
}
