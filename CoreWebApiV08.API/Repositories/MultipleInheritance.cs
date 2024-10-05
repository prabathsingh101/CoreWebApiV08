namespace CoreWebApiV08.API.Repositories
{

    public interface IInterface
    {
        string Type { get; }

        int add(int x, int y);

        int mul(int x, int y);  
        
    }

    public class A : IInterface
    {
        public string Type { get { return "First"; } }


        public int add(int x, int y)
        {
            return x + y;
        }

        public int mul(int x, int y)
        {
            return (x * y);
        }
    }
    public class B : IInterface
    {
        public string Type { get { return "2nd"; } }


        public int add(int x, int y)
        {
            return x + y;
        }

        public int mul(int x, int y)
        {
            return x * y;
        }
    }

    public class C : IInterface
    {
        public string Type { get { return "3rd"; } }


        public int add(int x, int y)
        {
            return x + y;
        }

        public int mul(int x, int y)
        {
            return x * y;
        }
    }
}
