
public abstract class Component
{
    public abstract string Operation();
}


class ConcreteComponent : Component
{
    public override string Operation()
    {
        return "ConcreteComponent";
    }
}


abstract class Decorator : Component
{
    protected Component _component;

    public Decorator(Component component)
    {
        this._component = component;
    }

    //public void SetComponent(Component component)
    //{
    //    this._component = component;
    //}


    public override string Operation()
    {
        if (this._component != null)
        {
            return this._component.Operation();
        }
        else
        {
            return string.Empty;
        }
    }
}

class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(Component comp) : base(comp)
    {
    }


    public override string Operation()
    {
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}


class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(Component comp) : base(comp)
    {
    }

    public override string Operation()
    {
        return $"ConcreteDecoratorB({base.Operation()})";
    }
}

public class Client
{
    public void ClientCode(Component component)
    {
        Console.WriteLine("RESULT: " + component.Operation());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();

        var simple = new ConcreteComponent();
        Console.WriteLine("Client:simple component:");
        client.ClientCode(simple);
        Console.WriteLine();


        ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
        ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
        Console.WriteLine("Client:  decorated component:");
        client.ClientCode(decorator2);
    }
}

//using System;
//using System.Collections.Generic;
//namespace Decorator.RealWorld
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {

//            Book book = new Book("Mahdi", "Decoratore", 10);
//            book.Display();

//            Video video = new Video("MahdiVideo", "Video", 23, 50);
//            video.Display();

//            Console.WriteLine("\nMaking video borrowable:");
//            Borrowable borrowvideo = new Borrowable(video);
//            borrowvideo.BorrowItem("Customer #1");
//            borrowvideo.BorrowItem("Customer #2");
//            borrowvideo.Display();

//            Console.ReadKey();
//        }
//    }

//    // 'Component' abstract class
//    public abstract class LibraryItem
//    {
//        private int numCopies;
//        public int NumCopies
//        {
//            get { return numCopies; }
//            set { numCopies = value; }
//        }
//        public abstract void Display();
//    }

//    //'ConcreteComponent' class
//    public class Book : LibraryItem
//    {
//        private string author;
//        private string title;
//        // Constructor
//        public Book(string author, string title, int numCopies)
//        {
//            this.author = author;
//            this.title = title;
//            this.NumCopies = numCopies;
//        }
//        public override void Display()
//        {
//            Console.WriteLine("\nBook ------ ");
//            Console.WriteLine(" Author: {0}", author);
//            Console.WriteLine(" Title: {0}", title);
//            Console.WriteLine(" # Copies: {0}", NumCopies);
//        }
//    }

//    //  'ConcreteComponent' class
//    public class Video : LibraryItem
//    {
//        private string director;
//        private string title;
//        private int playTime;
//        // Constructor
//        public Video(string director, string title, int numCopies, int playTime)
//        {
//            this.director = director;
//            this.title = title;
//            this.NumCopies = numCopies;
//            this.playTime = playTime;
//        }
//        public override void Display()
//        {
//            Console.WriteLine("\nVideo ----- ");
//            Console.WriteLine(" Director: {0}", director);
//            Console.WriteLine(" Title: {0}", title);
//            Console.WriteLine(" # Copies: {0}", NumCopies);
//            Console.WriteLine(" Playtime: {0}\n", playTime);
//        }
//    }

//    // 'Decorator' abstract class
//    public abstract class Decorator : LibraryItem
//    {
//        protected LibraryItem libraryItem;
//        // Constructor
//        public Decorator(LibraryItem libraryItem)
//        {
//            this.libraryItem = libraryItem;
//        }
//        public override void Display()
//        {
//            libraryItem.Display();
//        }
//    }

//    //'ConcreteDecorator' class
//    public class Borrowable : Decorator
//    {
//        protected readonly List<string> borrowers = new List<string>();
//        // Constructor
//        public Borrowable(LibraryItem libraryItem)
//            : base(libraryItem)
//        {
//        }
//        public void BorrowItem(string name)
//        {
//            borrowers.Add(name);
//            libraryItem.NumCopies--;
//        }
//        public void ReturnItem(string name)
//        {
//            borrowers.Remove(name);
//            libraryItem.NumCopies++;
//        }
//        public override void Display()
//        {
//            base.Display();
//            foreach (string borrower in borrowers)
//            {
//                Console.WriteLine(" borrower: " + borrower);
//            }
//        }
//    }
//}