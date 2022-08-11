using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class Model: INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _isDone;
        private string text;

        public bool isDone
        {
            get { return _isDone; }

            set 
            {
                if (_isDone = value) 
                {
                    return;
                }
                _isDone = value;

                OnPropertyChanged("IsDode");

                
            }
        }

        public string Text
        {
            get { return text; }

            set 
            {
                if (text == value) 
                {
                    return;
                }
                text = value;

                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name = "")
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            
        }
    }
}
