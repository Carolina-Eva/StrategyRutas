using BE;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        private Manager _manager = new Manager();
        private Navegador _navegador;
        private Mapa _mapa;
        const int TAM_CELDA = 40;
        private Ruta _rutaActual;
        private Nodo _origen;
        private Nodo _destino;

        public Form1()
        {
            InitializeComponent();
            pnlMapa.Paint += pnlMapa_Paint;
            Controls.Add(pnlMapa);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _mapa = CrearMapa();
            ConectarVecinos(_mapa);

            cboOrigen.DataSource = _mapa.Nodos;
            cboDestino.DataSource = _mapa.Nodos.ToList();

            cboOrigen.DisplayMember = "Nombre";
            cboDestino.DisplayMember = "Nombre";

            CargarEstrategias();
            CargarLeyenda();

            _navegador = new Navegador(new RutaMasCortaStrategy());
        }

        private void CargarLeyenda()
        {
            AgregarItemLeyenda(pnlLeyenda, Color.Khaki, "Zona congestionada", 10);
            AgregarItemLeyenda(pnlLeyenda, Color.LightCoral, "Zona riesgosa", 40);
            AgregarItemLeyenda(pnlLeyenda, Color.Blue, "Ruta calculada", 70);
            AgregarItemLeyenda(pnlLeyenda, Color.Green, "Origen", 100);
            AgregarItemLeyenda(pnlLeyenda, Color.Red, "Destino", 130);
        }

        private void CargarEstrategias()
        {
            cboEstrategia.DisplayMember = "Nombre";

            cboEstrategia.Items.Add(new RutaMasCortaStrategy());
            cboEstrategia.Items.Add(new RutaMasRapidaStrategy());
            cboEstrategia.Items.Add(new RutaMasSeguraStrategy());

            cboEstrategia.SelectedIndex = 0;
        }

        private void AgregarBidireccional(Nodo a, Nodo b, int distancia, int riesgo, int trafico, int costo = 0)
        {
            a.Aristas.Add(new Arista { Origen = a, Destino = b, Distancia = distancia, Riesgo = riesgo, Trafico = trafico, Costo = costo });
            b.Aristas.Add(new Arista { Origen = b, Destino = a, Distancia = distancia, Riesgo = riesgo, Trafico = trafico, Costo = costo });
        }

        private Mapa CrearMapa()
        {
            var mapa = new Mapa();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var nodo = new Nodo
                    {
                        Id = x * 10 + y,
                        Nombre = $"{x},{y}",
                        X = x,
                        Y = y,
                        ZonaRiesgosa = EsZonaRiesgosa(x, y),
                        ZonaCongestionada = EsZonaCongestionada(x, y)
                    };

                    mapa.Nodos.Add(nodo);
                }
            }

            return mapa;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            _origen = (Nodo)cboOrigen.SelectedItem;
            _destino = (Nodo)cboDestino.SelectedItem;

            IRutaStrategy estrategiaSeleccionada =
                (IRutaStrategy)cboEstrategia.SelectedItem;

            _navegador.CambiarEstrategia(estrategiaSeleccionada);

            var ruta = _navegador.CalcularRuta(_mapa, _origen, _destino);

            MostrarRuta(ruta);
        }

        private async Task<bool> GuardarRutas()
        {
            if (_rutaActual == null)
            {
                MessageBox.Show("No hay ruta para guardar.");
                return false;
            }
            var rutaCalculada = new RutaCalculada
            {
                OrigenX = _origen?.X ?? 0,
                OrigenY = _origen?.Y ?? 0,
                DestinoX = _destino?.X ?? 0,
                DestinoY = _destino?.Y ?? 0,
                Estrategia = cboEstrategia.SelectedItem?.ToString() ?? "",
                DistanciaTotal = _rutaActual.DistanciaTotal,
                RiesgoTotal = _rutaActual.RiesgoTotal,
                TraficoTotal = _rutaActual.TraficoTotal,
                PesoFinal = _rutaActual.PesoFinal,
                Fecha = DateTime.Now
            };
            bool exito = await _manager.GuardarRutaAsync(rutaCalculada);
            return exito;
        }

        private async void MostrarRuta(Ruta ruta)
        {
            _rutaActual = ruta;
            pnlMapa.Invalidate();

            lblMetricas.Text =
                $"Pasos: {ruta.Nodos.Count - 1} | Distancia: {ruta.DistanciaTotal} | Riesgo: {ruta.RiesgoTotal} | Tráfico: {ruta.TraficoTotal}";
            await GuardarRutas();
        }

        private void pnlMapa_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            DibujarGrilla(g);
            DibujarZonas(g);    // rojo / amarillo
            DibujarNodos(g);    // puntos
            DibujarRuta(g);     // azul
            DibujarOrigenDestino(g);
        }

        private void DibujarGrilla(Graphics g)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    g.DrawRectangle(Pens.Gray,
                        x * TAM_CELDA,
                        y * TAM_CELDA,
                        TAM_CELDA,
                        TAM_CELDA);
                }
            }
        }

        private void DibujarZonas(Graphics g)
        {
            foreach (var nodo in _mapa.Nodos)
            {
                if (nodo.ZonaRiesgosa)
                {
                    g.FillRectangle(
                        Brushes.LightCoral,
                        nodo.X * TAM_CELDA,
                        nodo.Y * TAM_CELDA,
                        TAM_CELDA,
                        TAM_CELDA);
                }
                else if (nodo.ZonaCongestionada)
                {
                    g.FillRectangle(
                        Brushes.Khaki,
                        nodo.X * TAM_CELDA,
                        nodo.Y * TAM_CELDA,
                        TAM_CELDA,
                        TAM_CELDA);
                }
            }
        }

        private void DibujarOrigenDestino(Graphics g)
        {
            if (_origen != null)
                DibujarPunto(g, _origen, Brushes.Green);

            if (_destino != null)
                DibujarPunto(g, _destino, Brushes.Red);
        }

        private void DibujarPunto(Graphics g, Nodo nodo, Brush color)
        {
            if (nodo == null) return;

            g.FillEllipse(
                color,
                nodo.X * TAM_CELDA + 10,
                nodo.Y * TAM_CELDA + 10,
                20,
                20);
        }

        private void DibujarNodos(Graphics g)
        {
            foreach (var nodo in _mapa.Nodos)
            {
                Brush brush = Brushes.LightBlue;

                g.FillEllipse(
                    brush,
                    nodo.X * TAM_CELDA + 10,
                    nodo.Y * TAM_CELDA + 10,
                    20,
                    20);

                // Nombre del nodo
                g.DrawString(
                    nodo.Nombre,
                    Font,
                    Brushes.Black,
                    nodo.X * TAM_CELDA + 2,
                    nodo.Y * TAM_CELDA + 2);
            }
        }

        private void DibujarRuta(Graphics g)
        {
            if (_rutaActual == null) return;

            Pen penRuta = new Pen(Color.Blue, 3);

            for (int i = 0; i < _rutaActual.Nodos.Count - 1; i++)
            {
                var a = _rutaActual.Nodos[i];
                var b = _rutaActual.Nodos[i + 1];

                g.DrawLine(
                    penRuta,
                    a.X * TAM_CELDA + TAM_CELDA / 2,
                    a.Y * TAM_CELDA + TAM_CELDA / 2,
                    b.X * TAM_CELDA + TAM_CELDA / 2,
                    b.Y * TAM_CELDA + TAM_CELDA / 2);
            }
        }

        private bool EsZonaRiesgosa(int x, int y)
        {
            return x >= 2 && x <= 5 && y >= 2 && y <= 5;
        }

        private bool EsZonaCongestionada(int x, int y)
        {
            return x >= 6 && y <= 8;
        }

        private void ConectarVecinos(Mapa mapa)
        {
            var dict = mapa.Nodos.ToDictionary(n => (n.X, n.Y));

            foreach (var nodo in mapa.Nodos)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0)
                            continue;

                        var key = (nodo.X + dx, nodo.Y + dy);

                        if (!dict.TryGetValue(key, out var vecino))
                            continue;

                        if (vecino.Id <= nodo.Id)
                            continue;

                        bool diagonal = dx != 0 && dy != 0;

                        int distancia = diagonal ? 14 : 10;
                        int riesgo = (nodo.ZonaRiesgosa || vecino.ZonaRiesgosa) ? 10 : 1;
                        int trafico = (nodo.ZonaCongestionada || vecino.ZonaCongestionada) ? 8 : 1;

                        AgregarBidireccional(nodo, vecino, distancia, riesgo, trafico);
                    }
                }
            }
        }

        private void AgregarItemLeyenda(
        Control parent,
        Color color,
        string texto,
        int top)
        {
            Panel colorBox = new Panel
            {
                BackColor = color,
                Width = 20,
                Height = 20,
                Location = new Point(10, top)
            };

            Label lbl = new Label
            {
                Text = texto,
                AutoSize = true,
                Location = new Point(40, top + 2)
            };

            parent.Controls.Add(colorBox);
            parent.Controls.Add(lbl);
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            using (var frm = new Info())
            {
                frm.ShowDialog();
            }
        }
    }
}
