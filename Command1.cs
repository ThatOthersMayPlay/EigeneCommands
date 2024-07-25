using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EigeneCommands
{
    // Erstellung der Command1 - Klasse, die das Interface ICommand implementiert 
    public class Command1 : ICommand
    {
        // Variable _execute vom Typ Action kann eine Methode zugewiesen werden,
        // die keine Parameter hat und keinen Wert zurückgibt 
        // Variablen kann nur im Konstruktor einen Wert zurückgewiesen bekommen
        // und danach nur noch gelesen werden 
        private readonly Action _execute;
        // Variable _canExecute vom Typ Func<bool> kann eine Methode zugewiesen werden,
        // die keine Parameter hat und einen bool zurück gibt
        private readonly Func<bool> _canExecute;

        // 2. Parameter vom Konstruktor ist optional
        public Command1(Action execute, Func<bool> canExecute=null)
        {
            // _execute auf NULL überprüft
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute/* ?? throw new ArgumentNullException(nameof(canExecute))*/;
        }

        public event EventHandler CanExecuteChanged
        {   // Was Verwendung der Klasse CommandManager 
            // CommandManager verwendet, um Ereignismethoden hinzuzufügen
            // und wieder zu löschen
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return _canExecute();
            //return true;
        }

        public void Execute(object parameter)
        {
            // Ausführen der Action bzw. ausführen der Methode,
            // der der Variablen vom Typ Action zugewiesen wurde 
            _execute();
        }
    }

}
