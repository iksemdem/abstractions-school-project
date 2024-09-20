using System;

namespace abstrakcja
{
    public interface IAbstrakcyjnaFabryka
    {
        IKrzesloNowe StworzKrzesloNowe();

        IKrzesloStare StworzKrzesloStare();
    }

    class FabrykaKrzesel : IAbstrakcyjnaFabryka
    {
        public IKrzesloNowe StworzKrzesloNowe()
        {
            return new KrzesloNowe1();
        }

        public IKrzesloStare StworzKrzesloStare()
        {
            return new KrzesloStare1();
        }
    }

    class FabrykaStolow : IAbstrakcyjnaFabryka
    {
        public IKrzesloNowe StworzKrzesloNowe()
        {
            return new KrzesloNowe2();
        }

        public IKrzesloStare StworzKrzesloStare()
        {
            return new KrzesloStare2();
        }
    }

    public interface IKrzesloNowe
    {
        string UsefulFunctionA();
    }

    class KrzesloNowe1 : IKrzesloNowe
    {
        public string UsefulFunctionA()
        {
            return "Rezultat krzesla nowego 1.";
        }
    }

    class KrzesloNowe2 : IKrzesloNowe
    {
        public string UsefulFunctionA()
        {
            return "Rezultat krzesla nowego 2.";
        }
    }

    public interface IKrzesloStare
    {

        string UsefulFunctionB();

        string AnotherUsefulFunctionB(IKrzesloNowe collaborator);
    }

    class KrzesloStare1 : IKrzesloStare
    {
        public string UsefulFunctionB()
        {
            return "Rezltat krzesła starego 1.";
        }

        public string AnotherUsefulFunctionB(IKrzesloNowe collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"Rezultat krzesła starego 1 z ({result})";
        }
    }

    class KrzesloStare2 : IKrzesloStare
    {
        public string UsefulFunctionB()
        {
            return "Rwzultat krzesła starego 2";
        }

        public string AnotherUsefulFunctionB(IKrzesloNowe collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"Rezultat krzesła starego 2 z ({result})";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Klient: testowanie z krzesłami 1");
            ClientMethod(new FabrykaKrzesel());
            Console.WriteLine();

            Console.WriteLine("Klient: testowanie z krzesłami 2");
            ClientMethod(new FabrykaStolow());
        }

        public void ClientMethod(IAbstrakcyjnaFabryka factory)
        {
            var productA = factory.StworzKrzesloNowe();
            var productB = factory.StworzKrzesloStare();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}