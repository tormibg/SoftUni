using System;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public abstract class Command
    {
        private string input;
        private string[] data;

        private Tester _judge;
        private readonly StudentsRepository _repository;
        private readonly DowloadManager _downloadManager;
        private readonly IOManager _inptuOutputManager;

        public string Input
        {
            get { return this.input; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.input = value;
            }
        }
        public string[] Data
        {
            get { return this.data; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                this.data = value;
            }
        }

        protected StudentsRepository Repository
        {
            get { return this._repository; }
        }
        protected Tester Judge
        {
            get { return this._judge; }
        }

        protected DowloadManager DownloadManager
        {
            get { return this._downloadManager; }
        }

        protected IOManager InptuOutputManager
        {
            get { return this._inptuOutputManager; }
        }   

        protected Command(string input, string[] data, Tester tester, StudentsRepository repository,
            DowloadManager dowloadManager, IOManager ioManager)
        {
            this.Input = input;
            this.Data = data;
            this._judge = tester;
            this._repository = repository;
            this._downloadManager = dowloadManager;
            this._inptuOutputManager = ioManager;
        }

        public abstract void Execute();
    }
}