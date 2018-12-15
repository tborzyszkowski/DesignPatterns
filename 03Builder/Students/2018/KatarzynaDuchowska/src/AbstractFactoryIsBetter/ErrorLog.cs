namespace Builder.AbstractFactoryIsBetter
{
    public class ErrorLog : Log
    {
        public ErrorLog(string msg)
        {
            type = "ERROR";
            message = msg;
        }
    }
}