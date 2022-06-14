namespace WebApi
{
    public class InputCheck
    {
        static public bool InputString(string forCheck, int count = -1)
        {
            if (forCheck.Length > 0)
            {
                if (count == -1 || forCheck.Length <= count) return true;
                else return false;
            }
            else return false;
        }
        static public bool InputNumber(int forCheck, int left = int.MinValue, int right = int.MaxValue)
        {
            if (forCheck >= left && forCheck <= right) return true;
            return false;
        }
    }
}
