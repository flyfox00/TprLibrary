using System;
using System.ComponentModel;

namespace TprLibrary
{
    public class BodyRec : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private decimal? bw = 0;
        public decimal Bw
        {
            get => (decimal)bw;
            set
            {
                if (value != bw && value > 0)
                {
                    bw = value;
                    OnPropertyChanged(nameof(Bw));
                }
            }
        }

        private decimal? bh = 0;
        public decimal Bh
        {
            get => (decimal)bh;
            set
            {
                if (value != bh && value > 0)
                {
                    bh = value;
                    OnPropertyChanged(nameof(Bh));
                }
            }
        }

        public BodyRec() { }

        public event EventHandler OnConfirm;

        public void Confirm()
        {
            BodyEventArgs bodyEventArgs = new BodyEventArgs(this.Bw, this.Bh);
            // Update database
            OnConfirm?.Invoke(this, bodyEventArgs);
        }
    }

    public class BodyEventArgs : EventArgs
    {
        public decimal Bw { get; private set; }
        public decimal Bh { get; private set; }
        public BodyEventArgs(decimal bw, decimal bh)
        {
            this.Bw = bw;
            this.Bh = bh;
        }
    }

    public static class BodyRecExt
    {
        public static int Lastest(this BodyRec body)
        {
            // 最近一次
            int uid = 0;
            return uid;
        }
        public static int Insert(this BodyRec body)
        {
            // 新增紀錄
            int uid = 0;
            return uid;
        }

        public static bool Update(this BodyRec body, int uid)
        {
            // 更新紀錄
            return true;
        }

        public static bool Remove(this BodyRec body, int uid)
        {
            // 移除紀錄
            return true;
        }
    }
}
