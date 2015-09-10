using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MathUniversal.Model
{
    class MergeMatrix:ObservableObject
    {

        public MergeMatrix()
        {
            MatrixPanel panel = new MatrixPanel();
            Panels.Add(panel);
            _thisInstance = this;
        }

        private static MergeMatrix _thisInstance;
        public static MergeMatrix ThisInstance
        {
            get { return _thisInstance; }
        }

        private ObservableCollection<MatrixPanel> _panels= new ObservableCollection<MatrixPanel>();

        public ObservableCollection<MatrixPanel> Panels
        {
            get
            {
                return _panels;
            }
            private set
            {
                if (_panels==value)
                {
                    return;
                }

                _panels = value;
                RaisePropertyChanged("MatrixPanels");

            }
        }

        public void Add()
        {
            MatrixPanel newPanel = new MatrixPanel();
            Panels.Add(newPanel);
        }



    }
}
