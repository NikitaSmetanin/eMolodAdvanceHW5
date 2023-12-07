using System;
using System.Collections.Generic;
using System.Text;

namespace DZ7
{
    class Computer
    {
        private Motherboard motherboard;
        private PowerSupply powerSupply;
        public Computer(Motherboard motherboard, PowerSupply powerSupply)
        {
            this.motherboard = motherboard;
            this.powerSupply = powerSupply;
        }
        public void showComponents(List<ComputerComponent> components)
        {
            components.ForEach(component => { Console.WriteLine(component.getInfo()); });
        }
    }
    abstract class ComputerComponent
    {
        protected string name;
        protected double cost;
        public ComputerComponent(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }
        public string getName() { return name; }
        public double getCost() { return cost; }
        virtual public string getInfo()
        {
            return getName() + " " + getCost() + " грн.";
        }
    }
    class Motherboard : ComputerComponent {
        private CPU cpu;
        private GPU gpu;
        private List<RAM> ram;
        private List<SSD> ssd;
        public Motherboard(string name, double cost, CPU cpu, GPU gpu, List<RAM> ram, List<SSD> ssd) : base(name, cost)
        {
            this.ram = ram;
            this.ssd = ssd;
            this.cpu = cpu;
            this.gpu = gpu;
        }        
    }
    class SSD : ComputerComponent
    {
        private int amount;       
        public SSD(string name, double cost, int amount) : base(name, cost)
        {
            this.amount = amount;
        }
         public int getAmount()
        {
            return amount;
        }
        override public string getInfo()
        {
            return base.getInfo() + " " + getAmount() + " Gb";
        }
    }
    class RAM : ComputerComponent
    {
        private int amount;
        public RAM(string name, double cost, int amount) : base(name, cost)
        {
            this.amount = amount;
        }
        public int getAmount()
        {
            return amount;
        }
        override public string getInfo()
        {
            return base.getInfo() + " " + getAmount() + " Gb";
        }
    }
    class CPU : ComputerComponent
    {
        private double frequency;
        public CPU(string name, double cost, double frequency) : base(name, cost)
        {
            this.frequency = frequency;
        }
        public double getFrequency()
        {
            return frequency;
        }
        override public string getInfo()
        {
            return base.getInfo() + " " + getFrequency() + " GHz";
        }
    } 
    class GPU : ComputerComponent
    {
        private int amount;
        public GPU(string name, double cost, int amount) : base(name, cost)
        {
            this.amount = amount;
        }
        public int getAmount()
        {
            return amount;
        }
        override public string getInfo()
        {
            return base.getInfo() + " " + getAmount() + " Gb";
        }
    }    
    class PowerSupply : ComputerComponent
    {
        private int power;
        public PowerSupply(string name, double cost, int power) : base(name, cost)
        {
            this.power = power;
        }
        public int getPower()
        {
            return power;
        }
        override public string getInfo()
        {
            return base.getInfo() + " " + getPower() + " W";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            PowerSupply powerSupply = new PowerSupply("Блок живлення Vinga 400W ОЕМ (PSU-400-12 black)", 750, 400);
            CPU cpu = new CPU("Процессор INTEL Core i3 10105F", 3000, 3.7);
            GPU gpu = new GPU("Відеокарта GIGABYTE GeForce RTX3050 8Gb WINDFORCE OC (GV-N3050WF2OC-8GD)", 9800, 8);
                        
            List<RAM> ram = new List<RAM>();
            ram.Add(new RAM("Модуль пам'яті для комп'ютера DDR4 8GB 2666 MHz Goodram(GR2666D464L19S / 8G)", 700, 8));
            ram.Add(new RAM("Модуль пам'яті для комп'ютера DDR4 8GB 2666 MHz Goodram(GR2666D464L19S / 8G)", 700, 8));
            
            List<SSD> ssd = new List<SSD>();
            ssd.Add(new SSD("Накопичувач SSD 2.5\" 240GB Kingston (SA400S37/240G)", 1070, 240));

            Motherboard motherboard = new Motherboard("Материнська плата ASUS PRIME H510M-K", 2700, cpu, gpu, ram, ssd);

            List<ComputerComponent> components = new List<ComputerComponent>();
            components.Add(powerSupply);
            components.Add(cpu);
            components.Add(gpu);
            ram.ForEach(item => { components.Add(item); });
            ssd.ForEach(item => { components.Add(item); });
            components.Add(motherboard);

            Computer computer = new Computer(motherboard, powerSupply);
            computer.showComponents(components);
        }
    }
}
