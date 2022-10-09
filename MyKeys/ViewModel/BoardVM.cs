using System;
using System.Collections.Generic;
using System.Linq;

namespace MyKeys.ViewModel
{
    internal class BoardVM : VM
    {
        private int width = GameInfo.PossibleColumnNumber.Min();
        public int Width
        {
            get => width;
            set { if (Set(ref width, value)) { GenerateCells(); } }
        }

        private int height = GameInfo.PossibleRowNumber.Min();
        public int Height
        {
            get => height;
            set { if (Set(ref height, value)) { GenerateCells(); } }
        }

        private CellVM[,] cells;

        public IEnumerable<CellVM> AllCells => cells.Cast<CellVM>();

        void GenerateCells()
        {
            var cells = new CellVM[width, height];
            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    cells[column, row] = new CellVM(row, column, OnCellActivate);
            ShuffleAngles(cells);
            this.cells = cells;
            RaisePropertyChanged(nameof(AllCells));
        }
        static Random random = new Random();
        void ShuffleAngles(CellVM[,] cells)
        {
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    cells[x, y].RotationAngle = random.Next(4) * 90;
        }
        void OnCellActivate(int row0, int column0)
        {
            for (int row = 0; row < height; row++)
            {
                Rotate(cells[column0, row]);
            }

            for (int column = 0; column < width; column++)
            {
                if (column != column0)
                    Rotate(cells[column, row0]);
            }
        }

        private void Rotate(CellVM cellVM)
        {
            cellVM.RotationAngle = (cellVM.RotationAngle + 90) % 360;
        }
        public BoardVM()
        {
            GenerateCells();
        }
    }
}
