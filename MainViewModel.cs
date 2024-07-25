using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace EigeneCommands
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CloseCommand {  get; }
        public MainViewModel()
        {
            inhalt = "";
            CloseCommand = new Command1(CloseApplication, CanCloseApplication);
        }

        private string inhalt;

        public string Inhalt
        {
            get { return inhalt; }
            set
            {
                if (inhalt != value)
                {
                    inhalt = value;
                    OnPropertyChanged(nameof(inhalt));
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private bool CanCloseApplication()
        {
            //return true;
            return Inhalt.ToLower() == "ende";
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
            //MessageBox.Show("hey");
        }

    }
}
