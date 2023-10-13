namespace Naidis_Vorm
{
    public class Program
    {
        public static void Main()
        {
            Triangle triangle = new Triangle (50,1,53);
            Console.WriteLine(triangle.ExistTriangle);
            Console.ReadLine();
            //Application.Run(new TreeForm());
        }
    }
}