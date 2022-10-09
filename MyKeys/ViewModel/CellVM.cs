using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace MyKeys.ViewModel
{
    internal class CellVM : VM
    {
        public CellVM(int row, int column, Action<int, int> onActivate)
        {
            Row = row;
            Column = column;
            Activate = new RelayCommand(() => onActivate(row, column));
        }

        private double rotationAngle = 0;
        public double RotationAngle
        {
            get => rotationAngle;
            set => Set(ref rotationAngle, value);
        }

        public int Row { get; }
        public int Column { get; }

        public ICommand Activate { get; }
    }
}
