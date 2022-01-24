using System.Threading;

namespace WindowsFormsApp1 //universal
{
    class Waiting
    {
        FastCheck fc = new FastCheck();
        SpecialEvents se = new SpecialEvents();
        
        public void ReadytoRace()
        {
            bool x;            
            do
            {
                se.UniversalErrorDefense();
                x = fc.ReadyToRace();
                Thread.Sleep(500);
            } while (!x);
        }        
    }
}