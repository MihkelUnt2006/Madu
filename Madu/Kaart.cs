using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    using System;
    using System.Collections.Generic;

    public class Kaart
    {
        public List<Punkt> Takistused { get; private set; } = new List<Punkt>();

        public Kaart(int laius, int kõrgus)
        {
            // Horisontaalsed välisseinad (ülemine ja alumine)
            for (int x = 0; x < laius; x++)
            {
                Takistused.Add(new Punkt(x, 0, '#'));
                Takistused.Add(new Punkt(x, kõrgus - 1, '#'));
            }
            // Vertikaalsed välisseinad (vasak ja parem)
            for (int y = 0; y < kõrgus; y++)
            {
                Takistused.Add(new Punkt(0, y, '#'));
                Takistused.Add(new Punkt(laius - 1, y, '#'));
            }
        }

        public void Joonista()
        {
            foreach (var p in Takistused) p.Joonista();
        }
    }
}
