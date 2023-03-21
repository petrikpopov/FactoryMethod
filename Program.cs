using System;

namespace FactoryMethod
{
    interface Transport_interface
    {
        public void Fuelconsumption();// расход топлива

        public void Costofdelivery_Distance(); // стоимасть доставки

        public void Deliver();// растояние 
    }

    class Trac:Transport_interface
    {
       
        public void Fuelconsumption()
        {
            
            Console.WriteLine("Расход топлива используя перевозку с помощью грузовика 1000/100км = ");
        }

        public void Costofdelivery_Distance()
        {
            
            Console.WriteLine("Стоимость доставки  с помощью грузовика 2000/100км  = ");
        }

        public void Deliver()
        {
            Console.WriteLine("Доставка займет 2-3 часа");
        }
    }
    class Ship:Transport_interface
    {
       

        public void Fuelconsumption()
        {
            Console.WriteLine("Расход топлива используя перевозку с помощью корабля = 2000л/100км ");
        }
        public void Costofdelivery_Distance()
        {
            Console.WriteLine("Стоимость доставки  с помощью корабля = 10000грн/100км " );
        }
        public void Deliver()
        {
            Console.WriteLine("Доставка займет 3-3,5 часа ");
        }
       
    }
    class Air : Transport_interface
    {
        
        public void Fuelconsumption()
        {
            Console.WriteLine("Расход топлива используя перевозку с помощью самолета = 1678л/100км" );
        }
        public void Costofdelivery_Distance()
        {
            Console.WriteLine("Стоимость доставки с помощью самолета = 12900/100км" );
        }
        public void Deliver()
        {
            Console.WriteLine("Доставка займет 1-2 часа ");
        }
    }


    abstract class LOgistical//определяет интерфейс класса, объекты которого надо создавать
    {
        public void Operator()
        {
            var product = Transport();
            var result = "Result" + product.Fuelconsumption() + "\n" + product.Costofdelivery_Distance() + "\n" + product.Deliver();
            return result;
        }

        virtual public Transport_interface Transport() //фабричный метод 
        {
            return null;
        }
    }
    class AirLogist:LOgistical
    {
        public override Transport_interface Transport()
        {
            return new Air();
        }
    }
    class ShipLogist:LOgistical
    {
        public override Transport_interface Transport()
        {
            return new Ship();
        }
    }
    class TracLogist:LOgistical
    {
        public override Transport_interface Transport()
        {
            return new Trac();
        }
    }
    class Client
    {
        public void Clienter(LOgistical lOgistical)
        {
            Console.WriteLine("Хочу узнать данные о перевозке разными видами транспорта"+ lOgistical.Operator());
        }
        public void Main()
        {
          
           
            Clienter(new Air());
            Console.WriteLine();
            Clienter(new Ship());
            Console.WriteLine();
            Clienter(new Trac());
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] arr)
        {

            new Client().Main();
        }
    }
    
}