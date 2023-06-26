using HiDLL002;
namespace HiDLL001
{
    public class HiClass001
    {
        public string GetHi()
        {
            var obj = new HiClass002();
            return obj.GetHi();
        }
    }
}