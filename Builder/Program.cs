
namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Код использования
            IHouseBuilder houseType = new CottageBuilder();

            string userChois = "";
            
            while (userChois != "1" && userChois != "2")
            {
                Console.WriteLine("Выберите дом: \n1. Одноэтажный \n2. Двухэтажный");
                userChois = Console.ReadLine();
                switch (userChois)
                {
                    case "1":
                        break;
                    case "2":
                        houseType = new TwoStoreyHouseBuilder();
                        break;
                    default:
                        Console.WriteLine("Такого дома нет!");
                        break;
                }
            }
            
            Director director = new Director(houseType);
            director.BuildHouse();
            var house = houseType.GetHouse();
            Console.WriteLine(house);
        }
    }
}

// Класс для описания дома
public class House
{
    public int Floors { get; set; }
    public int Rooms { get; set; }
    public bool HasGarage { get; set; }
    public bool HasGarden { get; set; }

    public override string ToString()
    {
        return $"Floors: {Floors}, Rooms: {Rooms}, Garage: {(HasGarage ? "Yes" : "No")}, Garden: {(HasGarden ? "Yes" : "No")}";
    }
}

// Интерфейс строителя
public interface IHouseBuilder
{
    void BuildFloors();
    void BuildRooms();
    void BuildGarage();
    void BuildGarden();
    House GetHouse();
}

// Реализация строителя
public class TwoStoreyHouseBuilder : IHouseBuilder
{
    private House house = new House();

    public void BuildFloors()
    {
        house.Floors = 2;
    }

    public void BuildRooms()
    {
        house.Rooms = 4;
    }

    public void BuildGarage()
    {
        house.HasGarage = true;
    }

    public void BuildGarden()
    {
        house.HasGarden = true;
    }

    public House GetHouse()
    {
        return house;
    }
}

public class CottageBuilder : IHouseBuilder
{
    private House house = new House();

    public void BuildFloors()
    {
        house.Floors = 1;
    }

    public void BuildRooms()
    {
        house.Rooms = 3;
    }

    public void BuildGarage()
    {
        house.HasGarage = false;
    }

    public void BuildGarden()
    {
        house.HasGarden = true;
    }

    public House GetHouse()
    {
        return house;
    }
}

// Класс, который будет использовать строитель для постройки дома
public class Director
{
    private IHouseBuilder houseBuilder;

    public Director(IHouseBuilder builder)
    {
        houseBuilder = builder;
    }

    public void BuildHouse()
    {
        houseBuilder.BuildFloors();
        houseBuilder.BuildRooms();
        houseBuilder.BuildGarage();
        houseBuilder.BuildGarden();
    }
}