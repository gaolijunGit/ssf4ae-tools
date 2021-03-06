﻿using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace RainbowLib.BAC
{
    [Serializable]
    public class Script : INotifyPropertyChanged, ICloneable
    {
        public int Index { get; set; }

        public static Script NullScript = new Script(-1,"NONE");
        public Script(int index,string Name = null)
        {
            this.Index = index;
            this.Name = Name;
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public override string ToString()
        {
            return Name;
        }

        public object Clone()
        {
            var clone = Cloner.ShallowCopy(this);
            clone._CommandLists = new ObservableCollection<dynamic>();
            for (int i = 0; i < 13; i++)
            {
                clone._CommandLists.Add(Cloner.Clone(this._CommandLists[i]));
            }

            clone.Name = this.Name + "_COPY";
            return clone;
        }

        private ushort _FirstHitboxFrame;
        public ushort FirstHitboxFrame
        {
            get { return _FirstHitboxFrame; }
            set
            {
                _FirstHitboxFrame = value;
                OnPropertyChanged("FirstHitboxFrame");
            }
        }
        private ushort _LastHitboxFrame;
        public ushort LastHitboxFrame
        {
            get { return _LastHitboxFrame; }
            set
            {
                _LastHitboxFrame = value;
                OnPropertyChanged("LastHitboxFrame");
            }
        }
        private ushort _LastCancelableFrame;
        public ushort IASAFrame
        {
            get { return _LastCancelableFrame; }
            set
            {
                _LastCancelableFrame = value;
                OnPropertyChanged("LastCancelableFrame");
            }
        }
        private ushort _TotalFrames;
        public ushort TotalFrames
        {
            get { return _TotalFrames; }
            set
            {
                _TotalFrames = value;
                OnPropertyChanged("TotalFrames");
            }
        }
        private uint _UnknownFlags1;
        public uint UnknownFlags1
        {
            get { return _UnknownFlags1; }
            set
            {
                _UnknownFlags1 = value;
                OnPropertyChanged("UnknownFlags1");
            }
        }
        private uint _UnknownFlags2;
        public uint UnknownFlags2
        {
            get { return _UnknownFlags2; }
            set
            {
                _UnknownFlags2 = value;
                OnPropertyChanged("UnknownFlags2");
            }
        }
        private ushort _UnknownFlags3;
        public ushort UnknownFlags3
        {
            get { return _UnknownFlags3; }
            set
            {
                _UnknownFlags3 = value;
                OnPropertyChanged("UnknownFlags3");
            }
        }
         
        [NonSerialized]
        private ObservableCollection<dynamic> _CommandLists = new ObservableCollection<dynamic>();
        public ObservableCollection<dynamic> CommandLists
        {
            get { return _CommandLists; }
        }
         [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
    }
}
