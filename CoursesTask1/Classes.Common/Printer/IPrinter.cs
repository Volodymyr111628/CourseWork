namespace Classes.Common.Printer
{
    public interface IPrinter
    {
        void Print(string value);
        void Print(int value);
        void Print(object value);
        void Print(double value);
    }
}
