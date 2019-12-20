using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiniCtverecek
{
    public class Hra : Game
    {
        GraphicsDeviceManager SpravceGrafiky;
        SpriteBatch VykreslovaciDavka;

        int SirkaOkna = 1920;
        int VyskaOkna = 1080;


        Ctverecek ZkusebniCtverecek;

        public Hra()
        {
            SpravceGrafiky = new GraphicsDeviceManager(this);

            Window.Title = "Boxík měnící barvu";
        }

        protected override void Initialize()
        {
            SpravceGrafiky.PreferredBackBufferHeight = VyskaOkna;
            SpravceGrafiky.PreferredBackBufferWidth = SirkaOkna;
            SpravceGrafiky.ApplyChanges();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            VykreslovaciDavka = new SpriteBatch(GraphicsDevice);

            int velikost = 50;
            float rychlost = 5;

            Vector2 pozice = new Vector2((SirkaOkna - velikost) / 2, (VyskaOkna - velikost) / 2);
            Color barva = Color.Black;

           

                RidiciKlavesy ovladani = new RidiciKlavesy(Keys.Left, Keys.Right, Keys.Up, Keys.Down);

            ZkusebniCtverecek = new Ctverecek(velikost, rychlost, pozice, barva, ovladani, GraphicsDevice);
        }


protected override void Update(GameTime casOdPosledniAktualizace)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ZkusebniCtverecek.Aktualizovat(SpravceGrafiky);

            base.Update(casOdPosledniAktualizace);
        }
        protected override void Draw(GameTime casOdPoslednihoVykresleni)
        {
            GraphicsDevice.Clear(Color.GhostWhite);

            VykreslovaciDavka.Begin();
            #region Fronta pozadavku na vykresleni
            ZkusebniCtverecek.Vykreslit(VykreslovaciDavka);
            #endregion
            VykreslovaciDavka.End();

            base.Draw(casOdPoslednihoVykresleni);
        }
    }
}
