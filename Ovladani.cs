using Microsoft.Xna.Framework.Input;

namespace MiniCtverecek
{
    class RidiciKlavesy
    {
        public Keys SmerDoprava { get; private set; }
        public Keys SmerDoleva { get; private set; }
        public Keys SmerNahoru { get; private set; }
        public Keys SmerDolu { get; private set; }

        public RidiciKlavesy(Keys smerDoleva, Keys smerDoprava, Keys smerNahoru, Keys smerDolu)
        {
            SmerDoprava = smerDoprava;
            SmerDoleva = smerDoleva;
            SmerNahoru = smerNahoru;
            SmerDolu = smerDolu;
        }
    }
}
