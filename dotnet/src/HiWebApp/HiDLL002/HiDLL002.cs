namespace HiDLL002
{
    public class HiClass002
    {
        public string Name
        {
            get
            {
                return typeof(HiClass002).Name;
            }
        }

        public string GetHi()
        {
            return $"Hi in {typeof(HiClass002)}";
        }
    }
}