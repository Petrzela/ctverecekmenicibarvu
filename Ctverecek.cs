using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiniCtverecek
{
    class Ctverecek

       
    {
        public int R = 0;
        public int G = 0;
        public int B = 0;
        public int A = 255;


       

        private GraphicsDevice ZobrazovaciZarizeni { get; set; }

        private int Velikost { get; set; }
        private float Rychlost { get; set; }

        private Vector2 Pozice { get; set; }
        public Color Barva { get; set; }


        private RidiciKlavesy Ovladani { get; set; }
        private Texture2D Textura { get; set; }

        public Ctverecek(int velikost, float rychlost, Vector2 pozice, Color barva, RidiciKlavesy ovladani, GraphicsDevice zobrazovaciZarizeni)
        {
            ZobrazovaciZarizeni = zobrazovaciZarizeni;

            Velikost = velikost;
            Rychlost = rychlost;

            Pozice = pozice;
            Barva = barva;

            Ovladani = ovladani;
            
            Textura = PripravitTexturu();
        }

        private Texture2D PripravitTexturu()
        {
            Texture2D textura;

            Color[] barevnaDataTextury = new Color[Velikost * Velikost];

            for (int i = 0; i < barevnaDataTextury.Length; i++)
                barevnaDataTextury[i] = Color.White;

            textura = new Texture2D(ZobrazovaciZarizeni, Velikost, Velikost);
            textura.SetData(barevnaDataTextury);

            return textura;
        }

        private void Pohnout(KeyboardState stavKlavesnice, Vector2 rozmeryPlatna)
        {
            Vector2 smerPohybu = Vector2.Zero;

            if (stavKlavesnice.IsKeyDown(Ovladani.SmerNahoru))
            { 
                smerPohybu -= Vector2.UnitY;
                Barva = Color.FromNonPremultiplied(R, G, B, A);
                do { G = G + 5; A = A + 5; } while (stavKlavesnice.IsKeyUp(Ovladani.SmerNahoru));

            }
            if (stavKlavesnice.IsKeyDown(Ovladani.SmerDolu))
            { 
                smerPohybu += Vector2.UnitY;
                Barva = Color.FromNonPremultiplied(R, G, B, A);
                do { G = G - 5; A = A - 5; } while (stavKlavesnice.IsKeyUp(Ovladani.SmerDolu));
            }
            if (stavKlavesnice.IsKeyDown(Ovladani.SmerDoleva))
            {
                smerPohybu -= Vector2.UnitX;
                Barva = Color.FromNonPremultiplied(R, G, B, A);
                do { R = R - 5; B = B + 5; } while (stavKlavesnice.IsKeyUp(Ovladani.SmerDoleva));
            }
            if (stavKlavesnice.IsKeyDown(Ovladani.SmerDoprava))
            { 
                smerPohybu += Vector2.UnitX;
                Barva = Color.FromNonPremultiplied(R, G, B, A);
                do { R = R + 5; B = B - 5; } while (stavKlavesnice.IsKeyUp(Ovladani.SmerDoprava));
            }
            if (smerPohybu != Vector2.Zero)
                Pozice += Vector2.Normalize(smerPohybu) * Rychlost;
        }

        public void Aktualizovat(GraphicsDeviceManager spravceGrafiky)
        {
            Vector2 rozmerPlatna = new Vector2(spravceGrafiky.PreferredBackBufferWidth, spravceGrafiky.PreferredBackBufferHeight);

            KeyboardState stavKlavesnice = Keyboard.GetState();

            Pohnout(stavKlavesnice, rozmerPlatna);
        }
        public void Vykreslit(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textura, Pozice, Barva);
        }
    }
}
