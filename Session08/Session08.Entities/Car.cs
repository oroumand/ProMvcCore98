using System.ComponentModel;

namespace Session08.Entities
{
    public class KeyValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Car : INotifyPropertyChanged,INotifyPropertyChanging
    {
        private int _carId;

        public int CarId
        {
            get
            {
                return _carId;
            }
            set
            {
                if (_carId != value)
                {
                    //PropertyChanging
                    _carId = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CarId"));
                }
            }

        }
        public int MyProperty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    }
}
