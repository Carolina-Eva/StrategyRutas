using BLL;

namespace UI
{
    public partial class Info : Form
    {
        private readonly Manager _manager = new Manager();
        public Info()
        {
            InitializeComponent();
        }

        private async void Info_Load(object sender, EventArgs e)
        {
            var rutas = await _manager.ListarRutasAsync();
            dgvRutas.DataSource = rutas;

            dgvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutas.ReadOnly = true;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
