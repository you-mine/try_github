using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using LivetApp1.Models;

namespace LivetApp1.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region MyMessageProperty
        private string _MyMessage;

        public string MyMessage
        {
            get
            { return _MyMessage; }
            set
            {
                if (_MyMessage == value)
                    return;
                _MyMessage = value;
                RaisePropertyChanged();
                System.Diagnostics.Debug.WriteLine("MyMessage: " + this.MyMessage); //動作確認用。本来はこの行は必要ありません。

            }
        }

        
        #endregion

        #region MyDatetProperty
        private DateTime _MyDate;

        public DateTime MyDate
        {
            get
            { return _MyDate; }
            set
            { 
                if (_MyDate == value)
                    return;
                _MyDate = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region TestCommand
        private ViewModelCommand _TestCommand;

        public ViewModelCommand TestCommand
        {
            get
            {
                if (_TestCommand == null)
                {
                    _TestCommand = new ViewModelCommand(Test);
                }
                return _TestCommand;
            }
        }
        public void Test()
        {
            System.Diagnostics.Debug.WriteLine("TestCommand が呼ばれました。");
        }
        #endregion

        #region ListenerCommand
        private ListenerCommand<string> _Test2Command;

        public ListenerCommand<string> Test2Command
        {
            get
            {
                if (_Test2Command == null)
                {
                    _Test2Command = new ListenerCommand<string>(Test2);
                }
                return _Test2Command;
            }
        }

        //public  object Messenger { get; private set; }

        public void Test2(string parameter)
        {
            System.Diagnostics.Debug.WriteLine("Test2Command が呼ばれました。パラメータは「" + parameter + "」です。");
        }
        #endregion



        public void Initialize()
        {
            var message = new TransitionMessage(typeof(Views.Logon), new LogonViewModel(), TransitionMode.Modal, "ShowLogon");
            Messenger.Raise(message);
            this.MyMessage = "こんにちは";

             message = new TransitionMessage(typeof(Views.Botan), new BotanViewModel(), TransitionMode.Modal, "Show");
            Messenger.Raise(message);
        }
    }




    }

