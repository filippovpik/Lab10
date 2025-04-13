namespace Task10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создаем дом
            Building home = new Building("Зелeный 22", 22.2, 1985);
            home.DisplayInfo();

            //Создаем многоэтажный дом
            MultiBuilding mHome = new MultiBuilding("Глаголева 9", 30.2, 2001, 5, true);

            //Upcasting
            Building buildingUpcast = mHome;
            Console.WriteLine("\nПосле upcasting:");
            buildingUpcast.DisplayInfo();

            //Downcasting            
            if (buildingUpcast is MultiBuilding)
            {
                MultiBuilding buildingDowcast = (MultiBuilding)buildingUpcast;
                Console.WriteLine("\nПосле downcasting:");
                buildingDowcast.DisplayInfo();
            }

            //Вызов переопределенного метода CalculateTax()
            Console.WriteLine($"\nНалог составляет: {mHome.CalculateTax()}");

            //Вызов переопределенного метода DisplayInfo()
            mHome.DisplayInfo();

            //Использование уникального метода производного класса AreaPerFloor
            Console.WriteLine($"\nСредняя площадь на этаж: {mHome.AreaPerFloor}");

            Console.ReadLine();
        }

        //базовый класс Building (описывает здание)
        public class Building
        {
            //Поля
            public string _address;
            public double _area;
            public int _yearBuilt;

            //Конструктор
            public Building(string address, double area, int yearBuilt)
            {
                _address = address;
                _area = area;
                _yearBuilt = yearBuilt;
            }

            //Виртуальный метод для вычисления налога
            public virtual double CalculateTax()
            {
                return _area * 1000;
            }

            //Виртуальный метод выводит информацию о здании
            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Адрес: {_address}; Площадь: {_area}; Год постройки: {_yearBuilt}");
            }

            //Свойство возраст дома
            public int BuildingAge
            {
                get => Convert.ToInt32(DateTime.Now.Year) - _yearBuilt;
            }
        }

        //Дочерний класс MultiBuilding (описывает многоэтажное здание)
        public sealed class MultiBuilding : Building
        {
            //Конструктор
            public MultiBuilding(string address, double area, int yearBuilt, int floors, bool hasElevator)
                : base(address, area, yearBuilt)
            {
                _floors=floors;
                _hasElevator=hasElevator;
            }

            //Новые поля
            public int _floors;
            public bool _hasElevator;

            //Новый налог
            public override double CalculateTax()
            {
                if (_hasElevator)
                {
                    return Math.Round((1 + (_floors - 1) * 0.05) * _area * 1000 + 5000, 2);
                }
                else
                {
                    return Math.Round((1 + (_floors - 1) * 0.05) * _area * 1000, 2);
                }
            }

            //Новый метод вывода вывода информации
            public override void DisplayInfo()
            {
                Console.WriteLine($"Адрес: {_address}; Площадь: {_area}; Год постройки: {_yearBuilt}; Этажность: {_floors}; Наличие лифта:{_hasElevator}");
            }

            //Новое свойство средняя площадь на этаж
            public double AreaPerFloor
            {
                get => Math.Round(_area / _floors, 2);
            }
        }
    }
}




